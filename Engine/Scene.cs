using System.Numerics;
using Raylib_cs;
using Rectangle = Raylib_cs.Rectangle;

namespace Engine;

//Create a new Class inheriting Scene and call Load in the constructor to add gameobjects to the scene
public class Scene : IGameUpdatable
{
    private readonly SortedDictionary<int, List<GameObject>> _gameObjects = [];
    public readonly List<ICollidable> BoundingBoxes = [];
    public bool Paused = false;

    //Updates all Game Objects
    public void Update()
    {
        foreach (var gameObjectsKey in _gameObjects.Keys.ToList())
        {
            if (Paused && gameObjectsKey < Layers.UI)
            {
                continue;
            }

            _gameObjects[gameObjectsKey].ToList().ForEach(obj => obj.Update());
        }
    }

    //Renders all Game Objects
    public void Draw()
    {
        foreach (var gameObjectsKey in _gameObjects.Keys.ToList())
        {
            if (gameObjectsKey >= Layers.HUD)
                _gameObjects[gameObjectsKey].ToList().ForEach(obj => obj.Draw());
        }
    }

    //Renders all Game Objects
    public void Draw2D()
    {
        foreach (var gameObjectsKey in _gameObjects.Keys)
        {
            if (gameObjectsKey < Layers.HUD)
                _gameObjects[gameObjectsKey].ToList().ForEach(obj => obj.Draw());
        }
    }

    //Loads GameObjects into our scene (Highest Layer = Last drawn Element)
    public void Load(GameObject gameObject, int layer = Layers.Background)
    {
        var list = _gameObjects.GetValueOrDefault(layer, []);
        list.Add(gameObject);
        _gameObjects[layer] = list;
        try
        {
            gameObject.Load(this);
            if (gameObject is ICollidable collidable)
            {
                BoundingBoxes.Add(collidable);
            }
        }
        catch (Exception e)
        {
            Raylib.TraceLog(TraceLogLevel.Error, $"Failed to load GameObject of ID {gameObject.GetId()}: {e.Message}");
            list.Remove(gameObject);
            var updated = _gameObjects.GetValueOrDefault(layer, []);
            updated.Remove(gameObject);
            _gameObjects[layer] = updated;
        }
    }

    //Unloads GameObjects from the scene
    public void Unload(GameObject gameObject)
    {
        foreach (var gameObjectsKey in _gameObjects.Keys.ToList())
        {
            var list = _gameObjects[gameObjectsKey];
            if (!list.Contains(gameObject)) continue;
            list.Remove(gameObject);
            _gameObjects[gameObjectsKey] = list;
            if (gameObject is not ICollidable collidable) continue;
            BoundingBoxes.Remove(collidable);
        }

        try
        {
            gameObject.Unload(this);
        }
        catch (Exception e)
        {
            Raylib.TraceLog(TraceLogLevel.Warning,
                $"Failed to unload GameObject of ID {gameObject.GetId()}: {e.Message}");
        }
    }

    public List<GameObject> CollidesWith(Rectangle boundingBox)
    {
        return BoundingBoxes.Where(box => Raylib.CheckCollisionRecs(boundingBox, box.BoundingRect)).ToList()
            .ConvertAll(box => box as GameObject)!;
    }

    public List<GameObject> CollidesWith<T>(T self) where T : GameObject, ICollidable
    {
        return CollidesWith(obj => obj != self, self);
    }

    public List<GameObject> CollidesWith<T>(Predicate<GameObject> match, T self) where T : GameObject, ICollidable
    {
        return CollidesWith(self.BoundingRect).Where(obj => match(obj)).ToList();
    }

    public Dictionary<GameObject, RayCollision> CollidesWithRay(Ray ray)
    {
        var result = new Dictionary<ICollidable, RayCollision>();
        foreach (var box in BoundingBoxes)
        {
            var hit = Raylib.GetRayCollisionBox(ray,
                new BoundingBox(new Vector3(box.BoundingRect.X, box.BoundingRect.Y, 0),
                    new Vector3(box.BoundingRect.X + box.BoundingRect.Width,
                        box.BoundingRect.Y + box.BoundingRect.Height, 0)));
            if (!hit.Hit) continue;
            result.Add(box, hit);
        }

        var temp = result.ToList();
        temp.Sort((a, b) =>
        {
            var aDistance = Vector3.Distance(ray.Position, new Vector3(a.Key.BoundingRect.X, a.Key.BoundingRect.Y, 0));
            var bDistance = Vector3.Distance(ray.Position, new Vector3(b.Key.BoundingRect.X, b.Key.BoundingRect.Y, 0));
            return aDistance.CompareTo(bDistance);
        });
        return temp.ConvertAll(box => new KeyValuePair<GameObject, RayCollision>((GameObject)box.Key, box.Value))
            .ToDictionary();
    }

    //Find Game Objects loaded in the scene by id
    public List<GameObject> FindObjectsById(string id, int layer = Layers.Background)
    {
        return FindObjects(obj => obj.GetId() == id, layer);
    }

    //Find Game Objects loaded in the scene with a custom filter
    public List<GameObject> FindObjects(Predicate<GameObject> match, int layer = Layers.Background)
    {
        return _gameObjects[layer].FindAll(match);
    }
}
using Raylib_cs;

namespace Engine;

//Create a new Class inheriting Scene and call Load in the constructor to add gameobjects to the scene
public class Scene : IGameUpdatable
{
    private readonly SortedDictionary<int, List<GameObject>> _gameObjects = [];

    //Updates all Game Objects
    public void Update()
    {
        foreach (var gameObjectsKey in _gameObjects.Keys.ToList())
        {
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
using Raylib_cs;

namespace Engine;

//Create a new Class inheriting Scene and call Load in the constructor to add gameobjects to the scene
public class Scene : IGameUpdatable
{
    private readonly SortedDictionary<int, List<GameObject>> _gameObjects = [];

    //Updates all Game Objects
    public void Update()
    {
        foreach (var gameObjectsKey in _gameObjects.Keys)
        {
            _gameObjects[gameObjectsKey].ForEach(obj => obj.Update());
        }
    }

    //Renders all Game Objects
    public void Draw()
    {
        foreach (var gameObjectsKey in _gameObjects.Keys)
        {
            _gameObjects[gameObjectsKey].ForEach(obj => obj.Draw());
        }
    }

    //Loads GameObjects into our scene (Highest Layer = Last drawn Element)
    public void Load(GameObject gameObject, int layer = Layers.Background)
    {
        try
        {
            gameObject.Load(this);
        }
        catch (Exception e)
        {
            Raylib.TraceLog(TraceLogLevel.Error, $"Failed to load GameObject of ID {gameObject.GetId()}: {e.Message}");
            return;
        }
        var list = _gameObjects.GetValueOrDefault(layer, []);
        list.Add(gameObject);
        _gameObjects[layer] = list;
    }

    //Unloads GameObjects from the scene
    public void Unload(GameObject gameObject)
    {
        foreach (var gameObjectsKey in _gameObjects.Keys)
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
            Raylib.TraceLog(TraceLogLevel.Warning, $"Failed to unload GameObject of ID {gameObject.GetId()}: {e.Message}");
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
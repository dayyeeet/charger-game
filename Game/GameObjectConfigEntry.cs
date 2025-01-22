using Engine;

namespace Game;

public struct GameObjectConfigEntry(GameObject obj, int layer)
{
    public GameObject Obj { get; set; } = obj;
    public int Layer { get; set; } = layer;
}
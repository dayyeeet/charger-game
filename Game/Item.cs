using System.Numerics;
using Engine;

namespace Game;

public abstract class Item(string name) : GameObject($"item-{name}"), IPositionable
{
    private string _name = name;
    
    public string GetName() => _name;

    public void SetName(string name)
    {
        _name = name;
    }

    public Vector2 Position { get; set; }
}
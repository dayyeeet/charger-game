using System.Numerics;
using Engine;
using Raylib_cs;

namespace Game;

public abstract class Item(string name) : GameObject($"item-{name}"), IPositionable
{
    private string _name = name;

    public string GetName() => _name;

    public void SetName(string name)
    {
        _name = name;
    }

    public Vector2 Size {get; set; } = new(24, 24);
    public int Direction { get; set; }

    public abstract Texture2D Texture { get; }

    public Vector2 Position { get; set; }
}
using System.Numerics;
using Engine.Scene;
using Raylib_cs;

namespace Game.Item;

public abstract class Item(string name) : GameObject($"item-{name}"), IPositionable
{
    protected Vector2 Size { get; set; } = new(24, 24);
    public int Direction { get; set; }

    public Vector2 Offset { get; set; }

    public abstract Texture2D Texture { get; set; }

    public Vector2 Position { get; set; }
}
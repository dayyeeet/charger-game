using System.Numerics;

namespace Engine;

public abstract class HudElement(string id) : GameObject($"hud-element-{id}"), IPositionable, ISizeableObject
{
    public Vector2 Position { get; set; }
    public int ElementWidth { get; set; } //Must be set manually
    public int ElementHeight { get; set; } //Must be set manually
}
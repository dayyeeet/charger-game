using System.Numerics;
using Engine.Scene;

namespace Engine.World;

public abstract class WorldFeature(string id) : GameObject($"feature-{id}"), ISizeableObject, IPositionable
{
    public abstract int ElementWidth { get; set; }
    public abstract int ElementHeight { get; set; }
    public abstract Vector2 Position { get; set; }

    public abstract int Layer { get; set; }
}
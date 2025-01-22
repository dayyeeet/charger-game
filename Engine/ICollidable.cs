using Rectangle = Raylib_cs.Rectangle;

namespace Engine;

public interface ICollidable : IPositionable, ISizeableObject
{
    Rectangle BoundingRect
    {
        get => new(Position.X, Position.Y, ElementWidth, ElementHeight);
        set {}
    }

    public bool IsPassThrough()
    {
        return false;
    }

    public bool IsPlayerPassThrough()
    {
        return false;
    }
}
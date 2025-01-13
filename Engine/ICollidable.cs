using Rectangle = Raylib_cs.Rectangle;

namespace Engine;

public interface ICollidable : IPositionable, ISizeableObject
{
    Rectangle BoundingRect => new Rectangle(Position.X, Position.Y, ElementWidth, ElementHeight);

    public bool IsPassThrough()
    {
        return false;
    }
}
using System.Numerics;
using Raylib_cs;

namespace Engine;

public interface IGuiElement : ISizeableObject, IPositionable
{
    public Vector2 Size
    {
        get => new(ElementWidth, ElementHeight);
        set {}
    }

    void Draw(Rectangle bounds, GameWindow window);

    void Update(Rectangle bounds, GameWindow window)
    {
    }
}
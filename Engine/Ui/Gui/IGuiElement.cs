using System.Numerics;
using Engine.Scene;
using Engine.Util;
using Raylib_cs;

namespace Engine.Ui.Gui;

public interface IGuiElement : ISizeableObject, IPositionable
{
    public Vector2 Size
    {
        get => new(ElementWidth, ElementHeight);
        // ReSharper disable once ValueParameterNotUsed
        set { }
    }

    void Draw(Rectangle bounds, GameWindow window);

    void Update(Rectangle bounds, GameWindow window)
    {
    }
}
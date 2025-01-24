using System.Numerics;
using Engine.Ui.Gui;
using Engine.Util;
using Raylib_cs;

namespace Game.Ui.Gui;

public class SolidColorGuiElement(int width, int height) : IGuiElement
{
    public int ElementWidth { get; set; } = width;
    public int ElementHeight { get; set; } = height;
    public Vector2 Position { get; set; }

    public SolidColorGuiElement() : this(0, 0) {}
    
    public Color Color { get; set; } = new(0, 0, 0, 0x6f);
    public void Draw(Rectangle bounds, GameWindow window)
    {
        Raylib.DrawRectangleRec(bounds, Color);
    }
}
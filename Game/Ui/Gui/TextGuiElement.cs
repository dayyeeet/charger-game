using System.Numerics;
using Engine.Ui.Gui;
using Engine.Util;
using Raylib_cs;

namespace Game.Ui.Gui;

public class TextGuiElement(int height) : IGuiElement
{
    public int ElementWidth
    {
        get => Raylib.MeasureText(Text, ElementHeight);
        set { }
    }

    public int ElementHeight { get; set; } = height;

    public string Text { get; set; } = "Text";
    public Color Color { get; set; } = Color.Black;
    public Vector2 Position { get; set; }

    public void Draw(Rectangle bounds, GameWindow window)
    {
        Raylib.DrawText(Text, (int)bounds.X, (int)bounds.Y, ElementHeight, Color);
    }
}
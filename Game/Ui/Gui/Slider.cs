using System.Numerics;
using Engine.Ui.Gui;
using Engine.Util;
using Raylib_cs;

namespace Game.Ui.Gui;

public class Slider(int width, int height) : IGuiElement
{
    public int ElementWidth { get; set; } = width;
    public int ElementHeight { get; set; } = height;
    public Vector2 Position { get; set; }
    public int FontSize { get; set; } = 20;
    public string? Text { get; set; } = null;
    public Color TextColor { get; set; } = Color.White;
    public Color HighlightColor { get; set; } = new(0xff, 0xff, 0xff, 0x5f);
    public Color BackgroundColor { get; set; } = Color.Black;

    public float SliderValue = 1f;

    private bool _isHovered;

    public virtual void Draw(Rectangle bounds, GameWindow window)
    {
        Raylib.DrawRectangleRec(bounds, BackgroundColor);
        if (_isHovered) Raylib.DrawRectangleRec(bounds, HighlightColor);
        if (Text == null) return;
        var size = Raylib.MeasureText(Text, FontSize);
        var center = Position - new Vector2(size, 20) / 2;
        Raylib.DrawText(Text, (int)center.X, (int)center.Y, FontSize, TextColor);
        Raylib.DrawCircle((int)(SliderValue * bounds.Width + bounds.X), (int)(bounds.Height / 2 + bounds.Y),
            bounds.Height / 2, Color.LightGray);
    }

    public virtual void Update(Rectangle bounds, GameWindow window)
    {
        var mouse = Raylib.GetMousePosition();
        _isHovered = false;
        if (mouse.X < bounds.X || mouse.X > bounds.X + bounds.Width || mouse.Y < bounds.Y ||
            mouse.Y > bounds.Y + bounds.Height) return;
        _isHovered = true;

        if (Raylib.IsMouseButtonDown(MouseButton.Left))
        {
            SliderValue = (mouse.X - bounds.X) / bounds.Width;
        }

        if (!Raylib.IsMouseButtonPressed(MouseButton.Left)) return;
        OnClick();
    }

    public virtual void OnClick()
    {
    }
}
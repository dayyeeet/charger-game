using System.Numerics;
using Engine;
using Raylib_cs;

namespace Game;

public class ImageGuiElement(int width, int height) : IGuiElement
{
    public int ElementWidth { get; set; } = width;
    public int ElementHeight { get; set; } = height;
    public Vector2 Position { get; set; }

    public ImageGuiElement() : this(0, 0) {}
    public Texture2D? Image { get;  set; }
    public void Draw(Rectangle bounds, GameWindow window)
    {
        if (Image == null) return;
        var tex = Image.Value;
        Raylib.DrawTexturePro(tex, new Rectangle(0, 0, tex.Width, tex.Height), new Rectangle(Position, new Vector2(ElementWidth, ElementHeight)), Vector2.Zero, 0f, Color.White);
    }
}
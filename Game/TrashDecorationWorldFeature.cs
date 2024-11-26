using System.Numerics;
using Engine;
using Raylib_cs;

namespace Game;

public class TrashDecorationWorldFeature() : WorldFeature("trash-decoration")
{
    public override int ElementWidth { get; set; } = 50;
    public override int ElementHeight { get; set; } = 50;
    public override Vector2 Position { get; set; }
    public override int Layer { get; set; } = Layers.Decoration;

    public override void Draw()
    {
        Raylib.DrawRectangle((int)Position.X, (int)Position.Y, ElementWidth, ElementHeight, Color.Brown);
    }
}
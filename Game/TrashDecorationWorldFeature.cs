using System.Numerics;
using Engine;
using Raylib_cs;

namespace Game;

public class TrashDecorationWorldFeature() : WorldFeature("trash-decoration"), ICollidable
{
    public override int ElementWidth { get; set; } = 50;
    public override int ElementHeight { get; set; } = 50;
    public override Vector2 Position { get; set; }
    public override int Layer { get; set; } = Layers.Decoration;

    public Rectangle BoundingRect => new Rectangle(Position.X, Position.Y, ElementWidth, ElementHeight);
    
    public override void Draw()
    {
        Raylib.DrawRectangle((int)Position.X, (int)Position.Y, ElementWidth, ElementHeight, Color.Brown);
    }
}
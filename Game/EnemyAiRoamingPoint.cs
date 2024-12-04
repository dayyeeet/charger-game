using System.Numerics;
using Engine;
using Raylib_cs;

namespace Game;

public class EnemyAiRoamingPoint() : WorldFeature("roaming-point")
{
    public override void Draw()
    {
        Raylib.DrawCircle((int)Position.X, (int)Position.Y, 5f, Color.Blue);
    }

    public override int ElementWidth { get; set; } = 100;
    public override int ElementHeight { get; set; } = 100;
    public override Vector2 Position { get; set; }
    public override int Layer { get; set; } = Layers.Background;
}
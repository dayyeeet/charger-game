using System.Numerics;
using Engine.Scene;
using Engine.Util;
using Engine.World;
using Game.Util.Resource;
using Raylib_cs;

namespace Game.Level.One;

public class CarDecoration() : WorldFeature("car-decoration"), ICollidable
{
    private static readonly Texture2D Tex = EmbeddedTexture.LoadTexture("Game.level.one.car.png")!.Value;
    public override int ElementWidth { get; set; } = 220;
    public override int ElementHeight { get; set; } = (int)(220.0 * ((double)Tex.Height / Tex.Width));
    public override Vector2 Position { get; set; }
    public override int Layer { get; set; } = Layers.Decoration;

    public Rectangle BoundingRect
    {
        get => new(Position.X, Position.Y, ElementWidth, ElementHeight);
        set { }
    }

    public override void Draw()
    {
        var source = new Rectangle(0, 0, Tex.Width, Tex.Height);
        var dest = new Rectangle(Position.X, Position.Y, ElementWidth, ElementHeight);
        Raylib.DrawTexturePro(Tex, source, dest, Vector2.Zero, 0f, Color.White);
    }
}
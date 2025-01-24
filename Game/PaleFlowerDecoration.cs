 
using System.Numerics;
using Engine;
using Raylib_cs;

namespace Game;

public class PaleFlowerDecoration() : WorldFeature("pale-flowers-decoration"), ICollidable
{
    public override int ElementWidth { get; set; } = 50;
    public override int ElementHeight { get; set; } = (int) (50.0 * ((double)Tex.Height / Tex.Width));
    public override Vector2 Position { get; set; }
    public override int Layer { get; set; } = Layers.Decoration;

    public Rectangle BoundingRect
    {
        get => new(Position.X, Position.Y, ElementWidth, ElementHeight);
        set {}
    }

    public bool IsPassThrough()
    {
        return true;
    }


    private static readonly Texture2D Tex = EmbeddedTexture.LoadTexture("Game.level.two.pale-flowers.png")!.Value;


    public override void Draw()
    {
        var source = new Rectangle(0, 0, Tex.Width, Tex.Height);
        var dest = new Rectangle(Position.X, Position.Y, ElementWidth, ElementHeight);
        Raylib.DrawTexturePro(Tex, source, dest, Vector2.Zero, 0f, Color.White); 
    }
    
}
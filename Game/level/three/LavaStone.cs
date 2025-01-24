using System.Numerics;
using Engine;
using Raylib_cs;

namespace Game;

public class LavaStone() : WorldFeature("Lava-Stone-decoration"), ICollidable
{
    public override int ElementWidth { get; set; } = 400;
    public override int ElementHeight { get; set; } = (int)(400.0*((double)Tex.Height/Tex.Width));
    public override Vector2 Position { get; set; }
    public override int Layer { get; set; } = Layers.Decoration;

    public Rectangle BoundingRect
    {
        get => new(Position.X, Position.Y, ElementWidth, ElementHeight);
        set {}
    }


    private static readonly Texture2D Tex = EmbeddedTexture.LoadTexture("Game.level.three.lava-fountain.png")!.Value;


    public override void Draw()
    {
        var source = new Rectangle(0, 0, Tex.Width, Tex.Height);
        var dest = new Rectangle(Position.X, Position.Y, ElementWidth, ElementHeight);
        Raylib.DrawTexturePro(Tex, source, dest, Vector2.Zero, 0f, Color.White); 
    }
    
}
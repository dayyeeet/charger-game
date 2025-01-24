using System.Numerics;
using Engine.Util;
using Game.Util.Resource;
using Game.Util.World;
using Raylib_cs;

namespace Game.Level.Two;

public class BigBushDecoration() : DestroyableObject("big-bush-decoration", 20)
{
    private static readonly Texture2D Tex = EmbeddedTexture.LoadTexture("Game.level.two.big-bush.png")!.Value;
    public override int ElementWidth { get; set; } = 120;
    public override int ElementHeight { get; set; } = (int)(120.0 * ((double)Tex.Height / Tex.Width));
    public override Vector2 Position { get; set; }
    public override int Layer { get; set; } = Layers.Decoration;
    
    public Rectangle BoundingRect
    {
        get => new(Position.X, Position.Y, ElementWidth, ElementHeight);
        // ReSharper disable once ValueParameterNotUsed
        set { }
    }

    public override void Draw()
    {
        var source = new Rectangle(0, 0, Tex.Width, Tex.Height);
        var dest = new Rectangle(Position.X, Position.Y, ElementWidth, ElementHeight);
        Raylib.DrawTexturePro(Tex, source, dest, Vector2.Zero, 0f, Color.White);
    }
}
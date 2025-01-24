using System.Numerics;
using Engine.Scene;
using Engine.Util;
using Engine.World;
using Game.Util.Resource;
using Raylib_cs;

namespace Game.Level.One;

public class AlternateTireDecoration() : WorldFeature("trash-decoration"), ICollidable
{
    public override int ElementWidth { get; set; } = 50;
    public override int ElementHeight { get; set; } = 35;
    public override Vector2 Position { get; set; }
    public override int Layer { get; set; } = Layers.Decoration;

    public Rectangle BoundingRect
    {
        get => new(Position.X, Position.Y, ElementWidth, ElementHeight);
        set {}
    }


    private static readonly Texture2D Tex = EmbeddedTexture.LoadTexture("Game.level.one.tire-1.png")!.Value;


    public override void Draw()
    {
        var source = new Rectangle(0, 0, Tex.Width, Tex.Height);
        var dest = new Rectangle(Position.X, Position.Y, ElementWidth, ElementHeight);
        Raylib.DrawTexturePro(Tex, source, dest, Vector2.Zero, 0f, Color.White); 
    }
    
    }

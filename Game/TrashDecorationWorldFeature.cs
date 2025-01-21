using System.Numerics;
using Engine;
using Raylib_cs;

namespace Game;

public class TrashDecorationWorldFeature() : WorldFeature("trash-decoration"), ICollidable
{
    public override int ElementWidth { get; set; } = 100;
    public override int ElementHeight { get; set; } = 100;
    public override Vector2 Position { get; set; }
    public override int Layer { get; set; } = Layers.Decoration;

    public Rectangle BoundingRect
    {
        get => new(Position.X, Position.Y, ElementWidth, ElementHeight);
        set {}
    }


    private readonly Texture2D _tex = EmbeddedTexture.LoadTexture("Game.trash-bag.png")!.Value;


    public override void Draw()
    {
        var source = new Rectangle(0, 0, _tex.Width, _tex.Height);
        var dest = new Rectangle(Position.X, Position.Y, ElementWidth, ElementHeight);
        Raylib.DrawTexturePro(_tex, source, dest, Vector2.Zero, 0f, Color.White); 
    }
    
    }

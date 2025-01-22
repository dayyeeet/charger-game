using System.Numerics;
using Engine;
using Raylib_cs;

namespace Game;

public class Car2Decoration() : WorldFeature("brown-car-decoration"), ICollidable
{
    
    
    public override int ElementWidth { get; set; } = 120* (128/77);
    public override int ElementHeight { get; set; } = 70;
    public override Vector2 Position { get; set; }
    public override int Layer { get; set; } = Layers.Decoration;

    public Rectangle BoundingRect => new Rectangle(Position.X, Position.Y, ElementWidth, ElementHeight);
    
    
    private Texture2D _tex = EmbeddedTexture.LoadTexture("Game.brown-car-2.png")!.Value;


    public override void Draw()
    {
        var source = new Rectangle(0, 0, _tex.Width, _tex.Height);
        var dest = new Rectangle(Position.X, Position.Y, ElementWidth, ElementHeight);
        Raylib.DrawTexturePro(_tex, source, dest, Vector2.Zero, 0f, Color.White); 
    }
    
}

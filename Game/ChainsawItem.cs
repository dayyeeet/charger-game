using System.Numerics;
using Raylib_cs;

namespace Game;

public class ChainsawItem : Item
{
    private readonly Lazy<Texture2D> _texture = new(EmbeddedTexture.LoadTexture("Game.chainsaw.png")!.Value);
    public override Texture2D Texture
    {
        get => _texture.Value;
        set {}
    }

    public ChainsawItem() : base("chainsaw")
    {
    }

    public override void Draw()
    {
        base.Draw();

        var source = new Rectangle(0, 0, Texture.Width * Direction, Texture.Height);
        var destination = new Rectangle(Position.X, Position.Y, 64, 64);
        Raylib.DrawTexturePro(Texture, source, destination, Vector2.Zero, 0f, Color.White);
    }
}
using System.Numerics;
using Raylib_cs;

namespace Game;

public class MilkBottleItem : Item
{
    private readonly Lazy<Texture2D> _texture = new(EmbeddedTexture.LoadTexture("Game.milk-bottle.png")!.Value);
    public override Texture2D Texture => _texture.Value;

    public MilkBottleItem() : base("milk-bottle")
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
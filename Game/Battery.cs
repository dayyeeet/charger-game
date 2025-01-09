using System.Numerics;
using Raylib_cs;

namespace Game;

public class BatteryItem : Item
{
    private readonly Lazy<Texture2D> _texture = new(EmbeddedTexture.LoadTexture("Game.battery.png")!.Value);
    public override Texture2D Texture => _texture.Value;

    public BatteryItem() : base("battery")
    {
    }

    public override void Draw()
    {
        base.Draw();

        var source = new Rectangle(0, 0, Texture.Width, Texture.Height);
        var destination = new Rectangle(Position.X, Position.Y, 100, 100);
        Raylib.DrawTexturePro(Texture, source, destination, Vector2.Zero, 0f, Color.White);
    }
}
using System.Numerics;
using Game.Util.Resource;
using Raylib_cs;

namespace Game.Item;

public class BatteryItem() : Item("battery")
{
    private readonly Lazy<Texture2D> _texture = new(EmbeddedTexture.LoadTexture("Game.item.battery.png")!.Value);

    public override Texture2D Texture
    {
        get => _texture.Value;
        set { }
    }

    public override void Draw()
    {
        base.Draw();

        var source = new Rectangle(0, 0, Texture.Width * Direction, Texture.Height);
        var destination = new Rectangle(Position.X, Position.Y, 100, 100);
        Raylib.DrawTexturePro(Texture, source, destination, Vector2.Zero, 0f, Color.White);
    }
}
using System.Numerics;
using Raylib_cs;

namespace Game;

public class LaserGunItem() : GunItem("laser", new LaserGun())
{
    private readonly Lazy<Texture2D> _texture = new (EmbeddedTexture.LoadTexture("Game.lasergun.png")!.Value);
    public override Texture2D Texture
    {
        get => _texture.Value;
        set {}
    }

    public override void Draw()
    {
        base.Draw();
        var source = new Rectangle(0,0, Texture.Width * Direction, Texture.Height);
        Raylib.DrawTexturePro(Texture, source, new Rectangle(Position - Size / 2,Size), Vector2.Zero, 0F, Color.White);

    }
}
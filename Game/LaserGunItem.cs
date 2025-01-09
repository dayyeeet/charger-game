using System.Numerics;
using Raylib_cs;

namespace Game;

public class LaserGunItem() : GunItem("laser", new LaserGun())
{
    private readonly Lazy<Texture2D> _texture = new (EmbeddedTexture.LoadTexture("Game.plasma-gun.png")!.Value);
    public override Texture2D Texture => _texture.Value;
    public override void Draw()
    {
        base.Draw();
        var source = new Rectangle(0,0, Texture.Width * Direction, Texture.Height);
        Raylib.DrawTexturePro(Texture, source, new Rectangle(Position,new Vector2(64,64)), Vector2.Zero, 0F, Color.White);

    }
}
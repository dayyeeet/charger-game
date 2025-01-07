using System.Numerics;
using Raylib_cs;

namespace Game;

public class LaserGunItem() : GunItem("laser", new LaserGun())
{
    private Texture2D? texture = EmbeddedTexture.LoadTexture("Game.plasma-gun.png");
    public override void Draw()
    {
        base.Draw();
        if (texture == null) return;
        var tex = texture.Value;
        var source =new Rectangle(0,0, tex.Width, tex.Height);
        Raylib.DrawTexturePro(tex, source, new Rectangle(Position,new Vector2(64,64)), Vector2.Zero, 0F, Color.White);

    }
}
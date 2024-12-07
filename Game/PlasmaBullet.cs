using System.Numerics;
using Raylib_cs;

namespace Game;

public class PlasmaBullet(
    Vector2 startPosition,
    Vector2 direction,
    float shotDuration,
    float shotVelocity,
    float damageAmount,
    float energyCost,
    int maxDistance,
    Color color,
    Vector2 currentPosition) : FlyingProjectile(startPosition, direction, shotDuration, shotVelocity, damageAmount,
    energyCost, maxDistance, color, currentPosition)
{
    private Texture2D? texture = EmbeddedTexture.LoadTexture("Game.plasma-bullet.png");
    public override void Draw()
    {
        if (texture == null) return;
        var tex = texture.Value;
        var source =new Rectangle(0,0, tex.Width, tex.Height);
        var size = 25f;
        Raylib.DrawTexturePro(tex, source, new Rectangle(Position - new Vector2(size / 2, size / 2),new Vector2(size,size)), Vector2.Zero, ToDegrees(_direction)+90F, Color.White);

    }
    
    float ToDegrees(Vector2 direction)
    {      
        var x = direction.X;
        var y = direction.Y;
        float angleRadians = (float)Math.Atan2(y, x);
        float angleDegrees = angleRadians * (180f / (float)Math.PI);
        return angleDegrees;
    }
}
   
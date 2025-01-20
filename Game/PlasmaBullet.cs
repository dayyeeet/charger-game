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
    Vector2 currentPosition) : FlyingProjectile<Player>(startPosition, direction, shotDuration, shotVelocity,
    damageAmount,
    energyCost, maxDistance, color, currentPosition, obj => obj is not Player && obj is not PlasmaBullet)
{
    private static readonly Lazy<Texture2D> LazyTexture = new(EmbeddedTexture.LoadTexture("Game.plasma-bullet.png")!.Value);
    public Texture2D Texture => LazyTexture.Value;

    public override void Draw()
    {
        var source = new Rectangle(0, 0, Texture.Width, Texture.Height);
        var size = 25f;
        var dest = new Rectangle(Position + new Vector2(ElementWidth / 2, ElementHeight / 2),
            new Vector2(size, size));
        Raylib.DrawTexturePro(Texture, source,
            dest, new Vector2(size /2, size / 2),
            ToDegrees(_direction) + 90F, Color.White);
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
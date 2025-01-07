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
    private readonly Lazy<Texture2D> _texture = new(EmbeddedTexture.LoadTexture("Game.plasma-bullet.png")!.Value);
    public Texture2D Texture => _texture.Value;

    public override void Draw()
    {
        var source = new Rectangle(0, 0, Texture.Width, Texture.Height);
        var size = 25f;
        Raylib.DrawTexturePro(Texture, source,
            new Rectangle(Position - new Vector2(size / 2, size / 2), new Vector2(size, size)), Vector2.Zero,
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
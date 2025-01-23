using System.Numerics;
using Engine;
using Raylib_cs;

namespace Game;

public class PlasmaBullet(
    Vector2 startPosition,
    Vector2 direction,
    float shotDuration,
    float shotVelocity,
    float damageAmount,
    int maxDistance,
    Color color,
    Vector2 currentPosition) : FlyingProjectile<Player>(startPosition, direction, shotDuration, shotVelocity,
    damageAmount,
    maxDistance, color, currentPosition, obj => obj is not Player && !((ICollidable)obj).IsPassThrough())
{
    public PlasmaBullet() : this(Vector2.Zero, Vector2.Zero, 0f, 0f, 0f, 0, Color.White, Vector2.Zero)
    {
    }

    private static readonly Lazy<Texture2D> LazyTexture =
        new(EmbeddedTexture.LoadTexture("Game.plasma-bullet.png")!.Value);

    public Texture2D Texture
    {
        get => LazyTexture.Value;
        set { }
    }

    public override void Draw()
    {
        var source = new Rectangle(0, 0, Texture.Width, Texture.Height);
        var size = 25f;
        var dest = new Rectangle(Position + new Vector2(ElementWidth / 2, ElementHeight / 2),
            new Vector2(size, size));
        Raylib.DrawTexturePro(Texture, source,
            dest, new Vector2(size / 2, size / 2),
            ToDegrees(Direction) + 90F, Color.White);
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
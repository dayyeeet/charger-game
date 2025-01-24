using System.Numerics;
using Engine.Scene;
using Game.Entity.Player;
using Game.Util.Resource;
using Raylib_cs;

namespace Game.Gun.Projectile;

public class HunterBullet(
    Vector2 startPosition,
    Vector2 direction,
    float shotDuration,
    float shotVelocity,
    float damageAmount,
    int maxDistance,
    Color color,
    Vector2 currentPosition,
    Predicate<GameObject>? collisionFilter = null) : FlyingProjectile<Player>(startPosition, direction, shotDuration,
    shotVelocity,
    damageAmount,
    maxDistance, color, currentPosition, collisionFilter)
{
    public HunterBullet() : this(Vector2.Zero, Vector2.Zero, 0f, 0f, 0f, 0, Color.White, Vector2.Zero)
    {
    }

    private static readonly Lazy<Texture2D> LazyTexture =
        new(EmbeddedTexture.LoadTexture("Game.projectile.enemy-bullet.png")!.Value);

    public Texture2D Texture
    {
        get => LazyTexture.Value;
        // ReSharper disable once ValueParameterNotUsed
        set { }
    }

    public override void Draw()
    {
        var source = new Rectangle(0, 0, Texture.Width, Texture.Height);
        const float size = 25f;
        var dest = new Rectangle(Position + new Vector2(ElementWidth / 2.0f, ElementHeight / 2.0f),
            new Vector2(size, size));
        Raylib.DrawTexturePro(Texture, source,
            dest, new Vector2(size / 2, size / 2),
            ToDegrees(Direction) + 90F, Color.White);
    }

    private static float ToDegrees(Vector2 direction)
    {
        var x = direction.X;
        var y = direction.Y;
        var angleRadians = (float)Math.Atan2(y, x);
        var angleDegrees = angleRadians * (180f / (float)Math.PI);
        return angleDegrees;
    }
}
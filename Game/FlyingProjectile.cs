using System.Numerics;
using Engine;
using Raylib_cs;

namespace Game;

public class FlyingProjectile<TFilter>(
    Vector2 startPosition,
    Vector2 direction,
    float shotDuration,
    float shotVelocity,
    float damageAmount,
    float energyCost,
    int maxDistance,
    Color color,
    Vector2 currentPosition,
    Predicate<GameObject>? collisionFilter = null) : Projectile(
    startPosition, direction, shotDuration,
    maxDistance, color), ICollidable where TFilter : GameObject, ICollidable
{
    public Vector2 StartPosition = startPosition;
    public Vector2 Direction { get; set; } = direction;
    public float ShotVelocity = shotVelocity;
    public Color Color = color;
    public int MaxDistance = maxDistance;
    public float DamageAmount = damageAmount;
    private Predicate<GameObject>? _collisionFilter = collisionFilter;

    public Rectangle BoundingRect
    {
        get => new(Position.X, Position.Y, ElementWidth, ElementHeight);
        set { }
    }

    public bool IsPassThrough()
    {
        return true;
    }

    protected override void UpdateProjectilePosition()
    {
        Position += Direction * ShotVelocity * Raylib.GetFrameTime();

        if (Vector2.Distance(StartPosition, Position) > MaxDistance)
        {
            _scene?.Unload(this);
            return;
        }

        if (_scene != null)
        {
            _collisionFilter ??= obj => obj is TFilter;
            var collides = _scene.CollidesWith(_collisionFilter, this);
            foreach (var collider in collides)
            {
                if (collider is IDamageable damageable)
                {
                    damageable.Health.TakeDamage((int)DamageAmount);
                }
            }

            if (collides.Count > 0)
            {
                _scene.Unload(this);
            }
        }
    }

    public override void Draw()
    {
        Raylib.DrawCircleV(Position, 5f, Color);
    }

    public Vector2 Position { get; set; } = currentPosition;
    public int ElementWidth { get; set; } = 10;
    public int ElementHeight { get; set; } = 10;
}
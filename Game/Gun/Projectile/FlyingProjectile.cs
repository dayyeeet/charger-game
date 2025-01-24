using System.Numerics;
using Engine.Scene;
using Game.Entity.Enemy;
using Game.Util.Entity;
using Game.Util.Sound;
using Raylib_cs;

namespace Game.Gun.Projectile;

public class FlyingProjectile<TFilter>(
    Vector2 startPosition,
    Vector2 direction,
    float shotDuration,
    float shotVelocity,
    float damageAmount,
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
            Scene?.Unload(this);
            return;
        }

        if (Scene == null) return;
        _collisionFilter ??= obj => obj is TFilter;
        var collides = Scene.CollidesWith(_collisionFilter, this);
        foreach (var collider in collides)
        {
            if (collider is not IDamageable damageable) continue;
            damageable.Health.TakeDamage((int)DamageAmount);
            if(collider is Enemy)
                SoundLoading.Sound.PlaySound("hit-enemy", true);
        }

        if (collides.Count > 0)
        {
            Scene.Unload(this);
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
using System.Numerics;
using Engine;
using Raylib_cs;

namespace Game;

public class FlyingProjectile(
    Vector2 startPosition,
    Vector2 direction,
    float shotDuration,
    float shotVelocity,
    float damageAmount,
    float energyCost,
    int maxDistance,
    Color color,
    Vector2 currentPosition) : Projectile(startPosition, direction, shotDuration, shotVelocity, damageAmount, energyCost,
    maxDistance, color), ICollidable
{
    private readonly Vector2 _startPosition = startPosition;
    protected readonly Vector2 _direction = direction;
    private readonly float _shotVelocity = shotVelocity;
    private readonly Color _color = color;
    private readonly int _maxDistance = maxDistance;
    private readonly float _damageAmount = damageAmount;
    public Rectangle BoundingRect => new (Position.X, Position.Y, ElementWidth, ElementHeight);

    protected override void UpdateProjectilePosition()
    {
        Position += _direction * _shotVelocity * Raylib.GetFrameTime();
        
        if(Vector2.Distance(_startPosition, Position) > _maxDistance)
        {
            _scene?.Unload(this);
            return;
        }

        if (_scene != null)
        {
            var collides = _scene.CollidesWith(this);
            foreach (var collider in collides)
            {
                if (collider is Player player)
                {
                    player.TakeDamage((int)_damageAmount);
                    _scene.Unload(this);
                }
            }
        }
        
    }

    public override void Draw()
    {
        Raylib.DrawCircleV(Position, 5f, _color);
    }

    public Vector2 Position { get; set; } = currentPosition;
    public int ElementWidth { get; set; } = 10;
    public int ElementHeight { get; set; } = 10;
}
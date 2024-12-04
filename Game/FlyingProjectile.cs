using System.Numerics;
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
    maxDistance, color)
{
    private Vector2 _currentPosition = currentPosition;
    private readonly Vector2 _startPosition = startPosition;
    private readonly Vector2 _direction = direction;
    private readonly float _shotVelocity = shotVelocity;
    private readonly Color _color = color;
    private readonly int _maxDistance = maxDistance;

    protected override void UpdateProjectilePosition()
    {
        _currentPosition += _direction * _shotVelocity * Raylib.GetFrameTime();
        
        if(Vector2.Distance(_startPosition, _currentPosition) > _maxDistance)
        {
            _scene?.Unload(this);
        }
    }

    public override void Draw()
    {
        Raylib.DrawCircleV(_currentPosition, 5f, _color);
    }
}
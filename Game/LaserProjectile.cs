using System.Numerics;
using Raylib_cs;

namespace Game;

public class LaserProjectile(
    Vector2 startPosition,
    Vector2 direction,
    float shotDuration,
    float shotVelocity,
    float damageAmount,
    float energyCost,
    int maxDistance,
    Color color) : Projectile(startPosition, direction, shotDuration, shotVelocity, damageAmount, energyCost,
    maxDistance, color)
{
    private readonly Vector2 _startPosition = startPosition;
    private readonly Vector2 _direction = direction;
    private readonly float _shotVelocity = shotVelocity;
    private readonly Color _color = color;

    public override void Draw()
    {
        Raylib.DrawLineV(_startPosition, _startPosition + _direction * _shotVelocity, _color);
    }
}
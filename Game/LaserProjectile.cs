using System.Numerics;
using Engine;
using Raylib_cs;

namespace Game;

public class LaserProjectile(
    Vector2 startPosition,
    Vector2 direction,
    float shotVelocity,
    float damageAmount,
    float energyCost,
    int maxDistance,
    Color color) : Projectile(startPosition, direction, -1f, shotVelocity, damageAmount, energyCost,
    maxDistance, color)
{
    public Vector2 StartPosition = startPosition;
    public Vector2 Direction = direction;
    private readonly float _shotVelocity = shotVelocity;
    private readonly Color _color = color;

    public override void Draw()
    {
        Raylib.DrawLineV(StartPosition, StartPosition + Direction * _shotVelocity, _color);
    }
}
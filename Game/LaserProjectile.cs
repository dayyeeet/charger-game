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
    private GameObject? _hit;
    private RayCollision? _collision;

    public void Raycast()
    {
        var ray = new Ray(new Vector3(StartPosition.X, StartPosition.Y, 0), new Vector3(Direction.X, Direction.Y, 0));
        var collision = _scene?.CollidesWithRay(ray)
            .FirstOrDefault(it => it.Key is not Player && it.Key is not Projectile);
        if (collision == null || collision.Equals(default(KeyValuePair<GameObject, RayCollision>)))
        {
            _hit = null;
            _collision = null;
            return;
        }

        _hit = collision.Value.Key;
        _collision = collision.Value.Value;
    }

    public override void Draw()
    {
        if (_collision.HasValue)
        {
            var point = _collision.Value.Point;

            Raylib.DrawLineV(StartPosition, new Vector2(point.X, point.Y), _color);
            return;
        }

        Raylib.DrawLineV(StartPosition, StartPosition + Direction * _shotVelocity, _color);
    }

    public override void Update()
    {
        if(_hit is IDamageable damageable)
        {
              damageable.Health.TakeDamage(damageAmount * Raylib.GetFrameTime());
        }
    }
}
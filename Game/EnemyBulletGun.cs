using System.Numerics;
using Engine;
using Color = Raylib_cs.Color;

namespace Game;

public class EnemyBulletGun : Gun
{
    public override void Shoot(Scene scene, IPositionable origin, Vector2 targetPosition)
    {
        Vector2 direction = targetPosition - origin.Position;
        direction = Vector2.Normalize(direction);
        Vector2 startPosition = origin.Position;
        var projectile = new FlyingProjectile<Player>(startPosition, direction, 100, 1000, 5, 10, 1000, Color.Red, origin.Position);
        scene.Load(projectile, Layers.CollisionObject);
    }
}
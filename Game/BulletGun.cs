using System.Numerics;
using Engine;
using Color = Raylib_cs.Color;

namespace Game;

public class BulletGun : Gun
{
    public override void Shoot(Scene scene, IPositionable origin, Vector2 targetPosition)
    {
        Vector2 direction = targetPosition - origin.Position;
        direction = Vector2.Normalize(direction);
        Vector2 startPosition = origin.Position;
        FlyingProjectile projectile = new FlyingProjectile(startPosition, direction, 100, 1000, 10, 10, 1000, Color.Red, origin.Position);
        scene.Load(projectile, Layers.CollisionObject);
    }
}
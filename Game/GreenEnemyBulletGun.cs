using System.Numerics;
using Engine;
using Raylib_cs;

namespace Game;

public class GreenEnemyBulletGun : Gun
{
    public override void Shoot(Scene scene, Vector2 startPosition, Vector2 targetPosition)
    {
        Vector2 direction = targetPosition - startPosition;
        direction = Vector2.Normalize(direction);
        var projectile = new GreenPlasmaBullet(startPosition, direction, 100, 1000, 5, 1000, Color.Red, startPosition, it => !((ICollidable)it).IsPassThrough() && it is not Enemy);
        scene.Load(projectile, Layers.CollisionObject);
    }
}
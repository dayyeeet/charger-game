using System.Numerics;
using Engine;
using Game.level.three;
using Raylib_cs;

namespace Game;

public class DragonBulletGun: Gun
{
    public override void Shoot(Scene scene, Vector2 startPosition, Vector2 targetPosition)
    {
        Vector2 direction = targetPosition - startPosition;
        direction = Vector2.Normalize(direction);
        var projectile = new FireballBullet(startPosition, direction, 100, 1000, 5, 1000, startPosition);
        scene.Load(projectile, Layers.CollisionObject);
    }

   
}
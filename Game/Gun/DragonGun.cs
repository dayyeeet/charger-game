using System.Numerics;
using Engine.Scene;
using Engine.Util;
using Game.Gun.Projectile;

namespace Game.Gun;

public class DragonGun : Gun
{
    public override void Shoot(Scene scene, Vector2 startPosition, Vector2 targetPosition)
    {
        var direction = targetPosition - startPosition;
        direction = Vector2.Normalize(direction);
        var projectile = new Fireball(startPosition, direction, 100, 1000, 5, 1000, startPosition);
        scene.Load(projectile, Layers.CollisionObject);
    }
}
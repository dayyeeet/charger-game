using System.Numerics;
using Engine.Scene;
using Engine.Util;
using Game.Entity.Enemy;
using Game.Gun.Projectile;
using Game.Util.Sound;
using Raylib_cs;

namespace Game.Gun;

public class HunterGun : Gun
{
    public override void Shoot(Scene scene, Vector2 startPosition, Vector2 targetPosition)
    {
        SoundLoading.Sound.PlaySound("shoot", true);
        var direction = targetPosition - startPosition;
        direction = Vector2.Normalize(direction);
        var projectile = new HunterBullet(startPosition, direction, 100, 1000, 5, 1000, Color.Red, startPosition, it => !((ICollidable)it).IsPassThrough() && it is not Enemy);
        scene.Load(projectile, Layers.CollisionObject);
    }
}
using System.Numerics;
using Engine.Scene;
using Engine.Util;
using Game.Entity.Player;
using Game.Gun.Projectile;
using Color = Raylib_cs.Color;

namespace Game.Gun;

public class LaserGun : Gun, IPlayerGun
{
    private Laser? _laserProjectile;
    private Scene? _scene;
    public Player? Player { get; set; }
    public float EnergyCost { get; set; } = 0.1f;

    public override void Shoot(Scene scene, Vector2 startPosition, Vector2 targetPosition)
    {
        if (Player == null) return;
        if (Player.GetCurrentHealth() <= 30)
        {
            CancelShoot();
            return;
        }

        Player.TakeDamage(EnergyCost);
        Vector2 direction = targetPosition - startPosition;
        direction = Vector2.Normalize(direction);
        float angle = float.RadiansToDegrees(MathF.Atan2(direction.Y, direction.X)) - 90f;

        if (_laserProjectile == null)
        {
            _laserProjectile = new Laser(startPosition, direction, angle, 1000, 10, 10, Color.Green);
            _scene = scene;
            scene.Load(_laserProjectile, Layers.CollisionObject);
        }
        else
        {
            _laserProjectile.StartPosition = startPosition;
            _laserProjectile.Direction = direction;
            _laserProjectile.RotationDirection = angle;
        }

        _laserProjectile.Raycast();
    }

    public override float GetCooldown()
    {
        return 0f;
    }

    public override void CancelShoot()
    {
        if (_scene == null || _laserProjectile == null)
        {
            return;
        }

        _scene.Unload(_laserProjectile);
        _laserProjectile = null;
    }
}
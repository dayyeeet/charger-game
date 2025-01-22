using System.Numerics;
using Engine;
using Color = Raylib_cs.Color;

namespace Game;

public class LaserGun : Gun
{
    private LaserProjectile? _laserProjectile;
    private Scene? _scene;
    public override void Shoot(Scene scene, Vector2 startPosition, Vector2 targetPosition)
    {
        Vector2 direction = targetPosition - startPosition;
        direction = Vector2.Normalize(direction);
        float angle = float.RadiansToDegrees(MathF.Atan2(direction.Y, direction.X)) - 90f;
        
        if (_laserProjectile == null)
        {
            _laserProjectile = new LaserProjectile(startPosition, direction, angle, 1000, 10, 5, 10, Color.Green);
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
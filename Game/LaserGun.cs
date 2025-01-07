using System.Numerics;
using Engine;
using Color = Raylib_cs.Color;

namespace Game;

public class LaserGun : Gun
{
    private LaserProjectile? _laserProjectile;
    private Scene? _scene;
    public override void Shoot(Scene scene, IPositionable origin, Vector2 targetPosition)
    {
        Vector2 direction = targetPosition - origin.Position;
        direction = Vector2.Normalize(direction);
        Vector2 startPosition = origin.Position;
        if (_laserProjectile == null)
        {
            _laserProjectile = new LaserProjectile(startPosition, direction, 1000, 10, 5, 10, Color.Green);
            _scene = scene;
            scene.Load(_laserProjectile, Layers.CollisionObject);
        }
        else
        {
            _laserProjectile.StartPosition = startPosition;
            _laserProjectile.Direction = direction;
        }
        _laserProjectile.Raycast();
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
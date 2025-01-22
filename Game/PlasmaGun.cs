using System.Numerics;
using Engine;
using Raylib_cs;

namespace Game;

public class PlasmaGun : Gun
{
    public override void Shoot(Scene scene, Vector2 startPosition, Vector2 targetPosition)
    {
        Vector2 direction = targetPosition - startPosition;
        direction = Vector2.Normalize(direction);
        var projectile = new PlasmaBullet(startPosition, direction, 100, 1000, 5, 10, 1000, Color.Red, startPosition);
        scene.Load(projectile, Layers.CollisionObject);
    }
}
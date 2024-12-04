using System.Numerics;
using Engine;
using Color = Raylib_cs.Color;

namespace Game;

public class LaserGun : Gun
{
    public override void Shoot(Scene scene, IPositionable origin, Vector2 targetPosition)
    {
        Vector2 direction = targetPosition - origin.Position;
        direction = Vector2.Normalize(direction);
        Vector2 startPosition = origin.Position;
        LaserProjectile laser = new LaserProjectile(startPosition, direction, 1, 1000, 10, 5, 10, Color.Green);
        scene.Load(laser, Layers.CollisionObject);
    }
    
}
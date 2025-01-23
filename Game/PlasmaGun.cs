using System.Numerics;
using Engine;
using Raylib_cs;

namespace Game;

public class PlasmaGun : Gun, IPlayerGun
{
    public Player? Player { get; set; }
    public float EnergyCost { get; set; } = 2;

    public override void Shoot(Scene scene, Vector2 startPosition, Vector2 targetPosition)
    {
        if (Player == null) return;
        if (Player.GetCurrentHealth() <= 30) return;
        Player.TakeDamage(EnergyCost);
        Vector2 direction = targetPosition - startPosition;
        direction = Vector2.Normalize(direction);
        var projectile = new PlasmaBullet(startPosition, direction, 100, 1000, 5, 1000, Color.Red, startPosition);
        scene.Load(projectile, Layers.CollisionObject);
    }
}
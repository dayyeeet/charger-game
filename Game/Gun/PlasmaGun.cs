using System.Numerics;
using Engine.Scene;
using Engine.Util;
using Game.Entity.Player;
using Game.Gun.Projectile;
using Game.Util.Sound;
using Raylib_cs;

namespace Game.Gun;

public class PlasmaGun : Gun, IPlayerGun
{
    public Player? Player { get; set; }
    public float EnergyCost { get; set; } = 2;
    
    public override void Shoot(Scene scene, Vector2 startPosition, Vector2 targetPosition)
    {
        if (Player == null) return;
        if (Player.GetCurrentHealth() <= 30) return;
        Player.TakeDamage(EnergyCost);
        SoundLoading.Sound.PlaySound("shoot", true);
        Vector2 direction = targetPosition - startPosition;
        direction = Vector2.Normalize(direction);
        var projectile = new Plasma(startPosition, direction, 100, 1000, 5, 1000, Color.Red, startPosition);
        scene.Load(projectile, Layers.CollisionObject);
    }
}
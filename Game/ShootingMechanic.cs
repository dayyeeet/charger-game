using System.Numerics;
using Engine;
using Raylib_cs;

namespace Game;

public static class ShootingMechanic
{
    private const MouseButton ShootKeyBind = MouseButton.Left;

    public static void ShootIfKeyDown(Scene scene, IPositionable player)
    {
        if (Raylib.IsMouseButtonDown(ShootKeyBind))
        {
            var normalized = Raylib.GetMousePosition() - new Vector2(Game.Engine.GetWindow().GetWindowWidth() / 2f, Game.Engine.GetWindow().GetWindowHeight() / 2f);
            Shoot(scene, player.Position + normalized, player);
        }
    }

    public static void Shoot(Scene scene, Vector2 targetPosition, IPositionable origin, float shotDuration = 0.5f, float shotSpeed = 10f, float damageAmount = 10f)
    {
        Vector2 direction = targetPosition - origin.Position;
        direction = Vector2.Normalize(direction);
        Vector2 startPosition = origin.Position;
        int maxDistance = (int)(shotDuration * shotSpeed * 50);
        Projectile projectile = new Projectile(startPosition, direction, shotDuration, shotSpeed, damageAmount, maxDistance);
        scene.Load(projectile, Layers.CollisionObject);
    }
}
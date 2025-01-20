using System.Numerics;
using Engine;
using Raylib_cs;

namespace Game;

public static class ShootingMechanic
{
    private const MouseButton ShootKeyBind = MouseButton.Left;

    public static bool ShootIfKeyDown(Scene scene, IPositionable player, Gun currentGun)
    {
        if (Raylib.IsMouseButtonDown(ShootKeyBind))
        {
            var normalized = Raylib.GetMousePosition() - new Vector2(Game.Engine.GetWindow().GetWindowWidth() / 2f, Game.Engine.GetWindow().GetWindowHeight() / 2f);
            Shoot(scene, player, player.Position + normalized, currentGun);
            return true;
        }

        if (!Raylib.IsMouseButtonReleased(ShootKeyBind)) return false;
        currentGun.CancelShoot();
        return false;

    }

    public static void Shoot(Scene scene, IPositionable from, Vector2 to, Gun currentGun)
    {
        currentGun.Shoot(scene, from, to);
    }
    
    public static void Shoot(Scene scene, IPositionable from, ICollidable to, Gun currentGun)
    {
        Shoot(scene, from, to.Position + new Vector2(to.ElementWidth / 2, to.ElementHeight / 2), currentGun);
    }
}
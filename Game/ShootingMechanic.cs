using System.Numerics;
using Engine;
using Raylib_cs;

namespace Game;

public static class ShootingMechanic
{
    private const MouseButton ShootKeyBind = MouseButton.Left;

    public static bool ShootIfKeyDown(Scene scene, Vector2 from, Vector2 offset, Gun currentGun)
    {
        if (Raylib.IsMouseButtonDown(ShootKeyBind))
        {
            var center = new Vector2(Game.Engine.GetWindow().GetWindowWidth(),
                Game.Engine.GetWindow().GetWindowHeight()) / 2;
            var normalized = Raylib.GetMousePosition() - center;
            
            Shoot(scene, from, from + normalized - offset, currentGun);
            return true;
        }

        if (!Raylib.IsMouseButtonReleased(ShootKeyBind)) return false;
        currentGun.CancelShoot();
        return false;

    }

    public static void Shoot(Scene scene, Vector2 from, Vector2 to, Gun currentGun)
    {
        currentGun.Shoot(scene, from, to);
    }
    
    public static void Shoot(Scene scene, IPositionable from, ICollidable to, Gun currentGun)
    {
        Shoot(scene, from.Position, to.Position + new Vector2(to.ElementWidth / 2, to.ElementHeight / 2), currentGun);
    }
}
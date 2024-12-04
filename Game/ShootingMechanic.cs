using System.Numerics;
using Engine;
using Raylib_cs;

namespace Game;

public static class ShootingMechanic
{
    private const MouseButton ShootKeyBind = MouseButton.Left;

    public static void ShootIfKeyDown(Scene scene, IPositionable player, Gun currentGun)
    {
        if (Raylib.IsMouseButtonDown(ShootKeyBind))
        {
            var normalized = Raylib.GetMousePosition() - new Vector2(Game.Engine.GetWindow().GetWindowWidth() / 2f, Game.Engine.GetWindow().GetWindowHeight() / 2f);
            Shoot(scene, player,player.Position + normalized, currentGun);
        }
    }

    public static void Shoot(Scene scene, IPositionable from, Vector2 to, Gun currentGun)
    {
        currentGun.Shoot(scene, from, to);
    }
    
    public static void Shoot(Scene scene, IPositionable from, IPositionable to, Gun currentGun)
    {
        Shoot(scene, from, to.Position, currentGun);
    }
}
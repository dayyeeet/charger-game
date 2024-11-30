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
            currentGun.Shoot(scene, player,player.Position + normalized);
        }
    }
}
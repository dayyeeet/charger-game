using System.Numerics;
using Engine;
using Raylib_cs;

namespace Game;

public class SampleScene : Scene
{
    public SampleScene()
    {
        var window = Game.Engine.GetWindow();
        var player = new Player(new Vector2(window.GetWindowWidth() / 2f, window.GetWindowHeight() / 2f));
        Game.Engine.SetTracking(player);
        var manager = new HudRenderer();
        manager.RegisterHudElement(HudPositions.TopLeft, new HudHealth(Color.Green));
        manager.RegisterHudElement(HudPositions.TopLeft, new HudXp(Color.Blue));
        Load(player, Layers.Player);
        Load(manager, Layers.HUD);
    }
}
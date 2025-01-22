using System.Numerics;
using Engine;
using Raylib_cs;

namespace Game;

public class LevelScene : Scene
{
    public GameWorld GameWorld { get; private set; }
    public LevelScene(GameWorld gameWorld)
    {
        GameWorld = gameWorld;
        var window = Game.Engine.GetWindow();
        var player = new Player(new Vector2(window.GetWindowWidth() / 2f, window.GetWindowHeight() / 2f));
        Game.Engine.SetTracking(player);
        gameWorld.Player = player;
        Load(new EnemySpawnManager(0));
        Load(gameWorld);
        Load(new DeathPopover());
        var manager = new HudRenderer();
        manager.RegisterHudElement(HudPositions.TopLeft, new HudHealth());
        manager.RegisterHudElement(HudPositions.TopLeft, new HudXp());
        manager.RegisterHudElement(HudPositions.Bottom, new HudHotbar());
        Load(manager, Layers.HUD);
        Load(new TestPopover(), Layers.UI);
        Load(new DebugKeyHandler());
        Load(new PickupManager());
    }
}


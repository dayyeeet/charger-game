using System.Numerics;
using System.Text.Json.Serialization;
using Engine;

namespace Game;

public class LevelScene : Scene
{
    public GameWorld GameWorld { get; private set; }

    public LevelScene()
    {
        SoundLoading.Music.PlayMusic("SoundTrack1");
    }
    public LevelScene(GameWorld gameWorld,
        Player? playerBefore = null) : this()
    {
        GameWorld = gameWorld;
        var window = Game.Engine.GetWindow();
        var player = playerBefore ?? new Player(new Vector2(window.GetWindowWidth() / 2f, window.GetWindowHeight() / 2f));
        Game.Engine.SetTracking(player);
        gameWorld.Player = player;
        Load(new EnemySpawnManager(player.Level()));
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
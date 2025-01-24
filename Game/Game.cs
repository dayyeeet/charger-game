using Engine;
using Game.Entity.Player;
using Game.Level.One;
using Game.Level.Three;
using Game.Level.Two;
using Game.Ui.Gui;
using Game.Util.Save;
using Game.Util.Sound;
using Game.Util.World;

namespace Game;

internal static class Game
{
    //Call Game.Engine anywhere when you need to get access to other components
    public static readonly GameEngine Engine = new();

    public static void Main()
    {
        Engine.Start(() =>
        {
            SoundLoading.Load();
            Engine.LoadScene(new MainMenu());
        });
    }

    public static void Start()
    {
        Engine.LoadScene(SaveManager.LoadScene());
        Save();
    }

    public static void Save()
    {
        if (Engine.GetScene() != null) SaveManager.SaveScene(Engine.GetScene()!);
    }

    public static void LoadNextLevel(Player? player = null)
    {
        var level = (player?.Level() ?? 1) % 3;
        GameWorld world = new LevelOneWorld(1500, 1500);
        switch (level)
        {
            case 1:
                world = new LevelOneWorld(1500, 1500);
                break;
            case 2:
                world = new LevelTwoWorld(1500, 1500);
                break;
            case 0:
                world = new LevelThreeWorld(1500, 1500);
                break;
        }

        var scene = new LevelScene(world, player);
        Engine.LoadScene(scene);
        Save();
    }
}
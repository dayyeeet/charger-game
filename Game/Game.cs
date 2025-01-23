using Engine;

namespace Game;

class Game
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
        SoundLoading.Music.StopMusic("TitleScreenMusic");
        Engine.LoadScene(SaveManager.LoadScene());
        Save();
    }

    public static void Save()
    {
        if (Engine.GetScene() != null) SaveManager.SaveScene(Engine.GetScene()!);
    }

    public static void LoadNextLevel(Player? player = null)
    {
        Engine.StopCurrentMusic();
        var level = player?.Level() ?? 0;
        GameWorld world = new LevelTwoWorld(1500, 1500);
        switch (level)
        {
            case 1:
                world = new LevelOneWorld(1500, 1500);
                break;
            case 2:
                world = new LevelTwoWorld(1500, 1500);
                break;
            case 3:
                world = new LevelThreeWorld(1500, 1500);
                break;
        }

        var scene = new LevelScene(world, player);
        Engine.LoadScene(scene);
        Save();
    }
}
using System.Numerics;
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
        if(Engine.GetScene() != null) SaveManager.SaveScene(Engine.GetScene()!);
    }

    public static void NewGame()
    {
        SoundLoading.Music.StopMusic("TitleScreenMusic");
        Engine.LoadScene(new LevelScene(new LevelOneWorld(1500, 1500)));
        Save();
    }
}
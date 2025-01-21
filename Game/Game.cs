using System.Numerics;
using Engine;

namespace Game;

class Game
{
    //Call Game.Engine anywhere when you need to get access to other components
    public static readonly GameEngine Engine = new();

    public static void Main()
    {
        //You will need to load a scene before Start is called
        Engine.LoadScene(new MainMenu());
        Engine.Start();
    }

    public static void Start()
    {
        Engine.LoadScene(SaveManager.LoadScene());
        Save();
    }
    public static void Save()
    {
        if(Engine.GetScene() != null) SaveManager.SaveScene(Engine.GetScene()!);
    }

    public static void NewGame()
    {
        Engine.LoadScene(new LevelScene(new LevelOneWorld(1500, 1500)));
        Save();
    }
}
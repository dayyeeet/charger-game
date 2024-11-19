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
        Engine.LoadScene(new SampleScene());
        Engine.Start();
    }
}
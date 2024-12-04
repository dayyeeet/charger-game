using System.Numerics;
using Engine;
using Raylib_cs;

namespace Game;

public class Level2 : Scene
{
    public Level2()
    {
        var window = Game.Engine.GetWindow();
        var player = new Player(new Vector2(window.GetWindowWidth() / 2f, window.GetWindowHeight() / 2f));
        Game.Engine.SetTracking(player);
        Load(player);
    }
}


using System.Numerics;
using Engine;
using Raylib_cs;

namespace Game;

public class Level3 : Scene
{
    public Level3()
    {
        var window = Game.Engine.GetWindow();
        var player = new Player(new Vector2(window.GetWindowWidth() / 2f, window.GetWindowHeight() / 2f));
        Game.Engine.SetTracking(player);
        Load(player);
    }
}

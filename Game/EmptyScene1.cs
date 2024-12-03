using System.Numerics;
using Engine;

namespace Game;

public class Level2 : Scene
{
    public Level2() : base() { }

    public void Initialize()
    {
        var player = new Player(new Vector2(200, 200));
        Load(player);
    }
}


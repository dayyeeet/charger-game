using System.Numerics;
using Engine;

namespace Game;

public class EmptyScene2 : Scene
{
    public EmptyScene2() : base() { }

    public void Initialize()
    {
        var player = new Player(new Vector2(200, 200));
        Load(player);
    }
}

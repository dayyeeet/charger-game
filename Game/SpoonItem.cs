using Raylib_cs;

namespace Game;

public class SpoonItem() : Item("spoon")
{

    public override void Draw()
    {
        Raylib.DrawCircle((int)Position.X, (int)Position.Y, 10f, Color.Beige);

    }
}
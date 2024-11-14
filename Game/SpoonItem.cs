using Raylib_cs;

namespace Game;

public class SpoonItem() : Item("spoon")
{

    private readonly Texture2D _spoony = Raylib.LoadTexture("resources/new-spoon.jpeg"); 
    
    public override void Draw()
    {
        //Raylib.DrawCircle((int)Position.X, (int)Position.Y, 10f, Color.Beige);
        Raylib.DrawTexture(_spoony,(int)Position.X , (int)Position.Y, Color.Beige);
    }
}
using System.Numerics;
using Engine;
using Raylib_cs;
namespace Game;

public class SpoonItem() : Item("spoon")
{
  private Texture2D? _spoonTexture = EmbeddedTexture.LoadTexture("Game.wood-spoony.png");
    public override void Draw()
    {
        if ( _spoonTexture is not null)
        {
           Raylib.DrawTexture(_spoonTexture.Value, (int)Position.X, (int)Position.Y, Color.Beige);
        }

    }
}
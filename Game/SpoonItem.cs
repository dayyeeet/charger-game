using System.Numerics;
using Engine;
using Raylib_cs;
namespace Game;

public class SpoonItem() : Item("spoon")
{
  private Texture2D? _spoonTexture = EmbeddedTexture.LoadTexture("Game.wood-spoon.png");
    public override void Draw()
    {
        if ( _spoonTexture is not null)
        {
           var tex = _spoonTexture.Value;
           var src = new Rectangle(0, 0, tex.Width, tex.Height);
           var dest = new Rectangle(Position.X, Position.Y, 64, 64);
           Raylib.DrawTexturePro(tex, src, dest, Vector2.Zero,0, Color.White);
        }

    }
}
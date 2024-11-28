using Raylib_cs;

namespace Game;


    public class PlaceholderItem() : Item("placeholder")
         {
             private Texture2D? _placeholderTexture = EmbeddedTexture.LoadTexture("Game.drill-black.png");
             public override void Draw()
             {
                 if ( _placeholderTexture is not null)
                 {
                     Raylib.DrawTexture(_placeholderTexture.Value, (int)Position.X, (int)Position.Y, Color.Beige);
                 }
     
             }
         }

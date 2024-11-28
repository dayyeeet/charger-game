using Raylib_cs;

namespace Game;


    public class PlaceholderItem2() : Item("placeholder2")
    {
        private Texture2D? _placeholderTexture = EmbeddedTexture.LoadTexture("Game.drill-red.png");
        public override void Draw()
        {
            if ( _placeholderTexture is not null)
            {
                Raylib.DrawTexture(_placeholderTexture.Value, (int)Position.X, (int)Position.Y, Color.Beige);
            }

        }
    }

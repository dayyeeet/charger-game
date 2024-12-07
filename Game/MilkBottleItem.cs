using System.Numerics;
using Raylib_cs;

namespace Game;

public class MilkBottleItem : Item
{
    private Texture2D? _chainsawTexture = EmbeddedTexture.LoadTexture("Game.milk_bottle.png");

    public MilkBottleItem() : base("milkbottle")
    {
        
    }

    public override void Draw()
    {
        base.Draw();
        
        
        if (_chainsawTexture != null)
        {
            var tex = _chainsawTexture.Value;
            var source = new Rectangle(0, 0, tex.Width, tex.Height);
            var destination = new Rectangle(Position.X, Position.Y, 100, 100); 
            Raylib.DrawTexturePro(tex, source, destination, Vector2.Zero, 0f, Color.White);
        }
        else
        {
            Raylib.TraceLog(TraceLogLevel.Warning, "Chainsaw texture is null!");
        }
    }
}
using System.Numerics;
using Raylib_cs;

namespace Game;

public class ChainsawItem : Item
{
    private Texture2D? _chainsawTexture = EmbeddedTexture.LoadTexture("Game.chainsaw.png");

    public ChainsawItem() : base("chainsaw")
    {
        
    }

    public override void Draw()
    {
        base.Draw();
        
        
        if (_chainsawTexture != null)
        {
            var tex = _chainsawTexture.Value;
            var source = new Rectangle(0, 0, tex.Width, tex.Height);
            var destination = new Rectangle(Position.X, Position.Y, 64, 64); 
            Raylib.DrawTexturePro(tex, source, destination, Vector2.Zero, 0f, Color.White);
        }
        else
        {
            Raylib.TraceLog(TraceLogLevel.Warning, "Chainsaw texture is null!");
        }
    }
}
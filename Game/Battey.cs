using System.Numerics;
using Raylib_cs;

namespace Game;

public class BatteryItem : Item
{
    private Texture2D? _batteryTexture = EmbeddedTexture.LoadTexture("Game.battery.png");

    public BatteryItem() : base("battery")
    {
        
    }

    public override void Draw()
    {
        base.Draw();

        if (_batteryTexture != null)
        {
            var tex = _batteryTexture.Value;
            var source = new Rectangle(0, 0, tex.Width, tex.Height);
            var destination = new Rectangle(Position.X, Position.Y, 100, 100); 
            Raylib.DrawTexturePro(tex, source, destination, Vector2.Zero, 0f, Color.White);
        }
        else
        {
            Raylib.TraceLog(TraceLogLevel.Warning, "Battery texture is null!");
        }
    }
}
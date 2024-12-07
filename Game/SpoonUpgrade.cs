using System.Numerics;
using Raylib_cs;

namespace Game;

public class SpoonUpgradeItem : Item
{
    private Texture2D? _spoonUpgradeTexture = EmbeddedTexture.LoadTexture("Game.SpoonUpgrade.png");

    public SpoonUpgradeItem() : base("spoon_upgrade")
    {
        // You can set other properties or effects related to the upgrade
    }

    public override void Draw()
    {
        base.Draw();

        if (_spoonUpgradeTexture != null)
        {
            var tex = _spoonUpgradeTexture.Value;
            var source = new Rectangle(0, 0, tex.Width, tex.Height);
            var destination = new Rectangle(Position.X, Position.Y, 100, 100); // Adjust size as needed
            Raylib.DrawTexturePro(tex, source, destination, Vector2.Zero, 0f, Color.White);
        }
        else
        {
            Raylib.TraceLog(TraceLogLevel.Warning, "Spoon upgrade texture is null!");
        }
    }
}
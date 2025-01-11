using System.Numerics;
using Engine;
using Raylib_cs;

namespace Game;

public class ChainsawItem() : CloseCombatItem("chainsaw", 10f)
{
    private readonly Lazy<Texture2D> _texture = new(EmbeddedTexture.LoadTexture("Game.chainsaw.png")!.Value);
    public override Texture2D Texture => _texture.Value;
    public override void OnHit<T>(T other)
    {
        other.Health.TakeDamage(10);
    }

    

    public override void Draw()
    {
        base.Draw();

        var source = new Rectangle(0, 0, Texture.Width * Direction, Texture.Height);
        var destination = new Rectangle(Position.X, Position.Y, 64, 64);
        Raylib.DrawTexturePro(Texture, source, destination, Vector2.Zero, 0f, Color.White);
    }
}
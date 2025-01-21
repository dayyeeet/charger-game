using System.Numerics;
using Engine;
using Raylib_cs;

namespace Game;

public class SpoonItem() : Item("spoon")
{
    private readonly Lazy<Texture2D> _texture = new(EmbeddedTexture.LoadTexture("Game.wood-spoon.png")!.Value);
    public override Texture2D Texture
    {
        get => _texture.Value;
        set {}
    }

    public override void Draw()
    {
        var src = new Rectangle(0, 0, Texture.Width * Direction, Texture.Height);
        var dest = new Rectangle(Position.X, Position.Y, 64, 64);
        Raylib.DrawTexturePro(Texture, src, dest, Vector2.Zero, 0, Color.White);
    }
}
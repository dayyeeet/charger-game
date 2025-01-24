using System.Numerics;
using Engine;
using Raylib_cs;

namespace Game;

public class SpoonItem : CloseCombatItem
{
    private readonly Lazy<Texture2D> _texture = new(EmbeddedTexture.LoadTexture("Game.item.wood-spoon.png")!.Value);
    
    public SpoonItem() : base("spoon", 0.1f)
    {
        Size = new Vector2(64, (int)(64.0f * ((double)_texture.Value.Height / _texture.Value.Width)));
        ElementWidth = (int)Size.X;
        ElementHeight = (int)Size.Y;
    }
    
    public override Texture2D Texture
    {
        get => _texture.Value;
        set {}
    }

    public override void OnHit(IDamageable other)
    {
        if (other is not Player)
        {
            SoundLoading.Sound.PlaySound("hit");
            other.Health.TakeDamage(2);
        }
    }

    public override void OnSwing()
    {
        base.OnSwing();
        SoundLoading.Sound.PlaySound("swing");
    }


    public override void Draw()
    {
        base.Draw();

        var source = new Rectangle(0, 0, Texture.Width * Direction, Texture.Height);
        var destination = new Rectangle(BoundingRect.Position, BoundingRect.Size);
        Raylib.DrawTexturePro(Texture, source, destination, Vector2.Zero, 0f, Color.White);
    }
}
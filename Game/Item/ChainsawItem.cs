using System.Numerics;
using Game.Entity.Player;
using Game.Util.Entity;
using Game.Util.Resource;
using Game.Util.Sound;
using Raylib_cs;

namespace Game.Item;

public class ChainsawItem : CloseCombatItem
{
    private readonly Lazy<Texture2D> _texture = new(EmbeddedTexture.LoadTexture("Game.item.chainsaw.png")!.Value);

    public ChainsawItem() : base("chainsaw", 0.1f)
    {
        Size = new Vector2(64, (int)(64.0f * ((double)_texture.Value.Height / _texture.Value.Width)));
        ElementWidth = (int)Size.X;
        ElementHeight = (int)Size.Y;
    }

    public override Texture2D Texture
    {
        get => _texture.Value;
        set { }
    }

    public override void OnHit(IDamageable other)
    {
        if (other is not Player)
        {
            other.Health.TakeDamage(2);
        }
    }

    public override void OnSwing()
    {
        base.OnSwing();
        SoundLoading.Sound.PlaySound("chainsaw");
    }


    public override void Draw()
    {
        base.Draw();

        var source = new Rectangle(0, 0, Texture.Width * Direction, Texture.Height);
        var destination = new Rectangle(BoundingRect.Position, BoundingRect.Size);
        Raylib.DrawTexturePro(Texture, source, destination, Vector2.Zero, 0f, Color.White);
    }
}
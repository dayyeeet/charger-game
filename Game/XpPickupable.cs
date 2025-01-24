using System.Numerics;
using Raylib_cs;

namespace Game;

public class XpPickupable : Pickupable
{
    public double Xp { get; set; }
    public XpPickupable(Vector2 position, double xp) : base("xp", 10, 10)
    {
        Position = position;
        Xp = xp;
    }

    private readonly Animation _anim = new("Game.entity.xp.xp.png", 0.3f);
    
    public XpPickupable() : this(Vector2.Zero, 0) {}

    protected override void OnPickup(Player player)
    {
        player.AddXp(Xp);
        SoundLoading.Sound.PlaySound("xp", true);
        ShouldUnload = true;
    }

    public override void Update()
    {
        base.Update();
        _anim.Animate();
    }

    public override void Draw()
    {
        base.Draw();
        var size = new Vector2(ElementWidth, ElementHeight) * 6f;
        _anim.Draw(new Rectangle(Position - size / 2, size));
    }
}
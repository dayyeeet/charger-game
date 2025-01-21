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
    
    public XpPickupable() : this(Vector2.Zero, 0) {}

    protected override void OnPickup(Player player)
    {
        player.AddXp(Xp);
        ShouldUnload = true;
    }

    public override void Draw()
    {
        base.Draw();
        // ReSharper disable once PossibleLossOfFraction
        Raylib.DrawCircleV(Position, (ElementWidth - 1) / 2, Color.Blue);
    }
}
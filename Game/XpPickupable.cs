using System.Numerics;
using Raylib_cs;

namespace Game;

public class XpPickupable : Pickupable
{
    private readonly double _xp;
    public XpPickupable(Vector2 position, double xp) : base("xp", 10, 10)
    {
        Position = position;
        _xp = xp;
    }

    protected override void OnPickup(Player player)
    {
        player.AddXp(_xp);
        ShouldUnload = true;
    }

    public override void Draw()
    {
        base.Draw();
        // ReSharper disable once PossibleLossOfFraction
        Raylib.DrawCircleV(Position, (ElementWidth - 1) / 2, Color.Blue);
    }
}
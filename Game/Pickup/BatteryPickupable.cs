using System.Numerics;
using Game.Entity.Player;
using Game.Util.Sound;

namespace Game.Pickup;

public class BatteryPickupable : ItemPickupable
{
    public BatteryPickupable()
    {
    }

    public BatteryPickupable(Vector2 position, Item.Item item) : base(position, item)
    {
    }

    public override void OnControlledPickup(Player player)
    {
        var healthSystem = player.Health;
        if (!healthSystem.IsDead)
        {
            healthSystem.Heal(20);
            SoundLoading.Sound.PlaySound("BatteryPickup", true);
        }

        ShouldUnload = true;
    }
}
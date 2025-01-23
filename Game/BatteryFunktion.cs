using System.Numerics;
using Engine;

namespace Game;

public class BatteryFunktion : ItemPickupable
{
    public BatteryFunktion()
    {
    }

    public BatteryFunktion(Vector2 position, Item item) : base(position, item)
    {
    }

    public override void OnControlledPickup(Player player)
    {
        var healthSystem = player.Health;
        if (healthSystem != null && !healthSystem.IsDead)
        {
            healthSystem.Heal(20);
            SoundLoading.Sound.PlaySound("BatteryPickup", true);
        }

        ShouldUnload = true;
    }
}
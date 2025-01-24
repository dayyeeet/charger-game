using System.Numerics;
using Engine.Scene;
using Engine.Util;
using Game.Item;
using Game.Pickup;

namespace Game.Util.Loot;

public static class ItemLootTable
{
    private static readonly Dictionary<Type, double> Loot = new();

    static ItemLootTable()
    {
        Loot.Add(typeof(LaserGunItem), 0.05);
        Loot.Add(typeof(PlasmaGunItem), 0.05);
        Loot.Add(typeof(BatteryItem), 0.5);
        Loot.Add(typeof(ChainsawItem), 0.2);
        Loot.Add(typeof(SpoonItem), 0.2);
    }

    public static void SpawnLoot(Vector2 position, Scene scene)
    {
        var result = LootTable.RandomOfLootTable(Loot);
        var instance = Activator.CreateInstance(result) as Item.Item;
        var itemPickupable = new ItemPickupable(position, instance);
        if (instance is BatteryItem) itemPickupable = new BatteryPickupable(position, instance);
        scene.Load(itemPickupable, Layers.Decoration);
    }
}
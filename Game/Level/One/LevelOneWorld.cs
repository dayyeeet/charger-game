using Engine.Scene;
using Engine.Util;
using Engine.World;
using Game.Entity.Enemy;
using Game.Entity.Enemy.Hunter;
using Game.Entity.Enemy.Rooter;
using Game.Util.World;
using Raylib_cs;

namespace Game.Level.One;

public class LevelOneWorld(int dimensionX, int dimensionY, bool shouldLoad = true) : GameWorld(dimensionX, dimensionY,
    "Game.level.one.background.png", new Color(0xb5, 0x90, 0x74, 0xff), shouldLoad)
{
    public LevelOneWorld() : this(0, 0, false)
    {
    }

    public override void Load(Scene scene)
    {
        base.Load(scene);
        if (!ShouldLoad) return;
        var populator = new WorldPopulator(scene);
        populator.Populate(Player!, dimensionX, dimensionY, Layers.Player);
        populator.Populate<TreeDecoration>(Dimension, 0.05f);
        populator.Populate<RooterSpawner>(Dimension, 0.005f);
        populator.Populate<HunterSpawner>(Dimension, 0.005f);
        populator.Populate<EnemyAiRoamingPoint>(Dimension, 0.05f);
        populator.Populate<RockDecoration>(Dimension, 0.05f);
        populator.Populate<BigRockDecoration>(Dimension, 0.05f);
        populator.Populate<BuggyDecoration>(Dimension, 0.02f);
        populator.Populate<CarDecoration>(Dimension, 0.02f);
        populator.Populate<Chest>(Dimension, 0.002f);
        populator.Populate<AlternateTireDecoration>(Dimension, 0.003f);
        populator.Populate<TireDecoration>(Dimension, 0.002f);
        populator.Populate<GrassDecoration>(Dimension, 0.05f);
        populator.Populate<TallGrassDecoration>(Dimension, 0.03f);
    }
}
using Engine.Scene;
using Engine.Util;
using Engine.World;
using Game.Entity.Enemy;
using Game.Entity.Enemy.Dragon;
using Game.Entity.Enemy.Hunter;
using Game.Entity.Enemy.Rooter;
using Game.Util.World;
using Raylib_cs;

namespace Game.Level.Three;

public class LevelThreeWorld(int dimensionX, int dimensionY, bool shouldLoad = true)
    : GameWorld(dimensionX, dimensionY, "Game.level.three.background.png", new Color(0x5b, 0x2e, 0x35, 0xff), shouldLoad)
{
    public LevelThreeWorld() : this(0, 0, false)
    {
    }

    public override void Load(Scene scene)
    {
        base.Load(scene);
        if (!ShouldLoad) return;
        var populator = new WorldPopulator(scene);
        populator.Populate(Player!, dimensionX, dimensionY, Layers.Player);
        populator.Populate<Chest>(Dimension, 0.002f);
        populator.Populate<LavaBigRockDecoration>(Dimension, 0.05f);
        populator.Populate<LavaStoneDecoration>(Dimension, 0.05f);
        populator.Populate<BigRockDecoration>(Dimension, 0.05f);
        populator.Populate<DragonSpawner>(Dimension, 0.05f);
        populator.Populate<RooterSpawner>(Dimension, 0.05f);
        populator.Populate<HunterSpawner>(Dimension, 0.01f);
        populator.Populate<EnemyAiRoamingPoint>(Dimension, 0.05f);
        populator.Populate<CharredBushDecoration>(Dimension, 0.05f);
        populator.Populate<CharredTreeDecoration>(Dimension, 0.01f);
        populator.Populate<SmallRockDecoration>(Dimension, 0.01f);
        populator.Populate<DragonNestDecoration>(Dimension, 0.01f);
        
    }
}
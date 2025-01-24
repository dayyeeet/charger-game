using Engine;

namespace Game.level.three;

public class LevelThreeWorld(int dimensionX, int dimensionY, bool shouldLoad = true)
    : GameWorld(dimensionX, dimensionY, "Game.level3.level-3.png", new(0x5b, 0x2e, 0x35, 0xff), shouldLoad)
{
    public LevelThreeWorld() : this(0, 0, false)
    {
    }

    public override void Load(Scene scene)
    {
        base.Load(scene);
        if (!_shouldLoad) return;
        var populator = new WorldPopulator(scene);
        populator.Populate(Player, dimensionX, dimensionY, Layers.Player);
        populator.Populate<LevelThreeChest>(Dimension, 0.002f);
        populator.Populate<LavaBigRockDecoration>(Dimension, 0.05f);
        populator.Populate<LavaStone>(Dimension, 0.05f);
        populator.Populate<LevelThreeRock1>(Dimension, 0.05f);
        populator.Populate<Enemy3Spawner>(Dimension, 0.05f);
        populator.Populate<Enemy2Spawner>(Dimension, 0.05f);
        populator.Populate<TestEnemySpawner>(Dimension, 0.01f);
        populator.Populate<EnemyAiRoamingPoint>(Dimension, 0.05f);
        populator.Populate<CharredBushDecoration>(Dimension, 0.05f);
        populator.Populate<CharredTreeDecoration>(Dimension, 0.01f);
        populator.Populate<SmallRockDecoration>(Dimension, 0.01f);
        populator.Populate<DragonNest>(Dimension, 0.01f);
        
    }
}
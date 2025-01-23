using Engine;

namespace Game;

public class LevelTwoWorld(int dimensionX, int dimensionY, bool shouldLoad = true) : GameWorld(dimensionX, dimensionY,
    "Game.level-2.png", new(0x55, 0x64, 0x34, 0xff), shouldLoad)
{
    public LevelTwoWorld() : this(0, 0, false)
    {
    }

    public override void Load(Scene scene)
    {
        base.Load(scene);
        if (!_shouldLoad) return;
        var populator = new WorldPopulator(scene);
        populator.Populate(Player, dimensionX, dimensionY, Layers.Player);
        populator.Populate<LevelTwoChest>(Dimension, 0.002f);
        populator.Populate<PlaneDecoration>(Dimension, 0.05f);
        populator.Populate<RockFormationDecoration>(Dimension, 0.05f);
        populator.Populate<TestEnemySpawner>(Dimension, 0.01f);
        populator.Populate<EnemyAiRoamingPoint>(Dimension, 0.05f);
        populator.Populate<TankDecoration>(Dimension, 0.05f);
        populator.Populate<Tank2Decoration>(Dimension, 0.05f);
        populator.Populate<BigBushDecoration>(Dimension, 0.01f);
        populator.Populate<FallenLogDecoration>(Dimension, 0.01f);
        populator.Populate<SmallRockDecoration>(Dimension, 0.005f);
        populator.Populate<GrassDecoration>(Dimension, 0.01f);
        populator.Populate<TallGrassDecoration>(Dimension, 0.005f);
        populator.Populate<PaleFlowerDecoration>(Dimension, 0.01f);
    }
}
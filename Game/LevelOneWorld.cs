using Engine;

namespace Game;

public class LevelOneWorld(int dimensionX, int dimensionY, bool shouldLoad = true) : GameWorld(dimensionX, dimensionY,
    "Game.level.one.background.png", new(0xb5, 0x90, 0x74, 0xff), shouldLoad)
{
    public LevelOneWorld() : this(0, 0, false)
    {
    }

    public override void Load(Scene scene)
    {
        base.Load(scene);
        if (!_shouldLoad) return;
        var populator = new WorldPopulator(scene);
        populator.Populate(Player, dimensionX, dimensionY, Layers.Player);
        populator.Populate<LevelOneTree1>(Dimension, 0.05f);
        populator.Populate<Enemy2Spawner>(Dimension, 0.005f);
        populator.Populate<TestEnemySpawner>(Dimension, 0.005f);
        populator.Populate<EnemyAiRoamingPoint>(Dimension, 0.05f);
        populator.Populate<LevelOneRock1>(Dimension, 0.05f);
        populator.Populate<LevelOneRock2>(Dimension, 0.05f);
        populator.Populate<CarDecorationWorldFeature>(Dimension, 0.02f);
        populator.Populate<Car2Decoration>(Dimension, 0.02f);
        populator.Populate<LevelOneChest>(Dimension, 0.002f);
        populator.Populate<TrashDecorationWorldFeature>(Dimension, 0.003f);
        populator.Populate<Trash2Decoration>(Dimension, 0.002f);
        populator.Populate<LevelOneGrassDecoration>(Dimension, 0.05f);
        populator.Populate<LevelOneTallGrassDecoration>(Dimension, 0.03f);
    }
}
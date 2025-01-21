using Engine;

namespace Game;

public class LevelTwoWorld(int dimensionX, int dimensionY) : GameWorld(dimensionX, dimensionY,"Game.level-2.png", new(0x55, 0x64, 0x34, 0xff))   
{
    public LevelTwoWorld() : this(0, 0) {}
    public override void Load(Scene scene)
    {
        base.Load(scene);
        var populator = new WorldPopulator(scene);
        populator.Populate(Player, dimensionX, dimensionY, Layers.Player);
        populator.Populate<EnemySpawner<TestEnemy>>(Dimension, 0.01f);
        populator.Populate<EnemyAiRoamingPoint>(Dimension, 0.05f);
        populator.Populate<CarDecorationWorldFeature>(Dimension, 0.05f);
        populator.Populate<TrashDecorationWorldFeature>(Dimension, 0.01f);
        populator.Populate<TestDestroyableObject>(Dimension, 0.001f);
    }
}
using Engine;

namespace Game;

public class LevelOneWorld(int dimensionX, int dimensionY) : GameWorld(dimensionX, dimensionY,"Game.background.png", new(0xb5, 0x90, 0x74, 0xff))
{

    private readonly bool _shouldLoad = true;

    public LevelOneWorld() : this(0, 0)
    {
        _shouldLoad = false;
    }
    public override void Load(Scene scene)
    {
        base.Load(scene);
        if (!_shouldLoad) return;
        var populator = new WorldPopulator(scene);
        populator.Populate(Player, dimensionX, dimensionY, Layers.Player);
        populator.Populate<TestEnemySpawner>(Dimension, 0.01f);
        populator.Populate<EnemyAiRoamingPoint>(Dimension, 0.05f);
        populator.Populate<CarDecorationWorldFeature>(Dimension, 0.05f);
        populator.Populate<TrashDecorationWorldFeature>(Dimension, 0.01f);
        populator.Populate<TestDestroyableObject>(Dimension, 0.001f);
    }
}
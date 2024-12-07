using Engine;
using Raylib_cs;

namespace Game;

public class GameWorld(int dimensionX, int dimensionY, Player player): GameObject("world")
{
    public Rectangle Dimension { get; } = new(0, 0, dimensionX * 2, dimensionY * 2);
    
    public override void Load(Scene scene)
    {
        var populator = new WorldPopulator(scene);
        populator.Populate(player, dimensionX, dimensionY, Layers.Player);
        populator.Populate<EnemyAiRoamingPoint>(Dimension, 0.05f);
        populator.Populate(new TestEnemy(), dimensionX + dimensionX / 2, dimensionY, Layers.Entity);
        populator.Populate<TrashDecorationWorldFeature>(Dimension, 0.01f);
        populator.Populate<TestDestroyableObject>(Dimension, 0.001f);
    }

    public override void Draw()
    {
        Raylib.DrawRectangleLines((int)Dimension.X, (int)Dimension.Y, (int)Dimension.Width, (int)Dimension.Height, Color.Black);
    }
}
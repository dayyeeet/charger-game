using Engine;
using Raylib_cs;

namespace Game;

public class GameWorld(int dimensionX, int dimensionY, Player player): GameObject("world")
{
    public Rectangle Dimension { get; } = new(0, 0, dimensionX * 2, dimensionY * 2);
    
    public override void Load(Scene scene)
    {
        var populator = new WorldPopulator(scene);
        populator.Populate<TrashDecorationWorldFeature>(Dimension, 0.01f);
        populator.Populate(player, dimensionX, dimensionY, Layers.Player);
    }

    public override void Draw()
    {
        Raylib.DrawRectangleLines((int)Dimension.X, (int)Dimension.Y, (int)Dimension.Width, (int)Dimension.Height, Color.Black);
    }
}
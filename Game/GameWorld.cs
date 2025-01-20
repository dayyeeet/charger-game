using System.Numerics;
using Engine;
using Raylib_cs;

namespace Game;

public class GameWorld(int dimensionX, int dimensionY, Player player) : GameObject("world")
{
    public Rectangle Dimension { get; } = new(0, 0, dimensionX * 2, dimensionY * 2);

    private Lazy<Texture2D> _texture = new(EmbeddedTexture.LoadTexture("Game.background.png")!.Value);
    public Texture2D Background => _texture.Value;
    private readonly Color _backgroundColor = new(0xb5, 0x90, 0x74, 0xff);
    private const float BackgroundMarginWidth = 5;
    private const float BackgroundMarginHeight = 2.5f;

    public override void Load(Scene scene)
    {
        var populator = new WorldPopulator(scene);
        populator.Populate(player, dimensionX, dimensionY, Layers.Player);
        populator.Populate<EnemyAiRoamingPoint>(Dimension, 0.05f);
        populator.Populate<TestEnemy>(Dimension, 0.0010f, Layers.Entity);
        populator.Populate<Enemy2>(Dimension, 0.0030f, Layers.Entity);
        populator.Populate<CarDecorationWorldFeature>(Dimension, 0.05f);
        populator.Populate<TrashDecorationWorldFeature>(Dimension, 0.01f);
        populator.Populate<TestDestroyableObject>(Dimension, 0.001f);
        Game.Engine.BackgroundColor = _backgroundColor;
    }

    public override void Draw()
    {
        Rectangle src = new(0, 0, Background.Width, Background.Height);
        Rectangle dst = new((int)Dimension.X - Background.Width / BackgroundMarginWidth,
            Dimension.Y - Background.Height / BackgroundMarginHeight,
            (int)Dimension.Width + Background.Width / BackgroundMarginWidth * 2,
            Dimension.Height + Background.Height / BackgroundMarginHeight * 2);
        Raylib.DrawTexturePro(Background, src, dst, Vector2.Zero, 0f, Color.White);
        if(Game.Engine.HitBoxesVisible)
            Raylib.DrawRectangleLines((int)Dimension.X, (int)Dimension.Y, (int)Dimension.Width, (int)Dimension.Height,
            Color.Yellow);
    }
}
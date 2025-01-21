using System.Numerics;
using Engine;
using Raylib_cs;

namespace Game;

public class GameWorld(int dimensionX, int dimensionY, string backgroundTex, Color backgroundColor) : GameObject("world")
{
    public Player Player { get; set; }
    
    public Rectangle Dimension { get; set; } = new(0, 0, dimensionX * 2, dimensionY * 2);

    private readonly Lazy<Texture2D> _texture = new(EmbeddedTexture.LoadTexture(backgroundTex)!.Value);
    private Texture2D Background => _texture.Value;
    private const float BackgroundMarginWidth = 5;
    private const float BackgroundMarginHeight = 2.5f;

    public override void Load(Scene scene)
    {
        base.Load(scene);
        Game.Engine.BackgroundColor = backgroundColor;
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
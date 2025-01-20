

using System.Numerics;
using Engine;
using Raylib_cs;

namespace Game;

public class Level2 : Scene
{
    private Texture2D _backgroundTexture;

    public Level2()
    {
        _backgroundTexture = Raylib.LoadTexture("Assets/Level-2.png");
        var window = Game.Engine.GetWindow();
        var player = new Player(new Vector2(window.GetWindowWidth() / 2f, window.GetWindowHeight() / 2f));
        Game.Engine.SetTracking(player);
        Load(player, Layers.Player);
        var manager = new HudRenderer();
        manager.RegisterHudElement(HudPositions.TopLeft, new HudHealth(Color.Green));
        manager.RegisterHudElement(HudPositions.TopLeft, new HudXp(Color.Blue));
        Load(manager, Layers.HUD);
    }

    public override void Draw2D()
    {
        Raylib.DrawTexture(_backgroundTexture, 0, 0, Color.White);
        base.Draw2D();
    }

}

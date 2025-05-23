using System.Numerics;
using Engine.Scene;
using Engine.Ui.Gui;
using Engine.Util;
using Game.Util.Resource;
using Game.Util.Sound;
using Raylib_cs;

namespace Game.Ui.Gui;

public class MainMenu : Scene
{
    public MainMenu()
    {
        SoundLoading.Music.PlayMusic("main-menu");
        Game.Engine.BackgroundColor = new Color(0xff, 0xff, 0xff, 0xff);
        var gui = new GuiProvider(Game.Engine.GetWindow());
        gui.Add(new ImageGuiElement(Game.Engine.GetWindow().GetWindowWidth(), Game.Engine.GetWindow().GetWindowHeight())
        {
            Image = EmbeddedTexture.LoadTexture("Game.background.png")!.Value
        }, new Vector2(0, 0));
        gui.Add(new TextGuiElement(70)
        {
            Text = "charger",
        }, new Vector2(0.5f, 0.3f));
        gui.Add(new StartButton(200, 50), new Vector2(0.5f, 0.45f));
        gui.Add(new NewGameButton(200, 50), new Vector2(0.5f, 0.53f));
        gui.Add(new QuitButton(200, 50), new Vector2(0.5f, 0.61f));
        Load(gui, Layers.UI);
    }
}
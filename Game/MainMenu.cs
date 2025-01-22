using System.Numerics;
using Engine;
using Raylib_cs;

namespace Game;

public class MainMenu : Scene
{
    public MainMenu()
    {
        Load(new SoundHelper());
        Game.Engine.BackgroundColor = new Color(0xff, 0xff, 0xff, 0xff);
        var gui = new GuiProvider(Game.Engine.GetWindow());
        gui.Add(new TextGuiElement(70)
        {
            Text = "Robot Game",
        }, new Vector2(0.5f, 0.3f));
        gui.Add(new StartButton(200, 50), new Vector2(0.5f, 0.45f));
        gui.Add(new NewGameButton(200, 50), new Vector2(0.5f, 0.53f));
        gui.Add(new QuitButton(200, 50), new Vector2(0.5f, 0.61f));
        Load(gui, Layers.UI);
        SoundLoading.Music.PlayMusic("TitleScreenMusic");
    }
}
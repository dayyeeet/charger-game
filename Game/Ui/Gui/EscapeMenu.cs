using System.Numerics;
using Engine.Ui.Gui;
using Game.Util.Sound;

namespace Game.Ui.Gui;

public class EscapeMenu : GuiProvider
{
    public EscapeMenu() : base(Game.Engine.GetWindow())
    {
        var window = Game.Engine.GetWindow();
        Add(new SolidColorGuiElement(window.GetWindowWidth(), window.GetWindowHeight()), new Vector2(0.5f, 0.5f));
        Add(new SaveButton(200, 50), new Vector2(0.5f, 0.45f));
        Add(new MainMenuButton(200, 50), new Vector2(0.5f, 0.53f));
        Add(new QuitButton(200, 50), new Vector2(0.5f, 0.61f));
        Add(new SoundEffectVolumeSlider(200, 20), new Vector2(0.5f, 0.71f));
        Add(new MusicVolumeSlider(200, 20), new Vector2(0.5f, 0.81f));
    }
}
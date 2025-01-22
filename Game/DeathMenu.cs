using System.Numerics;
using Engine;
using Raylib_cs;

namespace Game;

public class DeathMenu : GuiProvider
{
    public DeathMenu(GameWindow window) : base(window)
    {
        Add(new SolidColorGuiElement(window.GetWindowWidth(), window.GetWindowHeight())
        {
            Color = new Color(0xFF, 0x0F, 0x0F, 0x6F)
        }, new Vector2(0.5f, 0.5f));
        Add(new TextGuiElement(50)
        {
            Text = "You Died",
            Color = new Color(0xFF, 0xFF, 0xFF, 0xFF)
        }, new Vector2(0.5f, 0.35f));
        Add(new MainMenuButton
        {
            ShouldSave = false,
        }, new Vector2(0.5f, 0.45f));
        Add(new QuitButton
        {
            ShouldSave = false,
        }, new Vector2(0.5f, 0.53f));
    }
}
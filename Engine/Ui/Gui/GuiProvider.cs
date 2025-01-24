using System.Numerics;
using Engine.Scene;
using Engine.Util;
using Raylib_cs;

namespace Engine.Ui.Gui;

public class GuiProvider(GameWindow window) : GameObject("gui-provider")
{
    private readonly List<IGuiElement> _elements = [];

    public override void Update()
    {
        foreach (var guiElement in _elements)
        {
            guiElement.Update(new Rectangle(guiElement.Position - guiElement.Size / 2, guiElement.Size), window);
        }
    }

    public void Add(IGuiElement element, Vector2 normalizedPosition)
    {
        element.Position = normalizedPosition * new Vector2(window.GetWindowWidth(), window.GetWindowHeight());
        _elements.Add(element);
    }

    public override void Draw()
    {
        foreach (var guiElement in _elements)
        {
            guiElement.Draw(new Rectangle(guiElement.Position - guiElement.Size / 2, guiElement.Size), window);
        }
    }
}
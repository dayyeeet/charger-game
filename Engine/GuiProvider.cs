using System.Numerics;
using Raylib_cs;

namespace Engine;

public class GuiProvider(GameWindow window) : GameObject("gui-provider")
{
    public List<IGuiElement> Elements { get; set; } = [];

    public override void Update()
    {
        foreach (var guiElement in Elements)
        {
            guiElement.Update(new Rectangle(guiElement.Position - guiElement.Size / 2, guiElement.Size), window);
        }
    }

    public void Add(IGuiElement element, Vector2 normalizedPosition)
    {
        element.Position = normalizedPosition * new Vector2(window.GetWindowWidth(), window.GetWindowHeight());
        Elements.Add(element);
    }

    public override void Draw()
    {
        foreach (var guiElement in Elements)
        {
            guiElement.Draw(new Rectangle(guiElement.Position - guiElement.Size / 2, guiElement.Size), window);
        }
    }
}
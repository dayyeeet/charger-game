using Engine;
using Raylib_cs;

namespace Game;

public class EscapePopover() : PopoverObject("escape", KeyboardKey.Escape)
{
    private readonly GuiProvider _gui = new EscapeMenu();
    public override void OnToggle(bool toggled)
    {
        if (!toggled)
        {
            _scene?.Unload(_gui);
            return;
        }
        _scene?.Load(_gui, Layers.UI);
    }
}
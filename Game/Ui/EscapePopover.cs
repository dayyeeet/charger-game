using Engine.Ui;
using Engine.Ui.Gui;
using Engine.Util;
using Game.Ui.Gui;
using Raylib_cs;

namespace Game.Ui;

public class EscapePopover() : PopoverObject("escape", KeyboardKey.Escape)
{
    private readonly GuiProvider _gui = new EscapeMenu();

    protected override void OnToggle(bool toggled)
    {
        if (!toggled)
        {
            Scene?.Unload(_gui);
            return;
        }

        Scene?.Load(_gui, Layers.UI);
    }
}
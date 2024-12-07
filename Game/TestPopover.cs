using Engine;
using Raylib_cs;

namespace Game;

public class TestPopover() : PopoverObject("test", KeyboardKey.Escape)
{
    public override void DrawToggled()
    {
        Raylib.DrawRectangle(100, 100, 100, 100, Color.Black);
    }
}
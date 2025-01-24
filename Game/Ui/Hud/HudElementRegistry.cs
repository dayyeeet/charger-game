using Engine.Ui.Hud;

namespace Game.Ui.Hud;

public struct HudElementRegistry
{
    public HudPosition Key { get; set; }
    public List<HudElement> Value { get; set; }
}
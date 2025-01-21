using Engine;

namespace Game;

public struct HudElementRegistry
{
    public HudPosition Key { get; set; }
    public List<HudElement> Value { get; set; }
}
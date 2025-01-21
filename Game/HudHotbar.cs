using System.Numerics;
using Engine;
using Raylib_cs;

namespace Game;

public class HudHotbar : HudElement
{
    private EquipmentManager? _system;
    private readonly int _margin;
    private readonly int _subElementWidth;

    public HudHotbar() : base("health")
    {
        ElementWidth = 200;
        ElementHeight = 40;
        _margin = 5;
        int elements = 5;
        int totalMargin = _margin * (elements - 1);
        int itemTotalWidth = ElementWidth - totalMargin;
        _subElementWidth = Math.Min(itemTotalWidth / elements, ElementHeight);
    }

    public override void Load(Scene scene)
    {
        var player = scene.FindObjectsById("player", Layers.Player).FirstOrDefault();
        if (player == null)
        {
            throw new NullReferenceException("Player not found");
        }

        _system = (player as Player)?.Equipment;
    }

    public override void Draw()
    {
        var distance = 0;
        if (_system == null) return;
        var index = 0;
        foreach (var systemItem in _system.Items)
        {
            if (systemItem != null)
            {
                var source = new Rectangle(0, 0, systemItem.Texture.Width, systemItem.Texture.Height);
                var dest = new Rectangle(Position.X + distance, Position.Y, _subElementWidth, _subElementWidth);
                Raylib.DrawTexturePro(systemItem.Texture, source, dest, Vector2.Zero, 0f, Color.White);
            }

            if (index == _system.CurrentIndex)
            {
                Raylib.DrawRectangleLines((int)(Position.X + distance), (int)Position.Y, _subElementWidth,
                    _subElementWidth, Color.Black);
            }

            distance += _subElementWidth + _margin;
            index++;
        }
    }
}
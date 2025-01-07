using System.Diagnostics;
using System.Numerics;
using Engine;
using Raylib_cs;

namespace Game;

public class HudHotbar : HudElement
{
    private readonly Color color;
    private EquipmentManager? system;
    private ItemManager? leftHand;
    private ItemManager? rightHand;
    private int margin;
    private int subElementWidth;

    public HudHotbar(Color color) : base("health")
    {
        ElementWidth = 200;
        ElementHeight = 40;
        margin = 5;
        int elements = 5;
        int totalMargin = margin * (elements - 1);
        int itemTotalWidth = ElementWidth - totalMargin;
        subElementWidth = Math.Min(itemTotalWidth / elements, ElementHeight);
        this.color = color;
    }

    public override void Load(Scene scene)
    {
        var player = scene.FindObjectsById("player", Layers.Player).FirstOrDefault();
        if (player == null)
        {
            throw new NullReferenceException("Player not found");
        }

        system = (player as Player)?.Equipment;
        rightHand = (player as Player)?.ItemManager;
    }

    public override void Update()
    {
        base.Update();
        rightHand?.SetItem(system?.CurrentItem);
    }

    public override void Draw()
    {
        var distance = 0;
        Debug.Assert(system?.Items != null, "system?.Items != null");
        foreach (var systemItem in system!.Items)
        {
            var source = new Rectangle(0, 0, systemItem.Texture.Width, systemItem.Texture.Height);
            var dest = new Rectangle(Position.X + distance, Position.Y, subElementWidth, subElementWidth);
            Raylib.DrawTexturePro(systemItem.Texture, source, dest, Vector2.Zero, 0f, Color.White);
            if (systemItem == system.CurrentItem)
            {
                Raylib.DrawRectangleLines((int)(Position.X + distance), (int)Position.Y, subElementWidth, subElementWidth, Color.Black);
            }
            distance += subElementWidth + margin;
        }
    }
}
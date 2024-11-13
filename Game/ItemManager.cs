using System.Numerics;
using Engine;

namespace Game;

public class ItemManager(IPositionable parent, int offsetX, int offsetY) : GameObject("item-manager"), IPositionable
{
    private Item? _item;
    private Scene? _scene;

    public override void Load(Scene scene)
    {
        _scene = scene;
    }

    public void SetItem(Item? item)
    {
        _item = item;
        if (item == null)
            return;
        _scene?.Load(item, Layers.Item);
    }

    public override void Update()
    {
        if (_item == null) return;
        Position = new Vector2(parent.Position.X + offsetX, parent.Position.Y + offsetY);
        _item.Position = Position;
    }

    public override void Draw()
    {
        _item?.Draw();
    }

    public Vector2 Position { get; set; } = new(parent.Position.X + offsetX, parent.Position.Y + offsetY);
}
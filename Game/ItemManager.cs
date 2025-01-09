using System.Numerics;
using Engine;

namespace Game;

public class ItemManager(IPositionable parent, int offsetX, int offsetY, int direction = 1, int layer = Layers.RightHand) : GameObject("item-manager"), IPositionable
{
    private Scene? _scene;

    public Item? Item { get; private set; }
    
    public int Direction => direction;
    
    public override void Load(Scene scene)
    {
        _scene = scene;
    }

    public void SetItem(Item? item)
    {
        if (Item != null) _scene?.Unload(Item);
        Item = item;
        if (Item != null) Item.Direction = Direction;
        if (item == null)
            return;
        Update();
        _scene?.Load(item, layer);
    }

    public override void Update()
    {
        if (Item == null) return;
        Position = new Vector2(parent.Position.X + offsetX, parent.Position.Y + offsetY);
        Item.Position = Position;
    }

    public override void Draw()
    {
        Item?.Draw();
    }

    public Vector2 Position { get; set; } = new(parent.Position.X + offsetX, parent.Position.Y + offsetY);
}
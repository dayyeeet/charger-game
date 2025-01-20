using System.Numerics;
using Engine;

namespace Game;

public class ItemManager(
    ICollidable parent,
    int offsetX,
    int offsetY,
    int direction = 1,
    int layer = Layers.RightHand) : GameObject("item-manager"), IPositionable
{
    private Scene? _scene;

    public Item? Item { get; private set; }

    public int Layer { get; set; } = layer;

    public int Direction { get; set; } = direction;

    public override void Load(Scene scene)
    {
        _scene = scene;
    }

    public void UpdateLayer(int layer)
    {
        Layer = layer;
        if (Item != null)
            _scene?.ReLayer(Item, layer);
    }

    public void SetItem(Item? item)
    {
        if (Item != null) _scene?.Unload(Item);
        Item = item;
        if (Item != null) Item.Direction = Direction;
        if (item == null)
            return;
        Update();
        _scene?.Load(item, Layer);
    }

    public override void Update()
    {
        if (Item == null) return;
        Position = new Vector2(parent.Position.X + parent.ElementWidth / 2 + offsetX * Direction, parent.Position.Y + parent.ElementHeight / 2 + offsetY * Direction);
        Item.Position = Position;
        Item.Direction = Direction;
    }

    public override void Draw()
    {
        Item?.Draw();
    }

    public Vector2 Position { get; set; } = new(parent.Position.X + offsetX, parent.Position.Y + offsetY);
}
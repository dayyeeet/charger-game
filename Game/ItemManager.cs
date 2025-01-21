using System.Numerics;
using Engine;

namespace Game;

public class ItemManager(
    int offsetX,
    int offsetY,
    int direction = 1,
    int layer = Layers.RightHand) : GameObject("item-manager"), IPositionable
{
    public required ICollidable Parent { get; set; }
    public int OffsetX { get; set; } = offsetX;
    public int OffsetY { get; set; } = offsetY;

    public ItemManager() : this(0, 0)
    {
        
    }
    
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
        Position = new Vector2(Parent.Position.X + Parent.ElementWidth / 2 + OffsetX * Direction, Parent.Position.Y + Parent.ElementHeight / 2 + OffsetY * Direction);
        Item.Position = Position;
        Item.Direction = Direction;
    }

    public override void Draw()
    {
        Item?.Draw();
    }

    public Vector2 Position { get; set; }
}
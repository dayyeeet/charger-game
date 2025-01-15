using System.Numerics;
using Raylib_cs;

namespace Game;

public class ItemPickupable : Pickupable
{
    private readonly Item _item;
    
    public ItemPickupable(Vector2 position, Item item) : base("item", 10, 10)
    {
        Position = position;
        _item = item;
        Console.WriteLine("Item loaded");
    }
    
    protected override void OnPickup(Player player)
    {
        var freeSlot = player.Equipment.Items.FindIndex(item => item == null);
        if (freeSlot >= 0)
        {
            player.Equipment.Items[freeSlot]= _item;
        }
    }
    
    private readonly Texture2D _tex = EmbeddedTexture.LoadTexture("Game.lasergun.png")!.Value;
    public override void Draw()
    {
        base.Draw();
        var source = new Rectangle(0, 0, _tex.Width, _tex.Height);
        var dest = new Rectangle(Position.X, Position.Y, ElementWidth * 3, ElementHeight * 3);
        Raylib.DrawTexturePro(_tex, source, dest, Vector2.Zero, 0f, Color. White);
    }
}
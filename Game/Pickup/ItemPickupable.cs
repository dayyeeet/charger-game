using System.Numerics;
using Engine.Scene;
using Game.Entity.Player;
using Game.Util.Shader;
using Raylib_cs;

namespace Game.Pickup;

public class ItemPickupable : Pickupable
{
    public Item.Item Item { get; set; }
    private const float Scale = 0.4f;
    private static readonly OutlineShader OutlineShader = new();
    public bool Targeted { get; set; } = false;
    public ItemPickupable(Vector2 position, Item.Item? item) : base("item", 100, 100)
    {
        Position = position;
        if(item != null) 
            Item = item;
    }
    
    public ItemPickupable() : this(Vector2.Zero, null) {}

    public override void Draw()
    {
        base.Draw();
        var source = new Rectangle(0, 0, Item.Texture.Width, Item.Texture.Height);
        var width = ElementWidth * Scale;
        var height = ElementHeight * Scale;
        var dest = new Rectangle(Position.X + ElementWidth / 2.0f - width/2, Position.Y + ElementHeight / 2.0f - height/2, width,
            width);
        
        if (Targeted) Raylib.BeginShaderMode(OutlineShader.GetShader());
        Raylib.DrawTexturePro(Item.Texture, source, dest, Vector2.Zero, 0f, Color.White);
        if(Targeted) Raylib.EndShaderMode();
    }

    public override void Load(Scene scene)
    {
        base.Load(scene);
        OutlineShader.SetOutlineSize(1f);
        OutlineShader.SetTextureSize(Item.Texture.Width, Item.Texture.Height);
        OutlineShader.SetOutLineColor(new Color(0xff, 0xff, 0xff, 0xaa));
    }

    protected override void OnPickup(Player player)
    {
    }

    public virtual void OnControlledPickup(Player player)
    {
        var freeSlot = player.Equipment.Items.FindIndex(item => item == null);
        if (freeSlot >= 0)
        {
            player.Equipment.Items[freeSlot] = Item;
            if(freeSlot == player.Equipment.CurrentIndex)
                player.Equipment.CurrentItem = Item;
            ShouldUnload = true;
        }
    }
}
using System.Numerics;
using Engine;
using Raylib_cs;

namespace Game;

public class ItemPickupable : Pickupable, ICollidable
{
    private readonly Item _item;
    private Scene? _scene;
    private const KeyboardKey PickUpBind = KeyboardKey.F;
    private float scale = 0.2f;

    public ItemPickupable(Vector2 position, Item item) : base("item", 100, 100)
    {
        Position = position;
        _item = item;
    }

    public override void Draw()
    {
        base.Draw();
        var source = new Rectangle(0, 0, _tex.Width, _tex.Height);
        var width = ElementWidth * scale;
        var height = ElementHeight * scale;
        var dest = new Rectangle(Position.X + ElementWidth / 2 - width, Position.Y + ElementHeight / 2 - height, width,
            width);

        Raylib.DrawTexturePro(_tex, source, dest, Vector2.Zero, 0f, Color.White);
    }
    protected override void OnPickup(Player player)
    {
        if(Raylib.IsKeyDown(PickUpBind))
        {
            var freeSlot = player.Equipment.Items.FindIndex(item => item == null);
            if (freeSlot >= 0)
            {
                player.Equipment.Items[freeSlot] = _item;
                ShouldUnload = true;
            }
            else
            {
                ShouldUnload = false;
            }
        }
    }

    private readonly Texture2D _tex = EmbeddedTexture.LoadTexture("Game.lasergun.png")!.Value;
}
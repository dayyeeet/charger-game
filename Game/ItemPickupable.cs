using System.Numerics;
using Engine;
using Raylib_cs;

namespace Game;

public class ItemPickupable : Pickupable, ICollidable
{
    private readonly Item _item;
    private float scale = 0.4f;
    private static OutlineShader _outlineShader = new OutlineShader();
    public bool Targeted { get; set; } = false;
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
        var dest = new Rectangle(Position.X + ElementWidth / 2 - width/2, Position.Y + ElementHeight / 2 - height/2, width,
            width);
        
        if (Targeted) Raylib.BeginShaderMode(_outlineShader.GetShader());
        Raylib.DrawTexturePro(_tex, source, dest, Vector2.Zero, 0f, Color.White);
        if(Targeted) Raylib.EndShaderMode();
    }

    public override void Load(Scene scene)
    {
        base.Load(scene);
        _outlineShader.SetOutlineSize(1f);
        _outlineShader.SetTextureSize(_tex.Width, _tex.Height);
        _outlineShader.SetOutLineColor(new Color(0xff, 0xff, 0xff, 0xaa));
    }

    protected override void OnPickup(Player player)
    {
    }

    public void OnControlledPickup(Player player)
    {
        var freeSlot = player.Equipment.Items.FindIndex(item => item == null);
        if (freeSlot >= 0)
        {
            player.Equipment.Items[freeSlot] = _item;
            ShouldUnload = true;
        }
    }

    private readonly Texture2D _tex = EmbeddedTexture.LoadTexture("Game.lasergun.png")!.Value;
}
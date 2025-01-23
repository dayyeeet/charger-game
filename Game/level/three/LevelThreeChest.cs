using System.Numerics;
using Raylib_cs;

namespace Game.level.three;

public class LevelThreeChest() : DestroyableObject("level-three-chest", 50)
{
    private static readonly Texture2D Tex = EmbeddedTexture.LoadTexture("Game.level3.level-3-care-package.png")!.Value;
    public override int ElementWidth { get; set; } = 60;
    public override int ElementHeight { get; set; } = (int) (60f * ((double)Tex.Height / Tex.Width));
    public override int Layer { get; set; }
    

    public override void Draw()
    {
        base.Draw();
        var src = new Rectangle(0, 0, Tex.Width, Tex.Height);
        Raylib.DrawTexturePro(Tex, src, new Rectangle(Position, new Vector2(ElementWidth, ElementHeight)), Vector2.Zero, 0f, Color.White);
    }
    
    public override void OnDestroy()
    {
        SoundLoading.Sound.PlaySound("ChestOpen", true);
        ItemLootTable.SpawnLoot(Position, Scene);
    }
}
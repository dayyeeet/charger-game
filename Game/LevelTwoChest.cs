using System.Numerics;
using Engine;
using Raylib_cs;

namespace Game;

public class LevelTwoChest() : DestroyableObject("level-two-chest", 50)
{
    private static readonly Texture2D Tex = EmbeddedTexture.LoadTexture("Game.care-package.png")!.Value;
    public override int ElementWidth { get; set; } = 60;
    public override int ElementHeight { get; set; } = (int) (60f * ((double)Tex.Height / Tex.Width));
    public override int Layer { get; set; }

    public override void Update()
    {
        base.Update();
        if (Health.IsDead && Scene != null)
        {
            ItemLootTable.SpawnLoot(Position, Scene);
        }
    }

    public override void Draw()
    {
        base.Draw();
        var src = new Rectangle(0, 0, Tex.Width, Tex.Height);
        Raylib.DrawTexturePro(Tex, src, new Rectangle(Position, new Vector2(ElementWidth, ElementHeight)), Vector2.Zero, 0f, Color.White);
    }
}
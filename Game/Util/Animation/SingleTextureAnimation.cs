using System.Numerics;
using Game.Util.Resource;
using Raylib_cs;

namespace Game.Util.Animation;

public class SingleTextureAnimation(Texture2D tex) : Animation(tex, 0)
{
    private readonly Rectangle _src = new(0, 0, tex.Width, tex.Height);
    private readonly Texture2D _tex = tex;

    public SingleTextureAnimation(string tex) : this(EmbeddedTexture.LoadTexture(tex)!.Value)
    {
    }

    public override void Animate()
    {
    }

    public override void Draw(Rectangle dest)
    {
        Raylib.DrawTexturePro(_tex, _src, dest, Vector2.Zero, 0f, Color.White);
    }
}
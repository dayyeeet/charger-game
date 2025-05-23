using System.Numerics;
using Game.Util.Resource;
using Raylib_cs;

namespace Game.Util.Animation;

public class Animation(Texture2D tex, float frameTime)
{
    public int Direction { get; set; } = 1;
    private readonly int _totalFrames = tex.Width / tex.Height;
    private int _currentFrame;
    private float _currentFrameTime;
    private Rectangle _currentSrc;

    public Animation(string tex, float frameTime) : this(EmbeddedTexture.LoadTexture(tex)!.Value, frameTime)
    {
        CalculateFrame();
    }

    public bool Paused { get; set; }

    public void Reset()
    {
        _currentFrame = 0;
        _currentFrameTime = 0;
    }

    private void NextFrame()
    {
        _currentFrame++;
        if (_currentFrame >= _totalFrames)
        {
            _currentFrame = 0;
        }

        CalculateFrame();
    }

    private void CalculateFrame()
    {
        _currentSrc = new Rectangle(_currentFrame * tex.Height, 0, tex.Height * Direction, tex.Height);
    }

    public virtual void Animate()
    {
        if (Paused) return;
        _currentFrameTime += Raylib.GetFrameTime();
        if (_currentFrameTime < frameTime) return;
        _currentFrameTime = 0;
        NextFrame();
    }

    public virtual void Draw(Rectangle dest)
    {
        Raylib.DrawTexturePro(tex, _currentSrc, dest, Vector2.Zero, 0f, Color.White);
    }
}
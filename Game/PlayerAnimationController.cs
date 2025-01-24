using Engine;
using Raylib_cs;

namespace Game;

public class PlayerAnimationController : IAnimationController<Player>
{
    private const float FrameTime = 0.15f;
    private readonly SingleTextureAnimation _idleLeft = new("Game.entity.player.left.png");
    private readonly SingleTextureAnimation _idleRight = new("Game.entity.player.right.png");
    private readonly Animation _walkLeft = new("Game.entity.player.left-walk.png", FrameTime);
    private readonly Animation _walkRight = new("Game.entity.player.right-walk.png", FrameTime);

    private Animation? _current;

    public void NextAnimationFor(Player input)
    {
        Animation updated;
        if (input.LastDelta.X < 0)
        {
            updated = input.Position != input.LastPosition ? _walkLeft : _idleLeft;
        }
        else
        {
            updated = input.Position != input.LastPosition ? _walkRight : _idleRight;
        }
        if (_current == updated) return;
        if (_current != null)
        {
            _current.Paused = true;
            _current.Reset();
        }

        updated.Reset();
        updated.Paused = false;

        _current = updated;
    }

    public void Animate()
    {
        _current?.Animate();
    }

    public void Draw(Rectangle dest)
    {
        _current?.Draw(dest);
    }

    public void ResetAll()
    {
        _idleLeft.Reset();
        _idleRight.Reset();
        _walkLeft.Reset();
        _walkRight.Reset();
    }

    public void Reset()
    {
        _current?.Reset();
    }
}
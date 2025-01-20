using Raylib_cs;

namespace Game;

public class Enemy2AnimationController : IAnimationController<Enemy2>
{
    private readonly Animation _attack = new("Game.enemy-2-idle.png", 0.5f);
    private readonly Animation _walk = new("Game.enemy-2-walk.png", 0.2f);
    private readonly Animation _idle = new SingleTextureAnimation("Game.enemy-2.png");

    private Animation? _current;

    public void NextAnimationFor(Enemy2 input)
    {
        if (input.Position == input.LastPosition) return;
        var updated = input.LastDirection != 0 ? _walk : _idle;
        if (input.CanAttack) updated = _attack;

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

    public void Draw(Rectangle dest)
    {
        _current?.Draw(dest);
    }

    public void Animate()
    {
        _current?.Animate();
    }

    public void ResetAll()
    {
        _idle.Reset();
        _walk.Reset();
    }

    public void Reset()
    {
        _current?.Reset();
    }
}
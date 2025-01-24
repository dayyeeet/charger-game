using Raylib_cs;

namespace Game;

public class Enemy2AnimationController : IAnimationController<Enemy2>
{
    private readonly Animation _attack = new("Game.entity.rooter.attack.png", 0.5f);
    private readonly Animation _walk = new("Game.entity.rooter.walk.png", 0.2f);
    private readonly Animation _idle = new SingleTextureAnimation("Game.entity.rooter.rooter.png");

    public Animation? Current { get; private set; }

    public void NextAnimationFor(Enemy2 input)
    {
        if (input.Position == input.LastPosition) return;
        var updated = input.LastDirection != 0 ? _walk : _idle;
        if (input.CanAttack) updated = _attack;

        if (Current == updated) return;
        if (Current != null)
        {
            Current.Paused = true;
            Current.Reset();
        }

        updated.Reset();
        updated.Paused = false;

        Current = updated;
    }

    public void Draw(Rectangle dest)
    {
        Current?.Draw(dest);
    }

    public void Animate()
    {
        Current?.Animate();
    }

    public void ResetAll()
    {
        _idle.Reset();
        _walk.Reset();
    }

    public void Reset()
    {
        Current?.Reset();
    }
}
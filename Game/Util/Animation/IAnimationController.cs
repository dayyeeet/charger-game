using Raylib_cs;

namespace Game.Util.Animation;

public interface IAnimationController<in T>
{
    public void NextAnimationFor(T input);

    public void Draw(Rectangle dest);

    public void Animate();

    public void ResetAll();

    public void Reset();
}
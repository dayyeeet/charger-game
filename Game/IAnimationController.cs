using Raylib_cs;

namespace Game;

public interface IAnimationController<in T>
{
    public void NextAnimationFor(T input);

    public void Draw(Rectangle dest);

    public void Animate();

    public void ResetAll();
    
    public void Reset();
}
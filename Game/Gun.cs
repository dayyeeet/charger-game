using System.Numerics;
using Engine;

namespace Game;

public abstract class Gun
{
    
    public string Type
    {
        get => GetType().FullName!;
        set {}
    }
    
    public abstract void Shoot(Scene scene, Vector2 startPosition, Vector2 targetPosition);

    public virtual float GetCooldown()
    {
        return 0.2f;
    }
    
    public virtual void CancelShoot()
    {
    }
}
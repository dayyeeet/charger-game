using System.Numerics;
using Engine;

namespace Game;

public abstract class Gun
{
    public abstract void Shoot(Scene scene, IPositionable origin, Vector2 targetPosition);

    public virtual void CancelShoot()
    {
    }
}
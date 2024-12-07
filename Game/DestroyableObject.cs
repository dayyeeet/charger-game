using System.Numerics;
using Engine;

namespace Game;

public abstract class DestroyableObject(string id, int initialHealth) : WorldFeature(id), ICollidable, IDamageable
{
    public override Vector2 Position { get; set; }
    public HealthSystem Health { get; } = new(initialHealth);
}
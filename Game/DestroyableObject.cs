using System.Numerics;
using Engine;

namespace Game;

public abstract class DestroyableObject(string id, int initialHealth) : WorldFeature(id), ICollidable, IDamageable
{
    public override Vector2 Position { get; set; }
    public HealthSystem Health { get; set; } = new(initialHealth);

    protected Scene? Scene = null;

    public override void Load(Scene scene)
    {
        base.Load(scene);
        Scene = scene;
    }

    public override void Update()
    {
        base.Update();
        if (Health.IsDead)
        {
            OnDestroy();
            Scene?.Unload(this);
        }
    }

    public virtual void OnDestroy()
    {
        SoundLoading.Sound.PlaySound("Break2", true);
    }
}
using System.Numerics;
using Engine.Scene;
using Engine.World;
using Game.Util.Entity;
using Game.Util.Sound;

namespace Game.Util.World;

public abstract class DestroyableObject(string id, int initialHealth) : WorldFeature(id), ICollidable, IDamageable
{
    public override Vector2 Position { get; set; }
    public HealthSystem Health { get; set; } = new(initialHealth);

    protected Scene? Scene;

    public override void Load(Scene scene)
    {
        base.Load(scene);
        Scene = scene;
    }

    public override void Update()
    {
        base.Update();
        if (!Health.IsDead) return;
        OnDestroy();
        Scene?.Unload(this);
    }

    protected virtual void OnDestroy()
    {
        SoundLoading.Sound.PlaySound("break", true);
    }
}
using System.Numerics;
using Engine;
using Raylib_cs;

namespace Game;

public abstract class CloseCombatItem(String name, float cooldown) : Item($"weapon-{name}"), ICollidable
{
    public override Texture2D Texture { get; set; }
    public int ElementWidth { get; set; } = 30;
    public int ElementHeight { get; set; }= 30;
    private CooldownWeapon? _cooldown;


    public override void Load(Scene scene)
    {
        base.Load(scene);
        _cooldown = new CooldownWeapon(this, cooldown);
    }

    public abstract void OnHit<T>(T other)where T : ICollidable,IDamageable;
    public override void Update()
    {
        base.Update();
        _cooldown?.OnTick();
    }

    public void Hit<T>(T other) where T : ICollidable, IDamageable
    {
        if(!_cooldown?.CanHit(other) ?? false)return;
        _cooldown?.OnHit();
        OnHit(other);
    }
}
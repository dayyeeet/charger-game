using System.Numerics;
using Engine;
using Raylib_cs;

namespace Game;

public abstract class CloseCombatItem(String name, float cooldown) : Item($"weapon-{name}"), ICollidable
{
    public override Texture2D Texture { get; set; }
    public int ElementWidth { get; set; } = 30;
    public int ElementHeight { get; set; }= 30;
    protected CooldownWeapon? _cooldown;

    private Scene? _scene;

    public bool IsPassThrough()
    {
        return true;
    }

    public Rectangle BoundingRect
    {
        get => new(Position + Math.Min(Direction, 0) * new Vector2(ElementWidth, 0) - Math.Max(Direction, 0) * new Vector2(ElementWidth, ElementHeight) / 2, ElementWidth, ElementHeight);
        set {}
    }


    public override void Load(Scene scene)
    {
        base.Load(scene);
        _scene = scene;
        _cooldown = new CooldownWeapon(this, cooldown);
    }

    public virtual void OnSwing()
    {
        
    }
    public abstract void OnHit(IDamageable obj);
    public override void Update()
    {
        base.Update();
        _cooldown?.OnTick();
        if (!Raylib.IsMouseButtonDown(MouseButton.Left)) return;
        if (_cooldown?.CanSwing() != true) return;
        OnSwing();
        if (_scene == null) return;
        _scene.CollidesWith(obj => obj != this && obj is IDamageable and not Player, this).ForEach(it => Hit((it as IDamageable)!));
        _cooldown.OnHit();
    }

    private void Hit(IDamageable other)
    {
        if(!_cooldown?.CanHit((other as ICollidable)!) ?? false)return;
        OnHit(other);
    }
    
}
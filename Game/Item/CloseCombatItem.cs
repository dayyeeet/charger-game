using System.Numerics;
using Engine.Scene;
using Engine.Util;
using Game.Entity.Player;
using Game.Util.Entity;
using Raylib_cs;

namespace Game.Item;

public abstract class CloseCombatItem(string name, float cooldown) : Item($"weapon-{name}"), ICollidable
{
    public override Texture2D Texture { get; set; }
    public int ElementWidth { get; set; } = 30;
    public int ElementHeight { get; set; }= 30;
    private CooldownWeapon? _cooldown;

    private Scene? _scene;

    public bool IsPassThrough()
    {
        return true;
    }

    public Rectangle BoundingRect
    {
        get => new(Position + Math.Min(Direction, 0) * new Vector2(ElementWidth - ElementWidth / 2, ElementHeight / 2) - Math.Max(Direction, 0) * new Vector2(ElementWidth, ElementHeight) / 2, ElementWidth, ElementHeight);
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
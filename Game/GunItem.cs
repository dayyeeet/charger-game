using Engine;
using Raylib_cs;

namespace Game;

public abstract class GunItem(string name, Gun gun) : Item(name)
{
    private Scene? _scene;

    private float _cooldown;

    public override void Update()
    {
        base.Update();
        if (_scene == null) return;
        _cooldown += Raylib.GetFrameTime();
        if (_cooldown < gun.GetCooldown()) return;
        if (!ShootingMechanic.ShootIfKeyDown(_scene, this, gun)) return;
        _cooldown = 0;
    }

    public override void Load(Scene scene)
    {
        _scene = scene;
    }

    public override void Draw()
    {
        base.Draw();
        if (Game.Engine.HitBoxesVisible)
            Raylib.DrawRectangleLinesEx(new Rectangle(Position - Size / 2, Size), 2f, Color.SkyBlue);
    }
}
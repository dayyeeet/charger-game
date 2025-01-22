using Engine;
using Raylib_cs;

namespace Game;

public abstract class GunItem(string name, Gun gun) : Item(name)
{
    private Scene? _scene;

    public float Cooldown { get; set; }
    public Gun Gun { get; set; } = gun;

    public override void Update()
    {
        base.Update();
        if (_scene == null) return;
        Cooldown += Raylib.GetFrameTime();
        if (Cooldown < Gun.GetCooldown()) return;
        if (!ShootingMechanic.ShootIfKeyDown(_scene, this, Gun)) return;
        Cooldown = 0;
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
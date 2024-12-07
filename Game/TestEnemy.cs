using System.Numerics;
using Engine;
using Raylib_cs;

namespace Game;

public class TestEnemy() : Enemy("test", 2, 10, 1, 0, 0, 30, 30)
{
    private EnemyAi _ai = new(600f, 250f, 0.01f);

    private Player? _player;
    private Scene? _scene;
    private List<EnemyAiRoamingPoint>? _roamingPoints;
    private float _cooldown = 0.2f;
    private float _cooldownTimer = 0f;
    private readonly Gun _gun = new EnemyBulletGun();

    public override void Load(Scene scene)
    {
        base.Load(scene);
        _scene = scene;
        _player = scene.FindObjectsById("player", Layers.Player).FirstOrDefault() as Player ??
                  throw new NullReferenceException("Cannot find player");
        _roamingPoints = scene.FindObjectsById("feature-roaming-point").ConvertAll(point =>
            point as EnemyAiRoamingPoint ?? throw new NullReferenceException("Cannot find roaming point"));
    }

    public override void Move()
    {
        if (_player == null) return;
        Position = _ai.DefaultBehavior(this, _player, _roamingPoints);
        CanAttack = Vector2.Distance(_player.Position, Position) <= 400;
    }

    public override void Attack()
    {
        if (_scene == null || _player == null) return;
        _cooldownTimer += Raylib.GetFrameTime();
        if (!(_cooldownTimer >= _cooldown)) return;
        _cooldownTimer = 0f;
        ShootingMechanic.Shoot(_scene, this, _player, _gun);
    }

    public override void Draw()
    {
        Raylib.DrawCircleV(Position + new Vector2(ElementWidth / 2, ElementHeight / 2), ElementWidth / 2, Color.Red);
    }
}
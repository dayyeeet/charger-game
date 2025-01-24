using System.Numerics;
using Engine.Scene;
using Engine.Util;
using Game.Gun;
using Game.Util.Animation;
using Game.Util.Shader;
using Raylib_cs;

namespace Game.Entity.Enemy.Hunter;

public class Hunter() : Enemy("test", 10, 1, 0, 0, 50, 50)
{
    private readonly Animation _anim = new("Game.entity.hunter.walk.png", 0.3f);
    private readonly EnemyAi _ai = new(600f, 250f, 0.01f);
    private Player.Player? _player;
    private Scene? _scene;
    private List<EnemyAiRoamingPoint>? _roamingPoints;
    private const float Cooldown = 0.2f;
    private float _cooldownTimer;
    private readonly Gun.Gun _gun = new HunterGun();
    private static readonly OutlineShader OutlineShader = new();

    public override void Load(Scene scene)
    {
        base.Load(scene);
        _scene = scene;
        _player = scene.FindObjectsById("player", Layers.Player).FirstOrDefault() as Player.Player ??
                  throw new NullReferenceException("Cannot find player");
        _roamingPoints = scene.FindObjectsById("feature-roaming-point").ConvertAll(point =>
            point as EnemyAiRoamingPoint ?? throw new NullReferenceException("Cannot find roaming point"));
        OutlineShader.SetOutlineSize(0.6f);
        OutlineShader.SetTextureSize(ElementWidth, ElementHeight);
        OutlineShader.SetOutLineColor(new Color(0xff, 0x00, 0x0f, 0x3f));
    }

    public override void Move()
    {
        if (_player == null) return;
        if (_scene == null) return;
        LastPosition = Position;
        _ai.DefaultBehavior(_scene, this, LastPosition, _player, _roamingPoints);
        CanAttack = Vector2.Distance(_player.Position, Position) <= 400;
        _anim.Direction = (Position.X - LastPosition.X) switch
        {
            < 0 => -1,
            > 0 => 1,
            _ => _anim.Direction
        };
    }

    public override void Attack()
    {
        if (_scene == null || _player == null) return;
        _cooldownTimer += Raylib.GetFrameTime();
        if (!(_cooldownTimer >= Cooldown)) return;
        _cooldownTimer = 0f;
        ShootingMechanic.Shoot(_scene, this, _player, _gun);
    }

    public float Spread = 15;

    public override void Update()
    {
        base.Update();
        _anim.Animate();
    }

    public override void Draw()
    {
        var dest = new Rectangle(Position.X, Position.Y, ElementWidth, ElementHeight);
        if (CanAttack) Raylib.BeginShaderMode(OutlineShader.GetShader());
        _anim.Draw(dest);
        if (CanAttack) Raylib.EndShaderMode();
    }
}
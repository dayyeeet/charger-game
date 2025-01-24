using System.Numerics;
using Engine.Scene;
using Engine.Util;
using Game.Gun;
using Game.Util.Animation;
using Game.Util.Shader;
using Game.Util.Sound;
using Raylib_cs;

namespace Game.Entity.Enemy.Dragon;

public class Dragon() : Enemy("enemy-3", 50, 1, 0, 0, 120, 120)
{
    private int _direction = 1;
    private readonly Animation _anim = new("Game.entity.dragon.walk.png", 0.3f);
    private readonly EnemyAi _ai = new(600f, 250f, 0.005f);
    private Player.Player? _player;
    private Scene? _scene;
    private List<EnemyAiRoamingPoint>? _roamingPoints;
    private const float Cooldown = 0.2f;
    private float _cooldownTimer;
    private readonly Gun.Gun _gun = new DragonGun();
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
        switch (Position.X - LastPosition.X)
        {
            case < 0:
                _anim.Direction = -1;
                _direction = 0;
                break;
            case > 0:
                _anim.Direction = 1;
                _direction = 1;
                break;
        }
    }

    private const float Spread = 15;

    public override void Attack()
    {
        if (_scene == null || _player == null) return;
        _cooldownTimer += Raylib.GetFrameTime();
        if (!(_cooldownTimer >= Cooldown)) return;
        _cooldownTimer = 0f;
        SoundLoading.Sound.PlaySound("fireball");
        ShootingMechanic.Shoot(_scene, Position + new Vector2(_direction * ElementWidth, 0),
            _player.Position + new Vector2(Spread, Spread), _gun);
        ShootingMechanic.Shoot(_scene, Position + new Vector2(_direction * ElementWidth, 0), _player.Position, _gun);
        ShootingMechanic.Shoot(_scene, Position + new Vector2(_direction * ElementWidth, 0),
            _player.Position - new Vector2(Spread, Spread), _gun);
    }

    public override void Update()
    {
        base.Update();
        _anim.Animate();
    }

    private const float Size = 3;

    public override void Draw()
    {
        var dest = new Rectangle(Position.X - ElementWidth / Size / 2, Position.Y - ElementHeight / Size / 2,
            ElementWidth + ElementWidth / Size, ElementHeight + ElementHeight / Size);
        if (CanAttack) Raylib.BeginShaderMode(OutlineShader.GetShader());
        _anim.Draw(dest);
        if (CanAttack) Raylib.EndShaderMode();
    }
}
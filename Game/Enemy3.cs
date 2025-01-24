using System.Numerics;
using Engine;
using Raylib_cs;

namespace Game;

public class Enemy3() : Enemy("enemy-3", 1, 50, 1, 0, 0, 120, 120)
{
    private int _direction = 1;
    private readonly Animation _anim = new("Game.entity.dragon.walk.png", 0.3f);
    private EnemyAi _ai = new(600f, 250f, 0.005f);
    private Player? _player;
    private Scene? _scene;
    private List<EnemyAiRoamingPoint>? _roamingPoints;
    private float _cooldown = 0.2f;
    private float _cooldownTimer = 0f;
    private readonly Gun _gun = new DragonBulletGun();
    private static readonly OutlineShader OutlineShader = new();

    public override void Load(Scene scene)
    {
        base.Load(scene);
        _scene = scene;
        _player = scene.FindObjectsById("player", Layers.Player).FirstOrDefault() as Player ??
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
        if (Position.X - LastPosition.X < 0)
        {
            _anim.Direction = -1;
            _direction = 0;
        }
        else if (Position.X - LastPosition.X > 0)
        {
            _anim.Direction = 1;
            _direction = 1;
        }
    }

    private float _spread = 15;

    public override void Attack()
    {
        if (_scene == null || _player == null) return;
        _cooldownTimer += Raylib.GetFrameTime();
        if (!(_cooldownTimer >= _cooldown)) return;
        _cooldownTimer = 0f;
        SoundLoading.Sound.PlaySound("fireball");
        ShootingMechanic.Shoot(_scene, Position + new Vector2( _direction * ElementWidth,0), _player.Position + new Vector2(_spread, _spread), _gun);
        ShootingMechanic.Shoot(_scene, Position + new Vector2( _direction * ElementWidth,0) , _player.Position, _gun);
        ShootingMechanic.Shoot(_scene, Position + new Vector2( _direction * ElementWidth,0) , _player.Position - new Vector2(_spread, _spread), _gun);
    }

    public override void Update()
    {
        base.Update();
        _anim.Animate();
    }

    private float _size = 3;
    public override void Draw()
    {
        var dest = new Rectangle(Position.X - ElementWidth/_size/2, Position.Y - ElementHeight/_size/2, ElementWidth + ElementWidth/_size, ElementHeight + ElementHeight/_size);
        if (CanAttack) Raylib.BeginShaderMode(OutlineShader.GetShader());
        _anim.Draw(dest);
        if (CanAttack) Raylib.EndShaderMode();
    }
}
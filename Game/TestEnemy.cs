using System.Numerics;
using Engine;
using Raylib_cs;

namespace Game;

public class TestEnemy() : Enemy("test", 2, 10, 1, 0, 0, 50, 50)
{
    private int _direction = 1;
    private readonly Animation _anim = new("Game.entity.hunter.walk.png", 0.3f);
    private EnemyAi _ai = new(600f, 250f, 0.01f);
    private Player? _player;
    private Scene? _scene;
    private List<EnemyAiRoamingPoint>? _roamingPoints;
    private float _cooldown = 0.2f;
    private float _cooldownTimer = 0f;
    private readonly Gun _gun = new GreenEnemyBulletGun();
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

    public override void Attack()
    {
        if (_scene == null || _player == null) return;
        _cooldownTimer += Raylib.GetFrameTime();
        if (!(_cooldownTimer >= _cooldown)) return;
        _cooldownTimer = 0f;
        ShootingMechanic.Shoot(_scene, this, _player, _gun);
    }

    private float _spread = 15;

    public override void Update()
    {
        base.Update();
        _anim.Animate();
    }
    
    public override void Draw()
    {
        var dest = new Rectangle(Position.X, Position.Y, ElementWidth, ElementHeight);
        if(CanAttack) Raylib.BeginShaderMode(OutlineShader.GetShader());
        _anim.Draw(dest);
        if(CanAttack) Raylib.EndShaderMode();
    }
}
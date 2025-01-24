namespace Game;

using System.Numerics;
using Engine;
using Raylib_cs;

public class Enemy2() : Enemy("blue", 80, 10, 5, 0, 0, 70, 70)
{
    private const float Cooldown = 0.5f;
    private float _currentCooldown = Cooldown;
    private Player? _player;
    private Scene? _scene;
    private List<EnemyAiRoamingPoint>? _roamingPoints;
    private readonly Enemy2AnimationController _controller = new();
    private static readonly OutlineShader OutlineShader = new();

    private EnemyAi _ai = new(600f, 50f, 0.02f);
    public int LastDirection { get; private set; } = 0;

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

    public override void Update()
    {
        base.Update();
        _currentCooldown -= Raylib.GetFrameTime();
    }

    public override void Move()
    {
        if (_player == null) return;
        if (_scene == null) return;
        LastPosition = Position;
        _ai.DefaultBehavior(_scene, this, LastPosition, _player, _roamingPoints);
        LastDirection = Position.X > LastPosition.X ? 1 : Position.X < LastPosition.X ? -1 : 0;
        CanAttack = _currentCooldown <= 0 && _scene.CollidesWith(obj => obj is Player, this).Count > 0;
        _controller.NextAnimationFor(this);
        _controller.Animate();
        if (Position.X - LastPosition.X < 0)
        {
            if (_controller.Current != null) _controller.Current.Direction = -1;
        }
        else if (Position.X - LastPosition.X > 0)
        {
            if (_controller.Current != null) _controller.Current.Direction = 1;
        }
    }

    public override void Attack()
    {
        _currentCooldown = Cooldown;
        if (_player == null) return;

        if (Raylib.CheckCollisionRecs(BoundingRect, _player.BoundingRect))
        {
            _player.TakeDamage((int)Damage);
        }
    }

    public override void Draw()
    {
        var dest = new Rectangle(Position.X, Position.Y, ElementWidth, ElementHeight);
        if (CanAttack) Raylib.BeginShaderMode(OutlineShader.GetShader());
        _controller.Draw(dest);
        if (CanAttack) Raylib.EndShaderMode();
    }
}
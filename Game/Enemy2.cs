namespace Game;
using System.Numerics;
using Engine;
using Raylib_cs;



public class Enemy2() : Enemy("blue", 80, 10, 5, 0, 0, 70 , 70 )
{
    private Player? _player;
    private Scene? _scene;
    private List<EnemyAiRoamingPoint>? _roamingPoints;
    
    private EnemyAi _ai = new(600f, 50f, 0.02f);
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
        CanAttack = Vector2.Distance(_player.Position, Position) <= 75;
    }

    public override void Attack()
    {
        if (_player == null) return;

        if (Raylib.CheckCollisionRecs(BoundingRect, _player.BoundingRect))
        {
            _player.TakeDamage((int)Damage);
        }
    }

    private readonly Texture2D _tex = EmbeddedTexture.LoadTexture("Game.enemy-2.png")!.Value;
    public override void Draw()
    {
        var source = new Rectangle(0, 0, _tex.Width, _tex.Height);
        var dest = new Rectangle(Position.X, Position.Y, ElementWidth, ElementHeight);
        Raylib.DrawTexturePro(_tex, source, dest, Vector2.Zero, 0f, Color. White);
    }
}

namespace Game;
using System.Numerics;
using Engine;
using Raylib_cs;



public class Enemy2() : Enemy("blue", 80, 10, 5, 0, 0, 70 , 70 )
{
    private Player? _player;
    private Scene? _scene;

    public override void Load(Scene scene)
    {
        base.Load(scene);
        _scene = scene;
        _player = scene.FindObjectsById("player", Layers.Player).FirstOrDefault() as Player ??
                  throw new NullReferenceException("Cannot find player");
    }

    public override void Move()
    {
        if (_player == null) return;

        var direction = _player.Position - Position;
        if (direction.Length() > 0) 
        {
            direction = Vector2.Normalize(direction);
        }
        Position += direction * Speed * Raylib.GetFrameTime();
    }

    public override void Attack()
    {
        if (_player == null) return;

        if (Raylib.CheckCollisionRecs(BoundingRect, _player.BoundingRect))
        {
            _player.TakeDamage((int)Damage);
        }
    }

    public override void Update()
    {
        base.Update();
        Move();  
        Attack(); 
    }

    private readonly Texture2D _tex = EmbeddedTexture.LoadTexture("Game.enemy-2.png")!.Value;
    public override void Draw()
    {
        var source = new Rectangle(0, 0, _tex.Width, _tex.Height);
        var dest = new Rectangle(Position.X, Position.Y, ElementWidth, ElementHeight);
        Raylib.DrawTexturePro(_tex, source, dest, Vector2.Zero, 0f, Color. White);
    }
}

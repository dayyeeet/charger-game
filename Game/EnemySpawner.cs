using System.Numerics;
using Engine;
using Raylib_cs;

namespace Game;

public class EnemySpawner<T>() : WorldFeature("enemy-spawner") where T : Enemy
{
    private float _spawnRate = 12;
    private float _currentSpawnRate;
    private Scene? _scene;
    private EnemySpawnManager? _spawnManager;

    public EnemySpawner(float spawnRate) : this()
    {
        _spawnRate = spawnRate;
    }

    public override void Load(Scene scene)
    {
        base.Load(scene);
        _scene = scene;
        _spawnManager = scene.FindObjectsById("enemy-spawn-manager").FirstOrDefault() as EnemySpawnManager ??
                        throw new NullReferenceException();
    }

    public override void Update()
    {
        base.Update();

        if (_spawnManager == null || _scene == null) return;
        _currentSpawnRate -= Raylib.GetFrameTime();
        
        if(_currentSpawnRate > 0) return;
        _currentSpawnRate = _spawnRate;

        if (!_spawnManager.CanSpawnEnemies()) return;

        var enemy = Activator.CreateInstance<T>();
        enemy.Position = Position;
        _scene.Load(enemy, Layers.Entity);
        _spawnManager.NeededEnemyAmount--;
    }

    public override void Draw()
    {
        if(Game.Engine.HitBoxesVisible)Raylib.DrawRectangleLines((int)Position.X, (int)Position.Y, ElementWidth, ElementHeight, Color.Magenta);
    }

    public override int ElementWidth { get; set; } = 100;
    public override int ElementHeight { get; set; } = 100;
    public override Vector2 Position { get; set; }
    public override int Layer { get; set; } = Layers.CollisionObject;
    
    public Rectangle BoundingRect => new Rectangle(Position.X, Position.Y, ElementWidth, ElementHeight);
}
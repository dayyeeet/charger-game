using System.Numerics;
using Engine.Scene;
using Engine.Util;
using Engine.World;
using Raylib_cs;

namespace Game.Entity.Enemy;

public class EnemySpawner<T>() : WorldFeature("enemy-spawner") where T : Enemy
{
    private float _currentSpawnRate;
    private Scene? _scene;
    private EnemySpawnManager? _spawnManager;
    
    public float SpawnRate { get; set; } = 12;

    protected EnemySpawner(float spawnRate, int width = 100, int height = 100) : this()
    {
        SpawnRate = spawnRate;
        ElementWidth = width;
        ElementHeight = height;
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
        _currentSpawnRate = SpawnRate;

        if (!_spawnManager.CanSpawnEnemies()) return;

        var enemy = Activator.CreateInstance<T>();
        enemy.Position = Position;
        _scene.Load(enemy, Layers.Entity);
    }

    public override void Draw()
    {
        if(Game.Engine.HitBoxesVisible)Raylib.DrawRectangleLines((int)Position.X, (int)Position.Y, ElementWidth, ElementHeight, Color.Magenta);
    }

    public sealed override int ElementWidth { get; set; } = 100;
    public sealed override int ElementHeight { get; set; } = 100;
    public override Vector2 Position { get; set; }
    public override int Layer { get; set; } = Layers.CollisionObject;
}
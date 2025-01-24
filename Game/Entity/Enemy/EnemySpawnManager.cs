using Engine.Scene;
using Engine.Util;

namespace Game.Entity.Enemy;

public class EnemySpawnManager(int level) : GameObject("enemy-spawn-manager")
{
    private readonly int _maxCurrentEnemyAmount = 3 + (int)(level * 1.5);
    private Scene? _scene;

    public EnemySpawnManager() : this(0)
    {
    }

    public override void Load(Scene scene)
    {
        base.Load(scene);
        _scene = scene;
    }

    public bool CanSpawnEnemies()
    {
        if (_scene == null) return false;
        return _scene.FindObjects(obj => obj is Enemy, Layers.Entity).Count < _maxCurrentEnemyAmount;
    }
}
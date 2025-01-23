using Engine;
using System.Numerics;
using Raylib_cs;

namespace Game;

public class Enemy3Spawner : EnemySpawner<Enemy3>
{
    public Enemy3Spawner() : base(60)
    {}
}
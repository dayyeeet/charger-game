using System.Numerics;
using Engine.Scene;
using Raylib_cs;

namespace Game.Gun.Projectile;

public abstract class Projectile(
    Vector2 startPosition,
    Vector2 direction,
    float shotDuration,
    int maxDistance,
    Color color)
    : GameObject("projectile")
{
    private float _shotDuration = shotDuration;

    protected Scene? Scene;

    public override void Draw()
    {
        Raylib.DrawLineV(startPosition, startPosition + direction * maxDistance, color);
    }

    public override void Load(Scene scene)
    {
        Scene = scene;
    }

    public override void Update()
    {
        UpdateProjectilePosition();
        
        // ReSharper disable once CompareOfFloatsByEqualityOperator
        if (_shotDuration == -1f) return;
        _shotDuration -= Raylib.GetFrameTime();
        if (_shotDuration <= 0)
        {
            Scene?.Unload(this);
        }
    }

    protected virtual void UpdateProjectilePosition()
    {
        
    }
}

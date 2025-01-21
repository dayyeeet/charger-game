using System.Numerics;
using Engine;
using Raylib_cs;

namespace Game;

public abstract class Projectile(
    Vector2 startPosition,
    Vector2 direction,
    float shotDuration,
    int maxDistance,
    Color color)
    : GameObject("projectile")
{
    private float _shotDuration = shotDuration;

    protected Scene? _scene;

    public override void Draw()
    {
        Raylib.DrawLineV(startPosition, startPosition + direction * maxDistance, color);
    }

    public override void Load(Scene scene)
    {
        _scene = scene;
    }

    public override void Update()
    {
        UpdateProjectilePosition();
        
        if (_shotDuration == -1f) return;
        _shotDuration -= Raylib.GetFrameTime();
        if (_shotDuration <= 0)
        {
            _scene?.Unload(this);
        }
    }

    protected virtual void UpdateProjectilePosition()
    {
        
    }
}

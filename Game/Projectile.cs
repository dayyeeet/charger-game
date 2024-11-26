using System.Numerics;
using Engine;
using Raylib_cs;

namespace Game;

public class Projectile(
    Vector2 startPosition,
    Vector2 direction,
    float shotDuration,
    float shotVelocity,
    float damageAmount,
    int maxDistance)
    : GameObject("projectile")
{
    private float _shotDuration = shotDuration;
    private float _shotVelocity = shotVelocity;
    private float _damageAmount = damageAmount;

    private Scene? _scene;
    public override void Draw()
    {
        Raylib.DrawLineV(startPosition, startPosition + direction * maxDistance, Color.Lime);
    }

    public override void Load(Scene scene)
    {
        _scene = scene;
    }

    public override void Update()
    {
        _shotDuration -= Raylib.GetFrameTime();
        if (_shotDuration <= 0)
        {
            _scene?.Unload(this);
        }
    }
}
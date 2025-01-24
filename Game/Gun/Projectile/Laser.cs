using System.Numerics;
using Engine.Scene;
using Game.Entity.Player;
using Game.Util.Entity;
using Game.Util.Resource;
using Game.Util.Sound;
using Raylib_cs;

namespace Game.Gun.Projectile;

public class Laser(
    Vector2 startPosition,
    Vector2 direction,
    float rotationDirection,
    float shotVelocity,
    float damageAmount,
    int maxDistance,
    Color color) : Projectile(startPosition, direction, -1f,
    maxDistance, color)
{
    private static readonly Texture2D Texture = EmbeddedTexture.LoadTexture("Game.projectile.laser-beam.png")!.Value;
    public Vector2 StartPosition = startPosition;
    public Vector2 Direction = direction;
    public float RotationDirection = rotationDirection;
    private readonly Color _color = color;
    private GameObject? _hit;
    private RayCollision? _collision;
    private readonly SoundSystem _soundSystem = SoundLoading.Sound;

    public void Raycast()
    {
        var ray = new Ray(new Vector3(StartPosition.X, StartPosition.Y, 0), new Vector3(Direction.X, Direction.Y, 0));
        var collision = Scene?.CollidesWithRay(ray)
            .FirstOrDefault(it => it.Key is not Player && !((ICollidable)it.Key).IsPassThrough());
        // ReSharper disable once UsageOfDefaultStructEquality
        if (collision == null || collision.Equals(default(KeyValuePair<GameObject, RayCollision>)))
        {
            _hit = null;
            _collision = null;
            return;
        }

        _hit = collision.Value.Key;
        _collision = collision.Value.Value;
    }
    

    public override void Draw()
    {
        var endPosition = StartPosition + Direction * shotVelocity;
        if (_collision.HasValue)
        {
            var point = _collision.Value.Point;
            endPosition = new Vector2(point.X, point.Y);
        }
        
        var src = new Rectangle(0, 0, Texture.Width, Texture.Height);
        var width = Texture.Width * 2f;
        var dest = new Rectangle(StartPosition.X + width/2, StartPosition.Y, width, Vector2.Distance(StartPosition, endPosition));
        Raylib.DrawTexturePro(Texture, src, dest, Vector2.Zero, RotationDirection, Color.White);
        if(Game.Engine.HitBoxesVisible)
            Raylib.DrawLineV(StartPosition, endPosition, _color);
    }

    public override void Update()
    {
        _soundSystem.PlaySound("laser-beam");
        if(_hit is IDamageable damageable)
        {
              damageable.Health.TakeDamage(damageAmount * Raylib.GetFrameTime());
        }
    }

    public override void Unload(Scene scene)
    {
        base.Unload(scene);
        _soundSystem.StopSound("laser-beam");
    }
}
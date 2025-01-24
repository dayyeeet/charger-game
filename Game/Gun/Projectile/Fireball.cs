using System.Numerics;
using Engine.Scene;
using Game.Entity.Enemy;
using Game.Entity.Enemy.Dragon;
using Game.Util.Resource;
using Raylib_cs;

namespace Game.Gun.Projectile;

public class Fireball : FlyingProjectile<Dragon>    
{
    public Fireball(Vector2 startPosition, Vector2 direction, float shotDuration, float shotVelocity,
        float damageAmount, int maxDistance, Vector2 currentPosition)
        : base(startPosition, direction, shotDuration, shotVelocity, damageAmount, maxDistance, Color.White, currentPosition, obj => obj is not Enemy && !((ICollidable)obj).IsPassThrough())
    {
    }

    
    public Fireball() : this(Vector2.Zero, Vector2.Zero, 0f, 0f, 0f, 0, Vector2.Zero)
    {
    }
    
    private static readonly Lazy<Texture2D> LazyTexture = new(() => 
        EmbeddedTexture.LoadTexture("Game.projectile.fireball.png")!.Value);
    
    private Texture2D _texture = LazyTexture.Value; 
    public Texture2D Texture
    {
        get => _texture; 
        set => _texture = value; 
    }
    
    public override void Draw()
    {
        var source = new Rectangle(0, 0, Texture.Width, Texture.Height);
        var size = 25f;  
        var dest = new Rectangle(Position + new Vector2(ElementWidth / 2f, ElementHeight / 2f),
                                 new Vector2(size, size));

        
        Raylib.DrawTexturePro(Texture, source, dest, 
            new Vector2(size / 2f, size / 2f), 
            ToDegrees(Direction) + 90F, Color.White);
    }
    
    private float ToDegrees(Vector2 direction)
    {
        float angleRadians = (float)Math.Atan2(direction.Y, direction.X);
        float angleDegrees = angleRadians * (180f / (float)Math.PI);
        return angleDegrees;
    }
}
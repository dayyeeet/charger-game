using System.Numerics;
using Engine;
using Raylib_cs;

namespace Game;

public abstract class Enemy : GameObject, ICollidable
{
    // Properties for speed and damage
    public float Speed { get; protected set; }
    public Rectangle BoundingRect => new Rectangle(Position.X, Position.Y, ElementWidth, ElementHeight);
    public float Damage { get; protected set; }

    public bool CanAttack { get; protected set; } = false;
    public bool CanMove { get; protected set; } = true;

    // HealthSystem instance to manage health
    public HealthSystem Health { get; private set; }

    // Constructor to initialize Enemy
    protected Enemy(string id, float speed, int initialHealth, float damage, float x, float y, float width,
        float height) : base($"enemy-{id}")
    {
        Speed = speed;
        Damage = damage;
        Health = new HealthSystem(initialHealth);
        Position = new Vector2(x, y);
        ElementWidth = (int)width;
        ElementHeight = (int)height;
    }

    // Abstract methods to be implemented by derived classes
    public abstract void Move();
    public abstract void Attack();

    public override void Update()
    {
        base.Update();
        if (CanMove) Move();
        if (CanAttack) Attack();
    }

    // Method to handle taking damage
    public void TakeDamage(float amount)
    {
        var damageAmount = (int)amount; // Convert to integer if needed
        var isDead = Health.TakeDamage(damageAmount);
        if (isDead)
            // Optional death logic
            OnDeath();
    }

    // Method to heal the enemy
    public void Heal(int amount)
    {
        Health.Heal(amount);
    }

    // Check if the enemy is alive
    public bool IsAlive()
    {
        return !Health.IsDead;
    }

    // Optional method to handle death-related actions
    protected virtual void OnDeath()
    {
        // Actions when the enemy dies (e.g., dropping items)
    }

    public Vector2 Position { get; set; }
    public int ElementWidth { get; set; }
    public int ElementHeight { get; set; }
}
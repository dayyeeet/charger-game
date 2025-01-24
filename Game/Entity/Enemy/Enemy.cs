using System.Numerics;
using Engine.Scene;
using Game.Pickup;
using Game.Util.Entity;
using Game.Util.Loot;
using Raylib_cs;

namespace Game.Entity.Enemy;

public abstract class Enemy : GameObject, ICollidable, IDamageable
{
    // Properties for speed and damage

    public Rectangle BoundingRect
    {
        get => new(Position.X, Position.Y, ElementWidth, ElementHeight);
        set { }
    }

    // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
    public float Damage { get; protected set; }

    public bool CanAttack { get; protected set; }
    public bool CanMove { get; protected set; } = true;

    // HealthSystem instance to manage health
    public HealthSystem Health { get; protected set; }

    public bool IsPlayerPassThrough()
    {
        return true;
    }

    // Constructor to initialize Enemy
    protected Enemy(string id, int initialHealth, float damage, float x, float y, float width,
        float height) : base($"enemy-{id}")
    {
        Damage = damage;
        Health = new HealthSystem(initialHealth);
        Position = new Vector2(x, y);
        ElementWidth = (int)width * 2;
        ElementHeight = (int)height * 2;
    }

    // Abstract methods to be implemented by derived classes
    public abstract void Move();
    public abstract void Attack();

    private Scene? _scene;

    public override void Load(Scene scene)
    {
        base.Load(scene);
        _scene = scene;
    }

    public override void Update()
    {
        if (_scene == null) return;
        if (Health.IsDead)
        {
            _scene.Load(new XpPickupable(Position + new Vector2(ElementWidth, ElementHeight) / 2, 10));
            ItemLootTable.SpawnLoot(Position + new Vector2(ElementWidth, ElementHeight) / 2, _scene);

            _scene.Unload(this);
            /*var currentLevel = SaveManager.LoadLevel();
            var nextLevel = currentLevel + 1;
            SaveManager.SaveLevel(nextLevel);
            var newScene = SceneLoader.Load(nextLevel);
            Game.Engine.LoadScene(newScene); */
            return;
        }

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

    public Vector2 LastPosition { get; set; }
    public int ElementWidth { get; set; }
    public int ElementHeight { get; set; }
}
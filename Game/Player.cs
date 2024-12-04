using System.Numerics;
using Engine;
using Raylib_cs;

namespace Game;

public class Player : GameObject, IPositionable, ISizeableObject
{
    public Vector2 Position { get; set; }
    public HealthSystem Health { get; private set; } = new(100);
    
    public ExperienceSystem Experience { get; private set; } = new();
    public float Velocity { get; set; } = 500;
    public ItemManager ItemManager { get; private set; }
    public EquipmentManager Equipment { get; private set; } 

    private Scene? _scene;
    private GameWorld _world;

    public Player(Vector2 spawnLocation) : base("player")
    {
        Position = spawnLocation;
        ItemManager = new ItemManager(this, ElementWidth - ElementWidth / 5, 0);
        Equipment = new EquipmentManager(ItemManager);
    }

    public override void Load(Scene scene)
    {
        scene.Load(ItemManager);
        _scene = scene;
        var world = scene.FindObjectsById("world").FirstOrDefault();
        _world = world as GameWorld ?? throw new NullReferenceException("World not found");
    }

    public override void Update()
    {
        Move();
        Equipment.Update();
    }

    private void Move()
    {
        var updatedPosition = PlayerController.Movement(Position, Velocity);
        if (updatedPosition != Position && RectIntersects.With(_world.Dimension,
                new Rectangle(updatedPosition.X, updatedPosition.Y, updatedPosition.X - ElementWidth, updatedPosition.Y - ElementHeight)))
        {
            Position = updatedPosition;
        }
    }

    public override void Draw()
    {
        Raylib.DrawRectangle((int)Position.X, (int)Position.Y, ElementWidth, ElementHeight, Color.Red);
    }

    public void Kill()
    {
        Health.Kill();
    }

    public void TakeDamage(int damageAmount)
    {
        Health.TakeDamage(damageAmount);
    }

    public void Heal(int healAmount)
    {
        Health.Heal(healAmount);
    }

    public void GetCurrentHealth()
    {
        Health.GetCurrentHealth();
    }

    public bool IsDead()
    {
        return Health.IsDead;
    }

    public void AddXp(double amount)
    {
        Experience.AddXp(amount);
    }

    public double Difficulty()
    {
        return Experience.Difficulty;
    }

    public int Level()
    {
        return Experience.Level;
    }

    public double Xp()
    {
        return Experience.Xp;
    }

    public int ElementWidth { get; set; } = 70;
    public int ElementHeight { get; set; } = 150;
}
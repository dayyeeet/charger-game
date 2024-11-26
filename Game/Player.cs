using System.Numerics;
using Engine;
using Raylib_cs;

namespace Game;

public class Player : GameObject, IPositionable
{
    public Vector2 Position { get; set; }
    public HealthSystem Health { get; private set; } = new(100);
    public ExperienceSystem Experience { get; private set; } = new();
    public float Velocity { get; set; } = 500;
    public ItemManager ItemManager { get; private set; }

    private Scene? _scene;
    
    public Player(Vector2 spawnLocation) : base("player")
    {
        Position = spawnLocation;
        ItemManager = new ItemManager(this,20,0);
       ItemManager.SetItem(new SpoonItem());
    }

    public override void Load(Scene scene)
    {
        scene.Load(ItemManager);
        _scene = scene;
    }

    public override void Update()
    {
        Position = PlayerController.Movement(Position, Velocity);
        if (_scene != null) ShootingMechanic.ShootIfKeyDown(_scene, this);
    }

    public override void Draw()
    {
        Raylib.DrawCircle((int)Position.X, (int)Position.Y, 10, Color.Red);
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
}
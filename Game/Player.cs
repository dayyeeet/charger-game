using System.Numerics;
using Engine;
using Raylib_cs;

namespace Game;

public class Player(Vector2 spawnLocation) : GameObject("player"), IPositionable
{
    public Vector2 Position { get; set; } = spawnLocation;
    public HealthSystem Health { get; private set; } = new(100);
    public ExperienceSystem Experience { get; private set; } = new();
    public float Velocity { get; set; } = 500;

    //public ItemManager itemManager { get; private set; }

    //itemManager = new ItemManager();

    public override void Update()
    {
        Position = PlayerController.Movement(Position, Velocity);
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
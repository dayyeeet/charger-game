using System.Numerics;
using Engine;
using Raylib_cs;

namespace Game;

public class Player : GameObject, ICollidable, IDamageable
{
    public Vector2 Position { get; set; }
    public HealthSystem Health { get; private set; } = new(100);

    public Rectangle BoundingRect => new Rectangle(Position.X, Position.Y, ElementWidth, ElementHeight);

    public ExperienceSystem Experience { get; private set; } = new();
    public float Velocity { get; set; } = 500;
    public ItemManager RightHand { get; private set; }
    public ItemManager LeftHand { get; private set; }
    public EquipmentManager Equipment { get; private set; }

    private Scene? _scene;
    private GameWorld? _world;

    public Player(Vector2 spawnLocation) : base("player")
    {
        Position = spawnLocation;
        RightHand = new ItemManager(this, ElementWidth - ElementWidth / 5, 0);
        LeftHand = new ItemManager(this, - ElementWidth + ElementWidth / 5, 0, -1);
        Equipment = new EquipmentManager();
    }

    public override void Load(Scene scene)
    {
        scene.Load(RightHand);
        scene.Load(LeftHand);
        _scene = scene;
        var world = scene.FindObjectsById("world").FirstOrDefault();
        _world = world as GameWorld;
    }

    private float _regenInterval = 1;
    public override void Update()
    {
        Move();
        Equipment.CycleHotkey();
        Equipment.Update();
        Equipment.UpdateEquipped(LeftHand, RightHand);
        if (Health.GetCurrentHealth() < Health.GetMaxHealth())
        {
            Health.coolDown -= Raylib.GetFrameTime();
        }

        if (Health.coolDown > 0) return;
        
            _regenInterval -= Raylib.GetFrameTime();
            if (_regenInterval > 0) return;
            _regenInterval = 1;
            Health.Heal(2);
    }

    private bool MovementCollides()
    {
        if (_scene == null) return true;
        return _scene.CollidesWith(obj => obj != this && !((ICollidable) obj).IsPassThrough(),this).Count > 0;
    }

    private bool NotInWorld()
    {
        if (_world == null) return false;
        var worldContainedRect = Raylib.GetCollisionRec(_world.Dimension, BoundingRect);
        
        return Math.Abs(worldContainedRect.Width - ElementWidth) > 0.5 ||
               Math.Abs(worldContainedRect.Height - ElementHeight) > 0.5;
    }

    private void CalculatePosition(Vector2 oldPosition, Func<bool> checkDenied)
    {
        if (!checkDenied()) return;
        var delta = Position - oldPosition;
        var preTest = Position;
        Position -= delta with { Y = 0 };
        if (!checkDenied())
        {
            return;
        }

        Position = preTest - delta with { X = 0 };
        if (!checkDenied())
        {
            return;
        }
        Position = oldPosition;
    }

    private void Move()
    {
        if (_scene == null) return;
        var oldPosition = Position;
        Position = PlayerController.Movement(Position, Velocity);
        CalculatePosition(oldPosition, MovementCollides);
        CalculatePosition(oldPosition, NotInWorld);
    }

  
    private readonly Texture2D _tex = EmbeddedTexture.LoadTexture("Game.Roboter-Player.png")!.Value;

    public override void Draw()
    {
        var source = new Rectangle(0, 0, _tex.Width, _tex.Height); 
        var dest = new Rectangle(Position.X, Position.Y, ElementWidth, ElementHeight); 
        Raylib.DrawTexturePro(_tex, source, dest, Vector2.Zero, 0f, Color.White); 
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

    public int ElementWidth { get; set; } = 120;
    public int ElementHeight { get; set; } = 150;
}
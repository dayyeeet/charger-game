using System.Numerics;
using Engine.Scene;
using Engine.Util;
using Game.Item;
using Game.Util.Entity;
using Game.Util.World;
using Raylib_cs;

namespace Game.Entity.Player;

public class Player : GameObject, ICollidable, IDamageable
{
    public Vector2 Position { get; set; }
    public Vector2 LastPosition { get; private set; }
    public Vector2 LastDelta { get; private set; }

    // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
    public HealthSystem Health { get; set; } = new(100);

    public Rectangle BoundingRect
    {
        get => new(Position.X + 30, Position.Y + 10, ElementWidth - 60, ElementHeight - 20);
        set { }
    }

    public Rectangle CollideRect
    {
        get => new(Position.X + 30, Position.Y + ElementHeight - 40, ElementWidth - 60, 20);
        // ReSharper disable once ValueParameterNotUsed
        set { }
    }

    // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local
    public ExperienceSystem Experience { get; private set; } = new();

    // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
    public float Velocity { get; set; } = 500;

    // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local
    public ItemManager RightHand { get; private set; }

    // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local
    public ItemManager LeftHand { get; private set; }

    // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local
    public EquipmentManager Equipment { get; private set; }

    private Scene? _scene;
    private GameWorld? _world;

    private PlayerAnimationController _controller = new();

    public Player(Vector2 spawnLocation) : base("player")
    {
        Position = spawnLocation;
        RightHand = new ItemManager(ElementWidth / 5, ElementHeight / 9) { Parent = this };
        LeftHand = new ItemManager(ElementWidth / 5, -ElementHeight / 9, -1, Layers.LeftHand) { Parent = this };
        Equipment = new EquipmentManager();
    }

    public Player() : this(Vector2.Zero)
    {
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

    private void SimulateEquipmentLayering()
    {
        var direction = LastDelta.X != 0 ? LastDelta.X > 0 ? 1 : -1 : 1;
        switch (direction)
        {
            case -1:
                LeftHand.UpdateLayer(Layers.RightHand);
                RightHand.UpdateLayer(Layers.LeftHand);
                break;
            case 1:
                LeftHand.UpdateLayer(Layers.LeftHand);
                RightHand.UpdateLayer(Layers.RightHand);
                break;
        }

        RightHand.Direction = direction;
        LeftHand.Direction = direction;
    }

    public override void Update()
    {
        Move();
        SimulateEquipmentLayering();
        Equipment.CycleHotkey();
        Equipment.Update();
        Equipment.UpdateEquipped(LeftHand, RightHand);
        _controller.NextAnimationFor(this);
        _controller.Animate();
        if (Health.GetCurrentHealth() < Health.GetMaxHealth())
        {
            Health.CoolDown -= Raylib.GetFrameTime();
        }

        if (Health.CoolDown > 0) return;

        _regenInterval -= Raylib.GetFrameTime();
        if (_regenInterval > 0) return;
        _regenInterval = 1;
        Health.Heal(2);
    }

    private bool MovementCollides()
    {
        if (_scene == null) return true;
        return _scene
            .CollidesWith(
                obj => obj != this && !((ICollidable)obj).IsPassThrough() && !((ICollidable)obj).IsPlayerPassThrough(),
                CollideRect).Count > 0;
    }

    private bool NotInWorld()
    {
        if (_world == null) return false;
        var worldContainedRect = Raylib.GetCollisionRec(_world.Dimension, BoundingRect);

        return Math.Abs(worldContainedRect.Width - BoundingRect.Width) > 0.5 ||
               Math.Abs(worldContainedRect.Height - BoundingRect.Height) > 0.5;
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
        LastPosition = oldPosition;
        if (Position == oldPosition) return;
        LastDelta = Position - oldPosition;
    }

    public override void Draw()
    {
        var dest = new Rectangle(Position.X, Position.Y, ElementWidth, ElementHeight);
        _controller.Draw(dest);
        if (Game.Engine.HitBoxesVisible)
        {
            Raylib.DrawRectangleLinesEx(CollideRect, 1f, Color.SkyBlue);
        }
    }


    public void Kill()
    {
        Health.Kill();
    }

    public void TakeDamage(float damageAmount)
    {
        Health.TakeDamage(damageAmount);
    }

    public void Heal(int healAmount)
    {
        Health.Heal(healAmount);
    }

    public float GetCurrentHealth()
    {
        return Health.GetCurrentHealth();
    }

    public bool IsDead()
    {
        return Health.IsDead;
    }

    public void AddXp(double amount)
    {
        Experience.AddXp(amount, OnLevelUp);
    }

    private void OnLevelUp()
    {
        Game.LoadNextLevel(this);
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
    public int ElementHeight { get; set; } = 120;
}
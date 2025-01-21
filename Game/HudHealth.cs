using System.Numerics;
using Engine;
using Raylib_cs;

namespace Game;

public class HudHealth : HudElement
{
    private HealthSystem? system;
    private int _healthWidth;
    
    public HudHealth() : base("health")
    {
        ElementWidth = 200;
        ElementHeight = 20;
    }

    //Hook into healthSystem
    public override void Load(Scene scene)
    {
        var player = scene.FindObjectsById("player", Layers.Player).FirstOrDefault();
        if (player == null)
        {
            throw new NullReferenceException("Player not found");
        }

        system = (player as Player)?.Health;
    }

    public override void Update()
    {
        if (system != null)
        {
            var currentHealth = system.GetCurrentHealth();
            var maxHealth = system.GetMaxHealth();
            _healthWidth = (int)(ElementWidth * (currentHealth / maxHealth));
        }
    }

    public override void Draw()
    {
        Raylib.DrawRectangle((int)Position.X, (int)Position.Y, ElementWidth, ElementHeight, Color.Red);
        Raylib.DrawRectangle((int)Position.X, (int)Position.Y, _healthWidth, ElementHeight, Color.Green);
    }
}
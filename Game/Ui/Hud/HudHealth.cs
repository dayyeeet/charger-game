using Engine.Scene;
using Engine.Ui.Hud;
using Engine.Util;
using Game.Entity.Player;
using Game.Util.Entity;
using Raylib_cs;

namespace Game.Ui.Hud;

public class HudHealth : HudElement
{
    private HealthSystem? _system;
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

        _system = (player as Player)?.Health;
    }

    public override void Update()
    {
        if (_system != null)
        {
            var currentHealth = _system.GetCurrentHealth();
            var maxHealth = _system.GetMaxHealth();
            _healthWidth = (int)(ElementWidth * (currentHealth / maxHealth));
        }
    }

    public override void Draw()
    {
        Raylib.DrawRectangle((int)Position.X, (int)Position.Y, ElementWidth, ElementHeight, Color.Red);
        Raylib.DrawRectangle((int)Position.X, (int)Position.Y, _healthWidth, ElementHeight, Color.Green);
    }
}
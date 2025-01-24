using Engine.Scene;
using Engine.Ui.Hud;
using Engine.Util;
using Game.Entity.Player;
using Game.Util.Entity;
using Raylib_cs;

namespace Game.Ui.Hud;

public class HudXp : HudElement
{
    private ExperienceSystem? _system;
    private int _xpWidth;

    public HudXp() : base("Xp")
    {
        ElementWidth = 200;
        ElementHeight = 30;
    }

    //Hook into ExperienceSystem
    public override void Load(Scene scene)
    {
        var player = scene.FindObjectsById("player", Layers.Player).FirstOrDefault();
        if (player == null)
        {
            throw new NullReferenceException("Player not found");
        }

        _system = (player as Player)?.Experience;
    }

    public override void Update()
    {
        if (_system != null)
        {
            var currentXp = (int)_system.Xp;
            var maxXp = (int)_system.XpRequiredForNextLevel();
            _xpWidth = (int)(ElementWidth * ((float)currentXp / maxXp));
        }
    }

    public override void Draw()
    {
        Raylib.DrawRectangle((int)Position.X, (int)Position.Y, ElementWidth, ElementHeight, Color.LightGray);
        Raylib.DrawRectangle((int)Position.X, (int)Position.Y, _xpWidth, ElementHeight, Color.Blue);
        if (_system == null) return;
        Raylib.DrawText($"{_system.Level}", (int)Position.X + ElementWidth + 10, (int)Position.Y + 5, 20, Color.Black);
    }
}
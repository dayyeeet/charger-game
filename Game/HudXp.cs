using Engine;
using Raylib_cs;

namespace Game;

public class HudXp : HudElement
{
    private readonly Color color;
    private ExperienceSystem? system;
    private int _xpWidth;

    public HudXp(Color color) : base("Xp")
    {
        ElementWidth = 200;
        ElementHeight = 30;
        this.color = color;
    }

    //Hook into ExperienceSystem
    public override void Load(Scene scene)
    {
        var player = scene.FindObjectsById("player", Layers.Player).FirstOrDefault();
        if (player == null)
        {
            throw new NullReferenceException("Player not found");
        }

        system = (player as Player)?.Experience;
    }

    public override void Update()
    {
        if (system != null)
        {
            var currentXp = (int)system.Xp;
            var maxXp = (int)system.XpRequiredForNextLevel();
            _xpWidth = (int)(ElementWidth * ((float)currentXp / maxXp));
        }
    }

    public override void Draw()
    {
        Raylib.DrawRectangle((int)Position.X, (int)Position.Y, ElementWidth, ElementHeight, Color.LightGray);
        Raylib.DrawRectangle((int)Position.X, (int)Position.Y, _xpWidth, ElementHeight, Color.Blue);
        Raylib.DrawText($"{system.Level}", (int)Position.X + ElementWidth + 10, (int)Position.Y + 5, 20, Color.Black);
    }
}
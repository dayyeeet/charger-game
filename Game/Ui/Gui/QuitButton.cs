using Game.Util.World;

namespace Game.Ui.Gui;

public class QuitButton : Button
{
    public QuitButton(int width, int height) : base(width, height)
    {
        Text = "Quit";
    }

    public bool ShouldSave { get; set; } = true;
    
    public QuitButton() : this(200, 50) {}

    public override void OnClick()
    {
        if(Game.Engine.GetScene() is LevelScene && ShouldSave) Game.Save();
        Game.Engine.Stop();
    }
}
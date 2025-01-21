namespace Game;

public class QuitButton : Button
{
    public QuitButton(int width, int height) : base(width, height)
    {
        Text = "Quit";
    }
    
    public QuitButton() : this(200, 50) {}

    public override void OnClick()
    {
        Game.Save();
        Game.Engine.Stop();
    }
}
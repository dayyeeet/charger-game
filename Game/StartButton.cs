namespace Game;

public class StartButton : Button
{
    public StartButton(int width, int height) : base(width, height)
    {
        Text = "Start";
    }
    
    public StartButton() : this(200, 50) {}

    public override void OnClick()
    {
        Game.Start();
    }
}
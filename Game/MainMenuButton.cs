namespace Game;

public class MainMenuButton : Button
{
    public MainMenuButton(int width, int height) : base(width, height)
    {
        Text = "Main Menu";
    }
    
    public MainMenuButton() : this(200, 50) {}

    public override void OnClick()
    {
        Game.Save();
        Game.Engine.LoadScene(new MainMenu());
    }
}
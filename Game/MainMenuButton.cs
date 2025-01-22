namespace Game;

public class MainMenuButton : Button
{
    public MainMenuButton(int width, int height) : base(width, height)
    {
        Text = "Main Menu";
    }
    
    public MainMenuButton() : this(200, 50) {}
    
    public bool ShouldSave { get; set; } = true;

    public override void OnClick()
    {
        if(ShouldSave) Game.Save();
        Game.Engine.LoadScene(new MainMenu());
    }
}
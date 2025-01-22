namespace Game;

public class NewGameButton : Button
{
    public NewGameButton(int width, int height) : base(width, height)
    {
        Text = "New Game";
    }
    
    public NewGameButton() : this(200, 50) {}
    
    public override void OnClick()
    {
        Game.LoadNextLevel();
    }
}
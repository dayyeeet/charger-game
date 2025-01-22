namespace Game;

public class SaveButton : Button
{
    public SaveButton(int width, int height) : base(width, height)
    {
        Text = "Save";
    }
    
    public SaveButton() : this(200, 50) {}

    public override void OnClick()
    {
        Game.Save();
    }
}
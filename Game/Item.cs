namespace Game;

public abstract class Item   
{
    private string name;

    public string GetName()   //getter
    {
        return this.name;
    }

    public void SetName(string nameOfItem)   //setter
    {
        this.name = nameOfItem;
    }

    protected Item(string name)    //constructor
    {
        this.name = name;
    }

    public abstract void Update(int xOffset, int yOffset);    //empty void method for updating item position
}
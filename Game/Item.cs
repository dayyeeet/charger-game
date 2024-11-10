namespace Game;

public abstract class Item(string name)
{
    private string _name = name; 

    public string GetName()   //getter
    {
        return this._name;
    }

    public void SetName(string nameOfItem)   //setter
    {
        this._name = nameOfItem;
    }

    //constructor

    public abstract void Update(int xOffset, int yOffset);    //empty void method for updating item position
}
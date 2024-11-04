namespace Game;

public class ItemManager
{
    private int offsetX;
    private int offsetY;
    private Item item;

    public ItemManager(int offsetX, int offsetY)   //constructor
    {
        this.offsetX = offsetX;
        this.offsetY = offsetY;
    }

    public void SetItem(Item item)   //setter
    {
        this.item = item;
    }

    public void UpdateItem()    //update function for changing player item#
    {
        this.item?.Update(this.offsetX, this.offsetY);
    }
}
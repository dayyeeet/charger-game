namespace Game;

public class ItemManager(int offsetX, int offsetY, Item item)
{
    
    private Item _item = item;
    

    public void SetItem(Item item)   //setter
    {
        _item = item;
    }

    public void UpdateItem()    //update function for changing player item#
    {
        _item.Update(offsetX, offsetY);
    }
}
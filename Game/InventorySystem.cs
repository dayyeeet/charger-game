namespace Game; 

public class InventorySystem
{
    private readonly List<Item> _items;
    
    public InventorySystem()
    {
        _items = new List<Item>();
    }

    // Adds an item to the inventory.
    public void AddItem(Item item)
    {
        _items.Add(item); 
    }

    // Removes an item from the inventory
    public void RemoveItem(string itemName)
    {
        var item = _items.Find(i => i._name.Equals(itemName, StringComparison.OrdinalIgnoreCase));

        // If an item with the specified name is found, it is removed from the inventory.
        if (item != null)
        {
            _items.Remove(item);
        }
    }

    // Displays all items in the inventory.
    public void ShowInventory()
    {
        if (_items.Count == 0)
        {
        }
        else
        {
            foreach (var item in _items)
            {
               
            }
        }
    }
    
    public void UseItem(string itemName, Player player)
    {
        // Finds an item in the inventory with the specified name
        var item = _items.Find(i => i._name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
        
        if (item != null)
        {
            item.Use();
        }
    }
}
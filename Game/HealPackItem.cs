namespace Game;

public class HealPack : Item
{
    private int _healingAmount;

    // Constructor for HealPack, takes name and healing amount as parameters
    public HealPack(string name, int healingAmount) : base(name)
    {
        _healingAmount = healingAmount;
    }


    // Method to handle the right-click heal functionality
    public bool Heal(Player player)
    {
        if (player.CurrentHealth < player.MaxHealth)
        {
            int healthToRestore = Math.Min(_healingAmount, player.MaxHealth - player.CurrentHealth);
            player.CurrentHealth += healthToRestore;
            return true; // Healing was successful
        }

        return false; // Player was at max health, so no healing occurred
    }
}
    
    
        



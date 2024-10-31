namespace Game;

public class health_system
{
    private int currentHealth;
    private int maxHealth;
    public bool IsDead { get; private set; }
    public health_system (int initialHealth)
    {
        maxHealth = initialHealth;
        currentHealth = maxHealth;
        IsDead = false;
    }
    public void Kill()
    {
        currentHealth = 0;
        IsDead = true;
    }
    public void TakeDamage(int damageAmount)
    {
        if (IsDead) return;

        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Kill();
        }
    }
    public void RepairHealth(int repairAmount)
    {
        if (IsDead) return;

        currentHealth = Math.Min(currentHealth + repairAmount, maxHealth);
    }
    public int GetCurrentHealth() => currentHealth;
}
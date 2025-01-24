namespace Game.Util.Entity;

public class HealthSystem
{
    public float CurrentHealth { get; set; }
    public int MaxHealth { get; set; }
    public float CoolDown { get; set; }
    public bool IsDead { get; private set; }

    public HealthSystem(int initialHealth = 100)
    {
        MaxHealth = initialHealth;
        CurrentHealth = MaxHealth;
        IsDead = false;
    }

    public HealthSystem() : this(100)
    {
    }

    public void Kill()
    {
        CurrentHealth = 0;
        IsDead = true;
    }

    public bool TakeDamage(int damageAmount)
    {
        return TakeDamage((float)damageAmount);
    }

    public bool TakeDamage(float damageAmount)
    {
        CoolDown = 5;
        if (IsDead) return true;

        CurrentHealth -= damageAmount;

        if (CurrentHealth <= 0)
        {
            Kill();
        }

        return IsDead;
    }

    public void Heal(int repairAmount)
    {
        if (IsDead) return;

        CurrentHealth = Math.Min(CurrentHealth + repairAmount, MaxHealth);
    }

    public float GetCurrentHealth() => CurrentHealth;
    public int GetMaxHealth() => MaxHealth;
}
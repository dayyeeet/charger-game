using Raylib_cs;

namespace Game;

public class HealthSystem
{
    private float _currentHealth;
    private int _maxHealth;
    public float coolDown;
    public bool IsDead { get; private set; }

    public HealthSystem(int initialHealth = 100)
    {
        _maxHealth = initialHealth;
        _currentHealth = _maxHealth;
        IsDead = false;
    }
    
    public HealthSystem() : this(100) {}

    public void Kill()
    {
        _currentHealth = 0;
        IsDead = true;
    }

    public bool TakeDamage(int damageAmount)
    {
        coolDown = 5;
        return TakeDamage((float)damageAmount);
    }

    public bool TakeDamage(float damageAmount)
    {
        if (IsDead) return true;

        _currentHealth -= damageAmount;

        if (_currentHealth <= 0)
        {
            Kill();
        }
        
        return IsDead;
    }
    public void Heal(int repairAmount)
    {
        if (IsDead) return;

        _currentHealth = Math.Min(_currentHealth + repairAmount, _maxHealth);
    }
    public float GetCurrentHealth() => _currentHealth;
    public int GetMaxHealth() => _maxHealth;
}
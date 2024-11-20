namespace Engine;

public abstract class Enemy
{
    
    public float Speed { get; protected set; }  
    public float Life { get; protected set; }   
    public float Damage { get; protected set; } 
    
    protected Enemy(float speed, float life, float damage)
    {
        Speed = speed;
        Life = life;
        Damage = damage;
    }
    
    public abstract void Move();           
    public abstract void Attack();         
    public abstract void TakeDamage(float amount); 

    // Common Method
    public bool IsAlive()
    {
        return Life > 0;
    }
}
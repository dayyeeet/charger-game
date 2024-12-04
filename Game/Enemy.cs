namespace Game;

public abstract class Enemy : IPositionable, ISizableObject
    {
        // Properties for speed and damage
        public float Speed { get; protected set; }
        public float Damage { get; protected set; }

        // HealthSystem instance to manage health
        public HealthSystem Health { get; private set; }

        // IPositionable implementation (X and Y position)
        public float X { get; set; }
        public float Y { get; set; }

        // ISizableObject implementation (Width and Height)
        public float Width { get; set; }
        public float Height { get; set; }

        // Constructor to initialize Enemy
        protected Enemy(float speed, int initialHealth, float damage, float x, float y, float width, float height)
        {
            Speed = speed;
            Damage = damage;
            Health = new HealthSystem(initialHealth);
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        // Abstract methods to be implemented by derived classes
        public abstract void Move();
        public abstract void Attack();

        // Method to handle taking damage
        public void TakeDamage(float amount)
        {
            int damageAmount = (int)amount;  // Convert to integer if needed
            bool isDead = Health.TakeDamage(damageAmount);
            if (isDead)
            {
                // Optional death logic
                OnDeath();
            }
        }

        // Method to heal the enemy
        public void Heal(int amount)
        {
            Health.Heal(amount);
        }

        // Check if the enemy is alive
        public bool IsAlive()
        {
            return !Health.IsDead;
        }

        // Optional method to handle death-related actions
        protected virtual void OnDeath()
        {
            // Actions when the enemy dies (e.g., dropping items)
        }
    }

        // Check if the enemy is alive
        public bool IsAlive()
        {
            return !Health.IsDead;
        }

        // Optional method to handle death-related actions
        protected virtual void OnDeath()
        {
            // Actions when the enemy dies (e.g., dropping items)
        }
    }
}
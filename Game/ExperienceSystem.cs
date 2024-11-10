using System;

namespace Game
{
    public class ExperienceSystem
    {
        public double Xp { get; private set; } // Current XP of the player
        public int Level { get; private set; } // Current level of the player
        public double Difficulty { get; private set; } // Difficulty level that increases with each level up
        
        public ExperienceSystem(double initialXp = 0, int initialLevel = 1, double initialDifficulty = 1.0)
        {
            Xp = initialXp;
            Level = initialLevel;
            Difficulty = initialDifficulty;
        }
        
        public void AddXp(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("XP amount must be positive.");
            }

            Xp += amount;
            CheckLevelUp();
        }
        
        private void CheckLevelUp()
        {
            while (Xp >= XpRequiredForNextLevel())
            {
                LevelUp();
            }
        }
        
        private double XpRequiredForNextLevel()
        {
            return Math.Pow(Level, 1.5) * 100 * Difficulty;
        }
        
        private void LevelUp()
        {
            Level++;
            Difficulty += 0.1; 
        }
    }
}



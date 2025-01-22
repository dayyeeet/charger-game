using System;
using Raylib_cs;

namespace Game
{
    public class ExperienceSystem(double initialXp = 0, int initialLevel = 1, double initialDifficulty = 0.0)
    {
        public double Xp { get; private set; } = initialXp; // Current XP of the player
        public int Level { get; private set; } = initialLevel; // Current level of the player
        public double Difficulty { get; private set; } = initialDifficulty; // Difficulty level that increases with each level up

        public ExperienceSystem() : this(0) {}
        

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

        public double XpRequiredForNextLevel()
        {
            return  100 + 100 * Difficulty;
        }

        private void LevelUp()
        {
            
            while (Xp >= XpRequiredForNextLevel())
            {
                var tooMuchXp = (int)(Xp - XpRequiredForNextLevel());
                Xp = 0;
                Xp += tooMuchXp;
                Level++;
                Difficulty += 0.1;
            }
        }
    }
}
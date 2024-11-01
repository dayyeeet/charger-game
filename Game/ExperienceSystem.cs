namespace Game;

public class ExperienceSystem

{
    private double Xp { get; set; } // Current XP of the player
    private int Level { get; set; } // Current level of the player
    private double Difficulty { get; set; } // Difficulty level that increases with each level up

    public ExperienceSystem(double initialXp = 0, int initialLevel = 1, double initialDifficulty = 1.0)
    {
        Xp = initialXp;
        Level = initialLevel;
        Difficulty = initialDifficulty;

        void AddXp(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("XP amount must be positive.");
            }

            double xp;
            CheckLevelUp();


            void CheckLevelUp()
            {
                while (Xp >= XpRequiredfornextLevel())
                {
                    LevelUp();
                }
            }

            double XpRequiredfornextLevel()
            {
                // XP required for the next level increases with both level and difficulty
                return Math.Pow(Level, 1.5) * 100 * Difficulty;
            }

            void LevelUp()
            {
                Level++;
                Difficulty += 0.1; // Increase difficulty by 10% each level
            }
        }
    }
}
        
        


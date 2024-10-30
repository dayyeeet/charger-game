namespace Game;

public class XP_System
{
class PlayerXP
{
    public double XP { get; private set; } // Current XP of the player
    public int Level { get; private set; } // Current level of the player
    public double Difficulty { get; private set; } // Difficulty level that increases with each level up

    public PlayerXP(double initialXP = 0, int initialLevel = 1, double initialDifficulty = 1.0)
    {
        XP = initialXP;
        Level = initialLevel;
        Difficulty = initialDifficulty;
    }

    public void AddXP(double amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException("XP amount must be positive.");
        }
        
        XP += amount;
        CheckLevelUp();
    }

    private void CheckLevelUp()
    {
        while (XP >= XPToNextLevel())
        {
            LevelUp();
        }
    }

    private double XPToNextLevel()
    {
        // XP required for the next level increases with both level and difficulty
        return Math.Pow(Level, 1.5) * 100 * Difficulty;
    }

    private void LevelUp()
    {
        Level++;
        Difficulty += 0.1; // Increase difficulty by 10% each level
        Console.WriteLine($"Congratulations! You've reached Level {Level}. Difficulty is now {Difficulty:F1}.");
    }

    public double NextLevelXP()
    {
        // Returns the remaining XP needed to reach the next level
        return Math.Max(0, XPToNextLevel() - XP);
    }

    public override string ToString()
    {
        // Displays current status of the player
        return $"XP: {XP:F1}, Level: {Level}, XP needed for next level: {NextLevelXP():F1}, Difficulty: {Difficulty:F1}";
    }
}

}
namespace Game;

public class XP_System

{
    public double XP { get; private set; } // Current XP of the player
    public int Level { get; private set; } // Current level of the player
    public double Difficulty { get; private set; } // Difficulty level that increases with each level up

    public XP_System(double initialXP = 0, int initialLevel = 1, double initialDifficulty = 1.0)
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
        while (XP >= ProgressXp())
        {
            LevelUp();
        }
    }

    private double ProgressXp()
    {
        // XP required for the next level increases with both level and difficulty
        return Math.Pow(Level, 1.5) * 100 * Difficulty;
    }

    private void LevelUp()
    {
        Level++;
        Difficulty += 0.1; // Increase difficulty by 10% each level
    }

    public double AdvanceXp()
    {
        // Returns the remaining XP needed to reach the next level
        return Math.Max(0, AdvanceXp() - XP);
    }

    public override string ToString()
    {
        // Displays current status of the player
        return $"XP: {XP:F1}, Level: {Level}, XP needed for next level: {AdvanceXp():F1}, Difficulty: {Difficulty:F1}";
    }
}

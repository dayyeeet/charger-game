namespace Game.Util.Loot;

public static class LootTable
{
    public static T RandomOfLootTable<T>(Dictionary<T, double> probabilityMap) where T : notnull
    {
        if (probabilityMap == null || probabilityMap.Count == 0)
        {
            throw new ArgumentException("The probability map cannot be null or empty.", nameof(probabilityMap));
        }

        double totalProbability = 0;
        foreach (var probability in probabilityMap.Values)
        {
            if (probability is < 0 or > 1)
            {
                throw new ArgumentOutOfRangeException(nameof(probabilityMap), "Probabilities must be between 0 and 1.");
            }

            totalProbability += probability;
        }

        if (Math.Abs(totalProbability - 1) > 0.0001)
        {
            throw new InvalidOperationException("The probabilities in the map do not sum up to 1.");
        }

        Random rand = new Random();
        var randomValue = rand.NextDouble();

        var cumulativeProbability = 0.0;
        foreach (var entry in probabilityMap)
        {
            cumulativeProbability += entry.Value;
            if (!(randomValue <= cumulativeProbability)) continue;
            return entry.Key;
        }

        throw new InvalidOperationException("Nothing found");
    }
}
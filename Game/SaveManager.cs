using Raylib_cs;

namespace Game
{
    public class SaveManager
    {
        private const string SaveFilePath = "savegame.txt";

        public static void SaveLevel(int level)
        {
            try
            {
                File.WriteAllText(SaveFilePath, level.ToString());
            }
            catch (Exception e)
            {
                Raylib.TraceLog(TraceLogLevel.Error, $"Failed to save level: {e.Message}");
            }
        }

        public static int LoadLevel()
        {
            try
            {
                if (File.Exists(SaveFilePath))
                {
                    var level = File.ReadAllText(SaveFilePath);
                    return int.TryParse(level, out var levelNumber) ? levelNumber : 1;
                }
            }
            catch (Exception e)
            {
                Raylib.TraceLog(TraceLogLevel.Error, $"Failed to load level: {e.Message}");
            }
            return 1; // Default to level 1 if no save file exists
        }
    }
}
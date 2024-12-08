using Engine;

namespace Game;
public class SceneLoader
{
    public static Scene Load(int i)
    {
        return i switch
        {
            0 => new SampleScene(),
            1 => new Level2(),
            2 => new Level3(),
            _ => new SampleScene()
        };
    }
    public static void Save(Scene scene)
    {
        var saved = scene switch
        {
            SampleScene => 0,
            Level2 => 1,
            Level3 => 2,
            _ => 0
        };
        SaveManager.SaveLevel(saved);
    }
}
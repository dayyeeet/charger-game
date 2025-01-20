using Engine;

namespace Game;
public class SceneLoader
{
    public static Scene Load(int i)
    {
        return i switch
        {
            0 => new LevelScene(new LevelOneWorld(1000,1000)),
            1 => new LevelScene(new LevelTwoWorld(1000,1000)),
            2 => new LevelScene(new LevelThreeWorld(1000,1000)),
            _ => new LevelScene(new LevelOneWorld(1000,1000))
        };
    }
    public static void Save(LevelScene scene)
    {
        var saved = scene.GameWorld switch
        {
            LevelOneWorld => 0,
            LevelTwoWorld => 1,
            LevelThreeWorld => 2,
            _ => 0
        };
        SaveManager.SaveLevel(saved);
    }
}
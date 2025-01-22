namespace Engine;

//Object that can be present in scenes (e.g. Enemy, Player, HUD)
public abstract class GameObject(string id) : IGameUpdatable
{
    public string Type
    {
        get => GetType().FullName!;
        set {}
    }

    public virtual void Update()
    {
    }

    public virtual void Draw()
    {
    }

    public virtual void Close()
    {
    }
    //Called when object is added to scene, retuSns true if loading was successful. If an exception is thrown during load process, the game object wont be added
    public virtual void Load(Scene scene)
    {
    }

    //Called when object is removed from scene
    public virtual void Unload(Scene scene)
    {
    }

    //Returns the identifier of the GameObject (e.g. "hud", "small_enemy", ...)
    public string GetId()
    {
        return id;
    }
}
using Raylib_cs;

namespace Engine;

public abstract class PopoverObject(string id, KeyboardKey popoverKey) : GameObject($"popover-{id}")
{
    private bool _toggled = false;
    protected Scene? _scene;

    public virtual void DrawToggled() {}
    public virtual void OnToggle(bool toggled) {}
    public override void Update()
    {
        if (!Raylib.IsKeyReleased(popoverKey)) return;
        _toggled = !_toggled;
        OnToggle(_toggled);
        if (_scene != null) _scene.Paused = _toggled;
    }

    public override void Load(Scene scene)
    {
        base.Load(scene);
        _scene = scene;
    }

    public override void Draw()
    {
        if (_toggled)
        {
            DrawToggled();
        }
    }
    
}
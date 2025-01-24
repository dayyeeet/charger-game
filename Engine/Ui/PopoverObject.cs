using Engine.Scene;
using Raylib_cs;

namespace Engine.Ui;

public abstract class PopoverObject(string id, KeyboardKey popoverKey) : GameObject($"popover-{id}")
{
    private bool _toggled;
    protected Scene.Scene? Scene;

    protected virtual void DrawToggled()
    {
    }

    protected virtual void OnToggle(bool toggled)
    {
    }

    public override void Update()
    {
        if (!Raylib.IsKeyReleased(popoverKey)) return;
        _toggled = !_toggled;
        OnToggle(_toggled);
        if (Scene != null) Scene.Paused = _toggled;
    }

    public override void Load(Scene.Scene scene)
    {
        base.Load(scene);
        Scene = scene;
    }

    public override void Draw()
    {
        if (_toggled)
        {
            DrawToggled();
        }
    }
}
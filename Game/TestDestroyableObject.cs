using System.Numerics;
using Engine;
using Raylib_cs;

namespace Game;

public class TestDestroyableObject() : DestroyableObject("test-destroyable", 75)
{
    public override int ElementWidth { get; set; } = 20;
    public override int ElementHeight { get; set; } = 15;
    public override int Layer { get; set; } = Layers.Decoration;

    private Scene? _scene;

    public override void Draw()
    {
        Raylib.DrawRectangleV(Position, new Vector2(ElementWidth,ElementHeight), Color.Orange);
    }

    public override void Load(Scene scene)
    {
        base.Load(scene);
        _scene = scene;
    }

    public override void Update()
    {
        base.Update();
        if (Health.IsDead)
        {
            _scene?.Unload(this);
        }
    }
}
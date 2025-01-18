using Raylib_cs;

namespace Engine;

public class DebugKeyHandler(GameEngine engine) : GameObject("debug-key-handler")
{
    
    public override void Update()
    {
        base.Update();
        if (Raylib.IsKeyPressed(KeyboardKey.B))
        {
            engine.HitBoxesVisible = !engine.HitBoxesVisible;
        }

        if (Raylib.IsKeyPressed(KeyboardKey.V))
        {
            engine.AiPointsVisible = !engine.AiPointsVisible;
        }

        if (Raylib.IsKeyPressed(KeyboardKey.J))
        {
            engine.FpsVisible = !engine.FpsVisible;
        }
    }
}
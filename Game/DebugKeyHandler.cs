using Engine;
using Raylib_cs;

namespace Game;
public class DebugKeyHandler() : GameObject("debug-key-handler")
{
    
    public override void Update()
    {
        base.Update();
        if (Raylib.IsKeyPressed(KeyboardKey.B))
        {
            Game.Engine.HitBoxesVisible = !Game.Engine.HitBoxesVisible;
        }

        if (Raylib.IsKeyPressed(KeyboardKey.V))
        {
            Game.Engine.AiPointsVisible = !Game.Engine.AiPointsVisible;
        }

        if (Raylib.IsKeyPressed(KeyboardKey.J))
        {
            Game.Engine.FpsVisible = !Game.Engine.FpsVisible;
        }
    }
}
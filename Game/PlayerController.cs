using System.Numerics;
using Raylib_cs;

namespace Game;

public static class PlayerController
{
    public static Vector2 Movement(Vector2 position, float velocity)
    {
        if (Raylib.IsKeyDown(KeyboardKey.D))
        {
            position.X += velocity * Raylib.GetFrameTime();
        }

        if (Raylib.IsKeyDown(KeyboardKey.A))
        {
            position.X -= velocity * Raylib.GetFrameTime();
        }

        if (Raylib.IsKeyDown(KeyboardKey.W))
        {
            position.Y -= velocity * Raylib.GetFrameTime();
        }

        if (Raylib.IsKeyDown(KeyboardKey.S))
        {
            position.Y += velocity * Raylib.GetFrameTime();
        }
        return position;
    }
}
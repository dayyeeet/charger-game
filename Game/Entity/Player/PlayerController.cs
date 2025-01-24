using System.Numerics;
using Raylib_cs;

namespace Game.Entity.Player;

public static class PlayerController
{
    public static Vector2 Movement(Vector2 position, float velocity)
    {
        var movement = Vector2.Zero;
        
        if (Raylib.IsKeyDown(KeyboardKey.D))
        {
            movement.X += 1;
        }

        if (Raylib.IsKeyDown(KeyboardKey.A))
        {
            movement.X -= 1;
        }

        if (Raylib.IsKeyDown(KeyboardKey.W))
        {
            movement.Y -= 1;
        }

        if (Raylib.IsKeyDown(KeyboardKey.S))
        {
            movement.Y += 1;
        }
        
        movement = Vector2.Normalize(movement);
        
        position += movement * velocity * Raylib.GetFrameTime();
        
        return position;
    }
}
using System.Drawing;
using System.Numerics;
using Engine;
using Color = Raylib_cs.Color;

namespace Game;

public abstract class Gun
{
    public abstract void Shoot(Scene scene, IPositionable origin, Vector2 targetPosition);
}
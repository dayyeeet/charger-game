using Raylib_cs;

namespace Engine.Util;

public static class RectIntersects
{
    public static bool With(Rectangle first, Rectangle second)
    {
        return first.X < second.X + second.Width &&
               first.X + first.Width > second.X &&
               first.Y < second.Y + second.Height &&
               first.Y + first.Height > second.Y;
    }
}
using Raylib_cs;

namespace Engine.Util;

using static Raylib;

public class GameWindow(int windowWidth, int windowHeight)
{
    public void CreateWindow(string title)
    {
        InitWindow(windowWidth, windowHeight, title);
    }

    public int GetWindowWidth()
    {
        return windowWidth;
    }

    public int GetWindowHeight()
    {
        return windowHeight;
    }
}
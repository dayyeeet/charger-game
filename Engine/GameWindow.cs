namespace Engine;

using static Raylib_cs.Raylib;

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
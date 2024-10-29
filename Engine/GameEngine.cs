using Raylib_cs;

namespace Engine;

using static Raylib;

public class GameEngine
{
    private readonly GameWindow _window = new(800, 450);
    private bool _running;
    private Scene? _currentScene;

    public void Start()
    {
        _running = true;
        _window.CreateWindow("Team SkEPsis - Game");
        SetTargetFPS(60);
        while (!WindowShouldClose() && _running)
        {
            if (_currentScene == null) continue;
            _currentScene.Update();
            BeginDrawing();
            ClearBackground(Color.White);
            _currentScene.Draw();
            EndDrawing();
        }

        CloseWindow();
    }
    
    //Load a new Scene
    public void LoadScene(Scene scene)
    {
        _currentScene = scene;
    }

    //Retrieve current window
    public GameWindow GetWindow()
    {
        return _window;
    }

    //Retrieve the current scene
    public Scene? GetScene()
    {
        return _currentScene;
    }

    public void Stop()
    {
        _running = false;
    }
}
using Raylib_cs;

namespace Engine;

using static Raylib;

public class GameEngine
{
    private readonly GameWindow _window = new(1200, 720);
    private bool _running;
    private Scene? _currentScene;
    private TrackingCamera? _trackingCamera;

    public GameEngine()
    {
        _window.CreateWindow("Team SkEPsis - Game");
    }

    public void Start()
    {
        _running = true;

        SetTargetFPS(60);
        while (!WindowShouldClose() && _running)
        {
            if (_currentScene == null) continue;
            _currentScene.Update();
            _trackingCamera?.Update();
            BeginDrawing();
            ClearBackground(Color.White);

            if (_trackingCamera == null)
            {
                _currentScene.Draw();
                _currentScene.Draw2D();
            }
            else
            {
                BeginMode2D(_trackingCamera.GetCamera());
                _currentScene.Draw2D();
                // Comment/Uncomment the next line if you (don't) want hitboxes shown
                // ShowHitBoxes();
                EndMode2D();
                _currentScene.Draw();
            }

            EndDrawing();
        }

        CloseWindow();
    }

    //Load a new Scene
    public void LoadScene(Scene scene)
    {
        _currentScene = scene;
    }

    private void ShowHitBoxes()
    {
        foreach (var rect in _currentScene.BoundingBoxes)
        {
            DrawRectangleLinesEx(rect.BoundingRect, 2f, Color.Yellow);
        }
    }

    public void SetTracking(IPositionable? tracking)
    {
        if (tracking == null)
        {
            _trackingCamera = null;
            return;
        }
        _trackingCamera = new TrackingCamera(_window, tracking);
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
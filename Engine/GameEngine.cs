using Raylib_cs;

namespace Engine;

using static Raylib;

public class GameEngine
{
    private readonly GameWindow _window = new(1200, 720);
    private bool _running;
    private Scene? _currentScene;
    private TrackingCamera? _trackingCamera;
    public Color BackgroundColor { get; set; } = Color.White;
    public bool HitBoxesVisible { get; set; }
    public bool AiPointsVisible { get; set; }
    public bool FpsVisible { get; set; }
    
    public Music? CurrentMusic { get; set; }

    public GameEngine()
    {
        _window.CreateWindow("Team SkEPsis - Game");
    }

    public delegate void OnStart();

    public void Start(OnStart onStart)
    {
        _running = true;
        SetExitKey(KeyboardKey.Delete);
        SetTargetFPS(60);
        InitAudioDevice();
        SetMasterVolume(1.0f);
        onStart();
        while (!WindowShouldClose() && _running)
        {
            if (_currentScene == null) continue;
            _currentScene.Update();
            if(CurrentMusic != null)
                UpdateMusicStream(CurrentMusic.Value);
            _trackingCamera?.Update();
            BeginDrawing();
            ClearBackground(BackgroundColor);

            if (_trackingCamera == null)
            {
                _currentScene.Draw();
                _currentScene.Draw2D();
            }
            else
            {
                BeginMode2D(_trackingCamera.GetCamera());
                _currentScene.Draw2D();
                if (HitBoxesVisible)
                    ShowHitBoxes();
                EndMode2D();
                _currentScene.Draw();
                if (FpsVisible)
                    DrawFPS(5, _window.GetWindowHeight() - 25);
            }

            EndDrawing();
        }

        _currentScene?.Close();
        CloseAudioDevice();
        CloseWindow();
    }

    //Load a new Scene
    public void LoadScene(Scene scene)
    {
        _currentScene = scene;
    }

    private void ShowHitBoxes()
    {
        if (_currentScene?.BoundingBoxes == null) return;
        foreach (var rect in _currentScene.BoundingBoxes)
        {
            DrawRectangleLinesEx(rect.BoundingRect, 2f, Color.Yellow);
        }
    }

    public void SetTracking(ICollidable? tracking)
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

    public void StopCurrentMusic()
    {
        if (CurrentMusic != null && IsMusicStreamPlaying(CurrentMusic.Value))
        {
            StopMusicStream(CurrentMusic.Value);
        }
        CurrentMusic = null;
    }
    
    public void Stop()
    {
        _running = false;
    }
}
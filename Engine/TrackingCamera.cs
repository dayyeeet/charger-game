using System.Numerics;
using Raylib_cs;

namespace Engine;

public class TrackingCamera(GameWindow window, IPositionable cameraPosition): IGameUpdatable
{

    private Camera2D _camera = new(new Vector2(window.GetWindowWidth() / 2f, window.GetWindowHeight() / 2f),cameraPosition.Position,0, 1f);
    
    public void Update()
    {
        var delta = cameraPosition.Position - _camera.Target;
        _camera.Target += delta / ((float) Math.PI * 3);
    }

    public Camera2D GetCamera() => _camera;
}
using System.Numerics;
using Engine.Scene;
using Game.Entity.Player;

namespace Game.Pickup;

public abstract class Pickupable(string id, int width, int height) : GameObject($"pickupable-{id}"), ICollidable
{
    public Vector2 Position { get; set; }
    
    protected bool ShouldUnload {get; set;} = false;
    public bool IsPassThrough()
    {
        return true;
    }

    public int ElementWidth { get; set; } = width;
    public int ElementHeight { get; set; } = height;

    protected abstract void OnPickup(Player player);

    private Scene? _scene;

    public override void Load(Scene scene)
    {
        base.Load(scene);
        _scene = scene;
    }

    public override void Update()
    {
        base.Update();
        if (_scene == null) return;
        var collides = _scene.CollidesWith(obj => obj is Player, this);
        var player = collides.Count > 0 ? collides.First() as Player : null;
        if (player == null) return;
        OnPickup(player);

        if (ShouldUnload)
        {
            _scene.Unload(this);
        }
    }
}
using System.Numerics;
using Engine;
using Raylib_cs;

namespace Game;

public class PickupManager() : GameObject("pick-up-manager")
{
    private Scene? _scene;
    private Player? _player;
    private const KeyboardKey PickUpBind = KeyboardKey.F;

    public override void Load(Scene scene)
    {
        base.Load(scene);
        _scene = scene;
        _player = _scene.FindObjectsById("player", Layers.Player).FirstOrDefault() as Player ?? throw new Exception("Player not found");
    }

    public override void Update()
    {
        base.Update();

        if (_scene == null) return;

        if (!Raylib.IsKeyPressed(PickUpBind)) return;

        var nearest = GetNearestItem(_player);
        
        if(nearest == null) return;
        
        nearest.OnControlledPickup(_player);
    }

    private ItemPickupable? GetNearestItem(Player player)
    {
        var normalized = Raylib.GetMousePosition() - new Vector2(Game.Engine.GetWindow().GetWindowWidth() / 2f, Game.Engine.GetWindow().GetWindowHeight() / 2f);
        
        var allCollidingObjects = _scene.CollidesWith(player).OfType<ItemPickupable>();
            
        var nearestItem = allCollidingObjects.OrderBy(itemPickupable => CalculateCenterDistance(normalized, itemPickupable)).FirstOrDefault();
        return nearestItem;
    }

    private float CalculateCenterDistance(Vector2 normalized, ItemPickupable pickupable)
    {
        var center = pickupable.Position - new Vector2(pickupable.ElementWidth/2f, pickupable.ElementHeight/2f);

        return Vector2.Distance(center, normalized);
    }
}
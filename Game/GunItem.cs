using Engine;

namespace Game;

public class GunItem(string name) : Item(name)
{
    public Gun Gun { get; }
    private Scene? _scene;
    private Player? _player;
    public GunItem(string name, Gun gun) : this(name)
    {
        Gun = gun;
    }

    public override void Update()
    {
        base.Update();
        if (_scene == null || _player == null) return;
        ShootingMechanic.ShootIfKeyDown(_scene, _player, Gun);
    }

    public override void Load(Scene scene)
    {
       _scene = scene;
       var player = scene.FindObjectsById("player", Layers.Player).FirstOrDefault();

       _player = player as Player ?? throw new NullReferenceException("Player not found");
    }
}
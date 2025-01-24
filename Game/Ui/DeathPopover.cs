using Engine.Scene;
using Engine.Util;
using Game.Entity.Player;
using Game.Ui.Gui;
using Game.Util.Save;

namespace Game.Ui;

public class DeathPopover() : GameObject("death-popover")
{
    private Player? _player;
    private Scene? _scene;

    public override void Load(Scene scene)
    {
        base.Load(scene);
        _player = scene.FindObjectsById("player", Layers.Player).FirstOrDefault() as Player ??
                  throw new NullReferenceException("player not found");
        _scene = scene;
    }

    public override void Update()
    {
        base.Update();
        if (_player == null || _scene == null) return;
        if (!_player.Health.IsDead) return;
        _scene.Paused = true;
        SaveManager.WipeSave();
        _scene.Load(new DeathMenu(Game.Engine.GetWindow()), Layers.UI);
    }
}
using Game.Entity.Player;

namespace Game.Gun;

public interface IPlayerGun
{
    public Player? Player { get; set; }
    public float EnergyCost { get; set; }
}
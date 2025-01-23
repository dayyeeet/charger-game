namespace Game;

public interface IPlayerGun
{
    public Player? Player { get; set; }
    public float EnergyCost { get; set; }
}
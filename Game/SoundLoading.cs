namespace Game;

public class SoundLoading
{
    public static SoundSystem Instance { get; } = new();

    static SoundLoading()
    {
        Instance.LoadSound("LaserGunBeam", "Game.soundEffects.LaserGunBeam.wav");
    }
}
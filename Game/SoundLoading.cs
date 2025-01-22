using Engine;

namespace Game;

public class SoundLoading
{
    public static SoundSystem Sound { get; } = new();
    public static MusicSystem Music { get; } = new();

    public static void Load()
    {
        Sound.LoadSound("LaserGunBeam", "Game.soundEffects.LaserGunBeam.wav");
        Music.LoadMusic("TitleScreenMusic", "Game.soundTracks.AmbientSwellTitleScreen1.mp3");
    }
}
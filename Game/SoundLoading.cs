using Engine;

namespace Game;

public class SoundLoading
{
    public static SoundSystem Sound { get; } = new();
    public static MusicSystem Music { get; } = new();

    public static void Load()
    {
        Sound.LoadSound("LaserGunBeam", "Game.soundEffects.LaserGunBeam.wav");
        Sound.LoadSound("PlasmaGun", "Game.soundEffects.ShotSound.wav");
        Sound.LoadSound("Chainsaw", "Game.soundEffects.Chainsaw.wav");
        Sound.LoadSound("Equip1", "Game.soundEffects.Equip1.wav");
        Sound.LoadSound("Equip2", "Game.soundEffects.Equip2.wav");
        Sound.LoadSound("HitSound", "Game.soundEffects.HitSound.wav");
        Sound.LoadSound("XpPickUp","Game.soundEffects.XpPickUp.wav");
        Sound.LoadSound("Break", "Game.soundEffects.Break.wav");
        Sound.LoadSound("Break2", "Game.soundEffects.Break2.wav");
        Sound.LoadSound("Boss", "Game.soundEffects.BossSound.wav");
        Sound.LoadSound("ChestOpen", "Game.soundEffects.ChestOpen.wav");
        Sound.LoadSound("CloseWeaponSwing", "Game.soundEffects.CloseWeaponSwing.wav");
        Sound.LoadSound("CloseWeaponHit", "Game.soundEffects.CloseWeaponHit.wav");
        Sound.LoadSound("Fireball", "Game.soundEffects.Fireball.wav");
        
        Music.LoadMusic("TitleScreenMusic", "Game.soundTracks.AmbientSwellTitleScreen1.mp3");
        Music.LoadMusic("SoundTrack1", "Game.soundTracks.InGameSoundTrack1.mp3");
        Music.LoadMusic("Heartbeat", "Game.soundTracks.Herzschlag.mp3");
    }
}
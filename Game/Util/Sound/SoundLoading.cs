namespace Game.Util.Sound;

public class SoundLoading
{
    public static SoundSystem Sound { get; } = new();
    public static MusicSystem Music { get; } = new();

    public static void Load()
    {
        Sound.LoadSound("laser-beam", "Game.sound.effects.laser-beam.wav");
        Sound.LoadSound("shoot", "Game.sound.effects.shoot.wav");
        Sound.LoadSound("chainsaw", "Game.sound.effects.chainsaw.wav");
        Sound.LoadSound("equip-left", "Game.sound.effects.equip-left.wav");
        Sound.LoadSound("equip-right", "Game.sound.effects.equip-right.wav");
        Sound.LoadSound("hit-enemy", "Game.sound.effects.hit-enemy.wav");
        Sound.LoadSound("xp","Game.sound.effects.xp.wav");
        Sound.LoadSound("break", "Game.sound.effects.break.wav");
        Sound.LoadSound("chest", "Game.sound.effects.chest.wav");
        Sound.LoadSound("swing", "Game.sound.effects.swing.wav");
        Sound.LoadSound("hit", "Game.sound.effects.hit.wav");
        Sound.LoadSound("fireball", "Game.sound.effects.fireball.wav");
        
        Music.LoadMusic("ingame", "Game.sound.tracks.ingame.mp3");
        Music.LoadMusic("heart-beat", "Game.sound.tracks.heart-beat.mp3");
        Music.LoadMusic("main-menu", "Game.sound.tracks.main-menu.mp3");
    }
}
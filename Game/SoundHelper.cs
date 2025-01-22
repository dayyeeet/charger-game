using Engine;
using Raylib_cs;

namespace Game;

public class SoundHelper() : GameObject("sound-helper")
{
    public override void Close()
    {
        base.Close();
        SoundLoading.Sound.UnloadAllSounds();
        SoundLoading.Music.UnloadAllMusic();
    }

    public override void Update()
    {
        base.Update();
        if (SoundLoading.Music.CurrentMusic == null) return;
        var value = SoundLoading.Music.CurrentMusic!.Value;
        if (!Raylib.IsMusicValid(value)) return;
        if (!Raylib.IsMusicStreamPlaying(value)) return;
        Raylib.UpdateMusicStream(value);
    }
}
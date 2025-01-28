using Game.Util.Resource;
using Raylib_cs;

namespace Game.Util.Sound;

public class MusicSystem
{
    private readonly Dictionary<string, string> _samples = new();


    public void LoadMusic(string sampleName, string filePath)
    {
        _samples.TryAdd(sampleName, filePath);
    }

    public void PlayMusic(string sampleName)
    {
        if (!_samples.TryGetValue(sampleName, out var value)) return;
        Game.Engine.StopCurrentMusic();
        Game.Engine.Music = EmbeddedAudio.LoadMusic(value)!.Value;
        Raylib.PlayMusicStream(Game.Engine.Music!.Value);
        Raylib.SetMusicVolume(Game.Engine.Music!.Value, Game.Settings.MusicVolume);
    }
    
    public void SetMusicVolume(float volume)
    {
        if(Game.Engine.Music == null) return;
        Raylib.SetMusicVolume(Game.Engine.Music.Value, volume);
        Game.Settings.MusicVolume = volume;
    }
}
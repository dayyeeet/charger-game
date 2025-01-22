using Raylib_cs;

namespace Game;

public class MusicSystem
{
    private readonly Dictionary<string, Music> _samples = new();
    public Music? CurrentMusic { get; private set; }
    
    public void LoadMusic(string sampleName, string filePath)
    {
        if (_samples.ContainsKey(sampleName)) return;
        var sample = EmbeddedAudio.LoadMusic(filePath)!.Value;
        _samples[sampleName] = sample;
    }

    public void PlayMusic(string sampleName)
    {
        if (!_samples.TryGetValue(sampleName, out Music value)) return;
        if (Raylib.IsMusicStreamPlaying(value)) return;
        Raylib.PlayMusicStream(value);
        CurrentMusic = value;
    }

    public void StopMusic(string sampleName)
    {
        if (!_samples.TryGetValue(sampleName, out Music value)) return;
        if(Raylib.IsMusicStreamPlaying(value))
            Raylib.StopMusicStream(value);
        CurrentMusic = null;
    }
    
    public void UnloadAllMusic()
    {
        foreach (var sound in _samples.Values)
        {
            Raylib.UnloadMusicStream(sound);
        }
        _samples.Clear();
    }
}
using Raylib_cs;

namespace Game;

public class MusicSystem
{
    private readonly Dictionary<string, Music> _samples = new();

    
    public void LoadMusic(string sampleName, string filePath)
    {
        if (_samples.ContainsKey(sampleName)) return;
        var sample = EmbeddedAudio.LoadMusic(filePath)!.Value;
        _samples[sampleName] = sample;
    }

    public void PlayMusic(string sampleName)
    {
        if (!_samples.TryGetValue(sampleName, out Music value)) return;
        
        if (Game.Engine.CurrentMusic != null && Raylib.IsMusicStreamPlaying(Game.Engine.CurrentMusic.Value))
        {
            Raylib.StopMusicStream(Game.Engine.CurrentMusic.Value);
        }
        
        Raylib.PlayMusicStream(value);
        Game.Engine.CurrentMusic = value;
    }

    public void StopMusic(string sampleName)
    {
        if (!_samples.TryGetValue(sampleName, out Music value)) return;
        if(Raylib.IsMusicStreamPlaying(value))
            Raylib.StopMusicStream(value);
        Game.Engine.CurrentMusic = null;
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
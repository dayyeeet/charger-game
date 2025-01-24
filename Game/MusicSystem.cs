using Raylib_cs;

namespace Game;

public class MusicSystem
{
    private readonly Dictionary<string, string> _samples = new();


    public void LoadMusic(string sampleName, string filePath)
    {
        if (!_samples.TryAdd(sampleName, filePath)) return;
    }

    public void PlayMusic(string sampleName)
    {
        if (!_samples.TryGetValue(sampleName, out var value)) return;
        Game.Engine.StopCurrentMusic();
        Game.Engine.Music = EmbeddedAudio.LoadMusic(value)!.Value;
        Raylib.PlayMusicStream(Game.Engine.Music!.Value);
    }
}
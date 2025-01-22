using System.ComponentModel;
using Engine;
using Raylib_cs;
namespace Game;

public class SoundSystem
{
    private readonly Dictionary<string, Sound> _samples = new();

    public void LoadSound(string sampleName, string filePath)
    {
        if (_samples.ContainsKey(sampleName)) return;
            var sample = EmbeddedAudio.LoadSound(filePath)!.Value;
            _samples[sampleName] = sample;
    }

    public void PlaySound(string sampleName)
    {
        if (!_samples.TryGetValue(sampleName, out Sound value)) return;
        if(!Raylib.IsSoundPlaying(value))
            Raylib.PlaySound(value);
    }

    public void StopSound(string sampleName)
    {
        if (!_samples.TryGetValue(sampleName, out Sound value)) return;
        if(Raylib.IsSoundPlaying(value))
            Raylib.StopSound(value);
    }
    
    public void UnloadAllSounds()
    {
        foreach (var sound in _samples.Values)
        {
            Raylib.UnloadSound(sound);
        }
        _samples.Clear();
    }
}
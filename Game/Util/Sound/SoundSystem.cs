using Game.Util.Resource;
using Raylib_cs;

namespace Game.Util.Sound;

public class SoundSystem
{
    private readonly Dictionary<string, Raylib_cs.Sound> _samples = new();

    public void LoadSound(string sampleName, string filePath)
    {
        if (_samples.ContainsKey(sampleName)) return;
            var sample = EmbeddedAudio.LoadSound(filePath)!.Value;
            _samples[sampleName] = sample;
    }

    public void PlaySound(string sampleName, bool overlap = false)
    {
        if (!_samples.TryGetValue(sampleName, out Raylib_cs.Sound value)) return;
        if(overlap || !Raylib.IsSoundPlaying(value))
            Raylib.PlaySound(value);
    }

    public void StopSound(string sampleName)
    {
        if (!_samples.TryGetValue(sampleName, out Raylib_cs.Sound value)) return;
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

    public void SetEffectVolume(float volume)
    {
        foreach (var sound in _samples.Values)
            Raylib.SetSoundVolume(sound, volume);
    }
}
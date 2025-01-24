using System.Reflection;
using Raylib_cs;

namespace Game.Util.Resource;

public static class EmbeddedAudio
{
    public static Raylib_cs.Sound? LoadSound(string sampleName)
    {
        var assembly = Assembly.GetExecutingAssembly();
        using var stream = assembly.GetManifestResourceStream(sampleName);
        if (stream == null)
        {
            Raylib.TraceLog(TraceLogLevel.Warning, "Failed to load embedded sample: " + sampleName);
            return null;
        }
        var data = new byte[stream.Length];
        if (stream.Read(data, 0, data.Length) != data.Length) return null;
        var sample = Raylib.LoadSoundFromWave(Raylib.LoadWaveFromMemory(Path.GetExtension(sampleName), data));
        return sample;
    }
    
    private static readonly Dictionary<string, byte[]> MusicData = new();
    
    public static Music? LoadMusic(string sampleName)
    {
        var assembly = Assembly.GetExecutingAssembly();
        if (!MusicData.TryGetValue(sampleName, out var value))
        {
            using var stream = assembly.GetManifestResourceStream(sampleName);
            if (stream == null)
            {
                Raylib.TraceLog(TraceLogLevel.Warning, "Failed to load embedded sample: " + sampleName);
                return null;
            }


            var data = new byte[stream.Length];
            if(stream.Read(data, 0, data.Length) != data.Length) return null;
            value = data;
            MusicData[sampleName] = value;
        }
        var sample = Raylib.LoadMusicStreamFromMemory(Path.GetExtension(sampleName), value);
        sample.Looping = true;
        return sample;
    }
}
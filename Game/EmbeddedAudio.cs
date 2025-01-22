using System.Reflection;
using Raylib_cs;
namespace Game;

public static class EmbeddedAudio
{
    public static Sound? LoadSound(string sampleName)
    {
        var assembly = Assembly.GetExecutingAssembly();
        using (var stream = assembly.GetManifestResourceStream(sampleName))
        {
            if (stream == null)
            {
                Raylib.TraceLog(TraceLogLevel.Warning, "Failed to load embedded sample: " + sampleName);
                return null;
            }
            var data = new byte[stream.Length];
            stream.Read(data, 0, data.Length);
            var sample = Raylib.LoadSoundFromWave(Raylib.LoadWaveFromMemory(Path.GetExtension(sampleName), data));
            return sample;
        }
    }
    
    public static Music? LoadMusic(string sampleName)
    {
        var assembly = Assembly.GetExecutingAssembly();
        using (var stream = assembly.GetManifestResourceStream(sampleName))
        {
            if (stream == null)
            {
                Raylib.TraceLog(TraceLogLevel.Warning, "Failed to load embedded sample: " + sampleName);
                return null;
            }
            var data = new byte[stream.Length];
            stream.Read(data, 0, data.Length);
            var sample = Raylib.LoadMusicStreamFromMemory(Path.GetExtension(sampleName), data);
            return sample;
        }
    }
}
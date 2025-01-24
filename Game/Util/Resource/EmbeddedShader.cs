using System.Reflection;
using Raylib_cs;

namespace Game.Util.Resource;

public static class EmbeddedShader
{
    public static Raylib_cs.Shader? LoadShader(string shaderName)
    {
        var assembly = Assembly.GetExecutingAssembly();
        using var stream = assembly.GetManifestResourceStream(shaderName);
        if (stream == null)
        {
            Raylib.TraceLog(TraceLogLevel.Warning, "Failed to load embedded shader: " + shaderName);
            return null;
        }

        using var reader = new StreamReader(stream);
        var shaderText = reader.ReadToEnd();
        var shader = Raylib.LoadShaderFromMemory(null, shaderText);
        return shader;
    }
}
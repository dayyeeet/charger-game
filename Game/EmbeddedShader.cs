using System.Reflection;
using Raylib_cs;

namespace Game;

public class EmbeddedShader
{
    public static Shader? LoadShader(string shaderName)
    {
        var assembly = Assembly.GetExecutingAssembly();
        using (var stream = assembly.GetManifestResourceStream(shaderName))
        {
            if (stream == null)
            {
                Raylib.TraceLog(TraceLogLevel.Warning, "Failed to load embedded shader: " + shaderName);
                return null;
            }

            using (var reader = new StreamReader(stream))
            {
                var shaderText = reader.ReadToEnd();
                var shader = Raylib.LoadShaderFromMemory(null, shaderText);
                return shader;
            }
        }
    }
}
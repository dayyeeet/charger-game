using System.Reflection;
using Raylib_cs;

namespace Game;

public static class EmbeddedTexture
{
    public static Texture2D? LoadTexture(string textureName)
    {
        var assembly = Assembly.GetExecutingAssembly();
        using (var stream = assembly.GetManifestResourceStream(textureName))
        {
            if (stream == null)
            {
               Raylib.TraceLog(TraceLogLevel.Warning, "Failed to load embedded texture: " + textureName);
                return null;
            }
            var data = new byte[stream.Length];
            stream.Read(data, 0, data.Length);
            var image = Raylib.LoadImageFromMemory(Path.GetExtension(textureName), data);
            var texture = Raylib.LoadTextureFromImage(image);
            Raylib.UnloadImage(image);
            return texture;
        }
    }
}
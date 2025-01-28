using System.Reflection;
using Engine.Scene;
using Engine.Ui.Gui;
using Game.Entity.Player;
using Game.Gun.Projectile;
using Game.Level.One;
using Game.Util.World;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Game.Util.Save;

public class SettingsManager
{
    private const string SaveFilePath = "settings.yaml";

    public static void SaveSettings(Settings settings)
    {
        var serializer = new SerializerBuilder()
            .WithNamingConvention(PascalCaseNamingConvention.Instance).Build();
        var yml = serializer.Serialize(settings);
        if (File.Exists(SaveFilePath)) File.Delete(SaveFilePath);
        File.WriteAllText(SaveFilePath, yml);
    }

    public static void WipeSave()
    {
        if (File.Exists(SaveFilePath)) File.Delete(SaveFilePath);
    }
    
    

    public static Settings LoadSettings()
    {
        if (!File.Exists(SaveFilePath)) return new Settings();
        var deserializer = new DeserializerBuilder().WithNamingConvention(PascalCaseNamingConvention.Instance).Build();
        var content = File.ReadAllText(SaveFilePath);
        return deserializer.Deserialize<Settings>(content);
    }
}
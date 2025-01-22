using System.Reflection;
using Engine;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Game;

public static class SaveManager
{
    private const string SaveFilePath = "savegame.yaml";

    public static void SaveScene(Scene scene)
    {
        var serializer = new SerializerBuilder()
            .WithNamingConvention(PascalCaseNamingConvention.Instance).Build();
        var objects = scene.GetGameObjectsWithLayers().ToList().FindAll(it => it.Key is not (GuiProvider or Projectile))
            .ConvertAll(element => new GameObjectConfigEntry(element.Key, element.Value));
        var yml = serializer.Serialize(objects);
        if (File.Exists(SaveFilePath)) File.Delete(SaveFilePath);
        File.WriteAllText(SaveFilePath, yml);
    }

    public static void WipeSave()
    {
        if (File.Exists(SaveFilePath)) File.Delete(SaveFilePath);
    }

    public static Scene LoadScene()
    {
        if (!File.Exists(SaveFilePath)) return new LevelScene(new LevelOneWorld(1500, 1500));
        var deserializer = new DeserializerBuilder().WithTypeDiscriminatingNodeDeserializer(o =>
            {
                var type = typeof(GameObject);
                var assembly = Assembly.GetExecutingAssembly();
                var subclasses = assembly.GetTypes()
                    .Where(t => type.IsAssignableFrom(t) && t != type && !t.IsAbstract)
                    .ToList();
                var valueMappings =
                    subclasses.ConvertAll(clazz => new KeyValuePair<string, Type>(clazz.FullName!, clazz))
                        .ToDictionary();
                o.AddKeyValueTypeDiscriminator<GameObject>("Type", valueMappings);
            }).WithNamingConvention(PascalCaseNamingConvention.Instance)
            .Build();
        var content = File.ReadAllText(SaveFilePath);
        var objects = deserializer.Deserialize<List<GameObjectConfigEntry>>(content);
        var scene = new Scene();
        var world = objects.First(it => it.Obj is GameWorld);
        var player = objects.First(it => it.Obj is Player);
        scene.Load(world.Obj, world.Layer);
        scene.Load(player.Obj, player.Layer);
        Game.Engine.SetTracking((Player) player.Obj);
        foreach (var saved in objects.Where(it => it.Obj is not (GameWorld or Player)))
        {
            scene.Load(saved.Obj, saved.Layer);
        }

        return scene;
    }
}
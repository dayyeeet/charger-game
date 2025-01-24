using System.Numerics;
using Engine.Scene;
using Engine.Ui.Hud;
using Engine.Util;

namespace Game.Ui.Hud;

public class HudRenderer(int margin = 20) : GameObject("hud-renderer")
{
    private Dictionary<HudPosition, List<HudElement>>
        _hudElements = new(); //Key = Position, List contains Elements in said Positions

    public List<HudElementRegistry> Elements
    {
        get => _hudElements.ToList().ConvertAll(it => new HudElementRegistry { Key = it.Key, Value = it.Value });
        set => _hudElements = value.ToDictionary(it => it.Key, it => it.Value);
    }

    public HudRenderer() : this(20)
    {
    }

    public override void Draw() //loads all Elements into Draw method
    {
        foreach (var hudElement in _hudElements.Values.SelectMany(hudElements => hudElements))
        {
            hudElement.Draw();
        }
    }

    public override void Update() //Calculates element Positions
    {
        foreach (var hudElement in _hudElements.Values.SelectMany(hudElements => hudElements))
        {
            hudElement.Update();
        }

        foreach (var hudElementsKey in _hudElements.Keys)
        {
            var absolutePosition = AbsolutePosition(hudElementsKey.Position);
            var elements = _hudElements[hudElementsKey];
            var currentHeight = 0;

            foreach (var hudElement in elements)
            {
                var x = absolutePosition.X - hudElementsKey.AlignmentX * hudElement.ElementWidth +
                        (margin * hudElementsKey.MarginDirection);
                var y = absolutePosition.Y +
                        (hudElementsKey.AlignmentY * hudElement.ElementHeight + margin + currentHeight) *
                        hudElementsKey.Direction;
                currentHeight += hudElement.ElementHeight + margin;

                hudElement.Position = new Vector2(x, y);
            }
        }
    }

    public override void Load(Scene scene) //Loads Elements into scene
    {
        foreach (var hudElement in _hudElements.Values.SelectMany(hudElements => hudElements))
        {
            scene.Load(hudElement, Layers.HUD);
        }
    }

    private Vector2 AbsolutePosition(Vector2 position) //basically calculates coordinate System according to window size
    {
        var window = Game.Engine.GetWindow();

        return new Vector2(position.X * window.GetWindowWidth(), position.Y * window.GetWindowHeight());
    }

    public void
        RegisterHudElement(HudPosition hudPosition,
            HudElement element) //Adds Elements to List or creates new List and adds Element after
    {
        var presentElements = _hudElements.GetValueOrDefault(hudPosition, []);

        presentElements.Add(element);
        _hudElements[hudPosition] = presentElements;
    }
}
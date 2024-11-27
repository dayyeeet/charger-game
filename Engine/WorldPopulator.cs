using System.Numerics;
using Raylib_cs;

namespace Engine;

public class WorldPopulator(Scene scene)
{
    private readonly List<Rectangle> _occupiedAreas = [];

    public void Populate<T>(int x, int y, int layer) where T : GameObject, IPositionable
    {
        var feature = Activator.CreateInstance<T>();
        Populate(feature, x, y, layer);
    }
    
    public void Populate<T>(T feature, int x, int y, int layer) where T : GameObject, IPositionable
    {
        feature.Position = new Vector2(x, y);
        scene.Load(feature, layer);
    }

    public void Populate<T>(Rectangle bounds, double percentage) where T : WorldFeature
    {
        var xSpace = bounds.Width - bounds.X;
        var ySpace = bounds.Height - bounds.Y;

        // Get the dimensions of the object type
        var sampleObject = Activator.CreateInstance<T>();
        var objectWidth = sampleObject.ElementWidth;
        var objectHeight = sampleObject.ElementHeight;

        // Calculate total possible placements within bounds
        var totalCells = (xSpace / objectWidth) * (ySpace / objectHeight);
        var objectCount = (int)(totalCells * percentage);

        // Track occupied spaces as a list of rectangles
        var random = new Random();

        for (var i = 0; i < objectCount; i++)
        {
            var placed = false;
            var attempts = 0;

            // Try to place the object within bounds
            while (!placed && attempts < 1000)
            {
                attempts++;
                var x = random.Next((int)bounds.X, (int)(bounds.Width - objectWidth + 1));
                var y = random.Next((int)bounds.Y, (int)(bounds.Height - objectHeight + 1));

                var candidateArea = new Rectangle(x, y, objectWidth, objectHeight);

                if (_occupiedAreas.Any(area => RectIntersects.With(area, candidateArea))) continue;
                _occupiedAreas.Add(candidateArea);
                Populate<T>(x, y, sampleObject.Layer);
                placed = true;
            }

            if (!placed) break;
        }
    }
}
using System.Numerics;
using Raylib_cs;

namespace Engine;

public class WorldPopulator(Scene scene)
{
    private readonly List<Rectangle> _occupiedAreas = [];

    public bool Populate<T>(int x, int y, int layer) where T : GameObject, IPositionable, ISizeableObject
    {
        var feature = Activator.CreateInstance<T>();
        return Populate(feature, x, y, layer);
    }
    
    public bool Populate<T>(T feature, int x, int y, int layer) where T : GameObject, IPositionable, ISizeableObject
    {
        var candidateArea = new Rectangle(x, y, feature.ElementWidth, feature.ElementHeight);
        if (_occupiedAreas.Any(area => RectIntersects.With(area, candidateArea))) return false;
        _occupiedAreas.Add(candidateArea);
        feature.Position = new Vector2(x, y);
        scene.Load(feature, layer);
        return true;
    }
    
    public void Populate<T>(Rectangle bounds, double percentage, int layer) where T : GameObject, IPositionable, ISizeableObject
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
                
                if(!Populate<T>(x, y, layer))continue;
                placed = true;
            }

            if (!placed) break;
        }
    }

    public void Populate<T>(Rectangle bounds, double percentage) where T : WorldFeature
    {
       
        var sampleObject = Activator.CreateInstance<T>();
        Populate<T>(bounds, percentage, sampleObject.Layer);
    }
}
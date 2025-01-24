using System.Numerics;

namespace Engine.Ui.Hud;

public static class HudPositions
{
    public static readonly HudPosition TopRight = new(new Vector2(1, 0), 1, -1,1, 0);
    public static readonly HudPosition BottomRight = new(new Vector2(1, 1), -1, -1,1, 1);
    public static readonly HudPosition BottomLeft = new(new Vector2(0, 1), -1, 1, 0, 1);
    public static readonly HudPosition Bottom = new(new Vector2(0.5f, 1), -1, 1, 1f, 1);
    public static readonly HudPosition TopLeft = new(new Vector2(0, 0), 1, 1,0, 0);
    public static readonly HudPosition Center = new(new Vector2(0.5f,0.5f),1, 0,1, 1);
}

public class HudPosition(Vector2 position, int direction, int marginDirection, float alignmentX, float alignmentY)
{
    public HudPosition() : this(Vector2.Zero, 0, 0, 0, 0) { }
    public Vector2 Position { get; set; } = position;
    public int Direction { get; set; } = direction; //tells to stack elements on top/below of each other

    public int MarginDirection { get; set; } = marginDirection; //tells in which direction margin points depending on side
    public float AlignmentX { get; set; } = alignmentX; //tells if element is at the left/right edge of window
    public float AlignmentY { get; set; } = alignmentY; //tells if element is at top/bottom edge of window
    
}
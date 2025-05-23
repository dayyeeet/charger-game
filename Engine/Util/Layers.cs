namespace Engine.Util;

public static class Layers
{
    public const int Background = 0; // Used for background
    public const int Decoration = 1; // Used for Objects without collisions (trash)
    public const int CollisionObject = 2; // Used for Objects with collisions (cars, trash)
    public const int Item = 3; //Used for dropped items
    public const int Entity = 4; //Used for entities
    public const int LeftHand = 5;
    public const int Player = 6; //Used for the Player
    public const int RightHand = 7;

    // ReSharper disable once InconsistentNaming
    public const int HUD = 8; //Used for ingame HUD. ELEMENTS AT OR HIGHER THIS LAYER WILL NOT BE RENDERED 2D

    // ReSharper disable once InconsistentNaming
    public const int UI = 9; //Used for ingame containers (inventory, escape menu, ...)
}
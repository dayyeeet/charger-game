using System;
using System.Numerics;
using Game;
using Raylib_cs;

public class ThrowMilk
{
    private readonly float _fireRate;
    private float _timeSinceLastThrow;
    private readonly float _energyCost;

    public ThrowMilk(float fireRate, float energyCost)
    {
        _fireRate = fireRate;
        _timeSinceLastThrow = 0f;
        _energyCost = energyCost;
    }

    public void Update(float deltaTime)
    {
        _timeSinceLastThrow += deltaTime;
    }

    public bool CanThrow()
    {
        return _timeSinceLastThrow >= 1f / _fireRate;
    }

    public MilkBottleItem? Throw(Vector2 position, Vector2 direction, float energyAvailable)
    {
        if (!CanThrow() || energyAvailable < _energyCost)
            return null;

        _timeSinceLastThrow = 0f;
        Vector2 normalizedDirection = Vector2.Normalize(direction);

        var milkBottle = new MilkBottleItem
        {
            Position = position,
            Direction = normalizedDirection
        };

        return milkBottle;
    }
}
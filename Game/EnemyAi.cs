using System.Numerics;
using Engine;

namespace Game;

public class EnemyAi(float searchRadius, float minDistance, float speed)
{

    private IPositionable? _roamingTarget;

    public Vector2 DefaultBehavior(IPositionable self, IPositionable target, List<EnemyAiRoamingPoint>? roamingPoints = null)
    {
        return Chase(self, target) ?? Roam(self, roamingPoints) ?? self.Position;
    }
    
    public Vector2? MoveToTarget(IPositionable self, IPositionable target)
    {
        var distance = Vector2.Distance(self.Position, target.Position);
        if (distance < minDistance || distance > searchRadius)
        {
            return null;
        }
        return self.Position - (self.Position - target.Position) * speed;
    }
    
    public Vector2? Chase(IPositionable self, IPositionable target)
    {
        var distance = Vector2.Distance(self.Position, target.Position);
        if (distance < minDistance)
        {
            return self.Position;
        }
        if (distance > searchRadius)
        {
            return null;
        }
        return self.Position - (self.Position - target.Position) * speed;
    }

    public Vector2? Roam(IPositionable self, List<EnemyAiRoamingPoint>? targets)
    {
        if (targets == null || targets.Count == 0) return null;
        _roamingTarget ??= targets[new Random().Next(0, targets.Count)];
        var result = MoveToTarget(self, _roamingTarget);
        if (result == null) _roamingTarget = null;
        return result;
    }
}
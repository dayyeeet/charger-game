using System.Numerics;
using System.Xml.Schema;
using Engine;

namespace Game;

public class EnemyAi(float searchRadius, float minDistance, float speed)
{
    private IPositionable? _roamingTarget;

    public void DefaultBehavior<T>(Scene scene, T self, Vector2 lastPosition, ICollidable target, List<EnemyAiRoamingPoint>? roamingPoints = null) where T : GameObject, ICollidable
    {
        self.Position = Chase(self, target) ?? Roam(self, roamingPoints) ?? self.Position;
        CalculatePosition(self, lastPosition, () => scene.CollidesWith(obj => obj != self && !((ICollidable)obj).IsPassThrough() && obj is not Player, self).Count > 0);
    }
    
    private static void CalculatePosition(ICollidable self, Vector2 oldPosition, Func<bool> checkDenied)
    {
        if (!checkDenied()) return;
        var delta = self.Position - oldPosition;
        var preTest = self.Position;
        self.Position -= delta with { Y = 0 };
        if (!checkDenied())
        {
            return;
        }

        self.Position = preTest - delta with { X = 0 };
        if (!checkDenied())
        {
            return;
        }

        self.Position = oldPosition;
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
    
    public Vector2? Chase(IPositionable self, ICollidable target)
    {
        var pos = target.Position + new Vector2(target.ElementWidth / 2, target.ElementHeight / 2);
        var distance = Vector2.Distance(self.Position, pos);
        if (distance < minDistance)
        {
            return self.Position;
        }
        if (distance > searchRadius)
        {
            return null;
        }
        return self.Position - (self.Position - pos) * speed;
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
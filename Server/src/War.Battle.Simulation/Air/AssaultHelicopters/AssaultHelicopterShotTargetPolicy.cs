using System.Numerics;

namespace War.BattleServer;

/// <summary>
/// AssaultHelicopter.StartShooting chooses a separate target for each gun.
/// The first/second whole-body entries preserve GameShootableEntity order.
/// </summary>
internal static class AssaultHelicopterShotTargetPolicy
{
    internal sealed record Choice(DroneShotTarget First, DroneShotTarget Second,
        bool Shield);

    internal static Choice Select(Vector3 helicopterPosition, DroneTargetDetails details,
        bool playerWalking, float shieldProbability, Func<float> nextRandom)
    {
        if (!PlayerHitbox.Finite(helicopterPosition) || details == null ||
            details.Targets == null || details.Targets.Count is < 1 or > 100 ||
            !PlayerHitbox.Finite(details.Root) ||
            !PlayerHitbox.Finite(details.AimForward) ||
            !float.IsFinite(shieldProbability) ||
            shieldProbability is < -1 or > 1 || nextRandom == null ||
            (playerWalking && details.Hiding))
            throw new InvalidDataException("Invalid Assault Helicopter aim authority.");

        var identities = new HashSet<int>();
        foreach (var target in details.Targets)
            if (target == null || target.TransformFileId <= 0 ||
                !identities.Add(target.TransformFileId) ||
                target.Type is < 0 or > 0xFFFFFF ||
                !PlayerHitbox.Finite(target.Position))
                throw new InvalidDataException("Invalid Assault Helicopter shot target.");

        if (!details.IsPlayer)
        {
            var nearest = Nearest(helicopterPosition, details.Targets, 0xFFFFFB);
            return new(nearest, nearest, false);
        }

        bool facingShield = details.Hiding &&
            PlayerAimAngle(details, helicopterPosition) < 50f;
        if (facingShield)
        {
            float sample = nextRandom();
            if (!float.IsFinite(sample) || sample is < 0 or > 1)
                throw new InvalidDataException("Invalid Assault Helicopter shield sample.");
            if (sample < shieldProbability)
            {
                var shield = details.Targets.FirstOrDefault(target => target.Type == 2) ??
                    throw new InvalidDataException("Assault Helicopter shield target is missing.");
                return new(shield, shield, true);
            }
        }

        if (playerWalking)
        {
            var moving = Nearest(helicopterPosition, details.Targets, 16);
            return new(moving, moving, false);
        }

        var wholeBody = details.Targets.Where(target =>
            (target.Type & 9) == target.Type).ToArray();
        if (wholeBody.Length < 2)
            throw new InvalidDataException("Assault Helicopter whole-body pair is missing.");
        if (facingShield)
            return new(wholeBody[1], wholeBody[0], false);

        var nearestBody = Nearest(helicopterPosition, details.Targets, 9);
        return new(nearestBody, nearestBody, false);
    }

    private static float PlayerAimAngle(DroneTargetDetails details, Vector3 helicopterPosition)
    {
        Vector3 towardHelicopter = helicopterPosition - details.Root;
        float lengths = MathF.Sqrt(details.AimForward.LengthSquared() *
            towardHelicopter.LengthSquared());
        if (!float.IsFinite(lengths))
            throw new InvalidDataException("Assault Helicopter player angle overflowed.");
        if (lengths < 1e-15f) return 0;
        float cosine = Math.Clamp(Vector3.Dot(details.AimForward,
            towardHelicopter) / lengths, -1, 1);
        return MathF.Acos(cosine) * 180f / MathF.PI;
    }

    private static DroneShotTarget Nearest(Vector3 origin,
        IReadOnlyList<DroneShotTarget> targets, int mask)
    {
        DroneShotTarget? nearest = null;
        float distance = float.MaxValue;
        foreach (var target in targets)
        {
            if ((target.Type & mask) != target.Type) continue;
            float candidate = Vector3.Distance(origin, target.Position);
            if (!float.IsFinite(candidate))
                throw new InvalidDataException("Assault Helicopter target distance overflowed.");
            if (candidate < distance)
            {
                nearest = target;
                distance = candidate;
            }
        }
        return nearest ?? throw new InvalidDataException(
            "Assault Helicopter target mask has no source target.");
    }
}

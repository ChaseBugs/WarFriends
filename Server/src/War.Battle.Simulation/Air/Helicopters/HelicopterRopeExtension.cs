using System.Numerics;

namespace War.BattleServer;

/// <summary>First three current joint positions, supplied by the host rope simulation.</summary>
internal sealed record HelicopterRopeHead(Vector3 Anchor, Vector3 First, Vector3 Second);

/// <summary>One source extension command; insertion is not a solved physical joint pose.</summary>
internal sealed record HelicopterRopeExtensionResult(Vector3 MovedFirst, Vector3? InsertedPosition);

/// <summary>Prepares the geometry part of Helicopter.Update's QuickRope2.ExtendRope(0.7f) call.</summary>
internal static class HelicopterRopeExtension
{
    private const float SourceVelocity = 0.7f;
    private const float InsertionSpacingMultiplier = 1.5f;
    private const float NormalizeEpsilon = 0.00001f;

    internal static HelicopterRopeExtensionResult Prepare(
        HelicopterRopeHead head, float initialJointDistance, float deltaTime)
    {
        ArgumentNullException.ThrowIfNull(head);
        if (!PlayerHitbox.Finite(head.Anchor) || !PlayerHitbox.Finite(head.First) ||
            !PlayerHitbox.Finite(head.Second) || !float.IsFinite(initialJointDistance) || initialJointDistance <= 0 ||
            !float.IsFinite(deltaTime) || deltaTime < 0)
        {
            throw new InvalidDataException("Invalid host Helicopter rope extension input.");
        }
        Vector3 target = head.First - Normalize(head.Anchor - head.Second);
        Vector3 moved = MoveTowards(head.First, target, deltaTime * SourceVelocity);
        float distance = (moved - head.Anchor).Length();
        // Use the initial measured joint distance, not the requested spline spacing.
        float threshold = initialJointDistance * InsertionSpacingMultiplier;
        if (!float.IsFinite(distance) || !float.IsFinite(threshold))
        {
            throw new InvalidDataException("Helicopter rope extension overflow.");
        }
        Vector3? inserted = null;
        if (distance > threshold)
        {
            // Source inserts at most one joint, even if this step stretched much farther.
            inserted = moved - Normalize(moved - head.Anchor) * initialJointDistance;
        }
        if (!PlayerHitbox.Finite(moved) || inserted is Vector3 position && !PlayerHitbox.Finite(position))
        {
            throw new InvalidDataException("Helicopter rope command produced an invalid position.");
        }
        return new HelicopterRopeExtensionResult(moved, inserted);
    }

    private static Vector3 Normalize(Vector3 direction)
    {
        float length = direction.Length();
        if (!float.IsFinite(length))
        {
            throw new InvalidDataException("Helicopter rope direction overflow.");
        }
        return length > NormalizeEpsilon ? direction / length : Vector3.Zero;
    }

    private static Vector3 MoveTowards(Vector3 current, Vector3 target, float maximumDistance)
    {
        Vector3 difference = target - current;
        float distance = difference.Length();
        if (!float.IsFinite(distance) || !float.IsFinite(maximumDistance))
        {
            throw new InvalidDataException("Helicopter rope movement overflow.");
        }
        return distance <= maximumDistance || distance == 0f
            ? target
            : current + difference / distance * maximumDistance;
    }
}

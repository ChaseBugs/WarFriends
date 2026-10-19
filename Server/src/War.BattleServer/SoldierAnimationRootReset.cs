namespace War.BattleServer;

/// <summary>Restores bound root positions/rotations while retaining scales and all other bones.</summary>
internal static class SoldierAnimationRootReset
{
    private const int MaximumNodes = 1024;
    private const int MaximumTargets = 2;
    internal sealed record Target(int Index, RigLocalTransform Rest);

    internal static RigLocalTransform[] Apply(IReadOnlyList<RigLocalTransform> current, IReadOnlyList<Target> targets)
    {
        ArgumentNullException.ThrowIfNull(current);
        ArgumentNullException.ThrowIfNull(targets);
        if (current.Count is < 1 or > MaximumNodes || targets.Count > MaximumTargets ||
            targets.Any(target => target == null || target.Index < 0 || target.Index >= current.Count) ||
            targets.Select(target => target.Index).Distinct().Count() != targets.Count)
        {
            throw new InvalidDataException("Invalid source root reset bindings.");
        }
        foreach (RigLocalTransform node in current)
        {
            ValidateLocal(node);
        }
        var result = current.ToArray();
        foreach (Target target in targets)
        {
            ValidateLocal(target.Rest);
            // Awake caches position and rotation only; Reset does not restore the old local scale.
            result[target.Index] = new RigLocalTransform(target.Rest.Position, target.Rest.Rotation,
                current[target.Index].Scale);
        }
        return result;
    }

    private static void ValidateLocal(RigLocalTransform transform)
    {
        // Validate each local transform without inventing a parent hierarchy for the supplied skeleton.
        _ = RigLocalPose.Compose(new[] { -1 }, new[] { transform });
    }
}

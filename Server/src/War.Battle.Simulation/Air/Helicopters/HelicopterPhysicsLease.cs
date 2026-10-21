namespace War.BattleServer;

/// <summary>Host entity identity plus a world-local generation, independent of recovered asset/view identities.</summary>
internal readonly record struct HelicopterPhysicsLease(Guid WorldId, ulong EntityId, ulong Generation);

/// <summary>One trusted flight pose required for a complete world render update.</summary>
internal sealed record HelicopterPhysicsRenderInput(
    HelicopterPhysicsLease Lease, HelicopterRopeBodyPose Aircraft,
    float? ExtensionTargetHeight = null, bool HasFailedLandingSample = false);

/// <summary>Copied native state with the global physical birth boundary and local executed counters.</summary>
internal sealed record HelicopterPhysicsMemberSnapshot(HelicopterPhysicsLease Lease, ulong BirthPhysicsStep,
    ulong PhysicsSteps, ulong RenderFrames, bool IsExtending, IReadOnlyList<HelicopterRopeMotionBody> Bodies);

/// <summary>One successful world publication; failed execution never returns a partial roster.</summary>
internal sealed record HelicopterPhysicsWorldSnapshot(ulong PhysicsSteps, ulong RenderFrames,
    ulong NominalPhysicsMilliseconds, IReadOnlyList<HelicopterPhysicsMemberSnapshot> Members);

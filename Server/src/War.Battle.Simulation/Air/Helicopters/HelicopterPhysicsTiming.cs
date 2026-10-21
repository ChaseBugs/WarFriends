namespace War.BattleServer;

/// <summary>Recovered TimeManager.SetupPhysicsTiming modes, selected by host-owned player lifecycle.</summary>
internal enum HelicopterPhysicsMode
{
    Normal,
    Ragdoll
}

/// <summary>Keeps source float simulation deltas distinct from nominal integer clock accounting.</summary>
internal static class HelicopterPhysicsTiming
{
    internal const float NormalSeconds = 0.02f;
    internal const float RagdollSeconds = 0.004f;
    internal const ulong NormalMilliseconds = 20;
    internal const ulong RagdollMilliseconds = 4;

    internal static float Seconds(HelicopterPhysicsMode mode)
    {
        switch (mode)
        {
            case HelicopterPhysicsMode.Normal:
                return NormalSeconds;
            case HelicopterPhysicsMode.Ragdoll:
                return RagdollSeconds;
            default:
                throw new InvalidDataException("Unknown source helicopter physics timing mode.");
        }
    }

    internal static ulong Milliseconds(HelicopterPhysicsMode mode)
    {
        switch (mode)
        {
            case HelicopterPhysicsMode.Normal:
                return NormalMilliseconds;
            case HelicopterPhysicsMode.Ragdoll:
                return RagdollMilliseconds;
            default:
                throw new InvalidDataException("Unknown source helicopter physics timing mode.");
        }
    }
}

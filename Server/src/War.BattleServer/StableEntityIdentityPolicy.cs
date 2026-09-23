namespace War.BattleServer;

public readonly record struct StableEntityIdentity(ulong EntityId, uint Generation);

public static class StableEntityIdentityPolicy
{
    public static StableEntityIdentity Validate(StableEntityIdentity identity)
    {
        if (identity.EntityId == 0 || identity.EntityId > 0x0000FFFFFFFFFFFFUL || identity.Generation == 0)
            throw new InvalidDataException("Invalid stable entity identity.");
        return identity;
    }

    public static bool IsCurrent(StableEntityIdentity expected, StableEntityIdentity observed)
        => expected.EntityId == observed.EntityId && expected.Generation == observed.Generation;
}

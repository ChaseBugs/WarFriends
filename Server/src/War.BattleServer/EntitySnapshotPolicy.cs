using System.Numerics;

namespace War.BattleServer;

public readonly record struct EntitySnapshot(StableEntityIdentity Identity, string OwnerPlayerId,
    Vector3 Position, Quaternion Rotation, ulong ServerTick);

public static class EntitySnapshotPolicy
{
    public static EntitySnapshot Validate(EntitySnapshot snapshot)
    {
        StableEntityIdentityPolicy.Validate(snapshot.Identity);
        if (!Guid.TryParseExact(snapshot.OwnerPlayerId ?? "", "N", out _) ||
            !PlayerHitbox.Finite(snapshot.Position) || !float.IsFinite(snapshot.Rotation.LengthSquared()) ||
            Math.Abs(snapshot.Rotation.LengthSquared() - 1) > .001f || snapshot.ServerTick > 10_000_000)
            throw new InvalidDataException("Invalid entity snapshot.");
        return snapshot;
    }
}

using System.Numerics;

namespace War.BattleServer;

public readonly record struct ExplosionAuthority(ulong EntityId, string OwnerPlayerId,
    Vector3 Origin, float Radius, float Damage, int PelletCount);

public static class ExplosionAuthorityPolicy
{
    public static ExplosionAuthority Validate(ExplosionAuthority explosion)
    {
        if (explosion.EntityId == 0 || !Guid.TryParseExact(explosion.OwnerPlayerId, "N", out _) ||
            !PlayerHitbox.Finite(explosion.Origin) || !float.IsFinite(explosion.Radius) ||
            explosion.Radius <= 0 || explosion.Radius > 100 || !float.IsFinite(explosion.Damage) ||
            explosion.Damage <= 0 || explosion.Damage > 10_000_000 || explosion.PelletCount is < 1 or > 64)
            throw new InvalidDataException("Invalid explosion authority.");
        return explosion;
    }
}

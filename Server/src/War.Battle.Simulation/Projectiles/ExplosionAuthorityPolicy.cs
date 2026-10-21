using System.Numerics;

namespace War.BattleServer;

public static class ExplosionAuthorityPolicy
{
    public static ExplosionAuthority Validate(ExplosionAuthority explosion)
    {
        if (explosion.EntityId == 0 || !War.Shared.CanonicalGuid.IsCanonical(explosion.OwnerPlayerId) ||
            !PlayerHitbox.Finite(explosion.Origin) || !float.IsFinite(explosion.Radius) ||
            explosion.Radius <= 0 || explosion.Radius > 100 || !float.IsFinite(explosion.Damage) ||
            explosion.Damage <= 0 || explosion.Damage > 10_000_000 || explosion.PelletCount is < 1 or > 64)
            throw new InvalidDataException("Invalid explosion authority.");
        return explosion;
    }
}

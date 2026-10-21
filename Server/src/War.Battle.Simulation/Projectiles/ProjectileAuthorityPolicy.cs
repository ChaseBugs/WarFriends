using System.Numerics;

namespace War.BattleServer;

public static class ProjectileAuthorityPolicy
{
    public static ProjectileAuthority Validate(ProjectileAuthority projectile)
    {
        if (projectile.ProjectileId == 0 || !War.Shared.CanonicalGuid.IsCanonical(projectile.OwnerPlayerId) ||
            !PlayerHitbox.Finite(projectile.Origin) || !PlayerHitbox.Finite(projectile.Direction) ||
            projectile.Direction.LengthSquared() < 1e-8f || !float.IsFinite(projectile.Speed) ||
            projectile.Speed <= 0 || projectile.Speed > 500 || projectile.SpawnTick > 10_000_000 ||
            projectile.MaxLifetimeTicks is < 1 or > 30 * MatchManifest.TickRate)
            throw new InvalidDataException("Invalid projectile authority.");
        return projectile with { Direction = Vector3.Normalize(projectile.Direction) };
    }
}

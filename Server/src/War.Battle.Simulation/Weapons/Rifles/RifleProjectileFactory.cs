namespace War.BattleServer;

/// <summary>Keeps runtime projectile construction outside the source-only rifle catalog.</summary>
internal static class RifleProjectileFactory
{
    internal static PreparedProjectile Prepare(this RifleBindingCatalog catalog, RifleStatCatalog stats,
        WeaponStageSelection selection, BulletLaunch launch)
    {
        if (stats.SceneRevision != catalog.SceneRevision || stats.Revision != catalog.StatRevision ||
            !float.IsFinite(launch.CriticalRoll) || launch.CriticalRoll is < 0f or > 1f)
        {
            throw new InvalidDataException("Invalid rifle shot authority.");
        }

        var binding = catalog.Get(selection.SourceId);
        var stage = stats.Get(selection.SourceId, selection.UpgradeIndex);
        float damage = stage.Damage *
            (launch.CriticalRoll < stage.CriticalProbability ? binding.CriticalMultiplier : 1);
        BulletFlight flight = BulletLaunchFactory.Create(launch,
            new BulletFlightDefinition(binding.Speed, binding.CheckDistance, false), binding.ShotOffset);
        var resolvedDamage = new ResolvedPlayerDamage(damage, CombatDamageType.Shot, HasWeapon: true,
            FriendKill: binding.FriendKill, PlayerCoefficient: stage.PlayerDamageRatio,
            PlayerOvertimeCoefficient: stage.OvertimePlayerDamageRatio);
        return new PreparedProjectile(flight, resolvedDamage, selection.SourceId);
    }
}

namespace War.BattleServer;

/// <summary>Builds a mutable pistol flight from immutable source data and one host-authored launch.</summary>
internal static class PistolProjectileFactory
{
    internal static PreparedProjectile Prepare(this PistolCatalog catalog, WeaponStageSelection selection,
        BulletLaunch launch)
    {
        var stage = catalog.Stage(selection.SourceId, selection.UpgradeIndex);
        var binding = catalog.Binding(selection.SourceId);
        BulletLaunchFactory.Validate(launch, "pistol");

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

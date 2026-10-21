namespace War.BattleServer;

/// <summary>Constructs an admitted Minigun shot without giving the immutable catalog runtime state.</summary>
internal static class MinigunProjectileFactory
{
    internal static PreparedProjectile Prepare(this MinigunCatalog catalog, int upgradeIndex, BulletLaunch launch)
    {
        var stage = catalog.Stage(upgradeIndex);
        BulletLaunchFactory.Validate(launch, "minigun");

        var binding = catalog.Binding;
        float damage = stage.Damage *
            (launch.CriticalRoll < stage.CriticalProbability ? binding.CriticalMultiplier : 1);
        BulletFlight flight = BulletLaunchFactory.Create(launch,
            new BulletFlightDefinition(binding.Speed, binding.CheckDistance, false), binding.ShotOffset);
        var resolvedDamage = new ResolvedPlayerDamage(damage, CombatDamageType.Shot, HasWeapon: true,
            FriendKill: binding.FriendKill, PlayerCoefficient: stage.PlayerDamageRatio,
            PlayerOvertimeCoefficient: stage.OvertimePlayerDamageRatio);
        return new PreparedProjectile(flight, resolvedDamage, MinigunCatalog.SourceId);
    }
}

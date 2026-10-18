using System.Numerics;

using War.BattleServer;
using War.Client;
using War.Protocol;

/// <summary>Exercises natural construction, callback, overhead launch and airborne shooter-death cleanup.</summary>
internal static class MortarShootingTests
{
    private const string UnitId = "ID_UNIT-MORTAR";
    private const ulong MaximumTick = 1200;
    private static readonly string OwnerId = new('a', 32);

    internal static int Run(string directory)
    {
        BattleCombatContent content = BattleArmyManifestProjectionTests.LoadContent(directory);
        int checks = 0;
        foreach (var upgrades in new OrdinaryArmyTestHost.UpgradeSelection[]
        {
            new(0, -1, -1), new(13, 26, -1, 1.5f, 2f), new(25, 31, -1, 1f, 0.5f)
        })
        {
            checks += CheckNaturalLaunch(content, upgrades);
        }
        return checks + CheckRepeatedCycle(content);
    }

    private static int CheckRepeatedCycle(BattleCombatContent content)
    {
        MatchEngine host = OrdinaryArmyTestHost.Create(content, UnitId);
        Require(host.Command(OwnerId, new MatchCommand
        {
            CommandId = 3, DeployArmy = new() { OptionIndex = host.ArmyBatch(OwnerId).OptionIndexes.First() }
        }).Code == "army-deploying", "Repeated Mortar fixture rejected deployment.");
        host.Advance(61);
        ulong entityKey = host.ArmyEntityBatch(OwnerId, 0, 0).Entities.Single().EntityKey;
        ArmyMortarRuntime weapon = host.OrdinaryMortarWeapon(entityKey)!;
        MortarShotAttempt? first = null;
        MortarPoint? firstPoint = null;
        bool hasRelocated = false;
        while (!host.Terminal && host.Snapshot().ServerTick < MaximumTick)
        {
            host.Advance(host.Snapshot().ServerTick + 1);
            MortarShotAttempt? current = host.MortarAttempt(entityKey);
            if (first == null && current?.ProjectileId != null)
            {
                first = current;
                firstPoint = host.MortarDestination(entityKey)!;
            }
            if (first == null)
            {
                continue;
            }
            if (host.MortarDestination(entityKey)?.ComponentFileId != firstPoint!.ComponentFileId)
            {
                Require(host.MortarDestinationOccupant(firstPoint.ComponentFileId) == null,
                    "Relocating Mortar retained its previous exclusive point.");
                hasRelocated = true;
            }
            if (current?.ProjectileId != null && current != first)
            {
                return Require(hasRelocated && current.ProjectileId != first.ProjectileId &&
                    current.PreparedTick > first.PreparedTick && host.OrdinaryMortarWeapon(entityKey) == weapon &&
                    host.MortarConstruction(entityKey)!.FirstFireEligibleTick == current.PreparedTick,
                    "Mortar did not move, rebuild and launch a new cycle with preserved weapon authority.");
            }
        }
        throw new InvalidOperationException("Mortar never completed a repeated firing cycle: " +
            host.Snapshot().TerminalReason);
    }

    private static int CheckNaturalLaunch(BattleCombatContent content, OrdinaryArmyTestHost.UpgradeSelection upgrades)
    {
        MatchEngine host = OrdinaryArmyTestHost.CreateUpgraded(content, UnitId, upgrades);
        Require(host.Command(OwnerId, new MatchCommand
        {
            CommandId = 3, DeployArmy = new() { OptionIndex = host.ArmyBatch(OwnerId).OptionIndexes.First() }
        }).Code == "army-deploying", "Mortar launch fixture rejected natural deployment.");
        host.Advance(61);
        ulong entityKey = host.ArmyEntityBatch(OwnerId, 0, 0).Entities.Single().EntityKey;
        MortarShotAttempt? attempt = null;
        while (!host.Terminal && host.Snapshot().ServerTick < MaximumTick && attempt?.ProjectileId == null)
        {
            host.Advance(host.Snapshot().ServerTick + 1);
            attempt = host.MortarAttempt(entityKey);
            if (attempt != null && host.Snapshot().ServerTick < attempt.PollTick)
            {
                Require(host.Snapshot().Projectiles.All(row => row.Kind != "army-mortar"),
                    "Mortar launched before the first gameplay poll after its callback.");
            }
        }
        Require(!host.Terminal && attempt?.ProjectileId != null,
            "Mortar never launched naturally: " + host.Snapshot().TerminalReason);
        MortarShotAttempt shot = attempt!;
        ulong projectileId = shot.ProjectileId!.Value;
        MatchSnapshot snapshot = host.Snapshot();
        BattleProjectileState row = snapshot.Projectiles.Single(projectile => projectile.ProjectileId == projectileId);
        Vector3 origin = shot.Target!.Position + Vector3.UnitY * 5f;
        int checks = Require(shot.CompletedTick == shot.PollTick && shot.CallbackTick == shot.PreparedTick + 9 &&
            shot.PollTick == shot.CallbackTick + 1 && row.Kind == "army-mortar" &&
            row.ArmyUnitId == UnitId && new Vector3(row.X, row.Y, row.Z) == origin &&
            row.VelocityX == 0f && row.VelocityY == 0f && row.VelocityZ == 0f,
            "Natural Mortar launch lost its callback order, frozen target or stationary overhead origin.");
        BattleProjectileRowPolicy.ValidateSnapshot(snapshot);
        ArmyCardRocketRuntime frozen = host.CardRocketLaunchMissile(projectileId) ??
            throw new InvalidOperationException("Mortar did not freeze its current damage setup at launch.");
        ArmyMortarRuntime current = host.OrdinaryMortarWeapon(entityKey)!;
        checks += Require(frozen.DirectDamage == current.DirectDamage &&
            frozen.ExplosionDamage == current.ExplosionDamage &&
            host.MortarDetachedWeapon(entityKey)?.PreparedTick == shot.PreparedTick &&
            host.ConfirmArmyDeath(entityKey, false) && host.MortarAttempt(entityKey) == null &&
            host.MortarDetachedWeapon(entityKey) == null &&
            host.OrdinaryMortarWeapon(entityKey) == null && host.CardRocketLaunchMissile(projectileId) == frozen,
            "Shooter death removed airborne Mortar authority or retained the dead soldier's shot attempt.");
        return checks + CheckImpact(host, projectileId);
    }

    private static int CheckImpact(MatchEngine host, ulong projectileId)
    {
        while (!host.Terminal && host.Snapshot().ServerTick < MaximumTick)
        {
            host.Advance(host.Snapshot().ServerTick + 1);
            if (host.CardRocketImpacts().Any(impact => impact.ProjectileId == projectileId))
            {
                return Require(host.CardRocketLaunchMissile(projectileId) == null,
                    "Completed Mortar impact retained its launch authority.");
            }
        }
        throw new InvalidOperationException("Airborne Mortar did not finish after shooter death: " +
            host.Snapshot().TerminalReason);
    }

    private static int Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
        return 1;
    }
}

using War.BattleServer;
using War.Protocol;

/// <summary>Exercises ordinary Rocket Soldier deployments, owner-bound missiles and natural Corner launches.</summary>
internal static class OrdinaryRocketTests
{
    private const string UnitId = "ID_UNIT-ROCKETSOLDIER";
    private const float BaseSpeed = 3f;
    private const float DirectDamageRatio = 0.1f;
    private const ulong FirstSpawnTick = 61;
    private const ulong MaximumTick = 1800;
    private static readonly string OwnerId = new('a', 32);

    internal static int Run(string directory)
    {
        BattleCombatContent content = BattleArmyManifestProjectionTests.LoadContent(directory);
        int checks = 0;
        foreach (var upgrades in new OrdinaryArmyTestHost.UpgradeSelection[]
        {
            new(0, -1, -1), new(39, 96, -1, 1.5f), new(95, 111, -1)
        })
        {
            checks += CheckDeployment(content, upgrades);
        }

        try
        {
            content.Army.ComposeOrdinaryRocket(0, null, 112, 1f);
            throw new InvalidOperationException("Rocket Soldier accepted an absent source Elite lane.");
        }
        catch (ArgumentOutOfRangeException)
        {
            checks++;
        }

        return checks;
    }

    private static int CheckDeployment(BattleCombatContent content, OrdinaryArmyTestHost.UpgradeSelection upgrades)
    {
        MatchEngine host = OrdinaryArmyTestHost.CreateUpgraded(content, UnitId, upgrades);
        int option = host.ArmyBatch(OwnerId).OptionIndexes.First();
        int checks = Require(host.Command(OwnerId, new MatchCommand
        {
            CommandId = 3, DeployArmy = new() { OptionIndex = option }
        }).Code == "army-deploying", "The ordinary Rocket Soldier deployment was rejected.");
        host.Advance(FirstSpawnTick);
        BattleArmyEntityState entity = host.ArmyEntityBatch(OwnerId, 0, 0).Entities.Single();
        int? special = upgrades.Special >= 0 ? upgrades.Special : null;
        float damage = content.Army.EffectiveDamage(UnitId, upgrades.Normal, special, null, upgrades.DamageScale);
        float speed = special.HasValue
            ? BaseSpeed * (1f + content.Army.ComposeSpecial(UnitId, upgrades.Normal, special, null)) : BaseSpeed;
        var expected = new ArmyCardRocketRuntime(damage * DirectDamageRatio, damage, speed,
            content.Army.PlayerDamagePolicy(UnitId).BehindShieldRatio);
        checks += Require(entity.UnitId == UnitId && entity.SourceCardId.Length == 0 &&
            host.CardRocketMissile(entity.EntityKey) == expected && host.CardRocketWalking(entity.EntityKey),
            $"Ordinary Rocket {upgrades}: setup={host.CardRocketMissile(entity.EntityKey)}, expected={expected}, " +
            $"walking={host.CardRocketWalking(entity.EntityKey)}, terminal={host.Snapshot().TerminalReason}.");
        checks += CheckLaunchAndDeath(host, entity, expected);
        return checks;
    }

    internal static int CheckLaunchAndDeath(MatchEngine host, BattleArmyEntityState spawned,
        ArmyCardRocketRuntime expected)
    {
        ulong launchedId = 0;
        while (!host.Terminal && host.Snapshot().ServerTick < MaximumTick && launchedId == 0)
        {
            host.Advance(host.Snapshot().ServerTick + 1);
            launchedId = host.Snapshot().Projectiles.FirstOrDefault(projectile =>
                projectile.Kind == "card-rocket" && projectile.OwnerPlayerId == OwnerId)?.ProjectileId ?? 0;
        }

        int checks = Require(!host.Terminal && launchedId != 0,
            $"Ordinary Rocket never launched: {host.Snapshot().TerminalReason}, tick {host.Snapshot().ServerTick}.");
        BattleArmyEntityState current = host.ArmyEntityBatch(OwnerId, 0, 0).Entities.Single();
        checks += Require(!host.CardRocketWalking(spawned.EntityKey) &&
            (current.X != spawned.X || current.Z != spawned.Z) &&
            host.CardRocketLaunchMissile(launchedId) == expected,
            "The natural missile launch skipped navigation or ignored owner-bound setup.");
        checks += Require(host.ConfirmArmyDeath(spawned.EntityKey, false) &&
            host.CardRocketMissile(spawned.EntityKey) == null && !host.CardRocketWalking(spawned.EntityKey) &&
            host.CardRocketAttack(spawned.EntityKey) == null && host.CardRocketLaunchMissile(launchedId) == expected,
            "Soldier death must clean live setup while preserving the airborne missile authority.");
        while (!host.Terminal && host.Snapshot().ServerTick < MaximumTick)
        {
            host.Advance(host.Snapshot().ServerTick + 1);
            if (host.CardRocketImpacts().Any(impact => impact.ProjectileId == launchedId))
            {
                return checks + Require(host.CardRocketLaunchMissile(launchedId) == null,
                    "A completed missile retained its launch authority after the shooter died.");
            }
        }

        throw new InvalidOperationException("The ordinary missile did not finish after its shooter died.");
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

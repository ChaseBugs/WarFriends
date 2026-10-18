using War.BattleServer;
using War.Protocol;

/// <summary>
/// Checks ordinary Bazooka contact-only modifiers through source deployment callbacks and actual flights.
/// </summary>
internal static class SicknessOrdinaryRocketTests
{
    private const string UnitId = "ID_UNIT-ROCKETSOLDIER";
    private const float Multiplier = 0.5f;
    private const ulong MaximumSpawnTick = 600;
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

        return checks;
    }

    private static int CheckDeployment(BattleCombatContent content, OrdinaryArmyTestHost.UpgradeSelection upgrades)
    {
        MatchEngine host = OrdinaryArmyTestHost.CreateUpgraded(content, UnitId, upgrades);
        var window = new SicknessSpawnWindow(2, content.Army);
        window.Arm();
        host.ArmyDeploymentStarted += window.DeploymentStarted;
        host.ArmyDeploymentFinished += window.DeploymentFinished;
        int checks = 0;
        BattleArmyEntityState? spawned = null;
        ArmyCardRocketRuntime? expected = null;
        host.SubscribeArmySpawn("ordinary-rocket-sickness-test", key =>
        {
            spawned = host.ArmyEntityBatch(OwnerId, 0, 0).Entities.Single().Clone();
            ArmyCardRocketRuntime before = host.CardRocketMissile(key) ??
                throw new InvalidOperationException("Ordinary Rocket spawn lacks current missile authority.");
            float? baseDamage = host.ArmyDamage(key);
            expected = before with { DirectDamage = before.DirectDamage * Multiplier };
            bool changed = host.ApplySicknessToArmyPrimaryWeapon(key, window);
            checks += Require(changed && host.CardRocketMissile(key) == expected &&
                host.ArmyDamage(key) == baseDamage && host.ArmyHealth(key) == spawned.MaxHealth * Multiplier,
                $"Rocket Sickness {upgrades}: changed={changed}, applying={window.IsApplying}, " +
                $"missile={host.CardRocketMissile(key)}, expected={expected}, " +
                $"health={host.ArmyHealth(key)}/{spawned.MaxHealth}, damage={host.ArmyDamage(key)}/{baseDamage}.");
            checks += Require(host.ArmyEntityBatch(OwnerId, 0, 0).Entities.Single().MaxHealth == spawned.MaxHealth,
                "Sickness changed the ordinary Rocket Soldier's maximum health.");
        });
        checks += Require(host.Command(OwnerId, new MatchCommand
        {
            CommandId = 3, DeployArmy = new() { OptionIndex = host.ArmyBatch(OwnerId).OptionIndexes.First() }
        }).Code == "army-deploying", "The ordinary Sickness Rocket deployment failed.");
        while (!host.Terminal && window.IsArmed && host.Snapshot().ServerTick < MaximumSpawnTick)
        {
            host.Advance(host.Snapshot().ServerTick + 1);
        }

        checks += Require(!host.Terminal && !window.IsArmed && spawned != null && expected != null,
            "The actual Rocket spawn or final deployment callback did not complete.");
        if (spawned == null || expected == null)
        {
            throw new InvalidOperationException("The ordinary Rocket observer did not retain its spawn proof.");
        }

        checks += Require(!host.ApplySicknessToArmyPrimaryWeapon(spawned.EntityKey, window) &&
            host.CardRocketMissile(spawned.EntityKey) == expected,
            "The disconnected Sickness window reapplied or restored current missile damage.");
        checks += OrdinaryRocketTests.CheckLaunchAndDeath(host, spawned, expected);
        host.UnsubscribeArmySpawn("ordinary-rocket-sickness-test");
        host.ArmyDeploymentStarted -= window.DeploymentStarted;
        host.ArmyDeploymentFinished -= window.DeploymentFinished;
        return checks;
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

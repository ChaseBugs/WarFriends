using War.BattleServer;
using War.Protocol;

/// <summary>Checks owner-bound Mortar setup and contact-only Sickness at actual deployment callbacks.</summary>
internal static class OrdinaryMortarTests
{
    private const string UnitId = "ID_UNIT-MORTAR";
    private const ulong MaximumSpawnTick = 600;
    private const float ContactRatio = 0.1f;
    private const float MissileSpeed = 20f;
    private const float BaseShotSpeed = 0.43f;
    private const float SicknessMultiplier = 0.5f;
    private static readonly string OwnerId = new('a', 32);

    internal static int Run(string directory)
    {
        BattleCombatContent content = BattleArmyManifestProjectionTests.LoadContent(directory);
        int checks = CheckInvalidSelections(content.Army);
        foreach (var upgrades in new OrdinaryArmyTestHost.UpgradeSelection[]
        {
            new(0, -1, -1), new(13, 26, -1, 1.5f, 2f), new(25, 31, -1, 1f, 0.5f)
        })
        {
            checks += CheckDeployment(content, upgrades, 1);
            checks += CheckDeployment(content, upgrades, 2);
        }

        return checks;
    }

    private static int CheckDeployment(BattleCombatContent content,
        OrdinaryArmyTestHost.UpgradeSelection upgrades, int sicknessOwnerFraction)
    {
        MatchEngine host = OrdinaryArmyTestHost.CreateUpgraded(content, UnitId, upgrades);
        var window = new SicknessSpawnWindow(sicknessOwnerFraction, content.Army);
        window.Arm();
        host.ArmyDeploymentStarted += window.DeploymentStarted;
        host.ArmyDeploymentFinished += window.DeploymentFinished;
        bool isDeploymentFinished = false;
        host.ArmyDeploymentFinished += (_, _) => isDeploymentFinished = true;
        int checks = 0;
        BattleArmyEntityState? spawned = null;
        ArmyMortarRuntime? expected = null;
        host.SubscribeArmySpawn("ordinary-mortar-test", key =>
        {
            spawned = host.ArmyEntityBatch(OwnerId, 0, 0).Entities.Single().Clone();
            float damage = content.Army.EffectiveDamage(UnitId, upgrades.Normal,
                upgrades.Special >= 0 ? upgrades.Special : null, null, upgrades.DamageScale);
            var before = new ArmyMortarRuntime(damage * ContactRatio, damage, MissileSpeed,
                1f / (BaseShotSpeed * upgrades.ShotSpeedCoefficient),
                content.Army.PlayerDamagePolicy(UnitId).BehindShieldRatio);
            checks += Require(host.OrdinaryMortarWeapon(key) == before && host.ArmyDamage(key) == damage,
                "Mortar setup was not available before the actual spawn observer.");
            bool isAffected = sicknessOwnerFraction != spawned.OwnerFraction;
            expected = isAffected ? before with { DirectDamage = before.DirectDamage * SicknessMultiplier } : before;
            bool isChanged = host.ApplySicknessToArmyPrimaryWeapon(key, window);
            checks += Require(isChanged == isAffected && host.OrdinaryMortarWeapon(key) == expected &&
                host.ArmyDamage(key) == damage, "Mortar Sickness changed explosion or flight authority.");
            float expectedHealth = isAffected ? spawned.MaxHealth * SicknessMultiplier : spawned.Health;
            checks += Require(host.ArmyHealth(key) == expectedHealth &&
                host.ArmyEntityBatch(OwnerId, 0, 0).Entities.Single().MaxHealth == spawned.MaxHealth,
                "Mortar Sickness changed maximum health or affected the friendly deployment.");
        });

        checks += Require(host.Command(OwnerId, new MatchCommand
        {
            CommandId = 3, DeployArmy = new() { OptionIndex = host.ArmyBatch(OwnerId).OptionIndexes.First() }
        }).Code == "army-deploying", "The ordinary Mortar deployment was rejected.");
        while (!host.Terminal && !isDeploymentFinished && host.Snapshot().ServerTick < MaximumSpawnTick)
        {
            host.Advance(host.Snapshot().ServerTick + 1);
        }

        checks += Require(!host.Terminal && isDeploymentFinished && spawned != null && expected != null &&
            window.IsArmed == (sicknessOwnerFraction == 1),
            $"Mortar {upgrades}, fraction {sicknessOwnerFraction}: terminal={host.Snapshot().TerminalReason}, " +
            $"finished={isDeploymentFinished}, spawned={spawned != null}, setup={expected != null}, " +
            $"armed={window.IsArmed}, tick={host.Snapshot().ServerTick}.");
        if (spawned == null || expected == null)
        {
            throw new InvalidOperationException("Mortar spawn observer did not capture its setup.");
        }

        window.Disconnect();
        checks += Require(!host.ApplySicknessToArmyPrimaryWeapon(spawned.EntityKey, window) &&
            host.OrdinaryMortarWeapon(spawned.EntityKey) == expected,
            "The disconnected window changed the current Mortar weapon.");
        checks += Require(host.ConfirmArmyDeath(spawned.EntityKey, false) &&
            host.OrdinaryMortarWeapon(spawned.EntityKey) == null,
            "Ordinary Mortar death retained current weapon authority.");
        host.UnsubscribeArmySpawn("ordinary-mortar-test");
        host.ArmyDeploymentStarted -= window.DeploymentStarted;
        host.ArmyDeploymentFinished -= window.DeploymentFinished;
        return checks;
    }

    private static int CheckInvalidSelections(ArmyDeploymentCatalog catalog)
    {
        int checks = 0;
        foreach (float coefficient in new[] { 0f, -1f, float.NaN, float.PositiveInfinity, 11f, float.Epsilon })
        {
            try
            {
                catalog.ComposeOrdinaryMortar(new(0, null, null, 1f, coefficient));
                throw new InvalidOperationException("Mortar accepted an invalid shot speed coefficient.");
            }
            catch (InvalidDataException)
            {
                checks++;
            }
        }

        try
        {
            catalog.ComposeOrdinaryMortar(new(0, null, 32, 1f, 1f));
            throw new InvalidOperationException("Mortar accepted an absent source Elite lane.");
        }
        catch (ArgumentOutOfRangeException)
        {
            checks++;
        }

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

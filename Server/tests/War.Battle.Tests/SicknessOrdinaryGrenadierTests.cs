using War.BattleServer;
using War.Protocol;

/// <summary>Checks ordinary Grenadier modifiers through real deployment and grenade launches.</summary>
internal static class SicknessOrdinaryGrenadierTests
{
    private const float DamageMultiplier = 0.5f;
    private const ulong MaximumTick = 1800;
    private static readonly string OwnerId = new('a', 32);

    internal static int Run(string directory)
    {
        BattleCombatContent content = BattleArmyManifestProjectionTests.LoadContent(directory);
        RecoveredBattleMap map = content.Maps.Single(candidate =>
            candidate.Source.EndsWith("/Park_Multiplayer.unity", StringComparison.Ordinal));
        int checks = 0;
        foreach (var selection in new (int Normal, int Special, int Elite)[]
        {
            (0, -1, -1), (39, 101, -1), (39, 126, 127)
        })
        {
            checks += CheckDeployment(content, map, selection);
        }

        return checks;
    }

    private static int CheckDeployment(BattleCombatContent content, RecoveredBattleMap map,
        (int Normal, int Special, int Elite) selection)
    {
        MatchEngine host = OrdinaryGrenadierSpawnTests.CreateHost(content, map, selection);
        var window = new SicknessSpawnWindow(2, content.Army);
        window.Arm();
        host.ArmyDeploymentStarted += window.DeploymentStarted;
        host.ArmyDeploymentFinished += window.DeploymentFinished;
        int checks = 0;
        var expectedDamage = new Dictionary<ulong, ArmyGrenadeDamageStats>();
        host.SubscribeArmySpawn("ordinary-grenadier-sickness-test", key =>
        {
            BattleArmyEntityState before = host.ArmyEntityBatch(OwnerId, 0, 0).Entities.Single(entity =>
                entity.EntityKey == key).Clone();
            ArmyGrenadeDamageStats grenade = host.CardGrenadierDamage(key) ??
                throw new InvalidOperationException("Missing ordinary grenade damage.");
            float primary = host.ArmyDamage(key) ?? throw new InvalidOperationException("Missing pistol damage.");
            var setup = host.CardGrenadierThrow(key);
            checks += Require(host.ApplySicknessToArmyPrimaryWeapon(key, window),
                "The opposing ordinary Grenadier did not enter the real deployment window.");
            BattleArmyEntityState after = host.ArmyEntityBatch(OwnerId, 0, 0).Entities.Single(entity =>
                entity.EntityKey == key);
            expectedDamage.Add(key,
                new ArmyGrenadeDamageStats(grenade.Minimum * DamageMultiplier, grenade.Explosion));
            checks += Require(after.MaxHealth == before.MaxHealth && after.Health == before.MaxHealth * DamageMultiplier &&
                host.ArmyDamage(key) == primary * DamageMultiplier &&
                host.CardGrenadierDamage(key) == expectedDamage[key] && host.CardGrenadierThrow(key) == setup,
                "Sickness changed maximum health, explosion damage or grenade setup instead of source damage fields.");
        });
        checks += Require(host.Command(OwnerId, new MatchCommand
        {
            CommandId = 3, DeployArmy = new() { OptionIndex = host.ArmyBatch(OwnerId).OptionIndexes.First() }
        }).Code == "army-deploying", "Ordinary Grenadier deployment failed.");
        bool launched = false;
        while (!host.Terminal && host.Snapshot().ServerTick < MaximumTick && (!launched || window.IsArmed))
        {
            host.Advance(host.Snapshot().ServerTick + 1);
            foreach (var projectile in host.Snapshot().Projectiles)
            {
                if (projectile.Kind != "card-grenadier" || projectile.OwnerPlayerId != OwnerId ||
                    host.CardGrenadierLaunchDamage(projectile.ProjectileId) is not { } actual)
                {
                    continue;
                }

                checks += Require(expectedDamage.Values.All(expected => actual == expected),
                    "A real grenade launch ignored current modified damage.");
                launched = true;
            }
        }

        checks += Require(!host.Terminal && launched && !window.IsArmed && expectedDamage.Count > 0,
            $"Grenadier {selection}: launched={launched}, armed={window.IsArmed}, spawns={expectedDamage.Count}, " +
            $"tick={host.Snapshot().ServerTick}, terminal={host.Snapshot().TerminalReason}.");
        foreach (ulong key in expectedDamage.Keys)
        {
            float? health = host.ArmyHealth(key);
            float? primary = host.ArmyDamage(key);
            checks += Require(!host.ApplySicknessToArmyPrimaryWeapon(key, window) && host.ArmyHealth(key) == health &&
                host.ArmyDamage(key) == primary && host.CardGrenadierDamage(key) == expectedDamage[key],
                "A disconnected window reapplied or restored ordinary Grenadier authority.");
        }

        host.UnsubscribeArmySpawn("ordinary-grenadier-sickness-test");
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

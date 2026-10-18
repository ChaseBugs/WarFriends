using War.BattleServer;
using War.Protocol;
using War.Shared;

/// <summary>Checks source spawn modifiers and actual ordinary Sniper/Minigunner launch damage.</summary>
internal static class SicknessPrimaryWeaponTests
{
    private const ulong StartTick = 60;
    private const ulong MaximumTick = 1800;
    private const int PlayerLevel = 22;
    private const int PlayerHealth = 1000;
    private const int MatchDurationSeconds = 180;
    private const int IdleSeconds = 120;
    private const int AdmissionSeconds = 10;
    private const float Multiplier = 0.5f;
    private const float Tolerance = 0.0001f;
    private static readonly string OwnerId = new('a', 32);
    private static readonly string OpponentId = new('b', 32);

    internal static int Run(string directory)
    {
        BattleCombatContent content = BattleArmyManifestProjectionTests.LoadContent(directory);
        int checks = 0;
        foreach (string unitId in new[] { "ID_UNIT-SNIPER", "ID_UNIT-MINIGUNNER" })
        {
            checks += CheckUnit(content, unitId);
        }

        return checks;
    }

    private static int CheckUnit(BattleCombatContent content, string unitId)
    {
        MatchEngine host = CreateHost(content, unitId);
        var window = new SicknessSpawnWindow(1, content.Army);
        window.Arm();
        host.ArmyDeploymentStarted += window.DeploymentStarted;
        host.ArmyDeploymentFinished += window.DeploymentFinished;
        var spawns = new Dictionary<ulong, SpawnProof>();
        host.SubscribeArmySpawn("sickness-primary-test", key =>
        {
            BattleArmyEntityState entity = host.ArmyEntityBatch(OwnerId, 0, 0).Entities.Single(row =>
                row.EntityKey == key).Clone();
            float damage = host.ArmyDamage(key) ?? throw new InvalidOperationException("Missing source gun damage.");
            bool changed = host.ApplySicknessToArmyPrimaryWeapon(key, window);
            spawns.Add(key, new SpawnProof(entity, damage, changed));
        });
        Deploy(host, OwnerId);
        Deploy(host, OpponentId);
        AdvanceUntil(host, () => !window.IsArmed);
        int checks = CheckSpawns(host, spawns);
        checks += CheckDisconnected(host, window, spawns);
        checks += CheckLaunch(host, spawns, unitId);
        host.UnsubscribeArmySpawn("sickness-primary-test");
        host.ArmyDeploymentStarted -= window.DeploymentStarted;
        host.ArmyDeploymentFinished -= window.DeploymentFinished;
        return checks;
    }

    private static int CheckDisconnected(MatchEngine host, SicknessSpawnWindow window,
        IReadOnlyDictionary<ulong, SpawnProof> spawns)
    {
        int checks = 0;
        foreach (ulong key in spawns.Keys)
        {
            float? damage = host.ArmyDamage(key);
            float? health = host.ArmyHealth(key);
            checks += Require(!host.ApplySicknessToArmyPrimaryWeapon(key, window) &&
                host.ArmyDamage(key) == damage && host.ArmyHealth(key) == health,
                "A disconnected Sickness window reapplied or restored the current gun/vitality state.");
        }

        return checks;
    }

    private static int CheckSpawns(MatchEngine host, IReadOnlyDictionary<ulong, SpawnProof> spawns)
    {
        int checks = Require(spawns.Values.Any(row => row.Changed) && spawns.Values.Any(row => !row.Changed),
            "Both opposing and friendly source spawns must reach the modifier observer.");
        foreach (BattleArmyEntityState entity in host.ArmyEntityBatch(OwnerId, 0, 0).Entities)
        {
            SpawnProof before = spawns[entity.EntityKey];
            bool isEnemy = entity.OwnerPlayerId == OpponentId;
            float factor = isEnemy ? Multiplier : 1f;
            checks += Require(before.Changed == isEnemy && entity.MaxHealth == before.Entity.MaxHealth &&
                entity.Health == before.Entity.MaxHealth * factor &&
                host.ArmyDamage(entity.EntityKey) == before.Damage * factor,
                "Sickness changed a friendly unit, maximum health or the wrong gun damage authority.");
        }

        return checks;
    }

    private static int CheckLaunch(MatchEngine host, IReadOnlyDictionary<ulong, SpawnProof> spawns, string unitId)
    {
        ulong projectileId = 0;
        AdvanceUntil(host, () =>
        {
            projectileId = host.Snapshot().Projectiles.FirstOrDefault(projectile =>
                host.ArmyProjectileSourceEntity(projectile.ProjectileId) is ulong key &&
                spawns.TryGetValue(key, out SpawnProof? spawn) && spawn.Changed)?.ProjectileId ?? 0;
            return projectileId != 0;
        });
        ulong actor = host.ArmyProjectileSourceEntity(projectileId) ??
            throw new InvalidOperationException("The actual shot lost its source soldier.");
        var launch = host.ArmyProjectileLaunch(projectileId) ??
            throw new InvalidOperationException("The actual shot lost its frozen damage.");
        float expected = spawns[actor].Damage * Multiplier;
        int checks = Require(launch.OwnerPlayerId == OpponentId && MathF.Abs(launch.Damage - expected) < Tolerance,
            "The automatic source gun did not launch its changed damage after the Sickness window closed.");
        Console.WriteLine($"PASS: Sickness {unitId} automatic launch damage {launch.Damage}, tick " +
            $"{host.Snapshot().ServerTick}.");
        return checks;
    }

    private static MatchEngine CreateHost(BattleCombatContent content, string unitId)
    {
        RecoveredBattleMap map = content.Maps.Single(candidate =>
            candidate.Source.EndsWith("/Park_Multiplayer.unity", StringComparison.Ordinal));
        var players = new[] { Participant(content, map, (1, unitId)), Participant(content, map, (2, unitId)) };
        var manifest = new MatchManifest("sickness-primary", "native-test", "Park_Multiplayer", map.SourceHash,
            content.Revision, MatchManifest.RifleCombatMode, AdmissionSeconds,
            MatchDurationSeconds, IdleSeconds, players)
        {
            SceneMasterPlayerId = OwnerId
        };
        var host = new MatchEngine(manifest, map, content, armyChoice: _ => 0, combatRandom: () => 1f);
        host.ConfigureBattleAllocations(players.Select(player => new BattleAllocationProjection(player.PlayerId,
            [], [], [0], [-1], [-1])).ToArray());
        foreach (ParticipantManifest player in players)
        {
            host.Admit(player.PlayerId);
            var cards = new SelectCardsCommand();
            cards.NormalUpgradeIndexes.Add(0);
            cards.SpecialUpgradeIndexes.Add(-1);
            cards.EliteUpgradeIndexes.Add(-1);
            Require(host.Command(player.PlayerId, new() { CommandId = 1, SelectCards = cards }).Code ==
                "cards-selected",
                "The primary-weapon fixture could not select its trusted upgrade lanes.");
            Require(host.Command(player.PlayerId, new()
            {
                CommandId = 2, Ready = new() { ManifestHash = host.ManifestHash }
            }).Code == "ready", "The primary-weapon fixture failed readiness.");
        }

        host.Advance(StartTick);
        return host;
    }

    private static ParticipantManifest Participant(BattleCombatContent content, RecoveredBattleMap map,
        (int Fraction, string UnitId) source)
    {
        return new ParticipantManifest(source.Fraction == 1 ? OwnerId : OpponentId,
            content.Stats.CreateManifest("Google2u.AssaultRifle_AK47", 0), source.Fraction,
            map.Covers.First(cover => cover.Main && cover.Fraction == source.Fraction).SourceIndex,
            1f, new PlayerCombatManifest(PlayerHealth), 0, 0, PlayerLevel)
        {
            EquippedArmyUnitIds = [source.UnitId], ArmyNormalUpgradeIndexes = [0],
            ArmySpecialUpgradeIndexes = [-1], ArmyEliteUpgradeIndexes = [-1],
            ArmyHealthFactors = [new ArmyHealthFactors(1f, 1f)], ArmyDamageScales = [1f],
            ArmySpeedCoefficients = [1f], ArmyAccuracyCoefficients = [1f]
        };
    }

    private static void Deploy(MatchEngine host, string playerId)
    {
        Require(host.Command(playerId, new MatchCommand
        {
            CommandId = 3, DeployArmy = new() { OptionIndex = host.ArmyBatch(playerId).OptionIndexes.First() }
        }).Code == "army-deploying", "A primary-weapon source deployment was rejected.");
    }

    private static void AdvanceUntil(MatchEngine host, Func<bool> predicate)
    {
        while (!host.Terminal && host.Snapshot().ServerTick < MaximumTick && !predicate())
        {
            host.Advance(host.Snapshot().ServerTick + 1);
        }

        Require(!host.Terminal && predicate(),
            $"Sickness primary-weapon fixture stopped: {host.Snapshot().TerminalReason}.");
    }

    private static int Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }

        return 1;
    }

    private sealed record SpawnProof(BattleArmyEntityState Entity, float Damage, bool Changed);
}

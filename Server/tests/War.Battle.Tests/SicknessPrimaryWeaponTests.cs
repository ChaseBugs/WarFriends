using War.BattleServer;
using War.Protocol;

/// <summary>Checks source spawn modifiers and actual ordinary gun launch damage.</summary>
internal static class SicknessPrimaryWeaponTests
{
    private const ulong MaximumTick = 1800;
    private const float Multiplier = 0.5f;
    private const float Tolerance = 0.0001f;
    private static readonly string OwnerId = new('a', 32);
    private static readonly string OpponentId = new('b', 32);

    internal static int Run(string directory)
    {
        BattleCombatContent content = BattleArmyManifestProjectionTests.LoadContent(directory);
        int checks = 0;
        foreach (string unitId in new[]
        {
            "ID_UNIT-SNIPER", "ID_UNIT-MINIGUNNER", "ID_UNIT-PARATROOPER", "ID_UNIT-SWAT",
            "ID_UNIT-GUNSLINGER", "ID_UNIT-COMMANDO", "ID_UNIT-SHOTGUNNER", "ID_UNIT-WARPER"
        })
        {
            checks += CheckUnit(content, unitId);
        }

        return checks;
    }

    private static int CheckUnit(BattleCombatContent content, string unitId)
    {
        MatchEngine host = OrdinaryArmyTestHost.Create(content, unitId);
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
        if (unitId == "ID_UNIT-PARATROOPER")
        {
            // The normal parachute descent/fire path is not connected yet. Spawn mutation is valid evidence;
            // claiming an automatic shot here would hide their independent gameplay backlog.
            Console.WriteLine($"PASS: Sickness {unitId} spawn mutation; normal automatic-fire proof remains open.");
        }
        else if (PreservesShotgunRange(unitId))
        {
            checks += CheckShotgunLaunch(content, host, unitId);
        }
        else
        {
            checks += CheckLaunch(host, spawns, unitId);
        }
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
            float damageFactor = PreservesShotgunRange(entity.UnitId) ? 1f : factor;
            checks += Require(before.Changed == isEnemy && entity.MaxHealth == before.Entity.MaxHealth &&
                entity.Health == before.Entity.MaxHealth * factor &&
                host.ArmyDamage(entity.EntityKey) == before.Damage * damageFactor,
                "Sickness changed a friendly unit, maximum health or the wrong gun damage authority.");
        }

        return checks;
    }

    private static bool PreservesShotgunRange(string unitId)
    {
        return unitId is "ID_UNIT-SHOTGUNNER" or "ID_UNIT-WARPER";
    }

    private static int CheckShotgunLaunch(BattleCombatContent content, MatchEngine affected, string unitId)
    {
        MatchEngine baseline = OrdinaryArmyTestHost.Create(content, unitId);
        Deploy(baseline, OwnerId);
        Deploy(baseline, OpponentId);
        float expected = FirstOpposingLaunch(baseline);
        float actual = FirstOpposingLaunch(affected);
        int checks = Require(expected > 0f && actual == expected &&
            baseline.Snapshot().ServerTick == affected.Snapshot().ServerTick,
            "Sickness changed the source ShotGun min/max falloff result or its automatic launch timing.");
        Console.WriteLine($"PASS: Sickness {unitId} preserves actual shotgun launch damage {actual}.");
        return checks;
    }

    private static float FirstOpposingLaunch(MatchEngine host)
    {
        ulong projectileId = 0;
        AdvanceUntil(host, () =>
        {
            projectileId = host.Snapshot().Projectiles.FirstOrDefault(projectile =>
                projectile.OwnerPlayerId == OpponentId && projectile.Kind == "army-bullet")?.ProjectileId ?? 0;
            return projectileId != 0;
        });
        return host.ArmyProjectileLaunch(projectileId)?.Damage ??
            throw new InvalidOperationException("The actual shotgun bullet lost its launch authority.");
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
        if (unitId == "ID_UNIT-COMMANDO")
        {
            checks += CheckNextCommandoRound(host, actor, projectileId, expected);
        }
        return checks;
    }

    private static int CheckNextCommandoRound(MatchEngine host, ulong actor, ulong firstProjectile, float expected)
    {
        ulong nextProjectile = 0;
        AdvanceUntil(host, () =>
        {
            nextProjectile = host.Snapshot().Projectiles.FirstOrDefault(projectile =>
                projectile.ProjectileId > firstProjectile &&
                host.ArmyProjectileSourceEntity(projectile.ProjectileId) == actor)?.ProjectileId ?? 0;
            return nextProjectile != 0;
        });
        float actual = host.ArmyProjectileLaunch(nextProjectile)?.Damage ??
            throw new InvalidOperationException("The next Commando gun lost its source damage.");
        return Require(MathF.Abs(actual - expected) < Tolerance,
            "The same Commando's next alternating-gun round escaped the current Sickness damage.");
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
            $"Sickness primary-weapon fixture stopped: {host.Snapshot().TerminalReason}; " +
            string.Join("; ", host.ArmyEntityBatch(OwnerId, 0, 0).Entities.Select(entity =>
                $"{entity.UnitId}/{entity.EntityKey}: {host.RusherMotionCandidate(entity.EntityKey)?.Phase}, " +
                $"position=({entity.X},{entity.Y},{entity.Z})")));
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

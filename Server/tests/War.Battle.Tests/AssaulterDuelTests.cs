using War.BattleServer;
using War.Protocol;

/// <summary>Follows opposing normal soldiers from automatic targeting through damage and actual death.</summary>
internal static class AssaulterDuelTests
{
    private const ulong MaximumTick = 3000;
    private const float SourceHeadWeight = 1.5f;
    private const float DamageTolerance = 0.001f;
    private static readonly string FirstPlayerId = new('a', 32);
    private static readonly string SecondPlayerId = new('b', 32);

    internal static int Run(BattleCombatContent content)
    {
        RecoveredBattleMap map = content.Maps.Single(candidate =>
            candidate.Source.EndsWith("/Park_Multiplayer.unity", StringComparison.Ordinal));
        MatchEngine host = GrenadierPrimaryDamageTests.CreateRealShotHost(content, map, _ => 0);
        Deploy(host, FirstPlayerId);
        Deploy(host, SecondPlayerId);
        var evidence = new DuelEvidence { Cursor = host.EventBatch(FirstPlayerId, 0).LatestEventId };
        while (!host.Terminal && host.Snapshot().ServerTick < MaximumTick && evidence.DeadEntity == null)
        {
            ObserveTick(host, evidence);
        }

        int checks = evidence.Checks + Require(!host.Terminal && evidence.HasEntityAim && evidence.HasEntityRound &&
            evidence.DamageCount > 0 && evidence.DeadEntity != null,
            "Normal opposing soldiers did not complete an actual entity-targeted damaging volley and kill.");
        checks += CheckDeath(host, evidence);
        Console.WriteLine($"PASS: normal Assaulter duel has {evidence.DamageCount} nonlethal hits " +
            $"and an actual kill at tick {evidence.DeathTick}.");
        return checks;
    }

    private static void ObserveTick(MatchEngine host, DuelEvidence evidence)
    {
        BattleArmyEntityState[] before = Roster(host).Select(entity => entity.Clone()).ToArray();
        RecordFlights(host, evidence);
        host.Advance(host.Snapshot().ServerTick + 1);
        BattleArmyEntityState[] after = Roster(host);
        MatchEventBatch page = host.EventBatch(FirstPlayerId, evidence.Cursor);
        evidence.Cursor = page.LatestEventId;
        MatchEvent[] impacts = page.Events.Where(item => item.Kind == MatchEventKind.Impact &&
            evidence.Launches.ContainsKey(item.ProjectileId)).ToArray();
        foreach (BattleArmyEntityState entity in after)
        {
            evidence.HasEntityAim |= host.AssaulterCallback(entity.EntityKey)?.Prediction.Inputs.BulletSpeed == 15f;
            BattleArmyEntityState? previous = before.SingleOrDefault(row => row.EntityKey == entity.EntityKey);
            if (previous != null && entity.Health < previous.Health)
            {
                evidence.Checks += CheckDamage(entity, previous, impacts, evidence);
            }
        }

        evidence.DeadEntity = before.SingleOrDefault(entity => after.All(row => row.EntityKey != entity.EntityKey));
        if (evidence.DeadEntity != null)
        {
            evidence.DeathTick = host.Snapshot().ServerTick;
            evidence.DeathEvents = page.Events.ToArray();
            evidence.DeathImpacts = impacts;
        }
    }

    private static void RecordFlights(MatchEngine host, DuelEvidence evidence)
    {
        foreach (BattleProjectileState projectile in host.Snapshot().Projectiles)
        {
            if (host.ArmyProjectileLaunch(projectile.ProjectileId) is not { } launch ||
                host.ArmyProjectileSourceEntity(projectile.ProjectileId) is not ulong actor)
            {
                continue;
            }

            evidence.Launches[projectile.ProjectileId] = new LaunchProof(actor, launch.OwnerPlayerId, launch.Damage);
            evidence.HasEntityRound |= host.ArmyProjectileSpeed(projectile.ProjectileId) == 15f;
        }
    }

    private static int CheckDamage(BattleArmyEntityState after, BattleArmyEntityState before,
        MatchEvent[] impacts, DuelEvidence evidence)
    {
        int checks = Require(impacts.Length == 1,
            "The fixed duel must bind each observed health reduction to one physical projectile impact.");
        LaunchProof launch = evidence.Launches[impacts[0].ProjectileId];
        // The pinned infantry head collider has weight 1.5; player/overtime ratios do not apply to units.
        float expected = launch.Damage * SourceHeadWeight;
        float actual = before.Health - after.Health;
        checks += Require(launch.OwnerPlayerId != after.OwnerPlayerId &&
            MathF.Abs(actual - expected) < DamageTolerance,
            "An actual enemy-unit hit lost its frozen weapon damage or source head coefficient.");
        evidence.DamageCount++;
        return checks;
    }

    private static int CheckDeath(MatchEngine host, DuelEvidence evidence)
    {
        BattleArmyEntityState victim = evidence.DeadEntity ??
            throw new InvalidOperationException("The duel produced no authoritative unit death.");
        int checks = Require(evidence.DeathImpacts.Length == 1,
            "The fixed lethal transition must have one physical projectile impact.");
        LaunchProof launch = evidence.Launches[evidence.DeathImpacts[0].ProjectileId];
        checks += Require(launch.OwnerPlayerId != victim.OwnerPlayerId &&
            victim.Health <= launch.Damage * SourceHeadWeight &&
            evidence.DeathEvents.Count(item => item.Kind == MatchEventKind.ArmyDied &&
                item.TargetId == victim.OwnerPlayerId && item.ArmyEntityId == victim.LocalEntityId) == 1,
            "The lethal projectile did not produce one matching source army death.");
        checks += Require(host.AssaulterPoint(victim.EntityKey) == null &&
            host.AssaulterCorner(victim.EntityKey) == null && host.AssaulterAttempt(victim.EntityKey) == null &&
            host.AssaulterCallback(victim.EntityKey) == null,
            "A projectile-killed soldier retained its Corner reservation or shooting state.");
        checks += CheckRetarget(host, launch.Actor, victim);
        return checks;
    }

    private static int CheckRetarget(MatchEngine host, ulong actor, BattleArmyEntityState victim)
    {
        ulong previousAcquisition = host.AssaulterAttempt(actor)?.Aim.AcquisitionTick ?? 0;
        while (!host.Terminal && host.Snapshot().ServerTick < MaximumTick &&
            (host.AssaulterAttempt(actor)?.Aim.AcquisitionTick ?? 0) <= previousAcquisition)
        {
            host.Advance(host.Snapshot().ServerTick + 1);
        }

        AssaulterPreparedAim aim = host.AssaulterAttempt(actor)?.Aim ??
            throw new InvalidOperationException("The surviving shooter never prepared its next target.");
        int checks = Require(!host.Terminal && aim.AcquisitionTick > previousAcquisition && !aim.Target.IsPlayer &&
            aim.Target.EntityId != $"army:{victim.EntityKey}" &&
            Roster(host).Any(entity => entity.OwnerPlayerId == victim.OwnerPlayerId &&
                aim.Target.EntityId == $"army:{entity.EntityKey}"),
            "The next automatic preparation retained a dead opponent instead of selecting a living soldier.");
        return checks;
    }

    private static BattleArmyEntityState[] Roster(MatchEngine host)
    {
        return host.ArmyEntityBatch(FirstPlayerId, 0, 0).Entities.ToArray();
    }

    private static void Deploy(MatchEngine host, string playerId)
    {
        Require(host.Command(playerId, new MatchCommand
        {
            CommandId = 3,
            DeployArmy = new() { OptionIndex = host.ArmyBatch(playerId).OptionIndexes.First() }
        }).Code == "army-deploying", "The duel requires accepted ordinary deployments for both players.");
    }

    private static int Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }

        return 1;
    }

    private sealed record LaunchProof(ulong Actor, string OwnerPlayerId, float Damage);

    private sealed class DuelEvidence
    {
        internal ulong Cursor { get; set; }
        internal bool HasEntityAim { get; set; }
        internal bool HasEntityRound { get; set; }
        internal int DamageCount { get; set; }
        internal int Checks { get; set; }
        internal ulong DeathTick { get; set; }
        internal BattleArmyEntityState? DeadEntity { get; set; }
        internal MatchEvent[] DeathEvents { get; set; } = [];
        internal MatchEvent[] DeathImpacts { get; set; } = [];
        internal Dictionary<ulong, LaunchProof> Launches { get; } = [];
    }
}

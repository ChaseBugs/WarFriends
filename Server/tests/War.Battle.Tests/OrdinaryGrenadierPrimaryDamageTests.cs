using War.BattleServer;
using War.Protocol;

/// <summary>Correlates ordinary pistol launches with actual shield destruction and player health loss.</summary>
internal static class OrdinaryGrenadierPrimaryDamageTests
{
    private const int RandomScale = 1_000_000;
    private const int PrimaryDraw = 400_000;
    private const int BodyDraw = 999_999;
    private const ulong MaximumTick = 3000;
    private const ulong FirstSpawnTick = 61;
    private const float DamageScale = 1.5f;
    private const float Tolerance = 0.001f;
    private static readonly string OwnerId = new('a', 32);
    private static readonly string OpponentId = new('b', 32);

    internal static int Run(BattleCombatContent content)
    {
        int checks = 0;
        foreach (var selection in new (int Normal, int Special, int Elite, ExpectedOutcome Outcome)[]
        {
            (39, 126, 127, ExpectedOutcome.PlayerHit),
            (0, -1, -1, ExpectedOutcome.CoveredShieldOnly)
        })
        {
            RecoveredBattleMap map = content.Maps.Single(candidate =>
                candidate.Source.EndsWith("/Park_Multiplayer.unity", StringComparison.Ordinal));
            MatchEngine? host = null;
            ulong actorKey = 0;
            ulong drawTick = ulong.MaxValue;
            int readyDraws = 0;
            int Draw(int maximum)
            {
                ulong currentTick = host?.Snapshot().ServerTick ?? 0;
                if (currentTick != drawTick)
                {
                    drawTick = currentTick;
                    readyDraws = 0;
                }

                if (maximum != RandomScale || host?.CardGrenadierAttack(actorKey)?.Phase != ArmyRusherAttackPhase.Ready)
                {
                    return 0;
                }

                // Retry ticks choose primary; the next draw requests body targeting when source facing permits it.
                int ordinal = readyDraws++;
                if (ordinal == 0)
                {
                    return PrimaryDraw;
                }

                return ordinal == 1 ? BodyDraw : 0;
            }

            host = OrdinaryGrenadierSpawnTests.CreateHost(content, map,
                (selection.Normal, selection.Special, selection.Elite), new() { ArmyChoice = Draw });
            int option = host.ArmyBatch(OwnerId).OptionIndexes.First();
            Require(host.Command(OwnerId, new MatchCommand
            {
                CommandId = 3, DeployArmy = new() { OptionIndex = option }
            }).Code == "army-deploying", "Ordinary primary deployment failed.");
            host.Advance(FirstSpawnTick);
            actorKey = host.ArmyEntityBatch(OwnerId, 0, 0).Entities.Single().EntityKey;
            float rawDamage = content.Army.EffectiveDamage("ID_UNIT-GRENADIER", selection.Normal,
                selection.Special >= 0 ? selection.Special : null,
                selection.Elite >= 0 ? selection.Elite : null, DamageScale);
            checks += ObserveDamage(host, (actorKey, rawDamage, selection.Outcome), content);
        }

        return checks;
    }

    private static int ObserveDamage(MatchEngine host,
        (ulong ActorKey, float RawDamage, ExpectedOutcome Outcome) fixture, BattleCombatContent content)
    {
        (ulong actorKey, float rawDamage, ExpectedOutcome outcome) = fixture;
        MatchSnapshot initial = host.Snapshot();
        var launches = new Dictionary<ulong, float>();
        var observedEvents = new List<MatchEvent>();
        ulong cursor = 0;
        while (!host.Terminal && host.Snapshot().ServerTick < MaximumTick)
        {
            MatchSnapshot before = host.Snapshot();
            CaptureLaunches(host, before, rawDamage, launches);

            host.Advance(before.ServerTick + 1);
            ReadEvents(host, observedEvents, ref cursor);
            MatchSnapshot after = host.Snapshot();
            float loss = before.Players.Single(player => player.PlayerId == OpponentId).Health -
                after.Players.Single(player => player.PlayerId == OpponentId).Health;
            if (loss <= 0)
            {
                continue;
            }

            Require(outcome == ExpectedOutcome.PlayerHit,
                "The pinned covered basic-unit control unexpectedly changed player health.");
            MatchEvent[] hits = observedEvents.Where(item => item.Tick == after.ServerTick &&
                item.Kind == MatchEventKind.Impact && item.TargetId == OpponentId).ToArray();
            int checks = Require(hits.Length > 0 && hits.All(hit => launches.ContainsKey(hit.ProjectileId)),
                "Health loss must correlate with actual ordinary pistol projectile IDs.");
            float expected = hits.Sum(hit => launches[hit.ProjectileId]) *
                content.Army.PlayerDamagePolicy("ID_UNIT-GRENADIER").PlayerDamageRatio;
            checks += Require(Math.Abs(loss - expected) < Tolerance,
                "Ordinary player health loss differs from captured damage and the source coefficient.");
            checks += CheckShields(initial, observedEvents, launches, content);
            checks += Require(after.Players.Single(player => player.PlayerId == OwnerId).Health ==
                initial.Players.Single(player => player.PlayerId == OwnerId).Health,
                "An ordinary primary shot changed its owner's health control.");
            checks += Require(host.CardGrenadierDamage(actorKey) != null,
                "A primary volley must retain ordinary secondary damage authority.");
            Console.WriteLine($"Ordinary Grenadier pistol: raw {rawDamage}, " +
                $"player loss {loss}, tick {after.ServerTick}.");
            return checks;
        }

        if (outcome == ExpectedOutcome.CoveredShieldOnly)
        {
            MatchSnapshot final = host.Snapshot();
            int checks = Require(!host.Terminal && final.ServerTick == MaximumTick && launches.Count > 0,
                "The covered ordinary control must complete its entire live observation window.");
            checks += CheckShields(initial, observedEvents, launches, content);
            checks += Require(final.Players.Select(player => player.Health)
                .SequenceEqual(initial.Players.Select(player => player.Health)),
                "A shield-only control must preserve both player health values.");
            Console.WriteLine($"Ordinary basic pistol: shields verified through tick {MaximumTick}; " +
                "no player damage in this covered fixture.");
            return checks;
        }

        throw new InvalidOperationException("Ordinary pistol never reached player damage: " +
            $"{host.Snapshot().TerminalReason}; launches={launches.Count}");
    }

    private static void CaptureLaunches(MatchEngine host, MatchSnapshot snapshot, float expectedDamage,
        Dictionary<ulong, float> launches)
    {
        foreach (BattleProjectileState projectile in snapshot.Projectiles.Where(row =>
            row.Kind == "army-bullet" && row.OwnerPlayerId == OwnerId))
        {
            var authority = host.ArmyProjectileLaunch(projectile.ProjectileId) ??
                throw new InvalidOperationException("An ordinary pistol flight lost its launch authority.");
            Require(projectile.ArmySourceCardId.Length == 0 && projectile.ArmyUnitId == "ID_UNIT-GRENADIER" &&
                authority.Damage == expectedDamage,
                "Ordinary pistol damage was replaced by card or unscaled authority.");
            launches.TryAdd(projectile.ProjectileId, authority.Damage);
        }
    }

    private static int CheckShields(MatchSnapshot initial, IReadOnlyList<MatchEvent> events,
        IReadOnlyDictionary<ulong, float> launches, BattleCombatContent content)
    {
        MatchEvent hit = events.First(item => item.Kind == MatchEventKind.ShieldDamaged &&
            item.TargetId == OpponentId && launches.ContainsKey(item.ProjectileId));
        float initialHealth = initial.Shields.Single(shield => shield.CoverIndex == hit.ShieldCoverIndex).Health;
        int checks = Require(Math.Abs(initialHealth - hit.Health -
            launches[hit.ProjectileId] * content.Shields.UnitToShieldCoefficient) < Tolerance,
            "The ordinary pistol shield hit differs from the source UnitToShield coefficient.");
        checks += Require(events.Any(item => item.Kind == MatchEventKind.ShieldDestroyed &&
            item.ShieldCoverIndex == hit.ShieldCoverIndex && launches.ContainsKey(item.ProjectileId)),
            "Shield destruction must refer to an ordinary pistol launch.");
        return checks;
    }

    private static void ReadEvents(MatchEngine host, List<MatchEvent> events, ref ulong cursor)
    {
        while (true)
        {
            MatchEventBatch batch = host.EventBatch(OwnerId, cursor);
            if (batch.Events.Count == 0)
            {
                return;
            }

            events.AddRange(batch.Events);
            cursor = batch.Events[^1].EventId;
            if (cursor == batch.LatestEventId)
            {
                return;
            }
        }
    }

    private static int Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }

        return 1;
    }
    private enum ExpectedOutcome
    {
        PlayerHit,
        CoveredShieldOnly
    }

}

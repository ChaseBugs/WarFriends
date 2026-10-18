using War.BattleServer;
using War.Protocol;

/// <summary>Checks real Grenadier shield/player collisions with normal, overtime and Sickness damage.</summary>
internal static class GrenadierPrimaryDamageTests
{
    private const ulong StartTick = 60;
    private const ulong MaximumScenarioTicks = 3000;
    private const int DurationSeconds = 180;
    private const int OvertimeDurationSeconds = 5;
    private const int PlayerHealth = 1000;
    private const int PlayerLevel = 22;
    private const int RandomScale = 1_000_000;
    private const int PrimaryWeaponDraw = 400_000;
    private const float DamageTolerance = 0.001f;
    private const string CardId = "GREATGRENADIER";
    private static readonly string OwnerId = new('a', 32);
    private static readonly string OpponentId = new('b', 32);

    internal static int Run(string directory)
    {
        BattleCombatContent content = BattleArmyManifestProjectionTests.LoadContent(directory);
        RecoveredBattleMap map = content.Maps.Single(candidate =>
            candidate.Source.EndsWith("/Park_Multiplayer.unity", StringComparison.Ordinal));
        int checks = 0;
        foreach (Scenario scenario in Enum.GetValues<Scenario>())
        {
            MatchEngine host = CreateHost(content, map, scenario);
            DamageObservation observed = ObserveDamage(host, content, scenario);
            checks += CheckDamage(observed, content, scenario);
        }

        return checks;
    }

    private static MatchEngine CreateHost(BattleCombatContent content, RecoveredBattleMap map, Scenario scenario)
    {
        ParticipantManifest owner = CreateParticipant(content, map, 1);
        ParticipantManifest opponent = CreateParticipant(content, map, 2);
        int duration = scenario == Scenario.Overtime ? OvertimeDurationSeconds : DurationSeconds;
        var manifest = new MatchManifest("grenadier-primary-damage", "native-test",
            Path.GetFileNameWithoutExtension(map.Source), map.SourceHash, content.Revision,
            MatchManifest.RifleCombatMode, 10, duration, 120, [owner, opponent])
        {
            SceneMasterPlayerId = OwnerId
        };
        MatchEngine? host = null;
        int readyDraws = 0;
        ulong entityKey = ((ulong)owner.Fraction << 32) | (uint)CardUnitEntityRegistry.FirstLocalEntityId;
        int Draw(int maximum)
        {
            if (maximum != RandomScale || host?.CardGrenadierAttack(entityKey)?.Phase != ArmyRusherAttackPhase.Ready)
            {
                readyDraws = 0;
                return 0;
            }

            // Choose the pistol, then the nearest target, minimum batch and real shots.
            return readyDraws++ == 0 ? PrimaryWeaponDraw : 0;
        }

        host = new MatchEngine(manifest, map, content, armyChoice: Draw, combatRandom: () => 1f);
        SelectAndReady(host);
        if (scenario == Scenario.Overtime)
        {
            ulong overtimeTick = StartTick + OvertimeDurationSeconds * MatchManifest.TickRate;
            for (ulong tick = StartTick + 1; tick <= overtimeTick; tick++)
            {
                host.Advance(tick);
            }
        }

        return host;
    }

    private static ParticipantManifest CreateParticipant(BattleCombatContent content, RecoveredBattleMap map,
        int fraction)
    {
        var weapon = content.Stats.CreateManifest("Google2u.AssaultRifle_AK47", 0);
        CoverNode start = map.Covers.First(cover => cover.Main && cover.Fraction == fraction);
        return new ParticipantManifest(fraction == 1 ? OwnerId : OpponentId, weapon, fraction,
            start.SourceIndex, 1f, new PlayerCombatManifest(PlayerHealth), 0, 0, PlayerLevel)
        {
            EquippedArmyUnitIds = ["ID_UNIT-ASSAULT"],
            ArmyNormalUpgradeIndexes = [0], ArmySpecialUpgradeIndexes = [-1], ArmyEliteUpgradeIndexes = [-1],
            ArmyHealthFactors = [new ArmyHealthFactors(1f, 1f)], ArmyDamageScales = [1f],
            ArmySpeedCoefficients = [1f], ArmyAccuracyCoefficients = [1f]
        };
    }

    private static void SelectAndReady(MatchEngine host)
    {
        host.ConfigureBattleAllocations([
            new(OwnerId, [CardId], [], [0], [-1], [-1]) { CardCounts = [1] },
            new(OpponentId, [], [], [0], [-1], [-1])
        ]);
        foreach (string player in new[] { OwnerId, OpponentId })
        {
            host.Admit(player);
            var cards = new SelectCardsCommand();
            if (player == OwnerId)
            {
                cards.CardIds.Add(CardId);
            }

            cards.NormalUpgradeIndexes.Add(0);
            cards.SpecialUpgradeIndexes.Add(-1);
            cards.EliteUpgradeIndexes.Add(-1);
            Require(host.Command(player, new() { CommandId = 1, SelectCards = cards }).Code == "cards-selected",
                "The damage fixture failed source-card selection.");
            Require(host.Command(player, new()
            {
                CommandId = 2, Ready = new() { ManifestHash = host.ManifestHash }
            }).Code == "ready", "The damage fixture failed readiness.");
        }

        host.Advance(StartTick);
    }

    private static DamageObservation ObserveDamage(MatchEngine host, BattleCombatContent content, Scenario scenario)
    {
        Require(host.Command(OwnerId, new MatchCommand
        {
            CommandId = 3, UseUnitCard = new() { RequestId = new string('c', 32), SourceCardId = CardId }
        }).Code == "unit-card-activated", "The fixture could not activate its selected Grenadier.");
        if (scenario == Scenario.Sickness)
        {
            ApplySpawnSickness(host, content);
        }

        MatchSnapshot before = host.Snapshot();
        var events = new List<MatchEvent>();
        var launches = new Dictionary<ulong, float>();
        ulong cursor = 0;
        while (!host.Terminal && host.Snapshot().ServerTick < MaximumScenarioTicks)
        {
            foreach (var projectile in host.Snapshot().Projectiles.Where(row =>
                row.ArmySourceCardId == CardId && row.Kind == "army-bullet"))
            {
                float damage = host.ArmyProjectileLaunch(projectile.ProjectileId)?.Damage ??
                    throw new InvalidOperationException("A published primary bullet lost its damage authority.");
                launches.TryAdd(projectile.ProjectileId, damage);
            }

            host.Advance(host.Snapshot().ServerTick + 1);
            ReadEvents(host, events, ref cursor);
            MatchSnapshot after = host.Snapshot();
            if (after.Players.Single(player => player.PlayerId == OpponentId).Health <
                before.Players.Single(player => player.PlayerId == OpponentId).Health)
            {
                return new DamageObservation(before, after, events, launches);
            }
        }

        throw new InvalidOperationException("The fixed Park fixture did not reach actual player damage.");
    }

    private static void ApplySpawnSickness(MatchEngine host, BattleCombatContent content)
    {
        int option = content.Army.Families.Single(family => family.UnitId == "ID_UNIT-ASSAULT").Options[0].Index;
        var deployment = new ArmyDeploymentState(content.Army, ["ID_UNIT-ASSAULT"]);
        deployment.SetOffers([option, option, option]);
        deployment.TryDeploy(option, 0);
        var sickness = new SicknessSpawnWindow(2, content.Army);
        sickness.Arm();
        sickness.DeploymentStarted(1, deployment.LastAcceptedWave!);
        ulong entity = host.ArmyEntityBatch(OwnerId, 0, 0).Entities.Single().EntityKey;
        Require(host.ApplySicknessToCardGrenadier(entity, sickness), "The native spawn Sickness binding failed.");
    }

    private static void ReadEvents(MatchEngine host, List<MatchEvent> events, ref ulong cursor)
    {
        while (true)
        {
            MatchEventBatch page = host.EventBatch(OwnerId, cursor);
            if (page.Events.Count == 0)
            {
                return;
            }

            events.AddRange(page.Events);
            cursor = page.Events[^1].EventId;
            if (cursor == page.LatestEventId)
            {
                return;
            }
        }
    }

    private static int CheckDamage(DamageObservation observed, BattleCombatContent content, Scenario scenario)
    {
        float raw = content.Army.CardBaseStats(CardId, PlayerLevel, content.BarrelPolicy.MaxDisplayLevel).Combat.Damage;
        if (scenario == Scenario.Sickness)
        {
            raw *= 0.5f;
        }

        ArmyPlayerDamagePolicy policy = content.Army.PlayerDamagePolicy("ID_UNIT-GRENADIER");
        float coefficient = scenario == Scenario.Overtime ? policy.OvertimePlayerDamageRatio : policy.PlayerDamageRatio;
        MatchEvent[] impacts = observed.Events.Where(item => item.Kind == MatchEventKind.Impact &&
            item.TargetId == OpponentId && item.Tick == observed.After.ServerTick).ToArray();
        int checks = Require(impacts.Length > 0 &&
            impacts.All(item => observed.Launches.ContainsKey(item.ProjectileId)),
            "Player damage did not correlate with a real published primary projectile.");
        checks += Require(impacts.All(item => Math.Abs(observed.Launches[item.ProjectileId] - raw) < DamageTolerance),
            "Actual primary collision used damage outside its source/Sickness setup.");
        float expected = impacts.Sum(item => observed.Launches[item.ProjectileId]) * coefficient;
        float actual = observed.Before.Players.Single(player => player.PlayerId == OpponentId).Health -
            observed.After.Players.Single(player => player.PlayerId == OpponentId).Health;
        checks += Require(Math.Abs(actual - expected) < DamageTolerance,
            "The real primary hit did not apply its source player/overtime coefficient to the weight-one victim.");
        checks += CheckFriendlyControls(observed);
        checks += CheckShields(observed, content, scenario);
        Console.WriteLine($"PASS: Grenadier {scenario} player damage {actual}, expected {expected}, " +
            $"impact tick {observed.After.ServerTick}.");
        return checks;
    }

    private static int CheckFriendlyControls(DamageObservation observed)
    {
        int checks = Require(observed.Before.Players.Single(player => player.PlayerId == OwnerId).Health ==
            observed.After.Players.Single(player => player.PlayerId == OwnerId).Health,
            "A Grenadier primary shot changed its owner's health.");
        var before = observed.Before.Shields.Where(shield => shield.OwnerFraction == 1).Select(shield => shield.Health);
        var after = observed.After.Shields.Where(shield => shield.OwnerFraction == 1).Select(shield => shield.Health);
        return checks + Require(before.SequenceEqual(after), "A primary shot changed a friendly shield control.");
    }

    private static int CheckShields(DamageObservation observed, BattleCombatContent content, Scenario scenario)
    {
        if (scenario == Scenario.Overtime)
        {
            return Require(observed.Before.EndTick == 0 && observed.Before.Shields.All(shield => shield.Destroyed) &&
                observed.Events.Any(item => item.Kind == MatchEventKind.OvertimeStarted),
                "The overtime fixture did not enter overtime through the actual host deadline.");
        }

        MatchEvent hit = observed.Events.First(item => item.Kind == MatchEventKind.ShieldDamaged &&
            item.TargetId == OpponentId && observed.Launches.ContainsKey(item.ProjectileId));
        float initial = observed.Before.Shields.Single(shield => shield.CoverIndex == hit.ShieldCoverIndex).Health;
        float expected = observed.Launches[hit.ProjectileId] * content.Shields.UnitToShieldCoefficient;
        int checks = Require(Math.Abs(initial - hit.Health - expected) < DamageTolerance,
            "Actual shield damage did not use the source UnitToShield coefficient.");
        checks += Require(observed.Events.Any(item => item.Kind == MatchEventKind.ShieldDestroyed &&
            item.ShieldCoverIndex == hit.ShieldCoverIndex && observed.Launches.ContainsKey(item.ProjectileId)),
            "The primary volley did not destroy its shield through real projectile collisions.");
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

    private enum Scenario { Normal, Overtime, Sickness }

    private sealed record DamageObservation(MatchSnapshot Before, MatchSnapshot After,
        IReadOnlyList<MatchEvent> Events, IReadOnlyDictionary<ulong, float> Launches);
}

using System.Numerics;
using War.BattleServer;
using War.Protocol;

// A grenade-equipped player must not disable the Drone's source-owned
// target selection, autonomous projectile flight, or scene visibility.
internal static class GrenadeDroneTests
{
    private const ulong FinalTick = 900;
    private const ulong ProbeProjectileId = 1_000_000;
    private const ulong ProbeLifetimeTicks = 100;
    private const ulong RevengeWindowTicks = 5 * MatchManifest.TickRate;
    private const float ProbeHeight = 2f;
    private const int SabotageRevengeScore = 56;

    private static readonly string DefenderId = new('a', 32);
    private static readonly string OwnerId = new('b', 32);

    internal static int Run(string directory)
    {
        BattleCombatContent content = BattleCombatContent.Load(
            Path.Combine(directory, "combat-content-manifest.json"),
            grenadeManifestPath: Path.Combine(directory, "grenade-content-manifest.json"));
        RecoveredBattleMap map = content.Maps.Single(scene =>
            scene.Source.EndsWith("Park_Multiplayer.unity", StringComparison.Ordinal));
        MatchManifest manifest = CreateManifest(content, map);
        content.ValidateAllocation(manifest);
        var match = new MatchEngine(manifest, map, content,
            armyChoice: _ => 0, combatRandom: () => 0f);
        int checks = 0;

        StartMatch(match, ref checks);
        Check(match.DroneCanSee(new Vector3(0, 100, 0), new Vector3(0, 100.5f, 0)),
            "Zero-direction Drone sight retains Unity's no-hit behavior.", ref checks);
        Check(match.DroneCanSee(new Vector3(0, 100, 0), new Vector3(0, 100.5f, 10)),
            "Drone sight reaches a clear elevated target in grenade mode.", ref checks);
        VerifyAutomaticFlight(match, content, ref checks);
        VerifyControlledPlayerImpact(match, content, ref checks);

        Console.WriteLine($"PASS: {checks} grenade-mode Drone assertions");
        return checks;
    }

    private static void VerifyControlledPlayerImpact(
        MatchEngine match, BattleCombatContent content, ref int checks)
    {
        BattleArmyEntityState drone = match.ArmyEntityBatch(OwnerId, 0, 0).Entities.Single();
        DroneProjectileIntent intent = match.LastDroneIntent(drone.EntityKey) ??
            throw new Exception("The deployed Drone has no trusted launch intent.");
        BulletImpact impact = ResolveControlledPlayerCollision(match, content, intent, ref checks);
        float healthBefore = match.Snapshot().Players.Single(player => player.PlayerId == DefenderId).Health;

        match.ApplyDroneProjectileImpact(new MatchEngine.DroneHostImpact(drone.EntityKey, intent, impact));

        Check(match.Snapshot().Players.Single(player => player.PlayerId == DefenderId).Health < healthBefore,
            "A confirmed Drone player collision applies its launch-time damage policy.", ref checks);
        Check(match.ArmyRevengeExpiry(drone.EntityKey, DefenderId) == impact.Tick + RevengeWindowTicks,
            "The damaging Drone receives the victim's source revenge window.", ref checks);
        Check(match.Snapshot().Players.Single(player => player.PlayerId == OwnerId).ConfirmedPlayerBulletHits == 0,
            "Drone damage does not become player-owned bullet credit.", ref checks);
        VerifyFakeImpactRejected(match, intent, impact, ref checks);
        VerifyDeadSourceImpact(match, content, intent, ref checks);
        VerifyTerminalRevenge(match, ref checks);
    }

    private static void VerifyDeadSourceImpact(MatchEngine match,
        BattleCombatContent content, DroneProjectileIntent intent, ref int checks)
    {
        SabotageTargetPolicy.Candidate drone = match.SabotageMechanicalCandidates().Single();
        VerifySabotageRevenge(match, ref checks);
        BulletImpact impact = ResolveControlledPlayerCollision(match, content, intent, ref checks);
        float healthBefore = match.Snapshot().Players.Single(player => player.PlayerId == DefenderId).Health;

        match.ApplyDroneProjectileImpact(new MatchEngine.DroneHostImpact(drone.EntityId, intent, impact));

        Check(match.Snapshot().Players.Single(player => player.PlayerId == DefenderId).Health < healthBefore &&
            match.ArmyRevengeExpiry(drone.EntityId, DefenderId) == null,
            "A retired Drone's captured damage intent cannot revive its revenge window.", ref checks);
    }

    private static void VerifySabotageRevenge(MatchEngine match, ref int checks)
    {
        string requestId = new('d', 32);
        MatchCommand Command(ulong commandId) => new()
        {
            CommandId = commandId,
            UseSabotage = new UseSabotageCommand { RequestId = requestId }
        };
        Check(match.Command(DefenderId, Command(3)).Code == "sabotage-applied",
            "The damaged player spends a selected Sabotage card to kill the marked Drone.", ref checks);
        PvpOwnerScoreSnapshot score = match.BonusProgress.ScoreSnapshot(DefenderId);
        Check(score.Score == SabotageRevengeScore &&
            match.Snapshot().Players.Single(player => player.PlayerId == DefenderId).Score == SabotageRevengeScore &&
            score.Counts[PvpArmyKillSkillShotPolicy.RevengeKill] == 1,
            "Sabotage adds the Drone's source revenge flag to its base one-hit kill score.", ref checks);
        Check(match.Command(DefenderId, Command(4)).Code == "sabotage-applied" &&
            match.BonusProgress.ScoreSnapshot(DefenderId).Score == SabotageRevengeScore,
            "Replaying the Sabotage request cannot award revenge twice.", ref checks);
    }

    private static void VerifyTerminalRevenge(MatchEngine match, ref int checks)
    {
        match.Command(DefenderId, new MatchCommand
        {
            CommandId = 5,
            Forfeit = new ForfeitCommand()
        });
        checks += BattleScoreSnapshotTests.VerifyTerminal(match, DefenderId);
        Check(match.TerminalEvidenceSnapshot().Players.Single(player =>
            player.PlayerId == DefenderId).ConfirmedSkillShotCounts.Single(row =>
                row.Flag == PvpArmyKillSkillShotPolicy.RevengeKill).Count == 1,
            "Private terminal evidence retains one confirmed Drone revenge kill.", ref checks);
    }

    private static void VerifyFakeImpactRejected(MatchEngine match,
        DroneProjectileIntent intent, BulletImpact impact, ref int checks)
    {
        DroneProjectileIntent fake = intent with
        {
            Shot = intent.Shot with { Batch = intent.Shot.Batch with { IsFake = true } }
        };
        float healthBefore = match.Snapshot().Players.Single(player => player.PlayerId == DefenderId).Health;
        bool isRejected = false;
        try
        {
            ulong entityKey = match.ArmyEntityBatch(OwnerId, 0, 0).Entities.Single().EntityKey;
            match.ApplyDroneProjectileImpact(new MatchEngine.DroneHostImpact(entityKey, fake, impact));
        }
        catch (InvalidDataException)
        {
            isRejected = true;
        }

        Check(isRejected &&
            match.Snapshot().Players.Single(player => player.PlayerId == DefenderId).Health == healthBefore,
            "A fake Drone round cannot reuse a real collision as damage authority.", ref checks);
    }

    private static BulletImpact ResolveControlledPlayerCollision(
        MatchEngine match, BattleCombatContent content, DroneProjectileIntent intent, ref int checks)
    {
        Vector3 head = match.ArmyPlayerCollision(DefenderId).Parts.Single(part =>
            part.Kind == PlayerHitboxKind.Sphere).Center;
        ulong launchTick = match.Snapshot().ServerTick;
        // Isolate impact ownership with a real host ray into the current posed head.
        // This origin is controlled; it does not prove a natural Drone muzzle hit.
        var flight = new BulletFlight(ProbeProjectileId + launchTick, OwnerId,
            new BulletFlightDefinition(intent.Speed, intent.CheckDistance, false),
            head + Vector3.UnitY * ProbeHeight, head, launchTick,
            (origin, direction, range) => match.TraceHeavyTurretShot(OwnerId,
                origin, direction, range, content.Bindings.BulletMask(2)));
        BulletImpact? impact = null;
        for (ulong tick = launchTick + 1;
            tick <= launchTick + ProbeLifetimeTicks && impact == null; tick++)
        {
            match.Advance(tick);
            impact = flight.Advance(tick);
        }

        Check(impact?.Hit.PlayerId == DefenderId,
            "The controlled projectile resolves a real posed-player collision.", ref checks);
        return impact!;
    }

    private static void StartMatch(MatchEngine match, ref int checks)
    {
        match.ConfigureBattleAllocations([
            new(DefenderId, ["SABOTAGE"], [], [0], [-1], [-1]),
            new(OwnerId, ["SABOTAGE"], [], [0], [-1], [-1])
        ]);
        foreach (string playerId in new[] { DefenderId, OwnerId })
        {
            match.Admit(playerId);
            SelectSabotage(match, playerId, ref checks);
            match.Command(playerId, new MatchCommand
            {
                CommandId = 2,
                Ready = new ReadyCommand { ManifestHash = match.ManifestHash }
            });
        }

        match.Advance(60);
        int option = match.ArmyBatch(OwnerId).OptionIndexes.First();
        Check(match.Command(OwnerId, new MatchCommand
        {
            CommandId = 3,
            DeployArmy = new DeployArmyCommand { OptionIndex = option }
        }).Code == "army-deploying", "Grenade match deploys the recovered Drone.", ref checks);
    }

    private static void SelectSabotage(MatchEngine match, string playerId, ref int checks)
    {
        Check(match.Command(playerId, new MatchCommand
        {
            CommandId = 1,
            SelectCards = new SelectCardsCommand
            {
                CardIds = { "SABOTAGE" },
                NormalUpgradeIndexes = { 0 },
                SpecialUpgradeIndexes = { -1 },
                EliteUpgradeIndexes = { -1 }
            }
        }).Code == "cards-selected", "Participant selects its source-bound Sabotage card.", ref checks);
    }

    private static void VerifyAutomaticFlight(
        MatchEngine match, BattleCombatContent content, ref int checks)
    {
        ulong cursor = match.EventBatch(OwnerId, 0).LatestEventId;
        var realShots = new HashSet<ulong>();
        int impacts = 0;
        for (ulong tick = 61; tick <= FinalTick && !match.Terminal; tick++)
        {
            match.Advance(tick);
            MatchEventBatch page = match.EventBatch(OwnerId, cursor);
            foreach (MatchEvent battleEvent in page.Events)
            {
                if (battleEvent.Kind == MatchEventKind.DroneFired &&
                    battleEvent.DroneShot is { Fake: false, Speed: > 0 })
                {
                    realShots.Add(battleEvent.ProjectileId);
                }

                if (battleEvent.Kind == MatchEventKind.Impact &&
                    battleEvent.Reason == "drone" && realShots.Contains(battleEvent.ProjectileId))
                {
                    impacts++;
                }
            }

            cursor = page.LatestEventId;
        }

        Check(!match.Terminal, "Drone combat preserves valid grenade-match authority.", ref checks);
        Check(realShots.Count > 0, "Drone automatically launches real source-bound rounds.", ref checks);
        Check(impacts > 0, "A real Drone round reaches host collision dispatch.", ref checks);
        VerifyLiveDroneState(match, content, ref checks);
    }

    private static void VerifyLiveDroneState(
        MatchEngine match, BattleCombatContent content, ref int checks)
    {
        BattleArmyEntityState drone = match.ArmyEntityBatch(OwnerId, 0, 0).Entities.Single();
        DroneProjectileIntent? intent = match.LastDroneIntent(drone.EntityKey);
        ArmyPlayerDamagePolicy policy = content.Army.PlayerDamagePolicy("ID_UNIT-DRONE");
        Check(intent != null && intent.PlayerDamageCoefficient == policy.PlayerDamageRatio &&
            intent.PlayerOvertimeDamageCoefficient == policy.OvertimePlayerDamageRatio,
            "Drone rounds retain recovered player-damage coefficients in grenade mode.", ref checks);
        Vector3 defenderRoot = match.DroneTargetSnapshot().Single(target =>
            target.Id == "player:" + DefenderId).Position;
        Check(match.DroneLookTarget(drone.EntityKey) == defenderRoot,
            "Drone selects the opposing player from the source target registry.", ref checks);

        DynamicShotTarget body = match.GroundVehicleShotTargets(DefenderId).First(target =>
            target.EntityId == drone.EntityKey && target.DroneRoot);
        Vector3 center = body.Hitbox.Center;
        Check(!match.DroneCanSee(center - Vector3.UnitX * 2 - Vector3.UnitY * .5f,
            center + Vector3.UnitX * 2),
            "The live Drone's destroyable body blocks source sight rays.", ref checks);
    }

    private static MatchManifest CreateManifest(BattleCombatContent content, RecoveredBattleMap map)
    {
        WeaponManifest weapon = content.Grenades!.CreateManifest("Google2u.GrenadeLauncher_M320", 0);
        ParticipantManifest Participant(string playerId, int fraction, string unitId) =>
            new(playerId, weapon, fraction, map.Covers.First(cover =>
                cover.Main && cover.Fraction == fraction).SourceIndex, 1, new(100000), 0)
            {
                PlayerLevel = 8,
                EquippedArmyUnitIds = [unitId],
                ArmyNormalUpgradeIndexes = [0],
                ArmySpecialUpgradeIndexes = [-1],
                ArmyEliteUpgradeIndexes = [-1],
                ArmyHealthFactors = [new ArmyHealthFactors(1, 1)],
                ArmyDamageScales = [1],
                ArmySpeedCoefficients = [1],
                ArmyAccuracyCoefficients = [1]
            };

        return new MatchManifest("grenade-drone-flight", "local-1", "Park_Multiplayer",
            map.SourceHash, content.GrenadeRevision!, MatchManifest.GrenadeCombatMode, 10, 60, 120,
            [Participant(DefenderId, 1, "ID_UNIT-ASSAULT"), Participant(OwnerId, 2, "ID_UNIT-DRONE")])
        {
            SceneMasterPlayerId = DefenderId
        };
    }

    private static void Check(bool condition, string message, ref int checks)
    {
        if (!condition)
        {
            throw new Exception($"FAIL: {message}");
        }

        checks++;
    }
}

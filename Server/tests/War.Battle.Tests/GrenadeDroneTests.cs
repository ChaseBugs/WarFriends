using System.Numerics;
using War.BattleServer;
using War.Protocol;

// A grenade-equipped player must not disable the Drone's source-owned
// target selection, autonomous projectile flight, or scene visibility.
internal static class GrenadeDroneTests
{
    private const ulong FinalTick = 900;
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

        Console.WriteLine($"PASS: {checks} grenade-mode Drone assertions");
        return checks;
    }

    private static void StartMatch(MatchEngine match, ref int checks)
    {
        foreach (string playerId in new[] { DefenderId, OwnerId })
        {
            match.Admit(playerId);
            match.Command(playerId, new MatchCommand
            {
                CommandId = 1,
                Ready = new ReadyCommand { ManifestHash = match.ManifestHash }
            });
        }

        match.Advance(60);
        int option = match.ArmyBatch(OwnerId).OptionIndexes.First();
        Check(match.Command(OwnerId, new MatchCommand
        {
            CommandId = 2,
            DeployArmy = new DeployArmyCommand { OptionIndex = option }
        }).Code == "army-deploying", "Grenade match deploys the recovered Drone.", ref checks);
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

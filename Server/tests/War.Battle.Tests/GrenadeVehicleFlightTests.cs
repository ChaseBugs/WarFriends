using System.Numerics;
using War.BattleServer;
using War.Protocol;

// Verify that grenade-equipped matches use recovered vehicle muzzles and
// current scene collisions for authenticated Humvee and Transporter attacks.
internal static class GrenadeVehicleFlightTests
{
    private static readonly string DefenderId = new('a', 32);
    private static readonly string VehicleOwnerId = new('b', 32);

    internal static int Run(string directory)
    {
        BattleCombatContent content = BattleCombatContent.Load(
            Path.Combine(directory, "combat-content-manifest.json"),
            grenadeManifestPath: Path.Combine(directory, "grenade-content-manifest.json"));
        RecoveredBattleMap map = content.Maps.Single(scene =>
            scene.Source.Contains("City_Multiplayer", StringComparison.Ordinal));

        int checks = 0;
        VerifyHumveeFlight(content, map, ref checks);
        VerifyTransporterFlight(content, map, ref checks);
        VerifyMovingTargetsAcrossScenes(content, ref checks);

        Console.WriteLine($"PASS: {checks} grenade-mode vehicle flight assertions");
        return checks;
    }

    private static void VerifyMovingTargetsAcrossScenes(
        BattleCombatContent content, ref int checks)
    {
        foreach (RecoveredBattleMap map in content.Maps)
        {
            foreach (string unitId in new[] { "ID_UNIT-HUMVEE", "ID_UNIT-TRANSPORTER" })
            {
                var (match, vehicle, tick) = PrepareVehicle(content, map, unitId, ref checks);
                var move = match.Command(DefenderId, new MatchCommand
                {
                    CommandId = 2,
                    MoveCover = new MoveCoverCommand { Direction = 1 }
                });
                Check(move.Code == "moving", "Defender changes cover during vehicle fire.", ref checks);
                StartAttack(match, vehicle, ref checks);
                while (tick < 1100 && !match.Terminal)
                {
                    match.Advance(++tick);
                }

                BattlePlayerState defender = match.Snapshot().Players.Single(player =>
                    player.PlayerId == DefenderId);
                Check(defender.Health == defender.MaxHealth,
                    $"{unitId} cannot invent player damage behind {map.Source} cover.", ref checks);
            }
        }
    }

    private static (MatchEngine Match, BattleArmyEntityState Vehicle, ulong Tick)
        PrepareVehicle(BattleCombatContent content, RecoveredBattleMap map,
            string unitId, ref int checks)
    {
        MatchManifest manifest = CreateManifest(content, map, unitId);
        content.ValidateAllocation(manifest);

        var match = new MatchEngine(manifest, map, content,
            armyChoice: _ => 0, combatRandom: () => 0f);
        match.Admit(DefenderId);
        match.Admit(VehicleOwnerId);
        foreach (string playerId in new[] { DefenderId, VehicleOwnerId })
        {
            match.Command(playerId, new MatchCommand
            {
                CommandId = 1,
                Ready = new ReadyCommand { ManifestHash = match.ManifestHash }
            });
        }

        match.Advance(60);
        int vehicleOption = match.ArmyBatch(VehicleOwnerId).OptionIndexes.First();
        Check(match.Command(VehicleOwnerId, new MatchCommand
        {
            CommandId = 2,
            DeployArmy = new DeployArmyCommand { OptionIndex = vehicleOption }
        }).Code == "army-deploying", $"Grenade match deploys source {unitId}.", ref checks);

        ulong tick = 60;
        BattleArmyEntityState? vehicle = null;
        while (tick < 900 && !match.Terminal)
        {
            match.Advance(++tick);
            vehicle = match.ArmyEntityBatch(DefenderId, 0, 0).Entities
                .SingleOrDefault(entity => entity.UnitId == unitId);
            if (vehicle != null &&
                match.GroundVehicleAttack(vehicle.EntityKey)?.Phase == ArmyAirAttackPhase.Ready)
            {
                break;
            }
        }

        Check(vehicle != null && tick < 900,
            $"Source {unitId} reaches its ready attack state.", ref checks);
        return (match, vehicle!, tick);
    }

    private static MatchManifest CreateManifest(
        BattleCombatContent content, RecoveredBattleMap map, string unitId)
    {
        WeaponManifest weapon = content.Grenades!.CreateManifest(
            "Google2u.GrenadeLauncher_M320", 0);
        CoverNode defenderCover = map.Covers.First(cover => cover.Main && cover.Fraction == 1);
        CoverNode ownerCover = map.Covers.First(cover => cover.Main && cover.Fraction == 2);
        return new MatchManifest(
            $"grenade-{unitId.ToLowerInvariant()}-source-flight", "local-1",
            Path.GetFileNameWithoutExtension(map.Source), map.SourceHash,
            content.GrenadeRevision!, MatchManifest.GrenadeCombatMode, 10, 60, 120,
            [
                new(DefenderId, weapon, 1, defenderCover.SourceIndex, 1, new(1000), 0)
                {
                    PlayerLevel = 8,
                    EquippedArmyUnitIds = ["ID_UNIT-ASSAULT"],
                    ArmyNormalUpgradeIndexes = [0],
                    ArmySpecialUpgradeIndexes = [-1],
                    ArmyEliteUpgradeIndexes = [-1],
                    ArmyHealthFactors = [new ArmyHealthFactors(1, 1)],
                    ArmyDamageScales = [1],
                    ArmySpeedCoefficients = [1],
                    ArmyAccuracyCoefficients = [1]
                },
                new(VehicleOwnerId, weapon, 2, ownerCover.SourceIndex, 1, new(1000), 0)
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
                }
            ])
        {
            SceneMasterPlayerId = DefenderId
        };
    }

    private static (Vector3 Target, ulong EventCursor) StartAttack(
        MatchEngine match, BattleArmyEntityState vehicle, ref int checks)
    {
        BattlePlayerState defender = match.Snapshot().Players.Single(player =>
            player.PlayerId == DefenderId);
        Vector3 target = new(defender.PositionX, defender.PositionY, defender.PositionZ);
        ulong eventCursor = match.EventBatch(VehicleOwnerId, 0).LatestEventId;
        Check(match.Command(VehicleOwnerId, new MatchCommand
        {
            CommandId = 3,
            VehicleAttack = new VehicleAttackCommand
            {
                EntityId = vehicle.EntityKey,
                TargetPlayerId = DefenderId,
                TargetX = target.X,
                TargetY = target.Y,
                TargetZ = target.Z
            }
        }).Code == "vehicle-attack-accepted",
            "Authenticated vehicle attack starts in grenade mode.", ref checks);
        return (target, eventCursor);
    }

    private static void VerifyHumveeFlight(
        BattleCombatContent content, RecoveredBattleMap map, ref int checks)
    {
        var (match, humvee, tick) = PrepareVehicle(
            content, map, "ID_UNIT-HUMVEE", ref checks);
        var (target, eventCursor) = StartAttack(match, humvee, ref checks);

        MatchEvent? shot = null;
        Vector3 rootAtShot = default;
        while (tick < 1050 && shot == null && !match.Terminal)
        {
            // The vehicle can move later in the same tick after its shot.
            BattleArmyEntityState beforeShot = match.ArmyEntityBatch(DefenderId, 0, 0)
                .Entities.Single(entity => entity.EntityKey == humvee.EntityKey);
            rootAtShot = new(beforeShot.X, beforeShot.Y, beforeShot.Z);
            match.Advance(++tick);
            shot = match.EventBatch(VehicleOwnerId, eventCursor).Events.FirstOrDefault(
                battleEvent => battleEvent.Kind == MatchEventKind.Shot &&
                    battleEvent.Reason == "vehicle");
        }

        Check(shot != null, "Humvee launches a host-owned vehicle projectile.", ref checks);
        Vector3 expectedMuzzle = content.GroundVehicleWeapons.RestMuzzleOrigin(
            "ID_UNIT-HUMVEE", "primary", 0, rootAtShot, target - rootAtShot);
        Vector3 actualMuzzle = new(shot!.X, shot.Y, shot.Z);
        Check(Vector3.Distance(actualMuzzle, expectedMuzzle) < .01f &&
              Vector3.Distance(actualMuzzle, rootAtShot) > .01f,
            "Humvee shot starts at its recovered weapon muzzle.", ref checks);

        MatchEvent? impact = null;
        while (tick < 1150 && impact == null && !match.Terminal)
        {
            match.Advance(++tick);
            impact = match.EventBatch(VehicleOwnerId, shot.EventId).Events.FirstOrDefault(
                battleEvent => battleEvent.Kind == MatchEventKind.Impact &&
                    battleEvent.ProjectileId == shot.ProjectileId);
        }

        Check(impact != null, "Humvee projectile reaches a source collision.", ref checks);
        BattlePlayerState defender = match.Snapshot().Players.Single(player =>
            player.PlayerId == DefenderId);
        Check(impact!.TargetId == "" && defender.Health == defender.MaxHealth,
            "Map cover blocks the Humvee shot without inventing player damage.", ref checks);
    }

    private static void VerifyTransporterFlight(
        BattleCombatContent content, RecoveredBattleMap map, ref int checks)
    {
        var (match, transporter, tick) = PrepareVehicle(
            content, map, "ID_UNIT-TRANSPORTER", ref checks);
        var (_, eventCursorAtAttack) = StartAttack(match, transporter, ref checks);

        ulong eventCursor = eventCursorAtAttack;
        var shots = new List<MatchEvent>();
        while (tick < 1050 && shots.Count < 4 && !match.Terminal)
        {
            match.Advance(++tick);
            var page = match.EventBatch(VehicleOwnerId, eventCursor);
            shots.AddRange(page.Events.Where(battleEvent =>
                battleEvent.Kind == MatchEventKind.Shot &&
                battleEvent.Reason is "transporter" or "transporter-fake"));
            eventCursor = page.LatestEventId;
        }

        Check(shots.Count >= 4 &&
              shots.Any(shot => shot.Reason == "transporter") &&
              shots.Select(shot => MathF.Round(shot.X, 3)).Distinct().Count() >= 2,
            "Transporter fires real and fake rounds from separate source muzzles.", ref checks);
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

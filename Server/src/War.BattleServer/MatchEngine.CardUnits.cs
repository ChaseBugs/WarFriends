using System.Numerics;
using War.Protocol;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private readonly CardUnitSpawnState cardUnitSpawns = new();
    private readonly CardUnitEntityRegistry cardUnitEntities = new();
    private CardUnitCombatLifecycle? cardUnitCombat;
    private CardEnemyPointOccupancy? cardEnemyPoints;
    private readonly Dictionary<ulong, ulong> swatPointRetryTicks = [];
    private readonly Dictionary<ulong, CardSoldierWalkState> swatWalks = [];
    private readonly Dictionary<ulong, ulong> sniperPointRetryTicks = [];
    private readonly Dictionary<ulong, CardSoldierWalkState> sniperWalks = [];
    private readonly HashSet<ulong> snipersAtPoint = [];
    private readonly Dictionary<ulong, ulong> sniperCornerChangeTicks = [];
    private readonly Dictionary<ulong, ArmyRusherAttackState> sniperAttacks = [];
    private readonly Dictionary<ulong, ArmyRusherTarget> sniperShotTargets = [];
    private readonly Dictionary<ulong, ulong> sniperExposeTicks = [];
    private readonly Dictionary<ulong, ulong> sniperLastShotTicks = [];
    private readonly Dictionary<ulong, CardSoldierWalkState> paratrooperWalks = [];
    private readonly Dictionary<ulong, CardParachuteFlightState> parachuteFlights = [];
    private readonly Dictionary<ulong, ArmyRusherAttackState> paratrooperAirAttacks = [];
    private readonly Dictionary<ulong, ArmyRusherTarget> paratrooperAirShotTargets = [];
    private readonly Dictionary<ulong, ulong> paratrooperAirShotStartTicks = [];
    private readonly Dictionary<ulong, ulong> paratrooperLandingTicks = [];
    private readonly Dictionary<ulong, Quaternion> paratrooperLandingRotations = [];
    private readonly Dictionary<ulong, Vector3> paratrooperLandingPositions = [];
    private readonly Dictionary<ulong, CardSoldierWalkState> paratrooperFallbackWalks = [];
    private readonly Dictionary<ulong, ulong> paratrooperPointRetryTicks = [];
    private readonly Dictionary<ulong, ArmyRusherAttackState> paratrooperAttacks = [];
    private readonly Dictionary<ulong, ArmyRusherTarget> paratrooperShotTargets = [];
    private readonly Dictionary<ulong, ulong> paratrooperExposeTicks = [];
    private readonly Dictionary<ulong, ulong> paratrooperLastShotTicks = [];
    private readonly Dictionary<ulong, ulong> paratrooperCornerChangeTicks = [];
    private readonly Dictionary<ulong, ArmyRusherAttackState> swatAttacks = [];
    private readonly Dictionary<ulong, ArmyRusherTarget> swatShotTargets = [];
    private readonly Dictionary<ulong, ulong> swatLastShotTicks = [];
    private readonly Dictionary<ulong, ulong> swatShieldHideTicks = [];

    internal CardUnitInitialPoint? CardEnemyPoint(ulong entityKey) =>
        cardEnemyPoints?.Find(entityKey);

    internal ulong? CardEnemyPointOccupant(int pointFileId) =>
        cardEnemyPoints?.Occupant(pointFileId);

    internal bool CardSwatWalking(ulong entityKey) => swatWalks.ContainsKey(entityKey);

    internal bool CardSwatAttacking(ulong entityKey) => swatAttacks.ContainsKey(entityKey);

    internal bool CardSniperWalking(ulong entityKey) =>
        sniperWalks.ContainsKey(entityKey);

    internal bool CardSniperAtPoint(ulong entityKey) =>
        snipersAtPoint.Contains(entityKey);

    internal ArmyRusherAttackState? CardSniperAttack(ulong entityKey) =>
        sniperAttacks.GetValueOrDefault(entityKey);

    internal Vector3? CardSniperFiringMuzzle(ulong entityKey,
        Vector3 targetPosition)
    {
        if (!sniperAttacks.ContainsKey(entityKey))
            return null;
        if (!activeArmyEntities.TryGetValue(entityKey, out var entity) ||
            entity.SourceCardId != "ELITESNIPER" ||
            cardEnemyPoints?.Find(entityKey) is not { } corner ||
            enemyMuzzles == null || assaulterWeapon == null ||
            armyWeapons == null)
            throw new InvalidDataException("Card Sniper lost animated muzzle authority.");
        return CardSniperMuzzlePose.Place(enemyMuzzles, assaulterWeapon,
            armyWeapons, corner, new Vector3(entity.X, entity.Y, entity.Z),
            targetPosition);
    }

    internal bool CardParatrooperWalking(ulong entityKey) =>
        paratrooperWalks.ContainsKey(entityKey);

    internal bool CardParatrooperWalkArrived(ulong entityKey) =>
        paratrooperWalks.TryGetValue(entityKey, out var walk) && walk.Arrived;

    internal bool CardParatrooperFalling(ulong entityKey) =>
        parachuteFlights.ContainsKey(entityKey);

    internal bool CardParatrooperAirAttacking(ulong entityKey) =>
        paratrooperAirAttacks.ContainsKey(entityKey);

    internal ArmyRusherAttackState? CardParatrooperAirAttack(ulong entityKey) =>
        paratrooperAirAttacks.GetValueOrDefault(entityKey);

    internal int? CardParatrooperFallbackSpawn(ulong entityKey) =>
        paratrooperFallbackWalks.TryGetValue(entityKey, out var walk)
            ? walk.PointFileId : null;

    internal bool CardParatrooperAttacking(ulong entityKey) =>
        paratrooperAttacks.ContainsKey(entityKey);

    internal ulong? CardParatrooperCornerChangeTick(ulong entityKey) =>
        paratrooperCornerChangeTicks.TryGetValue(entityKey, out ulong due)
            ? due : null;

    /// <summary>
    /// Host-only activation seam. The UDP command remains closed until
    /// recovered unit AI and Client presentation can consume these spawns.
    /// </summary>
    internal bool TryScheduleCardUnit(string requestId, string ownerPlayerId,
        string sourceCardId)
    {
        Player? owner = Find(ownerPlayerId);
        if (phase != BattlePhase.Running || owner?.Admitted != true ||
            owner.Definition.PlayerLevel is not { } ownerLevel ||
            ownerLevel < 0 || cardUnitCombat == null ||
            !War.Shared.CardUnitSourceIdentity.IsKnown(sourceCardId) ||
            !owner.CardsSelected ||
            !owner.SelectedCards.Contains(sourceCardId, StringComparer.Ordinal) ||
            cardReservations?.HasInventory(ownerPlayerId, sourceCardId) != true ||
            !performance.CanRecordCard(requestId) ||
            !EventCapacityForArmy(CardSpawnUnitSourceCatalog.Get(sourceCardId).Count + 1))
            return false;

        if (!cardUnitSpawns.TrySchedule(requestId, ownerPlayerId,
            sourceCardId, tick))
            return false;
        if (!cardReservations!.TryReserve(requestId, ownerPlayerId, sourceCardId))
        {
            cardUnitSpawns.CancelBeforeSpawn(requestId);
            return false;
        }

        // A selected Card.id is charged once even if its recovered source
        // Spawn call finds no scene point. Ordinary army energy is untouched.
        performance.RecordCard(requestId, ownerPlayerId,
            "CardSpawnUnit", sourceCardId);
        stateRevision++;
        Emit(MatchEventKind.CardEffectApplied, ownerPlayerId,
            "CardSpawnUnit", 0, owner.Position, 0, requestId);
        AdvanceCardUnitSpawns();
        return true;
    }

    private void AdvanceCardUnitSpawns()
    {
        if (cardUnitCombat == null)
            throw new InvalidDataException("Card-unit combat content is absent.");

        foreach (CardUnitSpawnIntent intent in cardUnitSpawns.Due(tick))
        {
            Player owner = Find(intent.OwnerPlayerId) ??
                throw new InvalidDataException("Card-unit owner left the match.");
            Player opponent = players.Single(player => player != owner);
            int ownerLevel = owner.Definition.PlayerLevel ??
                throw new InvalidDataException("Card-unit owner lacks a trusted level.");

            if (!EventCapacityForArmy(1))
            {
                End("army-event-backpressure", "", false);
                return;
            }

            BattleArmyEntityState? entity = cardUnitCombat.SpawnDue(intent,
                owner.Definition.Fraction, ownerLevel, opponent.Position, tick);
            if (entity == null)
                continue; // Source Spawn consumed its failed point search.

            activeArmyEntities.Add(entity.EntityKey, entity);
            if (entity.SourceCardId is "ELITEMINIGUN" or "ELITESWAT" or
                "ELITESNIPER" or "ELITEPARA")
                InitializeInfantryAnimation(entity.EntityKey);
            if (entity.SourceCardId == "HEAVYDRONE")
                InitializeCardDrone(entity);
            if (entity.SourceCardId == "ELITEMINIGUN")
                InitializeCardMinigunner(entity);
            if (entity.SourceCardId == "ELITEPARA")
                InitializeCardParatrooper(entity);
            if (entity.SourceCardId == "ELITESWAT")
                InitializeCardSwat(entity);
            if (entity.SourceCardId == "ELITESNIPER")
                InitializeCardSniper(entity);
            armyEntityRevision++;
            stateRevision++;
            Emit(MatchEventKind.ArmySpawned, owner.Definition.PlayerId,
                "", 0, new(entity.X, entity.Y, entity.Z), 0, "");
            MatchEvent spawnEvent = events[^1];
            spawnEvent.ArmyEntityId = entity.LocalEntityId;
            spawnEvent.ArmyOptionIndex = -1;
            spawnEvent.ArmyUnitId = entity.UnitId;
            spawnEvent.ArmySpawnComponentFileId = entity.SpawnComponentFileId;
            spawnEvent.ArmyReservationFileId = entity.ReservationFileId;
            spawnEvent.SourceCardId = entity.SourceCardId;
        }
    }

    private void InitializeCardSwat(BattleArmyEntityState entity)
    {
        CardUnitEntity source = cardUnitEntities.Find(entity.LocalEntityId) ??
            throw new InvalidDataException("Card SWAT lost its source spawn identity.");
        if (source.EntityKey != entity.EntityKey ||
            source.SourceCardId != "ELITESWAT" ||
            entity.UnitId != "ID_UNIT-SWAT")
            throw new InvalidDataException("Card SWAT cannot bind its combat rows.");

        // The card uses CARDS_MIN/MAX health, damage, and shot rows. It has
        // no ordinary army option or purchased special upgrade lane.
        armyDamage.Add(entity.EntityKey, source.BaseStats.Combat.Damage);
        armyShots.Add(entity.EntityKey, source.BaseStats.Shot);
        rusherShotCounts.Add(entity.EntityKey, 0);
        TryAssignCardSwatPoint(entity);
    }

    private void InitializeCardParatrooper(BattleArmyEntityState entity)
    {
        CardUnitEntity source = cardUnitEntities.Find(entity.LocalEntityId) ??
            throw new InvalidDataException("Card Paratrooper lost its source spawn identity.");
        if (source.EntityKey != entity.EntityKey ||
            source.SourceCardId != "ELITEPARA" ||
            entity.UnitId != "ID_UNIT-PARATROOPER")
            throw new InvalidDataException("Card Paratrooper cannot bind its combat rows.");

        // CardSpawnUnit uses its card upgrade rows, not the ordinary army
        // option. Corner-point selection occurs only after parachute landing.
        armyDamage.Add(entity.EntityKey, source.BaseStats.Combat.Damage);
        armyShots.Add(entity.EntityKey, source.BaseStats.Shot);
        float offset = combatRandom();
        if (!float.IsFinite(offset) || offset < 0f || offset > 1f)
            throw new InvalidDataException("Invalid host Paratrooper sway offset.");
        float phase = ((tick % (4u * MatchManifest.TickRate)) /
            (2f * MatchManifest.TickRate) + offset) % 2f;
        var flight = new CardParachuteFlightState(
            new Vector3(entity.X, entity.Y, entity.Z),
            entity.OwnerFraction, phase);
        if (!parachuteFlights.TryAdd(entity.EntityKey, flight))
            throw new InvalidDataException("Card Paratrooper reused a flight identity.");
        // ParachuteUpdate tries its first shot on the next update. A failed
        // range or visibility check schedules the source 1-4 second retry.
        var airAttack = new ArmyRusherAttackState(source.BaseStats.Shot,
            NextArmyFloat, shotIntervalTicks: 16);
        if (!paratrooperAirAttacks.TryAdd(entity.EntityKey, airAttack) ||
            !rusherShotCounts.TryAdd(entity.EntityKey, 0))
            throw new InvalidDataException("Card Paratrooper reused its airborne attack identity.");
    }

    private void AdvanceCardParachuteFlights()
    {
        if (map == null)
            throw new InvalidDataException("Card Paratrooper has no scene map.");
        foreach (var (entityKey, flight) in parachuteFlights
            .OrderBy(row => row.Key).ToArray())
        {
            if (!activeArmyEntities.TryGetValue(entityKey, out var entity) ||
                entity.SourceCardId != "ELITEPARA")
                throw new InvalidDataException("Card Paratrooper flight lost its soldier.");

            Vector3? landed = flight.AdvanceHostTick(map,
                shields == null ? null : shields.ColliderEnabled,
                barrels == null ? null : barrels.ColliderEnabled,
                barrels == null ? null : barrels.RuntimeLayer);
            Vector3 position = flight.Position;
            entity.X = position.X;
            entity.Y = position.Y;
            entity.Z = position.Z;
            entity.PositionTick = tick;
            cardUnitCombat!.UpdatePose(entity);
            if (landed.HasValue &&
                !ConfirmCardParatrooperLanding(entityKey, landed.Value))
                throw new InvalidDataException("Card Paratrooper landing was rejected.");
        }
    }

    /// <summary>
    /// Called only after host physics confirms the parachute's collision.
    /// The Client reserves its Corner/Hiding point in EnemyController.OnLanded,
    /// not when CardSpawnUnit creates the soldier.
    /// </summary>
    internal bool ConfirmCardParatrooperLanding(ulong entityKey,
        Vector3 landedPosition)
    {
        if (phase != BattlePhase.Running ||
            !activeArmyEntities.TryGetValue(entityKey, out var entity) ||
            entity.SourceCardId != "ELITEPARA" ||
            cardEnemyPoints == null || map == null ||
            armyNavMeshConnectivity == null || armyCatalog == null ||
            !parachuteFlights.TryGetValue(entityKey, out var flight) ||
            !PlayerHitbox.Finite(landedPosition))
            return false;
        if (paratrooperWalks.ContainsKey(entityKey) ||
            paratrooperFallbackWalks.ContainsKey(entityKey) ||
            paratrooperAttacks.ContainsKey(entityKey) ||
            cardEnemyPoints.Find(entityKey) != null)
            return false;

        CardUnitInitialPoint? point = cardEnemyPoints.TryAssign(entityKey,
            "ELITEPARA", entity.OwnerFraction, landedPosition);
        if (point == null)
        {
            bool beganFallback = BeginCardParatrooperFallback(entity, landedPosition);
            if (beganFallback)
            {
                RecordCardParatrooperLanding(entityKey, flight, landedPosition);
                parachuteFlights.Remove(entityKey);
            }
            return beganFallback;
        }
        try
        {
            ArmyNavMeshCorridor route = PlanCardSoldierRoute(
                landedPosition, point.Position);
            float speed = armyCatalog.EffectiveSpeed(entity.UnitId, 1f);
            var walk = new CardSoldierWalkState(point.ComponentFileId, route,
                armyCatalog.InfantryAgent, speed);
            entity.X = landedPosition.X;
            entity.Y = landedPosition.Y;
            entity.Z = landedPosition.Z;
            entity.PositionTick = tick;
            cardUnitCombat!.UpdatePose(entity);
            paratrooperWalks.Add(entityKey, walk);
            RecordCardParatrooperLanding(entityKey, flight, landedPosition);
            parachuteFlights.Remove(entityKey);
            armyEntityRevision++;
            stateRevision++;
            return true;
        }
        catch
        {
            cardEnemyPoints.Release(entityKey);
            throw;
        }
    }

    private void RecordCardParatrooperLanding(ulong entityKey,
        CardParachuteFlightState flight, Vector3 landedPosition)
    {
        if (!paratrooperLandingTicks.TryAdd(entityKey, tick) ||
            !paratrooperLandingRotations.TryAdd(entityKey, flight.Rotation) ||
            !paratrooperLandingPositions.TryAdd(entityKey, landedPosition))
            throw new InvalidDataException("Card Paratrooper landed more than once.");
    }

    private ArmyNavMeshCorridor PlanCardSoldierRoute(Vector3 startPosition,
        Vector3 destinationPosition)
    {
        if (map == null || armyNavMeshConnectivity == null)
            throw new InvalidDataException("Card soldier has no source navigation map.");
        // Scene transforms and parachute contacts can sit slightly above
        // the baked NavMesh. Unity's agent projects them to its surface.
        Vector3 start = armyNavMeshConnectivity.SampleNearest(map,
            startPosition, 1.25f) ??
            throw new InvalidDataException("Card soldier starts outside the NavMesh.");
        Vector3 destination = armyNavMeshConnectivity.SampleNearest(map,
            destinationPosition, 0.5f) ??
            throw new InvalidDataException("Card soldier destination lies outside the NavMesh.");
        ArmyNavMeshCorridor route = armyNavMeshConnectivity.PlanCorridor(
            map, start, destination) ??
            throw new InvalidDataException("Card soldier has no NavMesh corridor.");
        if (!route.PlanarCovered)
            throw new InvalidDataException("Card soldier corridor leaves the source NavMesh.");
        return route;
    }

    private bool BeginCardParatrooperFallback(BattleArmyEntityState entity,
        Vector3 landedPosition)
    {
        if (map == null || armySpawnPoints == null || armyCatalog == null)
            throw new InvalidDataException("Card Paratrooper has no fallback spawn catalog.");
        // SoldierBehaviour.PickNormalSPawn draws only from same-faction
        // normal soldier spawns, regardless of its parachute spawn route.
        ArmySpawnPoint[] candidates = armySpawnPoints.ForMap(map)
            .Where(point => point.Collection == "spawnPointsCollection" &&
                point.ComponentType == "SpawnPoint" &&
                point.Fraction == entity.OwnerFraction)
            .ToArray();
        if (candidates.Length == 0)
            throw new InvalidDataException("Card Paratrooper has no normal fallback spawn.");
        int selected = armyChoice(candidates.Length);
        if (selected < 0 || selected >= candidates.Length)
            throw new InvalidDataException("Invalid host Paratrooper fallback choice.");
        ArmySpawnPoint spawn = candidates[selected];
        ArmyNavMeshCorridor route = PlanCardSoldierRoute(
            landedPosition, spawn.Position);
        float speed = armyCatalog.EffectiveSpeed(entity.UnitId, 1f);
        paratrooperFallbackWalks.Add(entity.EntityKey,
            new CardSoldierWalkState(spawn.ComponentFileId, route,
                armyCatalog.InfantryAgent, speed));
        paratrooperPointRetryTicks.Add(entity.EntityKey,
            checked(tick + 5u * MatchManifest.TickRate));
        entity.X = landedPosition.X;
        entity.Y = landedPosition.Y;
        entity.Z = landedPosition.Z;
        entity.PositionTick = tick;
        cardUnitCombat!.UpdatePose(entity);
        armyEntityRevision++;
        stateRevision++;
        return true;
    }

    private void AdvanceCardParatrooperFallbacks()
    {
        foreach (var (entityKey, walk) in paratrooperFallbackWalks
            .OrderBy(row => row.Key).ToArray())
        {
            if (!activeArmyEntities.TryGetValue(entityKey, out var entity) ||
                entity.SourceCardId != "ELITEPARA" ||
                !paratrooperPointRetryTicks.TryGetValue(entityKey, out ulong retryTick))
                throw new InvalidDataException("Card Paratrooper fallback lost its soldier or retry.");
            if (!walk.Arrived)
            {
                walk.AdvanceTick();
                entity.X = walk.Position.X;
                entity.Y = walk.Position.Y;
                entity.Z = walk.Position.Z;
                entity.PositionTick = tick;
                cardUnitCombat?.UpdatePose(entity);
            }
            if (tick < retryTick)
                continue;

            Vector3 position = new(entity.X, entity.Y, entity.Z);
            CardUnitInitialPoint? point = cardEnemyPoints?.TryAssign(entityKey,
                "ELITEPARA", entity.OwnerFraction, position);
            if (point == null)
            {
                paratrooperPointRetryTicks[entityKey] = checked(tick +
                    5u * MatchManifest.TickRate);
                continue;
            }
            try
            {
                ArmyNavMeshCorridor route = PlanCardSoldierRoute(
                    position, point.Position);
                float speed = armyCatalog!.EffectiveSpeed(entity.UnitId, 1f);
                paratrooperWalks.Add(entityKey, new CardSoldierWalkState(
                    point.ComponentFileId, route,
                    armyCatalog.InfantryAgent, speed));
                paratrooperFallbackWalks.Remove(entityKey);
                paratrooperPointRetryTicks.Remove(entityKey);
            }
            catch
            {
                cardEnemyPoints!.Release(entityKey);
                throw;
            }
        }
    }

    private void AdvanceCardParatrooperWalks()
    {
        foreach (var (entityKey, walk) in paratrooperWalks.OrderBy(row => row.Key).ToArray())
        {
            if (!activeArmyEntities.TryGetValue(entityKey, out var entity) ||
                entity.SourceCardId != "ELITEPARA" ||
                cardEnemyPoints?.Find(entityKey)?.ComponentFileId != walk.PointFileId)
                throw new InvalidDataException("Card Paratrooper walk lost its soldier or point.");
            if (!walk.Arrived)
            {
                walk.AdvanceTick();
                entity.X = walk.Position.X;
                entity.Y = walk.Position.Y;
                entity.Z = walk.Position.Z;
                entity.PositionTick = tick;
                cardUnitCombat?.UpdatePose(entity);
            }
            // WalkingUpdate waits for !mWillShoot before TargetReached.
            // An airborne batch keeps that flag through OnLanded, so the
            // Corner state cannot replace its pending windup or rounds.
            if (walk.Arrived && !CardParatrooperHasPendingAirBatch(entityKey))
            {
                paratrooperWalks.Remove(entityKey);
                StartCardParatrooperAttack(entityKey);
            }
        }
    }

    private void StartCardParatrooperAttack(ulong entityKey)
    {
        if (!armyShots.TryGetValue(entityKey, out ArmyBaseShotStats? shot) ||
            cardEnemyPoints?.Find(entityKey) is not
                { ComponentType: "EnemyPointCorner", CornerDirection: not null,
                  CornerRightSide: not null } ||
            armyWeapons == null || enemyPoses == null)
            throw new InvalidDataException("Card Paratrooper reached no source Corner attack row.");

        int cadence = armyWeapons.CadenceTicks("ID_UNIT-PARATROOPER");
        var attack = new ArmyRusherAttackState(shot, NextArmyFloat, cadence);
        // SwitchState(CornerHiding) calls GenerateNextShootTime immediately.
        attack.BeginInitialCooldown();
        if (!paratrooperAttacks.TryAdd(entityKey, attack))
            throw new InvalidDataException("Card Paratrooper attack started twice.");
        if (!rusherShotCounts.ContainsKey(entityKey))
            throw new InvalidDataException("Card Paratrooper lost its airborne shot count.");
        int waitSeconds = 10 + armyChoice(10);
        if (waitSeconds is < 10 or > 19 ||
            !paratrooperCornerChangeTicks.TryAdd(entityKey,
                checked(tick + (ulong)waitSeconds * MatchManifest.TickRate)))
            throw new InvalidDataException("Card Paratrooper lost its Corner change clock.");
    }

    internal CardParatrooperAirTarget? CardParatrooperAirAim(ulong entityKey)
    {
        if (!parachuteFlights.ContainsKey(entityKey))
            return null;
        if (!activeArmyEntities.TryGetValue(entityKey, out var entity) ||
            entity.SourceCardId != "ELITEPARA" ||
            rifleCombat == null || playerShotTargets == null ||
            enemyMuzzles == null)
            throw new InvalidDataException("Airborne Paratrooper lost its target authority.");

        Player owner = Find(entity.OwnerPlayerId) ??
            throw new InvalidDataException("Airborne Paratrooper owner left the match.");
        Player opponent = players.Single(player => player != owner);
        if (opponent.Dead)
            return null;

        Vector3 position = new(entity.X, entity.Y, entity.Z);
        PlayerAimPose opponentPose = rifleCombat.Pose(opponent.Definition.PlayerId);
        CardParatrooperAirTarget target = CardParatrooperAirTarget.Select(
            playerShotTargets, opponentPose, position);
        if (!target.WithinRange)
            return target;

        // The Client checks visibility before ShootStand starts, while its
        // rifle is in the idle clip. The muzzle samples were exported from
        // the same enemy.prefab and assault rifle used by this card unit.
        CoopMuzzlePose muzzle = CardParatrooperAirMuzzle(entityKey) ??
            throw new InvalidDataException("Airborne Paratrooper lost its rifle muzzle.");
        HelicopterSightRay sight = CardParatrooperAirTarget.SightRay(
            position, muzzle.Position.Y, target.Position);
        return target with { HasClearSight = rifleCombat.HelicopterCanSee(sight) };
    }

    internal CoopMuzzlePose? CardParatrooperAirMuzzle(ulong entityKey)
    {
        if (!parachuteFlights.TryGetValue(entityKey, out var flight))
            return null;
        if (!activeArmyEntities.TryGetValue(entityKey, out var entity) ||
            entity.SourceCardId != "ELITEPARA" || enemyMuzzles == null ||
            tick < entity.SpawnTick)
            throw new InvalidDataException("Airborne Paratrooper lost its animated muzzle authority.");

        float idleSeconds = (tick - entity.SpawnTick) /
            (float)MatchManifest.TickRate;
        Vector3 soldierPosition = new(entity.X, entity.Y, entity.Z);
        return enemyMuzzles.Place("idle_1", soldierPosition,
            flight.Rotation, idleSeconds);
    }

    internal CoopMuzzlePose? CardParatrooperAirFiringMuzzle(ulong entityKey)
    {
        if (!parachuteFlights.TryGetValue(entityKey, out var flight))
            return null;
        if (!paratrooperAirShotStartTicks.TryGetValue(entityKey,
                out ulong startedAt) ||
            !activeArmyEntities.TryGetValue(entityKey, out var entity) ||
            entity.SourceCardId != "ELITEPARA" || enemyMuzzles == null ||
            tick < startedAt)
            throw new InvalidDataException("Airborne Paratrooper lost its firing animation clock.");

        // SoldierAnimationController.ShootStand plays rifle_shot_loop at
        // half speed. The source muzzle artifact samples that same clip.
        float clipSeconds = (tick - startedAt) /
            (float)MatchManifest.TickRate * 0.5f;
        Vector3 soldierPosition = new(entity.X, entity.Y, entity.Z);
        return enemyMuzzles.Place("rifle_shot_loop", soldierPosition,
            flight.Rotation, clipSeconds);
    }

    internal CoopMuzzlePose? CardParatrooperPostLandingMuzzle(ulong entityKey,
        ulong? sampleTick = null)
    {
        if (parachuteFlights.ContainsKey(entityKey))
            return null;
        ulong animationTick = sampleTick ?? tick;
        if (!paratrooperLandingTicks.TryGetValue(entityKey,
                out ulong landedAt) ||
            !paratrooperLandingRotations.TryGetValue(entityKey,
                out Quaternion landingRotation) ||
            !activeArmyEntities.TryGetValue(entityKey, out var entity) ||
            entity.SourceCardId != "ELITEPARA" || enemyMuzzles == null ||
            animationTick < landedAt ||
            (animationTick > tick && animationTick - tick != 1))
            throw new InvalidDataException("Landed Paratrooper lost its Walk muzzle authority.");

        CardSoldierWalkState? walk = paratrooperWalks.GetValueOrDefault(entityKey) ??
            paratrooperFallbackWalks.GetValueOrDefault(entityKey);
        if (walk == null)
            throw new InvalidDataException("Landed Paratrooper has no Walk route.");

        Quaternion rotation = landingRotation;
        if (walk.Facing is Vector3 forward)
        {
            float yaw = MathF.Atan2(forward.X, forward.Z);
            rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, yaw);
        }
        float walkSeconds = (animationTick - landedAt) /
            (float)MatchManifest.TickRate;
        Vector3 soldierPosition = new(entity.X, entity.Y, entity.Z);
        return enemyMuzzles.Place("run_0", soldierPosition,
            rotation, walkSeconds);
    }

    internal CoopMuzzlePose? CardParatrooperCornerMuzzle(ulong entityKey)
    {
        if (!paratrooperAttacks.ContainsKey(entityKey))
            return null;
        if (!activeArmyEntities.TryGetValue(entityKey, out var entity) ||
            entity.SourceCardId != "ELITEPARA" || enemyMuzzles == null ||
            cardEnemyPoints?.Find(entityKey) is not
                { ComponentType: "EnemyPointCorner", CornerRightSide: bool rightSide,
                  CornerDirection: Vector3 direction })
            throw new InvalidDataException("Corner Paratrooper lost its firing pose.");

        // ShootFromCover queues the side-specific fire clip after uncovering.
        // Shoot occurs 0.05 seconds after uncoverLength, so sample that clip
        // at the same elapsed time instead of using the resting weapon pose.
        // SwitchState(CornerHiding) turns toward -enemyPointCorner.direction;
        // the point's serialized transform rotation is different.
        string clip = rightSide ? "player_fire_right3" : "player_fire_left3";
        Vector3 position = new(entity.X, entity.Y, entity.Z);
        float yaw = MathF.Atan2(-direction.X, -direction.Z);
        Quaternion facing = Quaternion.CreateFromAxisAngle(Vector3.UnitY, yaw);
        return enemyMuzzles.Place(clip, position, facing, 0.05f);
    }

    private void AdvanceCardParatrooperAirAttacks()
    {
        if (armyWeapons == null)
            throw new InvalidDataException("Airborne Paratrooper lacks weapon timing.");

        int windupTicks = armyWeapons.WindupTicks("ID_UNIT-PARATROOPER");
        rusherShotIntents.Clear();
        foreach (var (entityKey, attack) in paratrooperAirAttacks
            .OrderBy(row => row.Key).ToArray())
        {
            if (!activeArmyEntities.TryGetValue(entityKey, out var entity) ||
                entity.SourceCardId != "ELITEPARA")
                throw new InvalidDataException("Airborne attack lost its Paratrooper.");

            bool stillFalling = parachuteFlights.ContainsKey(entityKey);
            if (!stillFalling && attack.Phase is
                ArmyRusherAttackPhase.Ready or ArmyRusherAttackPhase.Cooldown)
            {
                paratrooperAirAttacks.Remove(entityKey);
                paratrooperAirShotStartTicks.Remove(entityKey);
                continue;
            }

            if (attack.Phase == ArmyRusherAttackPhase.Ready)
            {
                CardParatrooperAirTarget? aim = CardParatrooperAirAim(entityKey);
                if (aim == null || !aim.WithinRange || !aim.HasClearSight)
                {
                    attack.RetryAfterRejectedTarget();
                }
                else if (attack.TryBegin(true, 1, windupTicks))
                {
                    Player owner = Find(entity.OwnerPlayerId) ??
                        throw new InvalidDataException("Airborne attack lost its owner.");
                    Player opponent = players.Single(player => player != owner);
                    var shotTarget = new ArmyRusherTarget(
                        entityKey, opponent.Definition.PlayerId,
                        aim.TransformFileId, 0, aim.Position);
                    if (!paratrooperAirShotTargets.TryAdd(entityKey, shotTarget) ||
                        !paratrooperAirShotStartTicks.TryAdd(entityKey, tick))
                        throw new InvalidDataException("Airborne Paratrooper reused a firing batch.");
                }
            }

            attack.AdvanceTick();
            if (!attack.ShotDue)
                continue;
            if (!paratrooperAirShotTargets.TryGetValue(entityKey,
                out ArmyRusherTarget? target))
                throw new InvalidDataException("Airborne attack lost its latched Shield target.");
            Vector3? firingMuzzle = null;
            if (stillFalling)
                firingMuzzle = CardParatrooperAirFiringMuzzle(entityKey)?.Position ??
                    throw new InvalidDataException("Airborne Paratrooper lost its shot muzzle.");
            else
                firingMuzzle = CardParatrooperPostLandingMuzzle(entityKey)?.Position ??
                    throw new InvalidDataException("Landed Paratrooper lost its shot muzzle.");
            rusherShotIntents.Add(new ArmyRusherShotIntent(entityKey,
                entity.OwnerPlayerId, target.PlayerId, target.TargetFileId,
                target.Position, attack.CurrentShotIsReal,
                attack.BatchCursor, attack.BatchSize, firingMuzzle));
            attack.CommitShot();
            if (attack.Phase == ArmyRusherAttackPhase.Cooldown)
            {
                paratrooperAirShotTargets.Remove(entityKey);
                paratrooperAirShotStartTicks.Remove(entityKey);
                if (!stillFalling)
                    paratrooperAirAttacks.Remove(entityKey);
            }
        }
        LaunchRusherShotIntents();
    }

    private bool CardParatrooperHasPendingAirBatch(ulong entityKey) =>
        paratrooperAirAttacks.TryGetValue(entityKey, out var attack) &&
        attack.Phase is ArmyRusherAttackPhase.Windup or
            ArmyRusherAttackPhase.Firing;

    private ArmyRusherTarget? CardParatrooperBodyTarget(ulong entityKey)
    {
        if (rifleCombat == null || playerShotTargets == null ||
            !activeArmyEntities.TryGetValue(entityKey, out var entity) ||
            cardEnemyPoints?.Find(entityKey) is not { } corner ||
            corner.CornerDirection is not Vector3 direction ||
            corner.CornerRightSide is not bool rightSide)
            return null;

        Player owner = Find(entity.OwnerPlayerId) ??
            throw new InvalidDataException("Card Paratrooper owner left the match.");
        Player opponent = players.Single(player => player != owner);
        if (opponent.Dead)
            return null;

        var pose = rifleCombat.Pose(opponent.Definition.PlayerId);
        var position = new Vector3(entity.X, entity.Y, entity.Z);
        var target = playerShotTargets.Nearest(1, position,
            candidate => pose.BodyTarget(candidate.TransformFileId).Position);
        Vector3 targetPosition = pose.BodyTarget(target.TransformFileId).Position;
        if (!CornerShotPolicy.CanExpose(direction, rightSide,
            position, targetPosition))
            return null;
        return new ArmyRusherTarget(entityKey, opponent.Definition.PlayerId,
            target.TransformFileId, corner.ComponentFileId, targetPosition);
    }

    private void AdvanceCardParatrooperAttacks()
    {
        if (enemyPoses == null)
            throw new InvalidDataException("Card Paratrooper has no cover animation content.");
        float uncoverSeconds = enemyPoses.Clip("player_look_right3").Length;
        int windupTicks = checked((int)MathF.Ceiling(
            (uncoverSeconds + 0.05f) * MatchManifest.TickRate));
        rusherShotIntents.Clear();
        foreach (var (entityKey, attack) in paratrooperAttacks.OrderBy(row => row.Key))
        {
            if (!activeArmyEntities.TryGetValue(entityKey, out var entity) ||
                entity.SourceCardId != "ELITEPARA" ||
                cardEnemyPoints?.Find(entityKey) == null)
                throw new InvalidDataException("Card Paratrooper attack lost its Corner soldier.");

            if (attack.Phase == ArmyRusherAttackPhase.Ready)
            {
                ArmyRusherTarget? target = CardParatrooperBodyTarget(entityKey);
                if (target == null)
                    attack.RetryAfterRejectedTarget();
                else if (attack.TryBegin(true, 1, windupTicks))
                {
                    paratrooperShotTargets[entityKey] = target;
                    paratrooperExposeTicks[entityKey] = tick;
                }
            }

            attack.AdvanceTick();
            if (!attack.ShotDue)
                continue;
            if (!paratrooperShotTargets.TryGetValue(entityKey, out var shotTarget))
                throw new InvalidDataException("Card Paratrooper lost its latched shot target.");
            Vector3 muzzle = CardParatrooperCornerMuzzle(entityKey)?.Position ??
                throw new InvalidDataException("Card Paratrooper lost its Corner muzzle.");
            rusherShotIntents.Add(new ArmyRusherShotIntent(entityKey,
                entity.OwnerPlayerId, shotTarget.PlayerId,
                shotTarget.TargetFileId, shotTarget.Position,
                attack.CurrentShotIsReal, attack.BatchCursor, attack.BatchSize,
                muzzle));
            paratrooperLastShotTicks[entityKey] = tick;
            attack.CommitShot();
            if (attack.Phase == ArmyRusherAttackPhase.Cooldown)
                paratrooperShotTargets.Remove(entityKey);
        }
        LaunchRusherShotIntents();
        AdvanceCardParatrooperCornerChanges();
    }

    private void AdvanceCardParatrooperCornerChanges()
    {
        if (cardEnemyPoints == null || armyCatalog == null)
            throw new InvalidDataException("Card Paratrooper has no point-change authority.");

        foreach (var (entityKey, attack) in paratrooperAttacks
            .OrderBy(row => row.Key).ToArray())
        {
            if (!paratrooperCornerChangeTicks.TryGetValue(entityKey,
                    out ulong changeTick) ||
                !activeArmyEntities.TryGetValue(entityKey, out var entity))
                throw new InvalidDataException("Card Paratrooper lost its Corner clock.");
            // CornerHidingUpdate changes points only while hidden and after
            // the current shooting callback has finished.
            if (tick <= changeTick || attack.Phase is
                ArmyRusherAttackPhase.Windup or ArmyRusherAttackPhase.Firing)
                continue;

            IReadOnlyList<CardUnitInitialPoint> available =
                cardEnemyPoints.NextFreePoints(entityKey, "ELITEPARA",
                    entity.OwnerFraction);
            if (available.Count == 0)
            {
                paratrooperCornerChangeTicks[entityKey] = checked(changeTick +
                    10u * MatchManifest.TickRate);
                continue;
            }

            int index = armyChoice(available.Count);
            if (index < 0 || index >= available.Count)
                throw new InvalidDataException("Invalid host Corner point choice.");
            CardUnitInitialPoint next = available[index];
            Vector3 position = new(entity.X, entity.Y, entity.Z);
            ArmyNavMeshCorridor route = PlanCardSoldierRoute(
                position, next.Position);
            float speed = armyCatalog.EffectiveSpeed(entity.UnitId, 1f);
            var walk = new CardSoldierWalkState(next.ComponentFileId, route,
                armyCatalog.InfantryAgent, speed);

            cardEnemyPoints.Transfer(entityKey, "ELITEPARA", next);
            paratrooperAttacks.Remove(entityKey);
            paratrooperShotTargets.Remove(entityKey);
            paratrooperExposeTicks.Remove(entityKey);
            paratrooperLastShotTicks.Remove(entityKey);
            paratrooperCornerChangeTicks.Remove(entityKey);
            paratrooperWalks.Add(entityKey, walk);
        }
    }

    private void TryAssignCardSwatPoint(BattleArmyEntityState entity)
    {
        if (cardEnemyPoints == null || entity.SourceCardId != "ELITESWAT")
            throw new InvalidDataException("Card SWAT has no source enemy-point authority.");
        var position = new Vector3(entity.X, entity.Y, entity.Z);
        CardUnitInitialPoint? point = cardEnemyPoints.TryAssign(entity.EntityKey,
            entity.SourceCardId, entity.OwnerFraction, position);
        if (point == null)
        {
            // EnemyController.GenerateInitPoint retries five seconds after
            // a failed GetInitPoint. The unit itself remains spawned.
            swatPointRetryTicks[entity.EntityKey] = checked(tick +
                5u * MatchManifest.TickRate);
            return;
        }
        swatPointRetryTicks.Remove(entity.EntityKey);
        if (map == null || armyNavMeshConnectivity == null || armyCatalog == null)
            throw new InvalidDataException("Card SWAT lacks source navigation content.");
        ArmyNavMeshCorridor route = armyNavMeshConnectivity.PlanCorridor(
            map, position, point.Position) ??
            throw new InvalidDataException("Card SWAT destination has no NavMesh corridor.");
        if (!route.PlanarCovered)
            throw new InvalidDataException("Card SWAT corridor leaves the source NavMesh.");

        // AIObject.SpawnByCard creates UnitUpgrades(1f), so SWAT has no
        // purchased special-speed lane. The recovered family speed applies.
        float speed = armyCatalog.EffectiveSpeed(entity.UnitId, 1f);
        if (!swatWalks.TryAdd(entity.EntityKey, new CardSoldierWalkState(
            point.ComponentFileId, route, armyCatalog.InfantryAgent, speed)))
            throw new InvalidDataException("Card SWAT already has a walk.");
    }

    private void InitializeCardSniper(BattleArmyEntityState entity)
    {
        CardUnitEntity source = cardUnitEntities.Find(entity.LocalEntityId) ??
            throw new InvalidDataException("Card Sniper lost its source spawn identity.");
        if (source.EntityKey != entity.EntityKey ||
            source.SourceCardId != "ELITESNIPER" ||
            entity.UnitId != "ID_UNIT-SNIPER")
            throw new InvalidDataException("Card Sniper cannot bind its source rows.");

        // The MainScene sniper sheet has no CARDS_MIN/MAX rows. The card
        // lifecycle has already applied the recovered row-zero fallback.
        armyDamage.Add(entity.EntityKey, source.BaseStats.Combat.Damage);
        armyShots.Add(entity.EntityKey, source.BaseStats.Shot);
        if (!rusherShotCounts.TryAdd(entity.EntityKey, 0))
            throw new InvalidDataException("Card Sniper shot counter already exists.");
        TryAssignCardSniperPoint(entity);
    }

    private void TryAssignCardSniperPoint(BattleArmyEntityState entity)
    {
        if (cardEnemyPoints == null || armyCatalog == null ||
            entity.SourceCardId != "ELITESNIPER")
            throw new InvalidDataException("Card Sniper has no source point authority.");
        Player owner = Find(entity.OwnerPlayerId) ??
            throw new InvalidDataException("Card Sniper owner left the match.");
        Player opponent = players.Single(player => player != owner);
        Vector3 position = new(entity.X, entity.Y, entity.Z);
        CardUnitInitialPoint? point = cardEnemyPoints.TryAssignSniper(
            entity.EntityKey, entity.OwnerFraction, position,
            opponent.Position);
        if (point == null)
        {
            // GenerateInitPoint retries five seconds after GetInitPoint
            // finds no free point past minSniperDistance.
            sniperPointRetryTicks[entity.EntityKey] = checked(tick +
                5u * MatchManifest.TickRate);
            return;
        }

        try
        {
            ArmyNavMeshCorridor route = PlanCardSoldierRoute(
                position, point.Position);
            float speed = armyCatalog.EffectiveSpeed(entity.UnitId, 1f);
            sniperWalks.Add(entity.EntityKey, new CardSoldierWalkState(
                point.ComponentFileId, route, armyCatalog.InfantryAgent,
                speed));
            sniperPointRetryTicks.Remove(entity.EntityKey);
        }
        catch
        {
            cardEnemyPoints.Release(entity.EntityKey);
            throw;
        }
    }

    private void AdvanceCardSniperPointRetries()
    {
        foreach (var (entityKey, dueTick) in sniperPointRetryTicks
            .OrderBy(row => row.Key).ToArray())
        {
            if (tick < dueTick)
                continue;
            if (!activeArmyEntities.TryGetValue(entityKey, out var entity) ||
                entity.SourceCardId != "ELITESNIPER")
                throw new InvalidDataException("Card Sniper retry lost its soldier.");
            TryAssignCardSniperPoint(entity);
        }
    }

    private void AdvanceCardSniperWalks()
    {
        foreach (var (entityKey, walk) in sniperWalks
            .OrderBy(row => row.Key).ToArray())
        {
            if (!activeArmyEntities.TryGetValue(entityKey, out var entity) ||
                entity.SourceCardId != "ELITESNIPER" ||
                cardEnemyPoints?.Find(entityKey)?.ComponentFileId !=
                    walk.PointFileId)
                throw new InvalidDataException("Card Sniper walk lost its point.");
            walk.AdvanceTick();
            entity.X = walk.Position.X;
            entity.Y = walk.Position.Y;
            entity.Z = walk.Position.Z;
            entity.PositionTick = tick;
            cardUnitCombat?.UpdatePose(entity);
            if (!walk.Arrived)
                continue;

            sniperWalks.Remove(entityKey);
            if (!snipersAtPoint.Add(entityKey))
                throw new InvalidDataException("Card Sniper arrived twice.");
            int waitSeconds = 10 + armyChoice(10);
            if (waitSeconds is < 10 or > 19 ||
                !sniperCornerChangeTicks.TryAdd(entityKey,
                    checked(tick + (ulong)waitSeconds * MatchManifest.TickRate)))
                throw new InvalidDataException("Card Sniper lost its Corner clock.");
            StartCardSniperAttack(entityKey);
        }
    }

    private void StartCardSniperAttack(ulong entityKey)
    {
        if (!armyShots.TryGetValue(entityKey, out ArmyBaseShotStats? shot) ||
            cardEnemyPoints?.Find(entityKey) is not
                { ComponentType: "EnemyPointCorner", CornerDirection: not null,
                  CornerRightSide: not null })
            throw new InvalidDataException("Card Sniper reached no source Corner or shot row.");
        int cadence = armyWeapons?.CadenceTicks("ID_UNIT-SNIPER") ??
            throw new InvalidDataException("Card Sniper lacks source cadence.");
        var attack = new ArmyRusherAttackState(shot, NextArmyFloat, cadence);
        // SwitchState(CornerHiding) calls GenerateNextShootTime on arrival.
        attack.BeginInitialCooldown();
        if (!sniperAttacks.TryAdd(entityKey, attack))
            throw new InvalidDataException("Card Sniper attack started twice.");
    }

    internal ArmyRusherTarget? CardSniperTarget(ulong entityKey)
    {
        if (rifleCombat == null || playerShotTargets == null || map == null ||
            !activeArmyEntities.TryGetValue(entityKey, out var entity) ||
            cardEnemyPoints?.Find(entityKey) is not { } point)
            return null;
        Player owner = Find(entity.OwnerPlayerId) ??
            throw new InvalidDataException("Card Sniper owner left the match.");
        Player opponent = players.Single(player => player != owner);
        if (opponent.Dead)
            return null;

        Vector3 origin = new(entity.X, entity.Y, entity.Z);
        // SoldierBehaviourSniper.PickTarget calls TryPickDecoy first.
        var enemyDecoys = decoys.Snapshot().Where(row =>
            row.OwnerFraction != entity.OwnerFraction).OrderBy(row => row.EntityId).ToArray();
        if (enemyDecoys.Length > 0)
        {
            int index = armyChoice(enemyDecoys.Length);
            if (index < 0 || index >= enemyDecoys.Length || decoySource == null)
                throw new InvalidDataException("Card Sniper Decoy choice lost source authority.");
            var decoy = enemyDecoys[index];
            float yaw = MathF.Atan2(decoy.Facing.X, decoy.Facing.Z);
            Quaternion rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, yaw);
            Vector3 position = decoy.Position + Vector3.Transform(
                decoySource.Prefab.TargetLocalPosition, rotation);
            return new ArmyRusherTarget(entityKey, decoy.OwnerPlayerId,
                decoySource.Prefab.TargetTransformFileId,
                point.ComponentFileId, position);
        }

        var pose = rifleCombat.Pose(opponent.Definition.PlayerId);
        if (opponent.Cover < 0 || opponent.Cover >= map.Covers.Count)
            return null;
        Vector3 aimForward = -Vector3.Transform(Vector3.UnitZ,
            map.Covers[opponent.Cover].Rotation);
        float shieldProbability = armyCatalog!.ShieldHitProbability(entity.UnitId);
        if (opponent.Route != null)
            shieldProbability *= .5f;
        int mask = HeavyTurretStationaryTargetMask(aimForward,
            origin - opponent.Position, shieldProbability, NextArmyFloat);
        bool shieldAvailable = shields?.Snapshot().Any(row =>
            row.CoverIndex == opponent.Cover && !row.Destroyed) ?? false;
        if (mask == 2 && shieldAvailable)
        {
            var shield = playerShotTargets.Gameplay.Single(row => row.Type == 2);
            return new ArmyRusherTarget(entityKey, opponent.Definition.PlayerId,
                shield.TransformFileId, point.ComponentFileId,
                map.Covers[opponent.Cover].ShotPosition);
        }
        if (opponent.Route != null && pose.MovingTarget is { } moving)
        {
            var source = playerShotTargets.Gameplay.Single(row => row.Type == 16);
            ArmyWeaponBindingCatalog weapons = armyWeapons ??
                throw new InvalidDataException("Card Sniper lacks source weapon aim speed.");
            Vector3 muzzle = weapons.RestMuzzleOrigin(entity.UnitId,
                origin, moving.Position - origin);
            float leadSeconds = Vector3.Distance(muzzle, moving.Position) /
                weapons.SniperPredictionSpeed + .2f;
            Vector3 predicted = moving.Position +
                leadSeconds * HeavyTurretPlayerVelocity(opponent);
            if (!PlayerHitbox.Finite(predicted))
                throw new InvalidDataException("Card Sniper moving target left scene bounds.");
            return new ArmyRusherTarget(entityKey, opponent.Definition.PlayerId,
                source.TransformFileId, point.ComponentFileId, predicted);
        }
        var body = playerShotTargets.Nearest(9, origin,
            candidate => pose.BodyTarget(candidate.TransformFileId).Position);
        return new ArmyRusherTarget(entityKey, opponent.Definition.PlayerId,
            body.TransformFileId, point.ComponentFileId,
            pose.BodyTarget(body.TransformFileId).Position);
    }

    private void AdvanceCardSniperAttacks()
    {
        rusherShotIntents.Clear();
        foreach (var (entityKey, attack) in sniperAttacks.OrderBy(row => row.Key))
        {
            if (!activeArmyEntities.TryGetValue(entityKey, out var entity) ||
                entity.SourceCardId != "ELITESNIPER" ||
                !snipersAtPoint.Contains(entityKey) || sniperWalks.ContainsKey(entityKey))
                throw new InvalidDataException("Card Sniper attack lost its arrived soldier.");
            if (attack.Phase == ArmyRusherAttackPhase.Ready)
            {
                ArmyRusherTarget? target = CardSniperTarget(entityKey);
                CardUnitInitialPoint point = cardEnemyPoints?.Find(entityKey) ??
                    throw new InvalidDataException("Card Sniper lost its Corner.");
                bool canExpose = target != null &&
                    point.CornerDirection is Vector3 direction &&
                    point.CornerRightSide is bool rightSide &&
                    CornerShotPolicy.CanExpose(direction, rightSide,
                        new Vector3(entity.X, entity.Y, entity.Z), target.Position);
                if (target != null && !canExpose)
                    attack.RetryAfterRejectedTarget();
                else if (canExpose)
                {
                    int windup = armyWeapons?.WindupTicks(entity.UnitId) ??
                        throw new InvalidDataException("Card Sniper lacks source windup.");
                    if (attack.TryBegin(true, 1, windup))
                    {
                        sniperShotTargets[entityKey] = target!;
                        sniperExposeTicks[entityKey] = tick;
                    }
                }
            }
            attack.AdvanceTick();
            if (!attack.ShotDue)
                continue;
            if (!sniperShotTargets.TryGetValue(entityKey, out var shot))
                throw new InvalidDataException("Card Sniper lost its latched target.");
            Vector3 muzzle = CardSniperFiringMuzzle(entityKey,
                shot.Position) ?? throw new InvalidDataException(
                    "Card Sniper shot has no source muzzle.");
            rusherShotIntents.Add(new ArmyRusherShotIntent(entityKey,
                entity.OwnerPlayerId, shot.PlayerId, shot.TargetFileId,
                shot.Position, attack.CurrentShotIsReal,
                attack.BatchCursor, attack.BatchSize, muzzle));
            // OnShot replays ShotFromCover and schedules the cover-back
            // transition half a second after the round leaves the muzzle.
            sniperLastShotTicks[entityKey] = tick;
            attack.CommitShot();
            if (attack.Phase == ArmyRusherAttackPhase.Cooldown)
                sniperShotTargets.Remove(entityKey);
        }
        LaunchRusherShotIntents();
    }

    private void AdvanceCardSniperCornerChanges()
    {
        if (cardEnemyPoints == null || armyCatalog == null)
            throw new InvalidDataException("Card Sniper has no point-change authority.");

        foreach (ulong entityKey in snipersAtPoint.Order().ToArray())
        {
            if (!sniperCornerChangeTicks.TryGetValue(entityKey,
                    out ulong changeTick) ||
                !activeArmyEntities.TryGetValue(entityKey, out var entity))
                throw new InvalidDataException("Card Sniper lost its Corner state.");
            if (tick <= changeTick)
                continue;
            if (sniperAttacks.TryGetValue(entityKey, out var attack) &&
                attack.Phase is ArmyRusherAttackPhase.Windup or ArmyRusherAttackPhase.Firing)
                continue;

            Player owner = Find(entity.OwnerPlayerId) ??
                throw new InvalidDataException("Card Sniper owner left the match.");
            Player opponent = players.Single(player => player != owner);
            IReadOnlyList<CardUnitInitialPoint> available =
                cardEnemyPoints.NextSniperPoints(entityKey,
                    entity.OwnerFraction, opponent.Position);
            if (available.Count == 0)
            {
                sniperCornerChangeTicks[entityKey] = checked(changeTick +
                    10u * MatchManifest.TickRate);
                continue;
            }

            int index = armyChoice(available.Count);
            if (index < 0 || index >= available.Count)
                throw new InvalidDataException("Invalid host Sniper point choice.");
            CardUnitInitialPoint next = available[index];
            Vector3 position = new(entity.X, entity.Y, entity.Z);
            ArmyNavMeshCorridor route = PlanCardSoldierRoute(
                position, next.Position);
            float speed = armyCatalog.EffectiveSpeed(entity.UnitId, 1f);
            var walk = new CardSoldierWalkState(next.ComponentFileId, route,
                armyCatalog.InfantryAgent, speed);

            cardEnemyPoints.Transfer(entityKey, "ELITESNIPER", next,
                opponent.Position);
            sniperCornerChangeTicks.Remove(entityKey);
            snipersAtPoint.Remove(entityKey);
            sniperAttacks.Remove(entityKey);
            sniperShotTargets.Remove(entityKey);
            sniperExposeTicks.Remove(entityKey);
            sniperLastShotTicks.Remove(entityKey);
            sniperWalks.Add(entityKey, walk);
        }
    }

    private void AdvanceCardSwatPointRetries()
    {
        foreach (var (entityKey, dueTick) in swatPointRetryTicks.ToArray())
        {
            if (tick < dueTick)
                continue;
            if (!activeArmyEntities.TryGetValue(entityKey, out var entity) ||
                entity.SourceCardId != "ELITESWAT")
                throw new InvalidDataException("Card SWAT retry lost its active soldier.");
            TryAssignCardSwatPoint(entity);
        }
    }

    private void AdvanceCardSwatWalks()
    {
        foreach (var (entityKey, walk) in swatWalks.OrderBy(row => row.Key).ToArray())
        {
            if (!activeArmyEntities.TryGetValue(entityKey, out var entity) ||
                entity.SourceCardId != "ELITESWAT" ||
                cardEnemyPoints?.Find(entityKey)?.ComponentFileId != walk.PointFileId)
                throw new InvalidDataException("Card SWAT walk lost its soldier or point.");

            walk.AdvanceTick();
            entity.X = walk.Position.X;
            entity.Y = walk.Position.Y;
            entity.Z = walk.Position.Z;
            entity.PositionTick = tick;
            cardUnitCombat?.UpdatePose(entity);
            if (walk.Arrived)
            {
                swatWalks.Remove(entityKey);
                StartCardSwatAttack(entityKey);
            }
        }
    }

    private void StartCardSwatAttack(ulong entityKey)
    {
        if (!armyShots.TryGetValue(entityKey, out ArmyBaseShotStats? shot) ||
            cardEnemyPoints?.Find(entityKey) == null)
            throw new InvalidDataException("Card SWAT reached no owned point or shot row.");
        int cadence = armyWeapons?.CadenceTicks("ID_UNIT-SWAT") ??
            throw new InvalidDataException("Card SWAT lacks source shot cadence.");
        var attack = new ArmyRusherAttackState(shot, NextArmyFloat, cadence,
            cooldownMinSeconds: 2f, cooldownMaxSeconds: 4f);
        // EnemyPointSwat enters Swat state on arrival. Its first
        // SwitchStateToSwat call sets mNextShootTime to mTime + 0.5f.
        attack.BeginInitialCooldown(0.5f, 0.5f);
        if (!swatAttacks.TryAdd(entityKey, attack))
            throw new InvalidDataException("Card SWAT attack started twice.");
    }

    private ArmyRusherTarget? CardSwatBodyTarget(ulong entityKey)
    {
        if (rifleCombat == null || playerShotTargets == null ||
            !activeArmyEntities.TryGetValue(entityKey, out var entity) ||
            cardEnemyPoints?.Find(entityKey) is not { } point)
            return null;
        Player owner = Find(entity.OwnerPlayerId) ??
            throw new InvalidDataException("Card SWAT owner left the match.");
        Player opponent = players.Single(player => player != owner);
        if (opponent.Dead)
            return null;

        var pose = rifleCombat.Pose(opponent.Definition.PlayerId);
        var position = new Vector3(entity.X, entity.Y, entity.Z);
        var target = playerShotTargets.Nearest(1, position,
            candidate => pose.BodyTarget(candidate.TransformFileId).Position);
        return new ArmyRusherTarget(entityKey, opponent.Definition.PlayerId,
            target.TransformFileId, point.ComponentFileId,
            pose.BodyTarget(target.TransformFileId).Position);
    }

    private void AdvanceCardSwatAttacks()
    {
        rusherShotIntents.Clear();
        foreach (var (entityKey, attack) in swatAttacks.OrderBy(row => row.Key))
        {
            if (!activeArmyEntities.TryGetValue(entityKey, out var entity) ||
                entity.SourceCardId != "ELITESWAT" || swatWalks.ContainsKey(entityKey))
                throw new InvalidDataException("Card SWAT attack lost its arrived soldier.");
            ArmyRusherTarget? target = CardSwatBodyTarget(entityKey);
            if (attack.Phase == ArmyRusherAttackPhase.Ready)
            {
                int windup = armyWeapons?.WindupTicks(entity.UnitId) ??
                    throw new InvalidDataException("Card SWAT lacks source windup.");
                if (attack.TryBegin(target != null, 1, windup))
                {
                    swatShotTargets[entityKey] = target!;
                    // ShootFromSwatShield keeps the shield exposed for five
                    // seconds before playing the recovered hide animation.
                    swatShieldHideTicks[entityKey] = checked(tick + 150);
                }
            }

            attack.AdvanceTick();
            if (!attack.ShotDue)
                continue;
            if (!swatShotTargets.TryGetValue(entityKey, out var shotTarget))
                throw new InvalidDataException("Card SWAT lost its latched shot target.");
            rusherShotIntents.Add(new ArmyRusherShotIntent(entityKey,
                entity.OwnerPlayerId, shotTarget.PlayerId,
                shotTarget.TargetFileId, shotTarget.Position,
                attack.CurrentShotIsReal, attack.BatchCursor, attack.BatchSize));
            swatLastShotTicks[entityKey] = tick;
            // EnemyController.OnShot repeats ShootFromSwatShield with a
            // half-second hide delay after the projectile leaves the muzzle.
            swatShieldHideTicks[entityKey] = checked(tick + 15);
            attack.CommitShot();
            if (attack.Phase == ArmyRusherAttackPhase.Cooldown)
                swatShotTargets.Remove(entityKey);
        }
        LaunchRusherShotIntents();
    }

    private void InitializeCardDrone(BattleArmyEntityState entity)
    {
        CardUnitEntity source = cardUnitEntities.Find(entity.LocalEntityId) ??
            throw new InvalidDataException("Card Drone lost its source spawn identity.");
        ArmyCardBaseStats card = source.BaseStats;
        ArmyCardDroneRuntime runtime = card.Drone ??
            throw new InvalidDataException("Card Drone lacks its recovered runtime constants.");
        if (source.EntityKey != entity.EntityKey ||
            source.SourceCardId != "HEAVYDRONE" ||
            entity.UnitId != "ID_UNIT-DRONE" ||
            runtime.CanTurnInvisible ||
            airWaypoints == null || map == null ||
            droneWeapon == null || droneProjectile == null || armyCatalog == null)
            throw new InvalidDataException("Card Drone cannot bind trusted flight authority.");

        var shot = new ArmyVehicleShotStats(runtime.ShotSpeed,
            card.Shot.ProbabilityOfRealShot,
            card.Shot.FireBatchSizeMin, card.Shot.FireBatchSizeMax,
            card.Shot.MinShootTime, card.Shot.MaxShootTime,
            0, runtime.ShieldHitProbability);
        var route = airWaypoints.ForSpawn(map, entity.SpawnComponentFileId);
        var position = new Vector3(entity.X, entity.Y, entity.Z);
        var family = CardSpawnUnitSourceCatalog.Family(armyCatalog,
            entity.SourceCardId);

        armyDamage.Add(entity.EntityKey, card.Combat.Damage);
        armySpeed.Add(entity.EntityKey, runtime.MovementSpeed);
        armyDroneShots.Add(entity.EntityKey, shot);
        armyDronePaths.Add(entity.EntityKey, new DroneWaypointState(
            route.Waypoints, route.JoinIndex, position, route.Radius,
            runtime.MovementSpeed, true, true, NextArmyFloat));
        droneAttacks.Add(entity.EntityKey, new DroneAttackState(
            (float)((double)tick / MatchManifest.TickRate), shot,
            droneWeapon, droneProjectile, NextArmyFloat, DroneBatchRange));
        RegisterDroneArmyTarget(entity.EntityKey, family);
    }

    private void InitializeCardMinigunner(BattleArmyEntityState entity)
    {
        CardUnitEntity source = cardUnitEntities.Find(entity.LocalEntityId) ??
            throw new InvalidDataException("Card Minigunner lost its source spawn identity.");
        if (source.EntityKey != entity.EntityKey ||
            source.SourceCardId != "ELITEMINIGUN" ||
            entity.UnitId != "ID_UNIT-MINIGUNNER" || armyCatalog == null)
            throw new InvalidDataException("Card Minigunner cannot bind host combat authority.");

        // CardSpawnUnit loads CARDS_MIN/MAX, not the owner's ordinary army
        // upgrade lanes. The existing Minigunner movement and attack clocks
        // can use these card-specific damage and shot values.
        armyDamage.Add(entity.EntityKey, source.BaseStats.Combat.Damage);
        armyShots.Add(entity.EntityKey, source.BaseStats.Shot);
        InitializeStationaryArmyCombat(entity.EntityKey, entity.UnitId);
    }

    private bool ConfirmCardUnitDeath(ulong entityKey, bool suicide)
    {
        if (!activeArmyEntities.TryGetValue(entityKey, out var entity) ||
            entity.SourceCardId.Length == 0 || cardUnitCombat == null)
            return false;
        if (!EventCapacityForArmyDeath())
        {
            End("army-event-backpressure", "", false);
            return false;
        }

        BattleArmyEntityState? authoritative = cardUnitCombat.Find(entityKey);
        if (authoritative == null ||
            authoritative.OwnerPlayerId != entity.OwnerPlayerId ||
            authoritative.SourceCardId != entity.SourceCardId ||
            authoritative.Health != entity.Health ||
            authoritative.Kevlar != entity.Kevlar ||
            authoritative.MaxKevlar != entity.MaxKevlar)
            throw new InvalidDataException("Card-unit death lost its roster proof.");
        if (cardUnitCombat.ConfirmDeath(entityKey) is not { Died: true })
            throw new InvalidDataException("Card-unit death did not remove its health authority.");
        if (!activeArmyEntities.Remove(entityKey))
            throw new InvalidDataException("Card-unit death lost its public roster row.");
        infantryAnimations.Remove(entityKey);

        // Card Drone uses the same host flight/weapon systems as an ordinary
        // Drone, but its stats came from CardSpawnUnit's source rows.
        if (entity.SourceCardId == "HEAVYDRONE")
        {
            if (droneArmyTargets.Remove(entityKey))
                droneTargets.Disable(DroneArmyId(entityKey));
            armyDronePaths.Remove(entityKey);
            armyDroneShots.Remove(entityKey);
            droneAttacks.Remove(entityKey);
            droneLastIntents.Remove(entityKey);
            armyDamage.Remove(entityKey);
            armySpeed.Remove(entityKey);
        }
        if (entity.SourceCardId == "ELITEMINIGUN")
        {
            if (minigunnerPointByEntity.Remove(entityKey, out int pointId))
            {
                if (!occupiedMinigunnerPoints.TryGetValue(pointId, out ulong occupant) ||
                    occupant != entityKey || !occupiedMinigunnerPoints.Remove(pointId))
                    throw new InvalidDataException("Card Minigunner lost its destination reservation.");
            }
            minigunnerMovements.Remove(entityKey);
            minigunnerSteering.Remove(entityKey);
            minigunnerAttacks.Remove(entityKey);
            minigunnerPointChangeTicks.Remove(entityKey);
            minigunnerAttackTargets.Remove(entityKey);
            rusherShotCounts.Remove(entityKey);
            armyDamage.Remove(entityKey);
            armyShots.Remove(entityKey);
        }
        if (entity.SourceCardId == "ELITESWAT")
        {
            swatPointRetryTicks.Remove(entityKey);
            swatWalks.Remove(entityKey);
            swatAttacks.Remove(entityKey);
            swatShotTargets.Remove(entityKey);
            swatLastShotTicks.Remove(entityKey);
            swatShieldHideTicks.Remove(entityKey);
            rusherShotCounts.Remove(entityKey);
            armyDamage.Remove(entityKey);
            armyShots.Remove(entityKey);
            cardEnemyPoints?.Release(entityKey);
        }
        if (entity.SourceCardId == "ELITESNIPER")
        {
            sniperPointRetryTicks.Remove(entityKey);
            sniperWalks.Remove(entityKey);
            snipersAtPoint.Remove(entityKey);
            sniperCornerChangeTicks.Remove(entityKey);
            sniperAttacks.Remove(entityKey);
            sniperShotTargets.Remove(entityKey);
            sniperExposeTicks.Remove(entityKey);
            sniperLastShotTicks.Remove(entityKey);
            rusherShotCounts.Remove(entityKey);
            armyDamage.Remove(entityKey);
            armyShots.Remove(entityKey);
            cardEnemyPoints?.Release(entityKey);
        }
        if (entity.SourceCardId == "ELITEPARA")
        {
            parachuteFlights.Remove(entityKey);
            paratrooperAirAttacks.Remove(entityKey);
            paratrooperAirShotTargets.Remove(entityKey);
            paratrooperAirShotStartTicks.Remove(entityKey);
            paratrooperWalks.Remove(entityKey);
            paratrooperFallbackWalks.Remove(entityKey);
            paratrooperPointRetryTicks.Remove(entityKey);
            paratrooperAttacks.Remove(entityKey);
            paratrooperShotTargets.Remove(entityKey);
            paratrooperExposeTicks.Remove(entityKey);
            paratrooperLastShotTicks.Remove(entityKey);
            paratrooperCornerChangeTicks.Remove(entityKey);
            rusherShotCounts.Remove(entityKey);
            armyDamage.Remove(entityKey);
            armyShots.Remove(entityKey);
            cardEnemyPoints?.Release(entityKey);
        }

        armyEntityRevision++;
        stateRevision++;
        Emit(MatchEventKind.ArmyDied, "", entity.OwnerPlayerId, 0,
            new(entity.X, entity.Y, entity.Z), 0,
            suicide ? "suicide" : "combat");
        MatchEvent deathEvent = events[^1];
        deathEvent.ArmyEntityId = entity.LocalEntityId;
        deathEvent.ArmyOptionIndex = -1;
        deathEvent.ArmyUnitId = entity.UnitId;
        deathEvent.ArmySpawnComponentFileId = entity.SpawnComponentFileId;
        deathEvent.ArmyReservationFileId = entity.ReservationFileId;
        deathEvent.SourceCardId = entity.SourceCardId;
        if (entity.SourceCardId == "ELITEPARA" &&
            paratrooperLandingTicks.TryGetValue(entityKey, out ulong landingTick))
        {
            if (!paratrooperLandingPositions.TryGetValue(entityKey, out Vector3 position) ||
                !paratrooperLandingRotations.TryGetValue(entityKey, out Quaternion rotation) ||
                !PlayerHitbox.Finite(position) || landingTick > tick)
                throw new InvalidDataException("Dead Paratrooper lost its landing pose.");
            if (tick - landingTick < 3u * MatchManifest.TickRate)
            {
                deathEvent.ParachuteEntityKey = entityKey;
                deathEvent.ParachuteLandingTick = landingTick;
                deathEvent.ParachuteRotation = ParachuteWireRotation(rotation);
                deathEvent.ParachuteLandingX = position.X;
                deathEvent.ParachuteLandingY = position.Y;
                deathEvent.ParachuteLandingZ = position.Z;
            }
        }
        paratrooperLandingTicks.Remove(entityKey);
        paratrooperLandingRotations.Remove(entityKey);
        paratrooperLandingPositions.Remove(entityKey);
        return true;
    }
}

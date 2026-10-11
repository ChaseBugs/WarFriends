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
    private readonly Dictionary<ulong, CardSoldierWalkState> paratrooperWalks = [];
    private readonly Dictionary<ulong, CardParachuteFlightState> parachuteFlights = [];
    private readonly Dictionary<ulong, ArmyRusherAttackState> paratrooperAirAttacks = [];
    private readonly Dictionary<ulong, ArmyRusherTarget> paratrooperAirShotTargets = [];
    private readonly Dictionary<ulong, ulong> paratrooperAirShotStartTicks = [];
    private readonly Dictionary<ulong, CardSoldierWalkState> paratrooperFallbackWalks = [];
    private readonly Dictionary<ulong, ulong> paratrooperPointRetryTicks = [];
    private readonly Dictionary<ulong, ArmyRusherAttackState> paratrooperAttacks = [];
    private readonly Dictionary<ulong, ArmyRusherTarget> paratrooperShotTargets = [];
    private readonly Dictionary<ulong, ArmyRusherAttackState> swatAttacks = [];
    private readonly Dictionary<ulong, ArmyRusherTarget> swatShotTargets = [];

    internal CardUnitInitialPoint? CardEnemyPoint(ulong entityKey) =>
        cardEnemyPoints?.Find(entityKey);

    internal ulong? CardEnemyPointOccupant(int pointFileId) =>
        cardEnemyPoints?.Occupant(pointFileId);

    internal bool CardSwatWalking(ulong entityKey) => swatWalks.ContainsKey(entityKey);

    internal bool CardSwatAttacking(ulong entityKey) => swatAttacks.ContainsKey(entityKey);

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
            if (entity.SourceCardId == "HEAVYDRONE")
                InitializeCardDrone(entity);
            if (entity.SourceCardId == "ELITEMINIGUN")
                InitializeCardMinigunner(entity);
            if (entity.SourceCardId == "ELITEPARA")
                InitializeCardParatrooper(entity);
            if (entity.SourceCardId == "ELITESWAT")
                InitializeCardSwat(entity);
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
                parachuteFlights.Remove(entityKey);
            return beganFallback;
        }
        try
        {
            ArmyNavMeshCorridor route = PlanCardParatrooperRoute(
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

    private ArmyNavMeshCorridor PlanCardParatrooperRoute(Vector3 startPosition,
        Vector3 destinationPosition)
    {
        if (map == null || armyNavMeshConnectivity == null)
            throw new InvalidDataException("Card Paratrooper has no source navigation map.");
        // Scene transforms and the collision contact sit slightly above the
        // baked NavMesh. Unity's agent projects both to its surface.
        Vector3 start = armyNavMeshConnectivity.SampleNearest(map,
            startPosition, 1.25f) ??
            throw new InvalidDataException("Card Paratrooper landed outside the NavMesh.");
        Vector3 destination = armyNavMeshConnectivity.SampleNearest(map,
            destinationPosition, 0.5f) ??
            throw new InvalidDataException("Card Paratrooper destination lies outside the NavMesh.");
        ArmyNavMeshCorridor route = armyNavMeshConnectivity.PlanCorridor(
            map, start, destination) ??
            throw new InvalidDataException("Card Paratrooper has no NavMesh corridor.");
        if (!route.PlanarCovered)
            throw new InvalidDataException("Card Paratrooper corridor leaves the source NavMesh.");
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
        ArmyNavMeshCorridor route = PlanCardParatrooperRoute(
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
                ArmyNavMeshCorridor route = PlanCardParatrooperRoute(
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
                    paratrooperShotTargets[entityKey] = target;
            }

            attack.AdvanceTick();
            if (!attack.ShotDue)
                continue;
            if (!paratrooperShotTargets.TryGetValue(entityKey, out var shotTarget))
                throw new InvalidDataException("Card Paratrooper lost its latched shot target.");
            rusherShotIntents.Add(new ArmyRusherShotIntent(entityKey,
                entity.OwnerPlayerId, shotTarget.PlayerId,
                shotTarget.TargetFileId, shotTarget.Position,
                attack.CurrentShotIsReal, attack.BatchCursor, attack.BatchSize));
            attack.CommitShot();
            if (attack.Phase == ArmyRusherAttackPhase.Cooldown)
                paratrooperShotTargets.Remove(entityKey);
        }
        LaunchRusherShotIntents();
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
                    swatShotTargets[entityKey] = target!;
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
            authoritative.Health != entity.Health)
            throw new InvalidDataException("Card-unit death lost its roster proof.");
        if (cardUnitCombat.ApplyHostDamage(entityKey, entity.Health) is not
            { Died: true })
            throw new InvalidDataException("Card-unit death did not remove its health authority.");
        if (!activeArmyEntities.Remove(entityKey))
            throw new InvalidDataException("Card-unit death lost its public roster row.");

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
        return true;
    }
}

using System.Numerics;
using War.Protocol;

namespace War.BattleServer;

internal sealed record CardRocketShotIntent(ulong EntityKey, ulong Tick,
    Vector3 TargetPosition, Vector3 MuzzlePosition, bool IsReal,
    int ShotIndex, int BatchSize);

internal sealed record CardRocketLaunchAuthority(string OwnerPlayerId,
    ArmyCardRocketRuntime Missile, ArmyPlayerDamagePolicy PlayerPolicy);
internal sealed record CardGrenadierLaunchAuthority(string OwnerPlayerId,
    ArmyGrenadeDamageStats Damage, ArmyCardGrenadierRuntime Setup,
    ArmyPlayerDamagePolicy PlayerPolicy);

public sealed partial class MatchEngine
{
    internal sealed record CardGrenadierMovingAim(Vector3? Muzzle, Vector3 TargetPosition,
        Vector3 Velocity, float FlightSeconds);
    internal sealed record CardGrenadierAim(ArmyRusherTarget Target,
        bool ThrowGrenade)
    {
        internal CardGrenadierMovingAim? Moving { get; init; }
    }
    internal sealed record CardGrenadierShotIntent(ulong EntityKey,
        ulong Tick, CardGrenadierAim Aim, bool IsReal, int ShotIndex,
        int BatchSize, Vector3? GrenadeMuzzlePosition,
        Vector3? GrenadeLaunchVelocity);

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
    private sealed record LandedCanopy(ulong LandingTick, Vector3 Position,
        Quaternion Rotation);
    private readonly Dictionary<ulong, LandedCanopy> deadParatrooperCanopies = [];
    private readonly Dictionary<ulong, ArmyCardRocketRuntime> cardRocketMissiles = [];
    private readonly Dictionary<ulong, ArmyCardGrenadierRuntime> cardGrenadierThrows = [];
    private readonly Dictionary<ulong, ArmyGrenadeDamageStats> _cardGrenadierDamage = [];
    private readonly Dictionary<ulong, ulong> grenadierPointRetryTicks = [];
    private readonly Dictionary<ulong, CardSoldierWalkState> grenadierWalks = [];
    private readonly Dictionary<ulong, ArmyRusherAttackState> grenadierAttacks = [];
    private readonly Dictionary<ulong, CardGrenadierAim> grenadierShotTargets = [];
    private readonly List<CardGrenadierShotIntent> grenadierShotIntents = [];
    private readonly Dictionary<ulong, CardGrenadierFlight> grenadierFlights = [];
    private readonly Dictionary<ulong, CardGrenadierLaunchAuthority>
        grenadierLaunches = [];
    private readonly List<CardGrenadierExplosion> grenadierExplosions = [];
    private readonly Dictionary<ulong, ulong> grenadierCornerChangeTicks = [];
    private readonly Dictionary<ulong, ulong> rocketPointRetryTicks = [];
    private readonly Dictionary<ulong, CardSoldierWalkState> rocketWalks = [];
    private readonly Dictionary<ulong, ArmyRusherAttackState> rocketAttacks = [];
    private readonly Dictionary<ulong, Vector3> rocketShotTargets = [];
    private readonly List<CardRocketShotIntent> rocketShotIntents = [];
    private readonly Dictionary<ulong, CardRocketMissileFlight> rocketFlights = [];
    private readonly Dictionary<ulong, CardRocketLaunchAuthority> rocketLaunches = [];
    private readonly List<CardRocketMissileImpact> rocketImpacts = [];
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
            !IsSniper(entity) ||
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
                "ELITESNIPER" or "ELITEPARA" or "BIGROCKET" or
                "GREATGRENADIER")
                InitializeInfantryAnimation(entity.EntityKey);
            if (entity.SourceCardId == "HEAVYDRONE")
                InitializeCardDrone(entity);
            if (entity.SourceCardId == "BIGROCKET")
                InitializeCardRocket(entity);
            if (entity.SourceCardId == "GREATGRENADIER")
                InitializeCardGrenadier(entity);
            if (entity.SourceCardId == "ELITEMINIGUN")
                InitializeCardMinigunner(entity);
            if (entity.SourceCardId == "ELITEPARA")
                InitializeCardParatrooper(entity);
            if (entity.SourceCardId == "ELITESWAT")
                InitializeCardSwat(entity);
            if (entity.SourceCardId == "ELITESNIPER")
                InitializeCardSniper(entity);
            var family = armyCatalog!.Families.Single(candidate => candidate.UnitId == entity.UnitId);
            RegisterDroneArmyTarget(entity.EntityKey, family);
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
            candidate => pose.BodyTargetPosition(candidate.TransformFileId));
        Vector3 targetPosition = pose.BodyTargetPosition(target.TransformFileId);
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
        TryAssignSniperPoint(entity);
    }

    private void InitializeNormalSniper(ulong entityKey)
    {
        if (!activeArmyEntities.TryGetValue(entityKey, out var entity) ||
            entity.UnitId != "ID_UNIT-SNIPER" || entity.SourceCardId.Length != 0 ||
            !armyShots.ContainsKey(entityKey))
            throw new InvalidDataException("Normal Sniper lacks its source shot and spawn authority.");

        // The ordinary deployment composes its upgrade rows before entering
        // the shared Sniper point and attack lifecycle. The elite card instead
        // uses its separately recovered row-zero fallback.
        if (!rusherShotCounts.TryAdd(entityKey, 0))
            throw new InvalidDataException("Normal Sniper shot counter already exists.");
        TryAssignSniperPoint(entity);
    }

    private static bool IsSniper(BattleArmyEntityState entity) =>
        entity.UnitId == "ID_UNIT-SNIPER" &&
        entity.SourceCardId is "" or "ELITESNIPER";

    private void TryAssignSniperPoint(BattleArmyEntityState entity)
    {
        if (cardEnemyPoints == null || armyCatalog == null ||
            !IsSniper(entity))
            throw new InvalidDataException("Sniper has no source point authority.");
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
                !IsSniper(entity))
                throw new InvalidDataException("Sniper retry lost its soldier.");
            TryAssignSniperPoint(entity);
        }
    }

    private void AdvanceCardSniperWalks()
    {
        foreach (var (entityKey, walk) in sniperWalks
            .OrderBy(row => row.Key).ToArray())
        {
            if (!activeArmyEntities.TryGetValue(entityKey, out var entity) ||
                !IsSniper(entity) ||
                cardEnemyPoints?.Find(entityKey)?.ComponentFileId !=
                    walk.PointFileId)
                throw new InvalidDataException("Card Sniper walk lost its point.");
            walk.AdvanceTick();
            entity.X = walk.Position.X;
            entity.Y = walk.Position.Y;
            entity.Z = walk.Position.Z;
            entity.PositionTick = tick;
            if (entity.SourceCardId == "ELITESNIPER")
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

    // SoldierBehaviour.PickPlayerOpponent uses Random.value <= shieldProb.
    // TurretWeaponBasic uses < instead, so its equal-value branch stays in
    // HeavyTurretStationaryTargetMask rather than changing both families.
    internal static int SoldierStationaryTargetMask(Vector3 aimForward,
        Vector3 towardSoldier, float shieldProbability, Func<float> random)
    {
        if (!PlayerHitbox.Finite(aimForward) ||
            !PlayerHitbox.Finite(towardSoldier) ||
            aimForward.LengthSquared() == 0 ||
            towardSoldier.LengthSquared() == 0 ||
            !float.IsFinite(shieldProbability) ||
            shieldProbability is < 0 or > 1)
            throw new InvalidDataException("Invalid soldier target selection authority.");
        float facing = Vector3.Dot(Vector3.Normalize(aimForward),
            Vector3.Normalize(towardSoldier));
        if (facing < MathF.Cos(50 * MathF.PI / 180)) return 2;
        float value = random();
        if (!float.IsFinite(value) || value is < 0 or >= 1)
            throw new InvalidDataException("Invalid soldier target random value.");
        return value <= shieldProbability ? 2 : 9;
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
        int mask = SoldierStationaryTargetMask(aimForward,
            origin - opponent.Position, shieldProbability, NextArmyFloat);
        // GetShotTargets(Shield) keeps the source aim transform even when
        // its shield collider is destroyed. Collision decides what the shot hits.
        if (mask == 2)
        {
            var shield = playerShotTargets.Gameplay.Single(row => row.Type == 2);
            return new ArmyRusherTarget(entityKey, opponent.Definition.PlayerId,
                shield.TransformFileId, point.ComponentFileId,
                ArmyShieldShotTarget(opponent));
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
            candidate => pose.BodyTargetPosition(candidate.TransformFileId));
        return new ArmyRusherTarget(entityKey, opponent.Definition.PlayerId,
            body.TransformFileId, point.ComponentFileId,
            pose.BodyTargetPosition(body.TransformFileId));
    }

    private void AdvanceCardSniperAttacks()
    {
        rusherShotIntents.Clear();
        foreach (var (entityKey, attack) in sniperAttacks.OrderBy(row => row.Key))
        {
            if (!activeArmyEntities.TryGetValue(entityKey, out var entity) ||
                !IsSniper(entity) ||
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

            // Both spawn paths use the same recovered Sniper point mask.
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

    private void ReleaseNormalSniperPoint(ulong entityKey)
    {
        sniperPointRetryTicks.Remove(entityKey);
        sniperWalks.Remove(entityKey);
        snipersAtPoint.Remove(entityKey);
        sniperCornerChangeTicks.Remove(entityKey);
        sniperAttacks.Remove(entityKey);
        sniperShotTargets.Remove(entityKey);
        sniperExposeTicks.Remove(entityKey);
        sniperLastShotTicks.Remove(entityKey);
        cardEnemyPoints?.Release(entityKey);
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
            candidate => pose.BodyTargetPosition(candidate.TransformFileId));
        return new ArmyRusherTarget(entityKey, opponent.Definition.PlayerId,
            target.TransformFileId, point.ComponentFileId,
            pose.BodyTargetPosition(target.TransformFileId));
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

        armyDamage.Add(entity.EntityKey, card.Combat.Damage);
        armySpeed.Add(entity.EntityKey, runtime.MovementSpeed);
        armyDroneShots.Add(entity.EntityKey, shot);
        armyDronePaths.Add(entity.EntityKey, new DroneWaypointState(
            route.Waypoints, route.JoinIndex, position, route.Radius,
            runtime.MovementSpeed, true, true, NextArmyFloat));
        droneAttacks.Add(entity.EntityKey, new DroneAttackState(
            (float)((double)tick / MatchManifest.TickRate), shot,
            droneWeapon, droneProjectile, NextArmyFloat, DroneBatchRange));
    }

    private void InitializeCardRocket(BattleArmyEntityState entity)
    {
        CardUnitEntity source = cardUnitEntities.Find(entity.LocalEntityId) ??
            throw new InvalidDataException("Card Rocket Soldier lost its spawn identity.");
        if (source.EntityKey != entity.EntityKey ||
            source.SourceCardId != "BIGROCKET" ||
            entity.UnitId != "ID_UNIT-ROCKETSOLDIER" ||
            source.BaseStats.Rocket is not { } missile)
            throw new InvalidDataException("Card Rocket Soldier lacks source missile setup.");
        if (!cardRocketMissiles.TryAdd(entity.EntityKey, missile))
            throw new InvalidDataException("Card Rocket Soldier reused its missile identity.");
        TryAssignCardRocketPoint(entity);
    }

    internal ArmyCardRocketRuntime? CardRocketMissile(ulong entityKey) =>
        cardRocketMissiles.GetValueOrDefault(entityKey);

    private void InitializeCardGrenadier(BattleArmyEntityState entity)
    {
        CardUnitEntity source = cardUnitEntities.Find(entity.LocalEntityId) ??
            throw new InvalidDataException("Card Grenadier lost its spawn identity.");
        if (source.EntityKey != entity.EntityKey ||
            source.SourceCardId != "GREATGRENADIER" ||
            entity.UnitId != "ID_UNIT-GRENADIER" ||
            source.BaseStats.Grenade is null ||
            source.BaseStats.Grenadier is not { } throwSetup)
            throw new InvalidDataException("Card Grenadier lacks its grenade setup.");
        if (!cardGrenadierThrows.TryAdd(entity.EntityKey, throwSetup))
            throw new InvalidDataException("Card Grenadier reused its throw identity.");
        _cardGrenadierDamage.Add(entity.EntityKey, source.BaseStats.Grenade);
        armyShots.Add(entity.EntityKey, source.BaseStats.Shot);
        armyDamage.Add(entity.EntityKey, source.BaseStats.Combat.Damage);
        TryAssignCardGrenadierPoint(entity);
    }

    internal ArmyCardGrenadierRuntime? CardGrenadierThrow(ulong entityKey) =>
        cardGrenadierThrows.GetValueOrDefault(entityKey);

    internal CardGrenadierAim? CardGrenadierChooseTarget(ulong entityKey)
    {
        if (rifleCombat == null || playerShotTargets == null || map == null ||
            armyCatalog == null || armyWeapons == null ||
            !activeArmyEntities.TryGetValue(entityKey, out var entity) ||
            !IsGrenadier(entity) ||
            grenadierWalks.ContainsKey(entityKey) ||
            cardEnemyPoints?.Find(entityKey) is not { } point ||
            !cardGrenadierThrows.TryGetValue(entityKey, out var setup))
            return null;

        Player owner = Find(entity.OwnerPlayerId) ??
            throw new InvalidDataException("Card Grenadier owner left the match.");
        Player opponent = players.Single(player => player != owner);
        if (opponent.Dead) return null;

        // PickTarget chooses the secondary weapon before its Decoy/player
        // branch. The card has both source weapons and no external weapon.
        bool shouldSelectSecondary = setup.ShouldThrowGrenade(NextArmyFloat(), false);
        if (shouldSelectSecondary)
        {
            // Source PickTarget switches before Decoy/player selection and Corner exposure checks.
            _grenadierWeapons.SelectSecondary(entityKey);
        }

        // A failed target/exposure attempt does not switch the recovered inventory back to its primary weapon.
        bool throwGrenade = _grenadierWeapons.IsSecondary(entityKey);
        Vector3 origin = new(entity.X, entity.Y, entity.Z);
        var enemyDecoys = decoys.Snapshot().Where(row =>
            row.OwnerFraction != entity.OwnerFraction)
            .OrderBy(row => row.EntityId).ToArray();
        if (enemyDecoys.Length > 0)
        {
            int index = armyChoice(enemyDecoys.Length);
            if (index < 0 || index >= enemyDecoys.Length || decoySource == null)
                throw new InvalidDataException("Card Grenadier Decoy choice is invalid.");
            var decoy = enemyDecoys[index];
            float yaw = MathF.Atan2(decoy.Facing.X, decoy.Facing.Z);
            Quaternion rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, yaw);
            Vector3 position = decoy.Position + Vector3.Transform(
                decoySource.Prefab.TargetLocalPosition, rotation);
            return new CardGrenadierAim(new ArmyRusherTarget(entityKey,
                decoy.OwnerPlayerId, decoySource.Prefab.TargetTransformFileId,
                point.ComponentFileId, position), throwGrenade);
        }

        if (opponent.Cover < 0 || opponent.Cover >= map.Covers.Count)
            return null;
        var pose = rifleCombat.Pose(opponent.Definition.PlayerId);
        Vector3 aimForward = -Vector3.Transform(Vector3.UnitZ,
            map.Covers[opponent.Cover].Rotation);
        float shieldProbability = armyCatalog.ShieldHitProbability(entity.UnitId);
        if (opponent.Route != null) shieldProbability *= .5f;
        int mask = SoldierStationaryTargetMask(aimForward,
            origin - opponent.Position, shieldProbability, NextArmyFloat);
        // The Client selects the Shield shot target independently of its health.
        if (mask == 2)
        {
            var shield = playerShotTargets.Gameplay.Single(row => row.Type == 2);
            return new CardGrenadierAim(new ArmyRusherTarget(entityKey,
                opponent.Definition.PlayerId, shield.TransformFileId,
                point.ComponentFileId,
                ArmyShieldShotTarget(opponent)), throwGrenade);
        }

        if (opponent.Route != null && pose.MovingTarget is { } moving)
        {
            var source = playerShotTargets.Gameplay.Single(row => row.Type == 16);
            Vector3 velocity = HeavyTurretPlayerVelocity(opponent);
            float flySeconds = GrenadierAimingPaddingSeconds;
            Vector3? acquisitionMuzzle = null;
            if (!throwGrenade)
            {
                Vector3 muzzle = CardGrenadierAcquisitionMuzzle(entityKey);
                acquisitionMuzzle = muzzle;
                // PistolEnemy BulletSetup speed is 5. Gun adds .1 seconds;
                // PickPlayerOpponent passes another .1 to AimingHelper.
                flySeconds += Vector3.Distance(muzzle, moving.Position) / GrenadierPrimaryWeapon.Instance.Speed +
                    GrenadierGunPaddingSeconds;
            }
            Vector3 predicted = moving.Position + flySeconds * velocity;
            if (!PlayerHitbox.Finite(predicted))
                throw new InvalidDataException("Card Grenadier moving aim left the map.");
            return new CardGrenadierAim(new ArmyRusherTarget(entityKey,
                opponent.Definition.PlayerId, source.TransformFileId,
                point.ComponentFileId, predicted), throwGrenade)
            {
                // Acquisition precedes the next player-animation sample. Retain these
                // exact inputs so a later pose cannot redefine the already latched aim.
                Moving = new CardGrenadierMovingAim(acquisitionMuzzle, moving.Position, velocity, flySeconds)
            };
        }

        var body = playerShotTargets.Nearest(9, origin,
            candidate => pose.BodyTargetPosition(candidate.TransformFileId));
        return new CardGrenadierAim(new ArmyRusherTarget(entityKey,
            opponent.Definition.PlayerId, body.TransformFileId,
            point.ComponentFileId,
            pose.BodyTargetPosition(body.TransformFileId)), throwGrenade);
    }

    internal bool CardGrenadierWalking(ulong entityKey) =>
        grenadierWalks.ContainsKey(entityKey);

    private void TryAssignCardGrenadierPoint(BattleArmyEntityState entity)
    {
        if (!IsGrenadier(entity) ||
            cardEnemyPoints == null || armyCatalog == null)
            throw new InvalidDataException("Card Grenadier has no source point authority.");

        Vector3 position = new(entity.X, entity.Y, entity.Z);
        // Both variants use the same source family mask 14; this key selects point policy, not actor identity.
        CardUnitInitialPoint? point = cardEnemyPoints.TryAssign(
            entity.EntityKey, "GREATGRENADIER", entity.OwnerFraction, position);
        if (point == null)
        {
            // EnemyController.GenerateInitPoint retries after five seconds.
            grenadierPointRetryTicks[entity.EntityKey] = checked(tick +
                5u * MatchManifest.TickRate);
            return;
        }

        try
        {
            ArmyNavMeshCorridor route = PlanCardSoldierRoute(position,
                point.Position);
            float speed = ArmySpeed(entity.EntityKey) ?? armyCatalog.EffectiveSpeed(entity.UnitId, 1f);
            grenadierWalks.Add(entity.EntityKey, new CardSoldierWalkState(
                point.ComponentFileId, route, armyCatalog.InfantryAgent, speed));
            grenadierPointRetryTicks.Remove(entity.EntityKey);
        }
        catch
        {
            cardEnemyPoints.Release(entity.EntityKey);
            throw;
        }
    }

    private void AdvanceCardGrenadierPointRetries()
    {
        foreach (var (entityKey, dueTick) in grenadierPointRetryTicks
            .OrderBy(row => row.Key).ToArray())
        {
            if (tick < dueTick) continue;
            if (!activeArmyEntities.TryGetValue(entityKey, out var entity) ||
                !IsGrenadier(entity))
                throw new InvalidDataException("Card Grenadier retry lost its soldier.");
            TryAssignCardGrenadierPoint(entity);
        }
    }

    private void AdvanceCardGrenadierWalks()
    {
        foreach (var (entityKey, walk) in grenadierWalks
            .OrderBy(row => row.Key).ToArray())
        {
            if (!activeArmyEntities.TryGetValue(entityKey, out var entity) ||
                !IsGrenadier(entity) ||
                cardEnemyPoints?.Find(entityKey)?.ComponentFileId != walk.PointFileId)
                throw new InvalidDataException("Card Grenadier walk lost its point.");

            walk.AdvanceTick();
            entity.X = walk.Position.X;
            entity.Y = walk.Position.Y;
            entity.Z = walk.Position.Z;
            entity.PositionTick = tick;
            if (entity.SourceCardId.Length > 0)
            {
                cardUnitCombat?.UpdatePose(entity);
            }
            if (walk.Arrived)
            {
                grenadierWalks.Remove(entityKey);
                StartCardGrenadierAttack(entityKey);
            }
        }
    }

    private void StartCardGrenadierAttack(ulong entityKey)
    {
        CardUnitInitialPoint point = cardEnemyPoints?.Find(entityKey) ??
            throw new InvalidDataException("Card Grenadier reached no Corner.");
        if (!activeArmyEntities.TryGetValue(entityKey, out var entity) ||
            point.ComponentType != "EnemyPointCorner")
            throw new InvalidDataException("Card Grenadier reached no valid Corner.");
        if (!IsGrenadier(entity) || !armyShots.TryGetValue(entityKey, out ArmyBaseShotStats? shot))
            throw new InvalidDataException("Grenadier lost its composed shot authority.");

        // SoldierBehaviour.ApplyWeaponsSetup replaces the pistol cadence
        // with 0.35 seconds. A selected grenade has only one shot.
        var attack = new ArmyRusherAttackState(shot,
            NextArmyFloat, shotIntervalTicks:
                (int)MathF.Ceiling(.35f * MatchManifest.TickRate));
        attack.BeginInitialCooldown();
        if (!grenadierAttacks.TryAdd(entityKey, attack))
            throw new InvalidDataException("Card Grenadier attack started twice.");
        int waitSeconds = 10 + armyChoice(10);
        if (waitSeconds is < 10 or > 19 ||
            !grenadierCornerChangeTicks.TryAdd(entityKey,
                checked(tick + (ulong)waitSeconds * MatchManifest.TickRate)))
            throw new InvalidDataException("Card Grenadier lost its Corner clock.");
    }

    private void AdvanceCardGrenadierAttacks()
    {
        grenadierShotIntents.Clear();
        foreach (var (entityKey, attack) in grenadierAttacks
            .OrderBy(row => row.Key))
        {
            if (!activeArmyEntities.TryGetValue(entityKey, out var entity) ||
                !IsGrenadier(entity) ||
                grenadierWalks.ContainsKey(entityKey) ||
                cardEnemyPoints?.Find(entityKey) is not { } point ||
                point.ComponentType != "EnemyPointCorner" ||
                point.CornerDirection is not Vector3 direction ||
                point.CornerRightSide is not bool rightSide)
                throw new InvalidDataException("Card Grenadier attack lost its Corner.");

            if (attack.Phase == ArmyRusherAttackPhase.Ready)
            {
                CardGrenadierAim? aim = CardGrenadierChooseTarget(entityKey);
                if (aim != null)
                {
                    Vector3 origin = new(entity.X, entity.Y, entity.Z);
                    if (!CornerShotPolicy.CanExpose(direction, rightSide,
                            origin, aim.Target.Position))
                        attack.RetryAfterRejectedTarget();
                    else if (attack.TryBegin(true, 1,
                                 aim.ThrowGrenade ? (int)MathF.Ceiling(.7f * MatchManifest.TickRate) :
                                     GrenadierCornerMuzzleCatalog.FirstShotDelayTicks,
                                 singleShot: aim.ThrowGrenade))
                        grenadierShotTargets[entityKey] = aim;
                }
            }

            attack.AdvanceTick();
            if (!attack.ShotDue) continue;
            if (!grenadierShotTargets.TryGetValue(entityKey, out var shot))
                throw new InvalidDataException("Card Grenadier lost its latched target.");
            // Shooting reads the current inventory, including any earlier InvokeAfter return during windup.
            shot = shot with { ThrowGrenade = _grenadierWeapons.IsSecondary(entityKey) };
            Vector3? grenadeMuzzle = null;
            Vector3? grenadeVelocity = null;
            if (shot.ThrowGrenade)
            {
                // Every secondary shot schedules its own source InvokeAfter callback, including overlapping timers.
                _grenadierWeapons.ScheduleReturn(entityKey, tick);
                ArmyWeaponBindingCatalog weapons = armyWeapons ??
                    throw new InvalidDataException("Card Grenadier lost its weapon binding.");
                ArmyCardGrenadierRuntime throwSetup = cardGrenadierThrows[entityKey];
                Vector3 soldierPosition = new(entity.X, entity.Y, entity.Z);
                grenadeMuzzle = weapons.CardGrenadierRestMuzzle(soldierPosition,
                    shot.Target.Position - soldierPosition);
                grenadeVelocity = throwSetup.LaunchVelocity(grenadeMuzzle.Value,
                    shot.Target.Position);
            }
            grenadierShotIntents.Add(new CardGrenadierShotIntent(entityKey,
                tick, shot, shot.ThrowGrenade || attack.CurrentShotIsReal,
                attack.BatchCursor, attack.BatchSize,
                grenadeMuzzle, grenadeVelocity));
            attack.CommitShot();
            if (attack.Phase == ArmyRusherAttackPhase.Cooldown)
                grenadierShotTargets.Remove(entityKey);
        }
        LaunchCardGrenadierShotIntents();
    }

    internal ArmyRusherAttackState? CardGrenadierAttack(ulong entityKey) =>
        grenadierAttacks.GetValueOrDefault(entityKey);

    internal IReadOnlyList<CardGrenadierShotIntent> CardGrenadierShotIntents() =>
        grenadierShotIntents.ToArray();

    internal int CardGrenadierActiveFlightCount => grenadierFlights.Count;

    internal float? CardGrenadierShotHealth(ulong grenadeId) =>
        grenadierFlights.TryGetValue(grenadeId, out var flight)
            ? flight.ShotHealth : null;

    /// <summary>Exposes the first physical contact tick for source fuse verification.</summary>
    internal ulong? GrenadierFirstContactTick(ulong projectileId) =>
        grenadierFlights.TryGetValue(projectileId, out var flight) ? flight.FirstContactTick : null;

    /// <summary>Exposes the most recent contact entry because the recovered fuse rearms on recontact.</summary>
    internal ulong? GrenadierLastContactTick(ulong projectileId) =>
        grenadierFlights.TryGetValue(projectileId, out var flight) ? flight.LastContactTick : null;

    internal IReadOnlyList<CardGrenadierExplosion> CardGrenadierExplosions() =>
        grenadierExplosions.ToArray();

    private void LaunchCardGrenadierShotIntents()
    {
        if (grenadierShotIntents.Count == 0)
            return;
        if (rifleCombat == null)
            throw new InvalidDataException("Card Grenadier has no collision world.");

        foreach (CardGrenadierShotIntent intent in grenadierShotIntents)
        {
            if (!intent.Aim.ThrowGrenade)
            {
                LaunchCardGrenadierPrimary(intent);
                continue;
            }
            if (!activeArmyEntities.TryGetValue(intent.EntityKey,
                    out var soldier) ||
                !IsGrenadier(soldier) ||
                !cardGrenadierThrows.TryGetValue(intent.EntityKey,
                    out var setup) ||
                intent.GrenadeMuzzlePosition is not Vector3 muzzle ||
                intent.GrenadeLaunchVelocity is not Vector3 velocity)
                throw new InvalidDataException(
                    "Card Grenadier shot lost its launch authority.");
            if (PendingProjectileCount >= MaximumProjectiles ||
                !EventCapacityForShot())
                continue;
            if (projectileId == ulong.MaxValue)
                throw new InvalidDataException("Card Grenadier projectile IDs exhausted.");

            ulong id = ++projectileId;
            string ownerId = soldier.OwnerPlayerId;
            if (!_cardGrenadierDamage.TryGetValue(intent.EntityKey, out var damage) ||
                armyCatalog == null)
                throw new InvalidDataException(
                    "Card Grenadier lost its source explosion authority.");
            var flight = new CardGrenadierFlight(id, intent.EntityKey,
                setup, muzzle, velocity, tick,
                (from, direction, range) => rifleCombat.TraceForArmyDamage(
                    ownerId, from, direction, range));
            grenadierFlights.Add(id, flight);
            grenadierLaunches.Add(id, new(ownerId, damage, setup,
                armyCatalog.PlayerDamagePolicy(soldier.UnitId)));
            Emit(MatchEventKind.Shot, ownerId, "", id, muzzle, 0,
                "card-grenadier");
            stateRevision++;
        }
    }

    private void AdvanceCardGrenadierFlights()
    {
        grenadierExplosions.Clear();
        foreach (var (id, flight) in grenadierFlights.OrderBy(row => row.Key)
                     .ToArray())
        {
            CardGrenadierExplosion? explosion = flight.Advance(tick);
            if (explosion == null)
                continue;
            PublishCardGrenadierExplosion(id, explosion);
        }
    }

    internal bool ApplyCardGrenadierShot(string shooterId, ulong grenadeId,
        float damage)
    {
        Player shooter = Find(shooterId) ??
            throw new InvalidDataException("Grenadier shot has no player owner.");
        if (!float.IsFinite(damage) || damage <= 0f ||
            damage > 10_000_000f)
            throw new InvalidDataException("Invalid Grenadier shot damage.");
        if (!grenadierFlights.TryGetValue(grenadeId, out var flight))
        {
            if (grenadierLaunches.ContainsKey(grenadeId))
                throw new InvalidDataException("Grenadier launch has no flight.");
            // Multiple host bullets may have selected the same live grenade
            // before their impact ticks. A later impact has no target to hurt.
            return false;
        }
        if (!grenadierLaunches.TryGetValue(grenadeId, out var launch) ||
            flight.CurrentTick != tick)
            throw new InvalidDataException("Grenadier shot lost its host target.");
        Player owner = Find(launch.OwnerPlayerId) ??
            throw new InvalidDataException("Grenadier owner left the match.");
        if (owner.Definition.Fraction == shooter.Definition.Fraction)
            throw new InvalidDataException("Owner cannot shoot their own grenade.");

        CardGrenadierExplosion? explosion = flight.ApplyShot(damage, tick);
        if (explosion != null)
            PublishCardGrenadierExplosion(grenadeId, explosion);
        return true;
    }

    private void PublishCardGrenadierExplosion(ulong grenadeId,
        CardGrenadierExplosion explosion)
    {
        if (!grenadierFlights.Remove(grenadeId) ||
            !grenadierLaunches.Remove(grenadeId, out var launch) ||
            explosion.ProjectileId != grenadeId)
            throw new InvalidDataException(
                "Card Grenadier explosion lost its damage authority.");
        grenadierExplosions.Add(explosion);
        Emit(MatchEventKind.Impact, launch.OwnerPlayerId, "", grenadeId,
            explosion.Position, 0, "card-grenadier");
        stateRevision++;
        ApplyCardGrenadierExplosion(explosion, launch);
    }

    private void AdvanceCardGrenadierCornerChanges()
    {
        if (cardEnemyPoints == null || armyCatalog == null)
            throw new InvalidDataException("Card Grenadier has no point-change authority.");

        foreach (var (entityKey, changeTick) in grenadierCornerChangeTicks
            .OrderBy(row => row.Key).ToArray())
        {
            if (tick <= changeTick) continue;
            if (!activeArmyEntities.TryGetValue(entityKey, out var entity) ||
                !IsGrenadier(entity) ||
                !grenadierAttacks.TryGetValue(entityKey, out var attack))
                throw new InvalidDataException("Card Grenadier lost its Corner state.");
            if (attack.Phase is ArmyRusherAttackPhase.Windup or
                ArmyRusherAttackPhase.Firing)
                continue;

            IReadOnlyList<CardUnitInitialPoint> available =
                cardEnemyPoints.NextFreePoints(entityKey,
                    "GREATGRENADIER", entity.OwnerFraction);
            if (available.Count == 0)
            {
                grenadierCornerChangeTicks[entityKey] = checked(changeTick +
                    10u * MatchManifest.TickRate);
                continue;
            }

            int index = armyChoice(available.Count);
            if (index < 0 || index >= available.Count)
                throw new InvalidDataException("Invalid host Grenadier point choice.");
            CardUnitInitialPoint next = available[index];
            Vector3 position = new(entity.X, entity.Y, entity.Z);
            ArmyNavMeshCorridor route = PlanCardSoldierRoute(position,
                next.Position);
            float speed = ArmySpeed(entity.EntityKey) ?? armyCatalog.EffectiveSpeed(entity.UnitId, 1f);
            var walk = new CardSoldierWalkState(next.ComponentFileId, route,
                armyCatalog.InfantryAgent, speed);

            cardEnemyPoints.Transfer(entityKey, "GREATGRENADIER", next);
            grenadierCornerChangeTicks.Remove(entityKey);
            grenadierAttacks.Remove(entityKey);
            grenadierShotTargets.Remove(entityKey);
            grenadierWalks.Add(entityKey, walk);
        }
    }

    internal bool CardRocketWalking(ulong entityKey) =>
        rocketWalks.ContainsKey(entityKey);

    internal ArmyRusherAttackState? CardRocketAttack(ulong entityKey) =>
        rocketAttacks.GetValueOrDefault(entityKey);

    internal IReadOnlyList<CardRocketShotIntent> CardRocketShotIntents() =>
        rocketShotIntents.ToArray();

    internal int CardRocketActiveFlightCount => rocketFlights.Count;

    internal IReadOnlyList<CardRocketMissileImpact> CardRocketImpacts() =>
        rocketImpacts.ToArray();

    internal Vector3? CardRocketAim(ulong entityKey)
    {
        if (phase != BattlePhase.Running || map == null ||
            !cardRocketMissiles.ContainsKey(entityKey) ||
            !activeArmyEntities.TryGetValue(entityKey, out var soldier) ||
            !IsRocketSoldier(soldier))
            return null;

        Player owner = Find(soldier.OwnerPlayerId) ??
            throw new InvalidDataException("Card Rocket Soldier lost its owner.");
        Player opponent = players.Single(player => player != owner);
        if (opponent.Dead)
            return null;

        // GetShotTargets(Shield) inserts the current cover's shield target,
        // removes the Shield bit, then asks the base class for type None.
        // Thus the serialized player target is never in this particular list.
        // PlayerController sets currentPlayerPoint to the destination before
        // moving, so a walking opponent still points at that cover shield.
        int currentPoint = opponent.Route == null ? opponent.Cover :
            opponent.Destination;
        if (currentPoint < 0 || currentPoint >= map.Covers.Count)
            return null;
        return map.Covers[currentPoint].ShotPosition;
    }

    internal Vector3? CardRocketFiringMuzzle(ulong entityKey,
        Vector3 targetPosition)
    {
        if (!rocketAttacks.ContainsKey(entityKey))
            return null;
        if (!activeArmyEntities.TryGetValue(entityKey, out var entity) ||
            !IsRocketSoldier(entity) ||
            cardEnemyPoints?.Find(entityKey) is not { } corner ||
            enemyMuzzles == null || assaulterWeapon == null)
            throw new InvalidDataException(
                "Card Rocket lost its animated muzzle authority.");

        Vector3 soldierPosition = new(entity.X, entity.Y, entity.Z);
        return CardRocketMuzzlePose.Place(enemyMuzzles, assaulterWeapon,
            corner, soldierPosition, targetPosition);
    }

    private void TryAssignCardRocketPoint(BattleArmyEntityState entity)
    {
        if (!IsRocketSoldier(entity) || cardEnemyPoints == null ||
            armyCatalog == null)
            throw new InvalidDataException("Card Rocket has no source point authority.");

        Vector3 position = new(entity.X, entity.Y, entity.Z);
        CardUnitInitialPoint? point = cardEnemyPoints.TryAssign(
            entity.EntityKey, "BIGROCKET", entity.OwnerFraction, position);
        if (point == null)
        {
            // EnemyController.GenerateInitPoint retries after five seconds.
            rocketPointRetryTicks[entity.EntityKey] = checked(tick +
                5u * MatchManifest.TickRate);
            return;
        }

        try
        {
            ArmyNavMeshCorridor route = PlanCardSoldierRoute(position, point.Position);
            float speed = ArmySpeed(entity.EntityKey) ?? armyCatalog.EffectiveSpeed(entity.UnitId, 1f);
            rocketWalks.Add(entity.EntityKey, new CardSoldierWalkState(
                point.ComponentFileId, route, armyCatalog.InfantryAgent, speed));
            rocketPointRetryTicks.Remove(entity.EntityKey);
        }
        catch
        {
            cardEnemyPoints.Release(entity.EntityKey);
            throw;
        }
    }

    private void AdvanceCardRocketPointRetries()
    {
        foreach (var (entityKey, dueTick) in rocketPointRetryTicks.OrderBy(row => row.Key).ToArray())
        {
            if (tick < dueTick)
                continue;
            if (!activeArmyEntities.TryGetValue(entityKey, out var entity) ||
                !IsRocketSoldier(entity))
                throw new InvalidDataException("Card Rocket retry lost its soldier.");
            TryAssignCardRocketPoint(entity);
        }
    }

    private void AdvanceCardRocketWalks()
    {
        foreach (var (entityKey, walk) in rocketWalks.OrderBy(row => row.Key).ToArray())
        {
            if (!activeArmyEntities.TryGetValue(entityKey, out var entity) ||
                !IsRocketSoldier(entity) ||
                cardEnemyPoints?.Find(entityKey)?.ComponentFileId != walk.PointFileId)
                throw new InvalidDataException("Card Rocket walk lost its point.");

            walk.AdvanceTick();
            entity.X = walk.Position.X;
            entity.Y = walk.Position.Y;
            entity.Z = walk.Position.Z;
            entity.PositionTick = tick;
            if (entity.SourceCardId.Length > 0)
            {
                cardUnitCombat?.UpdatePose(entity);
            }
            if (walk.Arrived)
            {
                rocketWalks.Remove(entityKey);
                StartCardRocketAttack(entityKey);
            }
        }
    }

    private void StartCardRocketAttack(ulong entityKey)
    {
        CardUnitInitialPoint point = cardEnemyPoints?.Find(entityKey) ??
            throw new InvalidDataException("Card Rocket reached no source Corner.");
        if (!activeArmyEntities.TryGetValue(entityKey, out var entity))
            throw new InvalidDataException("Card Rocket reached a point without its soldier.");
        if (point.ComponentType != "EnemyPointCorner" || !IsRocketSoldier(entity))
            throw new InvalidDataException("Rocket Soldier has no Corner attack authority.");
        ArmyBaseShotStats shot = ReadRocketShotStats(entity);

        // SoldierBehaviour.ApplyWeaponsSetup replaces the prefab's two-second
        // cadence with 0.35 seconds. CornerHiding draws the first delay.
        var attack = new ArmyRusherAttackState(shot,
            NextArmyFloat, shotIntervalTicks:
                (int)MathF.Ceiling(.35f * MatchManifest.TickRate));
        attack.BeginInitialCooldown();
        if (!rocketAttacks.TryAdd(entityKey, attack))
            throw new InvalidDataException("Card Rocket attack started twice.");
    }

    private void AdvanceCardRocketAttacks()
    {
        rocketShotIntents.Clear();
        foreach (var (entityKey, attack) in rocketAttacks.OrderBy(row => row.Key))
        {
            CardUnitInitialPoint? point = cardEnemyPoints?.Find(entityKey);
            if (!activeArmyEntities.TryGetValue(entityKey, out var entity) ||
                !IsRocketSoldier(entity) ||
                rocketWalks.ContainsKey(entityKey) ||
                point?.ComponentType != "EnemyPointCorner" ||
                point.CornerDirection is not Vector3 ||
                point.CornerRightSide is not bool)
                throw new InvalidDataException("Card Rocket attack lost its Corner.");
            Vector3 cornerDirection = point.CornerDirection.Value;
            bool cornerRightSide = point.CornerRightSide.Value;

            if (attack.Phase == ArmyRusherAttackPhase.Ready)
            {
                Vector3? aim = CardRocketAim(entityKey);
                Vector3 origin = new(entity.X, entity.Y, entity.Z);
                if (aim is Vector3 target)
                {
                    if (!CornerShotPolicy.CanExpose(cornerDirection, cornerRightSide,
                            origin, target))
                        attack.RetryAfterRejectedTarget();
                    else if (attack.TryBegin(true, 1,
                                 (int)MathF.Ceiling(.7f * MatchManifest.TickRate)))
                        rocketShotTargets[entityKey] = target;
                }
            }

            attack.AdvanceTick();
            if (!attack.ShotDue)
                continue;
            if (!rocketShotTargets.TryGetValue(entityKey, out Vector3 shotTarget))
                throw new InvalidDataException("Card Rocket lost its latched aim.");
            Vector3 muzzle = CardRocketFiringMuzzle(entityKey, shotTarget) ??
                throw new InvalidDataException("Card Rocket shot has no source muzzle.");
            rocketShotIntents.Add(new CardRocketShotIntent(entityKey, tick,
                shotTarget, muzzle, attack.CurrentShotIsReal, attack.BatchCursor,
                attack.BatchSize));
            attack.CommitShot();
            if (attack.Phase == ArmyRusherAttackPhase.Cooldown)
                rocketShotTargets.Remove(entityKey);
        }
        LaunchCardRocketShotIntents();
    }

    private void LaunchCardRocketShotIntents()
    {
        if (rocketShotIntents.Count == 0)
            return;
        if (rifleCombat == null)
            throw new InvalidDataException("Card Rocket has no collision world.");

        foreach (CardRocketShotIntent intent in rocketShotIntents)
        {
            if (!activeArmyEntities.TryGetValue(intent.EntityKey,
                    out var soldier) ||
                !IsRocketSoldier(soldier) ||
                !cardRocketMissiles.TryGetValue(intent.EntityKey,
                    out var missile))
                throw new InvalidDataException("Card Rocket shot lost its owner.");
            if (PendingProjectileCount >= MaximumProjectiles ||
                !EventCapacityForShot())
                continue;
            if (projectileId == ulong.MaxValue)
                throw new InvalidDataException("Card Rocket projectile IDs exhausted.");

            ulong id = ++projectileId;
            string ownerId = soldier.OwnerPlayerId;
            if (armyCatalog == null)
                throw new InvalidDataException("Card Rocket has no player damage policy.");
            var policy = armyCatalog.PlayerDamagePolicy(soldier.UnitId);
            var flight = new CardRocketMissileFlight(id, intent.EntityKey,
                missile, intent.MuzzlePosition, intent.TargetPosition,
                tick, !intent.IsReal,
                (from, direction, range) => rifleCombat.TraceForArmyDamage(
                    ownerId, from, direction, range));
            rocketFlights.Add(id, flight);
            rocketLaunches.Add(id, new CardRocketLaunchAuthority(ownerId,
                missile, policy));
            Emit(MatchEventKind.Shot, ownerId, "", id,
                intent.MuzzlePosition, 0,
                intent.IsReal ? "card-rocket" : "card-rocket-fake");
            stateRevision++;
        }
    }

    private void AdvanceCardRocketFlights()
    {
        rocketImpacts.Clear();
        foreach (var (id, flight) in rocketFlights.OrderBy(row => row.Key).ToArray())
        {
            CardRocketMissileImpact? impact = flight.Advance(tick);
            if (impact == null)
                continue;
            rocketFlights.Remove(id);
            rocketImpacts.Add(impact);
            if (!rocketLaunches.Remove(id, out var launch))
                throw new InvalidDataException("Card Rocket lost its launch authority.");
            Emit(MatchEventKind.Impact, launch.OwnerPlayerId,
                impact.Collision?.PlayerId ?? "", id, impact.Position, 0,
                impact.IsFake ? "card-rocket-fake" : "card-rocket");
            stateRevision++;
            if (!impact.IsFake)
                ApplyCardRocketExplosion(impact, launch);
        }
    }

    private void ApplyCardRocketExplosion(CardRocketMissileImpact impact,
        CardRocketLaunchAuthority launch)
    {
        if (rifleCombat == null || damageRoll == null)
            throw new InvalidDataException("Card Rocket has no player collision authority.");
        var attacker = Find(launch.OwnerPlayerId) ??
            throw new InvalidDataException("Card Rocket owner disappeared.");
        bool shieldBetween = false;
        if (map != null)
        {
            Func<int, bool>? enabled = barrels == null ? null :
                index => barrels.ColliderEnabled(index);
            Func<int, int, int>? layer = barrels == null ? null :
                (index, source) => barrels.RuntimeLayer(index, source);
            var overlaps = map.DynamicSphereOverlaps(impact.Position, 1.2f,
                uint.MaxValue, enabled, layer);
            var closest = CardRocketExplosion.ClosestColliders(
                impact.Position, overlaps);
            shieldBetween = shields != null && closest.Any(collider =>
                shields.IsLiveShield(collider.DynamicOwner));
            foreach (var collider in closest)
            {
                CardRocketDynamicHit hit = CardRocketExplosion.ResolveDynamic(
                    impact.Position, collider, launch.Missile);
                if (shields != null &&
                    shields.IsLiveShield(collider.DynamicOwner))
                {
                    var shield = shields.ApplyUnitExplosion(
                        collider.DynamicOwner, attacker.Definition.Fraction,
                        hit.RawDamage, tick);
                    if (shield != null)
                    {
                        stateRevision++;
                        EmitShield(shield.Destroyed ? MatchEventKind.ShieldDestroyed :
                            MatchEventKind.ShieldDamaged, launch.OwnerPlayerId,
                            shield, impact.ProjectileId);
                    }
                }
                else if (barrels?.Contains(collider.ColliderIndex) == true)
                {
                    ApplyBarrelDamage(launch.OwnerPlayerId,
                        impact.ProjectileId, collider.ColliderIndex,
                        hit.RawDamage, hit.Kind == CombatDamageType.Explosion ?
                            BarrelChainCause.Explosion : BarrelChainCause.Shiver);
                    if (Terminal)
                        return;
                }
            }
        }
        ApplyCardRocketBonusBoxes(launch.OwnerPlayerId,
            impact.ProjectileId, impact.Position, launch.Missile);
        ApplyCardRocketAssaultGlassExplosion(impact, launch,
            attacker.Definition.Fraction);
        if (Terminal)
            return;
        ApplyCardRocketArmyExplosion(impact, launch,
            attacker.Definition.Fraction);
        if (Terminal)
            return;
        ApplyCardRocketHelicopterGunnerExplosion(impact, launch,
            attacker.Definition.Fraction);
        if (Terminal)
            return;
        ApplyCardRocketDecoyExplosion(impact, launch,
            attacker.Definition.Fraction);
        if (Terminal)
            return;
        ApplyCardRocketHeavyTurretExplosion(impact, launch,
            attacker.Definition.Fraction);
        if (Terminal)
            return;
        ApplyCardRocketRepairDroneExplosion(impact, launch,
            attacker.Definition.Fraction);
        if (Terminal)
            return;
        ApplyCardRocketPassengerExplosion(impact, launch,
            attacker.Definition.Fraction);
        if (Terminal)
            return;
        ApplyCardRocketGroundVehicleExplosion(impact, launch,
            attacker.Definition.Fraction);
        if (Terminal)
            return;
        foreach (var victim in players.Where(player => !player.Dead).ToArray())
        {
            var pose = rifleCombat.Pose(victim.Definition.PlayerId).Collision;
            CardRocketPlayerHit? hit = CardRocketExplosion.ResolvePlayer(
                impact.Position, pose, victim.Position, launch.Missile,
                shieldBetween);
            if (hit == null)
                continue;
            bool enemy = attacker.Definition.Fraction != victim.Definition.Fraction;
            var damage = new ResolvedPlayerDamage(hit.RawDamage, hit.Kind,
                HasWeapon: true, FriendKill: false,
                PlayerCoefficient: launch.PlayerPolicy.PlayerDamageRatio,
                PlayerOvertimeCoefficient:
                    launch.PlayerPolicy.OvertimePlayerDamageRatio,
                Overtime: overtime);
            ApplyResolvedPlayerDamage(launch.OwnerPlayerId,
                victim.Definition.PlayerId, damage, damageRoll(), enemy);
            if (Terminal)
                return;
        }
    }

    private void ApplyCardRocketArmyExplosion(CardRocketMissileImpact impact,
        CardRocketLaunchAuthority launch, int attackerFraction)
    {
        var targets = GroundVehicleShotTargets(launch.OwnerPlayerId, true)
            .Where(target => target.ArmyInfantry || target.DroneRoot ||
                target.HelicopterBody)
            .GroupBy(target => target.EntityId)
            .OrderBy(group => group.Key);
        foreach (var group in targets)
        {
            if (!activeArmyEntities.TryGetValue(group.Key, out var army))
                throw new InvalidDataException(
                    "Card Rocket blast lost its army target authority.");
            bool infantry = infantryAnimations.ContainsKey(group.Key) &&
                group.All(target => target.ArmyInfantry);
            bool drone = army.UnitId == "ID_UNIT-DRONE" &&
                group.All(target => target.DroneRoot);
            bool helicopter = army.UnitId is
                ("ID_UNIT-HELICOPTER" or "ID_UNIT-ASSAULTHELI") &&
                group.All(target => target.HelicopterBody);
            if (!infantry && !drone && !helicopter)
                throw new InvalidDataException(
                    "Card Rocket blast has mismatched army hitboxes.");
            // BazookaEnemy's PhysicalAmmoWeapon has friendKill = false.
            if (army.OwnerFraction == attackerFraction)
                continue;
            var hit = CardRocketExplosion.ResolveArmy(impact.Position,
                new Vector3(army.X, army.Y, army.Z),
                group.Select(target => target.Hitbox).ToArray(),
                launch.Missile);
            if (hit == null)
                continue;
            if (!float.IsFinite(hit.RawDamage) ||
                hit.RawDamage is <= 0 or > 10_000_000)
                throw new InvalidDataException(
                    "Card Rocket army damage exceeded host bounds.");
            ApplyArmyHostDamage(group.Key, hit.RawDamage);
            if (Terminal)
                return;
        }
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
        cardRocketMissiles.Remove(entityKey);
        cardGrenadierThrows.Remove(entityKey);
        _cardGrenadierDamage.Remove(entityKey);
        if (entity.SourceCardId == "GREATGRENADIER")
        {
            armyDamage.Remove(entityKey);
            armyShots.Remove(entityKey);
        }
        grenadierPointRetryTicks.Remove(entityKey);
        grenadierWalks.Remove(entityKey);
        grenadierAttacks.Remove(entityKey);
        grenadierShotTargets.Remove(entityKey);
        grenadierShotIntents.RemoveAll(intent => intent.EntityKey == entityKey);
        RemoveGrenadierWeaponVisibility(entityKey);
        grenadierCornerChangeTicks.Remove(entityKey);
        rocketPointRetryTicks.Remove(entityKey);
        rocketWalks.Remove(entityKey);
        rocketAttacks.Remove(entityKey);
        rocketShotTargets.Remove(entityKey);
        rocketShotIntents.RemoveAll(intent => intent.EntityKey == entityKey);
        if (entity.SourceCardId is "BIGROCKET" or "GREATGRENADIER")
            cardEnemyPoints?.Release(entityKey);

        // Card Drone uses the same host flight/weapon systems as an ordinary
        // Drone, but its stats came from CardSpawnUnit's source rows.
        if (droneArmyTargets.Remove(entityKey))
            droneTargets.Disable(DroneArmyId(entityKey));
        if (entity.SourceCardId == "HEAVYDRONE")
        {
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
                deadParatrooperCanopies.Add(entityKey,
                    new LandedCanopy(landingTick, position, rotation));
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

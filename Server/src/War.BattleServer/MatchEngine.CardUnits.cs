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

    internal CardUnitInitialPoint? CardEnemyPoint(ulong entityKey) =>
        cardEnemyPoints?.Find(entityKey);

    internal ulong? CardEnemyPointOccupant(int pointFileId) =>
        cardEnemyPoints?.Occupant(pointFileId);

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
            if (entity.SourceCardId == "ELITESWAT")
                TryAssignCardSwatPoint(entity);
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

using War.Protocol;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private bool AdvanceRealtimeArmyDeployments()
    {
        if (phase != BattlePhase.Running || armySelector == null)
        {
            return true;
        }
        float realSeconds = (float)ObservedRealTimeSeconds;
        try
        {
            // Both owners must pass resource preflight before either publishes an entity.
            var candidates = new List<(Player Owner, ArmySpawn Spawn)>();
            foreach (Player owner in players)
            {
                candidates.AddRange(owner.Army!.PreviewRealtimeSpawns(realSeconds, tick)
                    .Select(spawn => (owner, spawn)));
            }
            PreflightMortarWeaponSlots(candidates);
            foreach (Player owner in players)
            {
                foreach (ArmySpawn spawned in owner.Army!.AdvanceRealtime(realSeconds, tick))
                {
                    PublishRealtimeArmySpawn(owner, spawned);
                }
                PublishArmyDeploymentFinished(owner);
            }
            return true;
        }
        catch (InvalidDataException)
        {
            End("invalid-army-authority", "", false);
            return false;
        }
    }

    private void PublishRealtimeArmySpawn(Player owner, ArmySpawn spawned)
    {
        var family = armyCatalog!.Families.Single(f => f.Options.Any(o => o.Index == spawned.OptionIndex));
        var selector = armySelector ?? throw new InvalidDataException("Army selector is unavailable.");
        var point = selector.Select(map!, family, owner.Definition.Fraction,
            players.Single(other => other != owner).Position, armyChoice, armyReservations!.Available);
        ulong entityKey = ((ulong)owner.Definition.Fraction << 32) | (uint)spawned.EntityId;
        if (point == null || !armyReservations.TryReserve(point, entityKey))
        {
            throw new InvalidDataException("Spawn point became unavailable after army acceptance.");
        }
        if (ArmyRusherPointCatalog.IsRusher(family.BehaviorType))
        {
            ReserveRusherSlot(entityKey, players.Single(other => other != owner).Cover, point.Position);
        }
        InitializeArmyVitality(owner.Definition, spawned.UnitId, entityKey);
        AllocateMortarWeapon(owner, spawned, entityKey);
        activeArmyEntities.Add(entityKey, new BattleArmyEntityState
        {
            EntityKey = entityKey,
            OwnerPlayerId = owner.Definition.PlayerId,
            OwnerFraction = owner.Definition.Fraction,
            LocalEntityId = spawned.EntityId,
            OptionIndex = spawned.OptionIndex,
            UnitId = spawned.UnitId,
            SpawnComponentFileId = point.ComponentFileId,
            ReservationFileId = point.ReservationFileId,
            X = point.Position.X,
            Y = point.Position.Y,
            Z = point.Position.Z,
            SpawnTick = tick,
            PositionTick = tick,
            HelicopterCrewCount = (uint)(armyHelicopterCrew.GetValueOrDefault(entityKey)?.Seats ?? 0),
            HelicopterRotation = spawned.UnitId == "ID_UNIT-HELICOPTER" ? new BattleJointRotation { W = 1 } : null,
            DroneRotation = spawned.UnitId == "ID_UNIT-DRONE" ? new BattleJointRotation { W = 1 } : null,
            MaxHealth = ArmyHealth(entityKey) ?? 0,
            Health = ArmyHealth(entityKey) ?? 0,
            AssaultGlassMaxHealth = AssaultGlassMaximum(entityKey) ?? 0,
            AssaultGlassHealth = AssaultGlassHealth(entityKey) ?? 0
        });
        InitializeRealtimeArmySpawn(entityKey, spawned);
        InitializeGroundVehicle(entityKey, family, point);
        InitializeDronePath(entityKey, family, point);
        InitializeAssaultHelicopterPath(entityKey, family, point);
        InitializeHelicopterPath(entityKey, family, point);
        RegisterDroneArmyTarget(entityKey, family);
        owner.ArmyStats.RecordSpawn(spawned.OptionIndex, spawned.UnitId);
        owner.ConfirmedArmySpawns = checked(owner.ConfirmedArmySpawns + 1);
        armyEntityRevision++;
        Emit(MatchEventKind.ArmySpawned, owner.Definition.PlayerId, "", 0, point.Position, 0, "");
        var row = events[^1];
        row.ArmyEntityId = spawned.EntityId;
        row.ArmyOptionIndex = spawned.OptionIndex;
        row.ArmyUnitId = spawned.UnitId;
        row.ArmySpawnComponentFileId = point.ComponentFileId;
        row.ArmyReservationFileId = point.ReservationFileId;
        stateRevision++;
    }

    private void InitializeRealtimeArmySpawn(ulong entityKey, ArmySpawn spawned)
    {
        // Source AfterSpawned observers run after the soldier has configured both weapons.
        if (spawned.UnitId == "ID_UNIT-GRENADIER")
        {
            InitializeOrdinaryGrenadier(entityKey);
        }
        if (spawned.UnitId == "ID_UNIT-ROCKETSOLDIER")
        {
            InitializeOrdinaryRocket(entityKey);
        }
        if (spawned.UnitId == "ID_UNIT-MORTAR")
        {
            InitializeOrdinaryMortar(entityKey);
        }
        ApplyActiveArmyHealthBuffs(entityKey);
        var vitality = armyVitality.GetValueOrDefault(entityKey);
        if (vitality != null)
        {
            activeArmyEntities[entityKey].MaxKevlar = vitality.KevlarMaximum;
            activeArmyEntities[entityKey].Kevlar = vitality.Kevlar;
        }
        InitializeInfantryAnimation(entityKey);
        InitializeRusherMotionCandidate(entityKey, spawned.UnitId);
        InitializeStationaryArmyCombat(entityKey, spawned.UnitId);
    }
}

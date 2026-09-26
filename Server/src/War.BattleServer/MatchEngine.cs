using Google.Protobuf;
using System.Globalization;
using System.Numerics;
using War.Protocol;
using War.Shared;

namespace War.BattleServer;

// Single writer: NetworkWorker's tick thread. Does not call Unity, Mongo or HTTP.
public sealed partial class MatchEngine
{
    private readonly MatchManifest manifest;
    private readonly Player[] players;
    private readonly ulong admissionDeadline;
    private readonly RecoveredBattleMap? map;
    private ulong tick;
    private ulong hostTick;
    private ulong stateRevision;
    private ulong startTick;
    private ulong endTick;
    private bool overtime;
    private BattlePhase phase = BattlePhase.Waiting;
    private string winner = "";
    private string terminalReason = "";
    private readonly Dictionary<ulong, PreparedProjectile> projectiles = [];
    private sealed record BazookaProjectile(BazookaMissileFlight Flight,BazookaStage Stage,BazookaBinding Binding,string WeaponSourceId,bool HalfDamage);
    private sealed record ScheduledBazooka(string Owner,Vector3 Target,ulong LaunchTick,bool Fake,bool Secondary,bool HalfDamage,string WeaponSourceId,int Upgrade);
    private readonly Dictionary<ulong,BazookaProjectile> bazookaProjectiles=[];
    private readonly List<ScheduledBazooka> scheduledBazookas=[];
    private readonly BazookaCatalog? bazookaCatalog;
    private ulong bazookaCurveCounter;
    private sealed record GrenadeProjectile(GrenadeFlight Flight,GrenadeStage Stage,GrenadeBinding Binding,string WeaponSourceId);
    private readonly Dictionary<ulong,GrenadeProjectile> grenadeProjectiles=[];
    private readonly GrenadeCatalog? grenadeCatalog;
    private readonly GrenadeMatchSimulation? grenadeCombat;
    private readonly Dictionary<ulong, ArmyProjectileFlight> armyProjectiles = [];
    private readonly Dictionary<ulong, VehicleProjectileFlight> vehicleProjectiles = [];
    private readonly Dictionary<ulong, (string Owner, string Target, Vector3 Position)> vehicleShotTargets = [];
    private Func<ulong, float>? vehicleDamage;
    private Func<ulong, string, Vector3, ulong, IReadOnlyList<PreparedProjectile>>? prepareVolley;
    private Func<float>? damageRoll;
    private readonly RifleMatchSimulation? rifleCombat;
    private readonly ShieldMatchSimulation? shields;
    private readonly BarrelMatchSimulation? barrels;
    private readonly ExplosionSourceCatalog? explosionPolicy;
    private readonly ArmySpawnPointSelector? armySelector;
    private readonly ArmyRusherPointCatalog? armyRusherPoints;
    private readonly ArmyMinigunnerPointCatalog? armyMinigunnerPoints;
    private readonly ArmyNavMeshConnectivity? armyNavMeshConnectivity;
    private readonly PlayerShotTargetCatalog? playerShotTargets;
    private readonly ArmySpawnReservationLedger? armyReservations;
    private readonly ArmyDeploymentCatalog? armyCatalog;
    private readonly ArmyWeaponBindingCatalog? armyWeapons;
    private readonly Dictionary<ulong,BattleArmyEntityState> activeArmyEntities=[];
    // Air entities use the same single-writer tick as the rest of the match.  The
    // registry is deliberately kept separate from infantry state until the
    // recovered air deployment contract is bound to a Client command.
    private readonly AirEntityRegistry airEntities = new();
    private readonly DeployableRegistry deployables = new();
    private readonly WarCardEffectRuntime cardEffects = new();
    private BattleCardSelectionState? cardSelections;
    private BattleBuddySelectionState? buddySelections;
    private IReadOnlySet<string>? cardCatalog;
    private WarCardReservationState? cardReservations;
    private readonly BattleInteractableRegistry interactables = new();
    private readonly Dictionary<string, BattleObjectiveState> objectives = new(StringComparer.Ordinal);
    private WarArenaPolicy? arenaPolicy;
    private WarArenaBattleState? arenaState;
    private string arenaPlayerId = "";
    private ulong arenaRevision;
    private CoopMissionState? coopMission;
    private CoopMissionModifiers coopModifiers;
    private readonly BattlePerformanceLedger performance = new();
    private readonly BattleRibbonLedger ribbons = new();
    private VehicleEntityRegistry? vehicles;
    private ulong armyEntityRevision;
    private ulong projectileId;
    internal const int MaximumProjectiles = 128;
    internal int PendingProjectileCount => checked(projectiles.Count+armyProjectiles.Count+armyFlameBursts.Count+bazookaProjectiles.Count+scheduledBazookas.Count+grenadeProjectiles.Count);
    internal IReadOnlyCollection<AirBattleEntity> AirEntities => airEntities.Snapshot();

    internal bool TryRegisterAirEntity(AirBattleEntity entity)
    {
        if (phase is not (BattlePhase.Waiting or BattlePhase.Countdown or BattlePhase.Running))
            return false;
        if (!HasPlayer(entity.AttackerPlayerId) || !Find(entity.AttackerPlayerId)!.Admitted)
            return false;
        if (!airEntities.TrySpawn(entity)) return false;
        stateRevision++;
        Emit(MatchEventKind.AirSpawned, entity.AttackerPlayerId, "", entity.EntityKey,
            entity.Motion.Position, entity.Health.Current, "");
        return true;
    }

    internal bool TryRemoveAirEntity(ulong entityKey)
    {
        if (!airEntities.TryGet(entityKey, out var entity) || entity == null) return false;
        if (!airEntities.TryDespawn(entityKey)) return false;
        stateRevision++;
        Emit(MatchEventKind.AirDespawned, entity.AttackerPlayerId, "", entity.EntityKey,
            entity.Motion.Position, entity.Health.Current, "despawned");
        return true;
    }

    internal bool TryDamageAirEntity(string victimPlayerId, ulong entityKey, float trustedDamage)
    {
        if (airEntities.TryGet(entityKey, out var entity) == false || entity == null ||
            Find(victimPlayerId)?.Admitted != true || entity.AttackerPlayerId == victimPlayerId) return false;
        if (!airEntities.TryApplyDamage(entityKey, trustedDamage, out var applied)) return false;
        stateRevision++;
        if (!airEntities.TryGet(entityKey, out _))
            Emit(MatchEventKind.AirDespawned, entity.AttackerPlayerId, victimPlayerId,
                entityKey, entity.Motion.Position, 0, "destroyed");
        return applied > 0;
    }

    internal bool TryRegisterDeployable(DeployableEntity entity)
    {
        if (phase is not (BattlePhase.Waiting or BattlePhase.Countdown or BattlePhase.Running)) return false;
        if (!HasPlayer(entity.OwnerPlayerId) || Find(entity.OwnerPlayerId)!.Admitted != true) return false;
        if (!deployables.TrySpawn(entity)) return false;
        stateRevision++;
        Emit(MatchEventKind.DeployableSpawned, entity.OwnerPlayerId, entity.CardId,
            (ulong)entity.EntityId, entity.Position, 0, "");
        return true;
    }

    internal bool TryApplyCardEffect(string effectId, string ownerPlayerId, WarCardEffectRequest request)
    {
        if (Find(ownerPlayerId)?.Admitted != true || phase is not (BattlePhase.Countdown or BattlePhase.Running)) return false;
        try { WarCardEffectRequestValidator.Validate(request); }
        catch (InvalidDataException) { return false; }
        var reserved = cardReservations != null;
        if (reserved && !cardReservations!.TryReserve(effectId, request.CardId)) return false;
        if (!cardEffects.TryApply(effectId, ownerPlayerId, request, tick))
        {
            if (reserved) cardReservations!.TryRelease(effectId);
            return false;
        }
        if (Guid.TryParseExact(effectId, "N", out _)) performance.RecordCard(effectId);
        stateRevision++;
        Emit(MatchEventKind.CardEffectApplied, ownerPlayerId, request.CardId, 0,
            request.Target, 0, effectId);
        return true;
    }

    internal void ConfigureCardInventory(IEnumerable<(string CardId, int Count)> inventory)
    {
        if (cardReservations != null || phase != BattlePhase.Waiting) throw new InvalidOperationException("Card inventory authority must be bound once.");
        cardReservations = new WarCardReservationState(inventory);
    }

    internal PlayerDamageResult? TryResolveCardDamage(string ownerPlayerId, string effectId,
        string targetPlayerId, float trustedDamage)
    {
        if (Find(ownerPlayerId)?.Admitted != true || Find(targetPlayerId)?.Admitted != true ||
            !cardEffects.TryGet(effectId, out var effect) || effect == null || effect.OwnerPlayerId != ownerPlayerId ||
            effect.Definition.Kind != WarCardEffectKind.Damage ||
            Find(ownerPlayerId)!.Definition.Fraction == Find(targetPlayerId)!.Definition.Fraction ||
            phase != BattlePhase.Running) return null;
        if (!float.IsFinite(trustedDamage) || trustedDamage <= 0 || trustedDamage > 10_000_000) return null;
        return ApplyResolvedPlayerDamage(ownerPlayerId, targetPlayerId,
            new ResolvedPlayerDamage(trustedDamage, CombatDamageType.Explosion, HasWeapon: false), 1, false);
    }

    internal PlayerDamageResult? TryResolveCardHeal(string ownerPlayerId, string effectId,
        string targetPlayerId, float trustedAmount)
    {
        if (Find(ownerPlayerId)?.Admitted != true || Find(targetPlayerId)?.Admitted != true ||
            !cardEffects.TryGet(effectId, out var effect) || effect == null || effect.OwnerPlayerId != ownerPlayerId ||
            effect.Definition.Kind != WarCardEffectKind.Heal || phase != BattlePhase.Running ||
            !float.IsFinite(trustedAmount) || trustedAmount <= 0 || trustedAmount > 10_000_000) return null;
        return ApplyResolvedPlayerDamage(ownerPlayerId, targetPlayerId,
            new ResolvedPlayerDamage(trustedAmount, CombatDamageType.Heal, HasWeapon: false), 1, false);
    }

    internal bool TryResolveCardStatus(string ownerPlayerId, string effectId, string targetPlayerId)
    {
        var target = Find(targetPlayerId);
        if (Find(ownerPlayerId)?.Admitted != true || target?.Admitted != true ||
            !cardEffects.TryGet(effectId, out var effect) || effect == null || effect.OwnerPlayerId != ownerPlayerId ||
            effect.Definition.Kind != WarCardEffectKind.Status || phase != BattlePhase.Running ||
            Find(ownerPlayerId)!.Definition.Fraction == target.Definition.Fraction || effect.Lease.ExpiresTick <= tick)
            return false;
        var seconds = (effect.Lease.ExpiresTick - tick) / (float)MatchManifest.TickRate;
        return target.Status.Apply(effectId, tick, seconds, stackable: true);
    }

    internal bool TryResolveCardAmmo(string ownerPlayerId, string effectId, string targetPlayerId, int trustedAmount)
    {
        var owner = Find(ownerPlayerId); var target = Find(targetPlayerId);
        if (owner?.Admitted != true || target?.Admitted != true || trustedAmount is < 1 or > 100000 ||
            !cardEffects.TryGet(effectId, out var effect) || effect == null || effect.OwnerPlayerId != ownerPlayerId ||
            effect.Definition.Kind != WarCardEffectKind.Ammo || owner.Definition.Fraction != target.Definition.Fraction ||
            phase != BattlePhase.Running) return false;
        var maximum = target.Weapon.ReserveAmmo;
        target.Reserve = Math.Min(maximum, checked(target.Reserve + trustedAmount));
        stateRevision++; return true;
    }

    internal bool TryResolveCardShield(string ownerPlayerId, string effectId, string targetPlayerId)
    {
        var owner = Find(ownerPlayerId); var target = Find(targetPlayerId);
        if (owner?.Admitted != true || target?.Admitted != true ||
            !cardEffects.TryGet(effectId, out var effect) || effect == null || effect.OwnerPlayerId != ownerPlayerId ||
            effect.Definition.Kind != WarCardEffectKind.Shield || owner.Definition.Fraction != target.Definition.Fraction ||
            phase != BattlePhase.Running || effect.Lease.ExpiresTick <= tick) return false;
        var seconds = (effect.Lease.ExpiresTick - tick) / (float)MatchManifest.TickRate;
        return target.Status.Apply(effectId, tick, seconds, stackable: false);
    }

    internal bool TryResolveCardModifier(string ownerPlayerId, string effectId, string targetPlayerId)
    {
        var owner = Find(ownerPlayerId); var target = Find(targetPlayerId);
        if (owner?.Admitted != true || target?.Admitted != true ||
            !cardEffects.TryGet(effectId, out var effect) || effect == null || effect.OwnerPlayerId != ownerPlayerId ||
            effect.Definition.Kind != WarCardEffectKind.Modifier || owner.Definition.Fraction != target.Definition.Fraction ||
            phase != BattlePhase.Running || effect.Lease.ExpiresTick <= tick) return false;
        var seconds = (effect.Lease.ExpiresTick - tick) / (float)MatchManifest.TickRate;
        return target.Status.Apply(effectId, tick, seconds, stackable: true);
    }

    internal bool TryRegisterObjectiveState(string playerId, IReadOnlyDictionary<BattleObjectiveKind,int> targets)
    {
        if (Find(playerId)?.Admitted != true || objectives.ContainsKey(playerId)) return false;
        objectives.Add(playerId, new BattleObjectiveState(targets));
        stateRevision++;
        return true;
    }

    internal void ConfigureVehicleDamage(Func<ulong, float> resolver)
    {
        if (resolver == null || vehicleDamage != null) throw new InvalidOperationException("Vehicle damage authority must be bound once.");
        vehicleDamage = resolver;
    }

    internal bool TryConfigureArena(string playerId, string eventId, int startingLives)
    {
        if (Find(playerId)?.Admitted != true || arenaState != null) return false;
        arenaPolicy = new WarArenaPolicy(eventId);
        if (!arenaPolicy.TryEnter(playerId)) return false;
        arenaState = new WarArenaBattleState(startingLives);
        arenaPlayerId = playerId; arenaRevision++;
        stateRevision++;
        return true;
    }

    internal bool TrySettleArena(string settlementId, bool won)
    {
        if (arenaState == null || !arenaState.Settle(settlementId, won)) return false;
        arenaState.Validate(); arenaRevision++; stateRevision++;
        Emit(MatchEventKind.ArenaSettled, arenaPlayerId, "", 0, Vector3.Zero, 0,
            settlementId + (won ? ":won" : ":lost"));
        return true;
    }

    internal bool TryConfigureCoop(int totalWaves, ulong deadlineTick)
    {
        if (coopMission != null || phase != BattlePhase.Waiting) return false;
        coopMission = new CoopMissionState(totalWaves, deadlineTick);
        stateRevision++;
        return true;
    }

    internal bool TryConfigureCoop(int totalWaves, ulong deadlineTick, CoopMissionModifiers modifiers)
    {
        if (!CoopMissionModifiersValidator.Validate(modifiers).Equals(modifiers)) return false;
        if (!TryConfigureCoop(totalWaves, deadlineTick)) return false;
        coopModifiers = modifiers;
        return true;
    }

    internal bool TryAdmitCoop(string playerId) =>
        coopMission != null && Find(playerId)?.Admitted == true && coopMission.Admit(playerId);

    internal bool TryReadyCoop(string playerId)
    {
        if (coopMission == null || Find(playerId)?.Admitted != true || !coopMission.MarkReady(playerId)) return false;
        coopMission.Validate();
        stateRevision++;
        return true;
    }

    internal bool TryLeaveCoop(string playerId)
    {
        if (coopMission == null || Find(playerId)?.Admitted != true || !coopMission.Leave(playerId)) return false;
        coopMission.Validate();
        stateRevision++;
        return true;
    }

    internal bool TryAdvanceCoop(string eventId, bool success)
    {
        if (coopMission == null || !coopMission.AdvanceWave(eventId, success)) return false;
        coopMission.Validate();
        stateRevision++;
        return true;
    }

    internal bool TryRegisterInteractable(BattleInteractable interactable) => interactables.TryRegister(interactable);

    internal bool TryRecordObjective(string eventId, int entityId, string playerId, int amount)
    {
        if (Find(playerId)?.Admitted != true || !objectives.TryGetValue(playerId, out var state)) return false;
        if (!interactables.TryRecord(eventId, entityId, playerId, state, amount)) return false;
        performance.RecordObjective(eventId);
        stateRevision++;
        Emit(MatchEventKind.ObjectiveProgress, playerId, "", (ulong)entityId,
            Vector3.Zero, amount, eventId);
        return true;
    }

    internal bool TryRecordRibbon(string ribbonId)
    {
        var added = ribbons.Record(ribbonId);
        if (added) stateRevision++;
        return added;
    }

    internal bool TryConfigureVehicleFamilies(IReadOnlyDictionary<string,int> familyCaps)
    {
        if (vehicles != null || phase != BattlePhase.Waiting) return false;
        vehicles = new VehicleEntityRegistry(familyCaps);
        stateRevision++;
        return true;
    }

    internal bool TryRegisterVehicle(VehicleEntity entity)
    {
        if (vehicles == null || Find(entity.OwnerPlayerId)?.Admitted != true) return false;
        if (!vehicles.TrySpawn(entity)) return false;
        stateRevision++;
        Emit(MatchEventKind.VehicleSpawned, entity.OwnerPlayerId, entity.UnitId,
            entity.EntityId, Vector3.Zero, 0, entity.Generation.ToString());
        return true;
    }

    internal bool TryBindVehicleHealth(ulong entityId, float maximumHealth) =>
        vehicles != null && vehicles.TryBindHealth(entityId, maximumHealth);

    internal bool TryBindVehiclePart(VehiclePartState part) => vehicles != null && vehicles.TryBindPart(part);

    internal bool TrySetVehiclePassenger(string ownerPlayerId, ulong entityId, uint generation,
        string partId, string? passengerPlayerId)
    {
        if (vehicles == null || Find(ownerPlayerId)?.Admitted != true ||
            !vehicles.TryGet(entityId, out var vehicle) || vehicle == null || vehicle.OwnerPlayerId != ownerPlayerId ||
            (passengerPlayerId != null && Find(passengerPlayerId)?.Admitted != true)) return false;
        return vehicles.TrySetPassenger(entityId, generation, partId, passengerPlayerId);
    }

    internal bool TryDamageVehiclePart(string attackerPlayerId, ulong entityId, uint generation,
        string partId, float trustedDamage)
    {
        if (vehicles == null || phase != BattlePhase.Running || Find(attackerPlayerId)?.Admitted != true ||
            !vehicles.TryGet(entityId, out var vehicle) || vehicle == null ||
            Find(vehicle.OwnerPlayerId)?.Admitted != true ||
            Find(attackerPlayerId)!.Definition.Fraction == Find(vehicle.OwnerPlayerId)!.Definition.Fraction) return false;
        return vehicles.TryDamagePart(entityId, generation, partId, trustedDamage, out _);
    }

    internal bool TryDamageVehicle(string attackerPlayerId, ulong entityId, float trustedDamage)
    {
        if (vehicles == null || phase != BattlePhase.Running || Find(attackerPlayerId)?.Admitted != true ||
            !vehicles.TryGet(entityId, out var vehicle) || vehicle == null ||
            Find(vehicle.OwnerPlayerId)?.Admitted != true ||
            Find(attackerPlayerId)!.Definition.Fraction == Find(vehicle.OwnerPlayerId)!.Definition.Fraction)
            return false;
        if (!vehicles.TryDamage(entityId, trustedDamage, out _, out var destroyed)) return false;
        if (destroyed) TryDestroyVehicle(vehicle.OwnerPlayerId, entityId, vehicle.Generation);
        return true;
    }

    internal bool TryDestroyVehicle(string ownerPlayerId, ulong entityId, uint generation)
    {
        if (vehicles == null || Find(ownerPlayerId)?.Admitted != true) return false;
        var entity = vehicles.Snapshot().SingleOrDefault(x => x.EntityId == entityId);
        if (entity == null || entity.OwnerPlayerId != ownerPlayerId || entity.Generation != generation) return false;
        if (!vehicles.TryDestroy(entityId, generation)) return false;
        vehicleShotTargets.Remove(entityId);
        foreach (var projectile in vehicleProjectiles.Where(x => x.Value.VehicleId == entityId).Select(x => x.Key).ToArray())
            vehicleProjectiles.Remove(projectile);
        stateRevision++;
        Emit(MatchEventKind.VehicleDestroyed, ownerPlayerId, entity.UnitId, entityId,
            Vector3.Zero, 0, generation.ToString());
        return true;
    }

    internal bool TryMoveVehicle(string ownerPlayerId, ulong entityId, Vector3 next, float sourceSpeed)
    {
        if (vehicles == null || !vehicles.TryGet(entityId, out var entity) || entity == null ||
            entity.OwnerPlayerId != ownerPlayerId || Find(ownerPlayerId)?.Admitted != true) return false;
        if (!vehicles.TryMove(entityId, next, sourceSpeed)) return false;
        stateRevision++;
        return true;
    }

    internal bool TryValidateVehicleTarget(string ownerPlayerId, string targetPlayerId,
        Vector3 origin, Vector3 target, float maxRange, out VehicleTarget validated)
    {
        validated = default;
        if (vehicles == null || Find(ownerPlayerId)?.Admitted != true || Find(targetPlayerId)?.Admitted != true)
            return false;
        try
        {
            validated = VehicleTargetPolicy.Validate(ownerPlayerId, targetPlayerId, origin, target, maxRange);
            return Find(ownerPlayerId)!.Definition.Fraction != Find(targetPlayerId)!.Definition.Fraction;
        }
        catch (InvalidDataException) { return false; }
    }

    internal PlayerDamageResult? ResolveVehicleImpact(string ownerPlayerId, ulong entityId,
        string victimPlayerId, Vector3 hitPosition, float radius, float trustedDamage)
    {
        if (vehicles == null || phase != BattlePhase.Running ||
            !vehicles.TryGet(entityId, out var vehicle) || vehicle == null ||
            vehicle.OwnerPlayerId != ownerPlayerId || Find(ownerPlayerId)?.Admitted != true ||
            Find(victimPlayerId)?.Admitted != true ||
            Find(ownerPlayerId)!.Definition.Fraction == Find(victimPlayerId)!.Definition.Fraction)
            return null;
        var impact = VehicleImpactResolver.Resolve(entityId, ownerPlayerId, victimPlayerId,
            vehicle.Position, hitPosition, radius, trustedDamage);
        return ApplyResolvedPlayerDamage(ownerPlayerId, victimPlayerId,
            new ResolvedPlayerDamage(impact.Damage, CombatDamageType.Shot, HasWeapon: false), 1, false);
    }

    internal bool TryBeginVehicleAttack(string ownerPlayerId, ulong entityId, bool eligible, int windupTicks)
    {
        if (vehicles == null || Find(ownerPlayerId)?.Admitted != true ||
            !vehicles.TryGet(entityId, out var vehicle) || vehicle?.OwnerPlayerId != ownerPlayerId)
            return false;
        return vehicles.TryBeginAttack(entityId, eligible, windupTicks);
    }

    internal bool TryAdvanceVehicleAttack(string ownerPlayerId, ulong entityId, out bool shotDue)
    {
        shotDue = false;
        if (vehicles == null || Find(ownerPlayerId)?.Admitted != true ||
            !vehicles.TryGet(entityId, out var vehicle) || vehicle?.OwnerPlayerId != ownerPlayerId)
            return false;
        shotDue = vehicles.AdvanceAttack(entityId);
        return true;
    }

    internal bool TryCommitVehicleAttack(string ownerPlayerId, ulong entityId, out bool realShot)
    {
        realShot = false;
        if (vehicles == null || Find(ownerPlayerId)?.Admitted != true ||
            !vehicles.TryGet(entityId, out var vehicle) || vehicle?.OwnerPlayerId != ownerPlayerId ||
            !vehicles.TryGetAttack(entityId, out var attack) || attack == null || !attack.ShotDue)
            return false;
        realShot = attack.CurrentShotIsReal;
        var committed = vehicles.TryCommitAttack(entityId);
        if (committed && realShot && vehicleShotTargets.TryGetValue(entityId, out var target) &&
            vehicles.TryGet(entityId, out var source) && source != null)
        {
            var id = checked(++projectileId);
            vehicleProjectiles.Add(id, new VehicleProjectileFlight(id, entityId, source.Position,
                target.Position, attack.ShotSpeed, tick, (origin, direction, distance) =>
            {
                var delta = target.Position - origin;
                var length = delta.Length();
                return length <= distance + .001f
                    ? new ShotCollision(length, target.Position, "vehicle-target", target.Target, 1)
                    : null;
            }));
            stateRevision++;
        }
        return committed;
    }

    internal IReadOnlyList<ActiveWarCardEffect> ActiveCardEffects(string ownerPlayerId)
    {
        if (Find(ownerPlayerId)?.Admitted != true) throw new InvalidOperationException("Card effects need admission.");
        return cardEffects.ActiveForOwner(ownerPlayerId);
    }

    internal bool TryTriggerDeployable(string playerId, int entityId)
    {
        if (Find(playerId)?.Admitted != true || phase is not (BattlePhase.Countdown or BattlePhase.Running))
            return false;
        var entity = deployables.Snapshot().SingleOrDefault(x => x.EntityId == entityId);
        if (entity == null || entity.State != DeployableState.Armed ||
            (entity.CardId == "LandMine" && entity.OwnerPlayerId == playerId) ||
            (entity.CardId == "HeavyTurret" && entity.OwnerPlayerId != playerId))
            return false;
        if (!deployables.TryTrigger(entityId)) return false;
        stateRevision++;
        if (deployables.Snapshot().Single(x => x.EntityId == entityId).State == DeployableState.Triggered)
        {
            Emit(MatchEventKind.DeployableDespawned, entity.OwnerPlayerId, playerId,
                (ulong)entity.EntityId, entity.Position, 0, "triggered");
            deployables.TryDespawn(entityId);
        }
        return true;
    }

    internal bool TryTriggerDeployable(string playerId, int entityId, string eventId)
    {
        if (Find(playerId)?.Admitted != true || phase is not (BattlePhase.Countdown or BattlePhase.Running)) return false;
        var entity = deployables.Snapshot().SingleOrDefault(x => x.EntityId == entityId);
        if (entity == null || entity.State != DeployableState.Armed ||
            (entity.CardId == "LandMine" && entity.OwnerPlayerId == playerId) ||
            (entity.CardId == "HeavyTurret" && entity.OwnerPlayerId != playerId)) return false;
        if (!deployables.TryTrigger(entityId, eventId)) return false;
        stateRevision++;
        if (deployables.Snapshot().Single(x => x.EntityId == entityId).State == DeployableState.Triggered)
        {
            Emit(MatchEventKind.DeployableDespawned, entity.OwnerPlayerId, playerId,
                (ulong)entity.EntityId, entity.Position, 0, "triggered");
            deployables.TryDespawn(entityId);
        }
        return true;
    }

    internal PlayerDamageResult? ResolveDeployableDamage(string attackerId, int entityId,
        string victimId, float radius, float trustedDamage)
    {
        if (Find(attackerId)?.Admitted != true || Find(victimId)?.Admitted != true ||
            phase != BattlePhase.Running) return null;
        if (!deployables.Snapshot().Any(x => x.EntityId == entityId && x.OwnerPlayerId == attackerId))
            return null;
        var victim = Find(victimId)!;
        if (victim.Definition.Fraction == Find(attackerId)!.Definition.Fraction) return null;
        var source = deployables.Snapshot().Single(x => x.EntityId == entityId);
        var impact = DeployableImpactResolver.Resolve(entityId, victimId, source.Position,
            victim.Position, radius, trustedDamage);
        var hit = new ResolvedPlayerDamage(impact.Damage, CombatDamageType.Explosion,
            HasWeapon: false, ExplosiveCoefficient: 1);
        return ApplyResolvedPlayerDamage(attackerId, victimId, hit, 1, false);
    }

    // A host-owned binding is required. Reference poses are not silently enabled
    // for the live Worker, and packets cannot install a resolver or damage profile.
    internal void ConfigureProjectiles(Func<ulong, string, Vector3, ulong, PreparedProjectile> prepare, Func<float> roll)
    {
        ArgumentNullException.ThrowIfNull(prepare);
        ConfigureVolley((id,owner,target,tick)=>[prepare(id,owner,target,tick)],roll);
    }

    internal void ConfigureVolley(Func<ulong,string,Vector3,ulong,IReadOnlyList<PreparedProjectile>> prepare,Func<float> roll)
    {
        if (phase != BattlePhase.Waiting || players.Any(p => p.Admitted) || prepareVolley != null)
            throw new InvalidOperationException("Projectile authority must be bound once before admission.");
        ArgumentNullException.ThrowIfNull(prepare);
        ArgumentNullException.ThrowIfNull(roll);
        if (players.Any(p => p.Definition.Combat == null)) throw new InvalidDataException("Projectile combat needs both player combat definitions.");
        prepareVolley = prepare;
        damageRoll = roll ?? throw new ArgumentNullException(nameof(roll));
    }
    private sealed class WeaponRuntime(WeaponSlotManifest definition)
    {
        public WeaponSlotManifest Definition { get; }=definition;
        public int Clip=definition.Weapon.ClipSize;
        public int Reserve=definition.Weapon.ReserveAmmo;
        public ulong ReloadEnd;
        public ulong NextFire;
    }
    private sealed class Player
    {
        public Player(ParticipantManifest definition)
        {
            Definition=definition;
            var slots=definition.WeaponSlots ?? [new WeaponSlotManifest(0,0,definition.Weapon,definition.WeaponUpgrade??0)];
            Weapons=slots.ToDictionary(x=>x.Slot,x=>new WeaponRuntime(x));ActiveSlot=slots[0].Slot;
            Health=definition.Combat?.MaxHealth??0;
        }
        public ParticipantManifest Definition { get; }
        public readonly Dictionary<int,WeaponRuntime> Weapons;
        public int ActiveSlot;
        public WeaponRuntime Current=>Weapons[ActiveSlot];
        public WeaponManifest Weapon=>Current.Definition.Weapon;
        public int Clip {get=>Current.Clip;set=>Current.Clip=value;}
        public int Reserve {get=>Current.Reserve;set=>Current.Reserve=value;}
        public ulong ReloadEnd {get=>Current.ReloadEnd;set=>Current.ReloadEnd=value;}
        public ulong NextFire {get=>Current.NextFire;set=>Current.NextFire=value;}
        public bool Admitted;
        public bool Ready;
        public ulong LastSeen;
        public bool Reconnecting;
        public uint ReconnectAttempts;
        public ulong ReconnectDeadlineHostTick;
        public ulong Shots;
        public ulong LastCommand;
        public int Cover = -1;
        public Vector3 Position;
        public Vector3[]? Route;
        public ulong MoveStart;
        public ulong MoveEnd;
        public int Destination;
        public string LastGeometryHit = "";
        public float Health;
        public bool Dead;
        public ulong DamageRevision;
        public uint ConfirmedPlayerHits;
        public uint ConfirmedEnemyHits;
        public uint ConfirmedPlayerKills;
        public uint ConfirmedArmySpawns;
        public uint ConfirmedArmyLosses;
        public ulong EventAck;
        public readonly StatusEffectState Status = new();
        public readonly Dictionary<ulong, (byte[] Payload, MatchReply Reply)> Receipts = [];
        public ArmyDeploymentState? Army;
        public IReadOnlyList<string> SelectedCards = Array.Empty<string>();
        public bool CardsSelected;
        public IReadOnlyList<string> SelectedBuddyCards = Array.Empty<string>();
        public IReadOnlyList<int> NormalUpgradeIndexes = Array.Empty<int>();
        public IReadOnlyList<int> SpecialUpgradeIndexes = Array.Empty<int>();
        public IReadOnlyList<int> EliteUpgradeIndexes = Array.Empty<int>();
    }
    public string MatchId => manifest.MatchId;
    internal PlayerAimPose CombatPose(string id)=>rifleCombat?.Pose(id) ?? throw new InvalidOperationException("No rifle simulation.");
    internal IReadOnlyList<BarrelMutation> BarrelState=>barrels?.Snapshot() ?? Array.Empty<BarrelMutation>();
    public string ManifestHash { get; }
    public bool Terminal => phase is BattlePhase.Ended or BattlePhase.Aborted;
    private readonly Func<int,int> armyChoice;
    public MatchEngine(MatchManifest definition, RecoveredBattleMap? map = null,
        BattleCombatContent? content=null,Func<int,int>? armyChoice=null)
    {
        this.armyChoice=armyChoice??Random.Shared.Next;
        manifest = MatchManifest.Validate(definition);
        if (content!=null) content.ValidateAllocation(manifest);
        else if (manifest.Players.Any(p=>p.WeaponUpgrade.HasValue)) throw new InvalidDataException("Source-bound upgrades require a verified combat package.");
        ManifestHash = manifest.Digest();
        players = manifest.Players.Select(p => new Player(p)).ToArray();
        if(manifest.Players[0].EquippedArmyUnitIds!=null)
        {
            if(content==null)throw new InvalidDataException("Army allocation requires a pinned combat package.");
            foreach(var player in players)
                player.Army=new ArmyDeploymentState(content.Army,player.Definition.EquippedArmyUnitIds!,
                    player.Definition.NewArmyUnitIds);
        }
        if (manifest.Mode is MatchManifest.RifleCombatMode or MatchManifest.ShotgunCombatMode or MatchManifest.SmgCombatMode or MatchManifest.PistolCombatMode or MatchManifest.LmgCombatMode or MatchManifest.MinigunCombatMode or MatchManifest.SniperCombatMode or MatchManifest.BazookaCombatMode or MatchManifest.GrenadeCombatMode or MatchManifest.MixedCombatMode)
            map=content?.Maps.SingleOrDefault(m=>System.IO.Path.GetFileNameWithoutExtension(m.Source)==manifest.MapId)
                ?? throw new InvalidDataException("Rifle combat requires its map in the pinned package.");
        this.map = map;
        if(players[0].Army!=null)
        {
            if(map==null || content==null)throw new InvalidDataException("Army authority needs the pinned scene.");
            armyCatalog=content.Army;
            armyWeapons=content.ArmyWeapons;
            armySelector=new ArmySpawnPointSelector(content.ArmySpawnPoints);
            armyRusherPoints=content.ArmyRusherPoints;
            armyMinigunnerPoints=content.ArmyMinigunnerPoints;
            armyNavMeshConnectivity=content.ArmyNavMeshConnectivity;
            playerShotTargets=content.PlayerShotTargets;
            armyReservations=new ArmySpawnReservationLedger(content.ArmySpawnPoints,map);
        }
        if (map != null)
        {
            if (manifest.MapId != System.IO.Path.GetFileNameWithoutExtension(map.Source) || manifest.MapRevision != map.SourceHash)
                throw new InvalidDataException("Manifest map identity/revision does not bind recovered content.");
            foreach (var p in players)
            {
                var d = p.Definition;
                if (d.StartCover < 0 || d.StartCover >= map.Covers.Count || d.MovementSpeed <= 0 || !map.Covers[d.StartCover].Main || map.Covers[d.StartCover].Fraction != d.Fraction)
                    throw new InvalidDataException("Map participant needs a source-bound start cover, side and trusted movement speed.");
                p.Cover = d.StartCover;
                p.Position = map.Covers[d.StartCover].Position;
            }
            if (players[0].Definition.Fraction == players[1].Definition.Fraction) throw new InvalidDataException("This duel slice requires opposing sides.");
        }
        admissionDeadline = (ulong)manifest.AdmissionSeconds * MatchManifest.TickRate;
        if (manifest.Mode is MatchManifest.RifleCombatMode or MatchManifest.ShotgunCombatMode or MatchManifest.SmgCombatMode or MatchManifest.PistolCombatMode or MatchManifest.LmgCombatMode or MatchManifest.MinigunCombatMode or MatchManifest.SniperCombatMode or MatchManifest.BazookaCombatMode or MatchManifest.GrenadeCombatMode or MatchManifest.MixedCombatMode)
        {
            if (map==null || content==null) throw new InvalidDataException("Live combat needs source map and combat package.");
            if(manifest.Players.All(p=>p.ShieldLevel.HasValue))
                shields=new ShieldMatchSimulation(map,content.Shields,manifest);
            if(manifest.SceneMasterPlayerId!=null)
            {
                barrels=new BarrelMatchSimulation(map,content.Barrels,content.BarrelPolicy,
                    content.BarrelOverlap,manifest);
                explosionPolicy=content.Explosions;
            }
            if(manifest.Mode==MatchManifest.GrenadeCombatMode)
            {
                grenadeCatalog=content.Grenades??throw new InvalidDataException("Grenade mode requires its pinned package.");
                grenadeCombat=new GrenadeMatchSimulation(manifest,map,grenadeCatalog,
                    shields==null?null:shields.ColliderEnabled,barrels==null?null:barrels.ColliderEnabled,
                    barrels==null?null:barrels.RuntimeLayer);damageRoll=Random.Shared.NextSingle;
            }
            else
            {
                rifleCombat=new RifleMatchSimulation(manifest,map,content,
                    shields==null?null:shields.ColliderEnabled,
                    barrels==null?null:barrels.ColliderEnabled,
                    barrels==null?null:barrels.RuntimeLayer);
                ConfigureVolley(rifleCombat.PrepareVolley,Random.Shared.NextSingle);
                bazookaCatalog=content.Bazookas;
            }
        }
    }
    public bool HasPlayer(string id) => players.Any(p => p.Definition.PlayerId == id);
    private Player? Find(string id) => players.FirstOrDefault(p => p.Definition.PlayerId == id);
    public bool Admit(string id)
    {
        var p = Find(id);
        if (p == null || Terminal || phase != BattlePhase.Waiting || tick >= admissionDeadline) return false;
        p.Admitted = true;
        p.LastSeen = hostTick;
        stateRevision++;
        return true;
    }
    public bool Resume(string id)
    {
        var p = Find(id);
        if (p == null || !p.Admitted || Terminal) return false;
        p.LastSeen = hostTick;
        p.Reconnecting=false;
        p.ReconnectDeadlineHostTick=0;
        stateRevision++;
        return true;
    }
    internal bool CancelBeforeStart()
    {
        if(Terminal || phase is not (BattlePhase.Waiting or BattlePhase.Countdown))return false;
        End("cancelled-before-start","",false);
        return true;
    }
    internal bool AbortForHostShutdown()
    {
        if(Terminal)return false;
        End("host-shutdown","",false);
        return true;
    }
    public void Advance(ulong nextTick)
    {
        if (nextTick < hostTick || nextTick > 10000000) throw new ArgumentOutOfRangeException(nameof(nextTick));
        ulong elapsed=nextTick-hostTick;
        hostTick=nextTick;
        if (Terminal) return; // Preserve the exact terminal tick and result projection.
        if(phase==BattlePhase.Running && players.Any(p=>p.Reconnecting))
        {
            if(elapsed>0)stateRevision++;
            var expired=players.Where(p=>p.Reconnecting && hostTick>=p.ReconnectDeadlineHostTick).ToArray();
            if(expired.Length>0)
            {
                var active=players.Where(p=>!p.Reconnecting &&
                    hostTick-p.LastSeen<(ulong)manifest.IdleSeconds*MatchManifest.TickRate).ToArray();
                End(expired.Length==1 && active.Length==1?"opponent-disconnected":"both-disconnected",
                    active.Length==1 && expired.Length==1?active[0].Definition.PlayerId:"",
                    active.Length==1 && expired.Length==1);
            }
            return;
        }
        ulong simulationTick=checked(tick+elapsed);
        if ((projectiles.Count != 0||bazookaProjectiles.Count!=0||scheduledBazookas.Count!=0||grenadeProjectiles.Count!=0) && simulationTick > tick+1) throw new InvalidOperationException("Active projectiles require every simulation tick.");
        if ((rifleCombat!=null||grenadeCombat!=null) && phase==BattlePhase.Running && simulationTick>tick+1) throw new InvalidOperationException("Live combat playback requires every simulation tick.");
        bool advanced=simulationTick!=tick;
        if (advanced) stateRevision++;
        tick = simulationTick;
        if (advanced && vehicles != null)
            foreach (var vehicle in vehicles.Snapshot())
            {
                if (vehicles.AdvanceAttack(vehicle.EntityId) && vehicles.TryGetAttack(vehicle.EntityId, out var attack) &&
                    attack != null && attack.ShotDue)
                    TryCommitVehicleAttack(vehicle.OwnerPlayerId, vehicle.EntityId, out _);
            }
        if (advanced && phase == BattlePhase.Running && vehicleProjectiles.Count > 0)
        {
            foreach (var pair in vehicleProjectiles.ToArray())
            {
                VehicleProjectileImpact? impact;
                try { impact = pair.Value.Advance(tick); }
                catch (InvalidDataException) { End("invalid-vehicle-projectile-authority", "", false); break; }
                if (pair.Value.Finished) vehicleProjectiles.Remove(pair.Key);
                if (impact != null)
                {
                    stateRevision++;
                    var owner = vehicleShotTargets.TryGetValue(impact.VehicleId, out var target) ? target.Owner : "";
                    Emit(MatchEventKind.Impact, owner,
                        impact.Collision.PlayerId ?? "", impact.ProjectileId, impact.Collision.Position, 0, "vehicle");
                    if (vehicleDamage != null && target.Target == impact.Collision.PlayerId &&
                        float.IsFinite(vehicleDamage(impact.VehicleId)) && vehicleDamage(impact.VehicleId) > 0)
                        ApplyResolvedPlayerDamage(owner, target.Target,
                            new ResolvedPlayerDamage(vehicleDamage(impact.VehicleId), CombatDamageType.Shot, HasWeapon: false), 1, false);
                }
            }
            if (Terminal) return;
        }
        if (advanced && coopMission != null && coopMission.AdvanceClock(tick)) stateRevision++;
        foreach (var player in players) player.Status.Expire(tick);
        if(shields!=null)
        {
            try
            {
                foreach(var repaired in shields.Advance(tick))
                {stateRevision++;EmitShield(MatchEventKind.ShieldRepaired,"",repaired,0);}
            }
            catch(InvalidDataException){End("invalid-shield-authority","",false);return;}
        }
        if (phase == BattlePhase.Waiting && tick >= admissionDeadline) { End("admission-timeout", "", false); return; }
        if (phase is not (BattlePhase.Running or BattlePhase.Countdown)) return;
        if (phase == BattlePhase.Running && !overtime && tick >= endTick)
        {
            if(manifest.Mode==MatchManifest.PrototypeMode){End("duration-limit","",false);return;}
            BeginOvertime();
            if(Terminal)return;
        }
        var idle = players.Where(p => hostTick - p.LastSeen >= (ulong)manifest.IdleSeconds * MatchManifest.TickRate).ToArray();
        if (idle.Length > 0)
        {
            if(phase==BattlePhase.Countdown)
            {
                End("prestart-disconnect","",false);
                return;
            }
            if(idle.Length==2){End("both-disconnected","",false);return;}
            var disconnected=idle[0];
            disconnected.ReconnectAttempts++;
            if(disconnected.ReconnectAttempts>3)
            {
                End("opponent-disconnected",players.Single(p=>p!=disconnected).Definition.PlayerId,true);
                return;
            }
            RemoveOwnedDeployables(disconnected.Definition.PlayerId);
            disconnected.Reconnecting=true;
            uint grace=disconnected.ReconnectAttempts switch {1=>30,2=>20,_=>10};
            disconnected.ReconnectDeadlineHostTick=hostTick+grace*MatchManifest.TickRate;
            stateRevision++;
            return;
        }
        if (phase == BattlePhase.Countdown && tick >= startTick)
        {
            phase = BattlePhase.Running;
            if (performance.StartTick == 0) performance.Start(tick == 0 ? 1 : tick);
        }
        if (phase == BattlePhase.Running && !overtime && tick >= endTick)
        {
            if(manifest.Mode==MatchManifest.PrototypeMode){End("duration-limit","",false);return;}
            BeginOvertime();
            if(Terminal)return;
        }
        foreach (var p in players)
        {
            AdvanceMovement(p);
            foreach(var weapon in p.Weapons.Values)
            {
                if(weapon.ReloadEnd==0 || tick<weapon.ReloadEnd)continue;
                int transfer=Math.Min(weapon.Definition.Weapon.ClipSize-weapon.Clip,weapon.Reserve);
                weapon.Clip+=transfer;
                // Recovered Pistol.ammoLeft is an immutable int.MaxValue getter;
                // its setter is intentionally empty, so reserve never decreases.
                if(weapon.Reserve!=int.MaxValue)weapon.Reserve-=transfer;
                weapon.ReloadEnd=0;
            }
        }
        if(phase==BattlePhase.Running && armySelector!=null)
        {
            try
            {
                foreach(var p in players)
                {
                    foreach(var spawned in p.Army!.Advance(tick))
                    {
                        var family=armyCatalog!.Families.Single(f=>f.Options.Any(o=>o.Index==spawned.OptionIndex));
                        var point=armySelector.Select(map!,family,p.Definition.Fraction,
                            players.Single(other=>other!=p).Position,armyChoice,armyReservations!.Available);
                        ulong entityKey=((ulong)p.Definition.Fraction<<32)|(uint)spawned.EntityId;
                        if(point==null || !armyReservations.TryReserve(point,entityKey))
                            throw new InvalidDataException("Spawn point became unavailable after army acceptance.");
                        if(ArmyRusherPointCatalog.IsRusher(family.BehaviorType))
                            ReserveRusherSlot(entityKey,players.Single(other=>other!=p).Cover,point.Position);
                        InitializeArmyVitality(p.Definition,spawned.UnitId,entityKey);
                        activeArmyEntities.Add(entityKey,new BattleArmyEntityState
                        {EntityKey=entityKey,OwnerPlayerId=p.Definition.PlayerId,
                            OwnerFraction=p.Definition.Fraction,LocalEntityId=spawned.EntityId,
                            OptionIndex=spawned.OptionIndex,UnitId=spawned.UnitId,
                            SpawnComponentFileId=point.ComponentFileId,
                            ReservationFileId=point.ReservationFileId,
                            X=point.Position.X,Y=point.Position.Y,Z=point.Position.Z,SpawnTick=tick,
                            PositionTick=tick,
                            MaxHealth=ArmyHealth(entityKey)??0,Health=ArmyHealth(entityKey)??0});
                        var vitality=armyVitality.GetValueOrDefault(entityKey);
                        if(vitality!=null)
                        {
                            activeArmyEntities[entityKey].MaxKevlar=vitality.KevlarMaximum;
                            activeArmyEntities[entityKey].Kevlar=vitality.Kevlar;
                        }
                        InitializeRusherMotionCandidate(entityKey,spawned.UnitId);
                        InitializeStationaryArmyCombat(entityKey,spawned.UnitId);
                        p.ConfirmedArmySpawns=checked(p.ConfirmedArmySpawns+1);
                        armyEntityRevision++;
                        Emit(MatchEventKind.ArmySpawned,p.Definition.PlayerId,"",0,point.Position,0,"");
                        var row=events[^1];
                        row.ArmyEntityId=spawned.EntityId;row.ArmyOptionIndex=spawned.OptionIndex;
                        row.ArmyUnitId=spawned.UnitId;row.ArmySpawnComponentFileId=point.ComponentFileId;
                        row.ArmyReservationFileId=point.ReservationFileId;
                        stateRevision++;
                    }
                }
            }
            catch(InvalidDataException){End("invalid-army-authority","",false);return;}
        }
        if(advanced && phase==BattlePhase.Running && (rusherMotionCandidates.Count>0||warperRelocations.Count>0))
        {
            try { if(warperRestartTicks.Count>0)StartDueWarperRestarts();
                  if(warperRelocations.Count>0)AdvanceWarperRelocations();
                  if(rusherMotionCandidates.Count>0)AdvanceRusherMotionCandidates(); }
            catch(InvalidDataException){End("invalid-army-authority","",false);return;}
        }
        if(advanced && phase==BattlePhase.Running &&
           (minigunnerMovements.Count>0||minigunnerAttacks.Count>0))
        {
            try { if(minigunnerAttacks.Count>0)AdvanceMinigunnerAttacks();
                  if(minigunnerMovements.Count>0)AdvanceMinigunnerMovements(); }
            catch(InvalidDataException){End("invalid-army-authority","",false);return;}
        }
        if(advanced && phase==BattlePhase.Running && (armyProjectiles.Count>0||armyFlameBursts.Count>0||armyPoisons.Count>0))
        {
            if(armyProjectiles.Count>0)AdvanceArmyProjectiles();
            if(armyFlameBursts.Count>0)
            {
                try { AdvanceArmyFlameBursts(); }
                catch(InvalidDataException){End("invalid-army-flame-authority","",false);return;}
            }
            if(armyPoisons.Count>0)
            {
                try { AdvanceArmyPoisons(); }
                catch(InvalidDataException){End("invalid-army-poison-authority","",false);return;}
            }
            if(Terminal)return;
        }
        if (advanced && phase == BattlePhase.Running && airEntities.Count > 0)
        {
            foreach (var air in airEntities.Snapshot())
                air.AdvanceTick();
        }
        if (advanced && phase == BattlePhase.Running && deployables.Count > 0)
        {
            deployables.AdvanceTick();
            if (deployables.RemoveExpired() > 0) stateRevision++;
        }
        if (advanced && phase == BattlePhase.Running)
        {
            var expiredEffects = cardEffects.ExpireAndReturn(tick);
            foreach (var effect in expiredEffects)
            {
                stateRevision++;
                Emit(MatchEventKind.CardEffectExpired, effect.OwnerPlayerId,
                    effect.Definition.CardId, 0, effect.Target, 0, effect.EffectId);
            }
        }
        if (advanced && phase==BattlePhase.Running && rifleCombat!=null)
        {
            try {
                foreach(var actor in players)rifleCombat.UpdateSniperReady(actor.Definition.PlayerId,actor.ReloadEnd==0&&tick>=actor.NextFire&&actor.Clip>0,tick);
                rifleCombat.Advance(tick,id=> { var actor=Find(id)!;return new(actor.Position,actor.Cover,actor.Route!=null); },
                (id,target)=> Terminal ? "match-terminal" : Fire(Find(id)!,target)); }
            catch (InvalidDataException) { End("invalid-combat-authority","",false);return; }
        }
        if(advanced&&phase==BattlePhase.Running&&grenadeCombat!=null)
        {
            try{foreach(var launch in grenadeCombat.Advance(tick))StartGrenadeProjectile(launch);}
            catch(InvalidDataException){End("invalid-projectile-authority","",false);return;}
        }
        if(advanced && phase==BattlePhase.Running && scheduledBazookas.Count>0)
        {
            try
            {
                foreach(var launch in scheduledBazookas.Where(x=>x.LaunchTick<=tick).ToArray())
                {
                    scheduledBazookas.Remove(launch);
                    StartBazookaProjectile(launch);
                }
            }
            catch(InvalidDataException){End("invalid-projectile-authority","",false);return;}
        }
        if(advanced && phase==BattlePhase.Running && bazookaProjectiles.Count>0)
        {
            foreach(var pair in bazookaProjectiles.ToArray())
            {
                if(pair.Value.Flight.CurrentTick==tick)continue;
                BazookaMissileImpact? impact;
                try{impact=pair.Value.Flight.Advance(tick);}
                catch(Exception e) when(e is InvalidDataException or InvalidOperationException)
                {End("invalid-projectile-authority","",false);break;}
                if(pair.Value.Flight.Finished)bazookaProjectiles.Remove(pair.Key);
                if(impact==null)continue;
                Emit(MatchEventKind.Impact,impact.OwnerId,impact.Collision?.PlayerId??"",
                    impact.ProjectileId,impact.Position,0,impact.Fake?"bazooka-fake":"bazooka");
                if(impact.Fake)continue;
                try{ApplyBazookaPlayerExplosion(pair.Value,impact);}
                catch(InvalidDataException){End("invalid-combat-authority","",false);break;}
                if(Terminal)break;
            }
            if(Terminal)return;
        }
        if(advanced&&phase==BattlePhase.Running&&grenadeProjectiles.Count>0)
        {
            foreach(var pair in grenadeProjectiles.ToArray())
            {
                if(pair.Value.Flight.CurrentTick==tick)continue;GrenadeFlightImpact? impact;
                try{impact=pair.Value.Flight.Advance(tick);}
                catch(Exception e) when(e is InvalidDataException or InvalidOperationException)
                {End("invalid-projectile-authority","",false);break;}
                if(pair.Value.Flight.Finished)grenadeProjectiles.Remove(pair.Key);
                if(impact==null)continue;
                Emit(MatchEventKind.Impact,impact.OwnerId,impact.Collision.PlayerId??"",impact.ProjectileId,impact.Position,0,
                    pair.Value.Binding.Effect==RecoveredGrenadeEffect.Molotov?"grenade-molotov":"grenade");
                try{ApplyGrenadeExplosion(pair.Value,impact);}
                catch(InvalidDataException){End("invalid-combat-authority","",false);break;}
                if(Terminal)break;
            }
            if(Terminal)return;
        }
        foreach (var pair in projectiles.ToArray())
        {
            BulletImpact? impact;
            try { impact = pair.Value.Flight.Advance(tick); }
            catch (InvalidDataException) { End("invalid-projectile-authority", "", false); break; }
            if (pair.Value.Flight.Finished) projectiles.Remove(pair.Key);
            if (impact!=null) Emit(MatchEventKind.Impact,impact.OwnerId,impact.Hit.PlayerId??"",
                impact.ProjectileId,impact.Hit.Position,0,"");
            if(impact?.Hit.DynamicOwner!=null && shields!=null)
            {
                try
                {
                    var shooter=Find(impact.OwnerId)!;
                    bool enemyShieldHit=shields.IsLiveEnemyShield(impact.Hit.DynamicOwner,shooter.Definition.Fraction);
                    string weaponSource=pair.Value.WeaponSourceId.Length==0
                        ? shooter.Weapon.SourceId : pair.Value.WeaponSourceId;
                    var shield=shields.ApplyShot(impact.Hit.DynamicOwner,shooter.Definition.Fraction,
                        weaponSource,pair.Value.Damage.Amount,tick);
                    // Ammo.DoDamage supplies Weapon.ReportShotHit with the enemy
                    // destroyable even when a valid shot changes no shield HP.
                    if(enemyShieldHit)shooter.ConfirmedEnemyHits=checked(shooter.ConfirmedEnemyHits+1);
                    if(shield!=null)
                    {
                        stateRevision++;
                        EmitShield(shield.Destroyed?MatchEventKind.ShieldDestroyed:MatchEventKind.ShieldDamaged,
                            impact.OwnerId,shield,impact.ProjectileId);
                    }
                }
                catch(InvalidDataException){End("invalid-shield-authority","",false);break;}
            }
            if(impact!=null && barrels!=null && impact.Hit.ColliderIndex is int barrelIndex &&
               barrels.Contains(barrelIndex))
            {
                try {ApplyBarrelImpact(impact,pair.Value.Damage.Amount);}
                catch(InvalidDataException){End("invalid-barrel-authority","",false);break;}
                if(Terminal)break;
            }
            if (impact?.Hit.PlayerId != null)
            {
                try
                {
                    ApplyResolvedPlayerDamage(impact.OwnerId, impact.Hit.PlayerId,
                        pair.Value.Damage with { PartWeight = impact.Hit.PartWeight }, damageRoll!(),true);
                }
                catch (InvalidDataException) { End("invalid-combat-authority", "", false); }
                if (Terminal) break;
            }
        }
    }

    private void RemoveOwnedDeployables(string ownerPlayerId)
    {
        if (cardEffects.RemoveOwner(ownerPlayerId) > 0) stateRevision++;
        foreach (var air in airEntities.Snapshot().Where(x => x.AttackerPlayerId == ownerPlayerId))
        {
            if (!airEntities.TryDespawn(air.EntityKey)) continue;
            stateRevision++;
            Emit(MatchEventKind.AirDespawned, ownerPlayerId, "", air.EntityKey,
                air.Motion.Position, air.Health.Current, "owner-disconnected");
        }
        if (vehicles != null)
        {
            foreach (var vehicle in vehicles.Snapshot().Where(x => x.OwnerPlayerId == ownerPlayerId))
            {
                if (!vehicles.TryDestroy(vehicle.EntityId, vehicle.Generation)) continue;
                vehicleShotTargets.Remove(vehicle.EntityId);
                foreach (var projectile in vehicleProjectiles.Where(x => x.Value.VehicleId == vehicle.EntityId).Select(x => x.Key).ToArray())
                    vehicleProjectiles.Remove(projectile);
                stateRevision++;
                Emit(MatchEventKind.VehicleDestroyed, ownerPlayerId, vehicle.UnitId,
                    vehicle.EntityId, Vector3.Zero, 0, vehicle.Generation.ToString());
            }
        }
        foreach (var entity in deployables.Snapshot().Where(x => x.OwnerPlayerId == ownerPlayerId))
        {
            if (!deployables.TryDespawn(entity.EntityId)) continue;
            stateRevision++;
            Emit(MatchEventKind.DeployableDespawned, ownerPlayerId, "", (ulong)entity.EntityId,
                entity.Position, 0, "owner-disconnected");
        }
    }
    public MatchReply Command(string playerId, MatchCommand command)
    {
        var p = Find(playerId);
        if (p == null || !p.Admitted) return Reply(command.CommandId, "not-admitted");
        if(command.IntentCase==MatchCommand.IntentOneofCase.None || command.CalculateSize()>256)
            return Reply(command.CommandId,"invalid-command");
        if (command.IntentCase == MatchCommand.IntentOneofCase.Poll)
        {
            if (command.CommandId != 0) return Reply(command.CommandId, "invalid-poll-id");
            p.LastSeen = hostTick;
            return Reply(0, "state");
        }
        if (command.CommandId == 0 || command.CommandId > 100000)
            return Reply(command.CommandId, "invalid-command");
        byte[] payload = command.ToByteArray();
        if (p.Receipts.TryGetValue(command.CommandId, out var receipt))
        {
            if (!payload.AsSpan().SequenceEqual(receipt.Payload)) return Reply(command.CommandId, "command-conflict");
            p.LastSeen = hostTick;
            return receipt.Reply.Clone();
        }
        if (Terminal) return Reply(command.CommandId, "match-terminal");
        if (command.CommandId != p.LastCommand + 1) return Reply(command.CommandId, "command-order");
        p.LastSeen = hostTick;
        string code = Apply(p, command);
        p.LastCommand = command.CommandId;
        stateRevision++;
        MatchReply reply = Reply(command.CommandId, code);
        p.Receipts.Add(command.CommandId, (payload, reply.Clone()));
        if (p.Receipts.Count > 64) p.Receipts.Remove(command.CommandId - 64);
        return reply;
    }

    /// <summary>Provision the immutable Backend-owned card catalog before
    /// clients may submit prebattle selections.</summary>
    public void ConfigureCardSelection(IEnumerable<string> catalog)
    {
        if (phase != BattlePhase.Waiting || cardSelections != null)
            throw new InvalidOperationException("Card selection is already active.");
        var ids = catalog?.ToArray() ?? throw new InvalidDataException("Missing card catalog.");
        cardCatalog = new HashSet<string>(ids, StringComparer.Ordinal);
        BattleLoadoutPolicy.ValidateCardIds(ids, cardCatalog);
        cardSelections = new BattleCardSelectionState();
    }
    public void ConfigureBuddySelection(IEnumerable<(string PlayerId, IEnumerable<string> BuddyIds)> provisioned)
    {
        if (phase != BattlePhase.Waiting || buddySelections != null)
            throw new InvalidOperationException("Buddy selection authority must be bound once while waiting.");
        buddySelections = new BattleBuddySelectionState(provisioned);
    }
    /// <summary>Bind the complete Backend-owned per-player loadout before admission traffic starts.</summary>
    public void ConfigureBattleAllocations(IEnumerable<BattleAllocationProjection> projections)
    {
        if (phase != BattlePhase.Waiting) throw new InvalidOperationException("Allocations must be bound while waiting.");
        if (projections == null) throw new ArgumentNullException(nameof(projections));
        var values = projections.Select(BattleAllocationProjection.Validate).ToArray();
        if (values.Length != players.Length || values.Select(x => x.PlayerId).Distinct(StringComparer.Ordinal).Count() != values.Length)
            throw new InvalidDataException("Allocation must contain exactly one entry per match participant.");
        foreach (var value in values)
        {
            var player = players.SingleOrDefault(x => x.Definition.PlayerId == value.PlayerId)
                ?? throw new InvalidDataException("Allocation player is not in the match manifest.");
            if (player.Definition.ArmyNormalUpgradeIndexes is { } normal && !normal.SequenceEqual(value.NormalUpgradeIndexes) ||
                player.Definition.ArmySpecialUpgradeIndexes is { } special && !special.SequenceEqual(value.SpecialUpgradeIndexes) ||
                player.Definition.ArmyEliteUpgradeIndexes is { } elite && !elite.SequenceEqual(value.EliteUpgradeIndexes))
                throw new InvalidDataException("Allocation upgrade lanes do not match the trusted manifest.");
        }
        ConfigureCardSelection(values.SelectMany(x => x.CardIds).Distinct(StringComparer.Ordinal));
        ConfigureBuddySelection(values.Select(x => (x.PlayerId, (IEnumerable<string>)x.BuddyCardIds)));
    }
    private string Apply(Player p, MatchCommand c)
    {
        if (Terminal) return "match-terminal";
        if(players.Any(x=>x.Reconnecting) && c.IntentCase!=MatchCommand.IntentOneofCase.Forfeit)
            return "reconnecting";
        if (c.IntentCase == MatchCommand.IntentOneofCase.Ready)
        {
            if (phase != BattlePhase.Waiting) return "wrong-phase";
            if (c.Ready.ManifestHash != ManifestHash) return "manifest-mismatch";
            p.Ready = true;
            if (players.All(x => x.Ready && x.Admitted))
            {
                phase = BattlePhase.Countdown;
                startTick = tick + 2 * MatchManifest.TickRate; // GameControllerOnline SyncMatchStart +2s.
                endTick = startTick + (ulong)manifest.DurationSeconds * MatchManifest.TickRate;
            }
            return "ready";
        }
        if (c.IntentCase == MatchCommand.IntentOneofCase.SelectCards)
        {
            if (phase != BattlePhase.Waiting || cardSelections == null || cardCatalog == null)
                return "card-selection-disabled";
            try
            {
                var normal = c.SelectCards.NormalUpgradeIndexes.ToArray();
                var special = c.SelectCards.SpecialUpgradeIndexes.ToArray();
                var elite = c.SelectCards.EliteUpgradeIndexes.ToArray();
                var expected = p.Definition.EquippedArmyUnitIds?.Length ?? 0;
                if (expected != 0 && normal.Length != expected) return "invalid-card-selection";
                if (special.Length != 0 && special.Length != normal.Length ||
                    elite.Length != 0 && elite.Length != normal.Length) return "invalid-card-selection";
                if (normal.Any(x => x < 0 || x > 255) || special.Any(x => x < -1 || x > 255) || elite.Any(x => x < -1 || x > 255))
                    return "invalid-card-selection";
                // Upgrade lanes are allocation authority. A client may echo the
                // trusted values, but can never introduce or alter a stage.
                if (p.Definition.ArmyNormalUpgradeIndexes is { } trustedNormal &&
                    !trustedNormal.SequenceEqual(normal)) return "invalid-card-selection";
                if (p.Definition.ArmySpecialUpgradeIndexes is { } trustedSpecial &&
                    !trustedSpecial.SequenceEqual(special)) return "invalid-card-selection";
                if (p.Definition.ArmyEliteUpgradeIndexes is { } trustedElite &&
                    !trustedElite.SequenceEqual(elite)) return "invalid-card-selection";
                if (p.Definition.ArmyNormalUpgradeIndexes == null && normal.Length != 0 ||
                    p.Definition.ArmySpecialUpgradeIndexes == null && special.Length != 0 ||
                    p.Definition.ArmyEliteUpgradeIndexes == null && elite.Length != 0)
                    return "invalid-card-selection";
                if (buddySelections == null && c.SelectCards.BuddyCardIds.Count != 0) return "buddy-selection-disabled";
                var buddies = buddySelections == null
                    ? Array.Empty<string>()
                    : buddySelections.Submit(p.Definition.PlayerId, c.SelectCards.BuddyCardIds);
                var selected = cardSelections.Submit(p.Definition.PlayerId,
                    c.CommandId.ToString(CultureInfo.InvariantCulture), c.SelectCards.CardIds, cardCatalog);
                p.SelectedCards = selected;
                p.CardsSelected = true;
                p.NormalUpgradeIndexes = normal;
                p.SpecialUpgradeIndexes = special;
                p.EliteUpgradeIndexes = elite;
                p.SelectedBuddyCards = buddies;
                return "cards-selected";
            }
            catch (InvalidDataException) { return "invalid-card-selection"; }
        }
        if (c.IntentCase == MatchCommand.IntentOneofCase.Forfeit)
        {
            if (phase == BattlePhase.Waiting) End("cancelled-before-start", "", false);
            else End("forfeit", players.Single(x => x != p).Definition.PlayerId, true);
            return "forfeited";
        }
        if (phase != BattlePhase.Running) return "not-running";
        if(c.IntentCase==MatchCommand.IntentOneofCase.SwitchWeapon)
        {
            int slot=c.SwitchWeapon.Slot;
            if(!p.Weapons.TryGetValue(slot,out var weapon))return "weapon-slot-unavailable";
            if(p.Route!=null)return "moving";
            if(scheduledBazookas.Any(x=>x.Owner==p.Definition.PlayerId))return "shooting";
            if(grenadeCombat?.Busy(p.Definition.PlayerId)==true)return "shooting";
            if(p.ActiveSlot==slot)return "weapon-selected";
            try {rifleCombat?.SwitchWeapon(p.Definition.PlayerId,weapon.Definition.Weapon,weapon.Definition.WeaponUpgrade);}
            catch(InvalidDataException){End("invalid-combat-authority","",false);return "match-aborted";}
            p.ActiveSlot=slot;
            return "weapon-selected";
        }
        if(c.IntentCase==MatchCommand.IntentOneofCase.MinigunHold)
        {
            if(rifleCombat==null)return "minigun-disabled";
            var hold=c.MinigunHold;
            if(!Coordinate(hold.TargetX)||!Coordinate(hold.TargetY)||!Coordinate(hold.TargetZ))return "invalid-target";
            if(!hold.Pressed)
            {
                try{return rifleCombat.HoldMinigun(p.Definition.PlayerId,false,Vector3.Zero,tick);}
                catch(InvalidDataException){End("invalid-combat-authority","",false);return "match-aborted";}
            }
            if(p.Route!=null)return "moving";
            if(p.ReloadEnd!=0)return "reloading";
            if(p.Clip==0)return "no-ammo";
            try{return rifleCombat.HoldMinigun(p.Definition.PlayerId,hold.Pressed,new(hold.TargetX,hold.TargetY,hold.TargetZ),tick);}
            catch(InvalidDataException){End("invalid-combat-authority","",false);return "match-aborted";}
        }
        if(c.IntentCase==MatchCommand.IntentOneofCase.SniperAim)
        {
            if(rifleCombat==null)return "sniper-disabled";
            var aim=c.SniperAim;
            if(!Coordinate(aim.TargetX)||!Coordinate(aim.TargetY)||!Coordinate(aim.TargetZ))return "invalid-target";
            if(aim.Pressed)
            {
                if(p.Route!=null)return "moving";
                if(p.ReloadEnd!=0)return "reloading";
                if(p.Clip==0)return "no-ammo";
            }
            try
            {
                var result=rifleCombat.SniperGesture(p.Definition.PlayerId,aim.Pressed,aim.Cancelled,
                    new(aim.TargetX,aim.TargetY,aim.TargetZ),tick,
                    p.ReloadEnd==0&&tick>=p.NextFire&&p.Clip>0);
                return result.FireTarget.HasValue?Fire(p,result.FireTarget.Value):result.Code;
            }
            catch(InvalidDataException){End("invalid-combat-authority","",false);return "match-aborted";}
        }
        if(c.IntentCase==MatchCommand.IntentOneofCase.BazookaHold)
        {
            if(rifleCombat==null)return "bazooka-disabled";var hold=c.BazookaHold;
            if(!Coordinate(hold.TargetX)||!Coordinate(hold.TargetY)||!Coordinate(hold.TargetZ))return "invalid-target";
            if(hold.Pressed)
            {
                if(p.Route!=null)return "moving";
                if(p.ReloadEnd!=0)return "reloading";
                if(p.Clip==0)return "no-ammo";
                if(tick<p.NextFire)return "cooldown";
            }
            try{return rifleCombat.HoldBazooka(p.Definition.PlayerId,hold.Pressed,new(hold.TargetX,hold.TargetY,hold.TargetZ),tick);}
            catch(InvalidDataException){End("invalid-combat-authority","",false);return "match-aborted";}
        }
        if(c.IntentCase==MatchCommand.IntentOneofCase.GrenadeThrow)
        {
            if(grenadeCombat==null||grenadeCatalog==null)return "grenade-disabled";
            if(p.Route!=null)return "moving";if(p.ReloadEnd!=0)return "reloading";
            if(tick<p.NextFire)return "cooldown";if(p.Clip==0)return "no-ammo";
            if(grenadeCombat.Busy(p.Definition.PlayerId))return "shooting";
            if(PendingProjectileCount>=MaximumProjectiles)return "projectile-capacity";
            if(!EventCapacityForShot())return "event-backpressure";
            try{_ = grenadeCombat.Begin(p.Definition.PlayerId,c.GrenadeThrow,tick);return "grenade-throwing";}
            catch(InvalidDataException){return "invalid-grenade-input";}
        }
        if (c.IntentCase == MatchCommand.IntentOneofCase.MoveCover)
        {
            if (map == null) return "map-unavailable";
            if(grenadeCombat?.Busy(p.Definition.PlayerId)==true)return "shooting";
            if (p.Route != null) return "already-moving";
            int target = map.Adjacent(p.Cover, c.MoveCover.Direction, p.Definition.Fraction);
            if (target < 0) return "cover-unavailable";
            if (players.Any(other => other != p && (other.Cover == target || (other.Route != null && other.Destination == target)))) return "cover-occupied";
            var route = map.Path(p.Cover, target);
            float length = 0;
            for (int i = 1; i < route.Length; i++) length += Vector3.Distance(route[i-1], route[i]);
            p.Route = route;
            p.Destination = target;
            p.MoveStart = tick + 1; // Source GoTo defaults to a 0.02-second deferred destination.
            p.MoveEnd = p.MoveStart + Math.Max(1, Ticks(length / p.Definition.MovementSpeed));
            rifleCombat?.StartMove(p.Definition.PlayerId);
            return "moving";
        }
        if (c.IntentCase == MatchCommand.IntentOneofCase.Reload)
        {
            if (p.ReloadEnd != 0 || p.Reserve == 0 || p.Clip == p.Weapon.ClipSize) return "reload-unavailable";
            Reload(p);
            return "reloading";
        }
        if(c.IntentCase==MatchCommand.IntentOneofCase.DeployArmy)
        {
            if(p.Army==null)return "army-disabled";
            int index=c.DeployArmy.OptionIndex;
            if(!p.Army.OfferedOptions.Contains(index))return "army-not-offered";
            var family=armyCatalog!.Families.Single(f=>f.Options.Any(o=>o.Index==index));
            var option=armyCatalog.Option(index);
            var availability=ArmyAvailabilityError(p,family,option);
            if(availability!=null){p.Army.InvalidateOffers();return availability;}
            if(!EventCapacityForArmy(option.Count))return "event-backpressure";
            return p.Army.TryDeploy(index,tick);
        }
        if (c.IntentCase == MatchCommand.IntentOneofCase.VehicleAttack)
        {
            var command = c.VehicleAttack;
            if (vehicles == null || !vehicles.TryGet(command.EntityId, out var vehicle) || vehicle == null ||
                !TryValidateVehicleTarget(p.Definition.PlayerId, command.TargetPlayerId, vehicle.Position,
                    new Vector3(command.TargetX, command.TargetY, command.TargetZ), 1000, out _))
                return "invalid-vehicle-target";
            vehicleShotTargets[command.EntityId] = (p.Definition.PlayerId, command.TargetPlayerId,
                new Vector3(command.TargetX, command.TargetY, command.TargetZ));
            return TryBeginVehicleAttack(p.Definition.PlayerId, command.EntityId, true, 0)
                ? "vehicle-attack-accepted" : "vehicle-attack-unavailable";
        }
        if (c.IntentCase != MatchCommand.IntentOneofCase.Fire) return "unsupported-command";
        if(grenadeCombat!=null||rifleCombat?.IsMinigun(p.Definition.PlayerId)==true||rifleCombat?.IsSniper(p.Definition.PlayerId)==true||rifleCombat?.IsBazooka(p.Definition.PlayerId)==true)return "wrong-fire-mode";
        // Original Fire(Vector3 to) uses a target POSITION, not a normalized direction.
        if (!Coordinate(c.Fire.TargetX) || !Coordinate(c.Fire.TargetY) || !Coordinate(c.Fire.TargetZ)) return "invalid-target";
        if (p.Route != null && rifleCombat==null) return "moving";
        if (p.ReloadEnd != 0) { rifleCombat?.StopShooting(p.Definition.PlayerId); return "reloading"; }
        if (tick < p.NextFire && !(rifleCombat?.BurstActive(p.Definition.PlayerId)??false)) return "cooldown";
        if (p.Clip == 0) { rifleCombat?.StopShooting(p.Definition.PlayerId); return "no-ammo"; }
        var fireTarget=new Vector3(c.Fire.TargetX,c.Fire.TargetY,c.Fire.TargetZ);
        if (rifleCombat!=null)
        {
            if (PendingProjectileCount>=MaximumProjectiles) return "projectile-capacity";
            if (!EventCapacityForShot()) return "event-backpressure";
            string result;
            try { result=rifleCombat.Trigger(p.Definition.PlayerId,fireTarget); }
            catch (InvalidDataException) { End("invalid-combat-authority","",false);return "match-aborted"; }
            if (result!="fire-now") return result;
        }
        return Fire(p,fireTarget);
    }
    private string Fire(Player p,Vector3 target)
    {
        if (phase!=BattlePhase.Running || p.Dead) return "match-terminal";
        if (p.ReloadEnd!=0) { rifleCombat?.StopShooting(p.Definition.PlayerId); return "reloading"; }
        if (tick<p.NextFire) return "cooldown";
        if (p.Clip==0) { rifleCombat?.StopShooting(p.Definition.PlayerId); return "no-ammo"; }
        if(rifleCombat?.IsBazooka(p.Definition.PlayerId)==true)return FireBazooka(p,target);
        IReadOnlyList<PreparedProjectile>? prepared = null;
        if (prepareVolley != null)
        {
            if (PendingProjectileCount >= MaximumProjectiles) return "projectile-capacity";
            if (!EventCapacityForShot()) return "event-backpressure";
            try
            {
                prepared = prepareVolley(projectileId+1, p.Definition.PlayerId,
                    target,tick);
                if(prepared==null || prepared.Count is <1 or >8 ||
                    projectileId>ulong.MaxValue-(ulong)prepared.Count)
                    throw new InvalidDataException("Host returned invalid projectile count.");
                if(prepared.Count>MaximumProjectiles-PendingProjectileCount)return "projectile-capacity";
                if(!EventCapacityForShot(prepared.Count))return "event-backpressure";
                prepared=prepared.ToArray(); // Detach a mutable host list before validation and insertion.
                for(int i=0;i<prepared.Count;i++)
                {
                    var pellet=prepared[i];
                    if(pellet?.Flight==null || pellet.Flight.Id!=projectileId+(ulong)i+1 ||
                        pellet.Flight.OwnerId!=p.Definition.PlayerId || pellet.Damage==null ||
                        pellet.Damage.Type!=CombatDamageType.Shot || !pellet.Damage.HasWeapon || pellet.Damage.Amount<0)
                        throw new InvalidDataException("Host returned invalid projectile authority.");
                    // Validate every pellet before ammo or any identity is consumed.
                    PlayerDamage.Resolve(new PlayerCombatManifest(1),1,pellet.Damage,false,false,1);
                }
            }
            catch (ProjectileTargetException) { return "invalid-target"; }
            catch (InvalidDataException) { End("invalid-projectile-authority", "", false); return "match-aborted"; }
        }
        p.Clip--;
        p.Shots++;
        rifleCombat?.ShotAccepted(p.Definition.PlayerId,target,tick);
        if (prepared != null)
        {
            foreach(var pellet in prepared)
            {
                projectiles.Add(++projectileId,pellet);
                Emit(MatchEventKind.Shot,p.Definition.PlayerId,"",projectileId,pellet.Flight.Position,0,"");
            }
        }
        if (map != null && rifleCombat==null)
        {
            Vector3 origin = map.Covers[p.Cover].ShotPosition;
            Vector3 delta = target - origin;
            string hitPath = delta.LengthSquared() < 0.000001f ? "" : map.Raycast(origin, delta, Math.Min(10000, delta.Length()))?.SourcePath ?? "";
            // Fixed-size identity keeps replies inside the MTU even for deeply
            // nested source hierarchy names. Map hash already binds the namespace.
            p.LastGeometryHit = hitPath.Length == 0 ? "" : Convert.ToHexStringLower(System.Security.Cryptography.SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(hitPath)));
        }
        p.NextFire = tick + Ticks(p.Weapon.CadenceSeconds);
        if (p.Clip == 0 && p.Reserve > 0) Reload(p); // Source Weapon.Fire auto-reload.
        // Static map rays do not resolve animated player hitboxes. Do not invent
        // player damage from the client aim point or geometry-hit acknowledgement.
        return "shot-accepted";
    }
    private string FireBazooka(Player p,Vector3 target)
    {
        if(bazookaCatalog==null||rifleCombat==null)throw new InvalidDataException("Missing bazooka authority.");
        var binding=bazookaCatalog.Binding(p.Weapon.SourceId);
        _=bazookaCatalog.Stage(p.Weapon.SourceId,p.Current.Definition.WeaponUpgrade);
        if(binding.ProjectileCount>MaximumProjectiles-PendingProjectileCount)return "projectile-capacity";
        if(!EventCapacityForShot(binding.ProjectileCount))return "event-backpressure";
        if(projectileId>ulong.MaxValue-(ulong)binding.ProjectileCount)throw new InvalidDataException("Bazooka projectile identity exhausted.");
        bool half=binding.ProjectileCount==4;
        StartBazookaProjectile(new(p.Definition.PlayerId,target,tick,false,false,half,p.Weapon.SourceId,p.Current.Definition.WeaponUpgrade));
        for(int i=1;i<binding.ProjectileCount;i++)
        {
            bool fake=i!=2;
            scheduledBazookas.Add(new(p.Definition.PlayerId,target,
                checked(tick+(ulong)Math.Ceiling(binding.ProjectileDelaySeconds*MatchManifest.TickRate*i)),
                fake,true,half,p.Weapon.SourceId,p.Current.Definition.WeaponUpgrade));
        }
        p.Clip--;p.Shots++;
        rifleCombat.ShotAccepted(p.Definition.PlayerId,target,tick);
        p.NextFire=tick+Ticks(p.Weapon.CadenceSeconds);
        return "shot-accepted";
    }
    private void StartBazookaProjectile(ScheduledBazooka launch)
    {
        if(bazookaCatalog==null||rifleCombat==null)throw new InvalidDataException("Missing bazooka authority.");
        var owner=Find(launch.Owner)??throw new InvalidDataException("Unknown bazooka owner.");
        if(owner.Dead||owner.Weapon.SourceId!=launch.WeaponSourceId||owner.Current.Definition.WeaponUpgrade!=launch.Upgrade)
            throw new InvalidDataException("Bazooka launch authority changed during volley.");
        var binding=bazookaCatalog.Binding(launch.WeaponSourceId);
        var stage=bazookaCatalog.Stage(launch.WeaponSourceId,launch.Upgrade);
        var origin=rifleCombat.BazookaMuzzle(launch.Owner,launch.Secondary)+binding.ShootOffset;
        uint mask=owner.Definition.Fraction==1?bazookaCatalog.AlliesBulletMask:bazookaCatalog.EnemiesBulletMask;
        int curveSign=(++bazookaCurveCounter&1)==0?-1:1;
        var flight=new BazookaMissileFlight(++projectileId,launch.Owner,binding,origin,launch.Target,tick,
            launch.Fake,Random.Shared.NextSingle(),Random.Shared.NextSingle(),curveSign,
            (from,direction,range)=>rifleCombat.TraceForBazooka(launch.Owner,from,direction,range,mask));
        bazookaProjectiles.Add(projectileId,new(flight,stage,binding,launch.WeaponSourceId,launch.HalfDamage));
        Emit(MatchEventKind.Shot,launch.Owner,"",projectileId,origin,0,launch.Fake?"bazooka-fake":"bazooka");
    }
    private void ApplyBazookaPlayerExplosion(BazookaProjectile projectile,BazookaMissileImpact impact)
    {
        if(rifleCombat==null||damageRoll==null)throw new InvalidDataException("Missing bazooka damage authority.");
        var attacker=Find(impact.OwnerId)??throw new InvalidDataException("Unknown bazooka owner.");
        bool shieldBetween=false;
        IReadOnlyList<MapDynamicCollider> overlaps=Array.Empty<MapDynamicCollider>();
        if(map!=null)
        {
            Func<int,bool>? colliderEnabled=barrels==null?null:index=>barrels.ColliderEnabled(index);
            Func<int,int,int>? runtimeLayer=barrels==null?null:(index,layer)=>barrels.RuntimeLayer(index,layer);
            overlaps=map.DynamicSphereOverlaps(impact.Position,projectile.Binding.HurtRadius,uint.MaxValue,
                colliderEnabled,runtimeLayer);
            shieldBetween=shields!=null&&overlaps.Any(x=>shields.IsLiveShield(x.DynamicOwner));
        }
        foreach(var collider in overlaps)
        {
            var dynamicHit=BazookaExplosion.ResolveDynamic(impact.Position,collider,projectile.Stage,
                projectile.Binding,projectile.HalfDamage);
            if(shields!=null&&shields.IsLiveShield(collider.DynamicOwner))
            {
                var shield=shields.ApplyExplosion(collider.DynamicOwner,attacker.Definition.Fraction,
                    projectile.WeaponSourceId,dynamicHit.RawDamage,tick);
                if(shield!=null)
                {
                    stateRevision++;
                    EmitShield(shield.Destroyed?MatchEventKind.ShieldDestroyed:MatchEventKind.ShieldDamaged,
                        impact.OwnerId,shield,impact.ProjectileId);
                }
            }
            else if(barrels?.Contains(collider.ColliderIndex)==true)
            {
                ApplyBarrelDamage(impact.OwnerId,impact.ProjectileId,collider.ColliderIndex,dynamicHit.RawDamage,
                    dynamicHit.Kind==CombatDamageType.Explosion?BarrelChainCause.Explosion:BarrelChainCause.Shiver);
                if(Terminal)return;
            }
        }
        foreach(var victim in players.Where(x=>!x.Dead).ToArray())
        {
            var pose=rifleCombat.Pose(victim.Definition.PlayerId).Collision;
            float roll=damageRoll();
            var effect=BazookaExplosion.ResolvePlayer(impact.Position,pose,victim.Position,
                victim.Definition.Combat!,victim.Health,projectile.Stage,projectile.Binding,projectile.HalfDamage,
                shieldBetween,overtime,attacker.Definition.Fraction==victim.Definition.Fraction,
                attacker==victim,roll);
            if(effect==null)continue;
            ApplyResolvedPlayerDamage(impact.OwnerId,victim.Definition.PlayerId,
                new ResolvedPlayerDamage(effect.RawDamage,effect.Kind,HasWeapon:true,FriendKill:true,
                    PlayerCoefficient:projectile.Stage.PlayerDamageRatio,
                    PlayerOvertimeCoefficient:projectile.Stage.OvertimePlayerDamageRatio,Overtime:overtime),
                roll,attacker!=victim&&attacker.Definition.Fraction!=victim.Definition.Fraction);
            if(Terminal)return;
        }
    }
    private void StartGrenadeProjectile(ScheduledGrenadeLaunch launch)
    {
        if(grenadeCatalog==null||grenadeCombat==null)throw new InvalidDataException("Missing grenade authority.");
        var owner=Find(launch.Owner)??throw new InvalidDataException("Unknown grenade owner.");
        if(owner.Dead||owner.Weapon.SourceId!=launch.WeaponSourceId||owner.Current.Definition.WeaponUpgrade!=launch.Upgrade||
           owner.Clip<=0||tick<owner.NextFire||PendingProjectileCount>=MaximumProjectiles||!EventCapacityForShot())
            throw new InvalidDataException("Grenade launch authority changed during animation.");
        if(projectileId==ulong.MaxValue)throw new InvalidDataException("Grenade projectile identity exhausted.");
        var binding=grenadeCatalog.Binding(launch.WeaponSourceId);var stage=grenadeCatalog.Stage(launch.WeaponSourceId,launch.Upgrade);
        var origin=grenadeCombat.Muzzle(launch)+binding.ShootOffset;
        uint mask=owner.Definition.Fraction==1?grenadeCatalog.AlliesBulletMask:grenadeCatalog.EnemiesBulletMask;
        var flight=new GrenadeFlight(++projectileId,launch.Owner,binding,origin,launch.Target,tick,
            (from,direction,range)=>grenadeCombat.Trace(launch.Owner,from,direction,range,mask));
        grenadeProjectiles.Add(projectileId,new(flight,stage,binding,launch.WeaponSourceId));
        owner.Clip--;owner.Shots++;owner.NextFire=tick+Ticks(owner.Weapon.CadenceSeconds);
        Emit(MatchEventKind.Shot,launch.Owner,"",projectileId,origin,0,
            binding.Effect==RecoveredGrenadeEffect.Molotov?"grenade-molotov":"grenade");
    }
    private void ApplyGrenadeExplosion(GrenadeProjectile projectile,GrenadeFlightImpact impact)
    {
        if(grenadeCombat==null||damageRoll==null)throw new InvalidDataException("Missing grenade damage authority.");
        var attacker=Find(impact.OwnerId)??throw new InvalidDataException("Unknown grenade owner.");bool shieldBetween=false;
        IReadOnlyList<MapDynamicCollider> overlaps=Array.Empty<MapDynamicCollider>();
        if(map!=null)
        {
            Func<int,bool>? enabled=barrels==null?null:index=>barrels.ColliderEnabled(index);
            Func<int,int,int>? layer=barrels==null?null:(index,source)=>barrels.RuntimeLayer(index,source);
            overlaps=map.DynamicSphereOverlaps(impact.Position,projectile.Stage.HurtRadius,uint.MaxValue,enabled,layer);
            shieldBetween=shields!=null&&overlaps.Any(x=>shields.IsLiveShield(x.DynamicOwner));
        }
        foreach(var collider in overlaps)
        {
            var hit=GrenadeExplosion.ResolveDynamic(impact.Position,collider,projectile.Stage);
            if(shields!=null&&shields.IsLiveShield(collider.DynamicOwner))
            {
                var shield=shields.ApplyExplosion(collider.DynamicOwner,attacker.Definition.Fraction,projectile.WeaponSourceId,hit.RawDamage,tick);
                if(shield!=null){stateRevision++;EmitShield(shield.Destroyed?MatchEventKind.ShieldDestroyed:MatchEventKind.ShieldDamaged,impact.OwnerId,shield,impact.ProjectileId);}
            }
            else if(barrels?.Contains(collider.ColliderIndex)==true)
            {
                ApplyBarrelDamage(impact.OwnerId,impact.ProjectileId,collider.ColliderIndex,hit.RawDamage,
                    hit.Kind==CombatDamageType.Explosion?BarrelChainCause.Explosion:BarrelChainCause.Shiver);
                if(Terminal)return;
            }
        }
        foreach(var victim in players.Where(x=>!x.Dead).ToArray())
        {
            float roll=damageRoll();var effect=GrenadeExplosion.ResolvePlayer(impact.Position,
                grenadeCombat.Collision(victim.Definition.PlayerId),victim.Position,victim.Definition.Combat!,victim.Health,
                projectile.Stage,shieldBetween,overtime,attacker.Definition.Fraction==victim.Definition.Fraction,attacker==victim,roll);
            if(effect==null)continue;
            ApplyResolvedPlayerDamage(impact.OwnerId,victim.Definition.PlayerId,
                new ResolvedPlayerDamage(effect.RawDamage,effect.Kind,HasWeapon:true,FriendKill:true,
                    PlayerCoefficient:projectile.Stage.PlayerDamageRatio,PlayerOvertimeCoefficient:projectile.Stage.OvertimePlayerDamageRatio,Overtime:overtime),
                roll,attacker!=victim&&attacker.Definition.Fraction!=victim.Definition.Fraction);
            if(Terminal)return;
        }
    }
    // Only the host's projectile/hitbox simulation may call this. It is
    // deliberately absent from MatchCommand and cannot be used as an RPC relay.
    internal PlayerDamageResult? ApplyResolvedPlayerDamage(string attackerId, string victimId,
        ResolvedPlayerDamage hit, float randomRoll,bool confirmedProjectileImpact=false)
    {
        if (phase != BattlePhase.Running) return null;
        var attacker = Find(attackerId);
        var victim = Find(victimId);
        if (attacker == null || victim == null || !attacker.Admitted || !victim.Admitted ||
            attacker.Dead || victim.Dead || victim.Definition.Combat == null) return null;
        var result = PlayerDamage.Resolve(victim.Definition.Combat, victim.Health, hit,
            attacker.Definition.Fraction == victim.Definition.Fraction, attacker == victim, randomRoll);
        if (!result.Applied) return result;
        if (confirmedProjectileImpact && attacker != victim && attacker.Definition.Fraction != victim.Definition.Fraction)
        {
            // Only this call site follows a one-shot flight impact. Direct
            // trusted damage helpers cannot manufacture combat statistics.
            attacker.ConfirmedPlayerHits = checked(attacker.ConfirmedPlayerHits + 1);
            attacker.ConfirmedEnemyHits = checked(attacker.ConfirmedEnemyHits + 1);
            if (result.Dead) attacker.ConfirmedPlayerKills = checked(attacker.ConfirmedPlayerKills + 1);
        }
        victim.Health = result.Health;
        victim.Dead = result.Dead;
        victim.DamageRevision++;
        stateRevision++;
        if (result.Dead)
        {
            Emit(MatchEventKind.PlayerDeath,attackerId,victimId,0,victim.Position,result.Health,"");
            victim.Route = null;
            foreach(var weapon in victim.Weapons.Values)weapon.ReloadEnd=0;
            End("player-killed", players.Single(p => p != victim).Definition.PlayerId, true);
        }
        return result;
    }
    private static bool Coordinate(float n) => float.IsFinite(n) && Math.Abs(n) <= 10000;
    private void AdvanceMovement(Player p)
    {
        if (p.Route == null) return;
        if (tick <= p.MoveStart) return;
        if (tick >= p.MoveEnd)
        {
            p.Cover = p.Destination;
            p.Position = map!.Covers[p.Cover].Position;
            p.Route = null;
            return;
        }
        float traveled = (float)(tick - p.MoveStart) / MatchManifest.TickRate * p.Definition.MovementSpeed;
        for (int i = 1; i < p.Route.Length; i++)
        {
            float segment = Vector3.Distance(p.Route[i-1], p.Route[i]);
            if (traveled <= segment && segment > 0) { p.Position = Vector3.Lerp(p.Route[i-1], p.Route[i], traveled/segment); return; }
            traveled -= segment;
        }
        p.Position = p.Route[^1];
    }
    private static ulong Ticks(double seconds) => checked((ulong)Math.Ceiling(seconds * MatchManifest.TickRate));
    private void Reload(Player p)
    {
        p.ReloadEnd = tick + Ticks(p.Weapon.ReloadSeconds);
        rifleCombat?.StopShooting(p.Definition.PlayerId);
    }
    private void BeginOvertime()
    {
        int shieldEvents=shields?.Snapshot().Count(s=>!s.Destroyed)??0;
        if(events.Count+shieldEvents+2>MaximumRetainedEvents)
        {End("overtime-event-backpressure","",false);return;}
        IReadOnlyList<ShieldMutation> destroyed;
        try {destroyed=shields?.BeginOvertime(tick)??Array.Empty<ShieldMutation>();}
        catch(InvalidDataException){End("invalid-shield-authority","",false);return;}
        overtime=true;
        endTick=0; // Running with no scheduled end denotes source overtime on reconnect.
        stateRevision++;
        Emit(MatchEventKind.OvertimeStarted,"","",0,Vector3.Zero,0,"");
        foreach(var shield in destroyed)
        {stateRevision++;EmitShield(MatchEventKind.ShieldDestroyed,"",shield,0);}
    }
    private void End(string reason, string winnerId, bool completed)
    {
        if (Terminal) return;
        BattleTerminalPolicy.ValidateWinner(reason, winnerId, completed,
            winnerId != "" && players.Any(p => p.Definition.PlayerId == winnerId && p.Dead),
            players.Select(p => p.Definition.PlayerId));
        foreach (var player in players)
            if (player.ConfirmedPlayerKills > player.ConfirmedPlayerHits ||
                player.ConfirmedArmyLosses > player.ConfirmedArmySpawns)
                throw new InvalidDataException("Inconsistent terminal combat statistics.");
        foreach(var player in players)
        {
            player.Reconnecting=false;
            player.ReconnectDeadlineHostTick=0;
        }
        if (performance.StartTick != 0 && performance.EndTick == 0)
            performance.End(tick);
        projectiles.Clear();
        armyProjectiles.Clear();
        armyFlameBursts.Clear();
        bazookaProjectiles.Clear();
        scheduledBazookas.Clear();
        grenadeProjectiles.Clear();
        phase = completed ? BattlePhase.Ended : BattlePhase.Aborted;
        terminalReason = reason;
        winner = winnerId;
        endTick = tick;
        stateRevision++;
        Emit(MatchEventKind.Terminal,winnerId,"",0,Vector3.Zero,0,reason);
    }
    public MatchReply Reply(ulong id, string code) => new() { CommandId = id, Code = code, Snapshot = Snapshot() };

    internal CompleteBattleEvidence? BuildCompleteBattleEvidence()
    {
        if (!Terminal) return null;
        var statistics = new BattleStatistics(
            checked((uint)players.Sum(x => x.ConfirmedPlayerHits)),
            checked((uint)players.Sum(x => x.ConfirmedPlayerKills)),
            checked((uint)players.Sum(x => x.ConfirmedArmySpawns)),
            checked((uint)players.Sum(x => x.ConfirmedArmyLosses)));
        var evidence = new CompleteBattleEvidence(MatchId, ManifestHash, statistics,
            performance.DurationTicks, ribbons.Snapshot(), performance.CardActivations,
            performance.ObjectiveCredits);
        return CompleteBattleEvidenceValidator.Validate(evidence);
    }

    internal BattleResultHandoff? BuildBattleResultHandoff(bool scored)
    {
        var evidence = BuildCompleteBattleEvidence();
        if (evidence == null) return null;
        var handoff = new BattleResultHandoff(evidence.MatchId, evidence.ManifestHash, evidence.Statistics, scored);
        BattleResultHandoffValidator.Validate(handoff);
        return handoff;
    }
    public MatchSnapshot Snapshot()
    {
        var snapshot = new MatchSnapshot
        {
            MatchId = MatchId, ManifestHash = ManifestHash, Phase = phase,
            ServerTick = tick, StartTick = startTick, EndTick = endTick,
            WinnerPlayerId = winner, TerminalReason = terminalReason, RewardEligible = false,
            StateRevision = stateRevision, Overtime = overtime
            ,CardActivations = (uint)performance.CardActivations,
            ObjectiveCredits = (uint)performance.ObjectiveCredits
        };
        snapshot.RibbonIds.AddRange(ribbons.Snapshot());
        snapshot.PerformanceDurationTicks = performance.DurationTicks;
        snapshot.Projectiles.AddRange(grenadeProjectiles.OrderBy(x=>x.Key).Select(x=>new BattleProjectileState
        {
            ProjectileId=x.Key,OwnerPlayerId=x.Value.Flight.OwnerId,
            Kind=x.Value.Binding.Effect==RecoveredGrenadeEffect.Molotov?"grenade-molotov":"grenade",
            X=x.Value.Flight.Position.X,Y=x.Value.Flight.Position.Y,Z=x.Value.Flight.Position.Z,
            VelocityX=x.Value.Flight.Velocity.X,VelocityY=x.Value.Flight.Velocity.Y,VelocityZ=x.Value.Flight.Velocity.Z
        }));
        if (vehicles != null)
            snapshot.Vehicles.AddRange(vehicles.Snapshot().Select(v =>
            {
                vehicles.TryGetAttack(v.EntityId, out var attack);
                var row = new BattleVehicleState
                { EntityId=v.EntityId, UnitId=v.UnitId, OwnerPlayerId=v.OwnerPlayerId, Generation=v.Generation,
                  X=v.Position.X, Y=v.Position.Y, Z=v.Position.Z,
                  AttackPhase=attack == null ? (int)ArmyAirAttackPhase.Ready : (int)attack.Phase,
                  CooldownTicks=attack?.CooldownTicksRemaining ?? 0,
                  Health=vehicles.TryGetHealth(v.EntityId, out var health) && health != null ? health.Current : 0,
                  MaxHealth=health?.Maximum ?? 0 };
                row.Parts.AddRange(vehicles.Parts(v.EntityId).Select(part => new BattleVehiclePartState
                { PartId = part.PartId, Health = part.Health, MaxHealth = part.MaxHealth,
                  PassengerPlayerId = part.PassengerPlayerId ?? "" }));
                return row;
            }));
        if(players.Any(p=>p.Reconnecting))snapshot.PauseHostTick=hostTick;
        snapshot.Players.AddRange(players.Select(p => new BattlePlayerState
        {
            PlayerId = p.Definition.PlayerId, Admitted = p.Admitted, Ready = p.Ready,
            ClipAmmo = p.Clip, ReserveAmmo = p.Reserve, ReloadEndTick = p.ReloadEnd,
            NextFireTick = p.NextFire, ShotsFired = p.Shots, LastCommandId = p.LastCommand,
            CoverIndex = p.Cover, PositionX = p.Position.X, PositionY = p.Position.Y, PositionZ = p.Position.Z,
            Moving = p.Route != null, MoveEndTick = p.MoveEnd, LastGeometryHit = p.LastGeometryHit,
            CombatEnabled = p.Definition.Combat != null, Health = p.Health,
            MaxHealth = p.Definition.Combat?.MaxHealth ?? 0, Dead = p.Dead, DamageRevision = p.DamageRevision,
            ConfirmedPlayerHits = p.ConfirmedPlayerHits, ConfirmedPlayerKills = p.ConfirmedPlayerKills,
            ConfirmedEnemyHits = p.ConfirmedEnemyHits,
            Reconnecting=p.Reconnecting,ReconnectAttempts=p.ReconnectAttempts,
            ReconnectDeadlineHostTick=p.ReconnectDeadlineHostTick,
            ConfirmedArmySpawns=p.ConfirmedArmySpawns,ConfirmedArmyLosses=p.ConfirmedArmyLosses,
            CardsSelected = p.CardsSelected,
            RiflePose = rifleCombat?.Snapshot(p.Definition.PlayerId) ?? grenadeCombat?.Snapshot(p.Definition.PlayerId,tick)
            ,MinigunHeld = rifleCombat?.MinigunHeld(p.Definition.PlayerId) ?? false
            ,BazookaTargeting = rifleCombat?.BazookaTargeting(p.Definition.PlayerId) ?? false
            ,SniperAiming = rifleCombat?.SniperAiming(p.Definition.PlayerId) ?? false
            ,SniperScopeVisible = rifleCombat?.SniperScopeVisible(p.Definition.PlayerId,tick) ?? false
        }));
        foreach (var row in snapshot.Players)
        {
            var source = players.Single(p => p.Definition.PlayerId == row.PlayerId);
            row.ActiveWeaponSlot=source.ActiveSlot;
            row.SelectedCardIds.Add(source.SelectedCards);
            row.SelectedBuddyCardIds.Add(source.SelectedBuddyCards);
            row.NormalUpgradeIndexes.Add(source.NormalUpgradeIndexes);
            row.SpecialUpgradeIndexes.Add(source.SpecialUpgradeIndexes);
            row.EliteUpgradeIndexes.Add(source.EliteUpgradeIndexes);
        }
        if(shields!=null)
            snapshot.Shields.AddRange(shields.Snapshot().Select(s=>new BattleShieldState
            {CoverIndex=s.CoverIndex,OwnerFraction=s.OwnerFraction,Health=s.Health,
                MaxHealth=s.MaxHealth,Destroyed=s.Destroyed,Revision=s.Revision}));
        snapshot.AirEntities.AddRange(airEntities.Snapshot().OrderBy(e=>e.EntityKey).Select(e =>
            new BattleAirEntityState
            {
                EntityKey=e.EntityKey, OwnerPlayerId=e.AttackerPlayerId,
                X=e.Motion.Position.X, Y=e.Motion.Position.Y, Z=e.Motion.Position.Z,
                Health=e.Health.Current, MaxHealth=e.Health.Maximum
            }));
        snapshot.Deployables.AddRange(deployables.Snapshot().Select(e => new BattleDeployableState
        {
            EntityId=e.EntityId, OwnerPlayerId=e.OwnerPlayerId, CardId=e.CardId,
            X=e.Position.X, Y=e.Position.Y, Z=e.Position.Z,
            State=(int)e.State, RemainingTicks=e.RemainingTicks, Charges=e.Charges, CooldownTicks=e.CooldownTicks
        }));
        snapshot.CardEffects.AddRange(cardEffects.Snapshot().Select(e => new BattleCardEffectState
        {
            EffectId=e.EffectId, OwnerPlayerId=e.OwnerPlayerId, CardId=e.Definition.CardId,
            Kind=(int)e.Definition.Kind, X=e.Target.X, Y=e.Target.Y, Z=e.Target.Z,
            StartedTick=e.StartedTick, ExpiresTick=e.Lease.ExpiresTick
        }));
        foreach (var row in objectives.OrderBy(x => x.Key, StringComparer.Ordinal))
            foreach (var pair in row.Value.TargetSnapshot().OrderBy(x => x.Key))
                snapshot.ObjectiveProgress.Add(new BattleObjectiveProgress
                {
                    PlayerId=row.Key, Kind=(int)pair.Key, Progress=row.Value.Progress(pair.Key),
                    Target=pair.Value, Complete=row.Value.Complete(pair.Key)
                });
        if (arenaState != null)
        {
            arenaState.Validate();
            snapshot.Arena = new BattleArenaState
            {
                EventId = arenaPolicy!.EventId, PlayerId = arenaPlayerId,
                Lives = arenaState.Lives, Wins = arenaState.Wins,
                Terminal = arenaState.Terminal, Revision = arenaRevision
            };
        }
        if (coopMission != null)
        {
            coopMission.Validate();
            snapshot.Coop = new BattleCoopState
            {
                Wave = coopMission.Wave, TotalWaves = coopMission.TotalWaves,
                DeadlineTick = coopMission.DeadlineTick, Started = coopMission.Started,
                Failed = coopMission.Failed, Completed = coopMission.Completed
                ,Heroic = coopModifiers.Heroic, EnemiesEnraged = coopModifiers.EnemiesEnraged,
                NoRespawn = coopModifiers.NoRespawn
            };
            snapshot.Coop.ParticipantIds.AddRange(coopMission.Participants.OrderBy(x => x, StringComparer.Ordinal));
        }
        return snapshot;
    }
    public MatchBarrelBatch BarrelBatch(string playerId)
    {
        if(Find(playerId)?.Admitted!=true)throw new InvalidOperationException("Barrel state needs admission.");
        var result=new MatchBarrelBatch {MatchId=MatchId,ManifestHash=ManifestHash,
            StateRevision=stateRevision};
        if(barrels==null)return result;
        var rows=barrels.Snapshot();
        result.SourceCount=(uint)rows.Count;
        result.MaxHealth=rows[0].MaxHealth;
        result.Changed.AddRange(rows.Where(b=>b.Revision>0).Select(b=>
            new BattleBarrelState {ColliderIndex=b.ColliderIndex,Health=b.Health,
                Destroyed=b.Destroyed,Revision=b.Revision,GameObjectFileId=b.GameObjectFileId}));
        return result;
    }
    public MatchArmyBatch ArmyBatch(string playerId)
    {
        var player=Find(playerId);
        if(player?.Admitted!=true)throw new InvalidOperationException("Army state needs admission.");
        var result=new MatchArmyBatch {MatchId=MatchId,ManifestHash=ManifestHash,
            StateRevision=stateRevision};
        var army=player.Army;
        if(army==null){result.Code="army-disabled";return result;}
        result.Energy=army.Energy;
        result.NextDeployTick=army.NextDeployTick;
        result.ActiveCount=army.ActiveCount;
        result.PendingCount=army.PendingCount;
        if(phase is not (BattlePhase.Countdown or BattlePhase.Running))
        {result.Code="army-not-running";return result;}
        var hand=army.OfferedOptions;
        if(hand.Count>0 && hand.Any(index=>
        {
            var family=armyCatalog!.Families.Single(f=>f.Options.Any(o=>o.Index==index));
            return !army.CanStillOffer(index) ||
                ArmyAvailabilityError(player,family,armyCatalog.Option(index))!=null;
        }))
        {
            army.InvalidateOffers();
            hand=army.OfferedOptions;
            stateRevision++;
        }
        if(hand.Count==0)
        {
            hand=army.GenerateOffers(armyChoice,(f,o)=>
                ArmyAvailabilityError(player,f,o)==null);
            if(hand.Count>0)stateRevision++;
            result.StateRevision=stateRevision;
        }
        result.Code=hand.Count==3 ? "army-offers" : "army-unavailable";
        result.OptionIndexes.AddRange(hand);
        player.LastSeen=hostTick;
        return result;
    }
    public MatchArmyEntityBatch ArmyEntityBatch(string playerId,ulong after,ulong expectedRevision)
    {
        var player=Find(playerId);
        if(player?.Admitted!=true)throw new InvalidOperationException("Army entities need admission.");
        var result=new MatchArmyEntityBatch {MatchId=MatchId,ManifestHash=ManifestHash,
            Revision=armyEntityRevision,ActiveCount=(uint)activeArmyEntities.Count,
            ServerTick=tick};
        if(player.Army==null){result.Code="army-disabled";return result;}
        if(expectedRevision!=0 && expectedRevision!=armyEntityRevision)
        {result.Code="revision-changed";return result;}
        if(after!=0 && (activeArmyEntities.Count==0 || after>activeArmyEntities.Keys.Max()))
        {result.Code="invalid-cursor";return result;}
        var remaining=activeArmyEntities.Where(pair=>pair.Key>after).OrderBy(pair=>pair.Key).ToArray();
        foreach(var row in remaining.Take(4))result.Entities.Add(row.Value.Clone());
        result.HasMore=remaining.Length>result.Entities.Count;
        result.Code="entities";
        player.LastSeen=hostTick;
        return result;
    }
}

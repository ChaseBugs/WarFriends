using System.Numerics;
using War.Protocol;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    internal sealed record ArmyRusherTarget(ulong EntityKey,string PlayerId,int TargetFileId,
        int RusherPointFileId,Vector3 Position);
    internal sealed record ArmyRusherShotIntent(ulong EntityKey,string OwnerPlayerId,string TargetPlayerId,int TargetFileId,
        Vector3 TargetPosition,bool IsReal,int BatchIndex,int BatchSize);
    private sealed class ArmyVitality(float maximum,float kevlarMaximum=0)
    {
        public float Maximum { get; }=maximum;
        public float Current=maximum;
        public float KevlarMaximum { get; }=kevlarMaximum;
        public float Kevlar=kevlarMaximum;
    }
    private readonly Dictionary<ulong,ArmyVitality> armyVitality=[];
    private readonly Dictionary<ulong,float> armyDamage=[];
    private readonly Dictionary<ulong,float> armySpecial=[];
    private readonly Dictionary<ulong,float> armySpeed=[];
    private readonly Dictionary<ulong,ArmyBaseShotStats> armyShots=[];
    private readonly Dictionary<ulong,ArmyVehicleShotStats> armyVehicleShots=[];
    private readonly Dictionary<ulong,ArmyRusherArrivalState> rusherMotionCandidates=[];
    private readonly Dictionary<ulong,ArmyWarperRelocationState> warperRelocations=[];
    private readonly Dictionary<ulong,ulong> warperRestartTicks=[];
    private readonly Dictionary<ulong,ArmyRusherLateralSteering> rusherSteering=[];
    private readonly Dictionary<ulong,ArmyRusherRetargetClock> rusherRetargetClocks=[];
    private readonly Dictionary<ulong,int> rusherDetours=[];
    private readonly Dictionary<ulong,ArmyRusherAttackState> rusherAttacks=[];
    private readonly Dictionary<ulong,ArmyRusherAttackState> minigunnerAttacks=[];
    private readonly Dictionary<ulong,ArmyMinigunnerMovementState> minigunnerMovements=[];
    private readonly Dictionary<ulong,ArmyRusherLateralSteering> minigunnerSteering=[];
    private readonly Dictionary<ulong,ulong> minigunnerPointChangeTicks=[];
    private readonly Dictionary<int,ulong> occupiedMinigunnerPoints=[];
    private readonly Dictionary<ulong,int> minigunnerPointByEntity=[];
    private readonly Dictionary<ulong,float> walkingShotgunnerSpecials=[];
    private readonly Dictionary<ulong,ArmyRusherTarget> rusherAttackTargets=[];
    private readonly Dictionary<ulong,ArmyRusherTarget> minigunnerAttackTargets=[];
    private readonly Dictionary<ulong,int> rusherShotCounts=[];
    private readonly List<ArmyRusherShotIntent> rusherShotIntents=[];
    private readonly Dictionary<ulong,ArmyFlameBurst> armyFlameBursts=[];
    private readonly Dictionary<ulong,ArmyPoisonEffect> armyPoisons=[];
    private readonly Dictionary<ulong,float> armyProjectileDamage=[];
    private readonly Dictionary<int,ulong> occupiedRusherSlots=[];
    private readonly Dictionary<ulong,int> rusherSlotByEntity=[];
    private readonly Dictionary<ulong,ArmyVehicleRouteMotion> vehicleRouteMotions=[];

    private string? ArmyAvailabilityError(Player player,ArmyDeploymentFamily family,
        ArmyDeploymentOption option)
    {
        int available=armySelector!.AvailableSlots(map!,family,player.Definition.Fraction,
            armyReservations!.Available);
        if(available!=int.MaxValue)
        {
            int pending=player.Army!.PendingRouteDemand(ArmySpawnPointSelector.Collection(family.BehaviorType));
            if(available-pending<option.Count)return "army-route-unavailable";
        }
        if(ArmyRusherPointCatalog.IsRusher(family.BehaviorType))
        {
            int pending=player.Army!.PendingRusherDemand;
            int occupied=occupiedRusherSlots.Values.Count(key=>(int)(key>>32)==player.Definition.Fraction);
            if(4-occupied-pending<option.Count ||
               FreeRusherSlots(players.Single(other=>other!=player).Cover)-pending<option.Count)
                return "army-rusher-unavailable";
        }
        return null;
    }

    private int FreeRusherSlots(int opponentCover)
    {
        if(opponentCover<0)return 0;
        var slots=armyRusherPoints!.ForCover(map!,opponentCover);
        return slots.Count(point=>!occupiedRusherSlots.ContainsKey(point.ComponentFileId));
    }

    private void ReserveRusherSlot(ulong entityKey,int opponentCover,Vector3 spawnPosition)
    {
        // EnemyController.rusherCounts spans every opposing defend position.
        // At four occupied points, GetInitPoint selects a spare point instead.
        int ownerFraction=(int)(entityKey>>32);
        if(occupiedRusherSlots.Values.Count(key=>(int)(key>>32)==ownerFraction)>=4)return;
        int slot=armyRusherPoints!.Choose(map!,opponentCover,spawnPosition,
            occupiedRusherSlots.ContainsKey)?.ComponentFileId??0;
        if(slot<=0 || !occupiedRusherSlots.TryAdd(slot,entityKey) ||
           !rusherSlotByEntity.TryAdd(entityKey,slot))
            throw new InvalidDataException("Source Rusher point is no longer free at spawn.");
    }

    private void InitializeArmyVitality(ParticipantManifest owner,string unitId,ulong entityKey)
    {
        int index=Array.IndexOf(owner.EquippedArmyUnitIds!,unitId);
        if(index<0)throw new InvalidDataException("Spawned army unit is outside the trusted equipped set.");
        if(owner.ArmyNormalUpgradeIndexes==null)return;
        int? special=owner.ArmySpecialUpgradeIndexes is { } specials && specials[index]>=0 ? specials[index] : null;
        int? elite=owner.ArmyEliteUpgradeIndexes is { } elites && elites[index]>=0 ? elites[index] : null;
        var family=armyCatalog!.Families.Single(f=>f.UnitId==unitId);
        if(owner.ArmyHealthFactors is { } healthFactors)
        {
            float maximum=armyCatalog!.EffectiveHealth(unitId,owner.ArmyNormalUpgradeIndexes![index],
                special,elite,healthFactors[index]);
            float kevlar=0;
            if(family.BehaviorType=="SoldierBehaviourParachuter"&&special.HasValue)
            {
                float ratio=armyCatalog.ComposeSpecial(unitId,owner.ArmyNormalUpgradeIndexes[index],special,elite);
                if(!float.IsFinite(ratio)||ratio<=0||ratio>10)
                    throw new InvalidDataException("Paratrooper kevlar ratio is outside its recovered combat domain.");
                kevlar=maximum*ratio;
                if(!float.IsFinite(kevlar)||kevlar<=0||kevlar>10_000_000)
                    throw new InvalidDataException("Paratrooper kevlar is outside host vitality bounds.");
            }
            armyVitality.Add(entityKey,new ArmyVitality(maximum,kevlar));
        }
        if(owner.ArmyDamageScales is { } damageScales)
            armyDamage.Add(entityKey,armyCatalog!.EffectiveDamage(unitId,
                owner.ArmyNormalUpgradeIndexes![index],special,elite,damageScales[index]));
        float specialValue=armyCatalog.ComposeSpecial(unitId,owner.ArmyNormalUpgradeIndexes![index],special,elite);
        if(family.BehaviorType=="SoldierBehaviourCommando")
        {
            if(specialValue<0||specialValue>100)
                throw new InvalidDataException("Commando poison ratio is outside its recovered combat domain.");
            if(specialValue>0)armySpecial.Add(entityKey,specialValue);
        }
        if(family.BehaviorType=="SoldierBehaviourShotgunner"&&special.HasValue)
        {
            if(specialValue<=0||specialValue>10)
                throw new InvalidDataException("Shotgunner walking-fire special is outside its recovered combat domain.");
            walkingShotgunnerSpecials.Add(entityKey,specialValue);
        }
        if(owner.ArmySpeedCoefficients is { } speedCoefficients)
            armySpeed.Add(entityKey,armyCatalog!.EffectiveSpeed(unitId,speedCoefficients[index],
                owner.ArmyNormalUpgradeIndexes[index],special,elite));
        if(family.BaseShot!=null)
            armyShots.Add(entityKey,armyCatalog.ComposeShot(unitId,
                owner.ArmyNormalUpgradeIndexes[index],special,elite,
                owner.ArmyAccuracyCoefficients?[index]??1f));
        if(family.VehicleShot!=null&&!family.IsAir&&!family.IsSoldier)
            armyVehicleShots.Add(entityKey,armyCatalog.ComposeVehicleShot(unitId,
                owner.ArmyNormalUpgradeIndexes[index],special,elite,
                owner.ArmyAccuracyCoefficients?[index]??1f));
    }

    internal float? ArmyHealth(ulong entityKey)
        =>armyVitality.TryGetValue(entityKey,out var row) ? row.Current : null;
    internal float? ArmyKevlar(ulong entityKey)
        =>armyVitality.TryGetValue(entityKey,out var row) ? row.Kevlar : null;
    internal float? ArmyDamage(ulong entityKey)
        =>armyDamage.TryGetValue(entityKey,out var value) ? value : null;
    internal float? ArmySpeed(ulong entityKey)
        =>armySpeed.TryGetValue(entityKey,out var value) ? value : null;

    // Match-owned motion is published for covered routes. Avoidance and corner
    // steering still need source comparison; motion alone grants no damage.
    internal ArmyRusherArrivalState? RusherMotionCandidate(ulong entityKey)
        =>rusherMotionCandidates.TryGetValue(entityKey,out var state) ? state : null;
    internal ArmyWarperRelocationState? WarperRelocationCandidate(ulong entityKey)
        =>warperRelocations.TryGetValue(entityKey,out var state)?state:null;
    internal ulong? WarperRestartTick(ulong entityKey)
        =>warperRestartTicks.TryGetValue(entityKey,out var due)?due:null;
    internal ulong? RusherSlotOccupant(int pointFileId)
        =>occupiedRusherSlots.TryGetValue(pointFileId,out var key) ? key : null;
    internal int RusherDetourCount(ulong entityKey)
        =>rusherDetours.TryGetValue(entityKey,out int count) ? count : 0;
    internal IReadOnlyList<ArmyRusherShotIntent> RusherShotIntents
        =>rusherShotIntents.AsReadOnly();
    internal ArmyRusherTarget? RusherLatchedShotTarget(ulong entityKey)
        =>rusherAttackTargets.TryGetValue(entityKey,out var target)?target:null;
    internal ArmyMinigunnerMovementState? MinigunnerMovementCandidate(ulong entityKey)
        =>minigunnerMovements.TryGetValue(entityKey,out var state)?state:null;
    internal Vector2? MinigunnerSteeringOffset(ulong entityKey)
        =>minigunnerSteering.TryGetValue(entityKey,out var state)?state.Offset:null;
    internal int? MinigunnerPoint(ulong entityKey)
        =>minigunnerPointByEntity.TryGetValue(entityKey,out int point)?point:null;
    internal ulong? MinigunnerPointOccupant(int pointFileId)
        =>occupiedMinigunnerPoints.TryGetValue(pointFileId,out ulong key)?key:null;
    internal ArmyVehicleRouteMotion? VehicleRouteMotion(ulong entityKey)
        =>vehicleRouteMotions.TryGetValue(entityKey,out var state)?state:null;
    internal VehicleAttackState? GroundVehicleAttack(ulong entityKey)
        =>vehicles?.TryGetAttack(entityKey,out var state)==true?state:null;

    private void InitializeGroundVehicle(ulong entityKey,ArmyDeploymentFamily family,
        ArmySpawnPoint point)
    {
        if(family.IsAir||family.IsSoldier||point.VehicleRoute==null||vehicles==null||
           !activeArmyEntities.TryGetValue(entityKey,out var army))return;
        float speed=ArmySpeed(entityKey)??armyCatalog!.EffectiveSpeed(army.UnitId,1f);
        var entity=new VehicleEntity(entityKey,army.UnitId,army.OwnerPlayerId,1)
            {Position=new(army.X,army.Y,army.Z)};
        var primary=groundVehicleWeapons?.For(army.UnitId).Roles.Single(r=>r.Role=="primary")??
            throw new InvalidDataException("Ground vehicle lacks its pinned primary turret.");
        if(!vehicles.TrySpawn(entity) || !armyVehicleShots.TryGetValue(entityKey,out var vehicleShot) ||
           !vehicles.TryBindAttack(entityKey,vehicleShot,primary.Weapons[0].Cadence) ||
           armyVitality.TryGetValue(entityKey,out var vitality)&&
               !vehicles.TryBindHealth(entityKey,vitality.Maximum))
            throw new InvalidDataException("Ground vehicle registry initialization failed.");
        vehicleRouteMotions.Add(entityKey,new ArmyVehicleRouteMotion(entity.Position,point.VehicleRoute,speed));
    }

    private void AdvanceGroundVehicleRoutes()
    {
        if(vehicles==null)throw new InvalidDataException("Ground vehicle route lacks its registry.");
        foreach(var (key,motion) in vehicleRouteMotions.OrderBy(x=>x.Key).ToArray())
        {
            if(!activeArmyEntities.TryGetValue(key,out var army)||
               !vehicles.TryGet(key,out var vehicle)||vehicle==null||vehicle.OwnerPlayerId!=army.OwnerPlayerId)
                throw new InvalidDataException("Ground vehicle route lost its host entity.");
            Vector3 before=motion.Position;motion.AdvanceTick();
            float speed=ArmySpeed(key)??armyCatalog!.EffectiveSpeed(army.UnitId,1f);
            if(!vehicles.TryMove(key,motion.Position,speed))
                throw new InvalidDataException("Ground vehicle route move failed.");
            army.X=motion.Position.X;army.Y=motion.Position.Y;army.Z=motion.Position.Z;
            army.PositionTick=tick;
            if(before!=motion.Position){armyEntityRevision++;stateRevision++;}
            if(motion.Arrived)vehicleRouteMotions.Remove(key);
        }
    }

    private void InitializeRusherMotionCandidate(ulong entityKey,string unitId)
    {
        if(!rusherSlotByEntity.ContainsKey(entityKey))return;
        float speed=ArmySpeed(entityKey)??armyCatalog!.EffectiveSpeed(unitId,1f);
        if(unitId=="ID_UNIT-WARPER")
        {
            StartWarperRelocation(entityKey,false);
            return;
        }
        var route=RusherWalkingRoute(entityKey);
        if(route is not {PlanarCovered:true})return;
        var state=new ArmyRusherArrivalState(route,armyCatalog!.InfantryAgent,speed);
        InitializeRusherCombatState(entityKey,unitId,state);
    }

    private void InitializeStationaryArmyCombat(ulong entityKey,string unitId)
    {
        var family=armyCatalog!.Families.Single(f=>f.UnitId==unitId);
        if(family.BehaviorType!="SoldierBehaviourMinigunner")return;
        if(!activeArmyEntities.TryGetValue(entityKey,out var army)||map==null||
           armyMinigunnerPoints==null||armyNavMeshConnectivity==null)
            throw new InvalidDataException("Minigunner spawn lacks point-navigation authority.");
        var point=armyMinigunnerPoints.NearestFree(map,army.OwnerFraction,
            new(army.X,army.Y,army.Z),null,occupiedMinigunnerPoints.ContainsKey)??
            throw new InvalidDataException("Minigunner spawn has no free source point.");
        StartMinigunnerMovement(entityKey,point,null);
    }

    private void StartMinigunnerAttack(ulong entityKey)
    {
        if(!activeArmyEntities.TryGetValue(entityKey,out var army))
            throw new InvalidDataException("Minigunner attack lacks its host entity.");
        if(!armyShots.TryGetValue(entityKey,out var shot))
            throw new InvalidDataException("Minigunner lacks composed shot authority.");
        int interval=armyWeapons?.CadenceTicks(army.UnitId)??
            throw new InvalidDataException("Minigunner lacks pinned cadence authority.");
        var attack=new ArmyRusherAttackState(shot,NextArmyFloat,interval);
        // SwitchStateToMinigunner schedules Random.Range(2f,4.5f). Later
        // EndShooting calls the serialized base-shot two-to-five-second timer.
        attack.BeginInitialCooldown(2f,4.5f);
        minigunnerAttacks.Add(entityKey,attack);
        minigunnerPointChangeTicks.Add(entityKey,checked(tick+MinigunnerPointDelayTicks()));
        rusherShotCounts.TryAdd(entityKey,0);
    }

    private ulong MinigunnerPointDelayTicks()
        =>(ulong)MathF.Ceiling((6f+NextArmyFloat()*4f)*MatchManifest.TickRate);

    private void StartMinigunnerMovement(ulong entityKey,ArmyMinigunnerPoint point,int? oldPoint)
    {
        if(!activeArmyEntities.TryGetValue(entityKey,out var army)||map==null||
           armyNavMeshConnectivity==null||point.Fraction!=army.OwnerFraction)
            throw new InvalidDataException("Minigunner movement lacks its entity, map or faction proof.");
        var start=new Vector3(army.X,army.Y,army.Z);
        var route=armyNavMeshConnectivity.PlanCorridor(map,start,point.Position);
        if(route is not {PlanarCovered:true})
            throw new InvalidDataException("Minigunner point has no covered host corridor.");
        float speed=ArmySpeed(entityKey)??armyCatalog!.EffectiveSpeed(army.UnitId,1f);
        var movement=new ArmyMinigunnerMovementState(point.ComponentFileId,route,
            armyCatalog!.InfantryAgent,speed);
        if(!occupiedMinigunnerPoints.TryAdd(point.ComponentFileId,entityKey))
            throw new InvalidDataException("Minigunner destination was occupied during transfer.");
        if(oldPoint.HasValue)
        {
            if(!occupiedMinigunnerPoints.TryGetValue(oldPoint.Value,out ulong owner)||owner!=entityKey||
               !occupiedMinigunnerPoints.Remove(oldPoint.Value))
            {
                occupiedMinigunnerPoints.Remove(point.ComponentFileId);
                throw new InvalidDataException("Minigunner lost its prior point reservation.");
            }
        }
        minigunnerPointByEntity[entityKey]=point.ComponentFileId;
        minigunnerMovements.Add(entityKey,movement);
        minigunnerSteering.Add(entityKey,new ArmyRusherLateralSteering(start));
    }

    private void AdvanceMinigunnerMovements()
    {
        var priorPositions=activeArmyEntities.Where(pair=>
                armyCatalog!.Families.Single(f=>f.UnitId==pair.Value.UnitId).BehaviorType==
                    "SoldierBehaviourMinigunner")
            .ToDictionary(pair=>pair.Key,pair=>new Vector3(pair.Value.X,pair.Value.Y,pair.Value.Z));
        foreach(var (key,movement) in minigunnerMovements.OrderBy(x=>x.Key).ToArray())
        {
            if(!activeArmyEntities.TryGetValue(key,out var army)||
               !minigunnerPointByEntity.TryGetValue(key,out int point)||point!=movement.PointFileId||
               !occupiedMinigunnerPoints.TryGetValue(point,out ulong owner)||owner!=key)
                throw new InvalidDataException("Minigunner movement lost its reservation proof.");
            if(!minigunnerSteering.ContainsKey(key))
                throw new InvalidDataException("Minigunner movement lost its steering proof.");
            movement.AdvanceTick();
        }
        foreach(var (key,movement) in minigunnerMovements.OrderBy(x=>x.Key).ToArray())
        {
            var army=activeArmyEntities[key];
            var peers=priorPositions.Where(pair=>pair.Key!=key&&
                    activeArmyEntities[pair.Key].OwnerPlayerId==army.OwnerPlayerId)
                .Select(pair=>(pair.Value,minigunnerMovements.TryGetValue(pair.Key,out var peer)
                    ?peer.PlanarDirection:Vector2.Zero)).ToArray();
            var steering=minigunnerSteering[key];
            steering.Advance(movement.Position,movement.PlanarDirection,peers,(before,next)=>
                before==next || Vector3.Distance(before,next)<=.07f&&
                armyNavMeshConnectivity!.Classify(map!,before,next)==ArmyNavMeshConnection.Connected);
            army.X=steering.Position.X;army.Y=steering.Position.Y;army.Z=steering.Position.Z;
            army.PositionTick=tick;
            if(!movement.Arrived || steering.Offset!=Vector2.Zero ||
               Vector2.Distance(new(army.X,army.Z),new(movement.Destination.X,movement.Destination.Z))>=.04f)
                continue;
            army.X=movement.Destination.X;army.Z=movement.Destination.Z;
            if(!minigunnerMovements.Remove(key)||!minigunnerSteering.Remove(key))
                throw new InvalidDataException("Minigunner arrival removal failed.");
            StartMinigunnerAttack(key);
        }
    }

    private void InitializeRusherCombatState(ulong entityKey,string unitId,ArmyRusherArrivalState state)
    {
        rusherMotionCandidates.Add(entityKey,state);
        rusherSteering.Add(entityKey,new ArmyRusherLateralSteering(state.Position));
        rusherRetargetClocks.Add(entityKey,new ArmyRusherRetargetClock());
        rusherDetours.Add(entityKey,0);
        var family=armyCatalog!.Families.Single(f=>f.UnitId==unitId);
        if((armyShots.TryGetValue(entityKey,out var effective)?effective:family.BaseShot) is { } shot)
        {
            var attack=walkingShotgunnerSpecials.TryGetValue(entityKey,out float special)
                ?CreateWalkingShotgunnerAttack(family,shot,special):CreateRusherAttack(family,shot);
            rusherAttacks.Add(entityKey,attack);
            rusherShotCounts.TryAdd(entityKey,0);
        }
    }

    private Vector3 RusherSlotPosition(int slot)
        =>armyRusherPoints!.ForCover(map!,Enumerable.Range(0,map!.Covers.Count).Single(i=>
            armyRusherPoints.ForCover(map,i).Any(p=>p.ComponentFileId==slot)))
            .Single(p=>p.ComponentFileId==slot).Position;

    private void StartWarperRelocation(ulong entityKey,bool repeatAfterShot)
    {
        if(!activeArmyEntities.TryGetValue(entityKey,out var army)||army.UnitId!="ID_UNIT-WARPER"||
           !rusherSlotByEntity.TryGetValue(entityKey,out int slot))
            throw new InvalidDataException("Warper relocation lacks its entity and Rusher slot.");
        float speed=ArmySpeed(entityKey)??armyCatalog!.EffectiveSpeed(army.UnitId,1f);
        var policy=armyWeapons!.WarperRelocation;
        warperRelocations.Add(entityKey,new ArmyWarperRelocationState(new(army.X,army.Y,army.Z),
            RusherSlotPosition(slot),policy,policy.Fields[map!.Source],map,armyNavMeshConnectivity!,
            armyCatalog!.InfantryAgent,speed,NextArmyFloat,repeatAfterShot));
    }

    private void StartDueWarperRestarts()
    {
        foreach(var (key,due) in warperRestartTicks.Where(pair=>pair.Value<=tick).OrderBy(pair=>pair.Key).ToArray())
        {
            if(!warperRestartTicks.Remove(key))throw new InvalidDataException("Warper restart timer removal failed.");
            if(!activeArmyEntities.ContainsKey(key))continue;
            rusherMotionCandidates.Remove(key);rusherSteering.Remove(key);rusherRetargetClocks.Remove(key);
            rusherDetours.Remove(key);rusherAttacks.Remove(key);rusherAttackTargets.Remove(key);
            StartWarperRelocation(key,true);
        }
    }

    private void AdvanceWarperRelocations()
    {
        foreach(var (key,state) in warperRelocations.OrderBy(pair=>pair.Key).ToArray())
        {
            if(!activeArmyEntities.TryGetValue(key,out var army)||army.UnitId!="ID_UNIT-WARPER"||
               !rusherSlotByEntity.TryGetValue(key,out int slot))
                throw new InvalidDataException("Warper relocation lost its host entity or slot.");
            ArmyWarperPresentationTransition presentation=state.AdvanceTick();
            army.X=state.Position.X;army.Y=state.Position.Y;army.Z=state.Position.Z;army.PositionTick=tick;
            if(presentation!=ArmyWarperPresentationTransition.None)
            {
                if(events.Count>=MaximumRetainedEvents-1)
                {End("army-event-backpressure","",false);return;}
                Emit(presentation==ArmyWarperPresentationTransition.WarpStarted
                        ?MatchEventKind.WarperWarpStarted:MatchEventKind.WarperWarpEnded,
                    army.OwnerPlayerId,"",0,state.Position,army.Health,"warper");
                var eventRow=events[^1];
                eventRow.ArmyEntityId=army.LocalEntityId;
                eventRow.ArmyOptionIndex=army.OptionIndex;
                eventRow.ArmyUnitId=army.UnitId;
                eventRow.ArmySpawnComponentFileId=army.SpawnComponentFileId;
                eventRow.ArmyReservationFileId=army.ReservationFileId;
            }
            if(state.Phase!=ArmyWarperRelocationPhase.Complete)continue;
            var target=RusherSlotPosition(slot);
            if(!warperRelocations.Remove(key))throw new InvalidDataException("Warper relocation removal failed.");
            InitializeRusherCombatState(key,army.UnitId,new ArmyRusherArrivalState(state.Position,target));
        }
    }

    private ArmyRusherAttackState CreateWalkingShotgunnerAttack(ArmyDeploymentFamily family,
        ArmyBaseShotStats shot,float special)
    {
        if(family.BehaviorType!="SoldierBehaviourShotgunner"||!float.IsFinite(special)||special<=0||special>10)
            throw new InvalidDataException("Invalid Shotgunner walking-fire authority.");
        int interval=armyWeapons?.CadenceTicks(family.UnitId)??
            throw new InvalidDataException("Shotgunner attack lacks pinned cadence authority.");
        var attack=new ArmyRusherAttackState(shot,NextArmyFloat,shotIntervalTicks:interval,
            cooldownMinSeconds:shot.MinShootTime/special,cooldownMaxSeconds:shot.MaxShootTime/special);
        attack.BeginInitialCooldown();
        return attack;
    }

    private ArmyRusherAttackState CreateRusherAttack(ArmyDeploymentFamily family,ArmyBaseShotStats shot)
    {
        int interval=armyWeapons?.CadenceTicks(family.UnitId)??
            throw new InvalidDataException("Rusher attack lacks pinned cadence authority.");
        // EndShooting -> ReturnToPreviousStateFromShot replaces the generic
        // definition cooldown for both Rusher states with Random.Range(2,4).
        return new ArmyRusherAttackState(shot,NextArmyFloat,shotIntervalTicks:interval,
            cooldownMinSeconds:2f,cooldownMaxSeconds:4f);
    }

    private float NextArmyFloat()
    {
        const int scale=1_000_000;
        int value=armyChoice(scale);
        if(value<0||value>=scale)
            throw new InvalidDataException("Army random source returned an invalid value.");
        return value/(float)scale;
    }

    private bool TryRetargetRusher(ulong key,int destinationCover)
    {
        if(map==null || armyRusherPoints==null || armyNavMeshConnectivity==null ||
           !activeArmyEntities.TryGetValue(key,out var army) ||
           !rusherSlotByEntity.TryGetValue(key,out int oldSlot) ||
           !occupiedRusherSlots.TryGetValue(oldSlot,out ulong occupant) || occupant!=key)
            throw new InvalidDataException("Rusher retarget lacks its source slot and entity proof.");
        int oldCover=Enumerable.Range(0,map.Covers.Count).Single(i=>
            armyRusherPoints.ForCover(map,i).Any(p=>p.ComponentFileId==oldSlot));
        var previous=armyRusherPoints.ForCover(map,oldCover);
        var destination=armyRusherPoints.ForCover(map,destinationCover);
        int currentIndex=previous.Single(p=>p.ComponentFileId==oldSlot).Index;
        var selected=ArmyRusherRetargetSelector.Select(previous,destination,currentIndex,
            occupiedRusherSlots.ContainsKey,
            (candidate,from)=>armyRusherPoints.IsFreeWithNearNeighbour(map,candidate,from,
                occupiedRusherSlots.ContainsKey));
        if(!selected.Qualified || occupiedRusherSlots.ContainsKey(selected.Point.ComponentFileId))
            return false;
        var start=new Vector3(army.X,army.Y,army.Z);
        var route=armyNavMeshConnectivity.PlanCorridor(map,start,selected.Point.Position);
        if(route is not {PlanarCovered:true})return false;
        float speed=ArmySpeed(key)??armyCatalog!.EffectiveSpeed(army.UnitId,1f);
        var motion=new ArmyRusherArrivalState(route,armyCatalog!.InfantryAgent,speed);
        var steering=new ArmyRusherLateralSteering(start);
        if(!occupiedRusherSlots.Remove(oldSlot) ||
           !occupiedRusherSlots.TryAdd(selected.Point.ComponentFileId,key))
            throw new InvalidDataException("Rusher retarget lost its atomic slot transfer.");
        rusherSlotByEntity[key]=selected.Point.ComponentFileId;
        rusherMotionCandidates[key]=motion;
        rusherSteering[key]=steering;
        var family=armyCatalog.Families.Single(f=>f.UnitId==army.UnitId);
        if((armyShots.TryGetValue(key,out var effective)?effective:family.BaseShot) is { } shot)
        {
            rusherAttacks[key]=CreateRusherAttack(family,shot);
        }
        rusherAttackTargets.Remove(key);
        rusherRetargetClocks[key].Reset();
        return true;
    }

    private void AdvanceRusherMotionCandidates()
    {
        rusherShotIntents.Clear();
        foreach(var (key,state) in rusherMotionCandidates.OrderBy(pair=>pair.Key).ToArray())
        {
            if(!activeArmyEntities.TryGetValue(key,out var army) ||
               !rusherSlotByEntity.TryGetValue(key,out int slot) ||
               !occupiedRusherSlots.TryGetValue(slot,out ulong occupant) || occupant!=key ||
               !rusherSteering.ContainsKey(key) || !rusherRetargetClocks.ContainsKey(key) ||
               !rusherDetours.ContainsKey(key))
                throw new InvalidDataException("Rusher motion lost its host entity or slot proof.");
            var owner=Find(army.OwnerPlayerId) ?? throw new InvalidDataException("Rusher owner disappeared.");
            var opponent=players.Single(p=>p!=owner);
            bool pointActive=!opponent.Dead && opponent.Cover>=0 && opponent.Route==null &&
                armyRusherPoints!.ForCover(map!,opponent.Cover)
                    .Any(p=>p.ComponentFileId==slot);
            bool shotPending=rusherAttacks.TryGetValue(key,out var pendingAttack) &&
                pendingAttack.Phase is ArmyRusherAttackPhase.Windup or ArmyRusherAttackPhase.Firing;
            if(state.Phase==ArmyRusherTravelPhase.Rusher &&
               rusherRetargetClocks[key].AdvanceTick(pointActive,shotPending) &&
               !opponent.Dead && opponent.Cover>=0 && opponent.Route==null &&
               TryRetargetRusher(key,opponent.Cover))continue;
            // The source-backed queue gate applies to allied Rushers sharing
            // spawn/corridor space. Head-on opposing agents need lateral
            // steering; a longitudinal wait can deadlock both routes.
            var otherPositions=rusherMotionCandidates.Where(pair=>pair.Key!=key &&
                activeArmyEntities.TryGetValue(pair.Key,out var other) &&
                other.OwnerPlayerId==army.OwnerPlayerId)
                .Select(pair=>pair.Value.Position).ToArray();
            bool advanced=state.TryAdvanceTick((before,proposed)=>ArmyRusherAvoidance.CanAdvance(
                before,proposed,otherPositions,armyCatalog!.InfantryAgent.Radius));
            if(!advanced && state.Phase==ArmyRusherTravelPhase.Walking &&
               state.RejectedMotionTicks>=15 && state.RejectedMotionTicks%15==0)
            {
                var blockers=rusherMotionCandidates.Where(pair=>pair.Key!=key &&
                    activeArmyEntities.TryGetValue(pair.Key,out var other) &&
                    other.OwnerPlayerId==army.OwnerPlayerId)
                    .Select(pair=>rusherSteering[pair.Key].Position).ToArray();
                var start=new Vector3(army.X,army.Y,army.Z);
                var detour=ArmyRusherDetourPlanner.Plan(map!,armyNavMeshConnectivity!,
                    start,state.Destination,blockers,armyCatalog!.InfantryAgent.Radius);
                if(detour!=null)
                {
                    float speed=ArmySpeed(key)??armyCatalog.EffectiveSpeed(army.UnitId,1f);
                    rusherMotionCandidates[key]=new ArmyRusherArrivalState(detour,
                        armyCatalog.InfantryAgent,speed);
                    rusherSteering[key]=new ArmyRusherLateralSteering(start);
                    rusherDetours[key]=checked(rusherDetours[key]+1);
                }
            }
        }
        // Every agent observes the same prior published positions. Reading a
        // peer after its projection would make avoidance depend on entity ID.
        var priorSteeringPositions=rusherSteering.ToDictionary(
            pair=>pair.Key,pair=>pair.Value.Position);
        foreach(var (key,state) in rusherMotionCandidates.OrderBy(pair=>pair.Key))
        {
            var army=activeArmyEntities[key];
            var opposing=rusherMotionCandidates.Where(pair=>pair.Key!=key &&
                activeArmyEntities.TryGetValue(pair.Key,out var other) &&
                other.OwnerPlayerId!=army.OwnerPlayerId)
                .Select(pair=>(priorSteeringPositions[pair.Key],pair.Value.PlanarDirection))
                .ToArray();
            var steering=rusherSteering[key];
            steering.Advance(state.Position,state.PlanarDirection,opposing,
                (before,next)=>before==next ||
                    Vector3.Distance(before,next)<=.07f &&
                    armyNavMeshConnectivity!.Classify(map!,before,next)==
                        ArmyNavMeshConnection.Connected);
            var position=steering.Position;
            if(!float.IsFinite(position.X) || !float.IsFinite(position.Y) ||
               !float.IsFinite(position.Z) || Math.Abs(position.X)>10000 ||
               Math.Abs(position.Y)>10000 || Math.Abs(position.Z)>10000)
                throw new InvalidDataException("Rusher motion produced an invalid host position.");
            army.X=position.X;army.Y=position.Y;army.Z=position.Z;
            army.PositionTick=tick;
        }
        foreach(var (key,attack) in rusherAttacks.OrderBy(pair=>pair.Key).ToArray())
        {
            if(!activeArmyEntities.TryGetValue(key,out var army) || !rusherMotionCandidates.TryGetValue(key,out var motion))
                continue;
            if(walkingShotgunnerSpecials.ContainsKey(key)&&motion.Phase==ArmyRusherTravelPhase.Rusher&&
               attack.Phase is not (ArmyRusherAttackPhase.Windup or ArmyRusherAttackPhase.Firing))
            {
                var family=armyCatalog!.Families.Single(f=>f.UnitId==army.UnitId);
                rusherAttacks[key]=CreateRusherAttack(family,armyShots[key]);
                walkingShotgunnerSpecials.Remove(key);
                continue;
            }
            bool walkingSpecial=walkingShotgunnerSpecials.ContainsKey(key)&&
                motion.Phase==ArmyRusherTravelPhase.Walking;
            var target=walkingSpecial&&motion.MotionLength-motion.MotionProgress>1f
                ?RusherWalkingTarget(key):RusherInitialShotTarget(key);
            bool eligible=target!=null&&(walkingSpecial||motion.InitialShotDelayElapsed);
            if(attack.Phase==ArmyRusherAttackPhase.Ready)
            {
                int windup=walkingSpecial?(int)MathF.Ceiling(
                    armyWeapons!.ShotgunnerWalkingFire.WindupSeconds*MatchManifest.TickRate):
                    armyWeapons?.WindupTicks(army.UnitId)??
                    throw new InvalidDataException("Rusher attack lacks pinned windup authority.");
                if(attack.TryBegin(eligible,1,windup))
                    rusherAttackTargets[key]=target!;
            }
            var priorPhase=attack.Phase;
            attack.AdvanceTick();
            if(priorPhase==ArmyRusherAttackPhase.Windup&&attack.Phase==ArmyRusherAttackPhase.Firing&&
               army.UnitId=="ID_UNIT-WARPER")
            {
                ulong delay=(ulong)MathF.Ceiling(armyWeapons!.WarperRelocation.RepeatAfterShotSeconds*
                    MatchManifest.TickRate);
                if(!warperRestartTicks.TryAdd(key,checked(tick+delay)))
                    throw new InvalidDataException("Warper already has a post-shot restart timer.");
            }
            if(attack.ShotDue)
            {
                if(!rusherAttackTargets.TryGetValue(key,out var shot))
                    throw new InvalidDataException("Rusher pending batch lost its latched target.");
                rusherShotIntents.Add(new(key,army.OwnerPlayerId,shot.PlayerId,shot.TargetFileId,shot.Position,
                    attack.CurrentShotIsReal,attack.BatchCursor,attack.BatchSize));
                attack.CommitShot();
                if(attack.Phase==ArmyRusherAttackPhase.Cooldown)
                    rusherAttackTargets.Remove(key);
            }
        }
        LaunchRusherShotIntents();
    }

    private void AdvanceMinigunnerAttacks()
    {
        rusherShotIntents.Clear();
        foreach(var (key,attack) in minigunnerAttacks.OrderBy(pair=>pair.Key).ToArray())
        {
            if(!activeArmyEntities.TryGetValue(key,out var army) ||
               armyCatalog!.Families.Single(f=>f.UnitId==army.UnitId).BehaviorType!=
                   "SoldierBehaviourMinigunner")
                throw new InvalidDataException("Minigunner attack lost its host entity.");
            if(!minigunnerPointChangeTicks.TryGetValue(key,out ulong changeTick)||
               !minigunnerPointByEntity.TryGetValue(key,out int currentPoint))
                throw new InvalidDataException("Minigunner attack lost its point clock.");
            if(attack.Phase==ArmyRusherAttackPhase.Cooldown&&tick>changeTick)
            {
                var next=armyMinigunnerPoints!.RandomFree(map!,army.OwnerFraction,currentPoint,
                    occupiedMinigunnerPoints.ContainsKey,armyChoice);
                if(next==null)
                {
                    minigunnerPointChangeTicks[key]=checked(changeTick+2u*MatchManifest.TickRate);
                }
                else
                {
                    minigunnerAttacks.Remove(key);minigunnerPointChangeTicks.Remove(key);
                    minigunnerAttackTargets.Remove(key);
                    StartMinigunnerMovement(key,next,currentPoint);
                    continue;
                }
            }
            var target=MinigunnerBodyTarget(key);
            if(attack.Phase==ArmyRusherAttackPhase.Ready)
            {
                int windup=armyWeapons?.WindupTicks(army.UnitId)??
                    throw new InvalidDataException("Minigunner lacks pinned windup authority.");
                if(attack.TryBegin(target!=null,1,windup))
                    minigunnerAttackTargets[key]=target!;
            }
            attack.AdvanceTick();
            if(!attack.ShotDue)continue;
            if(!minigunnerAttackTargets.TryGetValue(key,out var shot))
                throw new InvalidDataException("Minigunner pending batch lost its latched target.");
            rusherShotIntents.Add(new(key,army.OwnerPlayerId,shot.PlayerId,shot.TargetFileId,
                shot.Position,attack.CurrentShotIsReal,attack.BatchCursor,attack.BatchSize));
            attack.CommitShot();
            if(attack.Phase==ArmyRusherAttackPhase.Cooldown)
                minigunnerAttackTargets.Remove(key);
        }
        LaunchRusherShotIntents();
    }

    private void LaunchRusherShotIntents()
    {
        if(rifleCombat==null || rusherShotIntents.Count==0)return;
        foreach(var intent in rusherShotIntents)
        {
            if(!activeArmyEntities.TryGetValue(intent.EntityKey,out var army) ||
               army.OwnerPlayerId!=intent.OwnerPlayerId ||
               !rusherShotCounts.TryGetValue(intent.EntityKey,out int shotCount))continue;
            shotCount=checked(shotCount+1);rusherShotCounts[intent.EntityKey]=shotCount;
            string behavior=armyCatalog!.Families.Single(f=>f.UnitId==army.UnitId).BehaviorType;
            int muzzleIndex=behavior=="SoldierBehaviourCommando"&&shotCount%2==0?1:0;
            if(!intent.IsReal)continue;
            if(behavior=="SoldierBehaviourFlamethrower")
            {
                if(PendingProjectileCount>=MaximumProjectiles||!EventCapacityForShot())continue;
                if(projectileId==ulong.MaxValue)throw new InvalidDataException("Army flame identity exhausted.");
                ulong flameId=++projectileId;
                armyFlameBursts.Add(flameId,new ArmyFlameBurst(flameId,intent.EntityKey,intent.OwnerPlayerId,tick));
                Emit(MatchEventKind.Shot,intent.OwnerPlayerId,intent.TargetPlayerId,
                    flameId,new Vector3(army.X,army.Y,army.Z),0,"army-flame");
                continue;
            }
            float? projectileSpeed=behavior switch
            {
                "SoldierBehaviourShotgunner" or "SoldierBehaviourWarper"=>10f,
                "SoldierBehaviourParachuter" or "SoldierBehaviourSwat" or
                "SoldierBehaviourCommando" or "SoldierBehaviourMinigunner"=>5f,
                _=>null
            };
            if(!projectileSpeed.HasValue)continue;
            var entityPosition=new Vector3(army.X,army.Y,army.Z);
            var origin=armyWeapons?.RestMuzzleOrigin(army.UnitId,entityPosition,
                intent.TargetPosition-entityPosition,muzzleIndex)??
                throw new InvalidDataException("Army projectile lacks pinned muzzle authority.");
            if(!armyWeapons.TryProjectileDamage(army.UnitId,ArmyDamage(intent.EntityKey)??0,
                origin,intent.TargetPosition,out float launchDamage))
            {
                if(EventCapacityForShot())
                {
                    if(projectileId==ulong.MaxValue)throw new InvalidDataException("Army projectile identity exhausted.");
                    ulong missId=++projectileId;
                    Emit(MatchEventKind.Shot,intent.OwnerPlayerId,intent.TargetPlayerId,
                        missId,origin,0,"army-shotgun-cone-miss");
                }
                continue;
            }
            int poisonEvents=behavior=="SoldierBehaviourCommando"&&armySpecial.ContainsKey(intent.EntityKey)
                ?ArmyPoisonEffect.PulseCount:0;
            if(PendingProjectileCount>=MaximumProjectiles ||
               !EventCapacityForShot(1,poisonEvents))continue;
            if(projectileId==ulong.MaxValue)throw new InvalidDataException("Army projectile identity exhausted.");
            ulong id=++projectileId;
            var flight=new ArmyProjectileFlight(id,intent.EntityKey,origin,intent.TargetPosition,
                projectileSpeed.Value,tick,
                (from,direction,range)=>rifleCombat.TraceForArmy(intent.OwnerPlayerId,from,direction,range));
            armyProjectiles.Add(id,flight);
            armyProjectileDamage.Add(id,launchDamage);
            Emit(MatchEventKind.Shot,intent.OwnerPlayerId,intent.TargetPlayerId,
                id,origin,0,"army");
        }
    }

    private void AdvanceArmyProjectiles()
    {
        foreach(var pair in armyProjectiles.ToArray())
        {
            if(!armyProjectileDamage.TryGetValue(pair.Key,out float projectileDamage))
                throw new InvalidDataException("Army projectile lost its launch damage authority.");
            ArmyProjectileImpact? impact;
            try { impact=pair.Value.Advance(tick); }
            catch(InvalidDataException){End("invalid-army-projectile-authority","",false);return;}
            if(pair.Value.Finished)
            {
                armyProjectiles.Remove(pair.Key);
                armyProjectileDamage.Remove(pair.Key);
            }
            if(impact==null)continue;
            Emit(MatchEventKind.Impact,impact.EntityKey.ToString(),
                impact.Collision.PlayerId??"",impact.ProjectileId,impact.Collision.Position,0,"army");
            if(impact.Collision.DynamicOwner!=null && shields!=null &&
               activeArmyEntities.TryGetValue(impact.EntityKey,out var shieldArmy))
            {
                try
                {
                    var shield=shields.ApplyUnitShot(impact.Collision.DynamicOwner,
                        shieldArmy.OwnerFraction,projectileDamage,tick);
                    if(shield!=null)
                    {
                        stateRevision++;
                        EmitShield(shield.Destroyed?MatchEventKind.ShieldDestroyed:
                            MatchEventKind.ShieldDamaged,shieldArmy.OwnerPlayerId,shield,
                            impact.ProjectileId);
                    }
                }
                catch(InvalidDataException){End("invalid-shield-authority","",false);return;}
            }
            if(impact.Collision.PlayerId==null)continue;
            if(!activeArmyEntities.TryGetValue(impact.EntityKey,out var army))continue;
            var owner=Find(army.OwnerPlayerId);
            if(owner==null)continue;
            try
            {
                var proof=ArmyRusherImpactResolver.Resolve(
                    new ArmyRusherShotIntent(impact.EntityKey,owner.Definition.PlayerId,
                        impact.Collision.PlayerId,0,impact.Collision.Position,true,0,1),impact.Collision,
                    projectileDamage);
                var result=ApplyArmyRusherPlayerImpact(proof,damageRoll?.Invoke()??1f);
                if(result is {Applied:true,Dead:false}&&armySpecial.TryGetValue(impact.EntityKey,out float ratio))
                {
                    float pulse=projectileDamage/ArmyPoisonEffect.PulseCount*ratio;
                    armyPoisons.Add(impact.ProjectileId,new ArmyPoisonEffect(impact.ProjectileId,
                        impact.EntityKey,owner.Definition.PlayerId,impact.Collision.PlayerId,pulse,
                        impact.Collision.Position,tick));
                }
            }
            catch(InvalidDataException){End("invalid-army-impact-authority","",false);return;}
            if(Terminal)return;
        }
    }

    private void AdvanceArmyPoisons()
    {
        foreach(var pair in armyPoisons.OrderBy(x=>x.Key).ToArray())
        {
            var poison=pair.Value;
            if(!poison.TryTakePulse(tick))continue;
            var victim=Find(poison.VictimPlayerId);
            if(victim==null||victim.Dead){armyPoisons.Remove(pair.Key);continue;}
            Emit(MatchEventKind.Impact,poison.AttackerPlayerId,poison.VictimPlayerId,
                poison.ProjectileId,poison.Position,victim.Health,"army-poison");
            _=ApplyResolvedPlayerDamage(poison.AttackerPlayerId,poison.VictimPlayerId,
                new ResolvedPlayerDamage(poison.DamagePerPulse,CombatDamageType.Poison),
                damageRoll?.Invoke()??1f,false);
            if(poison.Remaining==0||victim.Dead)armyPoisons.Remove(pair.Key);
            if(Terminal)return;
        }
    }

    private void AdvanceArmyFlameBursts()
    {
        if(armyFlameBursts.Count==0)return;
        foreach(var pair in armyFlameBursts.OrderBy(x=>x.Key).ToArray())
        {
            var burst=pair.Value;if(!burst.Due(tick))continue;
            if(!activeArmyEntities.TryGetValue(burst.EntityKey,out var army))
            {armyFlameBursts.Remove(pair.Key);continue;}
            var owner=Find(burst.OwnerPlayerId);
            if(owner==null){armyFlameBursts.Remove(pair.Key);continue;}
            var victim=players.Single(x=>x!=owner);
            var target=rifleCombat?.Pose(victim.Definition.PlayerId).Collision;
            if(target==null)throw new InvalidDataException("Army flame requires current player collision authority.");
            var entityPosition=new Vector3(army.X,army.Y,army.Z);
            var forward=target.RootPosition-entityPosition;
            var origin=armyWeapons?.RestMuzzleOrigin(army.UnitId,entityPosition,forward)??
                throw new InvalidDataException("Army flame requires pinned weapon muzzle authority.");
            var hit=ArmyFlameBurst.ResolvePlayer(origin,forward,target,
                ArmyDamage(burst.EntityKey)??throw new InvalidDataException("Army flame lacks trusted damage."));
            burst.CommitPulse(tick);
            if(hit!=null&&!victim.Dead)
            {
                var result=ApplyResolvedPlayerDamage(owner.Definition.PlayerId,victim.Definition.PlayerId,
                    new ResolvedPlayerDamage(hit.RawDamage,CombatDamageType.Flame,HasWeapon:true,FriendKill:false),
                    damageRoll?.Invoke()??1f,true);
                Emit(MatchEventKind.Impact,burst.EntityKey.ToString(),victim.Definition.PlayerId,
                    burst.ProjectileId,origin,result?.Health??victim.Health,"army-flame");
            }
            if(burst.Finished)armyFlameBursts.Remove(pair.Key);
            if(Terminal)return;
        }
    }

    // A route from the host entity's current position to its reserved source
    // Rusher point. It does not move the entity or authorize arrival/fire.
    internal ArmyNavMeshCorridor? RusherWalkingRoute(ulong entityKey)
    {
        if(phase!=BattlePhase.Running || map==null || armyRusherPoints==null ||
           armyNavMeshConnectivity==null ||
           !activeArmyEntities.TryGetValue(entityKey,out var army) ||
           !rusherSlotByEntity.TryGetValue(entityKey,out int slot))return null;
        if(!occupiedRusherSlots.TryGetValue(slot,out ulong occupant) || occupant!=entityKey)
            throw new InvalidDataException("Rusher route lacks its occupied source slot.");
        if(Find(army.OwnerPlayerId)==null)
            throw new InvalidDataException("Rusher route owner disappeared.");
        // The old point remains reserved while its defender is moving. Route
        // authority follows that reservation until a validated transfer.
        var point=Enumerable.Range(0,map.Covers.Count)
            .SelectMany(i=>armyRusherPoints.ForCover(map,i))
            .Single(p=>p.ComponentFileId==slot);
        var position=new Vector3(army.X,army.Y,army.Z);
        return armyNavMeshConnectivity.PlanSourceSpawnCorridor(map,
                   army.SpawnComponentFileId,slot,position,point.Position) ??
               armyNavMeshConnectivity.PlanCorridor(map,position,point.Position);
    }

    // SoldierBehaviourRusher.PickTarget uses the nearest Body target until the
    // controller reaches EnemyAIState.Rusher. This is target intent, not fire.
    internal ArmyRusherTarget? RusherWalkingTarget(ulong entityKey)
    {
        if(phase!=BattlePhase.Running || rifleCombat==null || playerShotTargets==null ||
           !activeArmyEntities.TryGetValue(entityKey,out var army) ||
           !rusherSlotByEntity.TryGetValue(entityKey,out int slot))return null;
        if(!occupiedRusherSlots.TryGetValue(slot,out ulong occupant) || occupant!=entityKey)
            throw new InvalidDataException("Walking Rusher target lacks its occupied source slot.");
        var owner=Find(army.OwnerPlayerId) ?? throw new InvalidDataException("Rusher owner disappeared.");
        var opponent=players.Single(p=>p!=owner);
        if(opponent.Dead)return null;
        var pose=rifleCombat.Pose(opponent.Definition.PlayerId);
        var origin=new Vector3(army.X,army.Y,army.Z);
        var source=playerShotTargets.Nearest(1,origin,t=>pose.BodyTarget(t.TransformFileId).Position);
        return new(entityKey,opponent.Definition.PlayerId,source.TransformFileId,slot,
            pose.BodyTarget(source.TransformFileId).Position);
    }

    private ArmyRusherTarget? MinigunnerBodyTarget(ulong entityKey)
    {
        if(phase!=BattlePhase.Running || rifleCombat==null || playerShotTargets==null ||
           !activeArmyEntities.TryGetValue(entityKey,out var army))return null;
        var owner=Find(army.OwnerPlayerId) ?? throw new InvalidDataException("Minigunner owner disappeared.");
        var opponent=players.Single(p=>p!=owner);
        if(opponent.Dead)return null;
        if(map==null || opponent.Cover<0 || opponent.Cover>=map.Covers.Count)return null;
        // A Minigunner deployed from the army card calls PickPlayerOpponent(1f).
        // GameShootableEntityPlayer replaces the serialized type-2 child with
        // the current cover shield's shotPosition, so this branch is certain
        // while that cover has a shield object.
        var source=playerShotTargets.Gameplay.Single(t=>t.Type==2);
        return new(entityKey,opponent.Definition.PlayerId,source.TransformFileId,0,
            map.Covers[opponent.Cover].ShotPosition);
    }

    // Target projection only. The source enters EnemyAIState.Rusher after its
    // navigation transition; this does not cause a shot or claim arrival.
    internal ArmyRusherTarget? RusherMovingTarget(ulong entityKey)
    {
        if(phase!=BattlePhase.Running || rifleCombat==null || map==null ||
           armyRusherPoints==null || playerShotTargets==null ||
           !activeArmyEntities.TryGetValue(entityKey,out var army) ||
           !rusherSlotByEntity.TryGetValue(entityKey,out int slot))return null;
        if(!occupiedRusherSlots.TryGetValue(slot,out ulong occupant) || occupant!=entityKey)
            throw new InvalidDataException("Rusher target lacks its occupied source slot.");
        var owner=Find(army.OwnerPlayerId) ?? throw new InvalidDataException("Rusher owner disappeared.");
        var opponent=players.Single(p=>p!=owner);
        if(opponent.Dead || opponent.Cover<0 || opponent.Route!=null ||
           !armyRusherPoints.ForCover(map,opponent.Cover).Any(p=>p.ComponentFileId==slot))
            return null;
        var moving=rifleCombat.Pose(opponent.Definition.PlayerId).MovingTarget;
        var source=playerShotTargets.Gameplay.Single(p=>p.Type==16);
        if(moving==null || moving.SourcePath!=source.Path ||
           !PlayerHitbox.Finite(moving.Position))
            throw new InvalidDataException("Rusher moving target is not bound to host pose.");
        return new(entityKey,opponent.Definition.PlayerId,source.TransformFileId,slot,moving.Position);
    }

    // EnemyController.RusherUpdate may first call PrepareToShoot only after
    // SwitchStateToRusher's strict 0.5-second delay and while the reserved
    // player's Moving target still exists. This is eligibility, not a shot:
    // animation, aim, cooldown, and damage remain separate host work.
    internal ArmyRusherTarget? RusherInitialShotTarget(ulong entityKey)
        =>rusherMotionCandidates.TryGetValue(entityKey,out var state) &&
           state.InitialShotDelayElapsed ? RusherMovingTarget(entityKey) : null;

    // Army projectile impacts use the spawned entity as authority, then reuse
    // the same victim damage kernel and terminal statistics as player shots.
    internal PlayerDamageResult? ApplyArmyRusherPlayerImpact(
        ArmyRusherPlayerImpact impact,float randomRoll)
    {
        if(phase!=BattlePhase.Running ||
           !impact.IsReal ||
           !activeArmyEntities.TryGetValue(impact.EntityKey,out var army) ||
           army.OwnerPlayerId!=impact.AttackerPlayerId)
            return null;
        var attacker=Find(impact.AttackerPlayerId);
        var victim=Find(impact.VictimPlayerId);
        if(attacker==null || victim==null || !attacker.Admitted || !victim.Admitted ||
           attacker.Dead || victim.Dead || victim.Definition.Combat==null)
            return null;
        var hit=new ResolvedPlayerDamage(impact.Damage,CombatDamageType.Shot,
            impact.PartWeight);
        var result=PlayerDamage.Resolve(victim.Definition.Combat,victim.Health,hit,
            attacker.Definition.Fraction==victim.Definition.Fraction,attacker==victim,randomRoll);
        if(!result.Applied)return result;
        if(attacker.Definition.Fraction!=victim.Definition.Fraction)
        {
            attacker.ConfirmedPlayerHits=checked(attacker.ConfirmedPlayerHits+1);
            attacker.ConfirmedEnemyHits=checked(attacker.ConfirmedEnemyHits+1);
            if(result.Dead)attacker.ConfirmedPlayerKills=checked(attacker.ConfirmedPlayerKills+1);
        }
        victim.Health=result.Health;victim.Dead=result.Dead;victim.DamageRevision++;
        stateRevision++;
        if(result.Dead)
        {
            Emit(MatchEventKind.PlayerDeath,impact.AttackerPlayerId,impact.VictimPlayerId,
                0,victim.Position,result.Health,"");
            victim.Route=null;victim.ReloadEnd=0;
            End("player-killed",players.Single(p=>p!=victim).Definition.PlayerId,true);
        }
        return result;
    }

    // Damage is already established by trusted host collision/weapon logic.
    // No client packet can call this transition or choose an army victim.
    internal bool ApplyArmyHostDamage(ulong entityKey,float damage)
    {
        if(!float.IsFinite(damage) || damage<=0 || damage>10_000_000)
            throw new ArgumentOutOfRangeException(nameof(damage));
        if(phase!=BattlePhase.Running || !activeArmyEntities.ContainsKey(entityKey) ||
           !armyVitality.TryGetValue(entityKey,out var vitality))return false;
        float absorbed=Math.Min(damage,vitality.Kevlar);
        vitality.Kevlar-=absorbed;
        damage-=absorbed;
        if(damage>=vitality.Current)return ConfirmArmyDeath(entityKey,false);
        vitality.Current-=damage;
        if(!float.IsFinite(vitality.Current) || vitality.Current<=0 || vitality.Current>vitality.Maximum)
            throw new InvalidDataException("Army damage produced invalid host vitality.");
        if(!float.IsFinite(vitality.Kevlar)||vitality.Kevlar<0||vitality.Kevlar>vitality.KevlarMaximum)
            throw new InvalidDataException("Army damage produced invalid host kevlar.");
        activeArmyEntities[entityKey].Health=vitality.Current;
        activeArmyEntities[entityKey].Kevlar=vitality.Kevlar;
        armyEntityRevision++;
        stateRevision++;
        return true;
    }

    // Called only after host combat/AI establishes a death. There is no UDP
    // command capable of naming an entity, selecting a cause, or granting energy.
    internal bool ConfirmArmyDeath(ulong entityKey,bool suicide)
    {
        if(phase!=BattlePhase.Running || !activeArmyEntities.TryGetValue(entityKey,out var row))return false;
        var owner=Find(row.OwnerPlayerId) ?? throw new InvalidDataException("Army entity owner disappeared.");
        var recipient=suicide ? owner : players.Single(p=>p!=owner);
        var spawned=owner.Army?.Entity(row.LocalEntityId);
        if(spawned==null || spawned.UnitId!=row.UnitId || spawned.OptionIndex!=row.OptionIndex ||
           row.EntityKey!=(((ulong)owner.Definition.Fraction<<32)|(uint)row.LocalEntityId) ||
           armyReservations?.Owns(entityKey,row.ReservationFileId)!=true)
            throw new InvalidDataException("Army death lacks a complete host entity and route proof.");
        if(!EventCapacityForArmyDeath())
        {End("army-event-backpressure","",false);return false;}
        if(owner.Army!.RemoveEntity(row.LocalEntityId)==null ||
           !armyReservations!.Release(entityKey) || !activeArmyEntities.Remove(entityKey))
            throw new InvalidDataException("Army death compare-and-remove failed.");
        armyVitality.Remove(entityKey);
        armyDamage.Remove(entityKey);
        armySpecial.Remove(entityKey);
        armySpeed.Remove(entityKey);
        armyShots.Remove(entityKey);
        armyVehicleShots.Remove(entityKey);
        rusherMotionCandidates.Remove(entityKey);
        warperRelocations.Remove(entityKey);
        warperRestartTicks.Remove(entityKey);
        rusherSteering.Remove(entityKey);
        rusherRetargetClocks.Remove(entityKey);
        rusherDetours.Remove(entityKey);
        rusherAttacks.Remove(entityKey);
        minigunnerAttacks.Remove(entityKey);
        minigunnerMovements.Remove(entityKey);
        minigunnerSteering.Remove(entityKey);
        minigunnerPointChangeTicks.Remove(entityKey);
        vehicleRouteMotions.Remove(entityKey);
        if(vehicles?.TryGet(entityKey,out var vehicle)==true&&vehicle!=null&&
           !vehicles.TryDestroy(entityKey,vehicle.Generation))
            throw new InvalidDataException("Ground vehicle death cleanup failed.");
        walkingShotgunnerSpecials.Remove(entityKey);
        rusherAttackTargets.Remove(entityKey);
        minigunnerAttackTargets.Remove(entityKey);
        if(minigunnerPointByEntity.Remove(entityKey,out int minigunnerPoint) &&
           (!occupiedMinigunnerPoints.TryGetValue(minigunnerPoint,out ulong minigunnerOwner)||
            minigunnerOwner!=entityKey||!occupiedMinigunnerPoints.Remove(minigunnerPoint)))
            throw new InvalidDataException("Minigunner point release lost its host entity proof.");
        rusherShotCounts.Remove(entityKey);
        owner.ConfirmedArmyLosses=checked(owner.ConfirmedArmyLosses+1);
        if(rusherSlotByEntity.Remove(entityKey,out int rusherSlot) &&
           (!occupiedRusherSlots.TryGetValue(rusherSlot,out ulong occupant) ||
            occupant!=entityKey || !occupiedRusherSlots.Remove(rusherSlot)))
            throw new InvalidDataException("Rusher slot release lost its host entity proof.");
        recipient.Army!.CreditKillEnergy(spawned.Power);
        armyEntityRevision++;
        stateRevision++;
        Emit(MatchEventKind.ArmyDied,"",owner.Definition.PlayerId,0,
            new Vector3(row.X,row.Y,row.Z),0,suicide?"suicide":"combat");
        var eventRow=events[^1];
        eventRow.ArmyEntityId=row.LocalEntityId;
        eventRow.ArmyOptionIndex=row.OptionIndex;
        eventRow.ArmyUnitId=row.UnitId;
        eventRow.ArmySpawnComponentFileId=row.SpawnComponentFileId;
        eventRow.ArmyReservationFileId=row.ReservationFileId;
        eventRow.ArmyEnergyRecipientId=recipient.Definition.PlayerId;
        return true;
    }
}

using System.Numerics;
using War.Protocol;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    internal sealed record ArmyRusherTarget(ulong EntityKey,string PlayerId,int TargetFileId,
        int RusherPointFileId,Vector3 Position);
    internal sealed record ArmyRusherShotIntent(ulong EntityKey,string PlayerId,int TargetFileId,
        Vector3 TargetPosition,bool IsReal,int BatchIndex,int BatchSize);
    private sealed class ArmyVitality(float maximum)
    {
        public float Maximum { get; }=maximum;
        public float Current=maximum;
    }
    private readonly Dictionary<ulong,ArmyVitality> armyVitality=[];
    private readonly Dictionary<ulong,float> armyDamage=[];
    private readonly Dictionary<ulong,float> armySpeed=[];
    private readonly Dictionary<ulong,ArmyRusherArrivalState> rusherMotionCandidates=[];
    private readonly Dictionary<ulong,ArmyRusherLateralSteering> rusherSteering=[];
    private readonly Dictionary<ulong,ArmyRusherRetargetClock> rusherRetargetClocks=[];
    private readonly Dictionary<ulong,int> rusherDetours=[];
    private readonly Dictionary<ulong,ArmyRusherAttackState> rusherAttacks=[];
    private readonly List<ArmyRusherShotIntent> rusherShotIntents=[];
    private readonly Dictionary<ulong,ArmyFlameBurst> armyFlameBursts=[];
    private readonly Dictionary<int,ulong> occupiedRusherSlots=[];
    private readonly Dictionary<ulong,int> rusherSlotByEntity=[];

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
        if(owner.ArmyHealthFactors==null && owner.ArmyDamageScales==null &&
           owner.ArmySpeedCoefficients==null)return;
        int index=Array.IndexOf(owner.EquippedArmyUnitIds!,unitId);
        if(index<0)throw new InvalidDataException("Spawned army unit is outside the trusted equipped set.");
        int? special=owner.ArmySpecialUpgradeIndexes is { } specials && specials[index]>=0 ? specials[index] : null;
        int? elite=owner.ArmyEliteUpgradeIndexes is { } elites && elites[index]>=0 ? elites[index] : null;
        if(owner.ArmyHealthFactors is { } healthFactors)
        {
            float maximum=armyCatalog!.EffectiveHealth(unitId,owner.ArmyNormalUpgradeIndexes![index],
                special,elite,healthFactors[index]);
            armyVitality.Add(entityKey,new ArmyVitality(maximum));
        }
        if(owner.ArmyDamageScales is { } damageScales)
            armyDamage.Add(entityKey,armyCatalog!.EffectiveDamage(unitId,
                owner.ArmyNormalUpgradeIndexes![index],special,elite,damageScales[index]));
        if(owner.ArmySpeedCoefficients is { } speedCoefficients)
            armySpeed.Add(entityKey,armyCatalog!.EffectiveSpeed(unitId,speedCoefficients[index]));
    }

    internal float? ArmyHealth(ulong entityKey)
        =>armyVitality.TryGetValue(entityKey,out var row) ? row.Current : null;
    internal float? ArmyDamage(ulong entityKey)
        =>armyDamage.TryGetValue(entityKey,out var value) ? value : null;
    internal float? ArmySpeed(ulong entityKey)
        =>armySpeed.TryGetValue(entityKey,out var value) ? value : null;

    // Match-owned motion is published for covered routes. Avoidance and corner
    // steering still need source comparison; motion alone grants no damage.
    internal ArmyRusherArrivalState? RusherMotionCandidate(ulong entityKey)
        =>rusherMotionCandidates.TryGetValue(entityKey,out var state) ? state : null;
    internal ulong? RusherSlotOccupant(int pointFileId)
        =>occupiedRusherSlots.TryGetValue(pointFileId,out var key) ? key : null;
    internal int RusherDetourCount(ulong entityKey)
        =>rusherDetours.TryGetValue(entityKey,out int count) ? count : 0;
    internal IReadOnlyList<ArmyRusherShotIntent> RusherShotIntents
        =>rusherShotIntents.AsReadOnly();

    private void InitializeRusherMotionCandidate(ulong entityKey,string unitId)
    {
        if(!rusherSlotByEntity.ContainsKey(entityKey))return;
        var route=RusherWalkingRoute(entityKey);
        if(route is not {PlanarCovered:true})return;
        float speed=ArmySpeed(entityKey)??armyCatalog!.EffectiveSpeed(unitId,1f);
        var state=new ArmyRusherArrivalState(route,armyCatalog!.InfantryAgent,speed);
        rusherMotionCandidates.Add(entityKey,state);
        rusherSteering.Add(entityKey,new ArmyRusherLateralSteering(state.Position));
        rusherRetargetClocks.Add(entityKey,new ArmyRusherRetargetClock());
        rusherDetours.Add(entityKey,0);
        var family=armyCatalog.Families.Single(f=>f.UnitId==unitId);
        if(family.BaseShot is { } shot)
            rusherAttacks.Add(entityKey,new ArmyRusherAttackState(shot));
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
        if(armyCatalog.Families.Single(f=>f.UnitId==army.UnitId).BaseShot is { } shot)
            rusherAttacks[key]=new ArmyRusherAttackState(shot);
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
            if(state.Phase==ArmyRusherTravelPhase.Rusher &&
               rusherRetargetClocks[key].AdvanceTick(pointActive,false) &&
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
        foreach(var (key,attack) in rusherAttacks.OrderBy(pair=>pair.Key))
        {
            if(!activeArmyEntities.ContainsKey(key) || !rusherMotionCandidates.TryGetValue(key,out var motion))
                continue;
            var target=RusherInitialShotTarget(key);
            bool eligible=target!=null && motion.InitialShotDelayElapsed;
            if(attack.Phase==ArmyRusherAttackPhase.Ready)
                attack.TryBegin(eligible,1,0);
            attack.AdvanceTick();
            if(attack.ShotDue && target is { } shot)
            {
                rusherShotIntents.Add(new(key,shot.PlayerId,shot.TargetFileId,shot.Position,
                    attack.CurrentShotIsReal,attack.BatchCursor,attack.BatchSize));
                attack.CommitShot();
            }
        }
        LaunchRusherShotIntents();
    }

    private void LaunchRusherShotIntents()
    {
        if(rifleCombat==null || rusherShotIntents.Count==0)return;
        foreach(var intent in rusherShotIntents)
        {
            if(!activeArmyEntities.TryGetValue(intent.EntityKey,out var army) ||
               army.OwnerPlayerId!=intent.PlayerId || !intent.IsReal)continue;
            string behavior=armyCatalog!.Families.Single(f=>f.UnitId==army.UnitId).BehaviorType;
            if(behavior=="SoldierBehaviourFlamethrower")
            {
                if(PendingProjectileCount>=MaximumProjectiles||!EventCapacityForShot())continue;
                if(projectileId==ulong.MaxValue)throw new InvalidDataException("Army flame identity exhausted.");
                ulong flameId=++projectileId;
                armyFlameBursts.Add(flameId,new ArmyFlameBurst(flameId,intent.EntityKey,intent.PlayerId,tick));
                Emit(MatchEventKind.Shot,intent.PlayerId,intent.TargetFileId.ToString(),
                    flameId,new Vector3(army.X,army.Y,army.Z),0,"army-flame");
                continue;
            }
            float? projectileSpeed=behavior switch
            {
                "SoldierBehaviourShotgunner" or "SoldierBehaviourWarper"=>10f,
                "SoldierBehaviourParachuter" or "SoldierBehaviourSwat"=>5f,
                _=>null // Commando still requires its non-bullet source path.
            };
            if(!projectileSpeed.HasValue)continue;
            if(PendingProjectileCount>=MaximumProjectiles ||
               !EventCapacityForShot())continue;
            var origin=new Vector3(army.X,army.Y,army.Z);
            ulong id=checked(++projectileId);
            var flight=new ArmyProjectileFlight(id,intent.EntityKey,origin,intent.TargetPosition,
                projectileSpeed.Value,tick,
                (from,direction,range)=>rifleCombat.TraceForArmy(intent.PlayerId,from,direction,range));
            armyProjectiles.Add(id,flight);
            Emit(MatchEventKind.Shot,intent.PlayerId,intent.TargetFileId.ToString(),
                id,origin,0,"army");
        }
    }

    private void AdvanceArmyProjectiles()
    {
        foreach(var pair in armyProjectiles.ToArray())
        {
            ArmyProjectileImpact? impact;
            try { impact=pair.Value.Advance(tick); }
            catch(InvalidDataException){End("invalid-army-projectile-authority","",false);return;}
            if(pair.Value.Finished)armyProjectiles.Remove(pair.Key);
            if(impact==null)continue;
            Emit(MatchEventKind.Impact,impact.EntityKey.ToString(),
                impact.Collision.PlayerId??"",impact.ProjectileId,impact.Collision.Position,0,"army");
            if(impact.Collision.PlayerId==null)continue;
            if(!activeArmyEntities.TryGetValue(impact.EntityKey,out var army))continue;
            var owner=Find(army.OwnerPlayerId);
            if(owner==null)continue;
            try
            {
                var proof=ArmyRusherImpactResolver.Resolve(
                    new ArmyRusherShotIntent(impact.EntityKey,owner.Definition.PlayerId,
                        0,impact.Collision.Position,true,0,1),impact.Collision,
                    ArmyDamage(impact.EntityKey)??0);
                ApplyArmyRusherPlayerImpact(proof,damageRoll?.Invoke()??1f);
            }
            catch(InvalidDataException){End("invalid-army-impact-authority","",false);return;}
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
            var origin=new Vector3(army.X,army.Y,army.Z);
            var target=rifleCombat?.Pose(victim.Definition.PlayerId).Collision;
            if(target==null)throw new InvalidDataException("Army flame requires current player collision authority.");
            var hit=ArmyFlameBurst.ResolvePlayer(origin,target.RootPosition-origin,target,
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
        if(damage>=vitality.Current)return ConfirmArmyDeath(entityKey,false);
        vitality.Current-=damage;
        if(!float.IsFinite(vitality.Current) || vitality.Current<=0 || vitality.Current>vitality.Maximum)
            throw new InvalidDataException("Army damage produced invalid host vitality.");
        activeArmyEntities[entityKey].Health=vitality.Current;
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
        armySpeed.Remove(entityKey);
        rusherMotionCandidates.Remove(entityKey);
        rusherSteering.Remove(entityKey);
        rusherRetargetClocks.Remove(entityKey);
        rusherDetours.Remove(entityKey);
        rusherAttacks.Remove(entityKey);
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

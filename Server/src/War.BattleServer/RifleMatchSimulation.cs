using System.Numerics;
using War.Protocol;

namespace War.BattleServer;

// Recovered cover paths, rifle/shotgun poses and walking-shot timing.
internal sealed record RifleActorLocation(Vector3 Position,int CoverIndex,bool Moving);
internal enum LiveWeaponClass { Rifle, Shotgun, Smg, Pistol, Lmg, Minigun, Sniper, Bazooka }
internal sealed record SniperGestureResult(string Code,Vector3? FireTarget);
internal sealed class RifleMatchSimulation
{
    private sealed class Actor(ParticipantManifest definition,CoverNode cover,PlayerPoseCatalog poses,int animationFamily,LiveWeaponClass weaponClass)
    {
        internal readonly ParticipantManifest Definition=definition;
        internal CoverNode Cover=cover;
        internal RifleCoverTimeline Timeline=new(poses,animationFamily);
        internal readonly RifleFirstShot First=new();
        internal readonly SmgBurstScheduler Burst=new();
        internal readonly MinigunFireState Minigun=new();
        internal readonly SniperAimState Sniper=new();
        internal readonly BazookaHoldState Bazooka=new();
        internal readonly PlayerAimState Aim=new();
        internal PlayerAimPose Pose=poses.SampleBlended("idle",0,true,"idle",0,true,0,Quaternion.Identity).Place(cover.Position,cover.Rotation);
        internal RiflePoseState WirePose=RiflePoseProjection.Create(0,[new(new("idle",0,1,true),1)],cover.Rotation,Quaternion.Identity,null);
        internal Vector3 Position=cover.Position;
        internal Quaternion Rotation=cover.Rotation;
        internal bool Moving;
        internal double RunSeconds;
        internal double? WalkingShotStart;
        internal WeaponManifest Weapon=definition.Weapon;
        internal int WeaponUpgrade=definition.WeaponUpgrade!.Value;
        internal LiveWeaponClass WeaponClass=weaponClass;
    }
    private readonly Actor[] actors;
    private readonly BattleCombatContent content;
    private readonly RecoveredBattleMap map;
    private readonly Func<string,bool>? dynamicColliderEnabled;
    private readonly Func<int,bool>? indexedColliderEnabled;
    private readonly Func<int,int,int>? runtimeLayer;
    private readonly string mode;
    private ulong? lastTick;
    private double now;
    internal PlayerAimPose Pose(string id)=>actors.Single(a=>a.Definition.PlayerId==id).Pose;
    internal RiflePoseState Snapshot(string id)=>actors.Single(a=>a.Definition.PlayerId==id).WirePose.Clone();
    internal void StartMove(string id)
    {
        var actor=actors.Single(a=>a.Definition.PlayerId==id);
        actor.First.StopShooting();actor.Burst.Cancel();actor.Minigun.Release();actor.Sniper.Cancel();actor.Bazooka.Cancel();actor.Timeline.ResetToIdle();actor.RunSeconds=0;actor.WalkingShotStart=null;
        actor.Moving=true;
    }
    internal void StopShooting(string id)
    {var actor=actors.Single(a=>a.Definition.PlayerId==id);actor.First.StopShooting();actor.Burst.Cancel();actor.Minigun.Release();actor.Sniper.Cancel();actor.Bazooka.Cancel();}
    internal bool IsMinigun(string id)=>actors.Single(a=>a.Definition.PlayerId==id).WeaponClass==LiveWeaponClass.Minigun;
    internal bool MinigunHeld(string id)=>actors.Single(a=>a.Definition.PlayerId==id).Minigun.Active;
    internal bool IsSniper(string id)=>actors.Single(a=>a.Definition.PlayerId==id).WeaponClass==LiveWeaponClass.Sniper;
    internal bool SniperAiming(string id)=>actors.Single(a=>a.Definition.PlayerId==id).Sniper.Active;
    internal bool SniperScopeVisible(string id,ulong tick)
    {var a=actors.Single(x=>x.Definition.PlayerId==id);return a.WeaponClass==LiveWeaponClass.Sniper&&a.Sniper.ScopeVisible(tick,content.Snipers!.Binding(a.Weapon.SourceId).ScopeShowSeconds);}
    internal void UpdateSniperReady(string id,bool ready,ulong tick){var a=actors.Single(x=>x.Definition.PlayerId==id);if(a.WeaponClass==LiveWeaponClass.Sniper&&ready)a.Sniper.Arm(tick);}
    internal bool IsBazooka(string id)=>actors.Single(a=>a.Definition.PlayerId==id).WeaponClass==LiveWeaponClass.Bazooka;
    internal bool BazookaTargeting(string id)=>actors.Single(a=>a.Definition.PlayerId==id).Bazooka.Active;
    internal string HoldBazooka(string id,bool pressed,Vector3 target,ulong tick)
    {
        var a=actors.Single(x=>x.Definition.PlayerId==id);if(a.WeaponClass!=LiveWeaponClass.Bazooka)return "wrong-fire-mode";
        if(!pressed){a.Bazooka.Cancel();a.Timeline.ResetToIdle();return "bazooka-cancelled";}
        if(a.Bazooka.Active)return "bazooka-targeting";
        if(!ValidTarget(a,target,out bool right))return "invalid-target";
        a.Bazooka.Press(tick,target);a.Timeline.Uncover(right);a.Aim.LookAt(target-a.Position,a.Cover.Rotation,now);return "bazooka-targeting";
    }
    internal SniperGestureResult SniperGesture(string id,bool pressed,bool cancelled,Vector3 target,ulong tick,bool ready)
    {
        var a=actors.Single(x=>x.Definition.PlayerId==id);if(a.WeaponClass!=LiveWeaponClass.Sniper)return new("wrong-fire-mode",null);
        if(pressed)
        {
            if(!ValidTarget(a,target,out bool right))return new("invalid-target",null);
            if(a.Sniper.Active){a.Sniper.Update(target);a.Aim.LookAt(target-a.Position,a.Cover.Rotation,now);return new("sniper-target-updated",null);}
            a.Sniper.Press(tick,target,ready);a.Timeline.Uncover(right);a.Aim.LookAt(target-a.Position,a.Cover.Rotation,now);return new("sniper-aiming",null);
        }
        var fire=a.Sniper.Release(tick,content.Snipers!.Binding(a.Weapon.SourceId).ScopeShowSeconds,cancelled);
        if(!fire.HasValue){a.Timeline.BeginHide();return new("sniper-cancelled",null);}
        if(!ValidTarget(a,fire.Value,out bool shootRight)){a.Timeline.BeginHide();return new("invalid-target",null);}
        a.Timeline.Shot(shootRight);a.Aim.LookAt(fire.Value-a.Position,a.Cover.Rotation,now);return new("sniper-fire",fire);
    }
    internal string HoldMinigun(string id,bool pressed,Vector3 target,ulong tick)
    {
        var a=actors.Single(x=>x.Definition.PlayerId==id);
        if(a.WeaponClass!=LiveWeaponClass.Minigun)return "wrong-fire-mode";
        if(!pressed){a.Minigun.Release();return "minigun-released";}
        if(!ValidTarget(a,target,out bool right))return "invalid-target";
        if(a.Minigun.Active){a.Minigun.UpdateTarget(target);return "minigun-target-updated";}
        a.Minigun.Press(tick,target);a.Timeline.Uncover(right);a.Aim.LookAt(target-a.Position,a.Cover.Rotation,now);
        return "minigun-spinning";
    }
    internal bool BurstActive(string id)
    {var actor=actors.Single(a=>a.Definition.PlayerId==id);return actor.WeaponClass is (LiveWeaponClass.Smg or LiveWeaponClass.Lmg)&&actor.Burst.Active;}
    internal void ShotAccepted(string id,Vector3 target,ulong tick)
    {
        var actor=actors.Single(a=>a.Definition.PlayerId==id);
        if(actor.WeaponClass==LiveWeaponClass.Minigun)
        {actor.Minigun.ShotAccepted(tick,content.Minigun!.Stage(actor.WeaponUpgrade));return;}
        if(actor.WeaponClass is not (LiveWeaponClass.Smg or LiveWeaponClass.Lmg))return;
        var stage=BurstStage(actor);
        if(!actor.Burst.Active && actor.Burst.CanStart(tick))actor.Burst.StartAfterFirstShot(tick,target,stage);
    }
    internal void SwitchWeapon(string id,WeaponManifest weapon,int upgrade)
    {
        var actor=actors.Single(a=>a.Definition.PlayerId==id);
        var weaponClass=Class(weapon.SourceId);
        int family=Family(weapon.SourceId,weaponClass);
        if(family is not (0 or 2 or 4 or 5 or 7 or 9 or 10 or 13 or 15))throw new InvalidDataException("Unsupported weapon animation family.");
        actor.First.SelectionChanged();actor.Burst.Cancel();actor.Minigun.Release();actor.Sniper.Cancel();actor.Bazooka.Cancel();actor.Timeline=new RifleCoverTimeline(content.Poses,family);
        actor.Weapon=weapon;actor.WeaponUpgrade=upgrade;actor.WeaponClass=weaponClass;actor.RunSeconds=0;actor.WalkingShotStart=null;
    }
    internal RifleMatchSimulation(MatchManifest manifest,RecoveredBattleMap map,BattleCombatContent content,
        Func<string,bool>? dynamicColliderEnabled=null,Func<int,bool>? indexedColliderEnabled=null,
        Func<int,int,int>? runtimeLayer=null)
    {
        this.content=content;this.map=map;this.dynamicColliderEnabled=dynamicColliderEnabled;
        this.indexedColliderEnabled=indexedColliderEnabled;
        this.runtimeLayer=runtimeLayer;
        mode=manifest.Mode;
        int FamilyOf(ParticipantManifest p)=>Family(p.Weapon.SourceId,Class(p.Weapon.SourceId));
        if (manifest.Players.Any(p=>p.Combat==null || !p.WeaponUpgrade.HasValue ||
            FamilyOf(p) is not (0 or 2 or 4 or 5 or 7 or 9 or 10 or 13 or 15)))
            throw new InvalidDataException("Live combat requires health, source upgrades and a recovered animation family.");
        actors=manifest.Players.Select(p=>new Actor(p,map.Covers[p.StartCover],content.Poses,
            FamilyOf(p),Class(p.Weapon.SourceId))).ToArray();
    }
    private LiveWeaponClass Class(string id)
    {
        if(mode==MatchManifest.RifleCombatMode)return LiveWeaponClass.Rifle;
        if(mode==MatchManifest.ShotgunCombatMode)return LiveWeaponClass.Shotgun;
        if(mode==MatchManifest.SmgCombatMode)return LiveWeaponClass.Smg;
        if(mode==MatchManifest.PistolCombatMode)return LiveWeaponClass.Pistol;
        if(mode==MatchManifest.LmgCombatMode)return LiveWeaponClass.Lmg;
        if(mode==MatchManifest.MinigunCombatMode)return LiveWeaponClass.Minigun;
        if(mode==MatchManifest.SniperCombatMode)return LiveWeaponClass.Sniper;
        if(mode==MatchManifest.BazookaCombatMode)return LiveWeaponClass.Bazooka;
        if(mode==MatchManifest.MixedCombatMode)
        {
            if(id.StartsWith("Google2u.AssaultRifle_",StringComparison.Ordinal))return LiveWeaponClass.Rifle;
            if(id.StartsWith("Google2u.Shotgun_",StringComparison.Ordinal))return LiveWeaponClass.Shotgun;
            if(id.StartsWith("Google2u.SMG_",StringComparison.Ordinal))return LiveWeaponClass.Smg;
            if(id.StartsWith("Google2u.Pistol_",StringComparison.Ordinal))return LiveWeaponClass.Pistol;
            if(id==MinigunCatalog.SourceId)return LiveWeaponClass.Minigun;
            if(id.StartsWith("Google2u.SniperRifle_",StringComparison.Ordinal))return LiveWeaponClass.Sniper;
            if(id.StartsWith("Google2u.Bazooka_",StringComparison.Ordinal))return LiveWeaponClass.Bazooka;
            if(id.StartsWith("Google2u.LMG_",StringComparison.Ordinal))return LiveWeaponClass.Lmg;
        }
        throw new InvalidDataException("Weapon is outside the admitted live class.");
    }
    private int Family(string id,LiveWeaponClass weaponClass)=>weaponClass switch
    {
        LiveWeaponClass.Rifle=>content.Bindings.Get(id).AnimationFamily,
        LiveWeaponClass.Shotgun=>content.Shotguns!.Binding(id).AnimationFamily,
        LiveWeaponClass.Smg=>content.Smgs!.Binding(id).AnimationFamily,
        LiveWeaponClass.Pistol=>content.Pistols!.Binding(id).AnimationFamily,
        LiveWeaponClass.Lmg=>content.Lmgs!.Binding(id).AnimationFamily,
        LiveWeaponClass.Minigun=>content.Minigun!.Binding.AnimationFamily,
        LiveWeaponClass.Sniper=>content.Snipers!.Binding(id).AnimationFamily,
        LiveWeaponClass.Bazooka=>content.Bazookas!.Binding(id).AnimationFamily,
        _=>throw new InvalidDataException("Unsupported live weapon class.")
    };
    internal string Trigger(string id,Vector3 target)
    {
        var a=actors.Single(p=>p.Definition.PlayerId==id);
        if (a.First.Waiting) return "first-shot-pending";
        if(!ValidTarget(a,target,out bool right))return "invalid-target";
        var direction=target-a.Position;direction.Y=0;
        if(a.WeaponClass is LiveWeaponClass.Smg or LiveWeaponClass.Lmg)
        {
            if(a.Burst.Active){a.Burst.UpdateTarget(target);return "burst-active";}
            if(!a.Burst.CanStart(lastTick??0))return "burst-locked";
        }
        var phase=a.Timeline.Phase;
        var result=a.First.Trigger(now,target,right,!a.Moving&&phase==RifleCoverPhase.Idle,!a.Moving&&phase==RifleCoverPhase.Hiding,
            !a.Moving&&phase==RifleCoverPhase.Firing,a.Moving,a.Moving,a.Timeline.HidingWait,a.Timeline.UncoverWait*4,0);
        if(a.Moving)
        {
            a.WalkingShotStart=now;
            a.Aim.LookUpper(direction,a.Rotation,now);
        }
        else
        {
            a.Timeline.Shot(right);
            a.Aim.LookAt(direction,a.Cover.Rotation,now);
        }
        return result.Immediate ? "fire-now" : result.Scheduled ? "shot-scheduled" : "uncovering";
    }
    private static bool ValidTarget(Actor a,Vector3 target,out bool right)
    {
        right=false;var direction=target-a.Position;
        var forward=Vector3.Transform(Vector3.UnitZ,a.Moving?a.Rotation:a.Cover.Rotation);
        if(!PlayerHitbox.Finite(target)||direction.LengthSquared()<1e-10f||Vector3.Dot(-forward,Vector3.Normalize(direction))<=MathF.Cos(95*MathF.PI/180))return false;
        direction.Y=0;if(direction.LengthSquared()<1e-10f)return false;
        right=Vector3.Dot(Vector3.UnitY,Vector3.Cross(forward,direction))>0;return true;
    }
    internal void Advance(ulong tick,Func<string,RifleActorLocation> locate,Func<string,Vector3,string> fire)
    {
        if (lastTick.HasValue && tick!=lastTick.Value+1) throw new InvalidDataException("Rifle combat requires consecutive simulation ticks.");
        now=tick/(double)MatchManifest.TickRate;
        float delta=lastTick.HasValue ? 1f/MatchManifest.TickRate : 0;
        lastTick=tick;
        foreach (var a in actors)
        {
            var state=locate(a.Definition.PlayerId);
            if (!PlayerHitbox.Finite(state.Position) || state.CoverIndex<0 || state.CoverIndex>=map.Covers.Count ||
                map.Covers[state.CoverIndex].Fraction!=a.Definition.Fraction)
                throw new InvalidDataException("Invalid moving player authority.");
            a.Cover=map.Covers[state.CoverIndex];
            if(state.Moving)
            {
                if(!a.Moving){a.Timeline.ResetToIdle();a.First.SelectionChanged();a.RunSeconds=0;}
                var pathDirection=state.Position-a.Position;pathDirection.Y=0;
                if(pathDirection.LengthSquared()>1e-10f)
                    a.Rotation=Quaternion.CreateFromAxisAngle(Vector3.UnitY,MathF.Atan2(pathDirection.X,pathDirection.Z));
                a.RunSeconds+=delta;
            }
            else
            {
                if(a.Moving)a.Timeline.ResetToIdle();
                a.WalkingShotStart=null;
                a.Rotation=a.Cover.Rotation;a.RunSeconds=0;
            }
            a.Moving=state.Moving;a.Position=state.Position;
            a.Timeline.Advance(now);a.Aim.Advance(now,delta,a.Rotation);
            IReadOnlyList<RifleClipLayer> layers=state.Moving ?
                [new(new(a.Timeline.RunClip,a.RunSeconds,1,true),1)] : a.Timeline.Layers;
            RifleClipLayer? upperLayer=null;
            if(state.Moving && a.WalkingShotStart.HasValue)
            {
                double elapsed=now-a.WalkingShotStart.Value;
                float weight=elapsed<.08 ? (float)(elapsed/.08) : elapsed<=.4 ? 1 : Math.Max(0,1-(float)(elapsed-.4)*3);
                if(weight>.1f)
                    upperLayer=new(new("shootAdditive",Math.Min(elapsed,content.Poses.Duration("shootAdditive")),1,false),weight);
                else if(elapsed>.7)a.WalkingShotStart=null;
            }
            a.Pose=(upperLayer!=null ? content.Poses.SampleWalkingShot(a.Timeline.RunClip,a.RunSeconds,upperLayer.Clip.Seconds,
                upperLayer.Weight,a.Aim.BodyRotation,a.Aim.UpperOverride) :
                content.Poses.SampleLayers(layers,a.Aim.BodyRotation,a.Aim.UpperOverride)).Place(a.Position,a.Rotation);
            a.WirePose=RiflePoseProjection.Create(tick,layers,a.Rotation,a.Aim.BodyRotation,a.Aim.UpperOverride,upperLayer);
        }
        foreach (var a in actors)
        {
            var target=a.First.Advance(now,false);
            if (target.HasValue) _=fire(a.Definition.PlayerId,target.Value);
            if(a.WeaponClass is LiveWeaponClass.Smg or LiveWeaponClass.Lmg)
            {
                var burstTarget=a.Burst.Advance(tick,BurstStage(a));
                if(burstTarget.HasValue)_=fire(a.Definition.PlayerId,burstTarget.Value);
            }
            if(a.WeaponClass==LiveWeaponClass.Minigun)
            {
                var due=a.Minigun.Due(tick,content.Minigun!.Stage(a.WeaponUpgrade),content.Minigun.Binding);
                if(due.HasValue)
                {
                    string result=Trigger(a.Definition.PlayerId,due.Value);
                    if(result=="fire-now")_=fire(a.Definition.PlayerId,due.Value);
                }
            }
            if(a.WeaponClass==LiveWeaponClass.Bazooka)
            {
                var due=a.Bazooka.Due(tick,content.Bazookas!.Binding(a.Weapon.SourceId).HoldSeconds);
                if(due.HasValue)
                {
                    if(!ValidTarget(a,due.Value,out bool right))throw new InvalidDataException("Bazooka target changed validity.");
                    a.Timeline.BazookaShoot(right);a.Aim.LookAt(due.Value-a.Position,a.Cover.Rotation,now);
                    _=fire(a.Definition.PlayerId,due.Value);
                }
            }
        }
    }
    internal IReadOnlyList<PreparedProjectile> PrepareVolley(ulong id,string owner,Vector3 target,ulong tick)
    {
        var a=actors.Single(p=>p.Definition.PlayerId==owner);
        var world=new ShotCollisionWorld(map,actors.Select(p=>new CollisionPlayer(p.Definition.PlayerId,p.Pose.Collision)),
            dynamicColliderEnabled,indexedColliderEnabled,runtimeLayer);
        var muzzle=a.Pose.Muzzle(a.Weapon.SourceId).Position;
        uint bulletMask=a.WeaponClass==LiveWeaponClass.Smg ? (a.Definition.Fraction==1?content.Smgs!.AlliesBulletMask:content.Smgs!.EnemiesBulletMask) :
            a.WeaponClass==LiveWeaponClass.Pistol ? (a.Definition.Fraction==1?content.Pistols!.AlliesBulletMask:content.Pistols!.EnemiesBulletMask) :
            a.WeaponClass==LiveWeaponClass.Lmg ? (a.Definition.Fraction==1?content.Lmgs!.AlliesBulletMask:content.Lmgs!.EnemiesBulletMask) :
            a.WeaponClass==LiveWeaponClass.Minigun ? (a.Definition.Fraction==1?content.Minigun!.AlliesBulletMask:content.Minigun!.EnemiesBulletMask) :
            a.WeaponClass==LiveWeaponClass.Sniper ? (a.Definition.Fraction==1?content.Snipers!.AlliesBulletMask:content.Snipers!.EnemiesBulletMask) :
            content.Bindings.BulletMask(a.Definition.Fraction);
        var trace=new Func<Vector3,Vector3,float,ShotCollision?>((from,direction,range)=>
            world.Raycast(owner,from,direction,range,bulletMask));
        if(a.WeaponClass==LiveWeaponClass.Smg)return [content.Smgs!.Prepare(a.Weapon.SourceId,a.WeaponUpgrade,id,owner,muzzle,target,tick,
            Random.Shared.NextSingle(),trace)];
        if(a.WeaponClass==LiveWeaponClass.Pistol)return [content.Pistols!.Prepare(a.Weapon.SourceId,a.WeaponUpgrade,id,owner,muzzle,target,tick,
            Random.Shared.NextSingle(),trace)];
        if(a.WeaponClass==LiveWeaponClass.Lmg)return [content.Lmgs!.Prepare(a.Weapon.SourceId,a.WeaponUpgrade,id,owner,muzzle,target,tick,
            Random.Shared.NextSingle(),trace)];
        if(a.WeaponClass==LiveWeaponClass.Minigun)return [content.Minigun!.Prepare(a.WeaponUpgrade,id,owner,muzzle,target,tick,
            Random.Shared.NextSingle(),trace)];
        if(a.WeaponClass==LiveWeaponClass.Sniper)return [content.Snipers!.Prepare(a.Weapon.SourceId,a.WeaponUpgrade,id,owner,muzzle,target,tick,
            Random.Shared.NextSingle(),trace)];
        if(a.WeaponClass==LiveWeaponClass.Rifle)return [content.Bindings.Prepare(content.Stats,a.Weapon.SourceId,
            a.WeaponUpgrade,id,owner,muzzle,target,tick,Random.Shared.NextSingle(),trace)];
        var binding=content.Shotguns!.Binding(a.Weapon.SourceId);
        var stage=content.Shotguns.Stage(a.Weapon.SourceId,a.WeaponUpgrade);
        return ShotgunVolleyFactory.Prepare(binding,stage,id,owner,muzzle,target,tick,
            world.OverlapEnemy(owner,muzzle+binding.ShotOffset,binding.Geometry.Radius),
            Random.Shared.NextSingle,trace);
    }

    private IBurstStage BurstStage(Actor actor)=>actor.WeaponClass switch
    {
        LiveWeaponClass.Smg=>content.Smgs!.Stage(actor.Weapon.SourceId,actor.WeaponUpgrade),
        LiveWeaponClass.Lmg=>content.Lmgs!.Stage(actor.Weapon.SourceId,actor.WeaponUpgrade),
        _=>throw new InvalidDataException("Weapon class has no burst authority.")
    };

    internal ShotCollision? TraceForArmy(string owner,Vector3 origin,Vector3 direction,float range)
    {
        var actor=actors.Single(a=>a.Definition.PlayerId==owner);
        var world=new ShotCollisionWorld(map,
            actors.Select(p=>new CollisionPlayer(p.Definition.PlayerId,p.Pose.Collision)),
            dynamicColliderEnabled,indexedColliderEnabled,runtimeLayer);
        return world.Raycast(owner,origin,direction,range,
            content.Bindings.BulletMask(actor.Definition.Fraction));
    }
    internal ShotCollision? TraceForBazooka(string owner,Vector3 origin,Vector3 direction,float range,uint mask)
    {
        var world=new ShotCollisionWorld(map,actors.Select(p=>new CollisionPlayer(p.Definition.PlayerId,p.Pose.Collision)),
            dynamicColliderEnabled,indexedColliderEnabled,runtimeLayer);
        return world.Raycast(owner,origin,direction,range,mask);
    }
    internal Vector3 BazookaMuzzle(string owner,bool secondary)
    {
        var a=actors.Single(x=>x.Definition.PlayerId==owner);
        return a.Pose.Muzzle(a.Weapon.SourceId+(secondary?"#secondary":"")).Position;
    }
}

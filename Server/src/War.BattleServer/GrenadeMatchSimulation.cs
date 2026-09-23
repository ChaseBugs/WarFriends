using System.Numerics;
using War.Protocol;

namespace War.BattleServer;

internal sealed record ScheduledGrenadeLaunch(string Owner,Vector3 Target,bool Right,ulong LaunchTick,
    string WeaponSourceId,int Upgrade);

// Source-owned grenade gesture/animation clock. MatchEngine remains responsible
// for ammunition, cooldown, projectile identity, damage, and terminal state.
internal sealed class GrenadeMatchSimulation
{
    private sealed class Actor
    {
        internal readonly ParticipantManifest Definition;internal readonly GrenadeBinding Binding;
        internal Vector3 Position;internal Quaternion Rotation;internal string Clip;internal ulong ClipStarted;
        internal ScheduledGrenadeLaunch? Pending;internal GrenadePoseFrame Pose;
        internal Actor(ParticipantManifest definition,CoverNode cover,GrenadeBinding binding,GrenadePoseCatalog poses)
        {Definition=definition;Binding=binding;Position=cover.Position;Rotation=cover.Rotation;
         Clip=binding.Swipe?"grenade_idle":"grenadelauncher_idle";Pose=Place(poses.Sample(Clip,0,true),Position,Rotation);}
    }
    private readonly Actor[] actors;private readonly GrenadeCatalog catalog;private readonly RecoveredBattleMap map;
    private readonly Func<string,bool>? dynamicColliderEnabled;private readonly Func<int,bool>? indexedColliderEnabled;
    private readonly Func<int,int,int>? runtimeLayer;private ulong? lastTick;
    internal GrenadeMatchSimulation(MatchManifest manifest,RecoveredBattleMap map,GrenadeCatalog catalog,
        Func<string,bool>? dynamicColliderEnabled=null,Func<int,bool>? indexedColliderEnabled=null,Func<int,int,int>? runtimeLayer=null)
    {
        if(manifest.Mode!=MatchManifest.GrenadeCombatMode||manifest.Players.Any(p=>p.Combat==null||!p.WeaponUpgrade.HasValue))
            throw new InvalidDataException("Grenade simulation requires complete combat authority.");
        this.map=map;this.catalog=catalog;this.dynamicColliderEnabled=dynamicColliderEnabled;
        this.indexedColliderEnabled=indexedColliderEnabled;this.runtimeLayer=runtimeLayer;
        actors=manifest.Players.Select(p=>new Actor(p,map.Covers[p.StartCover],catalog.Binding(p.Weapon.SourceId),catalog.Poses)).ToArray();
    }
    internal bool Busy(string id)=>ActorOf(id).Pending!=null;
    internal PlayerCollisionModel Collision(string id)=>ActorOf(id).Pose.Collision;
    internal RiflePoseState Snapshot(string id,ulong tick)
    {
        var actor=ActorOf(id);double seconds=(tick-actor.ClipStarted)/(double)MatchManifest.TickRate;
        bool loop=actor.Clip is "grenade_idle" or "grenade_run" or "grenadelauncher_idle" or "run_grenadelauncher";
        return RiflePoseProjection.Create(tick,[new(new(actor.Clip,seconds,1,loop),1)],actor.Rotation,Quaternion.Identity,null);
    }
    internal ScheduledGrenadeLaunch? Begin(string id,GrenadeThrowCommand command,ulong tick)
    {
        var actor=ActorOf(id);if(actor.Pending!=null)return null;Vector3 target;bool right;double delay;
        if(actor.Binding.Swipe)
        {
            if(!command.Swipe||!Zero(command.TargetX)||!Zero(command.TargetY)||!Zero(command.TargetZ))throw new InvalidDataException("Swipe grenade requires canonical input.");
            var plan=GrenadeThrowPlanner.Plan(actor.Binding,actor.Position,actor.Rotation,
                new(command.SwipeStartX,command.SwipeStartY,command.SwipeStartZ),new(command.SwipeEndX,command.SwipeEndY,command.SwipeEndZ),command.HeldSeconds);
            target=plan.Target;right=plan.Right;delay=actor.Binding.FirstShotWaitSeconds;
            actor.Clip=right?"throw_grenade_left":"throw_grenade_right";
        }
        else
        {
            if(command.Swipe||!Zero(command.SwipeStartX)||!Zero(command.SwipeStartY)||!Zero(command.SwipeStartZ)||
               !Zero(command.SwipeEndX)||!Zero(command.SwipeEndY)||!Zero(command.SwipeEndZ)||!Zero(command.HeldSeconds))
                throw new InvalidDataException("Launcher requires canonical target input.");
            target=new(command.TargetX,command.TargetY,command.TargetZ);if(!PlayerHitbox.Finite(target)||Vector3.DistanceSquared(actor.Position,target)<1e-10f)throw new InvalidDataException("Invalid launcher target.");
            var planar=target-actor.Position;planar.Y=0;if(planar.LengthSquared()<1e-10f)throw new InvalidDataException("Invalid launcher direction.");
            var forward=Vector3.Transform(Vector3.UnitZ,actor.Rotation);right=Vector3.Dot(Vector3.UnitY,Vector3.Cross(forward,planar))>0;
            actor.Clip=right?"player_look_left_grenadelauncher":"player_look_right_grenadelauncher";
            delay=catalog.Poses.Duration(actor.Clip)*.25;
        }
        ulong launchTick=checked(tick+Math.Max(1,(ulong)Math.Ceiling(delay*MatchManifest.TickRate)));
        actor.ClipStarted=tick;actor.Pending=new(id,target,right,launchTick,actor.Definition.Weapon.SourceId,actor.Definition.WeaponUpgrade!.Value);
        actor.Pose=Place(catalog.Poses.Sample(actor.Clip,0,false),actor.Position,actor.Rotation);return actor.Pending;
    }
    internal IReadOnlyList<ScheduledGrenadeLaunch> Advance(ulong tick)
    {
        if(lastTick.HasValue&&tick!=lastTick.Value+1)throw new InvalidDataException("Grenade animation requires consecutive ticks.");lastTick=tick;
        var due=new List<ScheduledGrenadeLaunch>();
        foreach(var actor in actors)
        {
            bool loop=Loops(actor.Clip);double seconds=(tick-actor.ClipStarted)/(double)MatchManifest.TickRate;
            actor.Pose=Place(catalog.Poses.Sample(actor.Clip,seconds,loop),actor.Position,actor.Rotation);
            if(actor.Pending is { } pending&&pending.LaunchTick<=tick)
            {
                due.Add(pending);actor.Pending=null;
                if(!actor.Binding.Swipe){actor.Clip=pending.Right?"player_fire_left_grenadelauncher":"player_fire_right_grenadelauncher";actor.ClipStarted=tick;}
            }
            else if(actor.Pending==null&&seconds>=catalog.Poses.Duration(actor.Clip))
            {actor.Clip=actor.Binding.Swipe?"grenade_idle":"grenadelauncher_idle";actor.ClipStarted=tick;actor.Pose=Place(catalog.Poses.Sample(actor.Clip,0,true),actor.Position,actor.Rotation);}
        }
        return due;
    }
    internal Vector3 Muzzle(ScheduledGrenadeLaunch launch)
    {
        var actor=ActorOf(launch.Owner);return launch.Right&&actor.Binding.Swipe?actor.Pose.Left.Position:actor.Pose.Right[launch.WeaponSourceId].Position;
    }
    internal ShotCollision? Trace(string owner,Vector3 origin,Vector3 direction,float range,uint mask)
    {var world=new ShotCollisionWorld(map,actors.Select(x=>new CollisionPlayer(x.Definition.PlayerId,x.Pose.Collision)),dynamicColliderEnabled,indexedColliderEnabled,runtimeLayer);return world.Raycast(owner,origin,direction,range,mask);}
    private Actor ActorOf(string id)=>actors.Single(x=>x.Definition.PlayerId==id);
    private static bool Loops(string clip)=>clip is "grenade_idle" or "grenade_run" or "grenadelauncher_idle" or "run_grenadelauncher";
    private static bool Zero(float value)=>BitConverter.SingleToInt32Bits(value)==0;
    private static GrenadePoseFrame Place(GrenadePoseFrame frame,Vector3 position,Quaternion rotation)=>new(frame.Seconds,
        frame.Collision.Place(position,rotation),frame.Left.Place(position,rotation),
        frame.Right.ToDictionary(x=>x.Key,x=>x.Value.Place(position,rotation),StringComparer.Ordinal));
}

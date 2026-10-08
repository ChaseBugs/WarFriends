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
        internal bool Moving;
        internal ScheduledGrenadeLaunch? Pending;internal GrenadePoseFrame Pose;
        internal Actor(ParticipantManifest definition,CoverNode cover,GrenadeBinding binding,GrenadePoseCatalog poses)
        {Definition=definition;Binding=binding;Position=cover.Position;Rotation=cover.Rotation;
         Clip=binding.Swipe?"grenade_idle":"grenadelauncher_idle";Pose=Place(poses.Sample(Clip,0,true),Position,Rotation);}
    }
    private readonly Actor[] actors;private readonly GrenadeCatalog catalog;private readonly RecoveredBattleMap map;
    private readonly Func<string,bool>? dynamicColliderEnabled;private readonly Func<int,bool>? indexedColliderEnabled;
    private readonly Func<int,int,int>? runtimeLayer;private ulong? lastTick;
    private Func<string,IReadOnlyList<DynamicShotTarget>>? dynamicTargets;
    private Func<IReadOnlyList<DynamicShotTarget>>? visibilityTargets;
    private GrenadeShotTargetCatalog? shotTargets;
    internal void ConfigureDynamicTargets(Func<string,IReadOnlyList<DynamicShotTarget>> provider)
        =>dynamicTargets=provider??throw new ArgumentNullException(nameof(provider));
    internal void ConfigureVisibilityTargets(Func<IReadOnlyList<DynamicShotTarget>> provider)
        =>visibilityTargets=provider??throw new ArgumentNullException(nameof(provider));
    internal void ConfigureShotTargets(GrenadeShotTargetCatalog catalog)
        =>shotTargets=catalog??throw new ArgumentNullException(nameof(catalog));
    internal IReadOnlyList<Vector3> PlayerShotTargets(string id)
    {
        var actor=ActorOf(id);
        if(shotTargets==null||lastTick==null||lastTick.Value<actor.ClipStarted)
            throw new InvalidDataException("Grenade target pose clock is unavailable.");
        double seconds=(lastTick.Value-actor.ClipStarted)/(double)MatchManifest.TickRate;
        return shotTargets.Place(actor.Clip,seconds,Loops(actor.Clip),actor.Position,actor.Rotation);
    }
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
        Actor actor = ActorOf(id);
        if (actor.Pending != null)
            return null;

        GrenadeGesturePlan gesture = GrenadeGesturePlanner.Plan(
            actor.Binding, catalog.Poses, actor.Position, actor.Rotation,
            command, tick);
        actor.Clip = gesture.WindupClip;
        actor.ClipStarted = tick;
        actor.Pending = new ScheduledGrenadeLaunch(id, gesture.Target,
            gesture.Right, gesture.LaunchTick,
            actor.Definition.Weapon.SourceId,
            actor.Definition.WeaponUpgrade!.Value);
        actor.Pose = Place(catalog.Poses.Sample(actor.Clip, 0, false),
            actor.Position, actor.Rotation);
        return actor.Pending;
    }
    internal IReadOnlyList<ScheduledGrenadeLaunch> Advance(ulong tick,Func<string,RifleActorLocation>? locate=null)
    {
        if (lastTick.HasValue && tick != lastTick.Value + 1)
            throw new InvalidDataException(
                "Grenade animation requires consecutive ticks.");
        lastTick = tick;

        var dueLaunches = new List<ScheduledGrenadeLaunch>();
        foreach (Actor actor in actors)
        {
            if (locate != null)
                UpdateActorLocation(actor,
                    locate(actor.Definition.PlayerId), tick);

            bool loop = Loops(actor.Clip);
            double seconds = (tick - actor.ClipStarted) /
                (double)MatchManifest.TickRate;
            actor.Pose = Place(catalog.Poses.Sample(actor.Clip,
                seconds, loop), actor.Position, actor.Rotation);

            // Sample the windup before changing to the M320 fire clip. The
            // launch muzzle comes from that exact source animation frame.
            if (actor.Pending is { } pending && pending.LaunchTick <= tick)
            {
                dueLaunches.Add(pending);
                actor.Pending = null;
                if (!actor.Binding.Swipe)
                {
                    actor.Clip = pending.Right
                        ? "player_fire_left_grenadelauncher"
                        : "player_fire_right_grenadelauncher";
                    actor.ClipStarted = tick;
                }
            }
            else if (actor.Pending == null && !loop &&
                seconds >= catalog.Poses.Duration(actor.Clip))
            {
                actor.Clip = actor.Binding.Swipe
                    ? "grenade_idle" : "grenadelauncher_idle";
                actor.ClipStarted = tick;
                actor.Pose = Place(catalog.Poses.Sample(actor.Clip, 0,
                    true), actor.Position, actor.Rotation);
            }
        }
        return dueLaunches;
    }

    private void UpdateActorLocation(Actor actor,
        RifleActorLocation location, ulong tick)
    {
        if (!PlayerHitbox.Finite(location.Position) ||
            location.CoverIndex < 0 ||
            location.CoverIndex >= map.Covers.Count ||
            map.Covers[location.CoverIndex].Fraction !=
                actor.Definition.Fraction ||
            (location.Moving && actor.Pending != null))
            throw new InvalidDataException(
                "Invalid moving grenade player authority.");

        if (location.Moving)
        {
            Vector3 direction = location.Position - actor.Position;
            direction.Y = 0;
            if (direction.LengthSquared() > 1e-10f)
                actor.Rotation = Quaternion.CreateFromAxisAngle(
                    Vector3.UnitY, MathF.Atan2(direction.X, direction.Z));
            if (!actor.Moving)
            {
                actor.Clip = actor.Binding.Swipe
                    ? "grenade_run" : "run_grenadelauncher";
                actor.ClipStarted = tick;
            }
        }
        else if (actor.Moving)
        {
            actor.Clip = actor.Binding.Swipe
                ? "grenade_idle" : "grenadelauncher_idle";
            actor.ClipStarted = tick;
            actor.Rotation = map.Covers[location.CoverIndex].Rotation;
        }
        else if (actor.Pending == null && Loops(actor.Clip))
        {
            actor.Rotation = map.Covers[location.CoverIndex].Rotation;
        }

        actor.Moving = location.Moving;
        actor.Position = location.Position;
    }
    internal Vector3 Muzzle(ScheduledGrenadeLaunch launch)
    {
        ArgumentNullException.ThrowIfNull(launch);
        Actor actor = ActorOf(launch.Owner);
        if (launch.WeaponSourceId != actor.Binding.SourceId ||
            launch.Upgrade != actor.Definition.WeaponUpgrade)
            throw new InvalidDataException(
                "Grenade launch differs from the host weapon binding.");

        // The recovered swipe throw's right-side branch uses the shared
        // left-hand origin. All other branches use the equipped weapon muzzle.
        return launch.Right && actor.Binding.Swipe
            ? actor.Pose.Left.Position
            : actor.Pose.Right[launch.WeaponSourceId].Position;
    }
    internal ShotCollision? Trace(string owner,Vector3 origin,Vector3 direction,float range,uint mask)
    {
        var players = actors.Select(actor => new CollisionPlayer(
            actor.Definition.PlayerId, actor.Pose.Collision,
            actor.Definition.Fraction == 1 ? 23 : 22));
        var world = new ShotCollisionWorld(map, players,
            dynamicColliderEnabled, indexedColliderEnabled,
            runtimeLayer, dynamicTargets);
        return world.Raycast(owner, origin, direction, range, mask);
    }
    internal bool HelicopterCanSee(HelicopterSightRay ray)
    {
        if(!PlayerHitbox.Finite(ray.Origin)||!PlayerHitbox.Finite(ray.Direction)||
           !float.IsFinite(ray.Range)||ray.Range is <=0 or >10000||
           ray.LayerMask!=HelicopterTurretSightRay.SourceLayerMask)
            throw new InvalidDataException("Invalid grenade-mode Helicopter sight ray.");
        if(ray.Direction==Vector3.Zero)return true;
        if(Math.Abs(ray.Direction.LengthSquared()-1)>.001f)
            throw new InvalidDataException("Grenade-mode Helicopter sight direction is not normalized.");
        if(map.Raycast(ray.Origin,ray.Direction,ray.Range,ray.LayerMask,
            dynamicColliderEnabled,indexedColliderEnabled,runtimeLayer)!=null)return false;
        if(visibilityTargets==null)
            throw new InvalidDataException("Grenade-mode Helicopter visibility lacks host targets.");
        foreach(var collider in visibilityTargets())
        {
            if(collider==null||collider.EntityId==0||collider.Layer is <0 or >31||collider.Hitbox==null)
                throw new InvalidDataException("Invalid grenade-mode Helicopter blocker.");
            if((ray.LayerMask&(1u<<collider.Layer))!=0&&
               collider.Hitbox.Raycast(ray.Origin,ray.Direction,ray.Range).HasValue)return false;
        }
        return true;
    }
    private Actor ActorOf(string id)=>actors.Single(x=>x.Definition.PlayerId==id);
    private static bool Loops(string clip)=>clip is "grenade_idle" or "grenade_run" or "grenadelauncher_idle" or "run_grenadelauncher";
    private static GrenadePoseFrame Place(GrenadePoseFrame frame,Vector3 position,Quaternion rotation)=>new(frame.Seconds,
        frame.Collision.Place(position,rotation),frame.Left.Place(position,rotation),
        frame.Right.ToDictionary(x=>x.Key,x=>x.Value.Place(position,rotation),StringComparer.Ordinal));
}

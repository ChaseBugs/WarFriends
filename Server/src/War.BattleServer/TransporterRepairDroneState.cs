using System.Numerics;

namespace War.BattleServer;

internal sealed record TransporterRepairDroneSnapshot(int PathIndex,Vector3 Position,float Health,
    float MaximumHealth,bool Active,ulong RespawnTick,int WaypointIndex,bool Forward);

/// <summary>Fixed-tick authority for the recovered Transporter MiniDrone/DroneSteering pair.</summary>
internal sealed class TransporterRepairDroneState
{
    private readonly RepairDronePath path;
    private readonly RepairDronePrefabBinding binding;
    private readonly float healRatio;
    private Vector3 velocity;
    private int waypoint;
    private bool forward;
    private int stayTicks;
    private int cornerDelayTicks;
    private ulong nextHealTick;
    internal int PathIndex {get;}
    internal Vector3 Position {get;private set;}
    internal float MaximumHealth {get;}
    internal float Health {get;private set;}
    internal bool Active {get;private set;}=true;
    internal ulong RespawnTick {get;private set;}

    internal TransporterRepairDroneState(int pathIndex,RepairDronePath path,
        RepairDronePrefabBinding binding,TransporterRepairDroneStats stats,
        Vector3 vehiclePosition,Vector3 vehicleFacing,ulong spawnTick)
    {
        if(pathIndex is <0 or >1||path.Waypoints.Count!=7||!float.IsFinite(stats.HealRatioPerSecond)||
           stats.HealRatioPerSecond<=0||!float.IsFinite(stats.MaximumHealth)||stats.MaximumHealth<=0)
            throw new InvalidDataException("Invalid Transporter repair-drone spawn.");
        PathIndex=pathIndex;this.path=path;this.binding=binding;healRatio=stats.HealRatioPerSecond;
        MaximumHealth=stats.MaximumHealth;Health=MaximumHealth;forward=binding.InitialForward;
        Position=WorldPoint(0,vehiclePosition,vehicleFacing);
        nextHealTick=checked(spawnTick+(ulong)SecondsToTicks(binding.HealIntervalSeconds));
    }

    internal float Advance(Vector3 vehiclePosition,Vector3 vehicleFacing,ulong tick,Func<float> random)
    {
        ArgumentNullException.ThrowIfNull(random);
        if(!Active)
        {
            if(tick<RespawnTick)return 0;
            Active=true;Health=MaximumHealth;RespawnTick=0;waypoint=0;forward=binding.InitialForward;
            velocity=Vector3.Zero;stayTicks=0;cornerDelayTicks=0;
            Position=WorldPoint(0,vehiclePosition,vehicleFacing);
            nextHealTick=checked(tick+(ulong)SecondsToTicks(binding.HealIntervalSeconds));
            return 0;
        }
        Vector3 target=WorldPoint(waypoint,vehiclePosition,vehicleFacing);
        if(Vector3.Distance(Position,target)<path.Radius)
        {
            int required=SecondsToTicks(path.Waypoints[waypoint].StayTime);
            if(stayTicks==0)cornerDelayTicks=SecondsToTicks(binding.CornerDelayTime);
            if(required>0&&stayTicks<required)stayTicks++;
            else
            {
                stayTicks=0;
                float roll=random();
                if(!float.IsFinite(roll)||roll<0||roll>=1)
                    throw new InvalidDataException("Invalid repair-drone random roll.");
                if(roll<.1f)forward=!forward;
                if(forward)waypoint=waypoint<path.Waypoints.Count-1?waypoint+1:binding.Loop?0:waypoint;
                else waypoint=waypoint>0?waypoint-1:binding.Loop?path.Waypoints.Count-1:waypoint;
                target=WorldPoint(waypoint,vehiclePosition,vehicleFacing);
            }
        }
        Vector3 steering=Vector3.Zero;
        if(cornerDelayTicks>0)cornerDelayTicks--;
        else
        {
            Vector3 delta=target-Position;float distance=delta.Length();
            if(distance>1e-8f)
            {
                Vector3 desired=delta/distance;
                float dt=1f/MatchManifest.TickRate;
                desired*=distance<binding.BreakDistance?
                    binding.BreakSpeed*dt*(distance/binding.BreakDistance):binding.Speed*dt;
                steering=(desired-velocity)/binding.Mass;
            }
        }
        velocity+=steering;Position+=velocity;
        if(!PlayerHitbox.Finite(Position)||!PlayerHitbox.Finite(velocity))
            throw new InvalidDataException("Repair-drone steering left the finite domain.");
        return TakeHeal(tick);
    }

    internal bool ApplyDamage(float damage,ulong tick,Func<float> random)
    {
        ArgumentNullException.ThrowIfNull(random);
        if(!float.IsFinite(damage)||damage<=0||damage>10_000_000)
            throw new ArgumentOutOfRangeException(nameof(damage));
        if(!Active)return false;
        Health=Math.Max(0,Health-damage);
        if(Health>0)return true;
        float roll=random();
        if(!float.IsFinite(roll)||roll<0||roll>=1)throw new InvalidDataException("Invalid repair-drone respawn roll.");
        Active=false;velocity=Vector3.Zero;
        float seconds=binding.RespawnMinimumSeconds+
            (binding.RespawnMaximumSeconds-binding.RespawnMinimumSeconds)*roll;
        RespawnTick=checked(tick+(ulong)SecondsToTicks(seconds));
        return true;
    }

    internal TransporterRepairDroneSnapshot Snapshot()=>new(PathIndex,Position,Health,MaximumHealth,
        Active,RespawnTick,waypoint,forward);

    private float TakeHeal(ulong tick)
    {
        if(tick<nextHealTick)return 0;
        nextHealTick=checked(tick+(ulong)SecondsToTicks(binding.HealIntervalSeconds));
        return healRatio;
    }

    private Vector3 WorldPoint(int index,Vector3 vehiclePosition,Vector3 vehicleFacing)
    {
        if(!PlayerHitbox.Finite(vehiclePosition)||!PlayerHitbox.Finite(vehicleFacing))
            throw new InvalidDataException("Invalid repair-drone vehicle pose.");
        vehicleFacing.Y=0;
        if(vehicleFacing.LengthSquared()<1e-10f)throw new InvalidDataException("Repair drone has no vehicle facing.");
        float yaw=MathF.Atan2(vehicleFacing.X,vehicleFacing.Z);
        return vehiclePosition+Vector3.Transform(path.Waypoints[index].Position,
            Quaternion.CreateFromAxisAngle(Vector3.UnitY,yaw));
    }

    private static int SecondsToTicks(float seconds)
    {
        if(!float.IsFinite(seconds)||seconds<0||seconds>3600)throw new InvalidDataException("Invalid repair-drone time.");
        return checked((int)MathF.Ceiling(seconds*MatchManifest.TickRate));
    }
}

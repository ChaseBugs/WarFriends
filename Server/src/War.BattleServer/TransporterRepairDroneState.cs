using System.Numerics;

namespace War.BattleServer;

internal sealed record TransporterRepairDroneSnapshot(int PathIndex,Vector3 Position,float Health,
    float MaximumHealth,bool Active,ulong RespawnTick,int WaypointIndex,bool Forward,Quaternion Rotation,
    bool Falling,bool Crashed);
internal sealed record TransporterRepairDroneAdvance(float HealRatio,bool Crashed);

/// <summary>Fixed-tick authority for the recovered Transporter MiniDrone/DroneSteering pair.</summary>
internal sealed class TransporterRepairDroneState
{
    private readonly RepairDronePath path;
    private readonly RepairDronePrefabBinding binding;
    private readonly float healRatio;
    private Vector3 velocity;
    private Vector3 fallVelocity;
    private float physicsRemainder;
    private int waypoint;
    private bool forward;
    private int stayTicks;
    private int cornerDelayTicks;
    private ulong nextHealTick;
    internal int PathIndex {get;}
    internal Vector3 Position {get;private set;}
    internal Quaternion Rotation {get;private set;}
    internal float MaximumHealth {get;}
    internal float Health {get;private set;}
    internal bool Active {get;private set;}=true;
    internal bool Falling {get;private set;}
    internal bool Crashed {get;private set;}
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
        Rotation=VehicleYaw(vehicleFacing)*path.Rotation;
        nextHealTick=checked(spawnTick+(ulong)SecondsToTicks(binding.HealIntervalSeconds));
    }

    internal TransporterRepairDroneAdvance Advance(Vector3 vehiclePosition,Vector3 vehicleFacing,ulong tick,
        Func<float> random,Func<Vector3,Vector3,Quaternion,bool>? contact=null)
    {
        ArgumentNullException.ThrowIfNull(random);
        if(!Active)
        {
            bool crashed=false;
            if(Falling)
            {
                physicsRemainder+=1f/MatchManifest.TickRate;
                const float fixedStep=.02f;
                while(physicsRemainder+1e-7f>=fixedStep&&Falling)
                {
                    physicsRemainder-=fixedStep;
                    // Recovered Rigidbody: mass 1, drag 1, gravity -9.81. DroneSteering
                    // adds up*8 + its final per-frame steering velocity / dt * 2.
                    Vector3 force=Vector3.UnitY*8f+velocity/fixedStep*2f;
                    fallVelocity+=(force+new Vector3(0,-9.81f,0))*fixedStep;
                    fallVelocity/=1f+fixedStep;
                    Position+=fallVelocity*fixedStep;
                    if(!PlayerHitbox.Finite(Position)||!PlayerHitbox.Finite(fallVelocity))
                        throw new InvalidDataException("Repair-drone fall left the finite domain.");
                    Vector3 center=Position+Vector3.Transform(binding.ColliderCenter,Rotation);
                    if(contact?.Invoke(center,binding.ColliderSize,Rotation)==true)
                    {Falling=false;Crashed=true;fallVelocity=Vector3.Zero;crashed=true;}
                }
            }
            if(tick<RespawnTick)return new(0,crashed);
            Active=true;Health=MaximumHealth;RespawnTick=0;waypoint=0;forward=binding.InitialForward;
            Falling=false;Crashed=false;velocity=Vector3.Zero;fallVelocity=Vector3.Zero;physicsRemainder=0;
            stayTicks=0;cornerDelayTicks=0;
            Position=WorldPoint(0,vehiclePosition,vehicleFacing);
            Rotation=VehicleYaw(vehicleFacing)*path.Rotation;
            nextHealTick=checked(tick+(ulong)SecondsToTicks(binding.HealIntervalSeconds));
            return new(0,crashed);
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
        Vector3 outward=Position-WorldPathOrigin(vehiclePosition,vehicleFacing);outward.Y=0;
        if(outward.LengthSquared()>1e-10f)
        {
            float yaw=MathF.Atan2(outward.X,outward.Z);
            Rotation=Quaternion.Normalize(Quaternion.Slerp(Rotation,
                Quaternion.CreateFromAxisAngle(Vector3.UnitY,yaw),5f/MatchManifest.TickRate));
        }
        if(!PlayerHitbox.Finite(Position)||!PlayerHitbox.Finite(velocity))
            throw new InvalidDataException("Repair-drone steering left the finite domain.");
        return new(TakeHeal(tick),false);
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
        Active=false;Falling=true;Crashed=false;fallVelocity=Vector3.Zero;physicsRemainder=0;
        float seconds=binding.RespawnMinimumSeconds+
            (binding.RespawnMaximumSeconds-binding.RespawnMinimumSeconds)*roll;
        RespawnTick=checked(tick+(ulong)SecondsToTicks(seconds));
        return true;
    }

    internal TransporterRepairDroneSnapshot Snapshot()=>new(PathIndex,Position,Health,MaximumHealth,
        Active,RespawnTick,waypoint,forward,Rotation,Falling,Crashed);

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
        return vehiclePosition+Vector3.Transform(path.Waypoints[index].Position,VehicleYaw(vehicleFacing));
    }

    private Vector3 WorldPathOrigin(Vector3 vehiclePosition,Vector3 vehicleFacing)
        =>vehiclePosition+Vector3.Transform(path.Position,VehicleYaw(vehicleFacing));

    private static Quaternion VehicleYaw(Vector3 facing)
    {
        facing.Y=0;
        if(!PlayerHitbox.Finite(facing)||facing.LengthSquared()<1e-10f)
            throw new InvalidDataException("Repair drone has no vehicle facing.");
        return Quaternion.CreateFromAxisAngle(Vector3.UnitY,MathF.Atan2(facing.X,facing.Z));
    }

    private static int SecondsToTicks(float seconds)
    {
        if(!float.IsFinite(seconds)||seconds<0||seconds>3600)throw new InvalidDataException("Invalid repair-drone time.");
        return checked((int)MathF.Ceiling(seconds*MatchManifest.TickRate));
    }
}

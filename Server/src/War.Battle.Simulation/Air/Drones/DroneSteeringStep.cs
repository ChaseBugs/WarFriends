using System.Numerics;
namespace War.BattleServer;

// DroneSteering.Steer plus Update integration; waypoint decisions/orientation are separate.
public static class DroneSteeringStep
{
    public readonly record struct Result(Vector3 Position,Vector3 Velocity,Vector3 Steering);
    public static Result Advance(Vector3 position,Vector3 velocity,Vector3 target,
        float time,float deltaTime,float pointReachedTime,float cornerDelayTime,
        float speed,float mass,float breakDistance,float breakSpeed)
    {
        if(!Finite(position)||!Finite(velocity)||!Finite(target)||
           !float.IsFinite(time)||time<0||!float.IsFinite(deltaTime)||deltaTime<=0||deltaTime>.2f||
           !float.IsFinite(pointReachedTime)||pointReachedTime<0||pointReachedTime>time||
           !float.IsFinite(cornerDelayTime)||cornerDelayTime<0||cornerDelayTime>60||
           !float.IsFinite(speed)||speed<=0||speed>20||!float.IsFinite(mass)||mass<=0||mass>10000||
           !float.IsFinite(breakDistance)||breakDistance<=0||breakDistance>100||
           !float.IsFinite(breakSpeed)||breakSpeed<0||breakSpeed>20)
            throw new InvalidDataException("Invalid Drone steering authority.");
        float deadline=pointReachedTime+cornerDelayTime;
        if(!float.IsFinite(deadline)||(cornerDelayTime>0&&deadline==pointReachedTime))
            throw new InvalidDataException("Drone corner deadline overflow or lost precision.");
        Vector3 steering=Vector3.Zero;
        if(time>=deadline)
        {
            Vector3 delta=target-position;float distance=delta.Length();
            if(!float.IsFinite(distance))throw new InvalidDataException("Drone distance overflow.");
            // Unity Vector3.normalized uses the 1e-5 magnitude threshold.
            Vector3 desired=distance>1e-5f?delta/distance:Vector3.Zero;
            desired*=distance<breakDistance?breakSpeed*deltaTime*(distance/breakDistance):speed*deltaTime;
            steering=(desired-velocity)/mass;
        }
        Vector3 nextVelocity=velocity+steering,nextPosition=position+nextVelocity;
        if(!Finite(steering)||!Finite(nextVelocity)||!Finite(nextPosition))
            throw new InvalidDataException("Drone steering produced nonfinite motion.");
        return new(nextPosition,nextVelocity,steering);
    }
    private static bool Finite(Vector3 v)=>float.IsFinite(v.X)&&float.IsFinite(v.Y)&&float.IsFinite(v.Z);
}

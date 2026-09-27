using System.Numerics;
namespace War.BattleServer;

internal sealed record DroneRigidPose(Vector3 Root,Quaternion Rotation);
internal static class DroneRigidMotion
{
    internal static (Vector3 Velocity,Vector3 AngularVelocity) AdvanceVelocities(Vector3 velocity,Vector3 angularVelocity)
    {
        if(!PlayerHitbox.Finite(velocity)||!PlayerHitbox.Finite(angularVelocity))
            throw new InvalidDataException("Invalid Drone velocity authority.");
        velocity=(velocity+new Vector3(0,-9.81f,0)*.02f)*.98f;
        angularVelocity*=.999f;
        float speed=angularVelocity.Length();
        if(speed>7)angularVelocity*=7/speed;
        if(!PlayerHitbox.Finite(velocity)||!PlayerHitbox.Finite(angularVelocity))
            throw new InvalidDataException("Drone velocity arithmetic overflow.");
        return(velocity,angularVelocity);
    }
    // Post-force velocities, world angular velocity. Integrate around source COM.
    internal static DroneRigidPose Integrate(DroneBodyMass mass,Vector3 root,Quaternion rotation,
        Vector3 velocity,Vector3 angularVelocity)
    {
        ArgumentNullException.ThrowIfNull(mass);
        if(!PlayerHitbox.Finite(mass.CenterOfMass)||!PlayerHitbox.Finite(root)||!PlayerHitbox.Finite(velocity)||
           !PlayerHitbox.Finite(angularVelocity)||!float.IsFinite(rotation.LengthSquared())||
           Math.Abs(rotation.LengthSquared()-1)>.0001f)
            throw new InvalidDataException("Invalid Drone rigid-motion authority.");
        var center=root+Vector3.Transform(mass.CenterOfMass,rotation);
        center+=velocity*.02f;
        float speed=angularVelocity.Length();
        if(speed>0)
            rotation=Quaternion.Normalize(Quaternion.CreateFromAxisAngle(angularVelocity/speed,speed*.02f)*rotation);
        root=center-Vector3.Transform(mass.CenterOfMass,rotation);
        if(!PlayerHitbox.Finite(root))throw new InvalidDataException("Drone rigid-motion arithmetic overflow.");
        return new(root,rotation);
    }
}

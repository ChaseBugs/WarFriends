using System.Numerics;
namespace War.BattleServer;

internal sealed class DroneImpulseResponse
{
    private readonly DroneBodyMass mass;
    private readonly Matrix4x4 inverseInertia;
    internal DroneImpulseResponse(DroneColliderCatalog geometry)
        :this(DroneMassProperties.Compute(geometry)){}
    internal DroneImpulseResponse(DroneBodyMass bodyMass)
    {
        ArgumentNullException.ThrowIfNull(bodyMass);
        var t=bodyMass.Inertia;
        float[] entries={t.M11,t.M12,t.M13,t.M14,t.M21,t.M22,t.M23,t.M24,
            t.M31,t.M32,t.M33,t.M34,t.M41,t.M42,t.M43,t.M44};
        if(!PlayerHitbox.Finite(bodyMass.CenterOfMass)||entries.Any(v=>!float.IsFinite(v))||
           t.M14!=0||t.M24!=0||t.M34!=0||t.M41!=0||t.M42!=0||t.M43!=0||t.M44!=1||
           Math.Abs(t.M12-t.M21)>.000001f||Math.Abs(t.M13-t.M31)>.000001f||Math.Abs(t.M23-t.M32)>.000001f||
           t.M11<=0||t.M11*t.M22-t.M12*t.M21<=0||t.GetDeterminant()<=0)
            throw new InvalidDataException("Invalid Drone body mass authority.");
        mass=bodyMass;
        if(!Matrix4x4.Invert(mass.Inertia,out inverseInertia))
            throw new InvalidDataException("Singular Drone inertia authority.");
    }
    internal (Vector3 Velocity,Vector3 AngularVelocity) Apply(Vector3 root,Quaternion rotation,
        Vector3 velocity,Vector3 angularVelocity,Vector3 impulse,Vector3 worldPoint)
    {
        if(!PlayerHitbox.Finite(root)||!PlayerHitbox.Finite(velocity)||!PlayerHitbox.Finite(angularVelocity)||
           !PlayerHitbox.Finite(impulse)||!PlayerHitbox.Finite(worldPoint)||
           !float.IsFinite(rotation.LengthSquared())||Math.Abs(rotation.LengthSquared()-1)>.0001f)
            throw new InvalidDataException("Invalid Drone impulse authority.");
        var center=root+Vector3.Transform(mass.CenterOfMass,rotation);
        var torque=Vector3.Transform(Vector3.Cross(worldPoint-center,impulse),Quaternion.Conjugate(rotation));
        var angularChange=Vector3.Transform(Vector3.TransformNormal(torque,inverseInertia),rotation);
        velocity+=impulse;angularVelocity+=angularChange; // Recovered mass is one.
        if(!PlayerHitbox.Finite(velocity)||!PlayerHitbox.Finite(angularVelocity))
            throw new InvalidDataException("Drone impulse arithmetic overflow.");
        return(velocity,angularVelocity);
    }
    internal Vector3 PointVelocity(Vector3 root,Quaternion rotation,Vector3 velocity,
        Vector3 angularVelocity,Vector3 worldPoint)
    {
        // Reuse the impulse boundary's validation without changing state.
        _=Apply(root,rotation,velocity,angularVelocity,Vector3.Zero,worldPoint);
        var center=root+Vector3.Transform(mass.CenterOfMass,rotation);
        var result=velocity+Vector3.Cross(angularVelocity,worldPoint-center);
        if(!PlayerHitbox.Finite(result))throw new InvalidDataException("Drone point velocity overflow.");
        return result;
    }
    internal float FrictionVelocityMultiplier(Vector3 root,Quaternion rotation,Vector3 worldPoint,Vector3 tangent)
        => .8f*ContactVelocityMultiplier(root,rotation,worldPoint,tangent);

    internal float ContactVelocityMultiplier(Vector3 root,Quaternion rotation,Vector3 worldPoint,Vector3 tangent)
    {
        if(!PlayerHitbox.Finite(tangent)||Math.Abs(tangent.LengthSquared()-1)>.0001f)
            throw new InvalidDataException("Invalid unit friction tangent.");
        var delta=Apply(root,rotation,Vector3.Zero,Vector3.Zero,tangent,worldPoint);
        float response=Vector3.Dot(tangent,PointVelocity(root,rotation,delta.Velocity,delta.AngularVelocity,worldPoint));
        if(!float.IsFinite(response)||response<=0)throw new InvalidDataException("Invalid friction effective mass.");
        return 1f/response;
    }
}

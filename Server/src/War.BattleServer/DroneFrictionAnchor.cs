using System.Numerics;
namespace War.BattleServer;

internal readonly record struct PreparedFrictionAxis(Vector3 Tangent,float VelocityMultiplier,float Bias,float TargetVelocity);

// Static-map anchor preparation. Solver velocity inputs must be deltas from the
// initial velocity used here, as in PhysX's solver-body representation.
internal static class DroneFrictionAnchor
{
    internal static PreparedFrictionAxis Prepare(DroneImpulseResponse response,Vector3 root,Quaternion rotation,
        Vector3 initialVelocity,Vector3 initialAngularVelocity,Vector3 bodyAnchor,Vector3 mapAnchor,
        Vector3 tangent,Vector3 surfaceTargetVelocity,float timestep)
    {
        if(!PlayerHitbox.Finite(mapAnchor)||!PlayerHitbox.Finite(surfaceTargetVelocity)||
           !float.IsFinite(timestep)||timestep<=0||timestep>1)
            throw new InvalidDataException("Invalid friction anchor authority.");
        float multiplier=response.FrictionVelocityMultiplier(root,rotation,bodyAnchor,tangent);
        var initialPointVelocity=response.PointVelocity(root,rotation,initialVelocity,initialAngularVelocity,bodyAnchor);
        float bias=Vector3.Dot(tangent,bodyAnchor-mapAnchor)/timestep;
        float target=Vector3.Dot(tangent,surfaceTargetVelocity-initialPointVelocity);
        if(!float.IsFinite(bias)||!float.IsFinite(target))
            throw new InvalidDataException("Friction anchor preparation overflow.");
        return new(tangent,multiplier,bias,target);
    }
}

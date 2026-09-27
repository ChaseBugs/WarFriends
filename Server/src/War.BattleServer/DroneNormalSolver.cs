using System.Numerics;
namespace War.BattleServer;

internal readonly record struct DroneNormalPoint(Vector3 Point,Vector3 Normal,float Separation);
internal sealed record DroneNormalResult(DroneRigidPose Pose,Vector3 Velocity,Vector3 AngularVelocity,Vector3 Impulse);

// One position and one velocity pass, matching the recovered body's iteration
// counts. Static, zero-friction/zero-restitution contacts only; not live authority.
internal sealed class DroneNormalSolver
{
    private readonly DroneBodyMass mass;
    private readonly DroneImpulseResponse response;
    internal DroneNormalSolver(DroneColliderCatalog geometry)
    {mass=DroneMassProperties.Compute(geometry);response=new(geometry);}

    internal DroneNormalResult Solve(Vector3 root,Quaternion rotation,Vector3 velocity,Vector3 angularVelocity,
        IReadOnlyList<DroneNormalPoint> contacts)
    {
        ArgumentNullException.ThrowIfNull(contacts);
        if(contacts.Count>64)throw new InvalidDataException("Excessive Drone normal contact batch.");
        // Snapshot and prepare the complete batch before any solve. No caller state
        // is mutated, and a malformed later contact cannot publish a partial result.
        var points=contacts.ToArray();
        var initial=DroneRigidMotion.AdvanceVelocities(velocity,angularVelocity);
        _=response.PointVelocity(root,rotation,initial.Velocity,initial.AngularVelocity,root);
        var prepared=points.Select(c=>DroneNormalContact.Prepare(response,root,rotation,
            initial.Velocity,initial.AngularVelocity,c.Point,c.Normal,c.Separation,0,1e32f,.02f)).ToArray();
        var applied=new float[points.Length];
        var deltaVelocity=Vector3.Zero;var deltaAngular=Vector3.Zero;var impulse=Vector3.Zero;
        void Pass(bool biased)
        {
            for(int i=0;i<points.Length;i++)
            {
                var c=points[i];var p=prepared[i];
                float relative=Vector3.Dot(c.Normal,response.PointVelocity(root,rotation,deltaVelocity,deltaAngular,c.Point));
                var step=ContactNormalConstraint.Solve(applied[i],relative,p.VelocityMultiplier,
                    biased?p.BiasedError:p.UnbiasedError,float.MaxValue);
                var changed=response.Apply(root,rotation,deltaVelocity,deltaAngular,c.Normal*step.Delta,c.Point);
                deltaVelocity=changed.Velocity;deltaAngular=changed.AngularVelocity;
                impulse+=c.Normal*step.Delta;applied[i]=step.Impulse;
            }
        }
        Pass(true);
        var pose=DroneRigidMotion.Integrate(mass,root,rotation,initial.Velocity+deltaVelocity,initial.AngularVelocity+deltaAngular);
        Pass(false);
        return new(pose,initial.Velocity+deltaVelocity,initial.AngularVelocity+deltaAngular,impulse);
    }
}

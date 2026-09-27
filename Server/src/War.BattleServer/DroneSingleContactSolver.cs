using System.Numerics;
namespace War.BattleServer;

// First contact with one static zero-restitution shape. Persistent anchors and
// multi-contact patches are intentionally not accepted by this comparison kernel.
internal sealed class DroneSingleContactSolver
{
    private readonly DroneBodyMass mass;
    private readonly DroneImpulseResponse response;
    internal DroneSingleContactSolver(DroneColliderCatalog geometry)
    {mass=DroneMassProperties.Compute(geometry);response=new(geometry);}

    internal DroneNormalResult Solve(Vector3 root,Quaternion rotation,Vector3 velocity,Vector3 angularVelocity,
        MaterialContact contact)
    {
        var patch=ContactFrictionPatches.Correlate(new[]{contact},1).Single();
        if(patch.Material.Restitution!=0)throw new InvalidDataException("Unsupported contact restitution.");
        var initial=DroneRigidMotion.AdvanceVelocities(velocity,angularVelocity);
        var c=contact.Geometry;
        var normal=DroneNormalContact.Prepare(response,root,rotation,initial.Velocity,initial.AngularVelocity,
            c.Point,c.Normal,c.Separation,0,1e32f,.02f);
        var basis=ContactFrictionBasis.Prepare(c.Normal,initial.Velocity);
        var axes=new[]{basis.First,basis.Second}.Select(t=>DroneFrictionAnchor.Prepare(response,root,rotation,
            initial.Velocity,initial.AngularVelocity,c.Point,c.Point,t,Vector3.Zero,.02f)).ToArray();
        var deltaVelocity=Vector3.Zero;var deltaAngular=Vector3.Zero;var impulse=Vector3.Zero;
        float normalImpulse=0;var frictionImpulse=new float[2];
        void Apply(Vector3 value)
        {
            var result=response.Apply(root,rotation,deltaVelocity,deltaAngular,value,c.Point);
            deltaVelocity=result.Velocity;deltaAngular=result.AngularVelocity;impulse+=value;
        }
        void Pass(bool biased)
        {
            float relative=Vector3.Dot(c.Normal,response.PointVelocity(root,rotation,deltaVelocity,deltaAngular,c.Point));
            var n=ContactNormalConstraint.Solve(normalImpulse,relative,normal.VelocityMultiplier,
                biased?normal.BiasedError:normal.UnbiasedError,float.MaxValue);
            normalImpulse=n.Impulse;Apply(c.Normal*n.Delta);
            for(int i=0;i<axes.Length;i++)
            {
                var a=axes[i];
                relative=Vector3.Dot(a.Tangent,response.PointVelocity(root,rotation,deltaVelocity,deltaAngular,c.Point));
                var f=ContactFrictionConstraint.Solve(frictionImpulse[i],relative,a.TargetVelocity,biased?a.Bias:0,
                    a.VelocityMultiplier,normalImpulse,patch.Material.StaticFriction,patch.Material.DynamicFriction);
                frictionImpulse[i]=f.Impulse;Apply(a.Tangent*f.Delta);
            }
        }
        Pass(true);
        var pose=DroneRigidMotion.Integrate(mass,root,rotation,initial.Velocity+deltaVelocity,initial.AngularVelocity+deltaAngular);
        Pass(false);
        return new(pose,initial.Velocity+deltaVelocity,initial.AngularVelocity+deltaAngular,impulse);
    }
}

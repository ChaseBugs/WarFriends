using System.Numerics;
namespace War.BattleServer;

// Initial static, zero-restitution shape-pair contacts. Not live authority:
// persistent anchors and runtime threshold policy remain unverified.
internal sealed class DroneContactSolver
{
    private readonly DroneBodyMass mass;
    private readonly DroneImpulseResponse response;
    private Dictionary<int,List<(ContactMaterial Material,ContactFrictionCache Cache)>> caches=new();
    internal DroneContactSolver(DroneColliderCatalog geometry)
    {mass=DroneMassProperties.Compute(geometry);response=new(mass);}
    internal DroneNormalResult Solve(Vector3 root,Quaternion rotation,Vector3 velocity,Vector3 angularVelocity,
        IReadOnlyList<MaterialContact[]> shapePairs,float normalTolerance,float correlationDistance,float offsetThreshold,bool reuseCaches=false)
    {
        ArgumentNullException.ThrowIfNull(shapePairs);
        if(!float.IsFinite(normalTolerance)||normalTolerance<0||normalTolerance>1||
           !float.IsFinite(correlationDistance)||correlationDistance<0||correlationDistance>1||
           !float.IsFinite(offsetThreshold)||offsetThreshold<0||offsetThreshold>1)
            throw new InvalidDataException("Invalid contact solver thresholds.");
        if(shapePairs.Count>32||shapePairs.Any(p=>p==null)||shapePairs.Sum(p=>p.Length)>256)
            throw new InvalidDataException("Excessive Drone contact batch.");
        var initial=DroneRigidMotion.AdvanceVelocities(velocity,angularVelocity);
        _=response.PointVelocity(root,rotation,initial.Velocity,initial.AngularVelocity,root);
        var patches=shapePairs.SelectMany((p,index)=>ContactFrictionPatches.Correlate(p,normalTolerance)
            .Select(patch=>(Pair:index,Patch:patch))).ToArray();
        var normalStates=new List<(Vector3 Normal,ContactMaterial Material,DroneNormalPoint[] Points,
            PreparedNormalContact[] Prepared,float[] Applied,Vector3[] Anchors,PreparedFrictionAxis[] Axes,float[] Friction,
            int Pair,ContactFrictionCache Cache,bool[] Broken)>();
        foreach(var entry in patches)
        {
            var patch=entry.Patch;
            if(patch.Material.Restitution!=0)throw new InvalidDataException("Unsupported restitution.");
            var points=patch.Contacts.ToArray();
            var prepared=points.Select(c=>DroneNormalContact.Prepare(response,root,rotation,initial.Velocity,
                initial.AngularVelocity,c.Point,patch.Normal,c.Separation,0,1e32f,.02f)).ToArray();
            var anchors=ContactFrictionAnchors.Select(points,correlationDistance,offsetThreshold);
            ContactFrictionCache? cached=null;
            if(reuseCaches&&caches.TryGetValue(entry.Pair,out var candidates))
                cached=candidates.Where(c=>c.Material==patch.Material&&c.Cache.CanReuse(root,rotation,normalTolerance,correlationDistance)&&
                    Vector3.Dot(Vector3.Transform(c.Cache.BodyNormal,rotation),patch.Normal)>=normalTolerance)
                    .Select(c=>c.Cache).FirstOrDefault();
            // Initial reuse experiment retains two-anchor patches. One-anchor
            // growth and span-based rebuilding still need source binding.
            if(cached?.Anchors.Count!=2)cached=null;
            cached??=new ContactFrictionCache(root,rotation,patch.Normal,anchors,false);
            anchors=cached.Anchors.Select(a=>root+Vector3.Transform(a.BodyLocal,rotation)).ToArray();
            var basis=ContactFrictionBasis.Prepare(patch.Normal,initial.Velocity);
            var axes=anchors.SelectMany((a,index)=>new[]{basis.First,basis.Second}.Select(t=>DroneFrictionAnchor.Prepare(
                response,root,rotation,initial.Velocity,initial.AngularVelocity,a,cached.Anchors[index].MapWorld,t,Vector3.Zero,.02f))).ToArray();
            normalStates.Add((patch.Normal,patch.Material,points,prepared,new float[points.Length],anchors,axes,new float[axes.Length],
                entry.Pair,cached,new bool[1]));
        }
        var deltaVelocity=Vector3.Zero;var deltaAngular=Vector3.Zero;var impulse=Vector3.Zero;
        void Apply(Vector3 value,Vector3 point)
        {
            var changed=response.Apply(root,rotation,deltaVelocity,deltaAngular,value,point);
            deltaVelocity=changed.Velocity;deltaAngular=changed.AngularVelocity;impulse+=value;
        }
        void Pass(bool biased)
        {
            foreach(var patch in normalStates)
            {
                patch.Broken[0]=false; // PhysX writes the final iteration's break state.
                float total=0;
                for(int i=0;i<patch.Points.Length;i++)
                {
                    var c=patch.Points[i];var p=patch.Prepared[i];
                    float relative=Vector3.Dot(patch.Normal,response.PointVelocity(root,rotation,deltaVelocity,deltaAngular,c.Point));
                    var n=ContactNormalConstraint.Solve(patch.Applied[i],relative,p.VelocityMultiplier,
                        biased?p.BiasedError:p.UnbiasedError,float.MaxValue);
                    patch.Applied[i]=n.Impulse;total+=n.Impulse;Apply(patch.Normal*n.Delta,c.Point);
                }
                for(int i=0;i<patch.Axes.Length;i++)
                {
                    var a=patch.Axes[i];var point=patch.Anchors[i/2];
                    float relative=Vector3.Dot(a.Tangent,response.PointVelocity(root,rotation,deltaVelocity,deltaAngular,point));
                    var f=ContactFrictionConstraint.Solve(patch.Friction[i],relative,a.TargetVelocity,biased?a.Bias:0,
                        a.VelocityMultiplier,total,patch.Material.StaticFriction,patch.Material.DynamicFriction);
                    patch.Friction[i]=f.Impulse;Apply(a.Tangent*f.Delta,point);
                    patch.Broken[0]|=f.Broken;
                }
            }
        }
        Pass(true);
        var pose=DroneRigidMotion.Integrate(mass,root,rotation,initial.Velocity+deltaVelocity,initial.AngularVelocity+deltaAngular);
        Pass(false);
        if(reuseCaches)
            caches=normalStates.GroupBy(p=>p.Pair).ToDictionary(g=>g.Key,g=>g.Select(p=>
                (p.Material,p.Cache.WithBroken(p.Broken[0]))).ToList());
        return new(pose,initial.Velocity+deltaVelocity,initial.AngularVelocity+deltaAngular,impulse);
    }
}

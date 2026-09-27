using System.Numerics;
using System.Text.Json;
using War.BattleServer;

internal static class DroneFrictionControlTests
{
    internal static int Run(string directory,DroneColliderCatalog geometry)
    {
        using var document=JsonDocument.Parse(File.ReadAllBytes(Path.Combine(directory,"recovered-drone-zero-friction-control.json")));
        var root=document.RootElement;
        using var source=JsonDocument.Parse(File.ReadAllBytes(Path.Combine(directory,"recovered-drone-map-fall.json")));
        if(root.GetProperty("materialPolicy").GetString()!="zero-friction-control"||
           root.GetProperty("unityVersion").GetString()!="2018.3.0f2"||
           root.GetProperty("rows").GetArrayLength()!=10)
            throw new Exception("Wrong independent friction control dataset.");
        Vector3 Vec(JsonElement value)=>new(value[0].GetSingle(),value[1].GetSingle(),value[2].GetSingle());
        float maximum=0,maximumPreparedResidual=0,maximumTwoPhaseResidual=0;int count=0;
        var response=new DroneImpulseResponse(geometry);
        foreach(var row in root.GetProperty("rows").EnumerateArray())
        {
            foreach(var collider in row.GetProperty("bodyDynamics").GetProperty("colliders").EnumerateArray())
                if(collider.GetProperty("staticFriction").GetSingle()!=0||collider.GetProperty("dynamicFriction").GetSingle()!=0)
                    throw new Exception("Friction control body retains friction.");
            var callbacks=row.GetProperty("collisionCallbacks");int frame=callbacks[0].GetProperty("frame").GetInt32();
            var sourceRow=source.RootElement.GetProperty("rows").EnumerateArray().Single(r=>
                r.GetProperty("source").GetString()==row.GetProperty("source").GetString()&&
                r.GetProperty("fraction").GetInt32()==row.GetProperty("fraction").GetInt32()&&
                r.GetProperty("initialRotation")[3].GetSingle()==1);
            if(sourceRow.GetProperty("collisionCallbacks")[0].GetProperty("frame").GetInt32()!=frame)
                throw new Exception("Friction control changed sampled first-contact timing.");
            var before=Vec(row.GetProperty("frames")[frame-1].GetProperty("velocity"));
            var impulses=callbacks.EnumerateArray().Where(c=>c.GetProperty("frame").GetInt32()==frame)
                .Aggregate(Vector3.Zero,(sum,c)=>sum+Vec(c.GetProperty("impulse")));
            var predicted=DroneRigidMotion.AdvanceVelocities(before,Vector3.Zero).Velocity+impulses;
            var previousFrame=row.GetProperty("frames")[frame-1];
            var q=previousFrame.GetProperty("rotation");
            var orientation=new Quaternion(q[0].GetSingle(),q[1].GetSingle(),q[2].GetSingle(),q[3].GetSingle());
            var position=Vec(previousFrame.GetProperty("position"));
            var initial=DroneRigidMotion.AdvanceVelocities(before,Vec(previousFrame.GetProperty("angularVelocity")));
            var deltaVelocity=Vector3.Zero;var deltaAngular=Vector3.Zero;var computedImpulse=Vector3.Zero;
            var preparedContacts=new List<(Vector3 Point,Vector3 Normal,PreparedNormalContact Prepared,float Impulse)>();
            foreach(var callback in callbacks.EnumerateArray().Where(c=>c.GetProperty("frame").GetInt32()==frame))
            foreach(var contact in callback.GetProperty("contacts").EnumerateArray())
            {
                var point=Vec(contact.GetProperty("position"));var normal=Vec(contact.GetProperty("normal"));
                var prepared=DroneNormalContact.Prepare(response,position,orientation,initial.Velocity,initial.AngularVelocity,
                    point,normal,contact.GetProperty("separation").GetSingle(),0,1e32f,.02f);
                float relative=Vector3.Dot(normal,response.PointVelocity(position,orientation,deltaVelocity,deltaAngular,point));
                var step=ContactNormalConstraint.Solve(0,relative,prepared.VelocityMultiplier,prepared.BiasedError,float.MaxValue);
                var changed=response.Apply(position,orientation,deltaVelocity,deltaAngular,normal*step.Delta,point);
                deltaVelocity=changed.Velocity;deltaAngular=changed.AngularVelocity;computedImpulse+=normal*step.Delta;
                preparedContacts.Add((point,normal,prepared,step.Impulse));
            }
            float firstPassResidual=Vector3.Distance(computedImpulse,impulses);
            maximumPreparedResidual=Math.Max(maximumPreparedResidual,firstPassResidual);
            foreach(var contact in preparedContacts)
            {
                float relative=Vector3.Dot(contact.Normal,response.PointVelocity(position,orientation,
                    deltaVelocity,deltaAngular,contact.Point));
                var step=ContactNormalConstraint.Solve(contact.Impulse,relative,contact.Prepared.VelocityMultiplier,
                    contact.Prepared.UnbiasedError,float.MaxValue);
                var changed=response.Apply(position,orientation,deltaVelocity,deltaAngular,contact.Normal*step.Delta,contact.Point);
                deltaVelocity=changed.Velocity;deltaAngular=changed.AngularVelocity;computedImpulse+=contact.Normal*step.Delta;
            }
            float twoPhaseResidual=Vector3.Distance(computedImpulse,impulses);
            maximumTwoPhaseResidual=Math.Max(maximumTwoPhaseResidual,twoPhaseResidual);
            if(twoPhaseResidual>.00002f)
                throw new Exception("Prepared two-phase normal response differs from independent Unity reported impulse.");
            count++;
            Console.WriteLine("Drone normal phases: "+row.GetProperty("source").GetString()+" fraction "+
                row.GetProperty("fraction")+", contacts "+preparedContacts.Count+", first="+firstPassResidual+
                ", velocity-pass="+twoPhaseResidual);
            float residual=Vector3.Distance(predicted,Vec(row.GetProperty("frames")[frame].GetProperty("velocity")));
            if(residual>.00002f)throw new Exception("Zero-friction first-contact impulse fails measured momentum comparison.");
            maximum=Math.Max(maximum,residual);
            count++;
        }
        Console.WriteLine("Drone zero-friction impulse diagnostic: maximum velocity residual="+maximum+" (control only).");
        Console.WriteLine("Drone prepared normal first-pass diagnostic: maximum reported-impulse residual="+maximumPreparedResidual+
            " (recorded contacts; solver ordering/phases not verified).");
        Console.WriteLine("Drone prepared normal two-phase diagnostic: maximum reported-impulse residual="+maximumTwoPhaseResidual);
        return count;
    }
}

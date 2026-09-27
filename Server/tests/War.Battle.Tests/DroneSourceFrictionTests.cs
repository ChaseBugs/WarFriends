using System.Numerics;
using System.Text.Json;
using War.BattleServer;

internal static class DroneSourceFrictionTests
{
    internal static int Run(string directory,DroneColliderCatalog geometry)
    {
        using var document=JsonDocument.Parse(File.ReadAllBytes(Path.Combine(directory,"recovered-drone-map-fall.json")));
        if(document.RootElement.GetProperty("unityVersion").GetString()!="2018.3.0f2"||
           document.RootElement.GetProperty("materialPolicy").GetString()!="source-materials"||
           document.RootElement.GetProperty("rows").GetArrayLength()!=30)
            throw new Exception("Source-material contact oracle identity changed.");
        Vector3 Vec(JsonElement v)=>new(v[0].GetSingle(),v[1].GetSingle(),v[2].GetSingle());
        Quaternion Quat(JsonElement q)=>new(q[0].GetSingle(),q[1].GetSingle(),q[2].GetSingle(),q[3].GetSingle());
        int samples=0;float maximumVelocity=0,maximumAngular=0,maximumPosition=0;
        float observedMassAngular=0,observedImpulseAngular=0,solverAngularContribution=0;string worst="";
        float multiVelocity=0,multiAngular=0,multiRoot=0;int multiSamples=0;
        foreach(var row in document.RootElement.GetProperty("rows").EnumerateArray())
        {
            var callbacks=row.GetProperty("collisionCallbacks");int frame=callbacks[0].GetProperty("frame").GetInt32();
            var first=callbacks.EnumerateArray().Where(c=>c.GetProperty("frame").GetInt32()==frame).ToArray();
            var before=row.GetProperty("frames")[frame-1];var after=row.GetProperty("frames")[frame];
            var pairs=first.SelectMany(call=>call.GetProperty("contacts").EnumerateArray()).GroupBy(c=>
                (c.GetProperty("bodyCollider").GetString(),c.GetProperty("otherColliderIndex").GetInt32()))
                .Select(group=>group.Select(c=>new MaterialContact(new DroneNormalPoint(Vec(c.GetProperty("position")),
                    Vec(c.GetProperty("normal")),c.GetProperty("separation").GetSingle()),new ContactMaterial(.6f,.6f,0))).ToArray()).ToArray();
            var multi=new DroneContactSolver(geometry).Solve(Vec(before.GetProperty("position")),Quat(before.GetProperty("rotation")),
                Vec(before.GetProperty("velocity")),Vec(before.GetProperty("angularVelocity")),pairs,.999f,.025f,.04f);
            multiVelocity=Math.Max(multiVelocity,Vector3.Distance(multi.Velocity,Vec(after.GetProperty("velocity"))));
            multiAngular=Math.Max(multiAngular,Vector3.Distance(multi.AngularVelocity,Vec(after.GetProperty("angularVelocity"))));
            multiRoot=Math.Max(multiRoot,Vector3.Distance(multi.Pose.Root,Vec(after.GetProperty("position"))));multiSamples++;
            if(first.Length!=1||first[0].GetProperty("contacts").GetArrayLength()!=1)continue;
            var c=first[0].GetProperty("contacts")[0];var previous=row.GetProperty("frames")[frame-1];
            foreach(var name in new[]{"bodyMaterial","otherMaterial"})
            {
                var material=c.GetProperty(name);
                if(material.GetProperty("staticFriction").GetSingle()!=.6f||
                   material.GetProperty("dynamicFriction").GetSingle()!=.6f||
                   material.GetProperty("restitution").GetSingle()!=0||
                   material.GetProperty("frictionCombine").GetInt32()!=0||
                   material.GetProperty("restitutionCombine").GetInt32()!=0)
                    throw new Exception("Single-contact default-material evidence changed.");
            }
            var observed=row.GetProperty("frames")[frame];
            var result=new DroneSingleContactSolver(geometry).Solve(Vec(previous.GetProperty("position")),
                Quat(previous.GetProperty("rotation")),Vec(previous.GetProperty("velocity")),
                Vec(previous.GetProperty("angularVelocity")),new MaterialContact(new DroneNormalPoint(
                    Vec(c.GetProperty("position")),Vec(c.GetProperty("normal")),c.GetProperty("separation").GetSingle()),
                    new ContactMaterial(.6f,.6f,0)));
            float velocityError=Vector3.Distance(result.Velocity,Vec(observed.GetProperty("velocity")));
            float positionError=Vector3.Distance(result.Pose.Root,Vec(observed.GetProperty("position")));
            if(velocityError>.00002f||positionError>.00002f)
                throw new Exception("Single-contact source-friction linear/position response differs from Unity.");
            maximumVelocity=Math.Max(maximumVelocity,velocityError);
            float angularError=Vector3.Distance(result.AngularVelocity,Vec(observed.GetProperty("angularVelocity")));
            if(angularError>maximumAngular){maximumAngular=angularError;worst=row.GetProperty("source").GetString()+
                "/"+row.GetProperty("fraction")+"/"+frame;}
            var dynamics=row.GetProperty("bodyDynamics");
            var axes=Matrix4x4.CreateFromQuaternion(Quat(dynamics.GetProperty("inertiaTensorRotation")));
            var observedMass=new DroneBodyMass(Vec(dynamics.GetProperty("centerOfMass")),
                Matrix4x4.Transpose(axes)*Matrix4x4.CreateScale(Vec(dynamics.GetProperty("inertiaTensor")))*axes);
            var massControl=new DroneSingleContactSolver(observedMass).Solve(Vec(previous.GetProperty("position")),
                Quat(previous.GetProperty("rotation")),Vec(previous.GetProperty("velocity")),
                Vec(previous.GetProperty("angularVelocity")),new MaterialContact(new DroneNormalPoint(
                    Vec(c.GetProperty("position")),Vec(c.GetProperty("normal")),c.GetProperty("separation").GetSingle()),
                    new ContactMaterial(.6f,.6f,0)));
            observedMassAngular=Math.Max(observedMassAngular,Vector3.Distance(massControl.AngularVelocity,
                Vec(observed.GetProperty("angularVelocity"))));
            var initial=DroneRigidMotion.AdvanceVelocities(Vec(previous.GetProperty("velocity")),
                Vec(previous.GetProperty("angularVelocity")));
            var reconstructed=new DroneImpulseResponse(observedMass).Apply(Vec(previous.GetProperty("position")),
                Quat(previous.GetProperty("rotation")),initial.Velocity,initial.AngularVelocity,
                Vec(observed.GetProperty("velocity"))-initial.Velocity,Vec(c.GetProperty("position")));
            observedImpulseAngular=Math.Max(observedImpulseAngular,Vector3.Distance(reconstructed.AngularVelocity,
                Vec(observed.GetProperty("angularVelocity"))));
            solverAngularContribution=Math.Max(solverAngularContribution,Vector3.Distance(reconstructed.AngularVelocity,
                massControl.AngularVelocity));
            maximumPosition=Math.Max(maximumPosition,positionError);
            samples++;
        }
        Console.WriteLine("Drone source-friction single-contact diagnostic: samples="+samples+", velocity="+maximumVelocity+
            ", angular="+maximumAngular+", root="+maximumPosition+" (recorded contacts and materials; not live admission proof).");
        if(samples!=21)throw new Exception("Single-contact material coverage changed.");
        Console.WriteLine("Drone friction inertia control: measured-mass angular residual="+observedMassAngular+", worst analytic case="+worst);
        Console.WriteLine("Drone angular conservation control: observed-impulse/contact residual="+observedImpulseAngular+
            ", solver-versus-observed impulse angular contribution="+solverAngularContribution);
        Console.WriteLine("Drone multi-patch initial-contact diagnostic: samples="+multiSamples+", velocity="+multiVelocity+
            ", angular="+multiAngular+", root="+multiRoot+" (thresholds and callback pair order experimental).");
        return samples*2; // Material evidence and bounded linear/root response; angular remains diagnostic.
    }
}

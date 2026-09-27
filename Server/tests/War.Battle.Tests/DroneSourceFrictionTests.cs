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
        foreach(var row in document.RootElement.GetProperty("rows").EnumerateArray())
        {
            var callbacks=row.GetProperty("collisionCallbacks");int frame=callbacks[0].GetProperty("frame").GetInt32();
            var first=callbacks.EnumerateArray().Where(c=>c.GetProperty("frame").GetInt32()==frame).ToArray();
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
            maximumVelocity=Math.Max(maximumVelocity,Vector3.Distance(result.Velocity,Vec(observed.GetProperty("velocity"))));
            maximumAngular=Math.Max(maximumAngular,Vector3.Distance(result.AngularVelocity,Vec(observed.GetProperty("angularVelocity"))));
            maximumPosition=Math.Max(maximumPosition,Vector3.Distance(result.Pose.Root,Vec(observed.GetProperty("position"))));
            samples++;
        }
        Console.WriteLine("Drone source-friction single-contact diagnostic: samples="+samples+", velocity="+maximumVelocity+
            ", angular="+maximumAngular+", root="+maximumPosition+" (recorded contacts and materials; not live admission proof).");
        if(samples!=21)throw new Exception("Single-contact material coverage changed.");
        return samples;
    }
}

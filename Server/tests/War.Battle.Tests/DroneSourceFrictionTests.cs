using System.Numerics;
using System.Text.Json;
using War.BattleServer;

internal static class DroneSourceFrictionTests
{
    internal static int Run(string directory,DroneColliderCatalog geometry)
    {
        using var document=JsonDocument.Parse(File.ReadAllBytes(Path.Combine(directory,"recovered-drone-map-fall.json")));
        Vector3 Vec(JsonElement v)=>new(v[0].GetSingle(),v[1].GetSingle(),v[2].GetSingle());
        Quaternion Quat(JsonElement q)=>new(q[0].GetSingle(),q[1].GetSingle(),q[2].GetSingle(),q[3].GetSingle());
        int samples=0;float maximumVelocity=0,maximumAngular=0,maximumPosition=0;
        foreach(var row in document.RootElement.GetProperty("rows").EnumerateArray())
        {
            var callbacks=row.GetProperty("collisionCallbacks");int frame=callbacks[0].GetProperty("frame").GetInt32();
            var first=callbacks.EnumerateArray().Where(c=>c.GetProperty("frame").GetInt32()==frame).ToArray();
            if(first.Length!=1||first[0].GetProperty("contacts").GetArrayLength()!=1)continue;
            var c=first[0].GetProperty("contacts")[0];var previous=row.GetProperty("frames")[frame-1];
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
            ", angular="+maximumAngular+", root="+maximumPosition+" (default material assumed; not admission proof).");
        return 0;
    }
}

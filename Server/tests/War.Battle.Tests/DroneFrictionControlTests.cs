using System.Numerics;
using System.Text.Json;
using War.BattleServer;

internal static class DroneFrictionControlTests
{
    internal static int Run(string directory)
    {
        using var document=JsonDocument.Parse(File.ReadAllBytes(Path.Combine(directory,"recovered-drone-zero-friction-control.json")));
        var root=document.RootElement;
        using var source=JsonDocument.Parse(File.ReadAllBytes(Path.Combine(directory,"recovered-drone-map-fall.json")));
        if(root.GetProperty("materialPolicy").GetString()!="zero-friction-control"||
           root.GetProperty("unityVersion").GetString()!="2018.3.0f2"||
           root.GetProperty("rows").GetArrayLength()!=10)
            throw new Exception("Wrong independent friction control dataset.");
        Vector3 Vec(JsonElement value)=>new(value[0].GetSingle(),value[1].GetSingle(),value[2].GetSingle());
        float maximum=0;int count=0;
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
            float residual=Vector3.Distance(predicted,Vec(row.GetProperty("frames")[frame].GetProperty("velocity")));
            if(residual>.00002f)throw new Exception("Zero-friction first-contact impulse fails measured momentum comparison.");
            maximum=Math.Max(maximum,residual);
            count++;
        }
        Console.WriteLine("Drone zero-friction impulse diagnostic: maximum velocity residual="+maximum+" (control only).");
        return count;
    }
}

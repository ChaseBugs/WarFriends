using System.Numerics;
using System.Text.Json;
using War.BattleServer;

internal static class DroneFreeFallTests
{
    internal static int Run(string directory)
    {
        using var document=JsonDocument.Parse(File.ReadAllBytes(Path.Combine(directory,"recovered-drone-free-fall.json")));
        var root=document.RootElement;
        if(root.GetProperty("unityVersion").GetString()!="2018.3.0f2"||
           root.GetProperty("scenario").GetString()!="isolated-zero-velocity-free-fall"||
           root.GetProperty("fixedTimestep").GetSingle()!=.02f||
           root.GetProperty("drag").GetSingle()!=1||root.GetProperty("frames").GetArrayLength()!=101)
            throw new Exception("Drone free-fall oracle identity changed.");
        Vector3 Vec(JsonElement row)=>new(row[0].GetSingle(),row[1].GetSingle(),row[2].GetSingle());
        Vector3 position=new(0,100,0),velocity=Vector3.Zero;int count=0;
        foreach(var frame in root.GetProperty("frames").EnumerateArray())
        {
            if(frame.GetProperty("frame").GetInt32()!=count||
               Vector3.Distance(position,Vec(frame.GetProperty("position")))>.0001f||
               Vector3.Distance(velocity,Vec(frame.GetProperty("velocity")))>.00001f)
                throw new Exception("Drone free-fall differs from Unity frame "+count);
            count++;if(count<101)(position,velocity)=DroneFreeFall.Step(position,velocity);
        }
        return count;
    }
}

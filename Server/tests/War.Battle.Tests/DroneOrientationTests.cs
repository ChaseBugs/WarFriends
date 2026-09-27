using System.Numerics;
using War.BattleServer;
internal static class DroneOrientationTests
{
    internal static int Run(string directory)
    {
        int count=0;void Check(bool ok,string name){if(!ok)throw new Exception(name);count++;}
        var idle=new DroneOrientationState();idle.Advance(Vector3.Zero,Vector3.Zero,Vector3.Zero,1f/30,null);
        Check(idle.Rotation==Quaternion.Identity,"zero velocity/acceleration preserves identity bank");
        var heading=new DroneOrientationState();heading.Advance(Vector3.Zero,Vector3.Zero,Vector3.Zero,.2f,-Vector3.UnitX);
        Check(Vector3.Distance(Vector3.Transform(Vector3.UnitZ,heading.Rotation),Vector3.UnitX)<1e-5f,
            "source look heading points from target toward Drone");
        heading.Advance(Vector3.Zero,Vector3.Zero,Vector3.Zero,1f/30,null);
        Check(Vector3.Distance(Vector3.Transform(Vector3.UnitZ,heading.Rotation),Vector3.UnitX)<1e-5f,"missing target retains prior heading");
        var bank=new DroneOrientationState();bank.Advance(Vector3.Zero,Vector3.UnitZ,new(.001f,0,0),1f/30,null);
        Check(Math.Abs(bank.Rotation.LengthSquared()-1)<1e-5f&&bank.Rotation!=Quaternion.Identity,"source acceleration produces normalized retained bank");
        var prior=bank.Rotation;
        try{bank.Advance(Vector3.Zero,Vector3.UnitZ,Vector3.Zero,float.NaN,null);throw new Exception("invalid orientation clock accepted");}
        catch(InvalidDataException){Check(bank.Rotation==prior,"invalid orientation input leaves prior pose intact");}
        using var fixture=System.Text.Json.JsonDocument.Parse(File.ReadAllText(Path.Combine(directory,"unity-drone-orientation-reference.json")));
        Check(fixture.RootElement.GetProperty("version").GetInt32()==1&&
            fixture.RootElement.GetProperty("traces").GetArrayLength()==3,"complete Unity orientation fixture");
        Vector3 Vector(System.Text.Json.JsonElement v)=>new(v[0].GetSingle(),v[1].GetSingle(),v[2].GetSingle());
        foreach(var trace in fixture.RootElement.GetProperty("traces").EnumerateArray())
        {
            var state=new DroneOrientationState();int frame=0;float maximumError=0;
            Check(trace.GetProperty("frames").GetArrayLength()==180,"complete Unity retained-orientation trace");
            foreach(var row in trace.GetProperty("frames").EnumerateArray())
            {
                var target=row.GetProperty("lookTarget");
                state.Advance(Vector(row.GetProperty("position")),Vector(row.GetProperty("velocity")),
                    Vector(row.GetProperty("steering")),row.GetProperty("deltaTime").GetSingle(),
                    target.ValueKind==System.Text.Json.JsonValueKind.Null?null:Vector(target));
                var q=row.GetProperty("rotation");var expected=new Quaternion(q[0].GetSingle(),q[1].GetSingle(),q[2].GetSingle(),q[3].GetSingle());
                var actual=Quaternion.Normalize(state.Rotation);expected=Quaternion.Normalize(expected);
                float error=Math.Min((actual-expected).Length(),(actual+expected).Length());
                maximumError=Math.Max(maximumError,error);
                Check(error<.00001f,"Unity Drone orientation differs at scale "+trace.GetProperty("scale")+" frame "+frame+" error "+error);
                frame++;
            }
            Console.WriteLine("Drone orientation scale "+trace.GetProperty("scale")+" maximum quaternion error "+maximumError);
        }
        return count;
    }
}

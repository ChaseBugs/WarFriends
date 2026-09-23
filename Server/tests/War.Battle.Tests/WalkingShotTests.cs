using System.Numerics;
using System.Text.Json;
using Google.Protobuf;
using War.BattleServer;
using War.Protocol;

internal static class WalkingShotTests
{
    internal static int Run(string path)
    {
        using var doc=JsonDocument.Parse(File.ReadAllBytes(path));
        var root=doc.RootElement;
        var catalog=PlayerPoseCatalog.Load(Path.Combine(Path.GetDirectoryName(path)!,"recovered-player-poses.json"),root.GetProperty("sha256").GetString()!);
        static Vector3 V(JsonElement e)=>new(e[0].GetSingle(),e[1].GetSingle(),e[2].GetSingle());
        static Quaternion Q(JsonElement e)=>new(e[0].GetSingle(),e[1].GetSingle(),e[2].GetSingle(),e[3].GetSingle());
        int checks=0;
        var renderCases=new List<object>();
        using var poseDoc=JsonDocument.Parse(File.ReadAllBytes(Path.Combine(Path.GetDirectoryName(path)!,"recovered-player-poses.json")));
        var rootPosition=V(poseDoc.RootElement.GetProperty("position"));
        var rootRotation=Q(poseDoc.RootElement.GetProperty("rotation"));
        foreach(var row in root.GetProperty("cases").EnumerateArray())
        {
            var pose=catalog.SampleWalkingShot(row.GetProperty("run").GetString()!,row.GetProperty("runSeconds").GetDouble(),
                row.GetProperty("additiveSeconds").GetDouble(),row.GetProperty("weight").GetSingle());
            foreach(var part in row.GetProperty("parts").EnumerateArray())
            {
                var actual=pose.Collision.Parts.Single(p=>p.SourcePath==part.GetProperty("path").GetString());
                if(Vector3.Distance(actual.Center,V(part.GetProperty("center")))>.0003f)throw new Exception("Unity walking shot collider mismatch: "+row.GetProperty("run").GetString()+" weight "+row.GetProperty("weight").GetSingle());
                if(1-Math.Abs(Quaternion.Dot(actual.Rotation,Q(part.GetProperty("rotation"))))>.00001f)throw new Exception("Unity walking shot collider rotation mismatch");
                checks+=2;
            }
            foreach(var muzzle in row.GetProperty("muzzles").EnumerateArray())
            {
                var actual=pose.Muzzle(muzzle.GetProperty("id").GetString()!);
                if(Vector3.Distance(actual.Position,V(muzzle.GetProperty("position")))>.0003f)throw new Exception("Unity walking shot muzzle mismatch: "+row.GetProperty("run").GetString()+" weight "+row.GetProperty("weight").GetSingle());
                if(1-Math.Abs(Quaternion.Dot(actual.Rotation,Q(muzzle.GetProperty("rotation"))))>.00001f)throw new Exception("Unity walking shot muzzle rotation mismatch");
                checks+=2;
            }
            var run=row.GetProperty("run").GetString()!;
            var state=new BattlePlayerState {PlayerId=new string('a',32),PositionX=rootPosition.X,PositionY=rootPosition.Y,PositionZ=rootPosition.Z,
                RiflePose=RiflePoseProjection.Create(0,[new(new(run,.2,1,true),1)],rootRotation,Quaternion.Identity,null,
                    new(new("shootAdditive",.1,1,false),row.GetProperty("weight").GetSingle()))};
            var roundtrip=BattlePlayerState.Parser.ParseFrom(state.ToByteArray());
            if(roundtrip.RiflePose.UpperBodyLayer==null || roundtrip.RiflePose.UpperBodyLayer.Weight!=row.GetProperty("weight").GetSingle())
                throw new Exception("Walking-shot overlay lost on protobuf roundtrip.");
            var expected=catalog.SampleWalkingShot(run,.2,.1,row.GetProperty("weight").GetSingle(),Quaternion.Identity);
            renderCases.Add(new {player=JsonFormatter.Default.Format(roundtrip),
                parts=expected.Collision.Parts.Select(p=>new {path=p.SourcePath,center=new[]{p.Center.X,p.Center.Y,p.Center.Z}}).ToArray(),
                muzzles=row.GetProperty("muzzles").EnumerateArray().Select(m=>
                {var id=m.GetProperty("id").GetString()!;var muzzle=expected.Muzzle(id);return new {path=muzzle.SourcePath,position=new[]{muzzle.Position.X,muzzle.Position.Y,muzzle.Position.Z}};}).ToArray()});
            checks++;
        }
        string? fixture=Environment.GetEnvironmentVariable("WAR_WALKING_SHOT_RENDER_FIXTURE");
        if(!string.IsNullOrEmpty(fixture))File.WriteAllText(fixture,JsonSerializer.Serialize(new {sceneHash=root.GetProperty("sha256").GetString(),cases=renderCases}));
        return checks;
    }
}

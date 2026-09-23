using System.Numerics;
using System.Text.Json;
using War.BattleServer;

internal static class PlayerExplosionOverlapReferenceTests
{
    internal static int Run(string directory)
    {
        int checks=0,probes=0;
        void Check(bool valid,string name){if(!valid)throw new Exception(name);checks++;}
        using var doc=JsonDocument.Parse(File.ReadAllBytes(Path.Combine(directory,
            "unity-player-explosion-overlap-reference.json")));
        var root=doc.RootElement;
        using var manifest=JsonDocument.Parse(File.ReadAllBytes(Path.Combine(directory,"combat-content-manifest.json")));
        Check(root.GetProperty("client").GetString()=="1.4.0" &&
            root.GetProperty("source").GetString()=="Assets/Scenes/MainScene.unity" &&
            root.GetProperty("sha256").GetString()==manifest.RootElement.GetProperty("SceneRevision").GetString(),
            "Unity player explosion poses bind the pinned MainScene");
        var poses=root.GetProperty("poses");
        Check(poses.GetArrayLength()==9,"Unity audit covers three sampled frames of three source clips");
        using var exported=JsonDocument.Parse(File.ReadAllBytes(Path.Combine(directory,"recovered-player-poses.json")));
        var lengths=exported.RootElement.GetProperty("clips").EnumerateArray()
            .ToDictionary(c=>c.GetProperty("name").GetString()!,c=>c.GetProperty("length").GetDouble(),StringComparer.Ordinal);
        var catalog=BattleCombatContent.Load(Path.Combine(directory,"combat-content-manifest.json"));
        foreach(var pose in poses.EnumerateArray())
        {
            string name=pose.GetProperty("name").GetString()!;
            float time=pose.GetProperty("time").GetSingle();
            var shapes=pose.GetProperty("shapes").EnumerateArray().Select((source,index)=>
            {
                bool box=source.GetProperty("kind").GetString()=="Box";
                var rotation=source.GetProperty("rotation");
                return new PlayerHitbox("audit/"+index,(box?PlayerHitboxKind.Box:PlayerHitboxKind.Sphere),
                    1,Vector(source.GetProperty("center")),Vector(source.GetProperty("size")),
                    new Quaternion(rotation[0].GetSingle(),rotation[1].GetSingle(),
                        rotation[2].GetSingle(),rotation[3].GetSingle()),
                    source.GetProperty("radius").GetSingle(),Vector3.Zero,0,
                    transformPosition:Vector(source.GetProperty("transformPosition")));
            }).ToArray();
            Check(shapes.Length==2,"source gameplay rig has two initialized hit parts");
            if(time==0 || time==.5f || (name=="run" && time==.25f))
            {
                var host=catalog.Poses.SampleBlended(name,time*lengths[name],false,
                    name,time*lengths[name],false,0).Collision.Parts;
                Check(host.Count==2 && host.Select((part,index)=>
                    Vector3.Distance(part.TransformPosition,shapes[index].TransformPosition)<.0005f).All(ok=>ok),
                    "current source rig composes hit-part transform origins for "+name+" at "+time);
            }
            foreach(var probe in pose.GetProperty("probes").EnumerateArray())
            {
                Vector3 center=Vector(probe.GetProperty("center"));
                float radius=probe.GetProperty("radius").GetSingle();
                var expected=probe.GetProperty("hits").EnumerateArray().Select(x=>x.GetInt32()).ToArray();
                var order=probe.GetProperty("order").EnumerateArray().Select(x=>x.GetInt32()).ToArray();
                var actual=shapes.Select((shape,index)=>(shape,index))
                    .Where(x=>x.shape.OverlapsSphere(center,radius)).Select(x=>x.index).ToArray();
                Check(expected.SequenceEqual(actual),
                    "source player sphere overlap parity "+pose.GetProperty("name").GetString()+
                    " at "+pose.GetProperty("time").GetSingle()+" center "+center+" radius "+radius+
                    " expected "+string.Join(",",expected)+" actual "+string.Join(",",actual));
                Check(order.SequenceEqual(expected),"Unity returns the recovered body part before head when both overlap");
                probes++;
            }
        }
        Check(probes==180,"all 180 Unity player overlap probes compared");
        Console.WriteLine($"Unity player explosion overlap: {probes} source pose probes matched");
        return checks;
    }
    private static Vector3 Vector(JsonElement value)=>new(value[0].GetSingle(),value[1].GetSingle(),value[2].GetSingle());
}

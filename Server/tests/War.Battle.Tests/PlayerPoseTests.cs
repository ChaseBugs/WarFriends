using System.Numerics;
using System.Text.Json;
using System.Text.Json.Nodes;
using War.BattleServer;

internal static class PlayerPoseTests
{
    internal static int Run(string path, string sourceHash)
    {
        int count = 0;
        void Check(bool value, string name) { if (!value) throw new Exception(name); count++; }
        void Reject(Action action)
        {
            try { action(); } catch (Exception e) when (e is InvalidDataException or ArgumentException) { count++; return; }
            throw new Exception("Invalid pose accepted.");
        }
        var catalog = PlayerPoseCatalog.Load(path,sourceHash);
        count += RifleCoverTests.Run(catalog);
        Check(catalog.ClipNames.Count == 61, "complete rifle, shotgun, pistol-family, minigun, sniper and bazooka cover/run/idle clip set");
        using var doc = JsonDocument.Parse(File.ReadAllText(path));
        var rigNodes=doc.RootElement.GetProperty("rigNodes").EnumerateArray().ToArray();
        var rigParents=rigNodes.Select(n=>n.GetProperty("parent").GetInt32()).ToArray();
        var rigIndex=rigNodes.Select((n,i)=>(Name:n.GetProperty("path").GetString()!,Index:i)).ToDictionary(x=>x.Name,x=>x.Index);
        Vector3 V(JsonElement e) => new(e[0].GetSingle(),e[1].GetSingle(),e[2].GetSingle());
        int frames = 0;
        foreach (var clip in doc.RootElement.GetProperty("clips").EnumerateArray())
        {
            string name = clip.GetProperty("name").GetString()!;
            int index = 0;
            foreach (var frame in clip.GetProperty("frames").EnumerateArray())
            {
                var pose = catalog.Sample(name, Math.Min(index/30d,catalog.Duration(name)), false);
                var aimed=catalog.SampleAimed(name,Math.Min(index/30d,catalog.Duration(name)),false,
                    Quaternion.CreateFromAxisAngle(Vector3.UnitY,20*MathF.PI/180),Quaternion.CreateFromAxisAngle(Vector3.UnitX,-35*MathF.PI/180));
                Quaternion Q(JsonElement e)=>new(e[0].GetSingle(),e[1].GetSingle(),e[2].GetSingle(),e[3].GetSingle());
                var local=frame.GetProperty("rigLocals").EnumerateArray().Select(n=>new RigLocalTransform(V(n.GetProperty("position")),Q(n.GetProperty("rotation")),V(n.GetProperty("scale")))).ToArray();
                var rigWorld=RigLocalPose.Compose(rigParents,local);
                foreach (var expected in frame.GetProperty("aimedParts").EnumerateArray())
                {
                    var actual=aimed.Collision.Parts.Single(p=>p.SourcePath==expected.GetProperty("path").GetString());
                    Check(Vector3.Distance(actual.Center,V(expected.GetProperty("center")))<.0001f,"Unity aimed collider center parity");
                    Check(1-Math.Abs(Quaternion.Dot(actual.Rotation,Q(expected.GetProperty("rotation"))))<.00001f,"Unity aimed collider rotation parity");
                }
                foreach (var expected in frame.GetProperty("aimedMuzzles").EnumerateArray())
                {
                    var actual=aimed.Muzzle(expected.GetProperty("id").GetString()!);
                    Check(Vector3.Distance(actual.Position,V(expected.GetProperty("position")))<.0001f,"Unity aimed muzzle position parity");
                    Check(1-Math.Abs(Quaternion.Dot(actual.Rotation,Q(expected.GetProperty("rotation"))))<.00001f,"Unity aimed muzzle rotation parity");
                }
                int p = 0;
                foreach (var part in frame.GetProperty("parts").EnumerateArray())
                {
                    var hitbox = pose.Parts[p++];
                    Check(hitbox.Enabled && hitbox.Active, "InitPlayer enables hit parts");
                    foreach (var ray in part.GetProperty("rays").EnumerateArray())
                    {
                        var hit = hitbox.Raycast(V(ray.GetProperty("origin")), V(ray.GetProperty("direction")), 4);
                        Check(hit.HasValue == ray.GetProperty("hit").GetBoolean() && (!hit.HasValue || Math.Abs(hit.Value-ray.GetProperty("distance").GetSingle()) < 0.0002f), "animated Unity collider ray parity: " + name + " frame " + index);
                    }
                }
                foreach (var muzzle in frame.GetProperty("muzzles").EnumerateArray())
                {
                    string rifle=muzzle.GetProperty("id").GetString()!;
                    var sample=catalog.SampleMuzzle(name,rifle,Math.Min(index/30d,catalog.Duration(name)),false);
                    var bone=rigWorld[rigIndex[sample.SourcePath]];
                    Check(Vector3.Distance(bone.Position,sample.Position)<.0002f &&
                        1-Math.Abs(Quaternion.Dot(bone.Rotation,sample.Rotation))<.00001f,"exported per-frame local rig reconstructs muzzle");
                    Check(sample.SourcePath==muzzle.GetProperty("path").GetString() &&
                        Vector3.Distance(sample.Position,V(muzzle.GetProperty("position")))<.00001f,"muzzle uses same animation frame");
                    var placed=sample.Place(new Vector3(3,0,4),Quaternion.CreateFromAxisAngle(Vector3.UnitY,MathF.PI/2));
                    Check(Vector3.Distance(placed.Position,V(muzzle.GetProperty("placedPosition")))<.0001f,"Unity hierarchy muzzle placement parity");
                }
                frames++; index++;
            }
            Check(ReferenceEquals(catalog.Sample(name, 100, false), catalog.Sample(name, catalog.Duration(name), false)), "clamped clip completion");
            Check(ReferenceEquals(catalog.Sample(name, catalog.Duration(name), true), catalog.Sample(name, 0, true)), "explicit clip looping");
            var body=Quaternion.CreateFromAxisAngle(Vector3.UnitY,.3f);var upper=Quaternion.CreateFromAxisAngle(Vector3.UnitX,-.4f);
            var rigid=catalog.SampleAimed(name,0,false,body,upper);
            var hierarchy=catalog.SampleBlended(name,0,false,name,0,false,.5f,body,upper);
            Check(hierarchy.Collision.Parts.Zip(rigid.Collision.Parts).All(p=>Vector3.Distance(p.First.Center,p.Second.Center)<.0002f),"rig blend applies procedural overrides after animation");
        }
        Check(frames == catalog.FrameCount, "frame conservation");
        var start = catalog.Sample("player_look_right3", 0, false);
        var end = catalog.Sample("player_look_right3", catalog.Duration("player_look_right3"), false);
        Check(start.Parts.Where((part,i) => Vector3.Distance(part.Center,end.Parts[i].Center)>0.001f).Any(), "source uncover changes collision pose");
        Check(start.PoseKind == "initialized-single-clip-samples" && start.Place(Vector3.Zero,Quaternion.Identity).PoseKind == start.PoseKind, "pose provenance retained on placement");
        Reject(() => catalog.Sample("invented",0,false));
        Reject(() => catalog.Sample("idle",double.NaN,false));
        Reject(() => catalog.Sample("idle",-1,false));
        Reject(() => catalog.SampleAimed("idle",0,false,new Quaternion(),null));
        Reject(() => catalog.SampleMuzzle("idle","invented",0,false));
        var muzzleStart=catalog.SampleMuzzle("player_look_right3","Google2u.AssaultRifle_AK47",0,false);
        var muzzleEnd=catalog.SampleMuzzle("player_look_right3","Google2u.AssaultRifle_AK47",catalog.Duration("player_look_right3"),false);
        Check(Vector3.Distance(muzzleStart.Position,muzzleEnd.Position)>.001f,"uncover animation moves muzzle");
        Reject(() => muzzleStart.Place(Vector3.Zero,new Quaternion()));
        Reject(() => PlayerPoseCatalog.Load(path,new string('f',64)));
        var json = JsonNode.Parse(File.ReadAllText(path))!;
        string temp = Path.GetTempFileName();
        try
        {
            json["clips"]![0]!["frames"]!.AsArray().RemoveAt(0);
            File.WriteAllText(temp,json.ToJsonString());
            Reject(() => PlayerPoseCatalog.Load(temp,sourceHash));
            json = JsonNode.Parse(File.ReadAllText(path))!;
            json["rigNodes"]![1]!["parent"]=1;
            File.WriteAllText(temp,json.ToJsonString());
            Reject(() => PlayerPoseCatalog.Load(temp,sourceHash));
            json = JsonNode.Parse(File.ReadAllText(path))!;
            json["clips"]![0]!["frames"]![1]!["rigLocals"]!.AsArray().RemoveAt(0);
            File.WriteAllText(temp,json.ToJsonString());
            Reject(() => PlayerPoseCatalog.Load(temp,sourceHash));
            json = JsonNode.Parse(File.ReadAllText(path))!;
            json["clips"]![0]!["frames"]![0]!["aimBones"]![0]!["parentScale"]![0]=2;
            File.WriteAllText(temp,json.ToJsonString());
            Reject(() => PlayerPoseCatalog.Load(temp,sourceHash));
            json = JsonNode.Parse(File.ReadAllText(path))!;
            json["clips"]![0]!["frames"]![1]!["aimBones"]![1]!["path"]="MainSceneRootNew/Player/foreign";
            File.WriteAllText(temp,json.ToJsonString());
            Reject(() => PlayerPoseCatalog.Load(temp,sourceHash));
            json = JsonNode.Parse(File.ReadAllText(path))!;
            json["clips"]![0]!["frames"]![0]!["muzzles"]!.AsArray().RemoveAt(0);
            File.WriteAllText(temp,json.ToJsonString());
            Reject(() => PlayerPoseCatalog.Load(temp,sourceHash));
            json = JsonNode.Parse(File.ReadAllText(path))!;
            json["clips"]![1]!["frames"]![1]!["muzzles"]![0]!["path"]="MainSceneRootNew/Player/foreign";
            File.WriteAllText(temp,json.ToJsonString());
            Reject(() => PlayerPoseCatalog.Load(temp,sourceHash));
            json = JsonNode.Parse(File.ReadAllText(path))!;
            json["clips"]![1]!["frames"]![1]!["parts"]![0]!["weight"] = 2;
            File.WriteAllText(temp,json.ToJsonString());
            Reject(() => PlayerPoseCatalog.Load(temp,sourceHash));
        }
        finally { File.Delete(temp); }
        return count;
    }
}

using System.Numerics;
using System.Text.Json;
using War.BattleServer;

internal static class RigBlendTests
{
    internal static int Run(string path)
    {
        int count=0;
        void Check(bool ok,string name) { if (!ok) throw new Exception(name); count++; }
        void Reject(Action action) { try { action(); } catch (InvalidDataException) { count++; return; } throw new Exception("Invalid rig accepted."); }
        using var doc=JsonDocument.Parse(File.ReadAllBytes(path));
        var root=doc.RootElement;
        var catalog=PlayerPoseCatalog.Load(Path.Combine(Path.GetDirectoryName(path)!,"recovered-player-poses.json"),root.GetProperty("sha256").GetString()!);
        Vector3 V(JsonElement e)=>new(e[0].GetSingle(),e[1].GetSingle(),e[2].GetSingle());
        Quaternion Q(JsonElement e)=>new(e[0].GetSingle(),e[1].GetSingle(),e[2].GetSingle(),e[3].GetSingle());
        RigLocalTransform[] Locals(JsonElement a)=>a.EnumerateArray().Select(e=>new RigLocalTransform(V(e.GetProperty("position")),Q(e.GetProperty("rotation")),V(e.GetProperty("scale")))).ToArray();
        var parents=root.GetProperty("nodes").EnumerateArray().Select(n=>n.GetProperty("parent").GetInt32()).ToArray();
        var nodePaths=root.GetProperty("nodes").EnumerateArray().Select(n=>n.GetProperty("path").GetString()!).ToArray();
        foreach (var test in root.GetProperty("cases").EnumerateArray())
        {
            var runtime=catalog.SampleBlended(test.GetProperty("from").GetString()!,Math.Round(test.GetProperty("fromSeconds").GetDouble()*30)/30,false,
                test.GetProperty("to").GetString()!,Math.Round(test.GetProperty("toSeconds").GetDouble()*30)/30,false,test.GetProperty("weight").GetSingle());
            bool triple=test.GetProperty("third").ValueKind==JsonValueKind.String;
            float weight=test.GetProperty("weight").GetSingle();
            if (triple) runtime=catalog.SampleLayers([
                new(new(test.GetProperty("from").GetString()!,Math.Round(test.GetProperty("fromSeconds").GetDouble()*30)/30,1,false),(1-weight)*.8f),
                new(new(test.GetProperty("to").GetString()!,Math.Round(test.GetProperty("toSeconds").GetDouble()*30)/30,1,false),weight*.8f),
                new(new(test.GetProperty("third").GetString()!,Math.Round(test.GetProperty("thirdSeconds").GetDouble()*30)/30,1,false),.2f)]);
            foreach (var part in test.GetProperty("parts").EnumerateArray())
            {
                var actual=runtime.Collision.Parts.Single(p=>p.SourcePath==part.GetProperty("path").GetString());
                Check(Vector3.Distance(actual.Center,V(part.GetProperty("center")))<.0002f,"runtime blended collider center matches Unity");
                Check(1-Math.Abs(Quaternion.Dot(actual.Rotation,Q(part.GetProperty("rotation"))))<.00001f,"runtime blended collider rotation matches Unity");
            }
            var a=Locals(test.GetProperty("a")); var b=Locals(test.GetProperty("b"));
            var blended=RigLocalPose.Blend(a,b,test.GetProperty("weight").GetSingle());
            if (triple) blended=RigLocalPose.BlendWeighted([a,b,Locals(test.GetProperty("c"))],[(1-weight)*.8f,weight*.8f,.2f]);
            var expectedLocal=Locals(test.GetProperty("local"));
            var world=RigLocalPose.Compose(parents,blended);
            var expectedWorld=test.GetProperty("world");
            foreach (string rifle in new[] { "AK47","AK47Elite","AKS47U","Famas","FamasElite","G36","G36Elite","M16","QBZ95","QBZ95Elite","SteyrAUG" })
            {
                var muzzle=runtime.Muzzle("Google2u.AssaultRifle_"+rifle);
                int node=Array.IndexOf(nodePaths,muzzle.SourcePath);
                Check(node>=0 && Vector3.Distance(muzzle.Position,V(expectedWorld[node].GetProperty("position")))<.0002f,"runtime blended muzzle matches Unity");
            }
            for (int i=0;i<parents.Length;i++)
            {
                string label=test.GetProperty("from").GetString()+" -> "+test.GetProperty("to").GetString()+" node "+i;
                Check(Vector3.Distance(blended[i].Position,expectedLocal[i].Position)<.0001f,"Unity local blend position "+label);
                Check(Vector3.Distance(blended[i].Scale,expectedLocal[i].Scale)<.0001f,"Unity local blend scale "+label);
                Check(1-Math.Abs(Quaternion.Dot(blended[i].Rotation,expectedLocal[i].Rotation))<.00001f,"Unity local blend rotation "+label);
                Check(Vector3.Distance(world[i].Position,V(expectedWorld[i].GetProperty("position")))<.0002f,"Unity composed blend position "+label);
                Check(1-Math.Abs(Quaternion.Dot(world[i].Rotation,Q(expectedWorld[i].GetProperty("rotation"))))<.00001f,"Unity composed blend rotation "+label);
            }
            Reject(()=>RigLocalPose.Blend(a,b,float.NaN));
            Reject(()=>RigLocalPose.Compose(parents.Skip(1).ToArray(),a));
        }
        var one=new[] {new RigLocalTransform(Vector3.Zero,Quaternion.Identity,Vector3.One)};
        Reject(()=>RigLocalPose.Compose(new[] {0},one));
        Reject(()=>RigLocalPose.Compose(new[] {-1},new[] {one[0] with { Scale=Vector3.Zero }}));
        Reject(()=>RigLocalPose.Blend(one,one,1.01f));
        return count;
    }
}

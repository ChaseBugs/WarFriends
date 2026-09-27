using System.Numerics;
using System.Text.Json;
using War.BattleServer;

internal static class DronePersistentContactTests
{
    internal static int Run(string directory,DroneColliderCatalog geometry)
    {
        using var document=JsonDocument.Parse(File.ReadAllBytes(Path.Combine(directory,"recovered-drone-persistent-contact.json")));
        var root=document.RootElement;
        if(root.GetProperty("callbackPolicy").GetString()!="enter-and-stay"||root.GetProperty("rows").GetArrayLength()!=30||
           root.GetProperty("materialPolicy").GetString()!="source-materials"||root.GetProperty("unityVersion").GetString()!="2018.3.0f2")
            throw new Exception("Persistent-contact oracle identity changed.");
        Vector3 Vec(JsonElement v)=>new(v[0].GetSingle(),v[1].GetSingle(),v[2].GetSingle());
        Quaternion Quat(JsonElement q)=>new(q[0].GetSingle(),q[1].GetSingle(),q[2].GetSingle(),q[3].GetSingle());
        float maximumVelocity=0,maximumAngular=0,maximumRoot=0;int steps=0,stays=0;
        float cachedVelocity=0,cachedAngular=0,cachedRoot=0;
        foreach(var row in root.GetProperty("rows").EnumerateArray())
        {
            var frames=row.GetProperty("frames");
            var cachedSolver=new DroneContactSolver(geometry);
            var pairIds=new Dictionary<(string?,int),int>();
            foreach(var group in row.GetProperty("collisionCallbacks").EnumerateArray().GroupBy(c=>c.GetProperty("frame").GetInt32()))
            {
                stays+=group.Count(c=>c.GetProperty("callbackKind").GetString()=="stay");
                int frame=group.Key;var before=frames[frame-1];var after=frames[frame];
                var pairs=group.SelectMany(c=>c.GetProperty("contacts").EnumerateArray()).GroupBy(c=>
                    (c.GetProperty("bodyCollider").GetString(),c.GetProperty("otherColliderIndex").GetInt32()))
                    .Select(p=>p.Select(c=>new MaterialContact(new DroneNormalPoint(Vec(c.GetProperty("position")),
                        Vec(c.GetProperty("normal")),c.GetProperty("separation").GetSingle()),new ContactMaterial(.6f,.6f,0))).ToArray()).ToArray();
                var result=new DroneContactSolver(geometry).Solve(Vec(before.GetProperty("position")),Quat(before.GetProperty("rotation")),
                    Vec(before.GetProperty("velocity")),Vec(before.GetProperty("angularVelocity")),pairs,.999f,.025f,.04f);
                maximumVelocity=Math.Max(maximumVelocity,Vector3.Distance(result.Velocity,Vec(after.GetProperty("velocity"))));
                maximumAngular=Math.Max(maximumAngular,Vector3.Distance(result.AngularVelocity,Vec(after.GetProperty("angularVelocity"))));
                maximumRoot=Math.Max(maximumRoot,Vector3.Distance(result.Pose.Root,Vec(after.GetProperty("position"))));steps++;
                var keyed=group.SelectMany(c=>c.GetProperty("contacts").EnumerateArray()).GroupBy(c=>
                    (c.GetProperty("bodyCollider").GetString(),c.GetProperty("otherColliderIndex").GetInt32())).ToArray();
                foreach(var pair in keyed)if(!pairIds.ContainsKey(pair.Key))pairIds.Add(pair.Key,pairIds.Count);
                var stable=Enumerable.Range(0,pairIds.Count).Select(_=>Array.Empty<MaterialContact>()).ToArray();
                foreach(var pair in keyed)
                    stable[pairIds[pair.Key]]=pair.Select(c=>new MaterialContact(new DroneNormalPoint(Vec(c.GetProperty("position")),
                        Vec(c.GetProperty("normal")),c.GetProperty("separation").GetSingle()),new ContactMaterial(.6f,.6f,0))).ToArray();
                var cached=cachedSolver.Solve(Vec(before.GetProperty("position")),Quat(before.GetProperty("rotation")),
                    Vec(before.GetProperty("velocity")),Vec(before.GetProperty("angularVelocity")),stable,.999f,.025f,.04f,true);
                cachedVelocity=Math.Max(cachedVelocity,Vector3.Distance(cached.Velocity,Vec(after.GetProperty("velocity"))));
                cachedAngular=Math.Max(cachedAngular,Vector3.Distance(cached.AngularVelocity,Vec(after.GetProperty("angularVelocity"))));
                cachedRoot=Math.Max(cachedRoot,Vector3.Distance(cached.Pose.Root,Vec(after.GetProperty("position"))));
            }
        }
        if(stays==0||steps<30)throw new Exception("Persistent-contact oracle lacks continuing steps.");
        Console.WriteLine("Drone memoryless persistent-contact diagnostic: steps="+steps+", stays="+stays+", velocity="+maximumVelocity+
            ", angular="+maximumAngular+", root="+maximumRoot+" (cached anchors absent; no response assertion).");
        Console.WriteLine("Drone two-anchor cache diagnostic: velocity="+cachedVelocity+", angular="+cachedAngular+", root="+cachedRoot+
            " (one-anchor growth/span rebuilding absent; experimental pair order).");
        return 1;
    }
}

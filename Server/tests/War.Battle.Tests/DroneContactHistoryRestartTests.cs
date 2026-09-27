using System.Numerics;
using System.Text.Json;
using War.BattleServer;

internal static class DroneContactHistoryRestartTests
{
    internal static void Run(string directory,DroneColliderCatalog geometry)
    {
        using var document=JsonDocument.Parse(File.ReadAllBytes(Path.Combine(directory,"recovered-drone-contact-history-restart.json")));
        var root=document.RootElement;
        if(root.GetProperty("scenario").GetString()!="fresh-body-at-persistent-frame42"||
           root.GetProperty("unityVersion").GetString()!="2018.3.0f2"||root.GetProperty("fixedTimestep").GetSingle()!=.02f)
            throw new Exception("Contact history restart oracle identity mismatch.");
        Vector3 V(JsonElement v)=>new(v[0].GetSingle(),v[1].GetSingle(),v[2].GetSingle());
        Quaternion Q(JsonElement q)=>new(q[0].GetSingle(),q[1].GetSingle(),q[2].GetSingle(),q[3].GetSingle());
        var frames=root.GetProperty("restartFrames");
        if(frames.GetArrayLength()!=4)throw new Exception("Incomplete contact history restart.");
        var callbacks=root.GetProperty("collisionCallbacks").EnumerateArray().ToLookup(c=>c.GetProperty("frame").GetInt32());
        var solver=new DroneContactSolver(geometry);var identities=new Dictionary<(string?,int),int>();
        var shorterCorrelationControl=new DroneContactSolver(geometry);
        for(int index=1;index<4;index++)
        {
            var before=frames[index-1];var after=frames[index];int frame=after.GetProperty("frame").GetInt32();
            if(frame!=42+index)throw new Exception("Contact restart frames are not contiguous.");
            var pairs=callbacks[frame].SelectMany(c=>c.GetProperty("contacts").EnumerateArray()).GroupBy(c=>
                (c.GetProperty("bodyCollider").GetString(),c.GetProperty("otherColliderIndex").GetInt32())).ToArray();
            foreach(var pair in pairs)if(!identities.ContainsKey(pair.Key))identities.Add(pair.Key,identities.Count);
            var contacts=Enumerable.Range(0,identities.Count).Select(_=>Array.Empty<MaterialContact>()).ToArray();
            foreach(var pair in pairs)contacts[identities[pair.Key]]=pair.Select(c=>new MaterialContact(
                new DroneNormalPoint(V(c.GetProperty("position")),V(c.GetProperty("normal")),c.GetProperty("separation").GetSingle()),
                new ContactMaterial(.6f,.6f,0))).ToArray();
            var precedingHistory=solver.FrictionHistory();
            var result=solver.Solve(V(before.GetProperty("position")),Q(before.GetProperty("rotation")),
                V(before.GetProperty("velocity")),V(before.GetProperty("angularVelocity")),contacts,.999f,.025f,.04f,true);
            float error=Vector3.Distance(result.Velocity,V(after.GetProperty("velocity")));
            var fresh=new DroneContactSolver(geometry).Solve(V(before.GetProperty("position")),Q(before.GetProperty("rotation")),
                V(before.GetProperty("velocity")),V(before.GetProperty("angularVelocity")),contacts,.999f,.025f,.04f);
            var shorter=shorterCorrelationControl.Solve(V(before.GetProperty("position")),Q(before.GetProperty("rotation")),
                V(before.GetProperty("velocity")),V(before.GetProperty("angularVelocity")),contacts,.999f,.0025f,.04f,true);
            Console.WriteLine("Drone native contact-history restart frame="+frame+", pairs="+pairs.Length+", velocity residual="+error);
            Console.WriteLine("Drone native restart fresh response frame="+frame+", velocity residual="+
                Vector3.Distance(fresh.Velocity,V(after.GetProperty("velocity"))));
            Console.WriteLine("Drone native restart .0025 correlation diagnostic frame="+frame+", velocity residual="+
                Vector3.Distance(shorter.Velocity,V(after.GetProperty("velocity"))));
            if(frame==45)
                foreach(var patch in precedingHistory.Where(p=>contacts[p.Pair].Length>0))
                {
                    var rotation=Q(before.GetProperty("rotation"));var position=V(before.GetProperty("position"));
                    var worldNormal=Vector3.Transform(patch.Cache.BodyNormal,rotation);
                    Console.WriteLine("Drone disappearing-pair surviving history: broken="+patch.Cache.Broken+
                        ", anchors="+patch.Cache.Anchors.Count+", normal dot="+Vector3.Dot(worldNormal,patch.Cache.MapNormal)+
                        ", reusable="+patch.Cache.CanReuse(position,rotation,.999f,.025f)+", separations="+
                        string.Join(",",patch.Cache.Anchors.Select(a=>Vector3.Dot(position+Vector3.Transform(a.BodyLocal,rotation)-a.MapWorld,worldNormal))));
                }
            // The final disappearing-pair transition remains diagnostic.
            if(index<=2&&error>.00002f)throw new Exception("Contact history restart early response mismatch.");
        }
    }
}

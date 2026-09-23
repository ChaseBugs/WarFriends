using System.Numerics;
using System.Text.Json;
using War.BattleServer;

internal static class BarrelOverlapReferenceTests
{
    internal static int Run(string directory)
    {
        int checks=0,probes=0,unityHits=0,otherHits=0;
        void Check(bool valid,string name){if(!valid)throw new Exception(name);checks++;}
        using var doc=JsonDocument.Parse(File.ReadAllBytes(Path.Combine(directory,
            "unity-barrel-overlap-reference.json")));
        var root=doc.RootElement;
        Check(root.GetProperty("client").GetString()=="1.4.0","Unity barrel overlap Client version");
        var maps=RecoveredBattleMap.Load(Path.Combine(directory,"recovered-battle-content.json"));
        var sourceMaps=root.GetProperty("maps");
        Check(sourceMaps.GetArrayLength()==maps.Count,"Unity barrel overlap has all five scenes");
        for(int m=0;m<maps.Count;m++)
        {
            var map=maps[m];var source=sourceMaps[m];
            Check(source.GetProperty("source").GetString()==map.Source &&
                source.GetProperty("sha256").GetString()==map.SourceHash,
                "Unity barrel overlap binds the exact scene digest");
            var barrels=map.DynamicColliders.Where(c=>c.DynamicOwner.Split('/').Last()
                .StartsWith("barrel",StringComparison.OrdinalIgnoreCase)).ToArray();
            var ids=barrels.Select(c=>c.ColliderIndex).ToHashSet();
            var sourceProbes=source.GetProperty("probes");
            Check(sourceProbes.GetArrayLength()==barrels.Length,"Unity audit covers every scene barrel");
            foreach(var probe in sourceProbes.EnumerateArray())
            {
                string name=probe.GetProperty("name").GetString()!;
                Vector3 center=Vector(probe.GetProperty("position"));
                var origin=barrels.Where(c=>Name(c)==name && Vector3.Distance(c.TransformPosition,center)<.001f).ToArray();
                Check(origin.Length==1,"Unity probe identifies one exact scene barrel");
                var radii=probe.GetProperty("radii");
                Check(radii.GetArrayLength()==2 && radii[0].GetProperty("radius").GetSingle()==1.1f &&
                    radii[1].GetProperty("radius").GetSingle()==1.8f,
                    "Unity probe uses the source explosion radii");
                foreach(var row in radii.EnumerateArray())
                {
                    float radius=row.GetProperty("radius").GetSingle();
                    var expected=new HashSet<int>();
                    foreach(var hit in row.GetProperty("hits").EnumerateArray())
                    {
                        string hitName=hit.GetProperty("name").GetString()!;
                        bool barrelHit=hitName.StartsWith("barrel",StringComparison.OrdinalIgnoreCase);
                        if(!barrelHit)otherHits++;
                        Vector3 position=Vector(hit.GetProperty("position"));
                        var matching=map.DynamicColliders.Where(c=>Name(c)==hitName &&
                            Vector3.Distance(c.TransformPosition,position)<.001f).ToArray();
                        Check(matching.Length==1 && hit.GetProperty("layer").GetInt32()==8 &&
                            expected.Add(matching[0].ColliderIndex),
                            "Unity OverlapSphere hit resolves one runtime-layer destroyable");
                    }
                    unityHits+=expected.Count;
                    var candidates=map.DynamicSphereCandidates(center,radius,1u<<8,
                        runtimeLayer:(index,serialized)=>ids.Contains(index)?8:serialized)
                        .Select(c=>c.Collider.ColliderIndex).ToHashSet();
                    Check(expected.SetEquals(candidates),
                        "AABB candidates match Unity OverlapSphere at a source barrel center");
                    probes++;
                }
            }
        }
        Check(probes==58 && unityHits==103 && otherHits==1,
            "all 29 barrel centers and the distinct City beam hit are accounted for");
        Console.WriteLine($"Unity barrel overlap: {probes} probes, {unityHits} destroyable hits, {otherHits} nonbarrel hit");
        return checks;
    }
    private static string Name(MapDynamicCollider c)=>c.DynamicOwner.Split('/').Last();
    private static Vector3 Vector(JsonElement value)=>new(value[0].GetSingle(),value[1].GetSingle(),value[2].GetSingle());
}

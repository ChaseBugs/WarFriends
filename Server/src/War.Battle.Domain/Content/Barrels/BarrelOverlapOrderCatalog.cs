using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

/// <summary>Unity 2018 Physics.OverlapSphere order at each source barrel center.</summary>
internal sealed class BarrelOverlapOrderCatalog
{
    private const uint DestroyableMask=(1u<<8)|(1u<<22)|(1u<<23)|(1u<<24)|(1u<<26)|(1u<<27);
    private readonly Dictionary<string,IReadOnlyDictionary<int,IReadOnlyList<int>>> maps;
    private BarrelOverlapOrderCatalog(Dictionary<string,IReadOnlyDictionary<int,IReadOnlyList<int>>> maps)
        =>this.maps=maps;
    internal IReadOnlyList<int> Targets(RecoveredBattleMap map,int barrelColliderIndex)=>
        maps.TryGetValue(map.Source,out var rows) && rows.TryGetValue(barrelColliderIndex,out var hits)
            ? hits : throw new InvalidDataException("Unknown source barrel overlap origin.");
    internal static BarrelOverlapOrderCatalog Load(string path,string revision,
        IReadOnlyList<RecoveredBattleMap> maps,BarrelSceneCatalog barrels)
    {
        byte[] bytes=File.ReadAllBytes(path);
        if(bytes.Length is <100 or >100_000 || Convert.ToHexStringLower(SHA256.HashData(bytes))!=revision)
            throw new InvalidDataException("Barrel overlap order revision mismatch.");
        using var doc=JsonDocument.Parse(bytes,new JsonDocumentOptions{MaxDepth=16});
        var root=doc.RootElement;
        if(root.GetProperty("client").GetString()!="1.4.0" ||
           root.GetProperty("maps").GetArrayLength()!=maps.Count)
            throw new InvalidDataException("Incomplete barrel overlap audit.");
        var accepted=new Dictionary<string,IReadOnlyDictionary<int,IReadOnlyList<int>>>(StringComparer.Ordinal);
        for(int m=0;m<maps.Count;m++)
        {
            var map=maps[m];var source=root.GetProperty("maps")[m];
            if(source.GetProperty("source").GetString()!=map.Source ||
               source.GetProperty("sha256").GetString()!=map.SourceHash)
                throw new InvalidDataException("Barrel overlap scene digest mismatch.");
            var barrelIds=barrels.ForMap(map).Select(b=>b.ColliderIndex).ToHashSet();
            var probes=source.GetProperty("probes");
            if(probes.GetArrayLength()!=barrelIds.Count)
                throw new InvalidDataException("Missing source barrel overlap probe.");
            var rows=new Dictionary<int,IReadOnlyList<int>>();
            foreach(var probe in probes.EnumerateArray())
            {
                var center=Vector(probe.GetProperty("position"));
                int origin=Find(map.DynamicColliders,probe.GetProperty("name").GetString()!,center,8,barrelIds);
                if(!barrelIds.Contains(origin) || rows.ContainsKey(origin))
                    throw new InvalidDataException("Duplicate or unknown barrel overlap origin.");
                var radii=probe.GetProperty("radii");
                if(radii.GetArrayLength()!=2 || radii[0].GetProperty("radius").GetSingle()!=1.1f ||
                   radii[1].GetProperty("radius").GetSingle()!=1.8f)
                    throw new InvalidDataException("Wrong source barrel explosion radii.");
                for(int i=0;i<2;i++)
                {
                    float radius=radii[i].GetProperty("radius").GetSingle();
                    var ordered=new List<int>();
                    foreach(var hit in radii[i].GetProperty("hits").EnumerateArray())
                    {
                        if(hit.GetProperty("kind").GetString()!="DestroyableObject")
                            throw new InvalidDataException("Unexpected source explosion target type.");
                        int index=Find(map.DynamicColliders,hit.GetProperty("name").GetString()!,
                            Vector(hit.GetProperty("position")),hit.GetProperty("layer").GetInt32(),barrelIds);
                        if(!ordered.Contains(index))ordered.Add(index);
                        else throw new InvalidDataException("Duplicate source explosion target.");
                    }
                    var candidates=map.DynamicSphereCandidates(center,radius,DestroyableMask,
                        runtimeLayer:(index,serialized)=>barrelIds.Contains(index)?8:serialized)
                        .Select(c=>c.Collider.ColliderIndex).ToHashSet();
                    if(!candidates.SetEquals(ordered))
                        throw new InvalidDataException("Unity barrel overlap and source map disagree.");
                    if(i==1)rows.Add(origin,Array.AsReadOnly(ordered.ToArray()));
                }
            }
            accepted.Add(map.Source,rows);
        }
        return new(accepted);
    }
    private static int Find(IReadOnlyList<MapDynamicCollider> colliders,string name,Vector3 position,
        int runtimeLayer,HashSet<int> barrelIds)
    {
        var matching=colliders.Where(c=>c.SourcePath.Split('/').Last()==name &&
            Vector3.Distance(c.TransformPosition,position)<.001f &&
            (barrelIds.Contains(c.ColliderIndex)?8:c.Layer)==runtimeLayer).ToArray();
        if(matching.Length!=1)throw new InvalidDataException("Ambiguous Unity barrel overlap identity.");
        return matching[0].ColliderIndex;
    }
    private static Vector3 Vector(JsonElement value)
    {
        if(value.ValueKind!=JsonValueKind.Array || value.GetArrayLength()!=3)
            throw new InvalidDataException("Invalid Unity overlap vector.");
        var result=new Vector3(value[0].GetSingle(),value[1].GetSingle(),value[2].GetSingle());
        if(!PlayerHitbox.Finite(result))throw new InvalidDataException("Nonfinite Unity overlap vector.");
        return result;
    }
}

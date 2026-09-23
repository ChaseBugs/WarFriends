using System.Security.Cryptography;
using System.Text.Json;
using System.Numerics;

namespace War.BattleServer;

/// <summary>Source PlayerPoint.rusherPoints, bound to the five pinned scene digests.</summary>
public sealed record ArmyRusherPoint(int ComponentFileId,int Index,int TransformFileId,Vector3 Position);
public sealed class ArmyRusherPointCatalog
{
    private readonly IReadOnlyDictionary<string,ArmyRusherPoint[][]> maps;
    private readonly IReadOnlyDictionary<string,Dictionary<int,int?>> nearNeighbours;
    private ArmyRusherPointCatalog(Dictionary<string,ArmyRusherPoint[][]> maps,
        Dictionary<string,Dictionary<int,int?>> nearNeighbours)
    {this.maps=maps;this.nearNeighbours=nearNeighbours;}

    public IReadOnlyList<ArmyRusherPoint> ForCover(RecoveredBattleMap map,int coverIndex)
    {
        if(!maps.TryGetValue(map.Source,out var covers) || coverIndex<0 || coverIndex>=covers.Length)
            throw new InvalidDataException("Rusher slot lookup lacks a pinned defend position.");
        return Array.AsReadOnly(covers[coverIndex]);
    }

    // SoldierBehaviourRusher.GetInitPoint compares in serialized list order.
    // Once an index 0/1 point wins, a later index 2/3 cannot displace it.
    public ArmyRusherPoint? Choose(RecoveredBattleMap map,int coverIndex,Vector3 from,
        Func<int,bool> occupied)
    {
        if(!PlayerHitbox.Finite(from))throw new ArgumentOutOfRangeException(nameof(from));
        ArgumentNullException.ThrowIfNull(occupied);
        ArmyRusherPoint? selected=null;
        float distance=float.MaxValue;
        foreach(var candidate in ForCover(map,coverIndex))
        {
            if(occupied(candidate.ComponentFileId))continue;
            float candidateDistance=Vector3.Distance(from,candidate.Position);
            if(candidateDistance<distance &&
               (selected==null || selected.Index>1 || candidate.Index<=1))
            {selected=candidate;distance=candidateDistance;}
        }
        return selected;
    }

    public int? NearNeighbour(RecoveredBattleMap map,int pointFileId)
    {
        if(!nearNeighbours.TryGetValue(map.Source,out var points) ||
           !points.TryGetValue(pointFileId,out int? near))
            throw new InvalidDataException("Rusher near-neighbour identity is not source-bound.");
        return near;
    }

    public bool IsFreeWithNearNeighbour(RecoveredBattleMap map,ArmyRusherPoint candidate,
        ArmyRusherPoint from,Func<int,bool> occupied)
    {
        ArgumentNullException.ThrowIfNull(occupied);
        int? near=NearNeighbour(map,candidate.ComponentFileId);
        NearNeighbour(map,from.ComponentFileId);
        return !occupied(candidate.ComponentFileId) &&
            (near==from.ComponentFileId || near==null || !occupied(near.Value));
    }

    public static bool IsRusher(string behaviorType)=>behaviorType is
        "SoldierBehaviourShotgunner" or "SoldierBehaviourSwat" or
        "SoldierBehaviourFlamethrower" or "SoldierBehaviourCommando" or
        "SoldierBehaviourWarper" or "SoldierBehaviourParachuter";

    public static ArmyRusherPointCatalog Load(string path,string expectedRevision,
        IReadOnlyList<RecoveredBattleMap> sourceMaps)
    {
        var bytes=File.ReadAllBytes(path);
        if(bytes.Length is <100 or >65536 ||
           Convert.ToHexStringLower(SHA256.HashData(bytes))!=expectedRevision)
            throw new InvalidDataException("Army Rusher point revision mismatch.");
        using var document=JsonDocument.Parse(bytes,new JsonDocumentOptions{MaxDepth=8});
        var root=document.RootElement;
        Exact(root,"version","maps");
        if(root.GetProperty("version").GetInt32()!=1 || root.GetProperty("maps").GetArrayLength()!=5)
            throw new InvalidDataException("Incomplete Army Rusher source map set.");
        var accepted=new Dictionary<string,ArmyRusherPoint[][]>(StringComparer.Ordinal);
        var neighbours=new Dictionary<string,Dictionary<int,int?>>(StringComparer.Ordinal);
        foreach(var entry in root.GetProperty("maps").EnumerateArray())
        {
            Exact(entry,"source","sha256","mapDefinitionFileId","covers");
            string source=entry.GetProperty("source").GetString()??"";
            var map=sourceMaps.SingleOrDefault(x=>x.Source==source);
            if(map==null || entry.GetProperty("sha256").GetString()!=map.SourceHash ||
               entry.GetProperty("mapDefinitionFileId").GetInt32()<=0 ||
               entry.GetProperty("covers").GetArrayLength()!=map.Covers.Count)
                throw new InvalidDataException("Army Rusher slots do not bind a source scene.");
            var covers=new ArmyRusherPoint[8][];
            var centers=new Vector3[8];
            var seen=new HashSet<int>();
            for(int i=0;i<covers.Length;i++)
            {
                var cover=entry.GetProperty("covers")[i];
                Exact(cover,"sourceIndex","playerPointFileId","playerPointWorldPosition","rusherPoints");
                var center=cover.GetProperty("playerPointWorldPosition")
                    .EnumerateArray().Select(x=>x.GetSingle()).ToArray();
                if(cover.GetProperty("sourceIndex").GetInt32()!=map.Covers[i].SourceIndex ||
                   cover.GetProperty("playerPointFileId").GetInt32()<=0 ||
                   cover.GetProperty("rusherPoints").GetArrayLength()!=4 ||
                   center.Length!=3 || center.Any(x=>!float.IsFinite(x) || Math.Abs(x)>10000) ||
                   Vector3.Distance(new Vector3(center[0],center[1],center[2]),
                       map.Covers[i].Position)>.001f)
                    throw new InvalidDataException("Incomplete Rusher defend-position binding.");
                centers[i]=new Vector3(center[0],center[1],center[2]);
                covers[i]=new ArmyRusherPoint[4];
                for(int j=0;j<4;j++)
                {
                    var point=cover.GetProperty("rusherPoints")[j];
                    Exact(point,"componentFileId","index","transformFileId","worldPosition");
                    int id=point.GetProperty("componentFileId").GetInt32();
                    int sourceIndex=point.GetProperty("index").GetInt32();
                    int transform=point.GetProperty("transformFileId").GetInt32();
                    var coordinates=point.GetProperty("worldPosition").EnumerateArray()
                        .Select(x=>x.GetSingle()).ToArray();
                    if(id<=0 || !seen.Add(id) || sourceIndex!=j || transform<=0 ||
                       coordinates.Length!=3 || coordinates.Any(x=>!float.IsFinite(x) || Math.Abs(x)>10000))
                        throw new InvalidDataException("Rusher slot identity, index or position is invalid.");
                    covers[i][j]=new(id,sourceIndex,transform,
                        new Vector3(coordinates[0],coordinates[1],coordinates[2]));
                }
            }
            if(!accepted.TryAdd(source,covers))
                throw new InvalidDataException("Duplicate Army Rusher source scene.");
            var mapNeighbours=new Dictionary<int,int?>();
            for(int i=0;i<8;i++)
                foreach(var point in covers[i])
                {
                    float nearest=float.MaxValue;
                    int? near=null;
                    for(int j=0;j<8;j++)
                    {
                        if(Vector3.Distance(centers[j],point.Position)>3f)continue;
                        foreach(var other in covers[j])
                        {
                            if(other.ComponentFileId==point.ComponentFileId)continue;
                            float distance=Vector3.Distance(other.Position,point.Position);
                            if(distance<nearest && distance<=.2f)
                            {nearest=distance;near=other.ComponentFileId;}
                        }
                    }
                    mapNeighbours.Add(point.ComponentFileId,near);
                }
            neighbours.Add(source,mapNeighbours);
        }
        if(accepted.Count!=sourceMaps.Count)throw new InvalidDataException("Missing Army Rusher source scene.");
        return new ArmyRusherPointCatalog(accepted,neighbours);
    }

    private static void Exact(JsonElement value,params string[] fields)
    {
        if(value.ValueKind!=JsonValueKind.Object ||
           value.EnumerateObject().Select(x=>x.Name).OrderBy(x=>x,StringComparer.Ordinal)
               .SequenceEqual(fields.OrderBy(x=>x,StringComparer.Ordinal),StringComparer.Ordinal)==false)
            throw new InvalidDataException("Army Rusher source shape differs from the pinned artifact.");
    }
}

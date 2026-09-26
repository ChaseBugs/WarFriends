using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record ArmyMinigunnerPoint(int Order,int ComponentFileId,int TransformFileId,
    int Fraction,Vector3 Position);

/// <summary>EnemyPointMinigunner rows in the source SpawningManager list order.</summary>
public sealed class ArmyMinigunnerPointCatalog
{
    private readonly IReadOnlyDictionary<string,ArmyMinigunnerPoint[]> maps;
    private ArmyMinigunnerPointCatalog(Dictionary<string,ArmyMinigunnerPoint[]> maps)=>this.maps=maps;

    public IReadOnlyList<ArmyMinigunnerPoint> ForFaction(RecoveredBattleMap map,int fraction)
    {
        if(fraction is not (1 or 2) || !maps.TryGetValue(map.Source,out var points))
            throw new InvalidDataException("Minigunner point lookup lacks a pinned map or faction.");
        return Array.AsReadOnly(points.Where(p=>p.Fraction==fraction).ToArray());
    }

    public ArmyMinigunnerPoint? NearestFree(RecoveredBattleMap map,int fraction,Vector3 position,
        int? current,Func<int,bool> occupied)
    {
        if(!PlayerHitbox.Finite(position))throw new ArgumentOutOfRangeException(nameof(position));
        ArgumentNullException.ThrowIfNull(occupied);
        return ForFaction(map,fraction).Where(p=>p.ComponentFileId!=current&&!occupied(p.ComponentFileId))
            .OrderBy(p=>Vector3.Distance(p.Position,position)).ThenBy(p=>p.Order).FirstOrDefault();
    }

    public ArmyMinigunnerPoint? RandomFree(RecoveredBattleMap map,int fraction,int current,
        Func<int,bool> occupied,Func<int,int> choose)
    {
        ArgumentNullException.ThrowIfNull(occupied);ArgumentNullException.ThrowIfNull(choose);
        var candidates=ForFaction(map,fraction)
            .Where(p=>p.ComponentFileId!=current&&!occupied(p.ComponentFileId)).ToArray();
        if(candidates.Length==0)return null;
        int index=choose(candidates.Length);
        if(index<0||index>=candidates.Length)throw new InvalidDataException("Invalid Minigunner point random source.");
        return candidates[index];
    }

    public static ArmyMinigunnerPointCatalog Load(string path,string expectedRevision,
        IReadOnlyList<RecoveredBattleMap> sourceMaps)
    {
        byte[] bytes=File.ReadAllBytes(path);
        if(bytes.Length is <100 or >65536 ||
           Convert.ToHexStringLower(SHA256.HashData(bytes))!=expectedRevision)
            throw new InvalidDataException("Army Minigunner point revision mismatch.");
        using var document=JsonDocument.Parse(bytes,new JsonDocumentOptions{MaxDepth=8});
        var root=document.RootElement;Exact(root,"version","maps");
        if(root.GetProperty("version").GetInt32()!=1||root.GetProperty("maps").GetArrayLength()!=5)
            throw new InvalidDataException("Incomplete Minigunner point source map set.");
        var accepted=new Dictionary<string,ArmyMinigunnerPoint[]>(StringComparer.Ordinal);
        foreach(var entry in root.GetProperty("maps").EnumerateArray())
        {
            Exact(entry,"source","sha256","mapDefinitionFileId","enemyPointsCollectionFileId","points");
            string source=entry.GetProperty("source").GetString()??"";
            var map=sourceMaps.SingleOrDefault(x=>x.Source==source);
            if(map==null||entry.GetProperty("sha256").GetString()!=map.SourceHash||
               entry.GetProperty("mapDefinitionFileId").GetInt32()<=0||
               entry.GetProperty("enemyPointsCollectionFileId").GetInt32()<=0)
                throw new InvalidDataException("Minigunner points do not bind a source scene.");
            var rows=new List<ArmyMinigunnerPoint>();var ids=new HashSet<int>();var transforms=new HashSet<int>();
            int prior=-1;
            foreach(var point in entry.GetProperty("points").EnumerateArray())
            {
                Exact(point,"order","componentFileId","transformFileId","fraction","worldPosition");
                int order=point.GetProperty("order").GetInt32(),id=point.GetProperty("componentFileId").GetInt32(),
                    transform=point.GetProperty("transformFileId").GetInt32(),fraction=point.GetProperty("fraction").GetInt32();
                var xyz=point.GetProperty("worldPosition").EnumerateArray().Select(x=>x.GetSingle()).ToArray();
                if(order<=prior||order is <0 or >511||id<=0||transform<=0||fraction is not (1 or 2)||
                   !ids.Add(id)||!transforms.Add(transform)||xyz.Length!=3||
                   xyz.Any(x=>!float.IsFinite(x)||Math.Abs(x)>10000))
                    throw new InvalidDataException("Invalid Minigunner point identity or ordering.");
                prior=order;rows.Add(new(order,id,transform,fraction,new(xyz[0],xyz[1],xyz[2])));
            }
            if(rows.Count is <2 or >128||rows.Count(x=>x.Fraction==1)==0||rows.Count(x=>x.Fraction==2)==0||
               !accepted.TryAdd(source,rows.ToArray()))
                throw new InvalidDataException("Incomplete or duplicate Minigunner point map.");
        }
        if(accepted.Count!=sourceMaps.Count)throw new InvalidDataException("Missing Minigunner point scene.");
        return new(accepted);
    }

    private static void Exact(JsonElement value,params string[] fields)
    {
        if(value.ValueKind!=JsonValueKind.Object||!value.EnumerateObject().Select(x=>x.Name)
           .OrderBy(x=>x,StringComparer.Ordinal).SequenceEqual(fields.OrderBy(x=>x,StringComparer.Ordinal),StringComparer.Ordinal))
            throw new InvalidDataException("Minigunner point source shape differs from the pinned artifact.");
    }
}

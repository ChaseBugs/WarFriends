using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record BarrelSceneBinding(int ColliderIndex,int GameObjectFileId,int ColliderFileId,
    int BarrelFileId,int DestroyableFileId,float ShotCoefficient,string SourcePath);

/// <summary>Scene file-ID proof for the 29 recovered multiplayer barrels.</summary>
public sealed class BarrelSceneCatalog
{
    private readonly Dictionary<string,IReadOnlyList<BarrelSceneBinding>> byMap;
    private BarrelSceneCatalog(Dictionary<string,IReadOnlyList<BarrelSceneBinding>> byMap)
        =>this.byMap=byMap;
    public IReadOnlyList<BarrelSceneBinding> ForMap(RecoveredBattleMap map)
        =>byMap.TryGetValue(map.Source,out var rows) ? rows : throw new InvalidDataException("Unknown barrel scene.");
    public static BarrelSceneCatalog Load(string path,string expectedRevision,IReadOnlyList<RecoveredBattleMap> maps)
    {
        byte[] bytes=File.ReadAllBytes(path);
        if(bytes.Length is < 100 or > 32768 ||
           Convert.ToHexStringLower(SHA256.HashData(bytes))!=expectedRevision)
            throw new InvalidDataException("Barrel scene binding revision mismatch.");
        using var doc=JsonDocument.Parse(bytes,new JsonDocumentOptions{MaxDepth=8});
        var root=doc.RootElement;
        Exact(root,"client","maps");
        if(root.GetProperty("client").GetString()!="1.4.0")
            throw new InvalidDataException("Wrong barrel Client version.");
        var entries=root.GetProperty("maps");
        if(entries.GetArrayLength()!=maps.Count)throw new InvalidDataException("Incomplete barrel map set.");
        var byMap=new Dictionary<string,IReadOnlyList<BarrelSceneBinding>>(StringComparer.Ordinal);
        int total=0;
        for(int m=0;m<maps.Count;m++)
        {
            var map=maps[m];var entry=entries[m];
            Exact(entry,"source","sha256","barrels");
            if(entry.GetProperty("source").GetString()!=map.Source ||
               entry.GetProperty("sha256").GetString()!=map.SourceHash)
                throw new InvalidDataException("Barrel binding has a different source scene.");
            var expected=map.DynamicColliders.Where(c=>c.DynamicOwner.Split('/').Last()
                .StartsWith("barrel",StringComparison.OrdinalIgnoreCase)).ToArray();
            var rows=entry.GetProperty("barrels");
            if(rows.GetArrayLength()!=expected.Length)
                throw new InvalidDataException("Missing source barrel binding.");
            var objectIds=new HashSet<int>();var colliderIds=new HashSet<int>();
            var barrelIds=new HashSet<int>();var destroyableIds=new HashSet<int>();
            var accepted=new BarrelSceneBinding[expected.Length];
            for(int i=0;i<expected.Length;i++)
            {
                var row=rows[i];Exact(row,"colliderIndex","gameObjectFileId","colliderFileId",
                    "barrelFileId","destroyableFileId","shotCoefficient","sourcePath");
                int index=row.GetProperty("colliderIndex").GetInt32();
                int objectId=row.GetProperty("gameObjectFileId").GetInt32();
                int colliderId=row.GetProperty("colliderFileId").GetInt32();
                int barrelId=row.GetProperty("barrelFileId").GetInt32();
                int destroyableId=row.GetProperty("destroyableFileId").GetInt32();
                float coefficient=row.GetProperty("shotCoefficient").GetSingle();
                string sourcePath=row.GetProperty("sourcePath").GetString()??"";
                if(index!=expected[i].ColliderIndex || sourcePath!=expected[i].SourcePath ||
                   objectId<=0 || colliderId<=0 || barrelId<=0 || destroyableId<=0 ||
                   !float.IsFinite(coefficient) || coefficient!=1 ||
                   !objectIds.Add(objectId) || !colliderIds.Add(colliderId) ||
                   !barrelIds.Add(barrelId) || !destroyableIds.Add(destroyableId))
                    throw new InvalidDataException("Ambiguous source barrel binding.");
                accepted[i]=new(index,objectId,colliderId,barrelId,destroyableId,coefficient,sourcePath);
            }
            total+=accepted.Length;
            byMap.Add(map.Source,Array.AsReadOnly(accepted));
        }
        if(total!=29)throw new InvalidDataException("Incomplete barrel scene catalog.");
        return new(byMap);
    }
    private static void Exact(JsonElement value,params string[] names)
    {
        if(value.ValueKind!=JsonValueKind.Object || value.EnumerateObject().Count()!=names.Length ||
           value.EnumerateObject().Any(p=>!names.Contains(p.Name,StringComparer.Ordinal)))
            throw new InvalidDataException("Unknown or missing barrel binding field.");
    }
}

using System.Security.Cryptography;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace War.BattleServer;

/// <summary>Exact Unity NavMesh inputs; binary pathfinding is not implemented here.</summary>
public sealed record ArmyNavMeshSource(string Scene,string SceneRevision,string Guid,
    string Asset,int Bytes,string Revision);

public sealed class ArmyNavMeshSourceCatalog
{
    private readonly IReadOnlyList<ArmyNavMeshSource> rows;
    public IReadOnlyList<ArmyNavMeshSource> Maps => rows;
    private ArmyNavMeshSourceCatalog(ArmyNavMeshSource[] rows)=>this.rows=Array.AsReadOnly(rows);

    public ArmyNavMeshSource ForMap(RecoveredBattleMap map)
        =>rows.Single(row=>row.Scene==map.Source && row.SceneRevision==map.SourceHash);

    public static ArmyNavMeshSourceCatalog Load(string path,string expectedRevision,
        IReadOnlyList<RecoveredBattleMap> sourceMaps)
    {
        byte[] bytes=File.ReadAllBytes(path);
        if(bytes.Length is <100 or >8192 ||
           Convert.ToHexStringLower(SHA256.HashData(bytes))!=expectedRevision)
            throw new InvalidDataException("NavMesh source revision mismatch.");
        using var document=JsonDocument.Parse(bytes,new JsonDocumentOptions{MaxDepth=5});
        var root=document.RootElement;
        Exact(root,"version","unityVersion","maps");
        if(root.GetProperty("version").GetInt32()!=1 ||
           root.GetProperty("unityVersion").GetString()!="2018.3.0f2" ||
           root.GetProperty("maps").GetArrayLength()!=5 || sourceMaps.Count!=5)
            throw new InvalidDataException("Incomplete source NavMesh package.");
        var directory=Path.GetDirectoryName(Path.GetFullPath(path))!;
        var seenScenes=new HashSet<string>(StringComparer.Ordinal);
        var seenAssets=new HashSet<string>(StringComparer.Ordinal);
        var result=new ArmyNavMeshSource[5];
        int index=0;
        foreach(var item in root.GetProperty("maps").EnumerateArray())
        {
            Exact(item,"scene","sceneSha256","navMeshGuid","navMeshAsset",
                "navMeshBytes","navMeshSha256");
            string scene=item.GetProperty("scene").GetString()??"";
            string sceneHash=item.GetProperty("sceneSha256").GetString()??"";
            string guid=item.GetProperty("navMeshGuid").GetString()??"";
            string asset=item.GetProperty("navMeshAsset").GetString()??"";
            int length=item.GetProperty("navMeshBytes").GetInt32();
            string hash=item.GetProperty("navMeshSha256").GetString()??"";
            if(sourceMaps[index].Source!=scene || sourceMaps[index].SourceHash!=sceneHash ||
               !seenScenes.Add(scene) || !seenAssets.Add(asset) ||
               !Regex.IsMatch(guid,@"\A[0-9a-f]{32}\z") ||
               !Regex.IsMatch(hash,@"\A[0-9a-f]{64}\z") ||
               !Regex.IsMatch(asset,@"\AAssets/NavMeshData/NavMesh(?:_[0-9])?\.asset\z") ||
               length is <10000 or >1000000)
                throw new InvalidDataException("NavMesh map identity or binary bounds differ from source.");
            string binaryPath=Path.Combine(directory,"navmesh",Path.GetFileName(asset));
            byte[] binary=File.ReadAllBytes(binaryPath);
            if(binary.Length!=length ||
               Convert.ToHexStringLower(SHA256.HashData(binary))!=hash ||
               binary.AsSpan(0,Math.Min(binary.Length,80)).IndexOf("2018.3.0f2"u8)<0)
                throw new InvalidDataException("Packaged Unity NavMesh differs from pinned source.");
            result[index++]=new(scene,sceneHash,guid,asset,length,hash);
        }
        return new(result);
    }

    private static void Exact(JsonElement item,params string[] fields)
    {
        if(item.ValueKind!=JsonValueKind.Object ||
           item.EnumerateObject().Count()!=fields.Length ||
           fields.Any(name=>!item.TryGetProperty(name,out _)))
            throw new InvalidDataException("Unexpected NavMesh source fields.");
    }
}

using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace War.BattleServer;

/// <summary>Unity-exported walkable triangles. Route evaluation is separate.</summary>
public sealed class ArmyNavMeshTriangulation
{
    public string Scene { get; }
    public string Revision { get; }
    public IReadOnlyList<Vector3> Vertices { get; }
    public IReadOnlyList<int> Indices { get; }
    internal ArmyNavMeshTriangulation(string scene,string revision,Vector3[] vertices,int[] indices)
    { Scene=scene;Revision=revision;Vertices=Array.AsReadOnly(vertices);Indices=Array.AsReadOnly(indices); }
}

public sealed class ArmyNavMeshTriangulationCatalog
{
    private readonly IReadOnlyList<ArmyNavMeshTriangulation> rows;
    public IReadOnlyList<ArmyNavMeshTriangulation> Maps => rows;
    private ArmyNavMeshTriangulationCatalog(ArmyNavMeshTriangulation[] rows)
        =>this.rows=Array.AsReadOnly(rows);
    public ArmyNavMeshTriangulation ForMap(RecoveredBattleMap map)
        =>rows.Single(row=>row.Scene==map.Source);

    public static ArmyNavMeshTriangulationCatalog Load(string path,string expectedRevision,
        ArmyNavMeshSourceCatalog sources)
    {
        byte[] manifest=File.ReadAllBytes(path);
        if(manifest.Length is <100 or >8192 ||
           Convert.ToHexStringLower(SHA256.HashData(manifest))!=expectedRevision)
            throw new InvalidDataException("Unity triangulation revision mismatch.");
        using var document=JsonDocument.Parse(manifest,new JsonDocumentOptions{MaxDepth=5});
        var root=document.RootElement;
        Exact(root,"version","unityVersion","meshes");
        if(root.GetProperty("version").GetInt32()!=1 ||
           root.GetProperty("unityVersion").GetString()!="2018.3.0f2" ||
           root.GetProperty("meshes").GetArrayLength()!=sources.Maps.Count)
            throw new InvalidDataException("Incomplete Unity triangulation package.");
        string directory=Path.GetDirectoryName(Path.GetFullPath(path))!;
        var result=new ArmyNavMeshTriangulation[sources.Maps.Count];
        for(int i=0;i<result.Length;i++)
        {
            var source=sources.Maps[i];
            var item=root.GetProperty("meshes")[i];
            Exact(item,"scene","navMeshSha256","file","sha256","vertices","triangles");
            string file=item.GetProperty("file").GetString()??"";
            string hash=item.GetProperty("sha256").GetString()??"";
            int vertexCount=item.GetProperty("vertices").GetInt32();
            int triangleCount=item.GetProperty("triangles").GetInt32();
            if(item.GetProperty("scene").GetString()!=source.Scene ||
               item.GetProperty("navMeshSha256").GetString()!=source.Revision ||
               file!=Path.GetFileNameWithoutExtension(source.Asset)+".json" ||
               !Regex.IsMatch(hash,@"\A[0-9a-f]{64}\z") ||
               vertexCount is <100 or >20000 || triangleCount is <100 or >20000)
                throw new InvalidDataException("Unity triangulation source binding is invalid.");
            byte[] bytes=File.ReadAllBytes(Path.Combine(directory,"navmesh-triangulation",file));
            if(bytes.Length is <1000 or >1000000 ||
               Convert.ToHexStringLower(SHA256.HashData(bytes))!=hash)
                throw new InvalidDataException("Unity triangulation bytes differ from pinned export.");
            using var meshDocument=JsonDocument.Parse(bytes,new JsonDocumentOptions{MaxDepth=6});
            var mesh=meshDocument.RootElement;
            Exact(mesh,"asset","vertices","indices","areas");
            if(mesh.GetProperty("asset").GetString()!=source.Asset ||
               mesh.GetProperty("vertices").GetArrayLength()!=vertexCount ||
               mesh.GetProperty("indices").GetArrayLength()!=triangleCount*3 ||
               mesh.GetProperty("areas").GetArrayLength()!=triangleCount)
                throw new InvalidDataException("Incomplete Unity triangulation geometry.");
            var vertices=new Vector3[vertexCount];int j=0;
            foreach(var point in mesh.GetProperty("vertices").EnumerateArray())
            {
                Exact(point,"x","y","z");
                var value=new Vector3(point.GetProperty("x").GetSingle(),
                    point.GetProperty("y").GetSingle(),point.GetProperty("z").GetSingle());
                if(!PlayerHitbox.Finite(value) ||
                   Math.Max(Math.Abs(value.X),Math.Max(Math.Abs(value.Y),Math.Abs(value.Z)))>10000)
                    throw new InvalidDataException("Invalid Unity NavMesh vertex.");
                vertices[j++]=value;
            }
            var indices=new int[triangleCount*3];j=0;
            foreach(var entry in mesh.GetProperty("indices").EnumerateArray())
            {
                int index=entry.GetInt32();
                if(index<0 || index>=vertexCount)
                    throw new InvalidDataException("Unity NavMesh triangle has an invalid vertex.");
                indices[j++]=index;
            }
            if(mesh.GetProperty("areas").EnumerateArray().Any(a=>a.GetInt32()!=0))
                throw new InvalidDataException("Unity NavMesh has an unsupported walk area.");
            result[i]=new(source.Scene,hash,vertices,indices);
        }
        return new(result);
    }

    private static void Exact(JsonElement item,params string[] fields)
    {
        if(item.ValueKind!=JsonValueKind.Object ||
           item.EnumerateObject().Count()!=fields.Length ||
           fields.Any(name=>!item.TryGetProperty(name,out _)))
            throw new InvalidDataException("Unexpected Unity NavMesh triangulation fields.");
    }
}

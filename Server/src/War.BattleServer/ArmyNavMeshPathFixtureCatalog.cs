using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace War.BattleServer;

/// <summary>Validated Unity CalculatePath observations; exact complete spawn-to-Rusher pairs can seed host navigation.</summary>
public sealed record ArmyNavMeshPathFixture(int SpawnFileId,int RusherFileId,
    Vector3 Start,Vector3 End,Vector3 SampledStart,Vector3 SampledEnd,
    bool Complete,IReadOnlyList<Vector3> Corners);

public sealed class ArmyNavMeshPathFixtureCatalog
{
    private readonly IReadOnlyDictionary<string,IReadOnlyList<ArmyNavMeshPathFixture>> maps;
    public int Count => maps.Values.Sum(rows=>rows.Count);
    public int PartialCount => maps.Values.Sum(rows=>rows.Count(row=>!row.Complete));
    private ArmyNavMeshPathFixtureCatalog(Dictionary<string,IReadOnlyList<ArmyNavMeshPathFixture>> rows)
        =>maps=rows;
    public IReadOnlyList<ArmyNavMeshPathFixture> ForMap(RecoveredBattleMap map)
        =>maps.TryGetValue(map.Source,out var rows) ? rows : throw new InvalidDataException("Unknown Unity route map.");

    public static ArmyNavMeshPathFixtureCatalog Load(string path,string expectedRevision,
        IReadOnlyList<RecoveredBattleMap> sourceMaps,ArmyNavMeshSourceCatalog navmeshes,
        ArmyNavMeshTriangulationCatalog triangulations,ArmySpawnPointCatalog spawns,
        ArmyRusherPointCatalog rushers)
    {
        byte[] manifest=File.ReadAllBytes(path);
        if(manifest.Length is <100 or >8192 ||
           Convert.ToHexStringLower(SHA256.HashData(manifest))!=expectedRevision)
            throw new InvalidDataException("Unity route fixture revision mismatch.");
        using var doc=JsonDocument.Parse(manifest,new JsonDocumentOptions{MaxDepth=5});
        var root=doc.RootElement;
        Exact(root,"version","unityVersion","casesSha256","maps");
        if(root.GetProperty("version").GetInt32()!=1 ||
           root.GetProperty("unityVersion").GetString()!="2018.3.0f2" ||
           root.GetProperty("maps").GetArrayLength()!=5 || sourceMaps.Count!=5)
            throw new InvalidDataException("Incomplete Unity route fixtures.");
        string directory=Path.GetDirectoryName(Path.GetFullPath(path))!;
        byte[] caseBytes=File.ReadAllBytes(Path.Combine(directory,"recovered-navmesh-path-cases.json"));
        if(caseBytes.Length is <1000 or >250000 ||
           Convert.ToHexStringLower(SHA256.HashData(caseBytes))!=root.GetProperty("casesSha256").GetString())
            throw new InvalidDataException("Unity route cases differ from source pin.");
        using var caseDoc=JsonDocument.Parse(caseBytes,new JsonDocumentOptions{MaxDepth=9});
        var caseRoot=caseDoc.RootElement;
        Exact(caseRoot,"version","maps");
        if(caseRoot.GetProperty("version").GetInt32()!=1 ||
           caseRoot.GetProperty("maps").GetArrayLength()!=5)
            throw new InvalidDataException("Incomplete Unity route cases.");
        var accepted=new Dictionary<string,IReadOnlyList<ArmyNavMeshPathFixture>>(StringComparer.Ordinal);
        int totalComplete=0,totalPartial=0;
        for(int m=0;m<5;m++)
        {
            var map=sourceMaps[m];var nav=navmeshes.ForMap(map);
            var geometry=triangulations.ForMap(map);
            if(geometry.Vertices.Count<100)throw new InvalidDataException("Route map has no source geometry.");
            var item=root.GetProperty("maps")[m];
            Exact(item,"scene","navMeshSha256","triangulationSha256","file","sha256",
                "cases","complete","partial");
            string file=item.GetProperty("file").GetString()??"";
            string hash=item.GetProperty("sha256").GetString()??"";
            int count=item.GetProperty("cases").GetInt32();
            int complete=item.GetProperty("complete").GetInt32();
            int partial=item.GetProperty("partial").GetInt32();
            if(item.GetProperty("scene").GetString()!=map.Source ||
               item.GetProperty("navMeshSha256").GetString()!=nav.Revision ||
               item.GetProperty("triangulationSha256").GetString()!=geometry.Revision ||
               file!=Path.GetFileNameWithoutExtension(nav.Asset)+".json" ||
               !Regex.IsMatch(hash,@"\A[0-9a-f]{64}\z") ||
               count is <64 or >96 || complete<0 || partial<0 || complete+partial!=count)
                throw new InvalidDataException("Unity route map identity or counts differ from source.");
            var input=caseRoot.GetProperty("maps")[m];
            Exact(input,"scene","asset","cases");
            if(input.GetProperty("scene").GetString()!=map.Source ||
               input.GetProperty("asset").GetString()!=nav.Asset ||
               input.GetProperty("cases").GetArrayLength()!=count)
                throw new InvalidDataException("Route cases do not bind the source map.");
            byte[] bytes=File.ReadAllBytes(Path.Combine(directory,"navmesh-path-results",file));
            if(bytes.Length is <1000 or >250000 ||
               Convert.ToHexStringLower(SHA256.HashData(bytes))!=hash)
                throw new InvalidDataException("Unity route result bytes differ from export.");
            using var resultDoc=JsonDocument.Parse(bytes,new JsonDocumentOptions{MaxDepth=9});
            var result=resultDoc.RootElement;
            Exact(result,"scene","asset","cases");
            if(result.GetProperty("scene").GetString()!=map.Source ||
               result.GetProperty("asset").GetString()!=nav.Asset ||
               result.GetProperty("cases").GetArrayLength()!=count)
                throw new InvalidDataException("Unity route results do not bind the source map.");
            var allowed=new Dictionary<string,(Vector3 Start,Vector3 End)>(StringComparer.Ordinal);
            foreach(var spawn in spawns.ForMap(map).Where(p=>p.ComponentType=="SpawnPoint"))
                foreach(var cover in map.Covers.Where(c=>c.Fraction!=spawn.Fraction))
                    foreach(var rusher in rushers.ForCover(map,cover.SourceIndex))
                        allowed.Add(spawn.ComponentFileId+"-"+rusher.ComponentFileId,
                            (spawn.Position,rusher.Position));
            if(allowed.Count!=count)throw new InvalidDataException("Incomplete spawn-to-Rusher route cross-product.");
            var fixtures=new ArmyNavMeshPathFixture[count];
            int foundComplete=0,foundPartial=0;
            for(int i=0;i<count;i++)
            {
                var probe=input.GetProperty("cases")[i];
                Exact(probe,"id","spawnFileId","rusherFileId","start","end");
                int spawnId=probe.GetProperty("spawnFileId").GetInt32();
                int rusherId=probe.GetProperty("rusherFileId").GetInt32();
                string id=probe.GetProperty("id").GetString()??"";
                if(id!=spawnId+"-"+rusherId || !allowed.Remove(id,out var source) ||
                   Vector3.Distance(Point(probe.GetProperty("start")),source.Start)>.0002f ||
                   Vector3.Distance(Point(probe.GetProperty("end")),source.End)>.0002f)
                    throw new InvalidDataException("Unity route probe lacks a source spawn/slot pair.");
                var resultCase=result.GetProperty("cases")[i];
                Exact(resultCase,"id","spawnFileId","rusherFileId","startSampled","endSampled",
                    "sampledStart","sampledEnd","status","corners");
                string status=resultCase.GetProperty("status").GetString()??"";
                if(resultCase.GetProperty("id").GetString()!=id ||
                   resultCase.GetProperty("spawnFileId").GetInt32()!=spawnId ||
                   resultCase.GetProperty("rusherFileId").GetInt32()!=rusherId ||
                   !resultCase.GetProperty("startSampled").GetBoolean() ||
                   !resultCase.GetProperty("endSampled").GetBoolean() ||
                   status is not ("PathComplete" or "PathPartial"))
                    throw new InvalidDataException("Unity route status differs from source case.");
                var start=Point(resultCase.GetProperty("sampledStart"));
                var end=Point(resultCase.GetProperty("sampledEnd"));
                if(Vector3.Distance(start,source.Start)>3.01f ||
                   Vector3.Distance(end,source.End)>3.01f)
                    throw new InvalidDataException("Unity route snap exceeds the sampled source radius.");
                var corners=resultCase.GetProperty("corners");
                if(corners.GetArrayLength() is <2 or >32)
                    throw new InvalidDataException("Unity route has an invalid corner count.");
                var positions=corners.EnumerateArray().Select(Point).ToArray();
                bool isComplete=status=="PathComplete";
                if(isComplete)foundComplete++;else foundPartial++;
                fixtures[i]=new(spawnId,rusherId,source.Start,source.End,start,end,
                    isComplete,Array.AsReadOnly(positions));
            }
            if(allowed.Count!=0 || foundComplete!=complete || foundPartial!=partial ||
               !accepted.TryAdd(map.Source,Array.AsReadOnly(fixtures)))
                throw new InvalidDataException("Unity route results are incomplete or duplicated.");
            totalComplete+=complete;totalPartial+=partial;
        }
        if(totalComplete!=416 || totalPartial!=16)
            throw new InvalidDataException("Unity route completion evidence changed.");
        return new(accepted);
    }

    private static Vector3 Point(JsonElement row)
    {
        Exact(row,"x","y","z");
        var point=new Vector3(row.GetProperty("x").GetSingle(),
            row.GetProperty("y").GetSingle(),row.GetProperty("z").GetSingle());
        if(!PlayerHitbox.Finite(point) ||
           Math.Max(Math.Abs(point.X),Math.Max(Math.Abs(point.Y),Math.Abs(point.Z)))>10000)
            throw new InvalidDataException("Invalid Unity route coordinate.");
        return point;
    }
    private static void Exact(JsonElement item,params string[] fields)
    {
        if(item.ValueKind!=JsonValueKind.Object || item.EnumerateObject().Count()!=fields.Length ||
           fields.Any(name=>!item.TryGetProperty(name,out _)))
            throw new InvalidDataException("Unexpected Unity route fields.");
    }
}

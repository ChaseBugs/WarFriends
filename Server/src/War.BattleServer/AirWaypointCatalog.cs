using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
namespace War.BattleServer;

public sealed record AirWaypointRoute(int SpawnComponentFileId,int PathComponentFileId,
    int JoinIndex,int StopIndex,float Radius,IReadOnlyList<DroneWaypoint> Waypoints);

public sealed class AirWaypointCatalog
{
    private readonly Dictionary<string,IReadOnlyDictionary<int,AirWaypointRoute>> maps;
    private AirWaypointCatalog(Dictionary<string,IReadOnlyDictionary<int,AirWaypointRoute>> maps){this.maps=maps;}
    public AirWaypointRoute ForSpawn(RecoveredBattleMap map,int spawnComponentFileId)
        =>maps.TryGetValue(map.Source,out var routes)&&routes.TryGetValue(spawnComponentFileId,out var route)
            ?route:throw new InvalidDataException("Unknown air waypoint spawn.");
    public static AirWaypointCatalog Load(string path,string revision,ArmySpawnPointCatalog spawns,
        IReadOnlyList<RecoveredBattleMap> maps)
    {
        byte[] bytes=File.ReadAllBytes(path);
        if(bytes.Length is <100 or >2000000||Convert.ToHexStringLower(SHA256.HashData(bytes))!=revision)
            throw new InvalidDataException("Air waypoint revision mismatch.");
        using var doc=JsonDocument.Parse(bytes,new JsonDocumentOptions{MaxDepth=16});
        var root=doc.RootElement;Exact(root,"version","spawnSourceSha256","maps");
        if(root.GetProperty("version").GetInt32()!=1||root.GetProperty("spawnSourceSha256").GetString()!=spawns.Revision)
            throw new InvalidDataException("Air waypoint source binding mismatch.");
        var entries=root.GetProperty("maps");
        if(entries.GetArrayLength()!=maps.Count)throw new InvalidDataException("Incomplete air waypoint maps.");
        var result=new Dictionary<string,IReadOnlyDictionary<int,AirWaypointRoute>>(StringComparer.Ordinal);
        for(int m=0;m<maps.Count;m++)
        {
            var map=maps[m];var entry=entries[m];Exact(entry,"source","sha256","routes");
            if(entry.GetProperty("source").GetString()!=map.Source||entry.GetProperty("sha256").GetString()!=map.SourceHash)
                throw new InvalidDataException("Air waypoint map mismatch.");
            var source=spawns.ForMap(map).Where(p=>p.Collection is "spawnPointsCollectionDrones" or
                "spawnPointsCollectionAssaultHelis" or "spawnPointsCollectionHelicopters").ToArray();
            var routes=entry.GetProperty("routes");
            if(routes.GetArrayLength()!=source.Length)throw new InvalidDataException("Incomplete air waypoint routes.");
            var accepted=new Dictionary<int,AirWaypointRoute>();
            var pathIds=new HashSet<int>();
            for(int r=0;r<source.Length;r++)
            {
                var row=routes[r];var spawn=source[r];Exact(row,"spawnComponentFileId","collection","fraction",
                    "pathComponentFileId","joinWaypointFileId","joinIndex","stopWaypointFileId","stopIndex","radius","waypoints");
                int pathId=row.GetProperty("pathComponentFileId").GetInt32();
                if(row.GetProperty("spawnComponentFileId").GetInt32()!=spawn.ComponentFileId||
                   row.GetProperty("collection").GetString()!=spawn.Collection||row.GetProperty("fraction").GetInt32()!=spawn.Fraction||
                   pathId!=spawn.ReservationFileId||!pathIds.Add(pathId)||
                   row.GetProperty("joinWaypointFileId").GetInt32()!=spawn.JoinWaypointFileId)
                    throw new InvalidDataException("Air waypoint spawn/path identity mismatch.");
                float radius=row.GetProperty("radius").GetSingle();var points=row.GetProperty("waypoints");
                int join=row.GetProperty("joinIndex").GetInt32(),stop=row.GetProperty("stopIndex").GetInt32();
                int stopId=row.GetProperty("stopWaypointFileId").GetInt32();
                bool helicopter=spawn.Collection=="spawnPointsCollectionHelicopters";
                if(!float.IsFinite(radius)||radius<=0||radius>100||points.GetArrayLength() is <1 or >100||join<0||join>=points.GetArrayLength()||
                   (helicopter?(stop<0||stop>=points.GetArrayLength()||stop==join||stopId<=0):(stop!=-1||stopId!=0)))
                    throw new InvalidDataException("Invalid air path bounds.");
                var definitions=new DroneWaypoint[points.GetArrayLength()];var ids=new HashSet<int>();var tids=new HashSet<int>();
                for(int p=0;p<definitions.Length;p++)
                {
                    var point=points[p];Exact(point,"componentFileId","transformFileId","index","stayTime","worldPosition","transformChain");
                    int id=point.GetProperty("componentFileId").GetInt32(),tid=point.GetProperty("transformFileId").GetInt32();
                    float stay=point.GetProperty("stayTime").GetSingle();Vector3 position=Vector(point.GetProperty("worldPosition"));
                    if(id<=0||tid<=0||!ids.Add(id)||!tids.Add(tid)||point.GetProperty("index").GetInt32()!=p||
                       !float.IsFinite(stay)||stay<0||stay>3600||(p==join&&id!=spawn.JoinWaypointFileId)||
                       (p==stop&&id!=stopId))
                        throw new InvalidDataException("Invalid air waypoint definition.");
                    ValidateChain(point.GetProperty("transformChain"),tid,position);
                    definitions[p]=new(id,position,stay);
                }
                accepted.Add(spawn.ComponentFileId,new(spawn.ComponentFileId,pathId,join,stop,radius,Array.AsReadOnly(definitions)));
            }
            result.Add(map.Source,new System.Collections.ObjectModel.ReadOnlyDictionary<int,AirWaypointRoute>(accepted));
        }
        return new(result);
    }
    private static void ValidateChain(JsonElement chain,int tid,Vector3 expected)
    {
        if(chain.GetArrayLength() is <1 or >32)throw new InvalidDataException("Invalid air waypoint transform chain.");
        var ids=new HashSet<int>();Vector3 position=Vector3.Zero,scale=Vector3.One;Quaternion rotation=Quaternion.Identity;
        for(int i=chain.GetArrayLength()-1;i>=0;i--)
        {
            var row=chain[i];Exact(row,"fileId","position","rotation","scale");int id=row.GetProperty("fileId").GetInt32();
            var q=row.GetProperty("rotation");if(q.GetArrayLength()!=4)throw new InvalidDataException("Invalid air quaternion.");
            var localRotation=new Quaternion(q[0].GetSingle(),q[1].GetSingle(),q[2].GetSingle(),q[3].GetSingle());
            if(id<=0||!ids.Add(id)||(i==0&&id!=tid)||!float.IsFinite(localRotation.LengthSquared())||Math.Abs(localRotation.LengthSquared()-1)>.01f)
                throw new InvalidDataException("Invalid air transform identity/rotation.");
            var localScale=Vector(row.GetProperty("scale"));
            if(localScale.X==0||localScale.Y==0||localScale.Z==0)throw new InvalidDataException("Degenerate air transform.");
            position+=Vector3.Transform(Vector(row.GetProperty("position"))*scale,rotation);
            rotation=Quaternion.Multiply(rotation,localRotation);scale*=localScale;
        }
        if(!float.IsFinite(position.LengthSquared())||Vector3.Distance(position,expected)>.001f)
            throw new InvalidDataException("Air waypoint position differs from source transform chain.");
    }
    private static Vector3 Vector(JsonElement value)
    {
        if(value.GetArrayLength()!=3)throw new InvalidDataException("Invalid air vector.");
        var v=new Vector3(value[0].GetSingle(),value[1].GetSingle(),value[2].GetSingle());
        if(!float.IsFinite(v.LengthSquared())||Math.Abs(v.X)>10000||Math.Abs(v.Y)>10000||Math.Abs(v.Z)>10000)
            throw new InvalidDataException("Invalid air coordinates.");return v;
    }
    private static void Exact(JsonElement row,params string[] fields)
    {if(row.ValueKind!=JsonValueKind.Object||!row.EnumerateObject().Select(p=>p.Name).Order().SequenceEqual(fields.Order()))throw new InvalidDataException("Unexpected air waypoint fields.");}
}

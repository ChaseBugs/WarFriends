using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record ArmySpawnPoint(string Collection,int Order,int ComponentFileId,
    int GameObjectFileId,int TransformFileId,string ComponentType,int Fraction,
    int JoinWaypointFileId,int ReservationFileId,Vector3 Position,ArmyVehicleRoute? VehicleRoute);
public sealed record ArmyVehicleRoute(int CircuitFileId,int TargetTransformFileId,bool SmoothRoute,
    bool IsLoop,IReadOnlyList<int> WaypointTransformFileIds,IReadOnlyList<Vector3> Positions);

/// <summary>Source-scene spawn positions validated against their transform chains.</summary>
public sealed class ArmySpawnPointCatalog
{
    private static readonly string[] Collections=["spawnPointsCollection","spawnPointsCollectionDrones",
        "spawnPointsCollectionAssaultHelis","spawnPointsCollectionCars","spawnPointsCollectionHelicopters"];
    private readonly Dictionary<string,IReadOnlyList<ArmySpawnPoint>> maps;
    public string Revision { get; }
    private ArmySpawnPointCatalog(string revision,Dictionary<string,IReadOnlyList<ArmySpawnPoint>> maps)
    {Revision=revision;this.maps=maps;}
    public IReadOnlyList<ArmySpawnPoint> ForMap(RecoveredBattleMap map)
        =>maps.TryGetValue(map.Source,out var points) ? points : throw new InvalidDataException("Unknown army spawn map.");

    public static ArmySpawnPointCatalog Load(string path,string expectedRevision,IReadOnlyList<RecoveredBattleMap> sourceMaps)
    {
        byte[] bytes=File.ReadAllBytes(path);
        if(bytes.Length is <100 or >500000 ||
           Convert.ToHexStringLower(SHA256.HashData(bytes))!=expectedRevision)
            throw new InvalidDataException("Army spawn source revision mismatch.");
        using var document=JsonDocument.Parse(bytes,new JsonDocumentOptions{MaxDepth=12});
        var root=document.RootElement;Exact(root,"version","maps");
        if(root.GetProperty("version").GetInt32()!=2)throw new InvalidDataException("Unknown spawn artifact version.");
        var entries=root.GetProperty("maps");
        if(entries.GetArrayLength()!=sourceMaps.Count)throw new InvalidDataException("Incomplete army spawn maps.");
        var result=new Dictionary<string,IReadOnlyList<ArmySpawnPoint>>(StringComparer.Ordinal);
        int total=0;
        for(int m=0;m<sourceMaps.Count;m++)
        {
            var map=sourceMaps[m];var entry=entries[m];
            Exact(entry,"source","sha256","mapDefinitionFileId","points");
            if(entry.GetProperty("source").GetString()!=map.Source ||
               entry.GetProperty("sha256").GetString()!=map.SourceHash ||
               entry.GetProperty("mapDefinitionFileId").GetInt32()<=0)
                throw new InvalidDataException("Army spawn map differs from recovered scene.");
            var points=entry.GetProperty("points");
            if(points.GetArrayLength() is <10 or >50)throw new InvalidDataException("Invalid army spawn count.");
            var accepted=new ArmySpawnPoint[points.GetArrayLength()];
            var components=new HashSet<int>();var objects=new HashSet<int>();var transforms=new HashSet<int>();
            var order=Collections.ToDictionary(x=>x,_=>0,StringComparer.Ordinal);
            int categoryIndex=0;
            for(int i=0;i<accepted.Length;i++)
            {
                var point=points[i];Exact(point,"collection","order","componentFileId","gameObjectFileId",
                    "transformFileId","componentType","fraction","joinWaypointFileId","reservationFileId",
                    "worldPosition","transformChain","vehicleRoute");
                string category=point.GetProperty("collection").GetString()??"";
                int selected=Array.IndexOf(Collections,category);
                if(selected<categoryIndex || selected<0 || selected>=Collections.Length)
                    throw new InvalidDataException("Army spawn collection order changed.");
                categoryIndex=selected;
                int ordinal=point.GetProperty("order").GetInt32();
                int component=point.GetProperty("componentFileId").GetInt32();
                int gameObject=point.GetProperty("gameObjectFileId").GetInt32();
                int transform=point.GetProperty("transformFileId").GetInt32();
                int fraction=point.GetProperty("fraction").GetInt32();
                int join=point.GetProperty("joinWaypointFileId").GetInt32();
                int reservation=point.GetProperty("reservationFileId").GetInt32();
                string type=point.GetProperty("componentType").GetString()??"";
                if(ordinal!=order[category]++ || component<=0 || gameObject<=0 || transform<=0 ||
                   !components.Add(component) || !objects.Add(gameObject) || !transforms.Add(transform) ||
                   fraction is not (1 or 2) || !ValidType(category,type) ||
                   !ValidReservation(category,component,join,reservation))
                    throw new InvalidDataException("Invalid source spawn identity or faction.");
                Vector3 position=Vector(point.GetProperty("worldPosition"));
                var chain=point.GetProperty("transformChain");
                if(chain.GetArrayLength() is <1 or >32)throw new InvalidDataException("Invalid spawn transform chain.");
                Vector3 predicted=Vector3.Zero;Quaternion rotation=Quaternion.Identity;Vector3 scale=Vector3.One;
                for(int k=chain.GetArrayLength()-1;k>=0;k--)
                {
                    var step=chain[k];Exact(step,"fileId","position","rotation","scale");
                    if(k==0 && step.GetProperty("fileId").GetInt32()!=transform)
                        throw new InvalidDataException("Spawn transform does not bind its component.");
                    Vector3 local=Vector(step.GetProperty("position"));
                    var q=step.GetProperty("rotation");
                    if(q.GetArrayLength()!=4)throw new InvalidDataException("Invalid spawn quaternion.");
                    var r=new Quaternion(q[0].GetSingle(),q[1].GetSingle(),q[2].GetSingle(),q[3].GetSingle());
                    if(!float.IsFinite(r.X) || !float.IsFinite(r.Y) || !float.IsFinite(r.Z) || !float.IsFinite(r.W) ||
                       Math.Abs(r.LengthSquared()-1)>0.01f)
                        throw new InvalidDataException("Invalid spawn rotation.");
                    Vector3 localScale=Vector(step.GetProperty("scale"));
                    if(localScale.X==0 || localScale.Y==0 || localScale.Z==0)
                        throw new InvalidDataException("Degenerate spawn scale.");
                    predicted+=Vector3.Transform(local*scale,rotation);
                    rotation=Quaternion.Multiply(rotation,r);
                    scale*=localScale;
                }
                if(Vector3.Distance(predicted,position)>0.001f)
                    throw new InvalidDataException("Spawn world position differs from source transform chain.");
                ArmyVehicleRoute? vehicleRoute=ParseVehicleRoute(point.GetProperty("vehicleRoute"),category);
                accepted[i]=new(category,ordinal,component,gameObject,transform,type,fraction,join,reservation,
                    position,vehicleRoute);
            }
            if(order.Values.Any(count=>count==0))throw new InvalidDataException("Missing army spawn collection.");
            total+=accepted.Length;result.Add(map.Source,Array.AsReadOnly(accepted));
        }
        if(total!=101)throw new InvalidDataException("Incomplete recovered spawn-point set.");
        if(result.Values.SelectMany(x=>x).Count(x=>x.VehicleRoute!=null)!=20 ||
           result.Values.SelectMany(x=>x).Where(x=>x.VehicleRoute!=null)
               .Sum(x=>x.VehicleRoute!.Positions.Count)!=107)
            throw new InvalidDataException("Incomplete recovered vehicle route set.");
        return new(expectedRevision,result);
    }

    private static ArmyVehicleRoute? ParseVehicleRoute(JsonElement value,string category)
    {
        if(category!="spawnPointsCollectionCars")
        {
            if(value.ValueKind!=JsonValueKind.Null)
                throw new InvalidDataException("Non-vehicle spawn has a vehicle route.");
            return null;
        }
        Exact(value,"circuitFileId","targetTransformFileId","smoothRoute","isLoop",
            "waypointTransformFileIds","worldPositions");
        int circuit=value.GetProperty("circuitFileId").GetInt32();
        int target=value.GetProperty("targetTransformFileId").GetInt32();
        bool smooth=value.GetProperty("smoothRoute").GetBoolean();
        bool loop=value.GetProperty("isLoop").GetBoolean();
        var ids=value.GetProperty("waypointTransformFileIds");
        var positions=value.GetProperty("worldPositions");
        if(circuit<=0 || target<=0 || smooth || loop || ids.GetArrayLength() is <2 or >64 ||
           positions.GetArrayLength()!=ids.GetArrayLength())
            throw new InvalidDataException("Invalid recovered vehicle route shape.");
        var routeIds=new int[ids.GetArrayLength()];var routePositions=new Vector3[ids.GetArrayLength()];
        var unique=new HashSet<int>();
        for(int i=0;i<routeIds.Length;i++)
        {
            routeIds[i]=ids[i].GetInt32();routePositions[i]=Vector(positions[i]);
            if(routeIds[i]<=0 || !unique.Add(routeIds[i]))
                throw new InvalidDataException("Invalid recovered vehicle waypoint identity.");
        }
        if(routeIds[^1]!=target)
            throw new InvalidDataException("Vehicle target is not the final source waypoint.");
        return new(circuit,target,smooth,loop,Array.AsReadOnly(routeIds),Array.AsReadOnly(routePositions));
    }

    private static Vector3 Vector(JsonElement array)
    {
        if(array.GetArrayLength()!=3)throw new InvalidDataException("Invalid spawn vector length.");
        var result=new Vector3(array[0].GetSingle(),array[1].GetSingle(),array[2].GetSingle());
        if(!float.IsFinite(result.X) || !float.IsFinite(result.Y) || !float.IsFinite(result.Z) ||
           Math.Abs(result.X)>10000 || Math.Abs(result.Y)>10000 || Math.Abs(result.Z)>10000)
            throw new InvalidDataException("Invalid spawn coordinate.");
        return result;
    }
    private static bool ValidType(string category,string type)=>category switch
    {
        "spawnPointsCollection"=>type is "SpawnPoint" or "SpawnPointParachute",
        "spawnPointsCollectionDrones" or "spawnPointsCollectionAssaultHelis"=>type=="SpawnPointDrone",
        "spawnPointsCollectionCars"=>type=="SpawnPointCar",
        "spawnPointsCollectionHelicopters"=>type=="SpawnPointHelicopter",
        _=>false
    };
    private static bool ValidReservation(string category,int component,int join,int reservation)=>category switch
    {
        "spawnPointsCollection"=>join==0 && reservation==0,
        "spawnPointsCollectionCars"=>join==0 && reservation==component,
        "spawnPointsCollectionDrones" or "spawnPointsCollectionAssaultHelis" or
            "spawnPointsCollectionHelicopters"=>join>0 && reservation>0,
        _=>false
    };
    private static void Exact(JsonElement element,params string[] fields)
    {
        if(element.ValueKind!=JsonValueKind.Object ||
           !element.EnumerateObject().Select(p=>p.Name).Order().SequenceEqual(fields.Order()))
            throw new InvalidDataException("Unexpected army spawn field set.");
    }
}

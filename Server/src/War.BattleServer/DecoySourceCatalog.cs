using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record DecoyObstacleSlot(int Order,int ComponentFileId,int GameObjectFileId,int Fraction,
    int StartTransformFileId,int EndTransformFileId,Vector3 Start,Vector3 End,Vector3 InitialMidpoint);
public sealed record DecoyPrefabSource(string Source,string Sha256,int RootTransformFileId,
    int ShootableComponentFileId,int TargetTransformFileId,Vector3 TargetLocalPosition,
    int ColliderComponentFileId,Vector3 ColliderCenter,Vector3 ColliderSize);

/// <summary>Recovered Decoy card constants, prefab target/collider, and source obstacle slots.</summary>
public sealed class DecoySourceCatalog
{
    private static readonly int[] Counts=[17,19,20,13,20];
    private static readonly (int One,int Two)[] Fractions=[(10,7),(9,10),(10,10),(6,7),(10,10)];
    private readonly Dictionary<string,IReadOnlyList<DecoyObstacleSlot>> maps;
    public string Revision { get; }
    public int SpawnCount { get; }
    public float MinimumHealth { get; }
    public float MaximumHealth { get; }
    public DecoyPrefabSource Prefab { get; }
    private DecoySourceCatalog(string revision,int spawnCount,float minimumHealth,float maximumHealth,
        DecoyPrefabSource prefab,Dictionary<string,IReadOnlyList<DecoyObstacleSlot>> maps)
    {Revision=revision;SpawnCount=spawnCount;MinimumHealth=minimumHealth;MaximumHealth=maximumHealth;Prefab=prefab;this.maps=maps;}

    public IReadOnlyList<DecoyObstacleSlot> ForMap(RecoveredBattleMap map)
        =>maps.TryGetValue(map.Source,out var rows)?rows:throw new InvalidDataException("Unknown Decoy source map.");

    public float Health(int zeroBasedPlayerLevel,int maxDisplayLevel)
    {
        if(zeroBasedPlayerLevel<0||zeroBasedPlayerLevel>=maxDisplayLevel||maxDisplayLevel is <1 or >1000)
            throw new ArgumentOutOfRangeException(nameof(zeroBasedPlayerLevel));
        float result=MinimumHealth+(MaximumHealth-MinimumHealth)*zeroBasedPlayerLevel/maxDisplayLevel;
        if(!float.IsFinite(result)||result<=0)throw new InvalidDataException("Invalid Decoy health composition.");
        return result;
    }

    public IReadOnlyList<DecoyObstacleSlot> Select(string mapSource,int fraction,
        IReadOnlySet<int> occupied,Func<int,int> choose)
    {
        if(!maps.TryGetValue(mapSource,out var rows)||fraction is not (1 or 2)||occupied==null||choose==null)
            throw new InvalidDataException("Invalid Decoy placement authority.");
        var free=rows.Where(x=>x.Fraction==fraction&&!occupied.Contains(x.ComponentFileId)).ToList();
        if(free.Count<SpawnCount)return [];
        var selected=new DecoyObstacleSlot[SpawnCount];
        for(int i=0;i<selected.Length;i++)
        {
            int index=choose(free.Count);
            if(index<0||index>=free.Count)throw new InvalidDataException("Invalid Decoy random selection.");
            selected[i]=free[index];free.RemoveAt(index);
        }
        return Array.AsReadOnly(selected);
    }

    public static DecoySourceCatalog Load(string path,string expectedRevision,IReadOnlyList<RecoveredBattleMap> sourceMaps)
    {
        byte[] bytes=File.ReadAllBytes(path);
        if(bytes.Length is <1000 or >250000||Convert.ToHexStringLower(SHA256.HashData(bytes))!=expectedRevision)
            throw new InvalidDataException("Decoy source revision mismatch.");
        using var document=JsonDocument.Parse(bytes,new JsonDocumentOptions{MaxDepth=10});
        var root=document.RootElement;Exact(root,"version","client","spawnCount","health","prefab","maps");
        if(root.GetProperty("version").GetInt32()!=1||root.GetProperty("client").GetString()!="1.4.0"||
           root.GetProperty("spawnCount").GetInt32()!=3||sourceMaps.Count!=5)
            throw new InvalidDataException("Unknown Decoy source package.");
        var health=root.GetProperty("health");Exact(health,"minimum","maximum");
        float minimum=Number(health,"minimum"),maximum=Number(health,"maximum");
        if(minimum!=62.5f||maximum!=1090f)throw new InvalidDataException("Decoy health constants changed.");
        var prefab=ParsePrefab(root.GetProperty("prefab"));
        var entries=root.GetProperty("maps");
        if(entries.GetArrayLength()!=sourceMaps.Count)throw new InvalidDataException("Incomplete Decoy maps.");
        var result=new Dictionary<string,IReadOnlyList<DecoyObstacleSlot>>(StringComparer.Ordinal);
        int total=0;
        for(int m=0;m<sourceMaps.Count;m++)
        {
            var source=sourceMaps[m];var entry=entries[m];
            Exact(entry,"source","sha256","mapDefinitionFileId","enemyPointsCollectionFileId","slots");
            if(entry.GetProperty("source").GetString()!=source.Source||entry.GetProperty("sha256").GetString()!=source.SourceHash||
               entry.GetProperty("mapDefinitionFileId").GetInt32()<=0||entry.GetProperty("enemyPointsCollectionFileId").GetInt32()<=0)
                throw new InvalidDataException("Decoy map identity changed.");
            var slots=entry.GetProperty("slots");
            if(slots.GetArrayLength()!=Counts[m])throw new InvalidDataException("Decoy obstacle count changed.");
            var accepted=new DecoyObstacleSlot[slots.GetArrayLength()];var components=new HashSet<int>();
            int ones=0,twos=0,lastOrder=-1;
            for(int i=0;i<accepted.Length;i++)
            {
                var slot=slots[i];Exact(slot,"order","componentFileId","gameObjectFileId","fraction",
                    "startTransformFileId","endTransformFileId","start","end","initialMidpoint");
                int order=slot.GetProperty("order").GetInt32(),component=slot.GetProperty("componentFileId").GetInt32();
                int gameObject=slot.GetProperty("gameObjectFileId").GetInt32(),fraction=slot.GetProperty("fraction").GetInt32();
                int startId=slot.GetProperty("startTransformFileId").GetInt32(),endId=slot.GetProperty("endTransformFileId").GetInt32();
                var start=Vector(slot.GetProperty("start"));var end=Vector(slot.GetProperty("end"));
                var midpoint=Vector(slot.GetProperty("initialMidpoint"));
                if(order<=lastOrder||component<=0||gameObject<=0||startId<=0||endId<=0||startId==endId||
                   !components.Add(component)||fraction is not (1 or 2)||
                   Vector3.Distance(midpoint,(start+end)/2)>.00001f||Vector3.Distance(start,end)<.01f)
                    throw new InvalidDataException("Invalid Decoy obstacle slot.");
                lastOrder=order;if(fraction==1)ones++;else twos++;
                accepted[i]=new(order,component,gameObject,fraction,startId,endId,start,end,midpoint);
            }
            if((ones,twos)!=Fractions[m])throw new InvalidDataException("Decoy obstacle factions changed.");
            total+=accepted.Length;result.Add(source.Source,Array.AsReadOnly(accepted));
        }
        if(total!=89)throw new InvalidDataException("Incomplete Decoy obstacle package.");
        return new(expectedRevision,3,minimum,maximum,prefab,result);
    }

    private static DecoyPrefabSource ParsePrefab(JsonElement row)
    {
        Exact(row,"source","sha256","rootTransformFileId","shootableComponentFileId","targets","collider");
        string source=row.GetProperty("source").GetString()??"",sha=row.GetProperty("sha256").GetString()??"";
        int root=row.GetProperty("rootTransformFileId").GetInt32(),shootable=row.GetProperty("shootableComponentFileId").GetInt32();
        var targets=row.GetProperty("targets");
        if(source!="Assets/GameObject/Decoy.prefab"||sha!="b04629c9831eabf5cf3592ece6da638c4f3c5faafaa0d10040f09990e482bdb3"||
           root!=461526||shootable!=11431434||targets.GetArrayLength()!=1)
            throw new InvalidDataException("Decoy prefab identity changed.");
        var target=targets[0];Exact(target,"transformFileId","type","localPosition");
        int targetId=target.GetProperty("transformFileId").GetInt32();var targetPosition=Vector(target.GetProperty("localPosition"));
        var collider=row.GetProperty("collider");Exact(collider,"componentFileId","enabled","trigger","center","size");
        int colliderId=collider.GetProperty("componentFileId").GetInt32();var center=Vector(collider.GetProperty("center"));
        var size=Vector(collider.GetProperty("size"));
        if(targetId!=469566||target.GetProperty("type").GetInt32()!=1||targetPosition!=new Vector3(0,.431f,0)||
           colliderId!=6519550||!collider.GetProperty("enabled").GetBoolean()||collider.GetProperty("trigger").GetBoolean()||
           center!=new Vector3(0,.2503818f,-.05564286f)||size!=new Vector3(.2825435f,.5701809f,.1112857f))
            throw new InvalidDataException("Decoy target or collider changed.");
        return new(source,sha,root,shootable,targetId,targetPosition,colliderId,center,size);
    }

    private static float Number(JsonElement row,string name)
    {float value=row.GetProperty(name).GetSingle();if(!float.IsFinite(value))throw new InvalidDataException("Invalid Decoy number.");return value;}
    private static Vector3 Vector(JsonElement row)
    {
        if(row.GetArrayLength()!=3)throw new InvalidDataException("Invalid Decoy vector.");
        var value=new Vector3(row[0].GetSingle(),row[1].GetSingle(),row[2].GetSingle());
        if(!PlayerHitbox.Finite(value)||value.LengthSquared()>100_000_000)throw new InvalidDataException("Invalid Decoy vector.");
        return value;
    }
    private static void Exact(JsonElement row,params string[] names)
    {
        if(row.ValueKind!=JsonValueKind.Object||!row.EnumerateObject().Select(x=>x.Name)
            .ToHashSet(StringComparer.Ordinal).SetEquals(names))throw new InvalidDataException("Unknown or missing Decoy field.");
    }
}

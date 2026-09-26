using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace War.BattleServer;

public sealed record HeavyTurretPlacement(int Order,int ComponentFileId,int GameObjectFileId,
    int TransformFileId,Vector3 SourcePosition);
public sealed record HeavyTurretCover(int Order,int PointComponentFileId,int Fraction,bool Main,
    IReadOnlyList<HeavyTurretPlacement> Slots);
public sealed record HeavyTurretStats(float Health,float Damage,int BatchMinimum,int BatchMaximum,
    float ShootMinimum,float ShootMaximum,float RealShotProbability);
public sealed record HeavyTurretCollider(int ComponentFileId,int TransformFileId,Vector3 Center,Vector3 Size,Quaternion Rotation);

/// <summary>Strict recovered CardHeavyTurret placement, prefab and card-level combat authority.</summary>
public sealed class HeavyTurretSourceCatalog
{
    private sealed class Root {public int Version{get;set;}public string Client{get;set;}="";public int SpawnCount{get;set;}
        public float NavMeshSampleRadius{get;set;}public int NavMeshAreaMask{get;set;}public int MaxDisplayLevel{get;set;}
        public Stat[] Stats{get;set;}=[];public Prefab Prefab{get;set;}=new();public Map[] Maps{get;set;}=[];}
    private sealed class Stat {[JsonPropertyName("TIER")]public int Tier{get;set;}[JsonPropertyName("HP")]public float Health{get;set;}
        [JsonPropertyName("DAMAGE")]public float Damage{get;set;}[JsonPropertyName("BATCHSIZEMIN")]public int BatchMinimum{get;set;}
        [JsonPropertyName("BATCHSIZEMAX")]public int BatchMaximum{get;set;}[JsonPropertyName("SHOTFREQUENCYMIN")]public float ShootMinimum{get;set;}
        [JsonPropertyName("SHOTFREQUENCYMAX")]public float ShootMaximum{get;set;}[JsonPropertyName("REALSHOTPROBABILITY")]public float RealProbability{get;set;}}
    private sealed class Turret {public float AimTime{get;set;}public int BatchSizeMin{get;set;}public int BatchSizeMax{get;set;}
        public float MinShootTime{get;set;}public float MaxShootTime{get;set;}public float MaxShotRotation{get;set;}
        public bool PredictPosition{get;set;}public int PrimaryTarget{get;set;}public bool UseUnitTarget{get;set;}
        public float RealShotProbability{get;set;}public int BatchedWeaponComponentFileId{get;set;}}
    private sealed class Prefab {public string Source{get;set;}="";public string Sha256{get;set;}="";public int RootTransformFileId{get;set;}
        public int HeavyTurretComponentFileId{get;set;}public int TurretWeaponComponentFileId{get;set;}public Turret Turret{get;set;}=new();
        public int[] MeshComponentFileIds{get;set;}=[];public Collider[] Colliders{get;set;}=[];}
    private sealed class Collider {public int ComponentFileId{get;set;}public int TransformFileId{get;set;}
        public float[] Center{get;set;}=[];public float[] Size{get;set;}=[];public float[] Rotation{get;set;}=[];}
    private sealed class Slot {public int Order{get;set;}public int ComponentFileId{get;set;}public int GameObjectFileId{get;set;}
        public int TransformFileId{get;set;}public float[] SourcePosition{get;set;}=[];}
    private sealed class Cover {public int Order{get;set;}public int PointComponentFileId{get;set;}public int Fraction{get;set;}
        public bool Main{get;set;}public Slot[] Slots{get;set;}=[];}
    private sealed class Map {public string Source{get;set;}="";public string Sha256{get;set;}="";public int MapDefinitionFileId{get;set;}
        public Cover[] Covers{get;set;}=[];}
    private readonly Dictionary<string,IReadOnlyList<HeavyTurretCover>> maps;
    private readonly HeavyTurretStats minimum,maximum;
    public string Revision{get;}public int SpawnCount=>1;public float NavMeshSampleRadius=>10;public int NavMeshAreaMask=>1;
    public int MaxDisplayLevel=>44;public string PrefabRevision{get;}public float EffectiveRealShotProbability=>1;
    public IReadOnlyList<HeavyTurretCollider> Colliders{get;}
    private HeavyTurretSourceCatalog(string revision,string prefabRevision,HeavyTurretStats min,HeavyTurretStats max,
        Dictionary<string,IReadOnlyList<HeavyTurretCover>> maps,IReadOnlyList<HeavyTurretCollider> colliders)
    {Revision=revision;PrefabRevision=prefabRevision;minimum=min;maximum=max;this.maps=maps;Colliders=colliders;}
    public IReadOnlyList<HeavyTurretCover> ForMap(RecoveredBattleMap map)=>maps.TryGetValue(map.Source,out var rows)?rows:
        throw new InvalidDataException("Unknown Heavy Turret source map.");
    public HeavyTurretStats Compose(int zeroBasedPlayerLevel)
    {
        if(zeroBasedPlayerLevel<0||zeroBasedPlayerLevel>=MaxDisplayLevel)throw new ArgumentOutOfRangeException(nameof(zeroBasedPlayerLevel));
        float t=(float)zeroBasedPlayerLevel/MaxDisplayLevel;
        return new(Lerp(minimum.Health,maximum.Health,t),Lerp(minimum.Damage,maximum.Damage,t),
            (int)Lerp(minimum.BatchMinimum,maximum.BatchMinimum,t),(int)Lerp(minimum.BatchMaximum,maximum.BatchMaximum,t),
            Lerp(minimum.ShootMinimum,maximum.ShootMinimum,t),Lerp(minimum.ShootMaximum,maximum.ShootMaximum,t),
            Lerp(minimum.RealShotProbability,maximum.RealShotProbability,t));
    }
    public HeavyTurretPlacement? SelectNearestFree(RecoveredBattleMap map,int coverIndex,int ownerFraction,Vector3 playerPosition,
        Func<int,bool> occupied)
    {
        if(ownerFraction is not (1 or 2)||!PlayerHitbox.Finite(playerPosition)||occupied==null)
            throw new InvalidDataException("Invalid Heavy Turret placement authority.");
        var cover=ForMap(map).SingleOrDefault(x=>x.Order==coverIndex&&x.Fraction==ownerFraction)??
            throw new InvalidDataException("Heavy Turret cover binding changed.");
        return cover.Slots.Where(x=>!occupied(x.ComponentFileId)).OrderBy(x=>Vector3.DistanceSquared(playerPosition,x.SourcePosition))
            .ThenBy(x=>x.Order).FirstOrDefault();
    }
    public static HeavyTurretSourceCatalog Load(string path,string expectedRevision,IReadOnlyList<RecoveredBattleMap> sourceMaps)
    {
        byte[] bytes=File.ReadAllBytes(path);
        if(bytes.Length is <5000 or >500000||Convert.ToHexStringLower(SHA256.HashData(bytes))!=expectedRevision)
            throw new InvalidDataException("Heavy Turret source revision mismatch.");
        var root=JsonSerializer.Deserialize<Root>(bytes,new JsonSerializerOptions{PropertyNameCaseInsensitive=true,UnmappedMemberHandling=JsonUnmappedMemberHandling.Disallow})??
            throw new InvalidDataException("Missing Heavy Turret package.");
        if(root.Version!=2||root.Client!="1.4.0"||root.SpawnCount!=1||root.NavMeshSampleRadius!=10||
           root.NavMeshAreaMask!=1||root.MaxDisplayLevel!=44||root.Stats.Length!=2||root.Maps.Length!=5||sourceMaps.Count!=5)
            throw new InvalidDataException("Unknown Heavy Turret package.");
        HeavyTurretStats ParseStat(Stat x)
        {
            if(x.Tier!=-1||!Positive(x.Health)||!Positive(x.Damage)||x.BatchMinimum is <1 or >32||x.BatchMaximum<=x.BatchMinimum||
               x.BatchMaximum>32||!Positive(x.ShootMinimum)||!Positive(x.ShootMaximum)||x.ShootMaximum<x.ShootMinimum||
               !float.IsFinite(x.RealProbability)||x.RealProbability is <0 or >1)throw new InvalidDataException("Invalid Heavy Turret card stat row.");
            return new(x.Health,x.Damage,x.BatchMinimum,x.BatchMaximum,x.ShootMinimum,x.ShootMaximum,x.RealProbability);
        }
        var min=ParseStat(root.Stats[0]);var max=ParseStat(root.Stats[1]);
        if(min!=new HeavyTurretStats(98,11.66f,3,6,3,6,.75f)||max!=new HeavyTurretStats(1619.34216f,98.48f,4,7,2,4,.8f))
            throw new InvalidDataException("Heavy Turret card endpoints changed.");
        var p=root.Prefab;var t=p.Turret;
        if(p.Source!="Assets/GameObject/HeavyTurret.prefab"||p.Sha256!="237be8eb3d033154e081ac4a83930cd1a6e3d709e6fa6c4bae1dd6be12a2785f"||
           p.RootTransformFileId!=424449||p.HeavyTurretComponentFileId!=11491323||p.TurretWeaponComponentFileId!=11459786||
           t.AimTime!=1||t.BatchSizeMin!=1||t.BatchSizeMax!=5||t.MinShootTime!=1||t.MaxShootTime!=5||t.MaxShotRotation!=360||
           !t.PredictPosition||t.PrimaryTarget!=3||!t.UseUnitTarget||t.RealShotProbability!=1||t.BatchedWeaponComponentFileId!=11444804||
           !p.MeshComponentFileIds.SequenceEqual([3327192,3335660,3361517,3339548])||
           p.Colliders.Length!=3||!p.Colliders.Select(x=>x.ComponentFileId).SequenceEqual([6525385,6572182,6582579]))
            throw new InvalidDataException("Heavy Turret prefab graph changed.");
        var colliders=p.Colliders.Select(x=>
        {
            var center=Vector(x.Center);var size=Vector(x.Size);
            if(size.X<=0||size.Y<=0||size.Z<=0||size.X>10||size.Y>10||size.Z>10||x.TransformFileId<=0||x.Rotation.Length!=4)
                throw new InvalidDataException("Invalid Heavy Turret source collider.");
            var rotation=new Quaternion(x.Rotation[0],x.Rotation[1],x.Rotation[2],x.Rotation[3]);
            if(!float.IsFinite(rotation.X)||!float.IsFinite(rotation.Y)||!float.IsFinite(rotation.Z)||!float.IsFinite(rotation.W)||
               Math.Abs(rotation.LengthSquared()-1)>.001f)throw new InvalidDataException("Invalid Heavy Turret collider rotation.");
            return new HeavyTurretCollider(x.ComponentFileId,x.TransformFileId,center,size,Quaternion.Normalize(rotation));
        }).ToArray();
        var result=new Dictionary<string,IReadOnlyList<HeavyTurretCover>>(StringComparer.Ordinal);var ids=new HashSet<int>();int total=0;
        for(int m=0;m<5;m++)
        {
            var map=root.Maps[m];var source=sourceMaps[m];
            if(map.Source!=source.Source||map.Sha256!=source.SourceHash||map.MapDefinitionFileId<=0||map.Covers.Length!=8)
                throw new InvalidDataException("Heavy Turret map identity changed.");
            var covers=new HeavyTurretCover[8];int one=0,two=0;
            for(int i=0;i<8;i++)
            {
                var c=map.Covers[i];if(c.Order!=i||c.PointComponentFileId<=0||c.Fraction is not (1 or 2)||c.Slots.Length!=2)
                    throw new InvalidDataException("Invalid Heavy Turret cover.");
                if(c.Fraction==1)one++;else two++;var slots=new HeavyTurretPlacement[2];
                for(int j=0;j<2;j++)
                {var s=c.Slots[j];var position=Vector(s.SourcePosition);if(s.Order!=j||s.ComponentFileId<=0||s.GameObjectFileId<=0||s.TransformFileId<=0||!ids.Add(s.ComponentFileId))throw new InvalidDataException("Invalid Heavy Turret slot.");slots[j]=new(j,s.ComponentFileId,s.GameObjectFileId,s.TransformFileId,position);total++;}
                covers[i]=new(i,c.PointComponentFileId,c.Fraction,c.Main,Array.AsReadOnly(slots));
            }
            if(one!=4||two!=4||covers.Count(x=>x.Main)!=4)throw new InvalidDataException("Heavy Turret cover factions changed.");
            result.Add(map.Source,Array.AsReadOnly(covers));
        }
        if(total!=80)throw new InvalidDataException("Incomplete Heavy Turret slots.");
        return new(expectedRevision,p.Sha256,min,max,result,Array.AsReadOnly(colliders));
    }
    private static bool Positive(float x)=>float.IsFinite(x)&&x>0&&x<=10_000_000;
    private static float Lerp(float a,float b,float t)=>a+(b-a)*t;
    private static Vector3 Vector(float[] x){if(x.Length!=3)throw new InvalidDataException("Invalid Heavy Turret vector.");var v=new Vector3(x[0],x[1],x[2]);if(!PlayerHitbox.Finite(v))throw new InvalidDataException("Invalid Heavy Turret vector.");return v;}
}

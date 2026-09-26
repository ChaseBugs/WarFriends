using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record LandMineHidingSlot(int Order,int ComponentFileId,int GameObjectFileId,
    int TransformFileId,int Fraction,Vector3 SourcePosition);
public sealed record LandMinePrefabSource(string Source,string Sha256,int RootTransformFileId,
    int AmmoComponentFileId,int TriggerComponentFileId,Vector3 TriggerCenter,Vector3 TriggerSize,
    int MeshComponentFileId,int MeshTransformFileId,Vector3 MeshLocalPosition,string MeshAsset);

/// <summary>Strict recovered CardLandmine placement, damage and prefab authority.</summary>
public sealed class LandMineSourceCatalog
{
    private static readonly int[] Counts=[17,19,20,13,20];
    private static readonly (int One,int Two)[] Fractions=[(10,7),(9,10),(10,10),(6,7),(10,10)];
    private readonly Dictionary<string,IReadOnlyList<LandMineHidingSlot>> maps;
    public string Revision { get; }
    public int SpawnLimit { get; }
    public float NavMeshSampleRadius { get; }
    public int NavMeshAreaMask { get; }
    public float MinimumDamage { get; }
    public float MaximumDamage { get; }
    public float CardScale { get; }
    public float PlayerRadiusCoefficient { get; }
    public float TriggerRadius { get; }
    public float HurtRadius { get; }
    public float DeadRadius { get; }
    public Vector3 ExplosionCoefficient { get; }
    public float AdditionalUpForce { get; }
    public LandMinePrefabSource Prefab { get; }
    private LandMineSourceCatalog(string revision,Dictionary<string,IReadOnlyList<LandMineHidingSlot>> maps,
        LandMinePrefabSource prefab)
    {
        Revision=revision;this.maps=maps;Prefab=prefab;SpawnLimit=3;NavMeshSampleRadius=10;NavMeshAreaMask=1;
        MinimumDamage=62.5f;MaximumDamage=1090;CardScale=.1f;PlayerRadiusCoefficient=.9f;
        TriggerRadius=5;HurtRadius=1.8f;DeadRadius=1.1f;ExplosionCoefficient=new(5,8,5);AdditionalUpForce=6;
    }
    public IReadOnlyList<LandMineHidingSlot> ForMap(RecoveredBattleMap map)
        =>maps.TryGetValue(map.Source,out var rows)?rows:throw new InvalidDataException("Unknown Land Mine source map.");
    public float Damage(int zeroBasedPlayerLevel,int maxDisplayLevel)
    {
        if(zeroBasedPlayerLevel<0||zeroBasedPlayerLevel>=maxDisplayLevel||maxDisplayLevel is <1 or >1000)
            throw new ArgumentOutOfRangeException(nameof(zeroBasedPlayerLevel));
        float value=(MinimumDamage+(MaximumDamage-MinimumDamage)*zeroBasedPlayerLevel/maxDisplayLevel)*CardScale;
        if(!float.IsFinite(value)||value<=0)throw new InvalidDataException("Invalid Land Mine damage composition.");
        return value;
    }
    public IReadOnlyList<LandMineHidingSlot> Select(string mapSource,int ownerFraction,Func<int,int> choose)
    {
        if(!maps.TryGetValue(mapSource,out var rows)||ownerFraction is not (1 or 2)||choose==null)
            throw new InvalidDataException("Invalid Land Mine placement authority.");
        var candidates=rows.Where(x=>x.Fraction!=ownerFraction).ToList();
        int count=Math.Min(SpawnLimit,candidates.Count);var selected=new LandMineHidingSlot[count];
        for(int i=0;i<count;i++)
        {
            int index=choose(candidates.Count);
            if(index<0||index>=candidates.Count)throw new InvalidDataException("Invalid Land Mine random selection.");
            selected[i]=candidates[index];candidates.RemoveAt(index);
        }
        return Array.AsReadOnly(selected);
    }
    public static LandMineSourceCatalog Load(string path,string expectedRevision,IReadOnlyList<RecoveredBattleMap> sourceMaps)
    {
        byte[] bytes=File.ReadAllBytes(path);
        if(bytes.Length is <1000 or >250000||Convert.ToHexStringLower(SHA256.HashData(bytes))!=expectedRevision)
            throw new InvalidDataException("Land Mine source revision mismatch.");
        using var document=JsonDocument.Parse(bytes,new JsonDocumentOptions{MaxDepth=10});var root=document.RootElement;
        Exact(root,"version","client","spawnLimit","navMeshSampleRadius","navMeshAreaMask","damage","mainScene","prefab","maps");
        if(root.GetProperty("version").GetInt32()!=1||root.GetProperty("client").GetString()!="1.4.0"||
           root.GetProperty("spawnLimit").GetInt32()!=3||Number(root,"navMeshSampleRadius")!=10||
           root.GetProperty("navMeshAreaMask").GetInt32()!=1||sourceMaps.Count!=5)
            throw new InvalidDataException("Unknown Land Mine source package.");
        var damage=root.GetProperty("damage");Exact(damage,"minimum","maximum","cardScale","playerRadiusCoefficient");
        if(Number(damage,"minimum")!=62.5f||Number(damage,"maximum")!=1090||Number(damage,"cardScale")!=.1f||
           Number(damage,"playerRadiusCoefficient")!=.9f)throw new InvalidDataException("Land Mine damage constants changed.");
        ParseMainScene(root.GetProperty("mainScene"));var prefab=ParsePrefab(root.GetProperty("prefab"));
        var entries=root.GetProperty("maps");if(entries.GetArrayLength()!=sourceMaps.Count)throw new InvalidDataException("Incomplete Land Mine maps.");
        var result=new Dictionary<string,IReadOnlyList<LandMineHidingSlot>>(StringComparer.Ordinal);int total=0;
        for(int m=0;m<sourceMaps.Count;m++)
        {
            var source=sourceMaps[m];var entry=entries[m];Exact(entry,"source","sha256","mapDefinitionFileId","enemyPointsCollectionFileId","slots");
            if(entry.GetProperty("source").GetString()!=source.Source||entry.GetProperty("sha256").GetString()!=source.SourceHash||
               entry.GetProperty("mapDefinitionFileId").GetInt32()<=0||entry.GetProperty("enemyPointsCollectionFileId").GetInt32()<=0)
                throw new InvalidDataException("Land Mine map identity changed.");
            var slots=entry.GetProperty("slots");if(slots.GetArrayLength()!=Counts[m])throw new InvalidDataException("Land Mine hiding count changed.");
            var accepted=new LandMineHidingSlot[slots.GetArrayLength()];var components=new HashSet<int>();int ones=0,twos=0,last=-1;
            for(int i=0;i<accepted.Length;i++)
            {
                var slot=slots[i];Exact(slot,"order","componentFileId","gameObjectFileId","transformFileId","fraction","sourcePosition");
                int order=slot.GetProperty("order").GetInt32(),component=slot.GetProperty("componentFileId").GetInt32(),
                    gameObject=slot.GetProperty("gameObjectFileId").GetInt32(),transform=slot.GetProperty("transformFileId").GetInt32(),
                    fraction=slot.GetProperty("fraction").GetInt32();var position=Vector(slot.GetProperty("sourcePosition"));
                if(order<=last||component<=0||gameObject<=0||transform<=0||!components.Add(component)||fraction is not (1 or 2))
                    throw new InvalidDataException("Invalid Land Mine hiding slot.");
                last=order;if(fraction==1)ones++;else twos++;accepted[i]=new(order,component,gameObject,transform,fraction,position);
            }
            if((ones,twos)!=Fractions[m])throw new InvalidDataException("Land Mine hiding factions changed.");
            total+=accepted.Length;result.Add(source.Source,Array.AsReadOnly(accepted));
        }
        if(total!=89)throw new InvalidDataException("Incomplete Land Mine hiding package.");
        return new(expectedRevision,result,prefab);
    }
    private static void ParseMainScene(JsonElement row)
    {
        Exact(row,"source","sha256","playerWeapons");var weapons=row.GetProperty("playerWeapons");
        if(row.GetProperty("source").GetString()!="Assets/Scenes/MainScene.unity"||
           row.GetProperty("sha256").GetString()!="d46f81ff8c3e12bf17f34a1f53dd601bd799102c9f984818031441dfb7a5de43"||weapons.GetArrayLength()!=2)
            throw new InvalidDataException("Land Mine MainScene identity changed.");
        int[] weaponIds=[39180,42452],setupIds=[39179,42454],gameObjects=[1158,6750];
        for(int i=0;i<2;i++)
        {
            var value=weapons[i];Exact(value,"weaponComponentFileId","setupComponentFileId","gameObjectFileId","radius","hurtRadius","deadRadius","explosionCoefficient","additionalUpForce","explodeAfterTime");
            if(value.GetProperty("weaponComponentFileId").GetInt32()!=weaponIds[i]||value.GetProperty("setupComponentFileId").GetInt32()!=setupIds[i]||
               value.GetProperty("gameObjectFileId").GetInt32()!=gameObjects[i]||Number(value,"radius")!=5||Number(value,"hurtRadius")!=1.8f||
               Number(value,"deadRadius")!=1.1f||Vector(value.GetProperty("explosionCoefficient"))!=new Vector3(5,8,5)||
               Number(value,"additionalUpForce")!=6||Number(value,"explodeAfterTime")!=0)
                throw new InvalidDataException("Land Mine player setup changed.");
        }
    }
    private static LandMinePrefabSource ParsePrefab(JsonElement row)
    {
        Exact(row,"source","sha256","rootTransformFileId","ammoComponentFileId","trigger","mesh");
        var trigger=row.GetProperty("trigger");Exact(trigger,"componentFileId","center","size");
        var mesh=row.GetProperty("mesh");Exact(mesh,"componentFileId","transformFileId","localPosition","asset");
        string source=row.GetProperty("source").GetString()??"",sha=row.GetProperty("sha256").GetString()??"",asset=mesh.GetProperty("asset").GetString()??"";
        int root=row.GetProperty("rootTransformFileId").GetInt32(),ammo=row.GetProperty("ammoComponentFileId").GetInt32(),
            triggerId=trigger.GetProperty("componentFileId").GetInt32(),meshId=mesh.GetProperty("componentFileId").GetInt32(),transform=mesh.GetProperty("transformFileId").GetInt32();
        var center=Vector(trigger.GetProperty("center"));var size=Vector(trigger.GetProperty("size"));var position=Vector(mesh.GetProperty("localPosition"));
        if(source!="Assets/GameObject/MineAmmo.prefab"||sha!="3109b5c3ee2f2a23fe0b77034b53067cfc4faef070a8724a17690f59452e2da6"||
           root!=461526||ammo!=11454010||triggerId!=6577035||meshId!=3388124||transform!=469566||
           center!=new Vector3(-.00798732f,.052514464f,-.004704781f)||size!=new Vector3(.23787257f,.09612553f,.23773421f)||
           position!=new Vector3(.0125f,.0212f,0)||asset!="{fileID: 4300000, guid: 2e614823204f2f44590345a16cb5c366, type: 2}")
            throw new InvalidDataException("Land Mine prefab identity changed.");
        return new(source,sha,root,ammo,triggerId,center,size,meshId,transform,position,asset);
    }
    private static float Number(JsonElement row,string name)
    {float value=row.GetProperty(name).GetSingle();if(!float.IsFinite(value))throw new InvalidDataException("Invalid Land Mine number.");return value;}
    private static Vector3 Vector(JsonElement row)
    {if(row.GetArrayLength()!=3)throw new InvalidDataException("Invalid Land Mine vector.");var value=new Vector3(row[0].GetSingle(),row[1].GetSingle(),row[2].GetSingle());if(!PlayerHitbox.Finite(value)||value.LengthSquared()>100_000_000)throw new InvalidDataException("Invalid Land Mine vector.");return value;}
    private static void Exact(JsonElement row,params string[] names)
    {if(row.ValueKind!=JsonValueKind.Object||!row.EnumerateObject().Select(x=>x.Name).ToHashSet(StringComparer.Ordinal).SetEquals(names))throw new InvalidDataException("Unknown or missing Land Mine field.");}
}

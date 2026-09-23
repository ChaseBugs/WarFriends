using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace War.BattleServer;

public sealed record LmgStage(string SourceId,int Index,int ClipSize,int ReserveAmmo,float ReloadSeconds,
    float Damage,float CadenceSeconds,float CriticalProbability,float PlayerDamageRatio,float OvertimePlayerDamageRatio,
    int BurstSize,float BurstLockSeconds):IBurstStage;
public sealed record LmgBinding(string SourceId,int InventoryIndex,int AnimationFamily,Vector3 ShotOffset,
    int BurstSize,float SerializedBurstLockSeconds,float FirstShotWaitSeconds,float Speed,float CheckDistance,
    float CriticalMultiplier,bool FriendKill,string MuzzlePath,string BulletRevision);
public sealed record LmgContentManifest(int Version,string SceneRevision,string StatsRevision,string BindingsRevision);

/// <summary>Immutable source package for all recovered PlayerBurstWeapon LMGs.</summary>
public sealed class LmgCatalog
{
    private static readonly (string Id,int Count)[] Expected=
    [
        ("Google2u.LMG_M249",36),("Google2u.LMG_M249Elite",76),("Google2u.LMG_M60",66),
        ("Google2u.LMG_M60Elite",66),("Google2u.LMG_MG4",56),("Google2u.LMG_PKMachinegun",26),
        ("Google2u.LMG_PKMachinegunElite",26),("Google2u.LMG_SA80",46)
    ];
    private readonly IReadOnlyDictionary<string,LmgStage[]> stages;
    private readonly IReadOnlyDictionary<string,LmgBinding> bindings;
    public int WeaponCount=>stages.Count;
    public int StageCount=>stages.Values.Sum(x=>x.Length);
    public string SceneRevision {get;}
    public string StatsRevision {get;}
    public string BindingsRevision {get;}
    public string PackageRevision {get;}
    public IReadOnlyCollection<LmgBinding> Bindings=>Array.AsReadOnly(Expected.Select(x=>Binding(x.Id)).ToArray());
    public uint AlliesBulletMask {get;}
    public uint EnemiesBulletMask {get;}
    private LmgCatalog(Dictionary<string,LmgStage[]> stages,Dictionary<string,LmgBinding> bindings,
        string scene,string stats,string bindingRevision,uint allies,uint enemies)
    {this.stages=stages;this.bindings=bindings;SceneRevision=scene;StatsRevision=stats;BindingsRevision=bindingRevision;
     PackageRevision=Convert.ToHexStringLower(SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(
         "WarFriends/lmg-content/v1\n"+scene+"\n"+stats+"\n"+bindingRevision)));
     AlliesBulletMask=allies;EnemiesBulletMask=enemies;}
    public LmgStage Stage(string sourceId,int upgrade)=>stages.TryGetValue(sourceId,out var lane)&&upgrade>=0&&upgrade<lane.Length
        ? lane[upgrade]:throw new InvalidDataException("Unsupported LMG or upgrade index.");
    public LmgBinding Binding(string sourceId)=>bindings.TryGetValue(sourceId,out var row)?row:
        throw new InvalidDataException("Unsupported LMG binding.");
    public WeaponManifest CreateManifest(string sourceId,int upgrade)
    {var row=Stage(sourceId,upgrade);return new(row.SourceId,row.ClipSize,row.ReserveAmmo,row.CadenceSeconds,row.ReloadSeconds);}
    internal PreparedProjectile Prepare(string sourceId,int upgrade,ulong projectileId,string owner,
        Vector3 authoritativeMuzzle,Vector3 target,ulong tick,float criticalRoll,
        Func<Vector3,Vector3,float,ShotCollision?> trace)
    {
        var stage=Stage(sourceId,upgrade);var binding=Binding(sourceId);
        if(projectileId==0||owner==null||owner.Length==0||!PlayerHitbox.Finite(authoritativeMuzzle)||
           !PlayerHitbox.Finite(target)||!float.IsFinite(criticalRoll)||criticalRoll is <0 or >1||trace==null)
            throw new InvalidDataException("Invalid LMG projectile authority.");
        float damage=stage.Damage*(criticalRoll<stage.CriticalProbability?binding.CriticalMultiplier:1);
        if(!float.IsFinite(damage)||damage is <0 or >100_000_000)throw new InvalidDataException("Invalid LMG damage authority.");
        return new(new BulletFlight(projectileId,owner,new(binding.Speed,binding.CheckDistance,false),
                authoritativeMuzzle+binding.ShotOffset,target,tick,trace),
            new(damage,CombatDamageType.Shot,HasWeapon:true,FriendKill:binding.FriendKill,
                PlayerCoefficient:stage.PlayerDamageRatio,PlayerOvertimeCoefficient:stage.OvertimePlayerDamageRatio),sourceId);
    }

    public static LmgCatalog Load(string manifestPath)
    {
        byte[] manifestBytes=Read(manifestPath,2,4096);
        var json=new JsonSerializerOptions {UnmappedMemberHandling=JsonUnmappedMemberHandling.Disallow};
        var manifest=JsonSerializer.Deserialize<LmgContentManifest>(manifestBytes,json)??throw new InvalidDataException("Missing LMG manifest.");
        if(manifest.Version!=1||!Hash(manifest.SceneRevision)||!Hash(manifest.StatsRevision)||!Hash(manifest.BindingsRevision))
            throw new InvalidDataException("Invalid LMG content manifest.");
        string directory=Path.GetDirectoryName(Path.GetFullPath(manifestPath))!;
        byte[] source=Read(Path.Combine(directory,"recovered-battle-content.json"),2,16_000_000);
        byte[] bindingBytes=Read(Path.Combine(directory,"recovered-lmg-bindings.json"),2,1_000_000);
        if(Convert.ToHexStringLower(SHA256.HashData(source))!=manifest.StatsRevision||
           Convert.ToHexStringLower(SHA256.HashData(bindingBytes))!=manifest.BindingsRevision)
            throw new InvalidDataException("LMG package revision mismatch.");
        try
        {
            using var sourceDoc=JsonDocument.Parse(source);var root=sourceDoc.RootElement;
            if(root.GetProperty("client").GetString()!="1.4.0"||root.GetProperty("mainSceneSha256").GetString()!=manifest.SceneRevision)
                throw new InvalidDataException("LMG source provenance mismatch.");
            var sheets=root.GetProperty("sheets").EnumerateArray().ToDictionary(x=>x.GetProperty("type").GetString()!,x=>x.GetProperty("rows"),StringComparer.Ordinal);
            var definitions=sheets["Google2u.WeaponUpgrades"].EnumerateArray().ToDictionary(x=>x.GetProperty("NAME").GetString()!,StringComparer.Ordinal);
            var stageRows=new Dictionary<string,LmgStage[]>(StringComparer.Ordinal);
            foreach(var expected in Expected)
            {
                var definition=definitions[expected.Id];var rows=sheets[expected.Id];
                if(rows.GetArrayLength()!=expected.Count||Integer(definition,"BURSTSIZE",1,32)!=2)
                    throw new InvalidDataException("Incomplete LMG upgrade lane.");
                float cadence=Number(definition,"RATEOFFIRE",.01f,60),critical=Number(definition,"CRITICAL",0,1),
                    player=Number(definition,"DAMAGETOPLAYER",0,100),overtime=Number(definition,"DAMAGETOPLAYEROVERTIME",0,100),
                    burstLock=Number(definition,"BURSTLOCKTIME",.01f,60);
                var lane=new LmgStage[expected.Count];int i=0;
                foreach(var row in rows.EnumerateArray())lane[i]=new(expected.Id,i++,Integer(row,"CLIPSIZE",1,1000),
                    Integer(row,"AMMO",0,100000),Number(row,"RELOADTIME",.01f,120),Number(row,"DAMAGE",0,1_000_000),
                    cadence,critical,player,overtime,2,burstLock);
                stageRows.Add(expected.Id,lane);
            }
            using var bindingDoc=JsonDocument.Parse(bindingBytes);var bindingRoot=bindingDoc.RootElement;
            if(bindingRoot.GetProperty("client").GetString()!="1.4.0"||bindingRoot.GetProperty("source").GetString()!="Assets/Scenes/MainScene.unity"||
               bindingRoot.GetProperty("sha256").GetString()!=manifest.SceneRevision||bindingRoot.GetProperty("weaponCount").GetInt32()!=8)
                throw new InvalidDataException("LMG binding provenance mismatch.");
            uint allies=unchecked((uint)bindingRoot.GetProperty("alliesBulletMask").GetInt32()),
                enemies=unchecked((uint)bindingRoot.GetProperty("enemiesBulletMask").GetInt32());
            if(allies==0||enemies==0)throw new InvalidDataException("Missing LMG bullet masks.");
            var bindingRows=new Dictionary<string,LmgBinding>(StringComparer.Ordinal);var indexes=new HashSet<int>();
            foreach(var row in bindingRoot.GetProperty("weapons").EnumerateArray())
            {
                string id=row.GetProperty("id").GetString()??"";int index=row.GetProperty("inventoryIndex").GetInt32();
                if(!stageRows.ContainsKey(id)||!indexes.Add(index)||row.GetProperty("playerWeaponType").GetString()!="PlayerBurstWeapon"||
                   row.GetProperty("weaponType").GetString()!="LightMachinegun"||row.GetProperty("burst").GetInt32()!=5||
                   row.GetProperty("fast").GetBoolean()||!row.GetProperty("friendKill").GetBoolean()||
                   row.GetProperty("shotType").GetInt32()!=0||row.GetProperty("ignoreLayersMask").GetInt32()!=0||
                   !row.GetProperty("reloadable").GetBoolean()||row.GetProperty("infiniteAmmo").GetBoolean()||
                   row.GetProperty("bulletType").GetString()!="BulletSlow"||row.GetProperty("bulletSource").GetString()!="Assets/GameObject/BulletSlow.prefab")
                    throw new InvalidDataException("Unsupported LMG binding.");
                int family=row.GetProperty("animationFamily").GetInt32();
                if(family is not (9 or 15))throw new InvalidDataException("Unsupported LMG animation family.");
                string muzzle=row.GetProperty("muzzlePath").GetString()??"",bulletRevision=row.GetProperty("bulletSha256").GetString()??"";
                if(muzzle.Length is <1 or >512||!Hash(bulletRevision))throw new InvalidDataException("Invalid LMG asset identity.");
                bindingRows.Add(id,new(id,index,family,Vector(row.GetProperty("shotOffset")),5,
                    Number(row,"lockTimeAfterBurst",.01f,60),Number(row,"firstShotWaitTime",0,10),
                    Number(row,"serializedSpeed",.01f,10000)*Number(row,"speedMultiplier",.01f,100),
                    Number(row,"checkDistance",0,50),Number(row,"criticalMultiplier",1,100),true,
                    muzzle,bulletRevision));
            }
            if(bindingRows.Count!=8||!bindingRows.Keys.ToHashSet(StringComparer.Ordinal).SetEquals(Expected.Select(x=>x.Id)))
                throw new InvalidDataException("Incomplete LMG binding set.");
            return new(stageRows,bindingRows,manifest.SceneRevision,manifest.StatsRevision,manifest.BindingsRevision,allies,enemies);
        }
        catch(Exception e) when(e is JsonException or KeyNotFoundException or InvalidOperationException or FormatException or OverflowException or ArgumentException)
        {throw new InvalidDataException("Malformed LMG content package.",e);}
    }
    private static bool Hash(string? value)=>value!=null&&Regex.IsMatch(value,@"\A[0-9a-f]{64}\z");
    private static byte[] Read(string path,int min,int max){using var stream=File.OpenRead(path);if(stream.Length<min||stream.Length>max)throw new InvalidDataException("Invalid LMG file size.");var bytes=new byte[checked((int)stream.Length)];stream.ReadExactly(bytes);return bytes;}
    private static float Number(JsonElement row,string key,float min,float max){float value=row.GetProperty(key).GetSingle();if(!float.IsFinite(value)||value<min||value>max)throw new InvalidDataException("Invalid LMG number.");return value;}
    private static int Integer(JsonElement row,string key,int min,int max){if(!row.GetProperty(key).TryGetInt32(out int value)||value<min||value>max)throw new InvalidDataException("Invalid LMG integer.");return value;}
    private static Vector3 Vector(JsonElement value){if(value.GetArrayLength()!=3)throw new InvalidDataException("Invalid LMG vector.");var result=new Vector3(value[0].GetSingle(),value[1].GetSingle(),value[2].GetSingle());if(!float.IsFinite(result.X)||!float.IsFinite(result.Y)||!float.IsFinite(result.Z))throw new InvalidDataException("Invalid LMG vector.");return result;}
}

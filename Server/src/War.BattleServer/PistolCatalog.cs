using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace War.BattleServer;

public sealed record PistolStage(string SourceId,int Index,int ClipSize,float ReloadSeconds,float Damage,float CadenceSeconds,
    float CriticalProbability,float PlayerDamageRatio,float OvertimePlayerDamageRatio);
public sealed record PistolBinding(string SourceId,int InventoryIndex,int AnimationFamily,Vector3 ShotOffset,float FirstShotWaitSeconds,
    float Speed,float CheckDistance,float CriticalMultiplier,bool FriendKill,string MuzzlePath,string BulletRevision);
public sealed record PistolContentManifest(int Version,string SceneRevision,string StatsRevision,string BindingsRevision);

public sealed class PistolCatalog
{
    private static readonly (string Id,int Count)[] Expected=[("Google2u.Pistol_Berreta",36),("Google2u.Pistol_DesertEagle",66),
        ("Google2u.Pistol_Jester",76),("Google2u.Pistol_M1911",46),("Google2u.Pistol_Magnum357",56),("Google2u.Pistol_Remmington51",26)];
    private readonly IReadOnlyDictionary<string,PistolStage[]> stages;private readonly IReadOnlyDictionary<string,PistolBinding> bindings;
    public string SceneRevision{get;}public string StatsRevision{get;}public string BindingsRevision{get;}public string PackageRevision{get;}
    public uint AlliesBulletMask{get;}public uint EnemiesBulletMask{get;}public int WeaponCount=>bindings.Count;public int StageCount=>stages.Values.Sum(x=>x.Length);
    public IReadOnlyCollection<PistolBinding> Bindings=>Array.AsReadOnly(Expected.Select(x=>Binding(x.Id)).ToArray());
    private PistolCatalog(Dictionary<string,PistolStage[]> stages,Dictionary<string,PistolBinding> bindings,string scene,string stats,string binding,uint allies,uint enemies)
    {this.stages=stages;this.bindings=bindings;SceneRevision=scene;StatsRevision=stats;BindingsRevision=binding;AlliesBulletMask=allies;EnemiesBulletMask=enemies;
     PackageRevision=Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes("WarFriends/pistol-content/v1\n"+scene+"\n"+stats+"\n"+binding)));}
    public PistolStage Stage(string id,int index)=>stages.TryGetValue(id,out var lane)&&index>=0&&index<lane.Length?lane[index]:throw new InvalidDataException("Unsupported pistol stage.");
    public PistolBinding Binding(string id)=>bindings.TryGetValue(id,out var row)?row:throw new InvalidDataException("Unsupported pistol binding.");
    public WeaponManifest CreateManifest(string id,int index){var s=Stage(id,index);return new(id,s.ClipSize,int.MaxValue,s.CadenceSeconds,s.ReloadSeconds);}
    internal PreparedProjectile Prepare(string id,int upgrade,ulong projectileId,string owner,Vector3 muzzle,Vector3 target,ulong tick,float roll,Func<Vector3,Vector3,float,ShotCollision?> trace)
    {
        var stage=Stage(id,upgrade);var binding=Binding(id);
        if(projectileId==0||string.IsNullOrEmpty(owner)||!PlayerHitbox.Finite(muzzle)||!PlayerHitbox.Finite(target)||!float.IsFinite(roll)||roll is <0 or >1||trace==null)
            throw new InvalidDataException("Invalid pistol projectile authority.");
        float damage=stage.Damage*(roll<stage.CriticalProbability?binding.CriticalMultiplier:1);
        return new(new BulletFlight(projectileId,owner,new(binding.Speed,binding.CheckDistance,false),muzzle+binding.ShotOffset,target,tick,trace),
            new(damage,CombatDamageType.Shot,HasWeapon:true,FriendKill:binding.FriendKill,PlayerCoefficient:stage.PlayerDamageRatio,
                PlayerOvertimeCoefficient:stage.OvertimePlayerDamageRatio),id);
    }
    public static PistolCatalog Load(string manifestPath)
    {
        byte[] manifestBytes=Read(manifestPath,4096);var options=new JsonSerializerOptions{UnmappedMemberHandling=JsonUnmappedMemberHandling.Disallow};
        var manifest=JsonSerializer.Deserialize<PistolContentManifest>(manifestBytes,options)??throw new InvalidDataException("Missing pistol manifest.");
        if(manifest.Version!=1||!Hash(manifest.SceneRevision)||!Hash(manifest.StatsRevision)||!Hash(manifest.BindingsRevision))throw new InvalidDataException("Invalid pistol manifest.");
        string dir=Path.GetDirectoryName(Path.GetFullPath(manifestPath))!;byte[] statsBytes=Read(Path.Combine(dir,"recovered-battle-content.json"),32_000_000);
        byte[] bindingBytes=Read(Path.Combine(dir,"recovered-pistol-bindings.json"),262_144);
        if(Digest(statsBytes)!=manifest.StatsRevision||Digest(bindingBytes)!=manifest.BindingsRevision)throw new InvalidDataException("Pistol package hash mismatch.");
        try
        {
            using var statsDoc=JsonDocument.Parse(statsBytes);using var bindingDoc=JsonDocument.Parse(bindingBytes);var root=statsDoc.RootElement;var bindingRoot=bindingDoc.RootElement;
            if(root.GetProperty("client").GetString()!="1.4.0"||root.GetProperty("mainSceneSha256").GetString()!=manifest.SceneRevision||
               bindingRoot.GetProperty("client").GetString()!="1.4.0"||bindingRoot.GetProperty("sha256").GetString()!=manifest.SceneRevision||
               bindingRoot.GetProperty("weaponCount").GetInt32()!=6)throw new InvalidDataException("Pistol provenance mismatch.");
            var sheets=root.GetProperty("sheets").EnumerateArray().ToDictionary(x=>x.GetProperty("type").GetString()!,x=>x.GetProperty("rows"),StringComparer.Ordinal);
            var definitions=sheets["Google2u.WeaponUpgrades"].EnumerateArray().ToDictionary(x=>x.GetProperty("NAME").GetString()!,StringComparer.Ordinal);
            var stageRows=new Dictionary<string,PistolStage[]>(StringComparer.Ordinal);
            foreach(var expected in Expected)
            {
                var definition=definitions[expected.Id];var rows=sheets[expected.Id];if(rows.GetArrayLength()!=expected.Count)throw new InvalidDataException("Incomplete pistol lane.");
                float cadence=Number(definition,"RATEOFFIRE",.01f,60),critical=Number(definition,"CRITICAL",0,1),player=Number(definition,"DAMAGETOPLAYER",0,100),overtime=Number(definition,"DAMAGETOPLAYEROVERTIME",0,100);
                var lane=new PistolStage[expected.Count];int i=0;foreach(var row in rows.EnumerateArray())lane[i]=new(expected.Id,i++,Integer(row,"CLIPSIZE",1,1000),
                    Number(row,"RELOADTIME",.01f,120),Number(row,"DAMAGE",0,1_000_000),cadence,critical,player,overtime);stageRows.Add(expected.Id,lane);
            }
            uint allies=unchecked((uint)bindingRoot.GetProperty("alliesBulletMask").GetInt32()),enemies=unchecked((uint)bindingRoot.GetProperty("enemiesBulletMask").GetInt32());
            var bindingRows=new Dictionary<string,PistolBinding>(StringComparer.Ordinal);var indexes=new HashSet<int>();
            foreach(var row in bindingRoot.GetProperty("weapons").EnumerateArray())
            {
                string id=row.GetProperty("id").GetString()??"";int index=row.GetProperty("inventoryIndex").GetInt32();string muzzle=row.GetProperty("muzzlePath").GetString()??"",bullet=row.GetProperty("bulletSha256").GetString()??"";
                if(!stageRows.ContainsKey(id)||!indexes.Add(index)||row.GetProperty("playerWeaponType").GetString()!="PlayerClickWeapon"||row.GetProperty("weaponType").GetString()!="Pistol"||
                   row.GetProperty("animationFamily").GetInt32()!=5||row.GetProperty("autofire").GetBoolean()||row.GetProperty("showScope").GetBoolean()||
                   !row.GetProperty("reloadable").GetBoolean()||row.GetProperty("infiniteAmmo").GetBoolean()||row.GetProperty("pistolReserveOverride").GetInt32()!=int.MaxValue||
                   row.GetProperty("bulletType").GetString()!="BulletSlow"||muzzle.Length is <1 or >512||!Hash(bullet))throw new InvalidDataException("Unsupported pistol binding.");
                bindingRows.Add(id,new(id,index,5,Vector(row.GetProperty("shotOffset")),Number(row,"firstShotWaitTime",0,10),
                    Number(row,"serializedSpeed",.01f,10000)*Number(row,"speedMultiplier",.01f,100),Number(row,"checkDistance",0,50),
                    Number(row,"criticalMultiplier",1,100),row.GetProperty("friendKill").GetBoolean(),muzzle,bullet));
            }
            if(bindingRows.Count!=6||!bindingRows.Keys.ToHashSet(StringComparer.Ordinal).SetEquals(Expected.Select(x=>x.Id)))throw new InvalidDataException("Incomplete pistol bindings.");
            return new(stageRows,bindingRows,manifest.SceneRevision,manifest.StatsRevision,manifest.BindingsRevision,allies,enemies);
        }
        catch(Exception e)when(e is JsonException or KeyNotFoundException or InvalidOperationException or FormatException or OverflowException or ArgumentException){throw new InvalidDataException("Malformed pistol package.",e);}
    }
    private static string Digest(byte[] value)=>Convert.ToHexStringLower(SHA256.HashData(value));private static bool Hash(string? value)=>value!=null&&Regex.IsMatch(value,@"\A[0-9a-f]{64}\z");
    private static byte[] Read(string path,int max){using var stream=File.OpenRead(path);if(stream.Length<2||stream.Length>max)throw new InvalidDataException("Invalid pistol file size.");var bytes=new byte[checked((int)stream.Length)];stream.ReadExactly(bytes);return bytes;}
    private static float Number(JsonElement row,string key,float min,float max){float value=row.GetProperty(key).GetSingle();if(!float.IsFinite(value)||value<min||value>max)throw new InvalidDataException("Invalid pistol number.");return value;}
    private static int Integer(JsonElement row,string key,int min,int max){if(!row.GetProperty(key).TryGetInt32(out int value)||value<min||value>max)throw new InvalidDataException("Invalid pistol integer.");return value;}
    private static Vector3 Vector(JsonElement e){if(e.ValueKind!=JsonValueKind.Array||e.GetArrayLength()!=3)throw new InvalidDataException("Invalid pistol vector.");var value=new Vector3(e[0].GetSingle(),e[1].GetSingle(),e[2].GetSingle());if(!PlayerHitbox.Finite(value))throw new InvalidDataException("Invalid pistol vector.");return value;}
}

using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace War.BattleServer;

public sealed record MinigunStage(string SourceId,int Index,int Ammo,float Damage,float CadenceSeconds,
    float HeatSeconds,float CriticalProbability,float PlayerDamageRatio,float OvertimePlayerDamageRatio);
public sealed record MinigunBinding(string SourceId,int InventoryIndex,int AnimationFamily,Vector3 ShotOffset,
    float SpinUpSeconds,float SerializedCoolDownSeconds,float LockTimeAfterBurst,float FirstShotWaitSeconds,
    float Speed,float CheckDistance,float CriticalMultiplier,bool FriendKill,string MuzzlePath,string BulletRevision);
public sealed record MinigunContentManifest(int Version,string SceneRevision,string StatsRevision,string BindingsRevision);

/// <summary>Immutable source package for Google2u.LMG_Minigun.</summary>
public sealed class MinigunCatalog
{
    public const string SourceId="Google2u.LMG_Minigun";
    private readonly MinigunStage[] stages;
    public MinigunBinding Binding {get;}
    public string SceneRevision {get;}
    public string StatsRevision {get;}
    public string BindingsRevision {get;}
    public string PackageRevision {get;}
    public uint AlliesBulletMask {get;}
    public uint EnemiesBulletMask {get;}
    public int StageCount=>stages.Length;
    private MinigunCatalog(MinigunStage[] stages,MinigunBinding binding,string scene,string stats,string bindings,uint allies,uint enemies)
    {this.stages=stages;Binding=binding;SceneRevision=scene;StatsRevision=stats;BindingsRevision=bindings;AlliesBulletMask=allies;EnemiesBulletMask=enemies;
     PackageRevision=Convert.ToHexStringLower(SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(
         "WarFriends/minigun-content/v1\n"+scene+"\n"+stats+"\n"+bindings)));}
    public MinigunStage Stage(int upgrade)=>upgrade>=0&&upgrade<stages.Length?stages[upgrade]:throw new InvalidDataException("Unsupported minigun upgrade index.");
    // The recovered non-reloadable Weapon reads ammoLeft, not ammoLeftInClip.
    // MatchEngine's single active pool is ClipSize; ReserveAmmo stays zero so it can never reload.
    public WeaponManifest CreateManifest(int upgrade)
    {var row=Stage(upgrade);return new(SourceId,row.Ammo,0,row.CadenceSeconds,5);}
    internal PreparedProjectile Prepare(int upgrade,ulong projectileId,string owner,Vector3 muzzle,Vector3 target,ulong tick,
        float criticalRoll,Func<Vector3,Vector3,float,ShotCollision?> trace)
    {
        var stage=Stage(upgrade);
        if(projectileId==0||string.IsNullOrEmpty(owner)||!PlayerHitbox.Finite(muzzle)||!PlayerHitbox.Finite(target)||
           !float.IsFinite(criticalRoll)||criticalRoll is <0 or >1||trace==null)throw new InvalidDataException("Invalid minigun projectile authority.");
        float damage=stage.Damage*(criticalRoll<stage.CriticalProbability?Binding.CriticalMultiplier:1);
        return new(new BulletFlight(projectileId,owner,new(Binding.Speed,Binding.CheckDistance,false),muzzle+Binding.ShotOffset,target,tick,trace),
            new(damage,CombatDamageType.Shot,HasWeapon:true,FriendKill:Binding.FriendKill,
                PlayerCoefficient:stage.PlayerDamageRatio,PlayerOvertimeCoefficient:stage.OvertimePlayerDamageRatio),SourceId);
    }
    public static MinigunCatalog Load(string manifestPath)
    {
        var json=new JsonSerializerOptions{UnmappedMemberHandling=JsonUnmappedMemberHandling.Disallow};
        byte[] mb=Read(manifestPath,2,4096);var manifest=JsonSerializer.Deserialize<MinigunContentManifest>(mb,json)??throw new InvalidDataException("Missing minigun manifest.");
        if(manifest.Version!=1||!Hash(manifest.SceneRevision)||!Hash(manifest.StatsRevision)||!Hash(manifest.BindingsRevision))throw new InvalidDataException("Invalid minigun manifest.");
        string dir=Path.GetDirectoryName(Path.GetFullPath(manifestPath))!;
        byte[] source=Read(Path.Combine(dir,"recovered-battle-content.json"),2,16_000_000),bindingBytes=Read(Path.Combine(dir,"recovered-minigun-binding.json"),2,200_000);
        if(Convert.ToHexStringLower(SHA256.HashData(source))!=manifest.StatsRevision||Convert.ToHexStringLower(SHA256.HashData(bindingBytes))!=manifest.BindingsRevision)throw new InvalidDataException("Minigun package revision mismatch.");
        try
        {
            using var sd=JsonDocument.Parse(source);var root=sd.RootElement;
            if(root.GetProperty("client").GetString()!="1.4.0"||root.GetProperty("mainSceneSha256").GetString()!=manifest.SceneRevision)throw new InvalidDataException("Minigun source provenance mismatch.");
            var sheets=root.GetProperty("sheets").EnumerateArray().ToDictionary(x=>x.GetProperty("type").GetString()!,x=>x.GetProperty("rows"),StringComparer.Ordinal);
            var definition=sheets["Google2u.WeaponUpgrades"].EnumerateArray().Single(x=>x.GetProperty("NAME").GetString()==SourceId);
            float cadence=Number(definition,"RATEOFFIRE",.01f,60),critical=Number(definition,"CRITICAL",0,1),
                player=Number(definition,"DAMAGETOPLAYER",0,100),overtime=Number(definition,"DAMAGETOPLAYEROVERTIME",0,100);
            var rows=sheets[SourceId];if(rows.GetArrayLength()!=36)throw new InvalidDataException("Incomplete minigun lane.");
            var stages=new MinigunStage[36];int i=0;
            foreach(var row in rows.EnumerateArray())stages[i]=new(SourceId,i++,Integer(row,"AMMO",1,100000),Number(row,"DAMAGE",0,1_000_000),cadence,Number(row,"HEATTIME",.01f,60),critical,player,overtime);
            using var bd=JsonDocument.Parse(bindingBytes);var br=bd.RootElement;var w=br.GetProperty("weapon");
            if(br.GetProperty("client").GetString()!="1.4.0"||br.GetProperty("source").GetString()!="Assets/Scenes/MainScene.unity"||br.GetProperty("sha256").GetString()!=manifest.SceneRevision||
               w.GetProperty("id").GetString()!=SourceId||w.GetProperty("inventoryIndex").GetInt32()!=25||w.GetProperty("playerWeaponType").GetString()!="PlayerMinigunWeapon"||
               w.GetProperty("weaponType").GetString()!="LightMachinegun"||w.GetProperty("animationFamily").GetInt32()!=4||w.GetProperty("reloadable").GetBoolean()||w.GetProperty("infiniteAmmo").GetBoolean()||
               w.GetProperty("motorType").GetString()!="PlayerMinigunWeaponMotor"||!w.GetProperty("friendKill").GetBoolean()||w.GetProperty("bulletType").GetString()!="BulletSlow")
                throw new InvalidDataException("Unsupported minigun binding.");
            uint allies=unchecked((uint)br.GetProperty("alliesBulletMask").GetInt32()),enemies=unchecked((uint)br.GetProperty("enemiesBulletMask").GetInt32());
            string muzzle=w.GetProperty("muzzlePath").GetString()??"",bullet=w.GetProperty("bulletSha256").GetString()??"";
            if(allies==0||enemies==0||muzzle.Length is <1 or >512||!Hash(bullet))throw new InvalidDataException("Invalid minigun asset authority.");
            var binding=new MinigunBinding(SourceId,25,4,Vector(w.GetProperty("shotOffset")),Number(w,"waitTime",0,10),Number(w,"serializedCoolDown",.01f,60),
                Number(w,"lockTimeAfterBurst",0,10),Number(w,"firstShotWaitTime",0,10),Number(w,"serializedSpeed",.01f,10000)*Number(w,"speedMultiplier",.01f,100),
                Number(w,"checkDistance",0,50),Number(w,"criticalMultiplier",1,100),true,muzzle,bullet);
            return new(stages,binding,manifest.SceneRevision,manifest.StatsRevision,manifest.BindingsRevision,allies,enemies);
        }
        catch(Exception e) when(e is JsonException or KeyNotFoundException or InvalidOperationException or FormatException or OverflowException or ArgumentException)
        {throw new InvalidDataException("Malformed minigun package.",e);}
    }
    private static bool Hash(string? value)=>value!=null&&Regex.IsMatch(value,@"\A[0-9a-f]{64}\z");
    private static byte[] Read(string path,int min,int max){using var s=File.OpenRead(path);if(s.Length<min||s.Length>max)throw new InvalidDataException("Invalid minigun file size.");var b=new byte[checked((int)s.Length)];s.ReadExactly(b);return b;}
    private static float Number(JsonElement row,string key,float min,float max){float v=row.GetProperty(key).GetSingle();if(!float.IsFinite(v)||v<min||v>max)throw new InvalidDataException("Invalid minigun number.");return v;}
    private static int Integer(JsonElement row,string key,int min,int max){if(!row.GetProperty(key).TryGetInt32(out int v)||v<min||v>max)throw new InvalidDataException("Invalid minigun integer.");return v;}
    private static Vector3 Vector(JsonElement value){if(value.GetArrayLength()!=3)throw new InvalidDataException("Invalid minigun vector.");var v=new Vector3(value[0].GetSingle(),value[1].GetSingle(),value[2].GetSingle());if(!PlayerHitbox.Finite(v))throw new InvalidDataException("Invalid minigun vector.");return v;}
}

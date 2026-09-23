using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace War.BattleServer;

public sealed record SniperStage(string SourceId,int Index,int ClipSize,int ReserveAmmo,float ReloadSeconds,float Damage,
    float CadenceSeconds,float CriticalProbability,float PlayerDamageRatio,float OvertimePlayerDamageRatio);
public sealed record SniperBinding(string SourceId,int InventoryIndex,int AnimationFamily,Vector3 ShotOffset,float FirstShotWaitSeconds,
    float ScopeShowSeconds,float ZoomThresholdSeconds,float ZoomMovementThreshold,float Fov,int ScopeNumber,float Speed,float CheckDistance,
    float CriticalMultiplier,bool FriendKill,string MuzzlePath,string BulletRevision);
public sealed record SniperContentManifest(int Version,string SceneRevision,string StatsRevision,string BindingsRevision);

public sealed class SniperCatalog
{
    private static readonly (string Id,int Count)[] Expected=[("Google2u.SniperRifle_AWMF",46),("Google2u.SniperRifle_Dragunov",36),
        ("Google2u.SniperRifle_M110",56),("Google2u.SniperRifle_M110Elite",56),("Google2u.SniperRifle_M24",26),
        ("Google2u.SniperRifle_M90",66),("Google2u.SniperRifle_M90Elite",66),("Google2u.SniperRifle_MSR",76)];
    private readonly IReadOnlyDictionary<string,SniperStage[]> stages;private readonly IReadOnlyDictionary<string,SniperBinding> bindings;
    public int WeaponCount=>stages.Count;public int StageCount=>stages.Values.Sum(x=>x.Length);
    public string SceneRevision{get;}public string StatsRevision{get;}public string BindingsRevision{get;}public string PackageRevision{get;}
    public uint AlliesBulletMask{get;}public uint EnemiesBulletMask{get;}
    public IReadOnlyCollection<SniperBinding> Bindings=>Array.AsReadOnly(Expected.Select(x=>Binding(x.Id)).ToArray());
    private SniperCatalog(Dictionary<string,SniperStage[]> stages,Dictionary<string,SniperBinding> bindings,string scene,string stats,string binding,uint allies,uint enemies)
    {this.stages=stages;this.bindings=bindings;SceneRevision=scene;StatsRevision=stats;BindingsRevision=binding;AlliesBulletMask=allies;EnemiesBulletMask=enemies;
     PackageRevision=Convert.ToHexStringLower(SHA256.HashData(System.Text.Encoding.UTF8.GetBytes("WarFriends/sniper-content/v1\n"+scene+"\n"+stats+"\n"+binding)));}
    public SniperStage Stage(string id,int index)=>stages.TryGetValue(id,out var lane)&&index>=0&&index<lane.Length?lane[index]:throw new InvalidDataException("Unsupported sniper stage.");
    public SniperBinding Binding(string id)=>bindings.TryGetValue(id,out var row)?row:throw new InvalidDataException("Unsupported sniper binding.");
    public WeaponManifest CreateManifest(string id,int upgrade){var s=Stage(id,upgrade);return new(id,s.ClipSize,s.ReserveAmmo,s.CadenceSeconds,s.ReloadSeconds);}
    internal PreparedProjectile Prepare(string id,int upgrade,ulong projectileId,string owner,Vector3 muzzle,Vector3 target,ulong tick,float roll,Func<Vector3,Vector3,float,ShotCollision?> trace)
    {var s=Stage(id,upgrade);var b=Binding(id);if(projectileId==0||string.IsNullOrEmpty(owner)||!PlayerHitbox.Finite(muzzle)||!PlayerHitbox.Finite(target)||!float.IsFinite(roll)||roll is <0 or >1||trace==null)throw new InvalidDataException("Invalid sniper projectile authority.");
     float damage=s.Damage*(roll<s.CriticalProbability?b.CriticalMultiplier:1);return new(new(projectileId,owner,new(b.Speed,b.CheckDistance,false),muzzle+b.ShotOffset,target,tick,trace),
        new(damage,CombatDamageType.Shot,HasWeapon:true,FriendKill:b.FriendKill,PlayerCoefficient:s.PlayerDamageRatio,PlayerOvertimeCoefficient:s.OvertimePlayerDamageRatio),id);}
    public static SniperCatalog Load(string path)
    {
        var options=new JsonSerializerOptions{UnmappedMemberHandling=JsonUnmappedMemberHandling.Disallow};byte[] mb=Read(path,2,4096);
        var manifest=JsonSerializer.Deserialize<SniperContentManifest>(mb,options)??throw new InvalidDataException("Missing sniper manifest.");
        if(manifest.Version!=1||!Hash(manifest.SceneRevision)||!Hash(manifest.StatsRevision)||!Hash(manifest.BindingsRevision))throw new InvalidDataException("Invalid sniper manifest.");
        string dir=Path.GetDirectoryName(Path.GetFullPath(path))!;byte[] statsBytes=Read(Path.Combine(dir,"recovered-battle-content.json"),2,16_000_000),bindingBytes=Read(Path.Combine(dir,"recovered-sniper-bindings.json"),2,1_000_000);
        if(Digest(statsBytes)!=manifest.StatsRevision||Digest(bindingBytes)!=manifest.BindingsRevision)throw new InvalidDataException("Sniper package hash mismatch.");
        try
        {
            using var sd=JsonDocument.Parse(statsBytes);var root=sd.RootElement;if(root.GetProperty("client").GetString()!="1.4.0"||root.GetProperty("mainSceneSha256").GetString()!=manifest.SceneRevision)throw new InvalidDataException("Sniper source provenance mismatch.");
            var sheets=root.GetProperty("sheets").EnumerateArray().ToDictionary(x=>x.GetProperty("type").GetString()!,x=>x.GetProperty("rows"),StringComparer.Ordinal);
            var defs=sheets["Google2u.WeaponUpgrades"].EnumerateArray().ToDictionary(x=>x.GetProperty("NAME").GetString()!,StringComparer.Ordinal);var stageRows=new Dictionary<string,SniperStage[]>(StringComparer.Ordinal);
            foreach(var expected in Expected)
            {var d=defs[expected.Id];var rows=sheets[expected.Id];if(rows.GetArrayLength()!=expected.Count)throw new InvalidDataException("Incomplete sniper lane.");
             float cadence=Number(d,"RATEOFFIRE",.01f,60),critical=Number(d,"CRITICAL",0,1),player=Number(d,"DAMAGETOPLAYER",0,100),overtime=Number(d,"DAMAGETOPLAYEROVERTIME",0,100);
             var lane=new SniperStage[expected.Count];int i=0;foreach(var row in rows.EnumerateArray())lane[i]=new(expected.Id,i++,Integer(row,"CLIPSIZE",1,1000),Integer(row,"AMMO",0,100000),Number(row,"RELOADTIME",.01f,120),Number(row,"DAMAGE",0,1_000_000),cadence,critical,player,overtime);stageRows.Add(expected.Id,lane);}
            using var bd=JsonDocument.Parse(bindingBytes);var br=bd.RootElement;if(br.GetProperty("client").GetString()!="1.4.0"||br.GetProperty("sha256").GetString()!=manifest.SceneRevision||br.GetProperty("weaponCount").GetInt32()!=8)throw new InvalidDataException("Sniper binding provenance mismatch.");
            uint allies=unchecked((uint)br.GetProperty("alliesBulletMask").GetInt32()),enemies=unchecked((uint)br.GetProperty("enemiesBulletMask").GetInt32());var bindingRows=new Dictionary<string,SniperBinding>(StringComparer.Ordinal);var indexes=new HashSet<int>();
            foreach(var row in br.GetProperty("weapons").EnumerateArray())
            {string id=row.GetProperty("id").GetString()??"";int index=row.GetProperty("inventoryIndex").GetInt32();if(!stageRows.ContainsKey(id)||!indexes.Add(index)||row.GetProperty("playerWeaponType").GetString()!="PlayerZoomOnTouchWeapon"||row.GetProperty("weaponType").GetString()!="OneShotRifle"||row.GetProperty("animationFamily").GetInt32()!=10||!row.GetProperty("reloadable").GetBoolean()||row.GetProperty("infiniteAmmo").GetBoolean()||row.GetProperty("fast").GetBoolean()||!row.GetProperty("friendKill").GetBoolean()||row.GetProperty("bulletType").GetString()!="BulletSlow")throw new InvalidDataException("Unsupported sniper binding.");
             string muzzle=row.GetProperty("muzzlePath").GetString()??"",bullet=row.GetProperty("bulletSha256").GetString()??"";if(muzzle.Length is <1 or >512||!Hash(bullet))throw new InvalidDataException("Invalid sniper asset identity.");
             bindingRows.Add(id,new(id,index,10,Vector(row.GetProperty("shotOffset")),Number(row,"firstShotWaitTime",0,10),.17f,Number(row,"zoomTresholdTime",0,10),Number(row,"zoomTresholdSqrDistance",0,1_000_000),Number(row,"serializedFov",.1f,180),Integer(row,"scopeNum",0,16),Number(row,"serializedSpeed",.01f,10000)*Number(row,"speedMultiplier",.01f,100),Number(row,"checkDistance",0,50),Number(row,"criticalMultiplier",1,100),true,muzzle,bullet));}
            if(bindingRows.Count!=8||!bindingRows.Keys.ToHashSet(StringComparer.Ordinal).SetEquals(Expected.Select(x=>x.Id))||allies==0||enemies==0)throw new InvalidDataException("Incomplete sniper bindings.");
            return new(stageRows,bindingRows,manifest.SceneRevision,manifest.StatsRevision,manifest.BindingsRevision,allies,enemies);
        }
        catch(Exception e)when(e is JsonException or KeyNotFoundException or InvalidOperationException or FormatException or OverflowException or ArgumentException){throw new InvalidDataException("Malformed sniper package.",e);}
    }
    private static string Digest(byte[] b)=>Convert.ToHexStringLower(SHA256.HashData(b));private static bool Hash(string? s)=>s!=null&&Regex.IsMatch(s,@"\A[0-9a-f]{64}\z");
    private static byte[] Read(string p,int min,int max){using var s=File.OpenRead(p);if(s.Length<min||s.Length>max)throw new InvalidDataException("Invalid sniper file size.");var b=new byte[checked((int)s.Length)];s.ReadExactly(b);return b;}
    private static float Number(JsonElement e,string k,float min,float max){float v=e.GetProperty(k).GetSingle();if(!float.IsFinite(v)||v<min||v>max)throw new InvalidDataException("Invalid sniper number.");return v;}
    private static int Integer(JsonElement e,string k,int min,int max){if(!e.GetProperty(k).TryGetInt32(out int v)||v<min||v>max)throw new InvalidDataException("Invalid sniper integer.");return v;}
    private static Vector3 Vector(JsonElement e){if(e.GetArrayLength()!=3)throw new InvalidDataException("Invalid sniper vector.");var v=new Vector3(e[0].GetSingle(),e[1].GetSingle(),e[2].GetSingle());if(!PlayerHitbox.Finite(v))throw new InvalidDataException("Invalid sniper vector.");return v;}
}

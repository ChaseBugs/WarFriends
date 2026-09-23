using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace War.BattleServer;

public enum RecoveredGrenadeEffect { Frag=0,Molotov=4 }
public sealed record GrenadeStage(string SourceId,int Index,int Ammo,float CadenceSeconds,float ExplosionDamage,
    float MinimumDamage,float DeadRadius,float HurtRadius,float PlayerDamageRatio,float OvertimePlayerDamageRatio,
    float BehindShieldRatio);
public sealed record GrenadeSwipeBinding(float MaxDistance,float MaxDistanceShot,float MaxThrowTime,float MinDistance,
    float MinDistanceShot,float MinThrowTime,float ThrowFactor,float DistanceThreshold,string LeftMuzzlePath,string RightMuzzlePath);
public sealed record GrenadeBinding(string SourceId,int InventoryIndex,int AnimationFamily,bool Swipe,float FirstShotWaitSeconds,
    Vector3 ShootOffset,string MuzzlePath,float Angle,float ThrowDistance,float FuseSeconds,float BehindShieldRatio,
    Vector3 ExplosionCoefficient,float AdditionalUpForce,RecoveredGrenadeEffect Effect,GrenadeSwipeBinding? SwipeInput,string BulletRevision);
public sealed record GrenadeContentManifest(int Version,string SceneRevision,string StatsRevision,string BindingsRevision,string PosesRevision);

public sealed class GrenadeCatalog
{
    private static readonly (string Id,int Count,int Index,bool Swipe)[] Expected=
    [
        ("Google2u.GrenadeLauncher_M320",36,19,false),("Google2u.Grenade_FLASH",36,7,true),
        ("Google2u.Grenade_FRAG",26,5,true),("Google2u.Grenade_M84",76,53,true),
        ("Google2u.Grenade_Molotov",66,40,true),("Google2u.Grenade_POISON",46,8,true),
        ("Google2u.Grenade_SMOKE",56,6,true),("Google2u.Grenade_SMOKEElite",56,62,true)
    ];
    private readonly IReadOnlyDictionary<string,GrenadeStage[]> stages;
    private readonly IReadOnlyDictionary<string,GrenadeBinding> bindings;
    public int WeaponCount=>stages.Count;public int StageCount=>stages.Values.Sum(x=>x.Length);
    public string SceneRevision{get;}public string StatsRevision{get;}public string BindingsRevision{get;}public string PackageRevision{get;}
    internal GrenadePoseCatalog Poses{get;}
    public uint AlliesBulletMask{get;}public uint EnemiesBulletMask{get;}public uint DestroyableMask{get;}
    public IReadOnlyCollection<GrenadeBinding> Bindings=>Array.AsReadOnly(Expected.Select(x=>Binding(x.Id)).ToArray());
    private GrenadeCatalog(Dictionary<string,GrenadeStage[]> stages,Dictionary<string,GrenadeBinding> bindings,
        string scene,string stats,string binding,uint allies,uint enemies,uint destroyable,GrenadePoseCatalog poses)
    {this.stages=stages;this.bindings=bindings;SceneRevision=scene;StatsRevision=stats;BindingsRevision=binding;
     AlliesBulletMask=allies;EnemiesBulletMask=enemies;DestroyableMask=destroyable;Poses=poses;
     PackageRevision=Convert.ToHexStringLower(SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(
         "WarFriends/grenade-content/v2\n"+scene+"\n"+stats+"\n"+binding+"\n"+poses.Revision)));}
    public GrenadeStage Stage(string id,int index)=>stages.TryGetValue(id,out var lane)&&index>=0&&index<lane.Length?lane[index]:
        throw new InvalidDataException("Unsupported grenade stage.");
    public GrenadeBinding Binding(string id)=>bindings.TryGetValue(id,out var row)?row:throw new InvalidDataException("Unsupported grenade binding.");
    public WeaponManifest CreateManifest(string id,int upgrade){var s=Stage(id,upgrade);return new(id,s.Ammo,0,s.CadenceSeconds,s.CadenceSeconds);}

    public static GrenadeCatalog Load(string path)
    {
        var options=new JsonSerializerOptions{UnmappedMemberHandling=JsonUnmappedMemberHandling.Disallow};byte[] mb=Read(path,2,4096);
        var manifest=JsonSerializer.Deserialize<GrenadeContentManifest>(mb,options)??throw new InvalidDataException("Missing grenade manifest.");
        if(manifest.Version!=2||!Hash(manifest.SceneRevision)||!Hash(manifest.StatsRevision)||!Hash(manifest.BindingsRevision)||!Hash(manifest.PosesRevision))
            throw new InvalidDataException("Invalid grenade manifest.");
        string dir=Path.GetDirectoryName(Path.GetFullPath(path))!;byte[] statsBytes=Read(Path.Combine(dir,"recovered-battle-content.json"),2,16_000_000),
            bindingBytes=Read(Path.Combine(dir,"recovered-grenade-bindings.json"),2,2_000_000);
        if(Digest(statsBytes)!=manifest.StatsRevision||Digest(bindingBytes)!=manifest.BindingsRevision)
            throw new InvalidDataException("Grenade package hash mismatch.");
        try
        {
            using var sd=JsonDocument.Parse(statsBytes);var root=sd.RootElement;
            if(root.GetProperty("client").GetString()!="1.4.0"||root.GetProperty("mainSceneSha256").GetString()!=manifest.SceneRevision)
                throw new InvalidDataException("Grenade source provenance mismatch.");
            var sheets=root.GetProperty("sheets").EnumerateArray().ToDictionary(x=>x.GetProperty("type").GetString()!,x=>x.GetProperty("rows"),StringComparer.Ordinal);
            var definitions=sheets["Google2u.WeaponUpgrades"].EnumerateArray().ToDictionary(x=>x.GetProperty("NAME").GetString()!,StringComparer.Ordinal);
            var lanes=new Dictionary<string,GrenadeStage[]>(StringComparer.Ordinal);
            foreach(var expected in Expected)
            {
                var definition=definitions[expected.Id];var rows=sheets[expected.Id];
                if(rows.GetArrayLength()!=expected.Count||Number(definition,"CRITICAL",0,1)!=0)throw new InvalidDataException("Incomplete grenade lane.");
                float player=Number(definition,"DAMAGETOPLAYER",0,100),overtime=Number(definition,"DAMAGETOPLAYEROVERTIME",0,100),
                    behind=Number(definition,"DAMAGETOPLAYERBEHINDSHIELD",0,100);
                var lane=new GrenadeStage[expected.Count];int i=0;
                foreach(var row in rows.EnumerateArray())
                {
                    float dead=row.TryGetProperty("DEADRADIUS",out var radius)?Number(radius,.01f,100):1f;
                    lane[i]=new(expected.Id,i++,Integer(row,"AMMO",1,100000),Number(row,"RELOADTIME",.01f,120),
                        Number(row,"EXPLODEDAMAGE",0,1_000_000),Number(row,"MINDAMAGE",0,1_000_000),dead,
                        row.TryGetProperty("DEADRADIUS",out _)?dead*1.5f:1.7f,player,overtime,behind);
                }
                lanes.Add(expected.Id,lane);
            }
            using var bd=JsonDocument.Parse(bindingBytes);var br=bd.RootElement;
            if(br.GetProperty("client").GetString()!="1.4.0"||br.GetProperty("sha256").GetString()!=manifest.SceneRevision||
               br.GetProperty("weaponCount").GetInt32()!=8)throw new InvalidDataException("Grenade binding provenance mismatch.");
            uint allies=unchecked((uint)br.GetProperty("alliesBulletMask").GetInt32()),enemies=unchecked((uint)br.GetProperty("enemiesBulletMask").GetInt32()),
                destroyable=unchecked((uint)br.GetProperty("destroyableMask").GetInt32());
            var bindingRows=new Dictionary<string,GrenadeBinding>(StringComparer.Ordinal);var indexes=new HashSet<int>();
            foreach(var row in br.GetProperty("weapons").EnumerateArray())
            {
                string id=row.GetProperty("id").GetString()??"";var expected=Expected.Single(x=>x.Id==id);int index=row.GetProperty("inventoryIndex").GetInt32();
                string controller=row.GetProperty("playerWeaponType").GetString()??"";int family=row.GetProperty("animationFamily").GetInt32();
                if(index!=expected.Index||!indexes.Add(index)||controller!=(expected.Swipe?"PlayerSwipeWeapon":"PlayerClickWeapon")||
                   family!=(expected.Swipe?1:6)||row.GetProperty("weaponType").GetString()!="Grenade"||row.GetProperty("ammoSetupType").GetString()!="GrenadeAmmoSetup"||
                   row.GetProperty("reloadable").GetBoolean()||row.GetProperty("infiniteAmmo").GetBoolean()||!row.GetProperty("friendKill").GetBoolean())
                    throw new InvalidDataException("Unsupported grenade binding.");
                int effect=row.GetProperty("grenadeType").GetInt32();if(effect!=(id=="Google2u.Grenade_Molotov"?4:0))throw new InvalidDataException("Unexpected recovered grenade effect.");
                var explosive=row.GetProperty("explosive");if(explosive.ValueKind!=JsonValueKind.Object)throw new InvalidDataException("Missing grenade explosion setup.");
                GrenadeSwipeBinding? swipe=null;var swipeJson=row.GetProperty("swipe");
                if(expected.Swipe)
                {
                    if(swipeJson.ValueKind!=JsonValueKind.Object)throw new InvalidDataException("Missing grenade swipe authority.");
                    swipe=new(Number(swipeJson,"maxDistance",0,100),Number(swipeJson,"maxDistanceShot",0,100),Number(swipeJson,"maxThrowTime",.01f,10),
                        Number(swipeJson,"minDistance",0,100),Number(swipeJson,"minDistanceShot",0,100),Number(swipeJson,"minThrowTime",.001f,10),
                        Number(swipeJson,"throwfactor",.001f,100),Number(swipeJson,"distanceTreshold",.001f,100),
                        Text(swipeJson,"spawnPointLeftPath"),Text(swipeJson,"spawnPointRightPath"));
                }
                else if(swipeJson.ValueKind!=JsonValueKind.Null)throw new InvalidDataException("Unexpected launcher swipe authority.");
                string bullet=row.GetProperty("bulletSha256").GetString()??"";
                if(!Hash(bullet)||row.GetProperty("bulletType").GetString()!="GrenadeAmmoBase"||
                   Number(row,"angle",.01f,89.99f) is not (30f or 45f)||
                   Number(row,"baseDeadRadius",.01f,100)!=(expected.Swipe?1f:.9f)||
                   Number(row,"baseHurtRadius",.01f,100)!=(expected.Swipe?1.7f:1.6f))throw new InvalidDataException("Invalid grenade projectile binding.");
                bindingRows.Add(id,new(id,index,family,expected.Swipe,Number(row,"firstShotWaitTime",0,10),Vector(row.GetProperty("shootOffset")),
                    Text(row,"muzzlePath"),Number(row,"angle",.01f,89.99f),Number(row,"baseThrowDistance",0,100),Number(row,"baseExplodeAfterTime",0,60),
                    Number(row,"damageToPlayerBehindShieldRatio",0,10),Vector(explosive.GetProperty("explosionCoef")),
                    Number(explosive,"additionalUpForce",0,1000),(RecoveredGrenadeEffect)effect,swipe,bullet));
            }
            if(bindingRows.Count!=8||lanes.Values.Sum(x=>x.Length)!=398||allies==0||enemies==0||destroyable==0)
                throw new InvalidDataException("Incomplete grenade bindings.");
            var poses=GrenadePoseCatalog.Load(Path.Combine(dir,"recovered-grenade-poses.json"),manifest.PosesRevision,manifest.SceneRevision,Array.AsReadOnly(bindingRows.Values.ToArray()));
            return new(lanes,bindingRows,manifest.SceneRevision,manifest.StatsRevision,manifest.BindingsRevision,allies,enemies,destroyable,poses);
        }
        catch(Exception e) when(e is JsonException or KeyNotFoundException or InvalidOperationException or FormatException or OverflowException or ArgumentException)
        {throw new InvalidDataException("Malformed grenade package.",e);}
    }
    private static string Digest(byte[] b)=>Convert.ToHexStringLower(SHA256.HashData(b));private static bool Hash(string? s)=>s!=null&&Regex.IsMatch(s,@"\A[0-9a-f]{64}\z");
    private static byte[] Read(string p,int min,int max){using var s=File.OpenRead(p);if(s.Length<min||s.Length>max)throw new InvalidDataException("Invalid grenade file size.");var b=new byte[checked((int)s.Length)];s.ReadExactly(b);return b;}
    private static float Number(JsonElement e,string k,float min,float max)=>Number(e.GetProperty(k),min,max);
    private static float Number(JsonElement e,float min,float max){float v=e.GetSingle();if(!float.IsFinite(v)||v<min||v>max)throw new InvalidDataException("Invalid grenade number.");return v;}
    private static int Integer(JsonElement e,string k,int min,int max){if(!e.GetProperty(k).TryGetInt32(out int v)||v<min||v>max)throw new InvalidDataException("Invalid grenade integer.");return v;}
    private static string Text(JsonElement e,string k){string v=e.GetProperty(k).GetString()??"";if(v.Length is <1 or >768)throw new InvalidDataException("Invalid grenade text.");return v;}
    private static Vector3 Vector(JsonElement e){if(e.GetArrayLength()!=3)throw new InvalidDataException("Invalid grenade vector.");var v=new Vector3(e[0].GetSingle(),e[1].GetSingle(),e[2].GetSingle());if(!PlayerHitbox.Finite(v))throw new InvalidDataException("Invalid grenade vector.");return v;}
}

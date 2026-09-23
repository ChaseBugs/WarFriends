using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace War.BattleServer;

public sealed record BazookaStage(string SourceId,int Index,int Ammo,float CadenceSeconds,float ExplosionDamage,float MinimumDamage,
    float PlayerDamageRatio,float OvertimePlayerDamageRatio);
public sealed record BazookaCurveKey(float Time,float Value,float InTangent,float OutTangent);
public sealed record BazookaBinding(string SourceId,int InventoryIndex,int AnimationFamily,Vector3 ShootOffset,float HoldSeconds,
    float FirstShotWaitSeconds,float DeadRadius,float HurtRadius,float Speed,float BehindShieldRatio,Vector3 ExplosionCoefficient,
    float AdditionalUpForce,float StopSeconds,int MissileType,bool CurvedTrajectory,Vector2 RotationRange,float RotationMagnitude,
    IReadOnlyList<BazookaCurveKey> RotationProfile,int ProjectileCount,float ProjectileDelaySeconds,string MuzzlePath,string? SecondaryMuzzlePath,string BulletRevision);
public sealed record BazookaContentManifest(int Version,string SceneRevision,string StatsRevision,string BindingsRevision);

public sealed class BazookaCatalog
{
    private static readonly (string Id,int Count)[] Expected=[("Google2u.Bazooka_FGM",66),("Google2u.Bazooka_FGMElite",66),
        ("Google2u.Bazooka_HMV",46),("Google2u.Bazooka_Hater",76),("Google2u.Bazooka_M202",76),
        ("Google2u.Bazooka_Panzerfaust",56),("Google2u.Bazooka_RPG7",26)];
    private readonly IReadOnlyDictionary<string,BazookaStage[]> stages;private readonly IReadOnlyDictionary<string,BazookaBinding> bindings;
    public int WeaponCount=>stages.Count;public int StageCount=>stages.Values.Sum(x=>x.Length);
    public string SceneRevision{get;}public string StatsRevision{get;}public string BindingsRevision{get;}public string PackageRevision{get;}
    public uint AlliesBulletMask{get;}public uint EnemiesBulletMask{get;}
    public IReadOnlyCollection<BazookaBinding> Bindings=>Array.AsReadOnly(Expected.Select(x=>Binding(x.Id)).ToArray());
    private BazookaCatalog(Dictionary<string,BazookaStage[]> stages,Dictionary<string,BazookaBinding> bindings,string scene,string stats,string binding,uint allies,uint enemies)
    {this.stages=stages;this.bindings=bindings;SceneRevision=scene;StatsRevision=stats;BindingsRevision=binding;AlliesBulletMask=allies;EnemiesBulletMask=enemies;
     PackageRevision=Convert.ToHexStringLower(SHA256.HashData(System.Text.Encoding.UTF8.GetBytes("WarFriends/bazooka-content/v1\n"+scene+"\n"+stats+"\n"+binding)));}
    public BazookaStage Stage(string id,int index)=>stages.TryGetValue(id,out var lane)&&index>=0&&index<lane.Length?lane[index]:throw new InvalidDataException("Unsupported bazooka stage.");
    public BazookaBinding Binding(string id)=>bindings.TryGetValue(id,out var row)?row:throw new InvalidDataException("Unsupported bazooka binding.");
    // Source launchers consume ammoLeft directly; the final field preserves the
    // same recovered reload/cadence value but MatchEngine never enters reload.
    public WeaponManifest CreateManifest(string id,int upgrade){var s=Stage(id,upgrade);return new(id,s.Ammo,0,s.CadenceSeconds,s.CadenceSeconds);}

    public static BazookaCatalog Load(string path)
    {
        var options=new JsonSerializerOptions{UnmappedMemberHandling=JsonUnmappedMemberHandling.Disallow};byte[] mb=Read(path,2,4096);
        var manifest=JsonSerializer.Deserialize<BazookaContentManifest>(mb,options)??throw new InvalidDataException("Missing bazooka manifest.");
        if(manifest.Version!=1||!Hash(manifest.SceneRevision)||!Hash(manifest.StatsRevision)||!Hash(manifest.BindingsRevision))throw new InvalidDataException("Invalid bazooka manifest.");
        string dir=Path.GetDirectoryName(Path.GetFullPath(path))!;byte[] statsBytes=Read(Path.Combine(dir,"recovered-battle-content.json"),2,16_000_000),bindingBytes=Read(Path.Combine(dir,"recovered-bazooka-bindings.json"),2,1_000_000);
        if(Digest(statsBytes)!=manifest.StatsRevision||Digest(bindingBytes)!=manifest.BindingsRevision)throw new InvalidDataException("Bazooka package hash mismatch.");
        try
        {
            using var sd=JsonDocument.Parse(statsBytes);var root=sd.RootElement;if(root.GetProperty("client").GetString()!="1.4.0"||root.GetProperty("mainSceneSha256").GetString()!=manifest.SceneRevision)throw new InvalidDataException("Bazooka source provenance mismatch.");
            var sheets=root.GetProperty("sheets").EnumerateArray().ToDictionary(x=>x.GetProperty("type").GetString()!,x=>x.GetProperty("rows"),StringComparer.Ordinal);
            var defs=sheets["Google2u.WeaponUpgrades"].EnumerateArray().ToDictionary(x=>x.GetProperty("NAME").GetString()!,StringComparer.Ordinal);var stageRows=new Dictionary<string,BazookaStage[]>(StringComparer.Ordinal);
            foreach(var expected in Expected)
            {var d=defs[expected.Id];var rows=sheets[expected.Id];if(rows.GetArrayLength()!=expected.Count)throw new InvalidDataException("Incomplete bazooka lane.");
             float critical=Number(d,"CRITICAL",0,1),player=Number(d,"DAMAGETOPLAYER",0,100),overtime=Number(d,"DAMAGETOPLAYEROVERTIME",0,100);if(critical!=0)throw new InvalidDataException("Unexpected bazooka critical policy.");
             var lane=new BazookaStage[expected.Count];int i=0;foreach(var row in rows.EnumerateArray())lane[i]=new(expected.Id,i++,Integer(row,"AMMO",1,100000),Number(row,"RELOADTIME",.01f,120),Number(row,"EXPLODEDAMAGE",0,1_000_000),Number(row,"MINDAMAGE",0,1_000_000),player,overtime);stageRows.Add(expected.Id,lane);}
            using var bd=JsonDocument.Parse(bindingBytes);var br=bd.RootElement;if(br.GetProperty("client").GetString()!="1.4.0"||br.GetProperty("sha256").GetString()!=manifest.SceneRevision||br.GetProperty("weaponCount").GetInt32()!=7)throw new InvalidDataException("Bazooka binding provenance mismatch.");
            uint allies=unchecked((uint)br.GetProperty("alliesBulletMask").GetInt32()),enemies=unchecked((uint)br.GetProperty("enemiesBulletMask").GetInt32());var bindingRows=new Dictionary<string,BazookaBinding>(StringComparer.Ordinal);var indexes=new HashSet<int>();
            foreach(var row in br.GetProperty("weapons").EnumerateArray())
            {string id=row.GetProperty("id").GetString()??"";int index=row.GetProperty("inventoryIndex").GetInt32();bool fangs=id=="Google2u.Bazooka_M202";
             if(!stageRows.ContainsKey(id)||!indexes.Add(index)||row.GetProperty("playerWeaponType").GetString()!="PlayerHoldWeapon"||row.GetProperty("animationFamily").GetInt32()!=2||row.GetProperty("reloadable").GetBoolean()||row.GetProperty("infiniteAmmo").GetBoolean()||!row.GetProperty("friendKill").GetBoolean()||row.GetProperty("bulletType").GetString()!="Missile"||row.GetProperty("weaponType").GetString()!=(fangs?"BazookaFangs":"Bazooka"))throw new InvalidDataException("Unsupported bazooka binding.");
             string muzzle=row.GetProperty("muzzlePath").GetString()??"",bullet=row.GetProperty("bulletSha256").GetString()??"";string? secondary=row.GetProperty("fangMuzzlePath").ValueKind==JsonValueKind.Null?null:row.GetProperty("fangMuzzlePath").GetString();
             if(muzzle.Length is <1 or >512||secondary?.Length>512||!Hash(bullet)||Number(row,"criticalMultiplier",1,100)!=2||Number(row,"stopTime",0,60)!=0||Integer(row,"missileType",0,3)!=(fangs?1:3)||row.GetProperty("curvedTrajectory").GetBoolean()!=fangs||Integer(row,"fangShotCount",1,8)!=(fangs?4:1)||Number(row,"fangDelaySeconds",0,2)!=(fangs?.1f:0)||fangs!=(secondary!=null))throw new InvalidDataException("Invalid bazooka asset identity.");
             var rotation=Vector2Of(row.GetProperty("minMaxRotations"));var profile=row.GetProperty("rotationProfile");if(profile.GetArrayLength()!=3||profile[0].GetArrayLength()!=4||profile[0][0].GetSingle()!=0||profile[1][0].GetSingle()!=.5f||profile[2][0].GetSingle()!=1)throw new InvalidDataException("Invalid bazooka trajectory profile.");
             var keys=profile.EnumerateArray().Select(x=>new BazookaCurveKey(x[0].GetSingle(),x[1].GetSingle(),x[2].GetSingle(),x[3].GetSingle())).ToArray();if(keys.Any(x=>!float.IsFinite(x.Time)||!float.IsFinite(x.Value)||!float.IsFinite(x.InTangent)||!float.IsFinite(x.OutTangent)))throw new InvalidDataException("Invalid bazooka trajectory curve.");
             bindingRows.Add(id,new(id,index,2,Vector(row.GetProperty("shootOffset")),Number(row,"holdTime",.01f,10),Number(row,"firstShotWaitTime",0,10),Number(row,"baseDeadRadius",.01f,100),Number(row,"baseHurtRadius",.01f,100),Number(row,"baseSpeed",.01f,1000),Number(row,"playerBehindShieldRatio",0,10),Vector(row.GetProperty("explosionCoef")),Number(row,"additionalUpForce",0,1000),0,fangs?1:3,fangs,rotation,Number(row,"baseRotationMagnitude",0,10),Array.AsReadOnly(keys),fangs?4:1,fangs?.1f:0,muzzle,secondary,bullet));}
            if(bindingRows.Count!=7||!bindingRows.Keys.ToHashSet(StringComparer.Ordinal).SetEquals(Expected.Select(x=>x.Id))||allies==0||enemies==0)throw new InvalidDataException("Incomplete bazooka bindings.");
            return new(stageRows,bindingRows,manifest.SceneRevision,manifest.StatsRevision,manifest.BindingsRevision,allies,enemies);
        }
        catch(Exception e)when(e is JsonException or KeyNotFoundException or InvalidOperationException or FormatException or OverflowException or ArgumentException){throw new InvalidDataException("Malformed bazooka package.",e);}
    }
    private static string Digest(byte[] b)=>Convert.ToHexStringLower(SHA256.HashData(b));private static bool Hash(string? s)=>s!=null&&Regex.IsMatch(s,@"\A[0-9a-f]{64}\z");
    private static byte[] Read(string p,int min,int max){using var s=File.OpenRead(p);if(s.Length<min||s.Length>max)throw new InvalidDataException("Invalid bazooka file size.");var b=new byte[checked((int)s.Length)];s.ReadExactly(b);return b;}
    private static float Number(JsonElement e,string k,float min,float max){float v=e.GetProperty(k).GetSingle();if(!float.IsFinite(v)||v<min||v>max)throw new InvalidDataException("Invalid bazooka number.");return v;}
    private static int Integer(JsonElement e,string k,int min,int max){if(!e.GetProperty(k).TryGetInt32(out int v)||v<min||v>max)throw new InvalidDataException("Invalid bazooka integer.");return v;}
    private static Vector3 Vector(JsonElement e){if(e.GetArrayLength()!=3)throw new InvalidDataException("Invalid bazooka vector.");var v=new Vector3(e[0].GetSingle(),e[1].GetSingle(),e[2].GetSingle());if(!PlayerHitbox.Finite(v))throw new InvalidDataException("Invalid bazooka vector.");return v;}
    private static Vector2 Vector2Of(JsonElement e){if(e.GetArrayLength()!=2)throw new InvalidDataException("Invalid bazooka vector.");var v=new Vector2(e[0].GetSingle(),e[1].GetSingle());if(!float.IsFinite(v.X)||!float.IsFinite(v.Y)||v.X<0||v.Y<v.X)throw new InvalidDataException("Invalid bazooka vector.");return v;}
}

using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace War.BattleServer;

internal sealed record ShotgunStage(string SourceId,int Index,int ClipSize,int ReserveAmmo,
    float ReloadSeconds,float MinDamage,float MaxDamage,float CadenceSeconds,
    float CriticalProbability,float PlayerDamageRatio,float OvertimePlayerDamageRatio);
internal sealed record ShotgunBinding(string SourceId,int InventoryIndex,string MuzzlePath,
    Vector3 ReferenceMuzzlePosition,Vector3 ShotOffset,float Speed,float CheckDistance,float CriticalMultiplier,
    float HitForceMax,bool FriendKill,int AnimationFamily,ShotgunRule Geometry)
{
    internal ShotgunRule Rule(ShotgunStage stage) => Geometry with {MinDamage=stage.MinDamage,MaxDamage=stage.MaxDamage};
}
internal sealed record ShotgunContentManifest(int Version,string SceneRevision,string StatsRevision,string BindingsRevision);

// Separate pinned source package. It is not yet admitted by the rifle-only live
// manifest; first establish every shotgun stage and scene binding together.
internal sealed class ShotgunCatalog
{
    private static readonly (string Name,int Count)[] Expected=[
        ("SPAS",36),("Benelli",26),("Saiga",46),("Striker",56),("Blackhand",76),
        ("SawnOff",56),("StrikerElite",56),("AA12",66),("SaigaElite",46)];
    private readonly Dictionary<string,ShotgunStage[]> stages;
    private readonly Dictionary<string,ShotgunBinding> bindings;
    internal int WeaponCount=>bindings.Count;
    internal int StageCount=>stages.Values.Sum(x=>x.Length);
    internal IReadOnlyList<ShotgunBinding> Bindings=>Array.AsReadOnly(Expected.Select(x=>Binding("Google2u.Shotgun_"+x.Name)).ToArray());
    internal string SceneRevision {get;}
    internal string PackageRevision {get;}
    private ShotgunCatalog(string scene,string package,Dictionary<string,ShotgunStage[]> stages,Dictionary<string,ShotgunBinding> bindings)
    {SceneRevision=scene;PackageRevision=package;this.stages=stages;this.bindings=bindings;}
    internal ShotgunStage Stage(string id,int index) => stages.TryGetValue(id,out var rows) && index>=0 && index<rows.Length ? rows[index] :
        throw new InvalidDataException("Unsupported shotgun stage.");
    internal ShotgunBinding Binding(string id) => bindings.TryGetValue(id,out var row) ? row :
        throw new InvalidDataException("Unsupported shotgun binding.");
    internal WeaponManifest CreateManifest(string id,int index)
    {var row=Stage(id,index);return new(row.SourceId,row.ClipSize,row.ReserveAmmo,row.CadenceSeconds,row.ReloadSeconds);}

    internal static ShotgunCatalog Load(string manifestPath)
    {
        byte[] manifestBytes=Read(manifestPath,4096);
        var options=new JsonSerializerOptions {UnmappedMemberHandling=JsonUnmappedMemberHandling.Disallow};
        var manifest=JsonSerializer.Deserialize<ShotgunContentManifest>(manifestBytes,options)??throw new InvalidDataException("Missing shotgun manifest.");
        static bool Hash(string? x)=>x!=null && Regex.IsMatch(x,@"\A[0-9a-f]{64}\z");
        if(manifest.Version!=1 || !Hash(manifest.SceneRevision) || !Hash(manifest.StatsRevision) || !Hash(manifest.BindingsRevision))
            throw new InvalidDataException("Invalid shotgun package revision.");
        string dir=Path.GetDirectoryName(Path.GetFullPath(manifestPath))!;
        byte[] statsBytes=Read(Path.Combine(dir,"recovered-battle-content.json"),32_000_000);
        byte[] bindingBytes=Read(Path.Combine(dir,"recovered-shotgun-bindings.json"),262_144);
        if(Digest(statsBytes)!=manifest.StatsRevision || Digest(bindingBytes)!=manifest.BindingsRevision)
            throw new InvalidDataException("Shotgun package hash mismatch.");
        try
        {
            using var statsDoc=JsonDocument.Parse(statsBytes);
            using var bindingDoc=JsonDocument.Parse(bindingBytes);
            var statsRoot=statsDoc.RootElement;var bindingRoot=bindingDoc.RootElement;
            if(statsRoot.GetProperty("client").GetString()!="1.4.0" ||
                bindingRoot.GetProperty("client").GetString()!="1.4.0" ||
                bindingRoot.GetProperty("source").GetString()!="Assets/Scenes/MainScene.unity" ||
                bindingRoot.GetProperty("sha256").GetString()!=manifest.SceneRevision ||
                bindingRoot.GetProperty("playerPath").GetString()!="MainSceneRootNew/Player")
                throw new InvalidDataException("Shotgun source provenance mismatch.");
            var sheets=new Dictionary<string,JsonElement>(StringComparer.Ordinal);
            foreach(var sheet in statsRoot.GetProperty("sheets").EnumerateArray())
                if(!sheets.TryAdd(sheet.GetProperty("type").GetString()!,sheet.GetProperty("rows")))
                    throw new InvalidDataException("Duplicate shotgun source sheet.");
            var definitions=new Dictionary<string,JsonElement>(StringComparer.Ordinal);
            foreach(var row in sheets["Google2u.WeaponUpgrades"].EnumerateArray())
                if(!definitions.TryAdd(row.GetProperty("NAME").GetString()!,row))
                    throw new InvalidDataException("Duplicate weapon definition.");
            if(definitions.Count!=66 || bindingRoot.GetProperty("weapons").GetArrayLength()!=Expected.Length)
                throw new InvalidDataException("Incomplete shotgun source package.");
            var stages=new Dictionary<string,ShotgunStage[]>(StringComparer.Ordinal);
            foreach(var (name,count) in Expected)
            {
                string id="Google2u.Shotgun_"+name;
                var sheet=sheets[id];var definition=definitions[id];
                if(sheet.GetArrayLength()!=count)throw new InvalidDataException("Incomplete shotgun upgrade lane.");
                float cadence=Number(definition,"RATEOFFIRE",.01f,60),critical=Number(definition,"CRITICAL",0,1);
                float ratio=Number(definition,"DAMAGETOPLAYER",0,100),overtime=Number(definition,"DAMAGETOPLAYEROVERTIME",0,100);
                _=Number(definition,"SPEED",.01f,10000); // source display only, not the runtime BulletSlow speed
                var lane=new ShotgunStage[count];
                for(int i=0;i<count;i++)
                {
                    var row=sheet[i];float min=Number(row,"MINDAMAGE",0,1_000_000),max=Number(row,"MAXDAMAGE",min,1_000_000);
                    lane[i]=new(id,i,Integer(row,"CLIPSIZE",1,1000),Integer(row,"AMMO",0,100000),
                        Number(row,"RELOADTIME",.01f,120),min,max,cadence,critical,ratio,overtime);
                }
                stages.Add(id,lane);
            }
            var bindings=new Dictionary<string,ShotgunBinding>(StringComparer.Ordinal);
            var inventory=new HashSet<int>();int ordinal=0;
            foreach(var row in bindingRoot.GetProperty("weapons").EnumerateArray())
            {
                string id=row.GetProperty("id").GetString()!;
                if(ordinal>=Expected.Length || id!="Google2u.Shotgun_"+Expected[ordinal++].Name ||
                    !inventory.Add(Integer(row,"inventoryIndex",0,255)) ||
                    row.GetProperty("playerWeaponType").GetString()!="PlayerClickWeapon" ||
                    row.GetProperty("weaponType").GetString()!="AutomaticRifle" ||
                    row.GetProperty("mainBulletType").GetString()!="BulletShotGun" ||
                    row.GetProperty("pelletType").GetString()!="BulletSlow" ||
                    row.GetProperty("mainBulletSource").GetString()!="Assets/GameObject/BulletShotGun.prefab" ||
                    row.GetProperty("pelletSource").GetString()!="Assets/GameObject/BulletSlow.prefab" ||
                    row.GetProperty("mainBulletSha256").GetString()!="61018015fd51f7f4ff6a4e92905ed8b6f949a7d896f3d88696ba26aee0a2aaf2" ||
                    row.GetProperty("pelletSha256").GetString()!="5379f6aba1560b8eb3d7d386d1349454b97ea133163ade9a313e2bc34d1adfae" ||
                    row.GetProperty("fast").GetBoolean() || !row.GetProperty("reloadable").GetBoolean() ||
                    row.GetProperty("infiniteAmmo").GetBoolean() || row.GetProperty("shotType").GetInt32()!=0 ||
                    row.GetProperty("ignoreLayersMask").GetInt32()!=0)
                    throw new InvalidDataException("Unsupported shotgun scene binding.");
                string weaponPath=row.GetProperty("weaponPath").GetString()!;
                string muzzlePath=row.GetProperty("muzzlePath").GetString()!;
                if(!weaponPath.StartsWith("MainSceneRootNew/Player/",StringComparison.Ordinal) ||
                    !muzzlePath.StartsWith(weaponPath+"/",StringComparison.Ordinal) || muzzlePath.Length>1200)
                    throw new InvalidDataException("Invalid shotgun muzzle identity.");
                var basis=row.GetProperty("baseDefinition");var setup=row.GetProperty("setup");
                float near=Number(basis,"shotHalfAngleNear",.01f,180),far=Number(basis,"shotHalfAngle",.01f,180);
                float radius=Number(basis,"radius",.01f,100),speed=Number(basis,"speed",.01f,10000);
                _=Number(basis,"minDamage",0,1_000_000);_=Number(basis,"maxDamage",0,1_000_000);
                _=Number(setup,"shotHalfAngleNear",.01f,180);_=Number(setup,"shotHalfAngle",.01f,180);
                _=Number(setup,"radius",.01f,100);_=Number(setup,"minDamage",0,1_000_000);_=Number(setup,"maxDamage",0,1_000_000);
                _=Number(setup,"bulletSpeed",.01f,10000);
                if(Number(setup,"speedMultiplier",1,1)!=1)throw new InvalidDataException("Unsupported shotgun speed multiplier.");
                int animation=Integer(row,"animationFamily",0,17);
                if(animation is not (0 or 7 or 13))throw new InvalidDataException("Unsupported shotgun animation family.");
                var geometry=new ShotgunRule(near,far,radius,0,0,
                    setup.GetProperty("flatY").GetBoolean(),setup.GetProperty("shotOnlyMainBullet").GetBoolean());
                var binding=new ShotgunBinding(id,Integer(row,"inventoryIndex",0,255),muzzlePath,
                    Vector(row.GetProperty("muzzlePosition")),Vector(row.GetProperty("shotOffset")),speed,Number(setup,"checkDistance",0,50),
                    Number(setup,"criticalMultiplier",1,100),Number(setup,"hitForceMax",0,100000),
                    row.GetProperty("friendKill").GetBoolean(),animation,geometry);
                if(!bindings.TryAdd(id,binding))throw new InvalidDataException("Duplicate shotgun binding.");
            }
            if(bindings.Count!=9 || stages.Values.Sum(x=>x.Length)!=464)throw new InvalidDataException("Incomplete shotgun catalog.");
            return new(manifest.SceneRevision,Digest(manifestBytes),stages,bindings);
        }
        catch(Exception e) when(e is JsonException or KeyNotFoundException or InvalidOperationException or FormatException or OverflowException or ArgumentException)
        {throw new InvalidDataException("Malformed shotgun source package.",e);}
    }
    private static byte[] Read(string path,int maximum)
    {using var stream=File.OpenRead(path);if(stream.Length is <2 || stream.Length>maximum)throw new InvalidDataException("Invalid shotgun package size.");
        byte[] data=new byte[(int)stream.Length];stream.ReadExactly(data);return data;}
    private static string Digest(byte[] data)=>Convert.ToHexStringLower(SHA256.HashData(data));
    private static float Number(JsonElement row,string key,float min,float max)
    {float n=row.GetProperty(key).GetSingle();if(!float.IsFinite(n)||n<min||n>max)throw new InvalidDataException("Invalid shotgun number: "+key);return n;}
    private static int Integer(JsonElement row,string key,int min,int max)
    {if(!row.GetProperty(key).TryGetInt32(out int n)||n<min||n>max)throw new InvalidDataException("Invalid shotgun integer: "+key);return n;}
    private static Vector3 Vector(JsonElement row)
    {if(row.GetArrayLength()!=3)throw new InvalidDataException("Invalid shotgun vector.");
        var v=new Vector3(row[0].GetSingle(),row[1].GetSingle(),row[2].GetSingle());
        if(!PlayerHitbox.Finite(v))throw new InvalidDataException("Invalid shotgun vector.");return v;}
}

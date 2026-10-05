using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using War.Shared;

namespace War.Backend;

/// <summary>Backend projection of the Worker's nine pinned shotgun lanes.
/// Durable inventory selects an identity and stage; no Client shot value is authority.</summary>
public sealed class BattleShotgunManifestCatalog : IBattleWeaponManifestCatalog
{
    private static readonly (string Name,int Count,int InventoryIndex)[] Expected=
    [
        ("SPAS",36,4),("Benelli",26,22),("Saiga",46,27),("Striker",56,33),
        ("Blackhand",76,50),("SawnOff",56,51),("StrikerElite",56,54),
        ("AA12",66,55),("SaigaElite",46,63)
    ];
    private sealed record Stage(string SourceId,int Index,int WeaponIndex,int ClipSize,
        int ReserveAmmo,double CadenceSeconds,double ReloadSeconds);
    private readonly IReadOnlyDictionary<string,Stage[]> lanes;
    public string PackageRevision { get; }

    private BattleShotgunManifestCatalog(Dictionary<string,Stage[]> lanes,string revision)
    {this.lanes=lanes;PackageRevision=revision;}

    public static BattleShotgunManifestCatalog Load(string manifestPath,BattleRifleManifestCatalog combat)
    {
        ArgumentNullException.ThrowIfNull(combat);
        byte[] manifestBytes=Read(manifestPath,4096);
        using var manifestDocument=JsonDocument.Parse(manifestBytes);
        var manifest=manifestDocument.RootElement;
        string scene=manifest.GetProperty("SceneRevision").GetString()!;
        string statsDigest=manifest.GetProperty("StatsRevision").GetString()!;
        string bindingsDigest=manifest.GetProperty("BindingsRevision").GetString()!;
        if(manifest.GetProperty("Version").GetInt32()!=1 ||
           new[]{scene,statsDigest,bindingsDigest}.Any(x=>x==null||
               !Regex.IsMatch(x,@"\A[0-9a-f]{64}\z"))||
           scene!=combat.SceneRevision||statsDigest!=combat.StatsRevision)
            throw new InvalidDataException("Invalid shotgun allocation package revision.");
        string directory=Path.GetDirectoryName(Path.GetFullPath(manifestPath))!;
        byte[] stats=Read(Path.Combine(directory,"recovered-battle-content.json"),32_000_000);
        byte[] bindings=Read(Path.Combine(directory,"recovered-shotgun-bindings.json"),262_144);
        if(Digest(stats)!=statsDigest||Digest(bindings)!=bindingsDigest)
            throw new InvalidDataException("Shotgun allocation package hash mismatch.");
        try
        {
            using var statsDocument=JsonDocument.Parse(stats);
            using var bindingDocument=JsonDocument.Parse(bindings);
            var root=statsDocument.RootElement;var binding=bindingDocument.RootElement;
            if(root.GetProperty("client").GetString()!="1.4.0"||
               root.GetProperty("mainSceneSha256").GetString()!=scene||
               binding.GetProperty("client").GetString()!="1.4.0"||
               binding.GetProperty("source").GetString()!="Assets/Scenes/MainScene.unity"||
               binding.GetProperty("sha256").GetString()!=scene||
               binding.GetProperty("playerPath").GetString()!="MainSceneRootNew/Player")
                throw new InvalidDataException("Shotgun allocation scene provenance mismatch.");
            var sheets=new Dictionary<string,JsonElement>(StringComparer.Ordinal);
            foreach(var sheet in root.GetProperty("sheets").EnumerateArray())
                if(!sheets.TryAdd(sheet.GetProperty("type").GetString()!,sheet.GetProperty("rows")))
                    throw new InvalidDataException("Duplicate shotgun allocation source sheet.");
            var definitions=new Dictionary<string,JsonElement>(StringComparer.Ordinal);
            foreach(var row in sheets["Google2u.WeaponUpgrades"].EnumerateArray())
                if(!definitions.TryAdd(row.GetProperty("NAME").GetString()!,row))
                    throw new InvalidDataException("Duplicate shotgun allocation weapon definition.");
            if(definitions.Count!=66||binding.GetProperty("weapons").GetArrayLength()!=9)
                throw new InvalidDataException("Incomplete shotgun allocation package.");
            var lanes=new Dictionary<string,Stage[]>(StringComparer.Ordinal);
            int ordinal=0;
            foreach(var weapon in binding.GetProperty("weapons").EnumerateArray())
            {
                var expected=Expected[ordinal++];string id="Google2u.Shotgun_"+expected.Name;
                if(weapon.GetProperty("id").GetString()!=id||
                   Integer(weapon,"inventoryIndex",0,255)!=expected.InventoryIndex||
                   weapon.GetProperty("playerWeaponType").GetString()!="PlayerClickWeapon"||
                   weapon.GetProperty("mainBulletType").GetString()!="BulletShotGun"||
                   weapon.GetProperty("pelletType").GetString()!="BulletSlow")
                    throw new InvalidDataException("Unsupported shotgun allocation scene binding.");
                var definition=definitions[id];var rows=sheets[id];
                if(rows.GetArrayLength()!=expected.Count)
                    throw new InvalidDataException("Incomplete shotgun allocation upgrade lane.");
                double cadence=Number(definition,"RATEOFFIRE",.01f,60);
                _=Number(definition,"CRITICAL",0,1);
                _=Number(definition,"DAMAGETOPLAYER",0,100);
                _=Number(definition,"DAMAGETOPLAYEROVERTIME",0,100);
                var stages=new Stage[expected.Count];
                for(int i=0;i<stages.Length;i++)
                {
                    var row=rows[i];float min=(float)Number(row,"MINDAMAGE",0,1_000_000);
                    _=Number(row,"MAXDAMAGE",min,1_000_000);
                    stages[i]=new(id,i,expected.InventoryIndex,Integer(row,"CLIPSIZE",1,1000),
                        Integer(row,"AMMO",0,100000),cadence,Number(row,"RELOADTIME",.01f,120));
                }
                lanes.Add(id,stages);
            }
            if(lanes.Values.Sum(x=>x.Length)!=464)
                throw new InvalidDataException("Incomplete shotgun allocation stage graph.");
            string revision=Digest(Encoding.UTF8.GetBytes("WarFriends/shotgun-combat/v1\n"+
                combat.PackageRevision+"\n"+Digest(manifestBytes)));
            return new(lanes,revision);
        }
        catch(Exception e) when(e is JsonException or KeyNotFoundException or InvalidOperationException or FormatException or OverflowException or ArgumentException)
        {throw new InvalidDataException("Malformed shotgun allocation source package.",e);}
    }

    public void ValidateTemplate(JsonObject template)
    {
        if(template["Mode"]?.GetValue<string>()!="unscored-shotgun-combat"||
           template["CatalogRevision"]?.GetValue<string>()!=PackageRevision)
            throw new InvalidDataException("Battle template does not bind the recovered shotgun combat package.");
    }

    public void Bind(JsonObject participant,BattlePlayerPresentation view)
    {
        view=BattlePlayerPresentation.Validate(view);
        var selectedStages=view.Weapons.OrderBy(x=>x.Slot)
            .Select(equipped=>(Equipped:equipped,Stage:Resolve(equipped))).ToArray();
        var slots=new JsonArray();
        foreach(var row in selectedStages)
        {
            slots.Add(new JsonObject{["Slot"]=row.Equipped.Slot,
                ["WeaponIndex"]=row.Stage.WeaponIndex,
                ["Weapon"]=Weapon(row.Stage),["WeaponUpgrade"]=row.Stage.Index});
        }
        participant["Weapon"]=Weapon(selectedStages[0].Stage);
        participant["WeaponUpgrade"]=selectedStages[0].Stage.Index;
        participant["WeaponSlots"]=slots;
    }

    private Stage Resolve(BattleWeaponPresentation equipped)
    {
        if(!lanes.TryGetValue(equipped.SourceId,out Stage[]? lane)||
           equipped.UpgradeIndex<0||equipped.UpgradeIndex>=lane.Length||
           equipped.WeaponIndex!=lane[0].WeaponIndex)
            throw new InvalidDataException("Durable equipped weapon is not in the recovered shotgun combat catalog.");
        return lane[equipped.UpgradeIndex];
    }
    private static JsonObject Weapon(Stage row)=>new()
    {
        ["SourceId"]=row.SourceId,["ClipSize"]=row.ClipSize,["ReserveAmmo"]=row.ReserveAmmo,
        ["CadenceSeconds"]=row.CadenceSeconds,["ReloadSeconds"]=row.ReloadSeconds
    };
    private static byte[] Read(string path,int maximum)
    {using var stream=File.OpenRead(path);if(stream.Length is <2||stream.Length>maximum)
        throw new InvalidDataException("Invalid shotgun allocation file size.");
        byte[] data=new byte[(int)stream.Length];stream.ReadExactly(data);return data;}
    private static string Digest(byte[] data)=>Convert.ToHexStringLower(SHA256.HashData(data));
    private static int Integer(JsonElement row,string key,int min,int max)
    {if(!row.GetProperty(key).TryGetInt32(out int n)||n<min||n>max)
        throw new InvalidDataException("Invalid shotgun allocation "+key+".");return n;}
    private static double Number(JsonElement row,string key,float min,float max)
    {float n=row.GetProperty(key).GetSingle();if(!float.IsFinite(n)||n<min||n>max)
        throw new InvalidDataException("Invalid shotgun allocation "+key+".");return n;}
}

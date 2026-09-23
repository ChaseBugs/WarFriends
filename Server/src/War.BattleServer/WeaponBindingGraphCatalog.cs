using System.Security.Cryptography;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace War.BattleServer;

/// <summary>Complete source identity graph for every recovered player weapon.
/// It is binding evidence; individual combat classes remain closed until their
/// class-specific simulation is validated.</summary>
public sealed class WeaponBindingGraphCatalog
{
    private readonly IReadOnlyDictionary<string,Binding> bindings;
    public int Count=>bindings.Count;
    public string Revision { get; }
    public sealed record Binding(string SourceId,int InventoryIndex,string SetupType,string PlayerWeaponType,
        string WeaponType,int AnimationFamily,string AmmoSetupType,string BulletType,string BulletSource,
        string BulletGuid,long BulletFileId,string BulletRevision,string WeaponPath,string MuzzlePath);
    private WeaponBindingGraphCatalog(Dictionary<string,Binding> bindings,string revision)
    {this.bindings=bindings;Revision=revision;}
    public Binding Get(string sourceId)=>bindings.TryGetValue(sourceId,out var value)?value:
        throw new InvalidDataException("Unknown recovered weapon binding.");

    public static WeaponBindingGraphCatalog Load(string path,string expectedRevision,string expectedSceneRevision,string contentPath)
    {
        byte[] bytes=Read(path,2,2_000_000);
        string revision=Convert.ToHexStringLower(SHA256.HashData(bytes));
        if(revision!=expectedRevision)throw new InvalidDataException("Weapon binding graph revision mismatch.");
        try
        {
            using var document=JsonDocument.Parse(bytes);JsonElement root=document.RootElement;
            Exact(root,"client","source","sha256","playerPath","weaponCount","weapons");
            if(root.GetProperty("client").GetString()!="1.4.0" || root.GetProperty("source").GetString()!="Assets/Scenes/MainScene.unity" ||
               root.GetProperty("sha256").GetString()!=expectedSceneRevision || root.GetProperty("weaponCount").GetInt32()!=66)
                throw new InvalidDataException("Weapon binding graph provenance mismatch.");
            var sourceIds=SourceIds(contentPath,expectedSceneRevision);
            var result=new Dictionary<string,Binding>(StringComparer.Ordinal);var indexes=new HashSet<int>();
            var playerTypes=new Dictionary<string,int>(StringComparer.Ordinal);var weaponTypes=new Dictionary<string,int>(StringComparer.Ordinal);
            foreach(JsonElement row in root.GetProperty("weapons").EnumerateArray())
            {
                Exact(row,"id","setupType","setupPath","playerWeaponType","weaponType","weaponPath","muzzlePath","inventoryIndex",
                    "animationFamily","shotType","ignoreLayersMask","reloadable","infiniteAmmo","ammoSetupType","weaponComponents",
                    "bulletType","bulletSource","bulletGuid","bulletSha256","bulletFileId");
                string id=Text(row,"id",1,64),setup=Text(row,"setupType",1,64),playerType=Text(row,"playerWeaponType",1,64),
                    weaponType=Text(row,"weaponType",1,64),weaponPath=PathText(row,"weaponPath"),muzzlePath=PathText(row,"muzzlePath"),
                    bulletType=Text(row,"bulletType",1,64),bulletSource=PathText(row,"bulletSource"),guid=Text(row,"bulletGuid",32,32),
                    bulletHash=Text(row,"bulletSha256",64,64);
                if(!sourceIds.Contains(id) || !Regex.IsMatch(id,@"\AGoogle2u\.[A-Za-z0-9_]{1,55}\z") ||
                   !Regex.IsMatch(guid,@"\A[0-9a-f]{32}\z") || !Regex.IsMatch(bulletHash,@"\A[0-9a-f]{64}\z") ||
                   !bulletSource.StartsWith("Assets/",StringComparison.Ordinal) ||
                   !(muzzlePath==weaponPath || muzzlePath.StartsWith(weaponPath+"/",StringComparison.Ordinal)))
                    throw new InvalidDataException("Malformed weapon binding identity.");
                int index=row.GetProperty("inventoryIndex").GetInt32(),animation=row.GetProperty("animationFamily").GetInt32();
                long fileId=row.GetProperty("bulletFileId").GetInt64();
                if(index is <0 or >255 || animation is <0 or >32 || fileId<=0 || !indexes.Add(index))
                    throw new InvalidDataException("Invalid weapon binding index.");
                string[] ammo=row.GetProperty("ammoSetupType").EnumerateArray().Select(x=>Text(x,1,64)).ToArray();
                string[] components=row.GetProperty("weaponComponents").EnumerateArray().Select(x=>Text(x,1,96)).ToArray();
                if(ammo.Length!=1 || components.Length is <3 or >12 || components.Distinct(StringComparer.Ordinal).Count()!=components.Length ||
                   !components.Contains(playerType,StringComparer.Ordinal) || !components.Contains(weaponType,StringComparer.Ordinal) ||
                   !components.Contains(ammo[0],StringComparer.Ordinal))throw new InvalidDataException("Incomplete weapon component binding.");
                if(!result.TryAdd(id,new(id,index,setup,playerType,weaponType,animation,ammo[0],bulletType,bulletSource,guid,fileId,
                    bulletHash,weaponPath,muzzlePath)))throw new InvalidDataException("Duplicate weapon binding.");
                Add(playerTypes,playerType);Add(weaponTypes,weaponType);
            }
            if(result.Count!=66 || !result.Keys.ToHashSet(StringComparer.Ordinal).SetEquals(sourceIds) ||
               !indexes.SetEquals(Enumerable.Range(0,67).Where(x=>x!=20)) ||
               !Counts(playerTypes,("PlayerClickWeapon",27),("PlayerBurstWeapon",16),("PlayerZoomOnTouchWeapon",8),
                   ("PlayerHoldWeapon",7),("PlayerSwipeWeapon",7),("PlayerMinigunWeapon",1)) ||
               !Counts(weaponTypes,("AutomaticRifle",20),("LightMachinegun",17),("Grenade",8),("OneShotRifle",8),
                   ("Bazooka",6),("Pistol",6),("BazookaFangs",1)))
                throw new InvalidDataException("Incomplete recovered weapon binding graph.");
            return new(result,revision);
        }
        catch(Exception e) when(e is JsonException or KeyNotFoundException or InvalidOperationException or FormatException or OverflowException or ArgumentException)
        {throw new InvalidDataException("Malformed weapon binding graph.",e);}
    }
    private static HashSet<string> SourceIds(string path,string scene)
    {
        byte[] bytes=Read(path,2,16_000_000);using var doc=JsonDocument.Parse(bytes);var root=doc.RootElement;
        if(root.GetProperty("mainSceneSha256").GetString()!=scene)throw new InvalidDataException("Weapon sheet scene mismatch.");
        var sheet=root.GetProperty("sheets").EnumerateArray().Single(x=>x.GetProperty("type").GetString()=="Google2u.WeaponUpgrades");
        var ids=sheet.GetProperty("rows").EnumerateArray().Select(x=>x.GetProperty("NAME").GetString()!).ToHashSet(StringComparer.Ordinal);
        if(ids.Count!=66)throw new InvalidDataException("Incomplete weapon definition identities.");return ids;
    }
    private static void Exact(JsonElement value,params string[] names)
    {if(value.ValueKind!=JsonValueKind.Object || !value.EnumerateObject().Select(x=>x.Name).ToHashSet(StringComparer.Ordinal).SetEquals(names))throw new InvalidDataException("Unexpected weapon binding fields.");}
    private static string Text(JsonElement row,string key,int min,int max)=>Text(row.GetProperty(key),min,max);
    private static string Text(JsonElement value,int min,int max){string text=value.GetString()??"";if(text.Length<min||text.Length>max||text.Any(char.IsControl))throw new InvalidDataException("Invalid binding text.");return text;}
    private static string PathText(JsonElement row,string key)=>Text(row,key,1,512);
    private static void Add(Dictionary<string,int> values,string key)=>values[key]=values.GetValueOrDefault(key)+1;
    private static bool Counts(Dictionary<string,int> actual,params (string Key,int Value)[] expected)=>actual.Count==expected.Length&&expected.All(x=>actual.GetValueOrDefault(x.Key)==x.Value);
    private static byte[] Read(string path,int min,int max){using var input=File.OpenRead(path);if(input.Length<min||input.Length>max)throw new InvalidDataException("Invalid weapon artifact size.");var bytes=new byte[checked((int)input.Length)];input.ReadExactly(bytes);return bytes;}
}

using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace War.BattleServer;

public sealed record RifleBinding(string SourceId, int InventoryIndex, string MuzzlePath,
    Vector3 ReferenceMuzzlePosition, Vector3 ShotOffset, float Speed, float CheckDistance,
    float CriticalMultiplier, bool FriendKill,int AnimationFamily);

// Serialized binding evidence. Reference muzzle positions must not substitute for
// the host's animated/aimed weapon pose in a live match.
public sealed class RifleBindingCatalog
{
    private readonly Dictionary<string,RifleBinding> bindings;
    public string Revision { get; }
    public string SceneRevision { get; }
    public string StatRevision { get; }
    private uint alliesMask,enemiesMask;
    internal uint BulletMask(int fraction)=>fraction switch { 1=>enemiesMask,2=>alliesMask,_=>throw new InvalidDataException("Invalid bullet fraction.") };
    public int Count => bindings.Count;
    private RifleBindingCatalog(Dictionary<string,RifleBinding> bindings,string revision,string scene,string stats)
    { this.bindings=bindings; Revision=revision; SceneRevision=scene; StatRevision=stats; }
    public RifleBinding Get(string id) => bindings.TryGetValue(id,out var row) ? row : throw new InvalidDataException("Unknown rifle binding.");

    public static RifleBindingCatalog Load(string path,string expectedRevision,RifleStatCatalog stats)
    {
        using var stream=File.OpenRead(path);
        if (stream.Length is < 2 or > 262144) throw new InvalidDataException("Invalid rifle binding size.");
        byte[] bytes=new byte[(int)stream.Length]; stream.ReadExactly(bytes);
        string revision=Convert.ToHexStringLower(SHA256.HashData(bytes));
        if (revision!=expectedRevision) throw new InvalidDataException("Rifle binding revision mismatch.");
        try
        {
            using var doc=JsonDocument.Parse(bytes);
            var root=doc.RootElement;
            if (root.GetProperty("sha256").GetString()!=stats.SceneRevision ||
                root.GetProperty("source").GetString()!="Assets/Scenes/MainScene.unity" ||
                root.GetProperty("client").GetString()!="1.4.0" ||
                root.GetProperty("pose").GetString()!="serialized-reference-only" ||
                root.GetProperty("playerPath").GetString()!="MainSceneRootNew/Player")
                throw new InvalidDataException("Rifle binding provenance mismatch.");
            var rows=root.GetProperty("weapons");
            if (rows.GetArrayLength()!=stats.WeaponCount) throw new InvalidDataException("Incomplete rifle bindings.");
            var result=new Dictionary<string,RifleBinding>(StringComparer.Ordinal);
            var inventory=new HashSet<int>();
            foreach (var row in rows.EnumerateArray())
            {
                string id=row.GetProperty("id").GetString()!;
                stats.Get(id,0); // Same complete supported identities as the stat catalog.
                int index=row.GetProperty("inventoryIndex").GetInt32();
                string weaponPath=row.GetProperty("weaponPath").GetString()!;
                string muzzlePath=row.GetProperty("muzzlePath").GetString()!;
                if (index is < 0 or > 255 || !inventory.Add(index) ||
                    !weaponPath.StartsWith("MainSceneRootNew/Player/",StringComparison.Ordinal) || weaponPath.Length>1024 ||
                    !muzzlePath.StartsWith(weaponPath+"/",StringComparison.Ordinal) || muzzlePath.Length>1200 ||
                    row.GetProperty("playerWeaponType").GetString()!="PlayerClickWeapon" ||
                    row.GetProperty("weaponType").GetString()!="AutomaticRifle" ||
                    row.GetProperty("bulletType").GetString()!="BulletSlow" ||
                    row.GetProperty("bulletSource").GetString()!="Assets/GameObject/BulletSlow.prefab" ||
                    !Regex.IsMatch(row.GetProperty("bulletGuid").GetString()??"",@"\A[0-9a-f]{32}\z") ||
                    !Regex.IsMatch(row.GetProperty("bulletSha256").GetString()??"",@"\A[0-9a-f]{64}\z") ||
                    row.GetProperty("bulletFileId").GetInt64()<=0 ||
                    row.GetProperty("fast").GetBoolean() || row.GetProperty("infiniteAmmo").GetBoolean() ||
                    !row.GetProperty("reloadable").GetBoolean() || row.GetProperty("shotType").GetInt32()!=0 ||
                    row.GetProperty("ignoreLayersMask").GetInt32()!=0 || Number(row,"speedMultiplier",1,1)!=1)
                    throw new InvalidDataException("Unsupported rifle binding.");
                var binding=new RifleBinding(id,index,muzzlePath,Vector(row.GetProperty("muzzlePosition")),
                    Vector(row.GetProperty("shotOffset")),Number(row,"definitionSpeed",.01f,10000),
                    Number(row,"checkDistance",0,50),Number(row,"criticalMultiplier",1,100),row.GetProperty("friendKill").GetBoolean(),row.GetProperty("animationFamily").GetInt32());
                if (binding.AnimationFamily is < 0 or > 17) throw new InvalidDataException("Invalid weapon animation family.");
                if (!result.TryAdd(id,binding)) throw new InvalidDataException("Duplicate rifle binding.");
            }
            uint allies=unchecked((uint)root.GetProperty("alliesBulletMask").GetInt32());
            uint enemies=unchecked((uint)root.GetProperty("enemiesBulletMask").GetInt32());
            if (allies==0 || enemies==0 || root.GetProperty("layerSource").GetString()!="Assets/GameObject/GlobalStorage.prefab" ||
                !Regex.IsMatch(root.GetProperty("layerSha256").GetString()??"",@"\A[0-9a-f]{64}\z")) throw new InvalidDataException("Missing source bullet masks.");
            return new(result,revision,stats.SceneRevision,stats.Revision) { alliesMask=allies,enemiesMask=enemies };
        }
        catch (Exception e) when (e is JsonException or KeyNotFoundException or InvalidOperationException or FormatException or OverflowException or ArgumentException)
        { throw new InvalidDataException("Malformed rifle binding.",e); }
    }
    internal PreparedProjectile Prepare(RifleStatCatalog stats,string sourceId,int upgrade,ulong id,string owner,
        Vector3 authoritativeMuzzle,Vector3 target,ulong tick,float criticalRoll,
        Func<Vector3,Vector3,float,ShotCollision?> trace)
    {
        if (stats.SceneRevision!=SceneRevision || stats.Revision!=StatRevision || !float.IsFinite(criticalRoll) || criticalRoll is < 0 or > 1)
            throw new InvalidDataException("Invalid rifle shot authority.");
        var binding=Get(sourceId); var stage=stats.Get(sourceId,upgrade);
        float damage=stage.Damage*(criticalRoll<stage.CriticalProbability ? binding.CriticalMultiplier : 1);
        var flight=new BulletFlight(id,owner,new(binding.Speed,binding.CheckDistance,false),
            authoritativeMuzzle+binding.ShotOffset,target,tick,trace);
        return new(flight,new(damage,CombatDamageType.Shot,HasWeapon:true,FriendKill:binding.FriendKill,
            PlayerCoefficient:stage.PlayerDamageRatio,PlayerOvertimeCoefficient:stage.OvertimePlayerDamageRatio),sourceId);
    }
    private static float Number(JsonElement row,string key,float min,float max)
    {
        float n=row.GetProperty(key).GetSingle();
        if (!float.IsFinite(n)||n<min||n>max) throw new InvalidDataException("Invalid rifle "+key);
        return n;
    }
    private static Vector3 Vector(JsonElement value)
    {
        if (value.GetArrayLength()!=3) throw new InvalidDataException("Invalid rifle vector.");
        var v=new Vector3(value[0].GetSingle(),value[1].GetSingle(),value[2].GetSingle());
        if (!PlayerHitbox.Finite(v)) throw new InvalidDataException("Invalid rifle vector.");
        return v;
    }
}

using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace War.BattleServer;

public sealed record ArmyWeaponMuzzle(string UnitId,string Path,Vector3 RestPosition,Quaternion RestRotation);

/// <summary>Pinned enemy-rig and serialized Rusher weapon spawn-point chains.</summary>
public sealed class ArmyWeaponBindingCatalog
{
    private readonly IReadOnlyDictionary<string,ArmyWeaponMuzzle> muzzles;
    public string Revision { get; }
    public string GunSnapPath { get; }
    public Vector3 GunSnapPosition { get; }
    public Quaternion GunSnapRotation { get; }

    private ArmyWeaponBindingCatalog(string revision,string path,Vector3 position,Quaternion rotation,
        Dictionary<string,ArmyWeaponMuzzle> muzzles)
    {Revision=revision;GunSnapPath=path;GunSnapPosition=position;GunSnapRotation=rotation;this.muzzles=muzzles;}

    public ArmyWeaponMuzzle Muzzle(string unitId)
        =>muzzles.TryGetValue(unitId,out var value)?value:throw new ArgumentOutOfRangeException(nameof(unitId));

    public Vector3 RestMuzzleOrigin(string unitId,Vector3 entityPosition,Vector3 planarForward)
    {
        if(!PlayerHitbox.Finite(entityPosition)||!PlayerHitbox.Finite(planarForward))
            throw new InvalidDataException("Invalid army muzzle placement.");
        planarForward.Y=0;
        if(planarForward.LengthSquared()<1e-10f)throw new InvalidDataException("Army muzzle has no planar facing.");
        planarForward=Vector3.Normalize(planarForward);
        float yaw=MathF.Atan2(planarForward.X,planarForward.Z);
        return entityPosition+Vector3.Transform(Muzzle(unitId).RestPosition,
            Quaternion.CreateFromAxisAngle(Vector3.UnitY,yaw));
    }

    public static ArmyWeaponBindingCatalog Load(string path,string expectedRevision,string sceneRevision)
    {
        byte[] bytes=File.ReadAllBytes(path);
        if(bytes.Length is <100 or >131072||Convert.ToHexStringLower(SHA256.HashData(bytes))!=expectedRevision)
            throw new InvalidDataException("Army weapon binding revision mismatch.");
        using var document=JsonDocument.Parse(bytes,new JsonDocumentOptions{MaxDepth=16});
        var root=document.RootElement;
        Exact(root,"version","sceneSha256","enemyPrefabSha256","gunSnap","provenance","families");
        if(root.GetProperty("version").GetInt32()!=2||root.GetProperty("sceneSha256").GetString()!=sceneRevision||
           !Hash(root.GetProperty("enemyPrefabSha256").GetString())||
           root.GetProperty("provenance").GetString()!=
             "serialized EnemyBasicInventory weapon references plus enemy rig and weapon spawn-point transform chains; runtime weapon IDs remain unresolved")
            throw new InvalidDataException("Invalid army weapon provenance.");
        var gun=Transform(root.GetProperty("gunSnap"),"enemy/");
        var families=root.GetProperty("families");
        if(families.GetArrayLength()!=6)throw new InvalidDataException("Incomplete Rusher weapon family set.");
        var result=new Dictionary<string,ArmyWeaponMuzzle>(StringComparer.Ordinal);
        foreach(var family in families.EnumerateArray())
        {
            Exact(family,"unitId","behaviorType","behaviorFileId","inventory");
            string unit=family.GetProperty("unitId").GetString()??"";
            if(!Regex.IsMatch(unit,@"\AID_UNIT-[A-Z0-9-]{1,50}\z")||result.ContainsKey(unit))
                throw new InvalidDataException("Invalid army weapon unit identity.");
            var inventory=family.GetProperty("inventory");
            if(inventory.GetArrayLength() is <1 or >3)throw new InvalidDataException("Invalid Rusher inventory size.");
            ArmyWeaponMuzzle? first=null;
            foreach(var weapon in inventory.EnumerateArray())
            {
                Exact(weapon,"fileId","weaponFileId","guid","asset","weaponType","projectile","spawnPoint");
                if(weapon.GetProperty("fileId").GetInt32()<=0||weapon.GetProperty("weaponFileId").GetInt32()<=0||
                   !Regex.IsMatch(weapon.GetProperty("guid").GetString()??"",@"\A[0-9a-f]{32}\z")||
                   weapon.GetProperty("weaponType").GetInt32() is <0 or >32)
                    throw new InvalidDataException("Invalid Rusher weapon identity.");
                var spawn=Transform(weapon.GetProperty("spawnPoint"),"");
                var combinedPosition=gun.Position+Vector3.Transform(spawn.Position,gun.Rotation);
                var combinedRotation=Quaternion.Normalize(gun.Rotation*spawn.Rotation);
                var muzzle=new ArmyWeaponMuzzle(unit,spawn.Path,combinedPosition,combinedRotation);
                first??=muzzle;
            }
            result.Add(unit,first!);
        }
        return new(expectedRevision,gun.Path,gun.Position,gun.Rotation,result);
    }

    private sealed record TransformRow(string Path,Vector3 Position,Quaternion Rotation);
    private static TransformRow Transform(JsonElement row,string prefix)
    {
        Exact(row,"path","position","rotation");string path=row.GetProperty("path").GetString()??"";
        Vector3 p=Vector(row.GetProperty("position"));Quaternion q=Rotation(row.GetProperty("rotation"));
        if(path.Length is <3 or >512||path.Any(char.IsControl)||!path.StartsWith(prefix,StringComparison.Ordinal)||
           p.Length()>10)throw new InvalidDataException("Invalid army transform chain.");
        return new(path,p,q);
    }
    private static Vector3 Vector(JsonElement row)
    {if(row.GetArrayLength()!=3)throw new InvalidDataException("Invalid army vector.");var v=new Vector3(row[0].GetSingle(),row[1].GetSingle(),row[2].GetSingle());if(!PlayerHitbox.Finite(v))throw new InvalidDataException("Invalid army vector.");return v;}
    private static Quaternion Rotation(JsonElement row)
    {if(row.GetArrayLength()!=4)throw new InvalidDataException("Invalid army rotation.");var q=new Quaternion(row[0].GetSingle(),row[1].GetSingle(),row[2].GetSingle(),row[3].GetSingle());if(!float.IsFinite(q.LengthSquared())||Math.Abs(q.LengthSquared()-1)>.001f)throw new InvalidDataException("Invalid army rotation.");return Quaternion.Normalize(q);}
    private static bool Hash(string? value)=>value!=null&&Regex.IsMatch(value,@"\A[0-9a-f]{64}\z");
    private static void Exact(JsonElement row,params string[] fields)
    {if(row.ValueKind!=JsonValueKind.Object||!row.EnumerateObject().Select(x=>x.Name).Order().SequenceEqual(fields.Order()))throw new InvalidDataException("Unexpected army weapon field set.");}
}

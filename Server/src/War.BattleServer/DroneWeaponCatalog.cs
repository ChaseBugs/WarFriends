using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
namespace War.BattleServer;

public sealed class DroneWeaponCatalog
{
    public string Revision { get; }
    public float Cadence=>.17f;
    public float FakeDispersion=>1;
    public Vector3 SpawnOffset { get; }
    public string ProjectileGuid=>"855689762fa6e774aaee190652b08c6f";
    public int ProjectileFileId=>11409266;
    private DroneWeaponCatalog(string revision,Vector3 offset){Revision=revision;SpawnOffset=offset;}
    public Vector3 Muzzle(Vector3 position,Quaternion rotation)
    {
        if(!Finite(position)||!float.IsFinite(rotation.LengthSquared())||Math.Abs(rotation.LengthSquared()-1)>.001f)
            throw new InvalidDataException("Invalid Drone muzzle pose authority.");
        var result=position+Vector3.Transform(SpawnOffset,rotation);
        if(!Finite(result))throw new InvalidDataException("Drone muzzle overflow.");
        return result;
    }
    public bool Ready(float time,float lastShotTime)
    {
        if(!float.IsFinite(time)||!float.IsFinite(lastShotTime)||time<0||lastShotTime<0||lastShotTime>time)
            throw new InvalidDataException("Invalid Drone weapon clock.");
        float deadline=lastShotTime+Cadence;
        if(!float.IsFinite(deadline)||deadline==lastShotTime)throw new InvalidDataException("Drone weapon deadline lost precision.");
        return time>deadline;
    }
    public static DroneWeaponCatalog Load(string path,string revision)
    {
        var bytes=File.ReadAllBytes(path);
        if(bytes.Length is <100 or >10000||Convert.ToHexStringLower(SHA256.HashData(bytes))!=revision)
            throw new InvalidDataException("Drone weapon artifact revision mismatch.");
        using var doc=JsonDocument.Parse(bytes);var r=doc.RootElement;
        string[] fields=["version","unitId","source","sha256","droneComponentFileId","batchedComponentFileId",
            "weaponComponentFileId","weaponType","cadence","fakeShotDispersion","spawnTransformFileId",
            "restSpawnPosition","restSpawnRotation","restSpawnScale","shotOffset","infiniteAmmo","reloadableWeapon",
            "friendKill","fastBullet","ignoreLayersMask","projectileFileId","projectileGuid","projectileSource","projectileSha256"];
        if(r.ValueKind!=JsonValueKind.Object||!r.EnumerateObject().Select(p=>p.Name).Order().SequenceEqual(fields.Order()))
            throw new InvalidDataException("Unexpected Drone weapon field set.");
        bool Equal(string name,string value)=>r.GetProperty(name).GetString()==value;
        if(r.GetProperty("version").GetInt32()!=1||!Equal("unitId","ID_UNIT-DRONE")||!Equal("source","Assets/GameObject/dronePrototype.prefab")||
           !Equal("sha256","c2afc19487462e6163ad107267ef1b35c9c86fb34fa80898135b1d25f4a872a3")||
           r.GetProperty("droneComponentFileId").GetInt32()!=11459786||r.GetProperty("batchedComponentFileId").GetInt32()!=11434916||
           r.GetProperty("weaponComponentFileId").GetInt32()!=11433324||!Equal("weaponType","AutomaticRifle")||
           r.GetProperty("spawnTransformFileId").GetInt32()!=484583||r.GetProperty("cadence").GetSingle()!=.17f||
           r.GetProperty("fakeShotDispersion").GetSingle()!=1||!r.GetProperty("infiniteAmmo").GetBoolean()||
           r.GetProperty("reloadableWeapon").GetBoolean()||!r.GetProperty("friendKill").GetBoolean()||r.GetProperty("fastBullet").GetBoolean()||
           r.GetProperty("ignoreLayersMask").GetInt32()!=0||r.GetProperty("projectileFileId").GetInt32()!=11409266||
           !Equal("projectileGuid","855689762fa6e774aaee190652b08c6f")||!Equal("projectileSource","Assets/GameObject/BulletSlow.prefab")||
           !Equal("projectileSha256","5379f6aba1560b8eb3d7d386d1349454b97ea133163ade9a313e2bc34d1adfae"))
            throw new InvalidDataException("Drone weapon differs from verified source contract.");
        Vector3 offset=Vector(r.GetProperty("restSpawnPosition"));
        if(Vector3.Distance(offset,new(.016174316f,-.13520324f,-.07588673f))>1e-7f||
            Vector(r.GetProperty("shotOffset"))!=Vector3.Zero||
            Vector3.Distance(Vector(r.GetProperty("restSpawnScale")),new(.6888661f,.6888661f,.68886405f))>1e-7f)
            throw new InvalidDataException("Drone muzzle geometry changed.");
        var q=r.GetProperty("restSpawnRotation");
        if(q.GetArrayLength()!=4)throw new InvalidDataException("Invalid Drone muzzle rotation.");
        var rotation=new Quaternion(q[0].GetSingle(),q[1].GetSingle(),q[2].GetSingle(),q[3].GetSingle());
        if(!float.IsFinite(rotation.LengthSquared())||Math.Abs(rotation.LengthSquared()-1)>.001f||
            (rotation-new Quaternion(-3.3589187e-9f,.99704325f,-.076843105f,-4.3582148e-8f)).Length()>1e-7f)
            throw new InvalidDataException("Drone muzzle rotation changed.");
        return new(revision,offset);
    }
    private static Vector3 Vector(JsonElement v)
    {if(v.GetArrayLength()!=3)throw new InvalidDataException("Invalid Drone vector.");var result=new Vector3(v[0].GetSingle(),v[1].GetSingle(),v[2].GetSingle());if(!Finite(result))throw new InvalidDataException("Nonfinite Drone vector.");return result;}
    private static bool Finite(Vector3 v)=>float.IsFinite(v.X)&&float.IsFinite(v.Y)&&float.IsFinite(v.Z);
}

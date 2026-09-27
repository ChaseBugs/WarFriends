using System.Security.Cryptography;
using System.Text.Json;
namespace War.BattleServer;

public sealed class DroneProjectileCatalog
{
    public string Revision { get; }
    public float CheckDistance=>1;
    public float FakeSpeedFactor=>1.5f;
    public float CriticalProbability=>0;
    public float CriticalMultiplier=>2;
    private DroneProjectileCatalog(string revision){Revision=revision;}
    public float Speed(float composedSpeed,bool playerTarget,bool fake)
    {
        if(!float.IsFinite(composedSpeed)||composedSpeed<=0||composedSpeed>1000)
            throw new InvalidDataException("Invalid composed Drone projectile speed.");
        // BulletSetup.fakeSpeed ignores speedMultiplayer; real bulletSpeed includes it.
        return composedSpeed*(fake?FakeSpeedFactor:playerTarget?.5f:1);
    }
    public static DroneProjectileCatalog Load(string path,string revision)
    {
        var bytes=File.ReadAllBytes(path);
        if(bytes.Length is <100 or >4096||Convert.ToHexStringLower(SHA256.HashData(bytes))!=revision)
            throw new InvalidDataException("Drone projectile setup revision mismatch.");
        using var doc=JsonDocument.Parse(bytes);var r=doc.RootElement;
        string[] names=["version","source","sha256","componentFileId","speed","checkDistance","fakeSpeedFactor",
            "speedMultiplayer","criticalProbability","criticalAmount","serializedDamage","poisonTime","poisonRatio"];
        if(r.ValueKind!=JsonValueKind.Object||!r.EnumerateObject().Select(p=>p.Name).Order().SequenceEqual(names.Order())||
           r.GetProperty("version").GetInt32()!=1||r.GetProperty("componentFileId").GetInt32()!=11492819||
           r.GetProperty("source").GetString()!="Assets/GameObject/dronePrototype.prefab"||
           r.GetProperty("sha256").GetString()!="c2afc19487462e6163ad107267ef1b35c9c86fb34fa80898135b1d25f4a872a3")
            throw new InvalidDataException("Unexpected Drone projectile setup identity.");
        foreach(var expected in new[]{("speed",9f),("checkDistance",1f),("fakeSpeedFactor",1.5f),
            ("speedMultiplayer",1f),("criticalProbability",0f),("criticalAmount",2f),("serializedDamage",20f),
            ("poisonTime",0f),("poisonRatio",0f)})
            if(r.GetProperty(expected.Item1).GetSingle()!=expected.Item2)
                throw new InvalidDataException("Drone projectile setup differs from verified source.");
        return new(revision);
    }
}

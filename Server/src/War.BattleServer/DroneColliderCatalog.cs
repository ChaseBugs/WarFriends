using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
namespace War.BattleServer;

public sealed record DroneCollider(int ComponentFileId,int SerializedLayer,bool RootOwned,PlayerHitbox Hitbox);
public sealed class DroneColliderCatalog
{
    public const string VerifiedInventoryRevision="c4db78dd2bca17f2ed36dca3512d374ec685cd2909ec9d3eae5950a9920f43cd";
    // dronePrototype.prefab root DestroyableObject serializes shotCoeficient: 1.
    public const float FlameCoefficient=1f;
    public string Revision=>VerifiedInventoryRevision;
    private readonly Vector3 center,size;
    private readonly float radius;
    private DroneColliderCatalog(Vector3 center,Vector3 size,float radius)
    {this.center=center;this.size=size;this.radius=radius;}
    public static DroneColliderCatalog Load(string path)
    {
        var bytes=File.ReadAllBytes(path);
        // Exact independently audited inventory; no recomputed manifest can promote edits.
        if(bytes.Length>500000||Convert.ToHexStringLower(SHA256.HashData(bytes))!=VerifiedInventoryRevision)
            throw new InvalidDataException("Drone collider inventory differs from verified source.");
        using var doc=JsonDocument.Parse(bytes);
        var unit=doc.RootElement.GetProperty("units").EnumerateArray().Single(u=>u.GetProperty("unitId").GetString()=="ID_UNIT-DRONE");
        if(unit.GetProperty("sha256").GetString()!="c2afc19487462e6163ad107267ef1b35c9c86fb34fa80898135b1d25f4a872a3")
            throw new InvalidDataException("Drone collider prefab identity mismatch.");
        var damageRoot=unit.GetProperty("components").EnumerateArray()
            .Single(c=>c.GetProperty("scriptType").GetString()=="DestroyableObject");
        if(damageRoot.GetProperty("componentFileId").GetInt32()!=11434467||
           damageRoot.GetProperty("gameObjectFileId").GetInt32()!=147589)
            throw new InvalidDataException("Drone Flame damage root changed.");
        var box=unit.GetProperty("colliders")[0];var sphere=unit.GetProperty("colliders")[1];
        if(box.GetProperty("gameObjectFileId").GetInt32()!=147589||
           sphere.GetProperty("gameObjectFileId").GetInt32()==147589)
            throw new InvalidDataException("Drone Flame collider ownership changed.");
        Vector3 V(JsonElement v)=>new(v[0].GetSingle(),v[1].GetSingle(),v[2].GetSingle());
        return new(V(box.GetProperty("restCenter")),V(box.GetProperty("localSize")),sphere.GetProperty("localRadius").GetSingle());
    }
    // Root scale is one in SpawningManager.Spawn. Child sphere keeps its own layer.
    public IReadOnlyList<DroneCollider> Place(Vector3 position,Quaternion rotation)
    {
        if(!PlayerHitbox.Finite(position)||!float.IsFinite(rotation.LengthSquared())||Math.Abs(rotation.LengthSquared()-1)>.0001f)
            throw new InvalidDataException("Invalid Drone collider pose.");
        const string source="Assets/GameObject/dronePrototype.prefab";
        return Array.AsReadOnly(new[]{
            new DroneCollider(6544804,0,true,new PlayerHitbox(source+"#6544804",PlayerHitboxKind.Box,1,
                position+Vector3.Transform(center,rotation),size,rotation,0,Vector3.Zero,0,transformPosition:position)),
            new DroneCollider(13511718,8,false,new PlayerHitbox(source+"#13511718",PlayerHitboxKind.Sphere,1,
                position,Vector3.Zero,rotation,radius,Vector3.Zero,0,transformPosition:position))});
    }
}

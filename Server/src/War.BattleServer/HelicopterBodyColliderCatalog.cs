using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

internal sealed record HelicopterBodyCollider(int ColliderFileId,int PartComponentFileId,
    int Layer,PlayerHitbox Hitbox);

// All eleven Helicopter boxes are direct descendants of its body transform.
// Their source DestroyableObjectpart components route damage to the same root.
internal sealed class HelicopterBodyColliderCatalog
{
    // Helicopter.prefab's root and child parts serialize shotCoeficient: 1.
    // UpgradesLoaded later changes only the root to 0.33; Burn does not refresh children.
    internal const float FlamePartCoefficient=1f;
    private sealed record Source(int ColliderFileId,int PartComponentFileId,int Layer,
        Vector3 Center,Quaternion Rotation,Vector3 Size);
    private static readonly int[] SourceOrder=[6580903,6571354,6564753,6533468,6593588,
        6554546,6557662,6505360,6593469,6500539,6501874];
    private readonly Source[] boxes;
    private HelicopterBodyColliderCatalog(Source[] boxes)=>this.boxes=boxes;
    internal int Count=>boxes.Length;
    internal bool HasCollider(int fileId)=>boxes.Any(x=>x.ColliderFileId==fileId);

    internal static HelicopterBodyColliderCatalog Load(string path)
    {
        byte[] bytes=File.ReadAllBytes(path);
        if(bytes.Length>500000||
           Convert.ToHexStringLower(SHA256.HashData(bytes))!=DroneColliderCatalog.VerifiedInventoryRevision)
            throw new InvalidDataException("Helicopter collision inventory differs from verified source.");
        using var doc=JsonDocument.Parse(bytes);
        var unit=doc.RootElement.GetProperty("units").EnumerateArray().Single(x=>
            x.GetProperty("unitId").GetString()=="ID_UNIT-HELICOPTER");
        if(unit.GetProperty("source").GetString()!="Assets/GameObject/Helicopter.prefab"||
           unit.GetProperty("sha256").GetString()!=
               "e91c07c1552988601ada89c769056354ebd5d94ea88356eeacc5fa3f3fb76408"||
           unit.GetProperty("rootTransformFileId").GetInt32()!=499539)
            throw new InvalidDataException("Helicopter collider prefab identity mismatch.");
        var rootDamage=unit.GetProperty("components").EnumerateArray().Single(x=>
            x.GetProperty("scriptType").GetString()=="DestroyableObjectMultipleParts");
        if(rootDamage.GetProperty("componentFileId").GetInt32()!=11414637||
           rootDamage.GetProperty("gameObjectFileId").GetInt32()!=147589)
            throw new InvalidDataException("Helicopter Flame damage root changed.");
        var parts=unit.GetProperty("components").EnumerateArray().Where(x=>
            x.GetProperty("scriptType").GetString()=="DestroyableObjectpart").ToArray();
        var colliders=unit.GetProperty("colliders");
        if(colliders.GetArrayLength()!=SourceOrder.Length||parts.Length!=12)
            throw new InvalidDataException("Helicopter body parts or colliders are incomplete.");
        var result=new Source[SourceOrder.Length];
        var colliderIds=new HashSet<int>();var partIds=new HashSet<int>();
        for(int i=0;i<result.Length;i++)
        {
            var row=colliders[i];int id=row.GetProperty("colliderFileId").GetInt32();
            int go=row.GetProperty("gameObjectFileId").GetInt32();
            var part=parts.SingleOrDefault(x=>x.GetProperty("gameObjectFileId").GetInt32()==go);
            var ancestors=row.GetProperty("ancestorTransformFileIds");
            if(id!=SourceOrder[i]||!colliderIds.Add(id)||part.ValueKind==JsonValueKind.Undefined||
               row.GetProperty("type").GetString()!="Box"||
               row.GetProperty("serializedLayer").GetInt32()!=8||
               !row.GetProperty("enabled").GetBoolean()||row.GetProperty("trigger").GetBoolean()||
               !row.GetProperty("activeAncestors").GetBoolean()||ancestors.GetArrayLength()!=3||
               ancestors[1].GetInt32()!=435975||ancestors[2].GetInt32()!=499539||
               part.GetProperty("weight").GetSingle()!=1f||
               part.GetProperty("ownerDestroyableObject").GetInt32()!=0)
                throw new InvalidDataException("Helicopter body collider lost source owner or geometry.");
            int partId=part.GetProperty("componentFileId").GetInt32();
            if(!partIds.Add(partId))throw new InvalidDataException("Duplicate Helicopter damage part.");
            var center=Vector(row.GetProperty("restCenter"));
            var localSize=Vector(row.GetProperty("localSize"));
            var scale=Vector(row.GetProperty("scale"));
            var size=localSize*scale;
            var rotation=Rotation(row.GetProperty("restRotation"));
            if(!PlayerHitbox.Finite(center)||!PlayerHitbox.Finite(size)||
               size.X<=0||size.Y<=0||size.Z<=0||size.Length()>10||
               !float.IsFinite(rotation.LengthSquared())||
               Math.Abs(rotation.LengthSquared()-1)>.001f)
                throw new InvalidDataException("Helicopter collision box is malformed.");
            result[i]=new(id,partId,8,center,rotation,size);
        }
        return new(result);
    }

    internal IReadOnlyList<HelicopterBodyCollider> Place(Vector3 position,Quaternion rotation)
    {
        if(!PlayerHitbox.Finite(position)||!float.IsFinite(rotation.LengthSquared())||
           Math.Abs(rotation.LengthSquared()-1)>.001f)
            throw new InvalidDataException("Invalid Helicopter collider root pose.");
        var placed=new HelicopterBodyCollider[boxes.Length];
        for(int i=0;i<boxes.Length;i++)
        {
            var row=boxes[i];var center=position+Vector3.Transform(row.Center,rotation);
            var worldRotation=Quaternion.Normalize(rotation*row.Rotation);
            if(!PlayerHitbox.Finite(center)||!float.IsFinite(worldRotation.LengthSquared()))
                throw new InvalidDataException("Helicopter collision pose overflow.");
            var hitbox=new PlayerHitbox("Assets/GameObject/Helicopter.prefab#"+row.ColliderFileId,
                PlayerHitboxKind.Box,1,center,row.Size,worldRotation,0,Vector3.Zero,0,
                transformPosition:position);
            placed[i]=new(row.ColliderFileId,row.PartComponentFileId,row.Layer,hitbox);
        }
        return Array.AsReadOnly(placed);
    }
    private static Vector3 Vector(JsonElement value)=>new(value[0].GetSingle(),
        value[1].GetSingle(),value[2].GetSingle());
    private static Quaternion Rotation(JsonElement value)=>new(value[0].GetSingle(),
        value[1].GetSingle(),value[2].GetSingle(),value[3].GetSingle());
}

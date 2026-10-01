using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record HelicopterCrewPoint(int Index,int ComponentFileId,int TransformFileId,
    int RopeTransformFileId,Vector3 RestPosition,Quaternion RestRotation,Vector3 RopeRestPosition);

public sealed class HelicopterCrewPointCatalog
{
    public const string VerifiedRevision="f500a5be419ee7e6a688f9a9b8486998a5f7aee4f3819179241213a24e3d8bd4";
    private static readonly int[] SourceOrder=[11438461,11450766,11481434,11454267,11412170,11411857];
    public IReadOnlyList<HelicopterCrewPoint> Slots { get; }
    public int TurretPointComponentFileId { get; }
    private HelicopterCrewPointCatalog(HelicopterCrewPoint[] slots,int turret)
    {Slots=Array.AsReadOnly(slots);TurretPointComponentFileId=turret;}

    public static HelicopterCrewPointCatalog Load(string path,string revision)
    {
        byte[] bytes=File.ReadAllBytes(path);
        if(revision!=VerifiedRevision||bytes.Length is <100 or >10000||
           Convert.ToHexStringLower(SHA256.HashData(bytes))!=VerifiedRevision)
            throw new InvalidDataException("Helicopter crew source artifact differs from verified revision.");
        using var document=JsonDocument.Parse(bytes);
        var root=document.RootElement;
        if(root.GetProperty("version").GetInt32()!=1||root.GetProperty("client").GetString()!="1.4.0"||
           root.GetProperty("source").GetString()!="Assets/GameObject/Helicopter.prefab"||
           root.GetProperty("sha256").GetString()!="e91c07c1552988601ada89c769056354ebd5d94ea88356eeacc5fa3f3fb76408"||
           root.GetProperty("helicopterComponentFileId").GetInt32()!=11475216||
           root.GetProperty("turretPointComponentFileId").GetInt32()!=11499861)
            throw new InvalidDataException("Helicopter crew artifact lost prefab identity.");
        var rows=root.GetProperty("slots");
        if(rows.GetArrayLength()!=6)throw new InvalidDataException("Helicopter prefab crew slots are incomplete.");
        static Vector3 Vector(JsonElement value)=>new(value[0].GetSingle(),value[1].GetSingle(),value[2].GetSingle());
        var slots=new HelicopterCrewPoint[6];
        for(int i=0;i<slots.Length;i++)
        {
            var row=rows[i];var rotation=row.GetProperty("restRotation");
            var q=new Quaternion(rotation[0].GetSingle(),rotation[1].GetSingle(),
                rotation[2].GetSingle(),rotation[3].GetSingle());
            slots[i]=new(i,row.GetProperty("componentFileId").GetInt32(),
                row.GetProperty("transformFileId").GetInt32(),
                row.GetProperty("ropeTransformFileId").GetInt32(),
                Vector(row.GetProperty("restPosition")),q,Vector(row.GetProperty("ropeRestPosition")));
            if(row.GetProperty("index").GetInt32()!=i||slots[i].ComponentFileId!=SourceOrder[i]||
               slots[i].TransformFileId<=0||slots[i].RopeTransformFileId!=480871||
               !PlayerHitbox.Finite(slots[i].RestPosition)||!PlayerHitbox.Finite(slots[i].RopeRestPosition)||
               !float.IsFinite(q.LengthSquared())||Math.Abs(q.LengthSquared()-1)>.0002f)
                throw new InvalidDataException("Helicopter crew source slot is malformed.");
        }
        return new(slots,11499861);
    }
}

using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record HelicopterCrewPoint(int Index,int ComponentFileId,int TransformFileId,
    int RopeTransformFileId,Vector3 RestPosition,Quaternion RestRotation,Vector3 RopeRestPosition);
public sealed record HelicopterCrewPose(int Slot,int PointComponentFileId,Vector3 Position,
    Quaternion Rotation,Vector3 RopePosition);
public sealed record HelicopterTurretRestPose(int PointComponentFileId,Vector3 GunnerPosition,
    Quaternion GunnerRotation,Vector3 SightRestPosition,Quaternion SightRestRotation,
    Vector3 MuzzleRestPosition,Quaternion MuzzleRestRotation);

public sealed class HelicopterCrewPointCatalog
{
    public const string VerifiedRevision="ef23b0a47858d1ac794d799876ae6cc4822dc501bdbc361edd458ce60b920379";
    private static readonly int[] SourceOrder=[11438461,11450766,11481434,11454267,11412170,11411857];
    public IReadOnlyList<HelicopterCrewPoint> Slots { get; }
    public int TurretPointComponentFileId { get; }
    public Vector3 TurretPointRestPosition { get; }
    public Quaternion TurretPointRestRotation { get; }
    public Vector3 TurretSightRestPosition { get; }
    public Quaternion TurretSightRestRotation { get; }
    public Vector3 TurretMuzzleRestPosition { get; }
    public Quaternion TurretMuzzleRestRotation { get; }
    private HelicopterCrewPointCatalog(HelicopterCrewPoint[] slots,int turret,Vector3 turretPosition,
        Quaternion turretRotation,Vector3 sightPosition,Quaternion sightRotation,
        Vector3 muzzlePosition,Quaternion muzzleRotation)
    {
        Slots=Array.AsReadOnly(slots);TurretPointComponentFileId=turret;
        TurretPointRestPosition=turretPosition;TurretPointRestRotation=turretRotation;
        TurretSightRestPosition=sightPosition;TurretSightRestRotation=sightRotation;
        TurretMuzzleRestPosition=muzzlePosition;TurretMuzzleRestRotation=muzzleRotation;
    }

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
           root.GetProperty("turretPointComponentFileId").GetInt32()!=11499861||
           root.GetProperty("turretPointTransformFileId").GetInt32()!=417017||
           root.GetProperty("turretWeaponComponentFileId").GetInt32()!=11498443||
           root.GetProperty("turretBatchedWeaponComponentFileId").GetInt32()!=11483234||
           root.GetProperty("turretGunComponentFileId").GetInt32()!=11441888||
           root.GetProperty("turretSightTransformFileId").GetInt32()!=474009||
           root.GetProperty("turretMuzzleTransformFileId").GetInt32()!=477091)
            throw new InvalidDataException("Helicopter crew artifact lost prefab identity.");
        var rows=root.GetProperty("slots");
        if(rows.GetArrayLength()!=6)throw new InvalidDataException("Helicopter prefab crew slots are incomplete.");
        static Vector3 Vector(JsonElement value)=>new(value[0].GetSingle(),value[1].GetSingle(),value[2].GetSingle());
        static Quaternion Rotation(JsonElement value)=>new(value[0].GetSingle(),value[1].GetSingle(),
            value[2].GetSingle(),value[3].GetSingle());
        var turretPosition=Vector(root.GetProperty("turretPointRestPosition"));
        var turretRotation=Rotation(root.GetProperty("turretPointRestRotation"));
        var sightPosition=Vector(root.GetProperty("turretSightRestPosition"));
        var sightRotation=Rotation(root.GetProperty("turretSightRestRotation"));
        var muzzlePosition=Vector(root.GetProperty("turretMuzzleRestPosition"));
        var muzzleRotation=Rotation(root.GetProperty("turretMuzzleRestRotation"));
        if(!PlayerHitbox.Finite(turretPosition)||!PlayerHitbox.Finite(sightPosition)||
           !PlayerHitbox.Finite(muzzlePosition)||
           !float.IsFinite(turretRotation.LengthSquared())||
           Math.Abs(turretRotation.LengthSquared()-1)>.0002f||
           !float.IsFinite(sightRotation.LengthSquared())||
           Math.Abs(sightRotation.LengthSquared()-1)>.0002f||
           !float.IsFinite(muzzleRotation.LengthSquared())||
           Math.Abs(muzzleRotation.LengthSquared()-1)>.0002f)
            throw new InvalidDataException("Helicopter turret rest geometry is malformed.");
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
        return new(slots,11499861,turretPosition,turretRotation,
            sightPosition,sightRotation,muzzlePosition,muzzleRotation);
    }
    public HelicopterTurretRestPose PlaceTurret(Vector3 rootPosition,Quaternion rootRotation)
    {
        if(!PlayerHitbox.Finite(rootPosition)||!float.IsFinite(rootRotation.LengthSquared())||
           Math.Abs(rootRotation.LengthSquared()-1)>.001f)
            throw new InvalidDataException("Invalid Helicopter turret root placement.");
        var point=rootPosition+Vector3.Transform(TurretPointRestPosition,rootRotation);
        var sight=rootPosition+Vector3.Transform(TurretSightRestPosition,rootRotation);
        var muzzle=rootPosition+Vector3.Transform(TurretMuzzleRestPosition,rootRotation);
        var pointRotation=Quaternion.Normalize(rootRotation*TurretPointRestRotation);
        var sightRotation=Quaternion.Normalize(rootRotation*TurretSightRestRotation);
        var muzzleRotation=Quaternion.Normalize(rootRotation*TurretMuzzleRestRotation);
        if(!PlayerHitbox.Finite(point)||!PlayerHitbox.Finite(sight)||!PlayerHitbox.Finite(muzzle)||
           !float.IsFinite(pointRotation.LengthSquared())||!float.IsFinite(sightRotation.LengthSquared())||
           !float.IsFinite(muzzleRotation.LengthSquared()))
            throw new InvalidDataException("Helicopter turret placement overflow.");
        return new(TurretPointComponentFileId,point,pointRotation,
            sight,sightRotation,muzzle,muzzleRotation);
    }
    public IReadOnlyList<HelicopterCrewPose> PlaceAttached(Vector3 rootPosition,Quaternion rootRotation,int seats)
    {
        if(!PlayerHitbox.Finite(rootPosition)||seats is <0 or >6||
           !float.IsFinite(rootRotation.LengthSquared())||Math.Abs(rootRotation.LengthSquared()-1)>.001f)
            throw new InvalidDataException("Invalid Helicopter root placement.");
        var result=new HelicopterCrewPose[seats];
        for(int i=0;i<seats;i++)
        {
            var slot=Slots[i];
            Vector3 position=rootPosition+Vector3.Transform(slot.RestPosition,rootRotation);
            Vector3 rope=rootPosition+Vector3.Transform(slot.RopeRestPosition,rootRotation);
            Quaternion rotation=Quaternion.Normalize(rootRotation*slot.RestRotation);
            if(!PlayerHitbox.Finite(position)||!PlayerHitbox.Finite(rope)||
               !float.IsFinite(rotation.LengthSquared()))
                throw new InvalidDataException("Helicopter attached crew pose overflow.");
            result[i]=new(i,slot.ComponentFileId,position,rotation,rope);
        }
        return Array.AsReadOnly(result);
    }
}

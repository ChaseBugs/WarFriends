using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace War.BattleServer;

public sealed record ArmyWeaponMuzzle(string UnitId,string Path,Vector3 RestPosition,Quaternion RestRotation);
public sealed record ArmyWeaponWindup(string UnitId,float Seconds,string Rule,string? ClipAsset,
    string? ClipSha256,float? ClipLength);
public sealed record ArmyWeaponCadence(string UnitId,float Seconds,int StrictTicks,string Rule,
    string Source,string SourceSha256);
public sealed record ArmyCommandoPoison(float DurationSeconds,float PulseIntervalSeconds,int PulseCount,
    string Rule,string ConstantsSheet,int ConstantsRow,string BehaviorSource,string BehaviorSha256,
    string BulletSource,string BulletSha256);
public sealed record ArmyShotgunFalloff(string UnitId,float Radius,float ShotHalfAngle,float ShotHalfAngleNear,
    float MinimumDamageRatio,bool FlatY,
    bool ShotOnlyMainBullet,string Rule,string Source,string SourceSha256);
public sealed record ArmySwatSpecialSpeed(string Rule,string Source,string SourceSha256);

/// <summary>Pinned enemy-rig and serialized Rusher weapon spawn-point chains.</summary>
public sealed class ArmyWeaponBindingCatalog
{
    private readonly IReadOnlyDictionary<string,ArmyWeaponMuzzle[]> muzzles;
    private readonly IReadOnlyDictionary<string,ArmyWeaponWindup> windups;
    private readonly IReadOnlyDictionary<string,ArmyWeaponCadence> cadences;
    private readonly IReadOnlyDictionary<string,ArmyShotgunFalloff> shotgunFalloffs;
    public string Revision { get; }
    public string GunSnapPath { get; }
    public Vector3 GunSnapPosition { get; }
    public Quaternion GunSnapRotation { get; }
    public string LeftGunSnapPath { get; }
    public ArmyCommandoPoison CommandoPoison { get; }
    public ArmySwatSpecialSpeed SwatSpecialSpeed { get; }

    private ArmyWeaponBindingCatalog(string revision,TransformRow gun,TransformRow leftGun,
        Dictionary<string,ArmyWeaponMuzzle[]> muzzles,Dictionary<string,ArmyWeaponWindup> windups,
        Dictionary<string,ArmyWeaponCadence> cadences,Dictionary<string,ArmyShotgunFalloff> shotgunFalloffs,
        ArmyCommandoPoison commandoPoison,ArmySwatSpecialSpeed swatSpecialSpeed)
    {Revision=revision;GunSnapPath=gun.Path;GunSnapPosition=gun.Position;GunSnapRotation=gun.Rotation;
     LeftGunSnapPath=leftGun.Path;this.muzzles=muzzles;this.windups=windups;this.cadences=cadences;
     CommandoPoison=commandoPoison;SwatSpecialSpeed=swatSpecialSpeed;this.shotgunFalloffs=shotgunFalloffs;}

    public ArmyWeaponMuzzle Muzzle(string unitId,int index=0)
        =>muzzles.TryGetValue(unitId,out var value)&&index>=0&&index<value.Length
            ?value[index]:throw new ArgumentOutOfRangeException(nameof(unitId));
    public int MuzzleCount(string unitId)
        =>muzzles.TryGetValue(unitId,out var value)?value.Length:throw new ArgumentOutOfRangeException(nameof(unitId));
    public ArmyWeaponWindup Windup(string unitId)
        =>windups.TryGetValue(unitId,out var value)?value:throw new ArgumentOutOfRangeException(nameof(unitId));
    public int WindupTicks(string unitId)=>(int)MathF.Ceiling(Windup(unitId).Seconds*MatchManifest.TickRate);
    public ArmyWeaponCadence Cadence(string unitId)
        =>cadences.TryGetValue(unitId,out var value)?value:throw new ArgumentOutOfRangeException(nameof(unitId));
    public int CadenceTicks(string unitId)=>Cadence(unitId).StrictTicks;
    public ArmyShotgunFalloff? ShotgunFalloff(string unitId)
        =>shotgunFalloffs.TryGetValue(unitId,out var value)?value:null;
    public bool TryProjectileDamage(string unitId,float maximum,Vector3 origin,Vector3 target,out float damage)
    {
        damage=0;
        if(!float.IsFinite(maximum)||maximum<0||maximum>10_000_000||
           !PlayerHitbox.Finite(origin)||!PlayerHitbox.Finite(target))
            throw new InvalidDataException("Invalid army projectile damage inputs.");
        var falloff=ShotgunFalloff(unitId);
        if(falloff==null){damage=maximum;return true;}
        var delta=target-origin;
        float distance=delta.Length();
        var aim=delta;if(falloff.FlatY)aim.Y=0;
        float angle=0;
        if(aim.LengthSquared()>=1e-10f&&delta.LengthSquared()>=1e-10f)
        {
            float cosine=Math.Clamp(Vector3.Dot(Vector3.Normalize(aim),Vector3.Normalize(delta)),-1,1);
            angle=MathF.Acos(cosine)*180/MathF.PI;
        }
        float normalized=Math.Clamp(distance/falloff.Radius,0,1);
        float angleWeight=MathF.Sqrt(MathF.Sqrt(normalized));
        float halfAngle=falloff.ShotHalfAngleNear+
            (falloff.ShotHalfAngle-falloff.ShotHalfAngleNear)*angleWeight;
        if(Math.Abs(angle)>=halfAngle)return false;
        float weight=1-Math.Clamp(distance/falloff.Radius,0,1);
        float minimum=maximum*falloff.MinimumDamageRatio;
        damage=minimum+(maximum-minimum)*weight;
        if(!float.IsFinite(damage)||damage<minimum||damage>maximum)
            throw new InvalidDataException("Army shotgun falloff produced invalid damage.");
        return true;
    }

    public Vector3 RestMuzzleOrigin(string unitId,Vector3 entityPosition,Vector3 planarForward,int index=0)
    {
        if(!PlayerHitbox.Finite(entityPosition)||!PlayerHitbox.Finite(planarForward))
            throw new InvalidDataException("Invalid army muzzle placement.");
        planarForward.Y=0;
        if(planarForward.LengthSquared()<1e-10f)throw new InvalidDataException("Army muzzle has no planar facing.");
        planarForward=Vector3.Normalize(planarForward);
        float yaw=MathF.Atan2(planarForward.X,planarForward.Z);
        return entityPosition+Vector3.Transform(Muzzle(unitId,index).RestPosition,
            Quaternion.CreateFromAxisAngle(Vector3.UnitY,yaw));
    }

    public static ArmyWeaponBindingCatalog Load(string path,string expectedRevision,string sceneRevision)
    {
        byte[] bytes=File.ReadAllBytes(path);
        if(bytes.Length is <100 or >131072||Convert.ToHexStringLower(SHA256.HashData(bytes))!=expectedRevision)
            throw new InvalidDataException("Army weapon binding revision mismatch.");
        using var document=JsonDocument.Parse(bytes,new JsonDocumentOptions{MaxDepth=16});
        var root=document.RootElement;
        Exact(root,"version","sceneSha256","enemyPrefabSha256","gunSnap","leftGunSnap","provenance","commandoPoison","swatSpecialSpeed","families");
        if(root.GetProperty("version").GetInt32()!=8||root.GetProperty("sceneSha256").GetString()!=sceneRevision||
           !Hash(root.GetProperty("enemyPrefabSha256").GetString())||
           root.GetProperty("provenance").GetString()!=
             "serialized EnemyBasicInventory weapon references plus enemy rig and weapon spawn-point transform chains; runtime weapon IDs remain unresolved")
            throw new InvalidDataException("Invalid army weapon provenance.");
        var gun=Transform(root.GetProperty("gunSnap"),"enemy/");
        var leftGun=Transform(root.GetProperty("leftGunSnap"),"enemy/");
        if(gun.Path==leftGun.Path)throw new InvalidDataException("Rusher gun snaps are not distinct.");
        var poisonRow=root.GetProperty("commandoPoison");
        Exact(poisonRow,"durationSeconds","pulseIntervalSeconds","pulseCount","rule","constantsSheet",
            "constantsRow","behaviorSource","behaviorSha256","bulletSource","bulletSha256");
        var poison=new ArmyCommandoPoison(poisonRow.GetProperty("durationSeconds").GetSingle(),
            poisonRow.GetProperty("pulseIntervalSeconds").GetSingle(),poisonRow.GetProperty("pulseCount").GetInt32(),
            poisonRow.GetProperty("rule").GetString()??"",poisonRow.GetProperty("constantsSheet").GetString()??"",
            poisonRow.GetProperty("constantsRow").GetInt32(),poisonRow.GetProperty("behaviorSource").GetString()??"",
            poisonRow.GetProperty("behaviorSha256").GetString()??"",poisonRow.GetProperty("bulletSource").GetString()??"",
            poisonRow.GetProperty("bulletSha256").GetString()??"");
        if(poison.DurationSeconds!=5||poison.PulseIntervalSeconds!=1||poison.PulseCount!=5||
           poison.Rule!="immediate-then-wait-one-second-while-before-duration"||
           poison.ConstantsSheet!="Google2u.UnitsContants"||poison.ConstantsRow!=2||
           poison.BehaviorSource!="Assets/Scripts/Assembly-CSharp/SoldierBehaviourCommando.cs"||
           poison.BulletSource!="Assets/Scripts/Assembly-CSharp/BulletPoison.cs"||
           !Hash(poison.BehaviorSha256)||!Hash(poison.BulletSha256))
            throw new InvalidDataException("Invalid source Commando poison policy.");
        var swatRow=root.GetProperty("swatSpecialSpeed");
        Exact(swatRow,"rule","source","sha256");
        var swatSpecialSpeed=new ArmySwatSpecialSpeed(swatRow.GetProperty("rule").GetString()??"",
            swatRow.GetProperty("source").GetString()??"",swatRow.GetProperty("sha256").GetString()??"");
        if(swatSpecialSpeed.Rule!="selected-special-multiplies-runtime-speed-by-one-plus-composed-special"||
           swatSpecialSpeed.Source!="Assets/Scripts/Assembly-CSharp/SoldierBehaviourSwat.cs"||!Hash(swatSpecialSpeed.SourceSha256))
            throw new InvalidDataException("Invalid source SWAT special-speed policy.");
        var families=root.GetProperty("families");
        if(families.GetArrayLength()!=6)throw new InvalidDataException("Incomplete Rusher weapon family set.");
        var result=new Dictionary<string,ArmyWeaponMuzzle[]>(StringComparer.Ordinal);
        var windups=new Dictionary<string,ArmyWeaponWindup>(StringComparer.Ordinal);
        var cadences=new Dictionary<string,ArmyWeaponCadence>(StringComparer.Ordinal);
        var shotgunFalloffs=new Dictionary<string,ArmyShotgunFalloff>(StringComparer.Ordinal);
        foreach(var family in families.EnumerateArray())
        {
            Exact(family,"unitId","behaviorType","behaviorFileId","attackWindup","attackCadence","shotgunFalloff","inventory");
            string unit=family.GetProperty("unitId").GetString()??"";
            if(!Regex.IsMatch(unit,@"\AID_UNIT-[A-Z0-9-]{1,50}\z")||result.ContainsKey(unit))
                throw new InvalidDataException("Invalid army weapon unit identity.");
            var inventory=family.GetProperty("inventory");
            if(inventory.GetArrayLength() is <1 or >2)throw new InvalidDataException("Invalid Rusher inventory size.");
            var familyMuzzles=new List<ArmyWeaponMuzzle>();
            int firstWeaponType=-1;
            foreach(var weapon in inventory.EnumerateArray())
            {
                Exact(weapon,"fileId","weaponFileId","guid","asset","weaponType","prefabWeaponType","leftHand","projectile","spawnPoint");
                int weaponType=weapon.GetProperty("weaponType").GetInt32();
                int prefabWeaponType=weapon.GetProperty("prefabWeaponType").GetInt32();
                if(firstWeaponType<0)firstWeaponType=weaponType;
                if(weapon.GetProperty("fileId").GetInt32()<=0||weapon.GetProperty("weaponFileId").GetInt32()<=0||
                   !Regex.IsMatch(weapon.GetProperty("guid").GetString()??"",@"\A[0-9a-f]{32}\z")||
                   weaponType is <0 or >32||prefabWeaponType is <0 or >32)
                    throw new InvalidDataException("Invalid Rusher weapon identity.");
                var spawn=Transform(weapon.GetProperty("spawnPoint"),"");
                var attachment=weapon.GetProperty("leftHand").GetBoolean()?leftGun:gun;
                var combinedPosition=attachment.Position+Vector3.Transform(spawn.Position,attachment.Rotation);
                var combinedRotation=Quaternion.Normalize(attachment.Rotation*spawn.Rotation);
                var muzzle=new ArmyWeaponMuzzle(unit,spawn.Path,combinedPosition,combinedRotation);
                familyMuzzles.Add(muzzle);
            }
            var windup=family.GetProperty("attackWindup");
            Exact(windup,"seconds","rule","clip");
            float seconds=windup.GetProperty("seconds").GetSingle();
            string rule=windup.GetProperty("rule").GetString()??"";
            string? clipAsset=null,clipHash=null;float? clipLength=null;
            var clip=windup.GetProperty("clip");
            if(clip.ValueKind!=JsonValueKind.Null)
            {
                Exact(clip,"asset","sha256","length");
                clipAsset=clip.GetProperty("asset").GetString();
                clipHash=clip.GetProperty("sha256").GetString();
                clipLength=clip.GetProperty("length").GetSingle();
            }
            bool flame=firstWeaponType==12,swat=firstWeaponType is 3 or 4;
            if(!float.IsFinite(seconds)||seconds<0||seconds>5||
               flame!=(rule=="flamethrower-zero")||swat!=(rule=="swat-shield-unhide")||
               (!flame&&!swat)!=(rule=="stand-shoot-30-percent")||
               (flame&&(seconds!=0||clip.ValueKind!=JsonValueKind.Null))||
               (!flame&&(clipAsset==null||!clipAsset.StartsWith("Assets/AnimationClip/",StringComparison.Ordinal)||
                 !Hash(clipHash)||clipLength is not 1f||seconds!=(swat?1f:.3f))))
                throw new InvalidDataException("Invalid source Rusher attack windup.");
            if((unit=="ID_UNIT-COMMANDO")!=(familyMuzzles.Count==2) ||
               unit=="ID_UNIT-COMMANDO"&&(firstWeaponType!=14||
                 inventory.EnumerateArray().Any(x=>x.GetProperty("weaponType").GetInt32()!=14)||
                 inventory[0].GetProperty("leftHand").GetBoolean()||
                 !inventory[1].GetProperty("leftHand").GetBoolean()))
                throw new InvalidDataException("Invalid source Commando dual inventory.");
            result.Add(unit,familyMuzzles.ToArray());
            windups.Add(unit,new(unit,seconds,rule,clipAsset,clipHash,clipLength));
            var cadence=family.GetProperty("attackCadence");
            Exact(cadence,"seconds","strictTicks","rule","source","sha256");
            float cadenceSeconds=cadence.GetProperty("seconds").GetSingle();
            int cadenceTicks=cadence.GetProperty("strictTicks").GetInt32();
            string cadenceRule=cadence.GetProperty("rule").GetString()??"";
            string cadenceSource=cadence.GetProperty("source").GetString()??"";
            string cadenceHash=cadence.GetProperty("sha256").GetString()??"";
            int expectedTicks=(int)MathF.Floor(cadenceSeconds*MatchManifest.TickRate)+1;
            if(!float.IsFinite(cadenceSeconds)||cadenceSeconds<=0||cadenceSeconds>2||
               cadenceTicks!=expectedTicks||cadenceTicks is <1 or >61||
               cadenceRule is not ("base-soldier" or "subclass-override")||
               !cadenceSource.StartsWith("Assets/Scripts/Assembly-CSharp/SoldierBehaviour",StringComparison.Ordinal)||
               !cadenceSource.EndsWith(".cs",StringComparison.Ordinal)||!Hash(cadenceHash))
                throw new InvalidDataException("Invalid source Rusher attack cadence.");
            cadences.Add(unit,new(unit,cadenceSeconds,cadenceTicks,cadenceRule,cadenceSource,cadenceHash));
            var falloffRow=family.GetProperty("shotgunFalloff");
            bool expectsFalloff=family.GetProperty("behaviorType").GetString() is
                "SoldierBehaviourShotgunner" or "SoldierBehaviourWarper";
            if(expectsFalloff)
            {
                Exact(falloffRow,"radius","shotHalfAngle","shotHalfAngleNear","minimumDamageRatio","flatY","shotOnlyMainBullet","rule","source","sha256");
                var falloff=new ArmyShotgunFalloff(unit,falloffRow.GetProperty("radius").GetSingle(),
                    falloffRow.GetProperty("shotHalfAngle").GetSingle(),falloffRow.GetProperty("shotHalfAngleNear").GetSingle(),
                    falloffRow.GetProperty("minimumDamageRatio").GetSingle(),falloffRow.GetProperty("flatY").GetBoolean(),
                    falloffRow.GetProperty("shotOnlyMainBullet").GetBoolean(),falloffRow.GetProperty("rule").GetString()??"",
                    falloffRow.GetProperty("source").GetString()??"",falloffRow.GetProperty("sha256").GetString()??"");
                if(falloff.Radius!=3||falloff.ShotHalfAngle!=10||falloff.ShotHalfAngleNear!=75||
                   falloff.MinimumDamageRatio!=.1f||!falloff.FlatY||!falloff.ShotOnlyMainBullet||
                   falloff.Rule!="min-plus-max-minus-min-times-one-minus-clamped-distance-over-radius"||
                   falloff.Source!=$"Assets/Scripts/Assembly-CSharp/{family.GetProperty("behaviorType").GetString()}.cs"||
                   !Hash(falloff.SourceSha256))
                    throw new InvalidDataException("Invalid source Rusher shotgun falloff.");
                shotgunFalloffs.Add(unit,falloff);
            }
            else if(falloffRow.ValueKind!=JsonValueKind.Null)
                throw new InvalidDataException("Unexpected Rusher shotgun falloff.");
        }
        if(shotgunFalloffs.Count!=2)throw new InvalidDataException("Incomplete Rusher shotgun falloff set.");
        return new(expectedRevision,gun,leftGun,result,windups,cadences,shotgunFalloffs,poison,swatSpecialSpeed);
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

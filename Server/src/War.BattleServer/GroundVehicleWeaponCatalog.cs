using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace War.BattleServer;

public sealed record GroundVehicleWeapon(int BatchedComponentFileId,int WeaponComponentFileId,
    string WeaponType,float Cadence,int SpawnTransformFileId,Vector3 MuzzlePosition,Vector3 ShotOffset,
    int ProjectileFileId,string ProjectileGuid,bool ForcedFake,GroundVehicleMissileBinding? Missile);
public sealed record GroundVehicleMissileBinding(int SetupComponentFileId,float Speed,float MinimumDamage,float HurtRadius,
    float DeadRadius,Vector3 ExplosionCoefficient,float AdditionalUpForce,float StopTime,int MissileType,
    bool CurvedTrajectory,Vector2 RotationRange,IReadOnlyList<BazookaCurveKey> RotationProfile,
    float BaseRotationMagnitude);
public sealed record GroundVehicleTurret(string Role,int TurretComponentFileId,string TurretType,
    float AimTime,float MaxShotRotation,bool UseUnitTarget,bool PrimaryTargetOnly,
    bool NeedToSeePrimaryTarget,bool NeedToSeeSecondaryTarget,bool PredictPosition,int PrimaryTarget,
    int SerializedTargetMask,float SecondaryDelay,int FakeShotEvery,IReadOnlyList<GroundVehicleWeapon> Weapons);
public sealed record GroundVehiclePassengerBinding(string Role,int PointComponentFileId,
    int TransformFileId,Vector3 Position,Quaternion Rotation);
public sealed record GroundVehicleBodyCollider(int ColliderFileId,PlayerHitboxKind Kind,
    Vector3 Center,Quaternion Rotation,Vector3 Size,float Radius,Vector3 Axis,float HalfSegment,bool Trigger);
public sealed record GroundVehicleBodyPart(int PartComponentFileId,int TransformFileId,int Layer,float Weight,
    IReadOnlyList<GroundVehicleBodyCollider> Colliders);
public sealed record RepairDroneWaypoint(int ComponentFileId,int TransformFileId,int Index,
    Vector3 Position,float StayTime);
public sealed record RepairDronePath(int ComponentFileId,float Radius,
    IReadOnlyList<RepairDroneWaypoint> Waypoints);
public sealed record RepairDronePrefabBinding(string Prefab,string Sha256,int ComponentFileId,
    int SteeringComponentFileId,float BreakDistance,float BreakSpeed,bool InitialForward,bool Loop,
    float Mass,float Multiplier,float Speed,float CornerDelayTime,float HealIntervalSeconds,
    float RespawnMinimumSeconds,float RespawnMaximumSeconds,float DeadRadius,float HurtRadius,
    float ExplosionDamageRatio,float SplashDamageRatio);
public sealed record GroundVehicleWeaponRig(string UnitId,string Prefab,string Sha256,string BehaviorType,
    IReadOnlyList<GroundVehicleTurret> Roles,IReadOnlyList<GroundVehiclePassengerBinding> Passengers,
    IReadOnlyList<GroundVehicleBodyPart> BodyParts,IReadOnlyList<RepairDronePath> RepairDronePaths);

/// <summary>Immutable turret and muzzle evidence extracted from the four 1.4.0 ground-vehicle prefabs.</summary>
public sealed class GroundVehicleWeaponCatalog
{
    private sealed class Root {public int Version{get;set;}public float ArmoredVehicleShotCoefficient{get;set;}
        public string PassengerPoseRevision{get;set;}="";
        public RepairDronePrefabDto RepairDronePrefab{get;set;}=new();
        public VehicleDto[] Vehicles{get;set;}=[];}
    private sealed class VehicleDto {public string UnitId{get;set;}="";public string Prefab{get;set;}="";
        public string Sha256{get;set;}="";public string BehaviorType{get;set;}="";public TurretDto[] Roles{get;set;}=[];
        public PassengerDto[] Passengers{get;set;}=[];public BodyPartDto[] BodyParts{get;set;}=[];
        public RepairDronePathDto[] RepairDronePaths{get;set;}=[];}
    private sealed class RepairDronePrefabDto {public string Prefab{get;set;}="";public string Sha256{get;set;}="";
        public int ComponentFileId{get;set;}public int SteeringComponentFileId{get;set;}
        public float BreakDistance{get;set;}public float BreakSpeed{get;set;}public bool InitialForward{get;set;}
        public bool Loop{get;set;}public float Mass{get;set;}public float Multiplier{get;set;}public float Speed{get;set;}
        public float CornerDelayTime{get;set;}public float HealIntervalSeconds{get;set;}
        public float RespawnMinimumSeconds{get;set;}public float RespawnMaximumSeconds{get;set;}
        public float DeadRadius{get;set;}public float HurtRadius{get;set;}
        public float ExplosionDamageRatio{get;set;}public float SplashDamageRatio{get;set;}}
    private sealed class RepairDronePathDto {public int ComponentFileId{get;set;}public float Radius{get;set;}
        public RepairDroneWaypointDto[] Waypoints{get;set;}=[];}
    private sealed class RepairDroneWaypointDto {public int ComponentFileId{get;set;}public int TransformFileId{get;set;}
        public int Index{get;set;}public float[] Position{get;set;}=[];public float StayTime{get;set;}}
    private sealed class PassengerDto {public string Role{get;set;}="";public int PointComponentFileId{get;set;}
        public int TransformFileId{get;set;}public float[] Position{get;set;}=[];public float[] Rotation{get;set;}=[];}
    private sealed class TurretDto {public string Role{get;set;}="";public int TurretComponentFileId{get;set;}
        public string TurretType{get;set;}="";public float AimTime{get;set;}public float MaxShotRotation{get;set;}
        public bool UseUnitTarget{get;set;}public bool PrimaryTargetOnly{get;set;}
        public bool NeedToSeePrimaryTarget{get;set;}public bool NeedToSeeSecondaryTarget{get;set;}
        public bool PredictPosition{get;set;}public int PrimaryTarget{get;set;}public int SerializedTargetMask{get;set;}
        public float SecondaryDelay{get;set;}public int FakeShotEvery{get;set;}public WeaponDto[] Weapons{get;set;}=[];}
    private sealed class WeaponDto {public int BatchedComponentFileId{get;set;}public int WeaponComponentFileId{get;set;}
        public string WeaponType{get;set;}="";public float Cadence{get;set;}public int SpawnTransformFileId{get;set;}
        public float[] MuzzlePosition{get;set;}=[];public float[] ShotOffset{get;set;}=[];public int ProjectileFileId{get;set;}
        public string ProjectileGuid{get;set;}="";public bool ForcedFake{get;set;}public MissileDto? Missile{get;set;}}
    private sealed class MissileDto {public int SetupComponentFileId{get;set;}public float Speed{get;set;}
        public float MinimumDamage{get;set;}
        public float HurtRadius{get;set;}public float DeadRadius{get;set;}public float[] ExplosionCoefficient{get;set;}=[];
        public float AdditionalUpForce{get;set;}public float StopTime{get;set;}public int MissileType{get;set;}
        public bool CurvedTrajectory{get;set;}public float[] RotationRange{get;set;}=[];
        public CurveDto[] RotationProfile{get;set;}=[];public float BaseRotationMagnitude{get;set;}}
    private sealed class CurveDto {public float Time{get;set;}public float Value{get;set;}
        public float InTangent{get;set;}public float OutTangent{get;set;}}
    private sealed class BodyPartDto {public int PartComponentFileId{get;set;}public int TransformFileId{get;set;}
        public int Layer{get;set;}public float Weight{get;set;}public ColliderDto[] Colliders{get;set;}=[];}
    private sealed class ColliderDto {public int ColliderFileId{get;set;}public string Type{get;set;}="";
        public float[] Center{get;set;}=[];public float[] Rotation{get;set;}=[];public float[] Size{get;set;}=[];
        public float Radius{get;set;}public float[] Axis{get;set;}=[];public float HalfSegment{get;set;}public bool Trigger{get;set;}}
    private static readonly (string Unit,string Prefab,string Behavior,int Roles)[] Expected=
    [
        ("ID_UNIT-HUMVEE","Assets/GameObject/Humvee.prefab","AICar",2),
        ("ID_UNIT-TANK","Assets/GameObject/Tank.prefab","Tank",2),
        ("ID_UNIT-BUGGY","Assets/GameObject/Buggy.prefab","AICarBuggy",2),
        ("ID_UNIT-TRANSPORTER","Assets/GameObject/Transporter.prefab","AICarTransporter",1)
    ];
    private static readonly IReadOnlyDictionary<string,string[]> ExpectedPassengers=
        new Dictionary<string,string[]>(StringComparer.Ordinal)
        {
            ["ID_UNIT-HUMVEE"]=["gunner"],
            ["ID_UNIT-TANK"]=["turret","cannon"],
            ["ID_UNIT-BUGGY"]=["driver","co-driver"],
            ["ID_UNIT-TRANSPORTER"]=["co-driver"]
        };
    private readonly IReadOnlyDictionary<string,GroundVehicleWeaponRig> rigs;
    public string Revision { get; }
    public float ArmoredVehicleShotCoefficient { get; }
    public RepairDronePrefabBinding RepairDronePrefab {get;}
    internal VehiclePassengerPoseCatalog PassengerPoses {get;}
    private GroundVehicleWeaponCatalog(string revision,Dictionary<string,GroundVehicleWeaponRig> rigs,
        VehiclePassengerPoseCatalog passengerPoses,RepairDronePrefabBinding repairDronePrefab)
    {Revision=revision;this.rigs=rigs;ArmoredVehicleShotCoefficient=.33f;PassengerPoses=passengerPoses;
        RepairDronePrefab=repairDronePrefab;}
    public GroundVehicleWeaponRig For(string unitId)=>rigs.TryGetValue(unitId,out var rig)?rig:
        throw new ArgumentOutOfRangeException(nameof(unitId));

    public Vector3 RestMuzzleOrigin(string unitId,string role,int weaponIndex,
        Vector3 entityPosition,Vector3 planarForward)
    {
        if(!PlayerHitbox.Finite(entityPosition)||!PlayerHitbox.Finite(planarForward))
            throw new InvalidDataException("Invalid ground vehicle muzzle placement.");
        var turret=For(unitId).Roles.SingleOrDefault(r=>r.Role==role)??
            throw new ArgumentOutOfRangeException(nameof(role));
        if(weaponIndex<0||weaponIndex>=turret.Weapons.Count)
            throw new ArgumentOutOfRangeException(nameof(weaponIndex));
        planarForward.Y=0;
        if(planarForward.LengthSquared()<1e-10f)
            throw new InvalidDataException("Ground vehicle muzzle has no planar facing.");
        planarForward=Vector3.Normalize(planarForward);
        float yaw=MathF.Atan2(planarForward.X,planarForward.Z);
        return entityPosition+Vector3.Transform(turret.Weapons[weaponIndex].MuzzlePosition,
            Quaternion.CreateFromAxisAngle(Vector3.UnitY,yaw));
    }

    internal IReadOnlyList<DynamicShotTarget> PlaceBody(string unitId,ulong entityId,
        Vector3 entityPosition,Vector3 planarForward)
    {
        if(entityId==0||!PlayerHitbox.Finite(entityPosition)||!PlayerHitbox.Finite(planarForward))
            throw new InvalidDataException("Invalid ground vehicle body placement.");
        planarForward.Y=0;
        if(planarForward.LengthSquared()<1e-10f)throw new InvalidDataException("Ground vehicle body has no planar facing.");
        float yaw=MathF.Atan2(planarForward.X,planarForward.Z);
        var facing=Quaternion.CreateFromAxisAngle(Vector3.UnitY,yaw);
        return For(unitId).BodyParts.SelectMany(part=>part.Colliders.Select(c=>
        {
            var center=entityPosition+Vector3.Transform(c.Center,facing);
            var rotation=Quaternion.Normalize(facing*c.Rotation);
            var axis=c.Axis==Vector3.Zero?Vector3.Zero:Vector3.Normalize(Vector3.Transform(c.Axis,facing));
            var hitbox=new PlayerHitbox($"{For(unitId).Prefab}#{part.PartComponentFileId}/{c.ColliderFileId}",
                c.Kind,part.Weight,center,c.Size,rotation,c.Radius,axis,c.HalfSegment,true,true);
            return new DynamicShotTarget(entityId,part.PartComponentFileId,part.Layer,hitbox);
        })).ToArray();
    }

    public static GroundVehicleWeaponCatalog Load(string path,string expectedRevision)
    {
        byte[] bytes=File.ReadAllBytes(path);
        if(bytes.Length is <1000 or >200000||Convert.ToHexStringLower(SHA256.HashData(bytes))!=expectedRevision)
            throw new InvalidDataException("Ground vehicle weapon revision mismatch.");
        Root root;
        try {root=JsonSerializer.Deserialize<Root>(bytes,new JsonSerializerOptions
            {PropertyNameCaseInsensitive=true,UnmappedMemberHandling=JsonUnmappedMemberHandling.Disallow})??
            throw new InvalidDataException("Missing ground vehicle weapon artifact.");}
        catch(JsonException e){throw new InvalidDataException("Malformed ground vehicle weapon artifact.",e);}
        if(root.Version!=7||root.ArmoredVehicleShotCoefficient!=.33f||
           !Regex.IsMatch(root.PassengerPoseRevision,@"\A[0-9a-f]{64}\z")||root.Vehicles.Length!=Expected.Length)
            throw new InvalidDataException("Incomplete ground vehicle weapon artifact.");
        var drone=root.RepairDronePrefab;
        if(drone.Prefab!="Assets/GameObject/miniDrone.prefab"||
           !Regex.IsMatch(drone.Sha256,@"\A[0-9a-f]{64}\z")||drone.ComponentFileId<=0||
           drone.SteeringComponentFileId<=0||drone.BreakDistance!=.4f||drone.BreakSpeed!=.5f||
           !drone.InitialForward||!drone.Loop||drone.Mass!=30||drone.Multiplier!=150000||
           drone.Speed!=.4f||drone.CornerDelayTime!=.3f||drone.HealIntervalSeconds!=1||
           drone.RespawnMinimumSeconds!=35||drone.RespawnMaximumSeconds!=45||
           drone.DeadRadius!=.7f||drone.HurtRadius!=1.4f||drone.ExplosionDamageRatio!=.5f||
           drone.SplashDamageRatio!=.05f)
            throw new InvalidDataException("Recovered repair-drone prefab contract changed.");
        var repairDronePrefab=new RepairDronePrefabBinding(drone.Prefab,drone.Sha256,drone.ComponentFileId,
            drone.SteeringComponentFileId,drone.BreakDistance,drone.BreakSpeed,drone.InitialForward,
            drone.Loop,drone.Mass,drone.Multiplier,drone.Speed,drone.CornerDelayTime,
            drone.HealIntervalSeconds,drone.RespawnMinimumSeconds,drone.RespawnMaximumSeconds,
            drone.DeadRadius,drone.HurtRadius,drone.ExplosionDamageRatio,drone.SplashDamageRatio);
        var result=new Dictionary<string,GroundVehicleWeaponRig>(StringComparer.Ordinal);
        int turretCount=0,weaponCount=0;
        for(int i=0;i<Expected.Length;i++)
        {
            var source=root.Vehicles[i];var expected=Expected[i];
            if(source.UnitId!=expected.Unit||source.Prefab!=expected.Prefab||source.BehaviorType!=expected.Behavior||
               !Regex.IsMatch(source.Sha256,@"\A[0-9a-f]{64}\z")||source.Roles.Length!=expected.Roles)
                throw new InvalidDataException("Ground vehicle prefab identity changed.");
            var roles=new GroundVehicleTurret[source.Roles.Length];var roleNames=new HashSet<string>(StringComparer.Ordinal);
            for(int r=0;r<roles.Length;r++)
            {
                var turret=source.Roles[r];
                if(turret.Role is not ("primary" or "cannon")||!roleNames.Add(turret.Role)||
                   turret.TurretComponentFileId<=0||turret.TurretType is not ("TurretWeaponBasic" or
                       "TurretWeaponMultipleWeapons" or "TransporterTurret")||
                   !float.IsFinite(turret.AimTime)||turret.AimTime<0||turret.AimTime>30||
                   !float.IsFinite(turret.MaxShotRotation)||turret.MaxShotRotation<=0||turret.MaxShotRotation>360||
                   turret.PrimaryTarget is <0 or >3||turret.SerializedTargetMask is <0 or >31||
                   !float.IsFinite(turret.SecondaryDelay)||turret.SecondaryDelay<0||turret.SecondaryDelay>10||
                   turret.FakeShotEvery is <0 or >16||turret.Weapons.Length is <1 or >4)
                    throw new InvalidDataException("Invalid ground vehicle turret contract.");
                var weapons=new GroundVehicleWeapon[turret.Weapons.Length];var batches=new HashSet<int>();
                for(int w=0;w<weapons.Length;w++)
                {
                    var weapon=turret.Weapons[w];
                    if(weapon.BatchedComponentFileId<=0||!batches.Add(weapon.BatchedComponentFileId)||
                       weapon.WeaponComponentFileId<=0||weapon.WeaponType is not ("Gun" or "AutomaticRifle" or "Bazooka")||
                       !float.IsFinite(weapon.Cadence)||weapon.Cadence<=0||weapon.Cadence>10||
                       weapon.SpawnTransformFileId<=0||weapon.ProjectileFileId<=0||
                       !Regex.IsMatch(weapon.ProjectileGuid,@"\A[0-9a-f]{32}\z"))
                        throw new InvalidDataException("Invalid ground vehicle weapon contract.");
                    GroundVehicleMissileBinding? missile=null;
                    if(weapon.WeaponType=="Bazooka")
                    {
                        var m=weapon.Missile??throw new InvalidDataException("Missing vehicle missile setup.");
                        if(m.SetupComponentFileId<=0||!float.IsFinite(m.Speed)||m.Speed<=0||
                           !float.IsFinite(m.MinimumDamage)||m.MinimumDamage<0||m.MinimumDamage>10_000_000||
                           !float.IsFinite(m.HurtRadius)||!float.IsFinite(m.DeadRadius)||m.DeadRadius<=0||
                           m.HurtRadius<m.DeadRadius||m.MissileType is <0 or >3||m.RotationRange.Length!=2||
                           !float.IsFinite(m.RotationRange[0])||!float.IsFinite(m.RotationRange[1])||
                           m.RotationRange[0]<0||m.RotationRange[1]<m.RotationRange[0]||
                           !float.IsFinite(m.BaseRotationMagnitude)||m.BaseRotationMagnitude<0||
                           !float.IsFinite(m.AdditionalUpForce)||!float.IsFinite(m.StopTime)||m.StopTime<0||
                           m.ExplosionCoefficient.Length!=3||m.RotationProfile.Length is not (3 or 5))
                            throw new InvalidDataException("Invalid vehicle missile setup.");
                        var curve=new BazookaCurveKey[m.RotationProfile.Length];
                        for(int k=0;k<curve.Length;k++)
                        {
                            var key=m.RotationProfile[k];
                            if(!float.IsFinite(key.Time)||!float.IsFinite(key.Value)||
                               !float.IsFinite(key.InTangent)||!float.IsFinite(key.OutTangent)||
                               key.Time<0||key.Time>1||(k>0&&key.Time<=curve[k-1].Time))
                                throw new InvalidDataException("Invalid vehicle missile curve.");
                            curve[k]=new(key.Time,key.Value,key.InTangent,key.OutTangent);
                        }
                        if(curve[0].Time!=0||curve[^1].Time!=1)
                            throw new InvalidDataException("Incomplete vehicle missile curve.");
                        missile=new(m.SetupComponentFileId,m.Speed,m.MinimumDamage,m.HurtRadius,m.DeadRadius,
                            Vector(m.ExplosionCoefficient),m.AdditionalUpForce,m.StopTime,m.MissileType,
                            m.CurvedTrajectory,new(m.RotationRange[0],m.RotationRange[1]),
                            Array.AsReadOnly(curve),m.BaseRotationMagnitude);
                    }
                    else if(weapon.Missile!=null)throw new InvalidDataException("Gun has missile setup.");
                    weapons[w]=new(weapon.BatchedComponentFileId,weapon.WeaponComponentFileId,weapon.WeaponType,
                        weapon.Cadence,weapon.SpawnTransformFileId,Vector(weapon.MuzzlePosition),Vector(weapon.ShotOffset),
                        weapon.ProjectileFileId,weapon.ProjectileGuid,weapon.ForcedFake,missile);
                }
                roles[r]=new(turret.Role,turret.TurretComponentFileId,turret.TurretType,turret.AimTime,
                    turret.MaxShotRotation,turret.UseUnitTarget,turret.PrimaryTargetOnly,turret.NeedToSeePrimaryTarget,
                    turret.NeedToSeeSecondaryTarget,turret.PredictPosition,turret.PrimaryTarget,
                    turret.SerializedTargetMask,turret.SecondaryDelay,turret.FakeShotEvery,Array.AsReadOnly(weapons));
                turretCount++;weaponCount+=weapons.Length;
            }
            if(roles[0].Role!="primary"||roles.Length==2&&roles[1].Role!="cannon")
                throw new InvalidDataException("Ground vehicle turret order changed.");
            var expectedPassengers=ExpectedPassengers[source.UnitId];
            if(source.Passengers.Length!=expectedPassengers.Length)
                throw new InvalidDataException("Ground vehicle passenger topology changed.");
            var passengers=new GroundVehiclePassengerBinding[source.Passengers.Length];
            var componentIds=new HashSet<int>();var transformIds=new HashSet<int>();
            for(int p=0;p<passengers.Length;p++)
            {
                var passenger=source.Passengers[p];
                if(passenger.Role!=expectedPassengers[p]||passenger.PointComponentFileId<=0||
                   passenger.TransformFileId<=0||!componentIds.Add(passenger.PointComponentFileId)||
                   !transformIds.Add(passenger.TransformFileId))
                    throw new InvalidDataException("Invalid ground vehicle passenger identity.");
                passengers[p]=new(passenger.Role,passenger.PointComponentFileId,
                    passenger.TransformFileId,Vector(passenger.Position),Rotation(passenger.Rotation));
            }
            int expectedParts=source.UnitId switch {"ID_UNIT-HUMVEE"=>8,"ID_UNIT-TANK"=>12,
                "ID_UNIT-BUGGY"=>8,"ID_UNIT-TRANSPORTER"=>12,_=>0};
            if(source.BodyParts.Length!=expectedParts)throw new InvalidDataException("Ground vehicle body topology changed.");
            var bodyParts=new GroundVehicleBodyPart[source.BodyParts.Length];var partIds=new HashSet<int>();
            var colliderIds=new HashSet<int>();int colliderCount=0;
            for(int b=0;b<bodyParts.Length;b++)
            {
                var part=source.BodyParts[b];
                if(part.PartComponentFileId<=0||part.TransformFileId<=0||!partIds.Add(part.PartComponentFileId)||
                   part.Layer is <0 or >31||part.Weight!=1||part.Colliders.Length is <1 or >2)
                    throw new InvalidDataException("Invalid ground vehicle body part.");
                var colliders=new GroundVehicleBodyCollider[part.Colliders.Length];
                for(int c=0;c<colliders.Length;c++)
                {
                    var collider=part.Colliders[c];
                    if(collider.ColliderFileId<=0||!colliderIds.Add(collider.ColliderFileId)||
                       !Enum.TryParse<PlayerHitboxKind>(collider.Type.Replace("Collider",""),out var kind))
                        throw new InvalidDataException("Invalid ground vehicle body collider.");
                    var center=Vector(collider.Center);var rotation=Rotation(collider.Rotation);
                    var size=Vector(collider.Size);var axis=Vector(collider.Axis);
                    _=new PlayerHitbox("validation",kind,part.Weight,center,size,rotation,
                        collider.Radius,axis,collider.HalfSegment);
                    colliders[c]=new(collider.ColliderFileId,kind,center,rotation,size,
                        collider.Radius,axis,collider.HalfSegment,collider.Trigger);colliderCount++;
                }
                bodyParts[b]=new(part.PartComponentFileId,part.TransformFileId,part.Layer,part.Weight,
                    Array.AsReadOnly(colliders));
            }
            int expectedDronePaths=source.UnitId=="ID_UNIT-TRANSPORTER"?2:0;
            if(source.RepairDronePaths.Length!=expectedDronePaths)
                throw new InvalidDataException("Ground vehicle repair-drone topology changed.");
            var repairPaths=new RepairDronePath[source.RepairDronePaths.Length];var pathIds=new HashSet<int>();
            for(int d=0;d<repairPaths.Length;d++)
            {
                var dronePath=source.RepairDronePaths[d];
                if(dronePath.ComponentFileId<=0||!pathIds.Add(dronePath.ComponentFileId)||dronePath.Radius!=.1f||
                   dronePath.Waypoints.Length!=7)
                    throw new InvalidDataException("Invalid repair-drone path.");
                var waypoints=new RepairDroneWaypoint[7];var waypointIds=new HashSet<int>();
                for(int w=0;w<waypoints.Length;w++)
                {
                    var point=dronePath.Waypoints[w];
                    if(point.ComponentFileId<=0||point.TransformFileId<=0||
                       !waypointIds.Add(point.ComponentFileId)||point.Index!=w||
                       !float.IsFinite(point.StayTime)||point.StayTime is <0 or >30||
                       point.StayTime!=(w%2==1&&w<6?3:0))
                        throw new InvalidDataException("Invalid repair-drone waypoint.");
                    waypoints[w]=new(point.ComponentFileId,point.TransformFileId,point.Index,
                        Vector(point.Position),point.StayTime);
                }
                repairPaths[d]=new(dronePath.ComponentFileId,dronePath.Radius,Array.AsReadOnly(waypoints));
            }
            result.Add(source.UnitId,new(source.UnitId,source.Prefab,source.Sha256,source.BehaviorType,
                Array.AsReadOnly(roles),Array.AsReadOnly(passengers),Array.AsReadOnly(bodyParts),
                Array.AsReadOnly(repairPaths)));
        }
        if(turretCount!=7||weaponCount!=9||result.Values.Sum(x=>x.BodyParts.Sum(p=>p.Colliders.Count))!=41)
            throw new InvalidDataException("Incomplete ground vehicle weapon graph.");
        var passengerPoses=VehiclePassengerPoseCatalog.Load(Path.Combine(Path.GetDirectoryName(path)!,
            "recovered-vehicle-passenger-poses.json"),root.PassengerPoseRevision);
        return new(expectedRevision,result,passengerPoses,repairDronePrefab);
    }
    private static Vector3 Vector(float[] value)
    {
        if(value.Length!=3)throw new InvalidDataException("Invalid vehicle weapon vector.");
        var result=new Vector3(value[0],value[1],value[2]);
        if(!PlayerHitbox.Finite(result)||Math.Abs(result.X)>100||Math.Abs(result.Y)>100||Math.Abs(result.Z)>100)
            throw new InvalidDataException("Invalid vehicle weapon coordinate.");
        return result;
    }
    private static Quaternion Rotation(float[] value)
    {
        if(value.Length!=4)throw new InvalidDataException("Invalid vehicle body rotation.");
        var q=new Quaternion(value[0],value[1],value[2],value[3]);
        if(!float.IsFinite(q.LengthSquared())||Math.Abs(q.LengthSquared()-1)>.0002f)
            throw new InvalidDataException("Invalid vehicle body rotation.");
        return Quaternion.Normalize(q);
    }
}

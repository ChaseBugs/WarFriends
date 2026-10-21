using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace War.BattleServer;

public sealed record GroundVehicleWeaponRig(string UnitId,string Prefab,string Sha256,string BehaviorType,
    IReadOnlyList<GroundVehicleTurret> Roles,IReadOnlyList<GroundVehiclePassengerBinding> Passengers,
    IReadOnlyList<GroundVehicleBodyPart> BodyParts,float FlamePartCoefficient,
    IReadOnlyList<RepairDronePath> RepairDronePaths,
    Vector3 ShotTarget,int ShotTargetTransformFileId);

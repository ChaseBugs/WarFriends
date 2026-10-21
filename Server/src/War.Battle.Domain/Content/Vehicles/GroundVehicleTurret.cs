using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace War.BattleServer;

public sealed record GroundVehicleTurret(string Role,int TurretComponentFileId,string TurretType,
    float AimTime,float MaxShotRotation,bool UseUnitTarget,bool PrimaryTargetOnly,
    bool NeedToSeePrimaryTarget,bool NeedToSeeSecondaryTarget,bool PredictPosition,int PrimaryTarget,
    int SerializedTargetMask,float SecondaryDelay,int FakeShotEvery,IReadOnlyList<GroundVehicleWeapon> Weapons);

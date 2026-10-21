using System.Security.Cryptography;
using System.Numerics;
using System.Text.Json;

namespace War.BattleServer;

public sealed record ArmyDeploymentFamily(int BehaviorFileId,string BehaviorType,int UpgradeSlotsFileId,string UnitId,
    string SheetRow,int UnitType,int SpawnPointMask,int MaxGeneratedCount,float BaseSpeed,float MovementSpeed,bool IsSoldier,bool IsAir,
    IReadOnlyList<ArmyDeploymentOption> Options,ArmyBaseShotStats? BaseShot,ArmyVehicleShotStats? VehicleShot);

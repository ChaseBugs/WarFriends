using System.Numerics;
namespace War.BattleServer;

public sealed record DroneWeaponShot(Vector3 Muzzle,DroneBatchShot Batch,float Time,bool IsShield=false);

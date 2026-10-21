using System.Numerics;
namespace War.BattleServer;

public sealed record DroneProjectileIntent(DroneWeaponShot Shot,float Speed,float Damage,float CheckDistance,bool Critical,
    float PlayerDamageCoefficient=1,float PlayerOvertimeDamageCoefficient=1);

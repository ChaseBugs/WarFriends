using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace War.BattleServer;

internal sealed record DynamicShotTarget(ulong EntityId,int PartComponentFileId,int Layer,PlayerHitbox Hitbox,
    string? PassengerRole=null,int? RepairDronePathIndex=null,bool ArmyInfantry=false,bool Decoy=false,bool HeavyTurret=false,bool HelicopterGunner=false,bool GroundVehicleBody=false,bool HelicopterBody=false,bool DroneRoot=false,bool AssaultGlass=false,bool GrenadierGrenade=false);

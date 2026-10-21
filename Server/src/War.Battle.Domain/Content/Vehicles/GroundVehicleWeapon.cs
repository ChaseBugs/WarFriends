using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace War.BattleServer;

public sealed record GroundVehicleWeapon(int BatchedComponentFileId,int WeaponComponentFileId,
    string WeaponType,float Cadence,int SpawnTransformFileId,Vector3 MuzzlePosition,Vector3 ShotOffset,
    int ProjectileFileId,string ProjectileGuid,bool ForcedFake,bool FriendKill,GroundVehicleMissileBinding? Missile);

using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace War.BattleServer;

public sealed record ArmyWeaponMuzzle(string UnitId,string Path,Vector3 RestPosition,Quaternion RestRotation);

using System.Security.Cryptography;
using System.Numerics;
using System.Text.Json;

namespace War.BattleServer;

public sealed record ArmyVehicleCannonStats(float Damage,float MinShootTime,float MaxShootTime);

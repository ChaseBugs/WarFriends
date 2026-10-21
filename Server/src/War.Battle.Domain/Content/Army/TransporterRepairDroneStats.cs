using System.Security.Cryptography;
using System.Numerics;
using System.Text.Json;

namespace War.BattleServer;

public sealed record TransporterRepairDroneStats(float HealRatioPerSecond,float MaximumHealth);

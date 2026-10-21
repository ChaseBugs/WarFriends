using System.Security.Cryptography;
using System.Numerics;
using System.Text.Json;

namespace War.BattleServer;

public sealed record ArmyUpgradeShotStats(float ProbabilityOfRealShot,int FireBatchSizeMin,
    int FireBatchSizeMax,float MinShootTime,float MaxShootTime);

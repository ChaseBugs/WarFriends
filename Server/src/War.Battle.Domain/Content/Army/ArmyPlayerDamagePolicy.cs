using System.Security.Cryptography;
using System.Numerics;
using System.Text.Json;

namespace War.BattleServer;

public sealed record ArmyPlayerDamagePolicy(float BehindShieldRatio,float PlayerDamageRatio,
    float OvertimePlayerDamageRatio);

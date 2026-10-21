using System.Security.Cryptography;
using System.Numerics;
using System.Text.Json;

namespace War.BattleServer;

public sealed record ArmyCardRocketRuntime(float DirectDamage,
    float ExplosionDamage, float Speed, float PlayerBehindShieldRatio);

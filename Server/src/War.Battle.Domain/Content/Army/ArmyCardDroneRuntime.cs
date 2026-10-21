using System.Security.Cryptography;
using System.Numerics;
using System.Text.Json;

namespace War.BattleServer;

public sealed record ArmyCardDroneRuntime(float MovementSpeed, float ShotSpeed,
    float ShieldHitProbability, bool CanTurnInvisible);

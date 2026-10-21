using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record CoopBotHealth(
    int MissionIndex, int Level, float BaseHealth,
    float HealthMultiplier, float MaximumHealth);

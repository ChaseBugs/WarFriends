using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record CoopShieldStart(
    float HealthRatio, float MaxHealthRatio, bool Regenerate, bool AutoRepair);

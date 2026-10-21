using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record CoopMissionShields(
    int MissionIndex, IReadOnlyList<CoopShieldStart> Player,
    IReadOnlyList<CoopShieldStart> Bot);

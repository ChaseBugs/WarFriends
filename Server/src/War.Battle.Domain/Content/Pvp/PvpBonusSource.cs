using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record PvpBonusSource(int Index, string Name, string PrefabGuid,
    long ComponentFileId, string PrefabPath, string PrefabSha256,
    float Probability, float ArenaProbability);

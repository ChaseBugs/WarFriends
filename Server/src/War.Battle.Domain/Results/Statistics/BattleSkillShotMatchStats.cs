using System.Collections.ObjectModel;
using War.Protocol;

namespace War.BattleServer;

/// <summary>Host-confirmed source skill-shot counts for one battle participant.</summary>
public sealed record BattleSkillShotMatchStats(
    string PlayerId,
    IReadOnlyDictionary<int, int> Counts);

using Google.Protobuf.Collections;
using War.Protocol;

namespace War.BattleServer;

/// <summary>Validates the recovered skill-shot counter identities in a terminal result.</summary>
public static class BattleSkillShotEvidencePolicy
{
    public const uint MaximumConfirmedReceipts = War.Shared.SkillShotCounterPolicy.MaximumConfirmedReceipts;

    /// <summary>Checks a complete ordered source counter set or an absent legacy set.</summary>
    public static bool Valid(RepeatedField<BattleSkillShotCount> counts)
    {
        return War.Shared.SkillShotCounterPolicy.Valid(counts);
    }

    /// <summary>Copies confirmed counters into recovered score-sheet order.</summary>
    public static IReadOnlyList<BattleSkillShotCount> FromConfirmedCounts(
        IReadOnlyDictionary<int, int> counts)
    {
        return War.Shared.SkillShotCounterPolicy.FromConfirmedCounts(counts);
    }
}

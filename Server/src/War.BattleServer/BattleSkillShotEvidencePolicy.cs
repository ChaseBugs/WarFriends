using Google.Protobuf.Collections;
using War.Protocol;

namespace War.BattleServer;

/// <summary>Validates the recovered skill-shot counter identities in a terminal result.</summary>
public static class BattleSkillShotEvidencePolicy
{
    public const uint MaximumConfirmedReceipts = 4096;

    // These are the 19 active SkillShotType flags in the recovered MainScene score sheet.
    private static readonly int[] SourceFlags =
    [
        1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 2048, 4096, 65536,
        131072, 8192, 262144, 32768, 16384, 524288
    ];

    /// <summary>Checks a complete ordered source counter set or an absent legacy set.</summary>
    public static bool Valid(RepeatedField<BattleSkillShotCount> counts)
    {
        if (counts.Count == 0)
        {
            return true;
        }

        if (counts.Count != SourceFlags.Length)
        {
            return false;
        }

        for (int index = 0; index < SourceFlags.Length; index++)
        {
            if (counts[index].Flag != SourceFlags[index] ||
                counts[index].Count > MaximumConfirmedReceipts)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>Copies confirmed counters into recovered score-sheet order.</summary>
    public static IReadOnlyList<BattleSkillShotCount> FromConfirmedCounts(
        IReadOnlyDictionary<int, int> counts)
    {
        if (counts.Count != SourceFlags.Length)
        {
            throw new InvalidDataException("Incomplete confirmed skill-shot counters.");
        }

        var rows = new List<BattleSkillShotCount>(SourceFlags.Length);
        foreach (int flag in SourceFlags)
        {
            if (!counts.TryGetValue(flag, out int count) ||
                count < 0 || count > MaximumConfirmedReceipts)
            {
                throw new InvalidDataException("Invalid confirmed skill-shot count.");
            }

            rows.Add(new BattleSkillShotCount
            {
                Flag = checked((uint)flag),
                Count = checked((uint)count)
            });
        }

        return rows;
    }
}

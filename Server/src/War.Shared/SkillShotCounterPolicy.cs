using System.Collections.Generic;
using System.IO;
using Google.Protobuf.Collections;
using War.Protocol;

namespace War.Shared
{
    /// <summary>Preserves the recovered MainScene's complete ordered skill-shot counter set.</summary>
    public static class SkillShotCounterPolicy
    {
        /// <summary>Bounds each source counter by the host's confirmed receipt capacity.</summary>
        public const uint MaximumConfirmedReceipts = 4096;

        private static readonly int[] _sourceFlags =
        {
            1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 2048, 4096, 65536,
            131072, 8192, 262144, 32768, 16384, 524288
        };

        /// <summary>Accepts a complete source counter set or an absent legacy set.</summary>
        public static bool Valid(RepeatedField<BattleSkillShotCount> counts)
        {
            if (counts == null)
            {
                return false;
            }

            if (counts.Count == 0)
            {
                return true;
            }

            if (counts.Count != _sourceFlags.Length)
            {
                return false;
            }

            for (int index = 0; index < _sourceFlags.Length; index++)
            {
                if (counts[index].Flag != _sourceFlags[index] ||
                    counts[index].Count > MaximumConfirmedReceipts)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>Copies confirmed counts without changing source score-sheet order.</summary>
        public static IReadOnlyList<BattleSkillShotCount> FromConfirmedCounts(IReadOnlyDictionary<int, int> counts)
        {
            if (counts == null || counts.Count != _sourceFlags.Length)
            {
                throw new InvalidDataException("Incomplete confirmed skill-shot counters.");
            }

            var rows = new List<BattleSkillShotCount>(_sourceFlags.Length);
            foreach (int flag in _sourceFlags)
            {
                int count;
                if (!counts.TryGetValue(flag, out count) || count < 0 || count > MaximumConfirmedReceipts)
                {
                    throw new InvalidDataException("Invalid confirmed skill-shot count.");
                }

                rows.Add(new BattleSkillShotCount
                {
                    Flag = (uint)flag,
                    Count = (uint)count
                });
            }

            return rows;
        }
    }
}

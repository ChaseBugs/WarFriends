using System;
using System.Collections.Generic;
using War.Protocol;
using War.Shared;

namespace War.Client
{
    /// <summary>Rejects damaged host score state before it reaches the recovered HUD.</summary>
    public static class BattleScoreSnapshotPolicy
    {
        private const int MatchPlayerCount = 2;

        /// <summary>Validates public score, streak progress, and terminal counter snapshots.</summary>
        public static void Validate(MatchSnapshot snapshot)
        {
            if (snapshot == null || snapshot.Players.Count != MatchPlayerCount)
            {
                throw new InvalidOperationException("Missing battle score snapshot.");
            }

            bool isTerminal = snapshot.Phase == BattlePhase.Ended || snapshot.Phase == BattlePhase.Aborted;
            var playerIds = new HashSet<string>(StringComparer.Ordinal);
            foreach (BattlePlayerState player in snapshot.Players)
            {
                if (!War.Shared.CanonicalGuid.IsCanonical(player.PlayerId) || !playerIds.Add(player.PlayerId) ||
                    player.Score < 0 || player.KillStreakProgress < 0 ||
                    float.IsNaN(player.KillStreakProgress) || float.IsInfinity(player.KillStreakProgress) ||
                    !SkillShotCounterPolicy.Valid(player.SkillShotCounts) ||
                    (!isTerminal && player.SkillShotCounts.Count != 0))
                {
                    throw new InvalidOperationException("Invalid public battle score state.");
                }
            }
        }
    }
}

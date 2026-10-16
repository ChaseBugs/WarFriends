using System;
using War.Protocol;

namespace War.Client
{
    // A host score replaces the recovered HUD total; malformed values must
    // fail before a snapshot can reach Unity or overwrite a displayed score.
    internal static class BattleScoreSnapshotPolicy
    {
        internal static void Validate(MatchSnapshot snapshot)
        {
            if (snapshot == null)
            {
                throw new InvalidOperationException("Missing battle score snapshot.");
            }

            foreach (BattlePlayerState player in snapshot.Players)
            {
                if (player.Score < 0)
                {
                    throw new InvalidOperationException("Invalid server-owned battle score.");
                }
            }
        }
    }
}

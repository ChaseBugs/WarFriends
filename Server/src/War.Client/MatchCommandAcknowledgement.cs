using System;
using War.Protocol;

namespace War.Client
{
    /// <summary>Confirms which local command the host actually consumed.</summary>
    internal static class MatchCommandAcknowledgement
    {
        private const ulong MaximumCommandId = 100000;

        internal static ulong AdmissionCursor(MatchSnapshot snapshot, string localPlayerId)
        {
            BattlePlayerState localPlayer = FindLocalPlayer(snapshot, localPlayerId);
            if (localPlayer.LastCommandId > MaximumCommandId ||
                snapshot.StateRevision < localPlayer.LastCommandId)
                throw new InvalidOperationException("Battle host returned an invalid command cursor.");
            return localPlayer.LastCommandId;
        }

        internal static void RequireConsumed(MatchReply reply, string localPlayerId,
            ulong expectedCommandId)
        {
            if (reply == null || expectedCommandId == 0 || expectedCommandId > MaximumCommandId ||
                reply.CommandId != expectedCommandId)
                throw new InvalidOperationException("Battle host returned an invalid command acknowledgement.");

            BattlePlayerState localPlayer = FindLocalPlayer(reply.Snapshot, localPlayerId);
            if (localPlayer.LastCommandId != expectedCommandId ||
                reply.Snapshot.StateRevision < expectedCommandId)
                throw new InvalidOperationException("Battle host did not consume the pending command.");
        }

        /// <summary>Closes a refused terminal command without inventing a consumed cursor.</summary>
        internal static ulong TerminalCursor(MatchReply reply, string localPlayerId, ulong expectedCommandId)
        {
            if (reply == null || reply.Code != "match-terminal" || expectedCommandId == 0 ||
                expectedCommandId > MaximumCommandId || reply.CommandId != expectedCommandId ||
                reply.Snapshot == null ||
                (reply.Snapshot.Phase != BattlePhase.Aborted && reply.Snapshot.Phase != BattlePhase.Ended) ||
                reply.Snapshot.EndTick != reply.Snapshot.ServerTick || reply.Snapshot.StateRevision == 0 ||
                string.IsNullOrEmpty(reply.Snapshot.TerminalReason))
            {
                throw new InvalidOperationException("Battle host returned an invalid terminal refusal.");
            }

            BattlePlayerState localPlayer = FindLocalPlayer(reply.Snapshot, localPlayerId);
            if ((localPlayer.LastCommandId != expectedCommandId &&
                localPlayer.LastCommandId != expectedCommandId - 1) ||
                reply.Snapshot.StateRevision < localPlayer.LastCommandId)
            {
                throw new InvalidOperationException("Terminal refusal changed the pending command cursor.");
            }

            return localPlayer.LastCommandId;
        }

        private static BattlePlayerState FindLocalPlayer(MatchSnapshot snapshot, string playerId)
        {
            if (snapshot == null || snapshot.Players.Count != 2 ||
                !War.Shared.CanonicalGuid.IsCanonical(playerId))
                throw new InvalidOperationException("Battle host returned an invalid player snapshot.");

            BattlePlayerState localPlayer = null;
            foreach (BattlePlayerState player in snapshot.Players)
            {
                if (player.PlayerId != playerId) continue;
                if (localPlayer != null)
                    throw new InvalidOperationException("Battle host repeated the local player.");
                localPlayer = player;
            }
            if (localPlayer == null)
                throw new InvalidOperationException("Battle host omitted the local player.");
            return localPlayer;
        }
    }
}

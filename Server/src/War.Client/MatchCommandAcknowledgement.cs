using System;
using War.Protocol;

namespace War.Client
{
    /// <summary>Confirms which local command the host actually consumed.</summary>
    internal static class MatchCommandAcknowledgement
    {
        internal static ulong AdmissionCursor(MatchSnapshot snapshot, string localPlayerId)
        {
            BattlePlayerState localPlayer = FindLocalPlayer(snapshot, localPlayerId);
            if (localPlayer.LastCommandId > 100000 ||
                snapshot.StateRevision < localPlayer.LastCommandId)
                throw new InvalidOperationException("Battle host returned an invalid command cursor.");
            return localPlayer.LastCommandId;
        }

        internal static void RequireConsumed(MatchReply reply, string localPlayerId,
            ulong expectedCommandId)
        {
            if (reply == null || expectedCommandId == 0 || expectedCommandId > 100000 ||
                reply.CommandId != expectedCommandId)
                throw new InvalidOperationException("Battle host returned an invalid command acknowledgement.");

            BattlePlayerState localPlayer = FindLocalPlayer(reply.Snapshot, localPlayerId);
            if (localPlayer.LastCommandId != expectedCommandId ||
                reply.Snapshot.StateRevision < expectedCommandId)
                throw new InvalidOperationException("Battle host did not consume the pending command.");
        }

        private static BattlePlayerState FindLocalPlayer(MatchSnapshot snapshot, string playerId)
        {
            if (snapshot == null || snapshot.Players.Count != 2 ||
                !Guid.TryParseExact(playerId, "N", out _))
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

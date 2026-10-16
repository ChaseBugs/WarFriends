using System;
using War.Protocol;

/// <summary>Recognizes a confirmed peer departure without inferring a local mission outcome.</summary>
public static class SelfHostedCoopDepartureState
{
    private const int MissionPlayerCount = 2;

    /// <summary>Recognizes the departed local peer while the other ally's mission remains running.</summary>
    public static bool IsLocalDeparture(MatchSnapshot snapshot, string localPlayerId)
    {
        if (snapshot == null || snapshot.Players.Count != MissionPlayerCount || string.IsNullOrEmpty(localPlayerId))
        {
            return false;
        }

        foreach (BattlePlayerState player in snapshot.Players)
        {
            if (player.PlayerId != localPlayerId)
            {
                return IsRemoteDeparture(snapshot, player.PlayerId, localPlayerId);
            }
        }

        return false;
    }

    /// <summary>Requires the surviving local ally and inactive remote peer in one running host snapshot.</summary>
    public static bool IsRemoteDeparture(MatchSnapshot snapshot, string localPlayerId, string remotePlayerId)
    {
        if (snapshot == null || snapshot.Coop == null || !snapshot.Coop.Started ||
            snapshot.Phase != BattlePhase.Running || snapshot.Players.Count != MissionPlayerCount ||
            string.IsNullOrEmpty(localPlayerId) || string.IsNullOrEmpty(remotePlayerId) ||
            string.Equals(localPlayerId, remotePlayerId, StringComparison.Ordinal) ||
            snapshot.Coop.ParticipantIds.Count != MissionPlayerCount - 1 ||
            snapshot.Coop.ParticipantIds[0] != localPlayerId)
        {
            return false;
        }

        BattlePlayerState localPlayer = null;
        BattlePlayerState remotePlayer = null;
        foreach (BattlePlayerState player in snapshot.Players)
        {
            if (player.PlayerId == localPlayerId)
            {
                localPlayer = player;
            }
            else if (player.PlayerId == remotePlayerId)
            {
                remotePlayer = player;
            }
        }

        // ParticipantIds is the active roster; Players retains the original admission and vitality history.
        // Readiness alone would confuse loading or a dead spectator with an authenticated departure.
        return localPlayer != null && localPlayer.Admitted && localPlayer.Ready && !localPlayer.Dead &&
            remotePlayer != null && remotePlayer.Admitted && !remotePlayer.Ready;
    }
}

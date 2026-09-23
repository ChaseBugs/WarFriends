using System;
using System.IO;
using System.Linq;
using War.Protocol;

namespace War.Client
{
    // Numeric values are GameController.GameEndReason in the recovered Client.
    public enum ClientGameEndReason : byte
    {
        None = 0,
        Killed = 1,
        Win = 2,
        WinByForfeit = 3,
        Forfeit = 5
    }

    public static class MatchOutcomeProjection
    {
        public static ClientGameEndReason ForPlayer(MatchSnapshot snapshot, string playerId)
        {
            if (snapshot == null) throw new ArgumentNullException(nameof(snapshot));
            if (string.IsNullOrEmpty(playerId) || snapshot.Players.Count != 2 ||
                snapshot.Players[0].PlayerId == snapshot.Players[1].PlayerId ||
                !snapshot.Players.Any(p => p.PlayerId == playerId))
                throw new InvalidDataException("Outcome needs an exact two-player roster member.");
            if (snapshot.Phase == BattlePhase.Waiting || snapshot.Phase == BattlePhase.Countdown ||
                snapshot.Phase == BattlePhase.Running || snapshot.Phase == BattlePhase.Aborted)
            {
                if (snapshot.WinnerPlayerId.Length != 0)
                    throw new InvalidDataException("Non-completed match cannot project a winner.");
                return ClientGameEndReason.None;
            }
            if (snapshot.Phase != BattlePhase.Ended ||
                !snapshot.Players.Any(p => p.PlayerId == snapshot.WinnerPlayerId))
                throw new InvalidDataException("Completed match has no roster winner.");
            bool winner = playerId == snapshot.WinnerPlayerId;
            switch (snapshot.TerminalReason)
            {
                case "player-killed":
                    if (snapshot.Players.Single(p => p.PlayerId != snapshot.WinnerPlayerId).Dead != true ||
                        snapshot.Players.Single(p => p.PlayerId == snapshot.WinnerPlayerId).Dead)
                        throw new InvalidDataException("Lethal outcome lacks a single dead losing player.");
                    return winner ? ClientGameEndReason.Win : ClientGameEndReason.Killed;
                case "forfeit":
                case "opponent-disconnected":
                    return winner ? ClientGameEndReason.WinByForfeit : ClientGameEndReason.Forfeit;
                default:
                    throw new InvalidDataException("Unsupported completed match reason.");
            }
        }
    }
}

using System;
using System.IO;
using System.Linq;
using War.Protocol;

namespace War.Client
{
    /// <summary>
    /// Maps confirmed source co-op results to recovered presentation codes without granting progression.
    /// </summary>
    public static class CoopOutcomeProjection
    {
        private const int ParticipantCount = 2;
        private const int MinimumStars = 1;
        private const int MaximumStars = 3;
        private const ulong MaximumHostTick = 10_000_000;

        /// <summary>
        /// Returns a shared terminal result while preserving an already departed peer's local Forfeit.
        /// </summary>
        public static ClientGameEndReason ForPlayer(MatchSnapshot snapshot, string playerId)
        {
            BattlePlayerState localPlayer = ValidateIdentity(snapshot, playerId);
            if (snapshot.Phase == BattlePhase.Waiting || snapshot.Phase == BattlePhase.Countdown ||
                snapshot.Phase == BattlePhase.Running || snapshot.Phase == BattlePhase.Aborted)
            {
                ValidateNonterminal(snapshot);
                return ClientGameEndReason.None;
            }
            if (snapshot.Phase != BattlePhase.Ended || !snapshot.Coop.Started ||
                snapshot.EndTick != snapshot.ServerTick)
            {
                throw new InvalidDataException("Co-op presentation requires a confirmed shared terminal boundary.");
            }

            ValidateStartedRoster(snapshot);
            ClientGameEndReason sharedReason = GetSharedTerminalReason(snapshot);
            // FinishGameMultiplayerRPC cannot reopen a peer whose local Forfeit already finished its game.
            return localPlayer.CoopDeparted ? ClientGameEndReason.Forfeit : sharedReason;
        }

        private static BattlePlayerState ValidateIdentity(MatchSnapshot snapshot, string playerId)
        {
            if (snapshot == null)
            {
                throw new ArgumentNullException(nameof(snapshot));
            }
            if (snapshot.Coop == null || snapshot.Players.Count != ParticipantCount ||
                snapshot.Players[0].PlayerId == snapshot.Players[1].PlayerId ||
                !snapshot.Players.All(player => IsCanonicalId(player.PlayerId)) ||
                !snapshot.Players.Any(player => player.PlayerId == playerId) ||
                !snapshot.Players.Any(player => player.PlayerId == snapshot.Coop.SceneMasterPlayerId) ||
                snapshot.WinnerPlayerId.Length != 0 || snapshot.RewardEligible)
            {
                throw new InvalidDataException("Co-op result needs the source roster and role without a PvP winner.");
            }
            string missionType = snapshot.Coop.MissionType;
            if (missionType != "KillXEnemies" && missionType != "SurviveXSeconds" &&
                missionType != "Score" && missionType != "KillOpponent")
            {
                throw new InvalidDataException("Unknown source co-op mission type.");
            }

            return snapshot.Players.Single(player => player.PlayerId == playerId);
        }

        private static bool IsCanonicalId(string playerId)
        {
            return War.Shared.CanonicalGuid.IsCanonical(playerId);
        }

        private static void ValidateNonterminal(MatchSnapshot snapshot)
        {
            if (snapshot.Coop.Completed || snapshot.Coop.SuccessScores.Count != 0 ||
                snapshot.Coop.PeerCompletionPlayerIds.Count != 0 ||
                snapshot.Coop.Failed != (snapshot.Phase == BattlePhase.Aborted) ||
                (snapshot.Phase != BattlePhase.Aborted && snapshot.TerminalReason.Length != 0) ||
                (snapshot.Phase != BattlePhase.Aborted && snapshot.EndTick != 0) ||
                (snapshot.Phase == BattlePhase.Running && !snapshot.Coop.Started))
            {
                throw new InvalidDataException("A non-completed co-op state cannot present mission success.");
            }
            if (snapshot.Coop.Started)
            {
                ValidateStartedRoster(snapshot);
            }
            BattlePlayerState master = snapshot.Players.Single(
                player => player.PlayerId == snapshot.Coop.SceneMasterPlayerId);
            if (snapshot.Phase == BattlePhase.Running && (master.Dead || master.CoopDeparted))
            {
                throw new InvalidDataException("A source master KIA or departure cannot leave its mission running.");
            }
        }

        private static void ValidateStartedRoster(MatchSnapshot snapshot)
        {
            string[] activeIds = snapshot.Players.Where(player => !player.CoopDeparted)
                .Select(player => player.PlayerId).OrderBy(playerId => playerId, StringComparer.Ordinal).ToArray();
            if (!snapshot.Coop.ParticipantIds.SequenceEqual(activeIds) ||
                snapshot.Coop.DeadlineTick <= snapshot.StartTick || snapshot.ServerTick > MaximumHostTick ||
                snapshot.StartTick > snapshot.ServerTick || snapshot.ServerTick > snapshot.Coop.DeadlineTick)
            {
                throw new InvalidDataException("Co-op active roster or mission clock is inconsistent.");
            }
            foreach (BattlePlayerState player in snapshot.Players)
            {
                if (!player.Admitted || player.Ready == player.CoopDeparted ||
                    !IsFinite(player.Health) || !IsFinite(player.MaxHealth) || player.MaxHealth <= 0 ||
                    player.Health > player.MaxHealth || player.Dead != (player.Health <= 0) ||
                    player.Dead != player.HasCoopDeathTick ||
                    (player.Dead && (player.DamageRevision == 0 || player.CoopDeathTick < snapshot.StartTick ||
                        player.CoopDeathTick > snapshot.ServerTick)))
                {
                    throw new InvalidDataException("Co-op player vitality does not support its presentation state.");
                }
            }
        }

        private static bool IsFinite(float value)
        {
            return !float.IsNaN(value) && !float.IsInfinity(value);
        }

        private static ClientGameEndReason GetSharedTerminalReason(MatchSnapshot snapshot)
        {
            BattlePlayerState master = snapshot.Players.Single(
                player => player.PlayerId == snapshot.Coop.SceneMasterPlayerId);
            switch (snapshot.TerminalReason)
            {
                case "mission-success":
                    ValidateSuccess(snapshot, master);
                    return ClientGameEndReason.MissionSuccess;
                case "mission-failed":
                    ValidateFailure(snapshot, master);
                    return ClientGameEndReason.MissionFailed;
                case "forfeit":
                    ValidateForfeit(snapshot, master);
                    return ClientGameEndReason.Forfeit;
                default:
                    throw new InvalidDataException("Unknown source co-op terminal reason.");
            }
        }

        private static void ValidateSuccess(MatchSnapshot snapshot, BattlePlayerState master)
        {
            if (!snapshot.Coop.Completed || snapshot.Coop.Failed || master.Dead || master.CoopDeparted ||
                snapshot.Coop.SuccessScores.Count != 1)
            {
                throw new InvalidDataException("Co-op success lacks its active source master.");
            }
            BattleCoopPlayerScore score = snapshot.Coop.SuccessScores[0];
            string[] peers = snapshot.Players
                .Where(player => player.PlayerId != master.PlayerId && !player.CoopDeparted)
                .Select(player => player.PlayerId).ToArray();
            if (score.PlayerId != master.PlayerId || score.Score < 0 ||
                score.Stars < MinimumStars || score.Stars > MaximumStars ||
                !snapshot.Coop.PeerCompletionPlayerIds.SequenceEqual(peers))
            {
                throw new InvalidDataException("Co-op star ownership or peer completion is inconsistent.");
            }
        }

        private static void ValidateFailure(MatchSnapshot snapshot, BattlePlayerState master)
        {
            ValidateUnsuccessfulFlags(snapshot);
            bool masterKilled = master.Dead && master.CoopDeathTick == snapshot.EndTick &&
                snapshot.EndTick < snapshot.Coop.DeadlineTick;
            bool objectiveExpired = !master.Dead && !master.CoopDeparted &&
                snapshot.EndTick == snapshot.Coop.DeadlineTick;
            if (master.CoopDeparted || (!masterKilled && !objectiveExpired))
            {
                throw new InvalidDataException("Co-op failure lacks its source deadline or master-KIA boundary.");
            }
        }

        private static void ValidateForfeit(MatchSnapshot snapshot, BattlePlayerState master)
        {
            ValidateUnsuccessfulFlags(snapshot);
            if (!master.CoopDeparted || master.Dead)
            {
                throw new InvalidDataException("Co-op shared Forfeit requires its source master departure.");
            }
        }

        private static void ValidateUnsuccessfulFlags(MatchSnapshot snapshot)
        {
            if (!snapshot.Coop.Failed || snapshot.Coop.Completed || snapshot.Coop.SuccessScores.Count != 0 ||
                snapshot.Coop.PeerCompletionPlayerIds.Count != 0)
            {
                throw new InvalidDataException("An unsuccessful co-op result cannot present completion rewards.");
            }
        }
    }
}

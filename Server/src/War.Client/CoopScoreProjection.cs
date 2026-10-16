using System.IO;
using War.Protocol;

namespace War.Client
{
    /// <summary>Provides a conserved source Score-mission view without changing stars or progression.</summary>
    public sealed class CoopScoreProjection
    {
        private const int ParticipantCount = 2;

        /// <summary>Gets this player's host-confirmed contribution.</summary>
        public int LocalScore { get; private set; }

        /// <summary>Gets the allied player's contribution, including retained credit after departure.</summary>
        public int PeerScore { get; private set; }

        /// <summary>Gets the exact shared objective score.</summary>
        public int TotalScore { get; private set; }

        private CoopScoreProjection(int localScore, int peerScore, int totalScore)
        {
            LocalScore = localScore;
            PeerScore = peerScore;
            TotalScore = totalScore;
        }

        /// <summary>Validates both ordered contributions before publishing either one to the HUD.</summary>
        public static CoopScoreProjection ForPlayer(MatchSnapshot snapshot, string playerId)
        {
            CoopOutcomeProjection.ForPlayer(snapshot, playerId);
            if (snapshot.Coop.MissionType != "Score" || snapshot.Coop.ParticipantScores.Count != ParticipantCount)
            {
                throw new InvalidDataException("The score view requires two source Score-mission contributions.");
            }

            long totalScore = 0;
            int localScore = 0;
            int peerScore = 0;
            for (int index = 0; index < snapshot.Players.Count; index++)
            {
                BattleCoopParticipantScore contribution = snapshot.Coop.ParticipantScores[index];
                if (contribution.PlayerId != snapshot.Players[index].PlayerId || contribution.Score < 0)
                {
                    throw new InvalidDataException("Co-op score contributions must match the exact ordered roster.");
                }

                totalScore += contribution.Score;
                if (contribution.PlayerId == playerId)
                {
                    localScore = contribution.Score;
                }
                else
                {
                    peerScore = contribution.Score;
                }
            }

            if (totalScore > int.MaxValue || totalScore != snapshot.Coop.ObjectiveScore ||
                (!snapshot.Coop.Started && totalScore != 0))
            {
                throw new InvalidDataException("Co-op score contributions do not conserve the shared objective.");
            }

            return new CoopScoreProjection(localScore, peerScore, (int)totalScore);
        }
    }
}

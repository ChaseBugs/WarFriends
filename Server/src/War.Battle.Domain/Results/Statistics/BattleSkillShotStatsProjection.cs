using System.Collections.ObjectModel;
using War.Protocol;

namespace War.BattleServer;

/// <summary>Reads completed terminal skill-shot evidence for later assignment settlement.</summary>
public static class BattleSkillShotStatsProjection
{
    /// <summary>Returns detached per-flag counters after validating the terminal result.</summary>
    public static IReadOnlyList<BattleSkillShotMatchStats> FromPayload(
        byte[] payload,
        string matchId,
        string digest)
    {
        MatchSnapshot terminal = BattleTerminalEvidenceValidator.ValidatePayload(payload, matchId, digest);
        if (terminal.Phase != BattlePhase.Ended ||
            terminal.Players.Any(player => player.ConfirmedSkillShotCounts.Count == 0))
        {
            throw new InvalidDataException("Battle lacks completed skill-shot evidence.");
        }

        return terminal.Players.Select(player => new BattleSkillShotMatchStats(
            player.PlayerId,
            new ReadOnlyDictionary<int, int>(player.ConfirmedSkillShotCounts.ToDictionary(
                row => checked((int)row.Flag),
                row => checked((int)row.Count))))).ToArray();
    }
}

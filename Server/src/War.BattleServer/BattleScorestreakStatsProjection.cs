using War.Protocol;

namespace War.BattleServer;

/// <summary>Source MatchStats scorestreak count derived from host-spawned boxes.</summary>
public sealed record BattleScorestreakMatchStats(string PlayerId, int ScorestreaksGained);

/// <summary>Reads validated private terminal evidence for Backend settlement.</summary>
public static class BattleScorestreakStatsProjection
{
    /// <summary>Projects per-player spawn counts from a validated completed result.</summary>
    public static IReadOnlyList<BattleScorestreakMatchStats> FromPayload(
        byte[] payload,
        string matchId,
        string digest)
    {
        MatchSnapshot terminal = TerminalOutbox.ValidatePayload(payload, matchId, digest);
        if (terminal.Phase != BattlePhase.Ended)
        {
            throw new InvalidDataException("Aborted battle has no scorestreak MatchStats.");
        }

        return terminal.Players.Select(player => new BattleScorestreakMatchStats(
            player.PlayerId,
            checked((int)player.ConfirmedScorestreaksGained))).ToArray();
    }
}

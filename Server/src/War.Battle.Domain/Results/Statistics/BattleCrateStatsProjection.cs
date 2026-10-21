using War.Protocol;

namespace War.BattleServer;

/// <summary>Reads validated, private terminal evidence for Backend settlement.</summary>
public static class BattleCrateStatsProjection
{
    public static IReadOnlyList<BattleCrateMatchStats> FromPayload(
        byte[] payload,
        string matchId,
        string digest)
    {
        MatchSnapshot terminal = BattleTerminalEvidenceValidator.ValidatePayload(payload, matchId, digest);
        if (terminal.Phase != BattlePhase.Ended)
        {
            throw new InvalidDataException("Aborted battle has no crate MatchStats.");
        }

        return terminal.Players.Select(player => new BattleCrateMatchStats(
            player.PlayerId,
            checked((int)player.ConfirmedCratesCollected),
            checked((int)player.ConfirmedCratesStolen))).ToArray();
    }
}

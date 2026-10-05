using War.Protocol;

namespace War.BattleServer;

/// <summary>Per-owner accepted fire events; source MatchStats parity remains a separate gate.</summary>
public sealed record BattlePlayerShotEvidence(string PlayerId,int AcceptedShots);

public static class BattleShotEvidenceProjection
{
    public static IReadOnlyList<BattlePlayerShotEvidence> FromPayload(byte[] payload,string matchId,string digest)
    {
        MatchSnapshot terminal=TerminalOutbox.ValidatePayload(payload,matchId,digest);
        return terminal.Players.Select(player=>new BattlePlayerShotEvidence(
            player.PlayerId,checked((int)player.ShotsFired))).ToArray();
    }
}

using War.Protocol;

namespace War.BattleServer;

public static class BattleShotEvidenceProjection
{
    public static IReadOnlyList<BattlePlayerShotEvidence> FromPayload(byte[] payload,string matchId,string digest)
    {
        MatchSnapshot terminal=BattleTerminalEvidenceValidator.ValidatePayload(payload,matchId,digest);
        return terminal.Players.Select(player=>new BattlePlayerShotEvidence(
            player.PlayerId,checked((int)player.ShotsFired))).ToArray();
    }
}

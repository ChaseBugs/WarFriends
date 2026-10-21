using War.Protocol;

namespace War.BattleServer;

public static class BattleBulletHitEvidenceProjection
{
    public static IReadOnlyList<BattlePlayerBulletHitEvidence> FromPayload(byte[] payload,string matchId,string digest)
    {
        MatchSnapshot terminal=BattleTerminalEvidenceValidator.ValidatePayload(payload,matchId,digest);
        return terminal.Players.Select(player=>new BattlePlayerBulletHitEvidence(
            player.PlayerId,checked((int)player.ConfirmedPlayerBulletHits))).ToArray();
    }
}

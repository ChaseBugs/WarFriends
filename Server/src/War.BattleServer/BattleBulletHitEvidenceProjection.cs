using War.Protocol;

namespace War.BattleServer;

/// <summary>Direct player-bullet contacts, distinct from all host enemy damage.</summary>
public sealed record BattlePlayerBulletHitEvidence(string PlayerId,int ConfirmedBulletHits);

public static class BattleBulletHitEvidenceProjection
{
    public static IReadOnlyList<BattlePlayerBulletHitEvidence> FromPayload(byte[] payload,string matchId,string digest)
    {
        MatchSnapshot terminal=TerminalOutbox.ValidatePayload(payload,matchId,digest);
        return terminal.Players.Select(player=>new BattlePlayerBulletHitEvidence(
            player.PlayerId,checked((int)player.ConfirmedPlayerBulletHits))).ToArray();
    }
}

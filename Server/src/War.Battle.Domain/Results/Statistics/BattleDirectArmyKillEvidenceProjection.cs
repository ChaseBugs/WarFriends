using War.Protocol;

namespace War.BattleServer;

public static class BattleDirectArmyKillEvidenceProjection
{
    public static IReadOnlyList<BattleDirectArmyKillEvidence> FromPayload(
        byte[] payload,string matchId,string digest)
    {
        MatchSnapshot terminal=BattleTerminalEvidenceValidator.ValidatePayload(payload,matchId,digest);
        return terminal.DirectArmyKills.Select(row=>new BattleDirectArmyKillEvidence(
            row.EntityKey,row.UnitId,row.VictimOwnerPlayerId,row.AttackerPlayerId,
            row.Cause,row.Tick,row.VictimSourceCardId,row.VictimSpawnRequestId,
            row.VictimSpawnTick)).ToArray();
    }
}

using War.Protocol;

namespace War.BattleServer;

/// <summary>Host-confirmed player-owned army deaths with source provenance.</summary>
public sealed record BattleDirectArmyKillEvidence(ulong EntityKey,string UnitId,
    string VictimOwnerPlayerId,string AttackerPlayerId,string Cause,ulong Tick,
    string VictimSourceCardId = "", string VictimSpawnRequestId = "", ulong VictimSpawnTick = 0);

public static class BattleDirectArmyKillEvidenceProjection
{
    public static IReadOnlyList<BattleDirectArmyKillEvidence> FromPayload(
        byte[] payload,string matchId,string digest)
    {
        MatchSnapshot terminal=TerminalOutbox.ValidatePayload(payload,matchId,digest);
        return terminal.DirectArmyKills.Select(row=>new BattleDirectArmyKillEvidence(
            row.EntityKey,row.UnitId,row.VictimOwnerPlayerId,row.AttackerPlayerId,
            row.Cause,row.Tick,row.VictimSourceCardId,row.VictimSpawnRequestId,
            row.VictimSpawnTick)).ToArray();
    }
}

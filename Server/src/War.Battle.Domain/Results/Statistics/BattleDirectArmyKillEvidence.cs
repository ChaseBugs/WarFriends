using War.Protocol;

namespace War.BattleServer;

/// <summary>Host-confirmed player-owned army deaths with source provenance.</summary>
public sealed record BattleDirectArmyKillEvidence(ulong EntityKey,string UnitId,
    string VictimOwnerPlayerId,string AttackerPlayerId,string Cause,ulong Tick,
    string VictimSourceCardId = "", string VictimSpawnRequestId = "", ulong VictimSpawnTick = 0);

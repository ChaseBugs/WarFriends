using War.Protocol;
using War.Shared;

namespace War.BattleServer;

/// <summary>
/// What the authenticated UDP endpoint needs from a battle simulation.
/// PvP and co-op can share transport without sharing combat ownership rules.
/// </summary>
internal interface IMatchRuntime
{
    string MatchId { get; }
    string ManifestHash { get; }
    bool Terminal { get; }
    bool HasPlayer(string playerId);
    bool Admit(string playerId);
    bool Resume(string playerId);
    bool CancelBeforeStart();
    bool AbortForHostShutdown();
    void Advance(ulong tick);
    void ConfigureBattleAllocations(IEnumerable<BattleAllocationProjection> allocations);
    MatchReply Command(string playerId, MatchCommand command);
    MatchReply Reply(ulong commandId, string code);
    MatchSnapshot Snapshot();
    MatchSnapshot TerminalEvidenceSnapshot();
    MatchEventBatch EventBatch(string playerId, ulong afterEventId);
    MatchBarrelBatch BarrelBatch(string playerId);
    MatchArmyBatch ArmyBatch(string playerId);
    MatchArmyEntityBatch ArmyEntityBatch(
        string playerId, ulong afterEntityKey, ulong expectedRevision);
}

using War.BattleServer;
using War.Protocol;

namespace War.Persistence.Battles.Settlement;

/// <summary>One transaction's accepted host result, frozen manifest and current participant accounts.</summary>
public sealed record BattleSettlementContext(
    MatchSnapshot Terminal, MatchManifest Manifest, IReadOnlyList<LegacyPlayerDocument> Players);

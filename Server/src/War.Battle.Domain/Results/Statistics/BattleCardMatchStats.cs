using System.Collections.ObjectModel;
using War.Protocol;

namespace War.BattleServer;

/// <summary>The source MatchStats card fields derivable from validated terminal evidence.</summary>
public sealed record BattleCardMatchStats(string PlayerId,int CardsPlayed,
    IReadOnlyDictionary<string,int> CardsPlayedSeparately);

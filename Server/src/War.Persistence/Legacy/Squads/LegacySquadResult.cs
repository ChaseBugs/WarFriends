namespace War.Persistence.Legacy.Squads;

/// <summary>Returns committed records for source-compatible success projections.</summary>
public sealed record LegacySquadResult(
    int Result, LegacyPlayerDocument Actor, LegacyPlayerDocument? Target, LegacySquadDocument? Squad);

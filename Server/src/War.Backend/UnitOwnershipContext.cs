namespace War.Backend;

/// <summary>Server-selected gameplay mode and durable rank used for unit availability.</summary>
public sealed record UnitOwnershipContext(int RankIndex, bool IsTutorial);

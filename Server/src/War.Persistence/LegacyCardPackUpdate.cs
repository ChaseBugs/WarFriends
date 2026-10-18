namespace War.Persistence;

/// <summary>Server-calculated inventory and post-purchase balances published as one account transition.</summary>
public sealed record LegacyCardPackUpdate(string SerializedCards, long Gold, long WarBucks);

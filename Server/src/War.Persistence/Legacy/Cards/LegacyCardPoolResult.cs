namespace War.Persistence.Legacy.Cards;

/// <summary>Returns a stable transfer outcome with current actor state for response projection.</summary>
public sealed record LegacyCardPoolResult(int Result, int NextWithdraw, LegacyPlayerDocument Actor);

namespace War.Persistence.Legacy.Cards;

/// <summary>Contains one transaction's authoritative player and squad inputs.</summary>
public sealed record LegacyCardPoolSnapshot(
    LegacyPlayerDocument Actor,
    LegacyPlayerDocument? Donor,
    LegacySquadDocument? Squad);

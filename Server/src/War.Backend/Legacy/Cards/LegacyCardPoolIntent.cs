namespace War.Backend.Legacy.Cards;

/// <summary>Validated card-pool intent; quantities are assertions against transactional ownership.</summary>
public sealed record LegacyCardPoolIntent(
    IReadOnlyDictionary<string, int> Added,
    IReadOnlyDictionary<string, int> Removed,
    string? CardId,
    string? DonorId);

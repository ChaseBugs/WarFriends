namespace War.Persistence.Legacy.Profile;

/// <summary>Feature outcomes mapped to the unchanged Client result codes by the Backend.</summary>
public enum LegacyRenameOutcome
{
    Published,
    InvalidSession,
    StaleRevision,
    MissingPrice,
    InvalidPrice,
    PaymentRequired,
    NotEnoughGold
}

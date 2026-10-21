namespace War.Persistence.Legacy.Profile;

/// <summary>Returns the committed profile and the exact server price used by a successful rename.</summary>
public sealed record LegacyRenameResult(
    LegacyRenameOutcome Outcome, LegacyPlayerDocument? Player = null, int Price = 0);

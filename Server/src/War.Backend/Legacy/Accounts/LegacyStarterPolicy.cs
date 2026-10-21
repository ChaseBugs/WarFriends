using War.Persistence.Legacy.Accounts;
using War.Persistence.Legacy.State;

namespace War.Backend.Legacy.Accounts;

/// <summary>Freezes validated deployment starting state before any registration or password work.</summary>
public sealed record LegacyStarterPolicy
{
    private const int MaximumSheetVersionLength = 64;

    public required long Gold { get; init; }

    public required long WarBucks { get; init; }

    public required long Tickets { get; init; }

    public required long Scraps { get; init; }

    public required int Level { get; init; }

    public required int DogTagMax { get; init; }

    public required int PlacementMatchesRequired { get; init; }

    public required int SessionLifetimeHours { get; init; }

    public required string SheetConfiguration { get; init; }

    /// <summary>Copies configuration values into one independently validated immutable snapshot.</summary>
    public static LegacyStarterPolicy FromOptions(LegacyStarterState options)
    {
        var policy = new LegacyStarterPolicy
        {
            Gold = options.Gold,
            WarBucks = options.WarBucks,
            Tickets = options.Tickets,
            Scraps = options.Scraps,
            Level = options.Level,
            DogTagMax = options.DogTagMax,
            PlacementMatchesRequired = options.PlacementMatchesRequired,
            SessionLifetimeHours = options.SessionLifetimeHours,
            SheetConfiguration = options.SheetConfiguration
        };
        policy.Validate();
        return policy;
    }

    /// <summary>Rejects malformed starter authority before traffic or password work.</summary>
    public void Validate()
    {
        if (Gold < 0 || WarBucks < 0 || Tickets < 0 || Scraps < 0 ||
            Level is < 0 or >= LegacyAccountCreation.RecoveredRankCount ||
            DogTagMax <= 0 ||
            PlacementMatchesRequired is < 0 or > LegacyPlayerEconomyAuthority.RecoveredPlacementMatches ||
            string.IsNullOrEmpty(SheetConfiguration) ||
            SheetConfiguration.Length > MaximumSheetVersionLength || SheetConfiguration.Contains(';') ||
            SheetConfiguration.Any(char.IsControl))
        {
            throw new InvalidDataException("Invalid legacy starter policy.");
        }

        _ = LegacySessionAuthority.Expiry(DateTime.UtcNow, SessionLifetimeHours);
    }
}

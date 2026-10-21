namespace War.Persistence.Legacy.Accounts;

/// <summary>Combines the server-owned starter document, metadata and one application time.</summary>
public sealed record LegacyAccountCreation
{
    public const int RecoveredRankCount = 43;

    public required LegacyPlayerDocument Player { get; init; }

    public required LegacyAccountRegistration Registration { get; init; }

    public required int SessionLifetimeHours { get; init; }

    public required int NowUnixSeconds { get; init; }
}

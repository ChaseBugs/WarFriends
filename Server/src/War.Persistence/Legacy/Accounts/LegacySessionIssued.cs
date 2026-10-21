namespace War.Persistence.Legacy.Accounts;

/// <summary>Pairs a rotated token with the exact account revision that stored it.</summary>
public sealed record LegacySessionIssued(LegacyPlayerDocument Player, string Token);

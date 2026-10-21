namespace War.Persistence.Legacy.Accounts;

/// <summary>Returns credentials only after their single account insert has succeeded.</summary>
public sealed record LegacyAccountCreated(LegacyPlayerDocument Player, string Token, string Password);

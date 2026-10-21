namespace War.Persistence.Legacy.Tutorial;

/// <summary>Returns the current authoritative account and the durable tutorial identity.</summary>
public sealed record LegacyTutorialResult(
    LegacyTutorialOutcome Outcome, LegacyPlayerDocument? Player = null, string? BattleId = null);

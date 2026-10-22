namespace War.Persistence.Legacy.Progression;

public sealed record DailyRewardCommit(LegacyPlayerDocument Player, long AddedGold, bool WasAlreadyClaimed);

namespace War.Persistence.Legacy.DogTags;

/// <summary>One complete proposed dog-tag/wallet successor, calculated from the same account revision.</summary>
public sealed record LegacyDogTagMutation(LegacyDogTagOutcome Outcome, int Seconds, int LastUpdate, long Gold);

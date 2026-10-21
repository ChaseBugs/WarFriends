namespace War.Persistence.Legacy.DogTags;

/// <summary>Returns the read/committed account and its exact operation outcome together.</summary>
public sealed record LegacyDogTagResult(LegacyPlayerDocument Player, LegacyDogTagOutcome Outcome);

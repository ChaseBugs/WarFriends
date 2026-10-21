namespace War.Backend.Legacy.DogTags;

/// <summary>A wire-safe base pool; the recovered Client adds its active VIP bonus separately.</summary>
public sealed record LegacyDogTagSnapshot(int Seconds, int LastUpdate, int MaximumSeconds);

namespace War.Persistence.Legacy.DogTags;

/// <summary>Distinguishes a committed mutation from a read-only outcome.</summary>
public enum LegacyDogTagOutcome
{
    Applied,
    Unchanged,
    NotEnoughGold
}

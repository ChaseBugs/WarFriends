namespace War.Backend.Legacy.Squads;

/// <summary>Captures the source-owned creation price; it does not invent member capacity.</summary>
public sealed record LegacySquadPolicy(int? CreationPrice)
{
    public const int MaximumNameLength = 15;
    public const int MaximumMessageLength = 100;
    public const int MaximumMedalsRequirement = 5000;
    public const int MaximumColeaders = 3;

    public static LegacySquadPolicy FromCatalog(LegacyCatalog catalog)
    {
        if (!catalog.IsLoaded)
        {
            return new LegacySquadPolicy((int?)null);
        }

        int? price = catalog.ConstantInt("WarBucksCreateSquadPrice");
        if (price is not >= 0)
        {
            throw new InvalidDataException("Invalid squad creation price.");
        }

        return new LegacySquadPolicy(price.Value);
    }
}

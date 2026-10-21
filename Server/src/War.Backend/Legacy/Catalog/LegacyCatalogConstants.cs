using System.Collections.Frozen;

namespace War.Backend.Legacy.Catalog;

/// <summary>Validates the numeric domains currently consumed as economy and timing authority.</summary>
internal static class LegacyCatalogConstants
{
    private const int MaximumCardsPerPack = 256;
    private static readonly FrozenSet<string> Integers = new[]
    {
        "DogTagCap", "DogTagRefillTime", "LeaguePlacementMatches", "CardWithdrawTimer", "SecondRenameGoldCost",
        "WarBucksCreateSquadPrice",
        "CardsInPack", "BronzePackBronzeCards", "SilverPackSilverCards", "GoldPackGoldCards",
        "CardCraftTimeSilver", "CardCraftTimeGold", "RepPointsBronzeCard", "RepPointsSilverCard", "RepPointsGoldCard"
    }.ToFrozenSet(StringComparer.Ordinal);
    private static readonly FrozenSet<string> PositiveNumbers = new[]
    {
        "GoldCoefficient", "PartToScrapsSell", "PartToScrapsUpgrade"
    }.ToFrozenSet(StringComparer.Ordinal);
    private static readonly FrozenSet<string> Probabilities = new[]
    {
        "SilverCardRarityEarly", "SilverCardRarity", "GoldCardRarityEarly", "GoldCardRarity"
    }.ToFrozenSet(StringComparer.Ordinal);

    internal static void Validate(LegacyCatalogRow row)
    {
        string key = row["DBKEY"]!.Value.GetValue<string>();
        LegacyCatalogValue value = row["FLOATVALUE"]!.Value;
        if (Integers.Contains(key))
        {
            int integer = value.GetValue<int>();
            if (integer < 0 || key is "DogTagCap" or "DogTagRefillTime" or "CardWithdrawTimer" && integer == 0)
            {
                throw new InvalidDataException("Invalid nonnegative/positive integer catalog policy: " + key);
            }
        }
        else if (key is "StartingGold" or "StartingWarbucks")
        {
            if (value.GetValue<long>() < 0 || value.ToJsonString().StartsWith('-'))
            {
                throw new InvalidDataException("Invalid starting wallet authority.");
            }
        }
        else if (PositiveNumbers.Contains(key) && value.GetValue<double>() <= 0 ||
            Probabilities.Contains(key) && value.GetValue<double>() is < 0 or > 1)
        {
            throw new InvalidDataException("Invalid catalog coefficient/probability: " + key);
        }

        if (key is "CardsInPack" or "BronzePackBronzeCards" or "SilverPackSilverCards" or "GoldPackGoldCards" &&
            (value.GetValue<int>() > MaximumCardsPerPack || key == "CardsInPack" && value.GetValue<int>() == 0))
        {
            throw new InvalidDataException("Card-pack policy exceeds its bounded grant count.");
        }

        if (PositiveNumbers.Contains(key) || key == "GoldExpCoefficient")
        {
            // The original exponent is -0.175; its sign must not be mistaken for a negative price.
            double number = value.GetValue<double>();
            float sourceNumber = (float)number;
            if (!float.IsFinite(sourceNumber) || number != 0 && sourceNumber == 0)
            {
                throw new InvalidDataException("Catalog arithmetic constant exceeds the Client's binary32 domain.");
            }
        }
    }
}

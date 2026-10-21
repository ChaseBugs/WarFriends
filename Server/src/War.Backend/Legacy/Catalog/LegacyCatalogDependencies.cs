namespace War.Backend.Legacy.Catalog;

/// <summary>Requires the current host's economy dependencies before a configured snapshot accepts traffic.</summary>
internal static class LegacyCatalogDependencies
{
    private static readonly string[] Sheets =
    [
        "Google2u.Constants", "Google2u.CardConstants", "Google2u.CardDefinitions", "Google2u.CardPacks",
        "Google2u.WeaponUpgrades", "Google2u.ArmyUpgrades", "Google2u.PlayerVisuals", "Google2u.Levels"
    ];
    private static readonly string[] Constants =
    [
        "StartingGold", "StartingWarbucks", "DogTagCap", "DogTagRefillTime", "LeaguePlacementMatches", "CardWithdrawTimer",
        "SecondRenameGoldCost", "WarBucksCreateSquadPrice", "CardsInPack", "BronzePackBronzeCards",
        "SilverPackSilverCards", "GoldPackGoldCards", "CardCraftTimeSilver", "CardCraftTimeGold",
        "GoldCoefficient", "GoldExpCoefficient", "PartToScrapsSell", "PartToScrapsUpgrade",
        "SilverCardRarityEarly", "SilverCardRarity", "GoldCardRarityEarly", "GoldCardRarity"
    ];

    internal static void Validate(LegacyCatalog catalog)
    {
        foreach (string type in Sheets)
        {
            if (catalog.Sheet(type).Count == 0)
            {
                throw new InvalidDataException("Configured catalog lacks a required sheet: " + type);
            }
        }

        foreach (string key in Constants)
        {
            if (catalog.Constant(key) == null)
            {
                throw new InvalidDataException("Configured catalog lacks a required constant: " + key);
            }
        }

        ValidateStages(catalog);
        ValidatePackPolicy(catalog);
    }

    private static void ValidateStages(LegacyCatalog catalog)
    {
        foreach (string type in new[] { "Google2u.WeaponUpgrades", "Google2u.ArmyUpgrades" })
        {
            foreach (LegacyCatalogRow row in catalog.Sheet(type))
            {
                string identity = row["NAME"]!.Value.GetValue<string>();
                if (catalog.Sheet(identity).Count == 0)
                {
                    throw new InvalidDataException("Configured catalog lacks an item's upgrade stages.");
                }
            }
        }
    }

    private static void ValidatePackPolicy(LegacyCatalog catalog)
    {
        int count = catalog.ConstantInt("CardsInPack")!.Value;
        foreach (string key in new[] { "BronzePackBronzeCards", "SilverPackSilverCards", "GoldPackGoldCards" })
        {
            if (catalog.ConstantInt(key) > count)
            {
                throw new InvalidDataException("Guaranteed card count exceeds the pack count.");
            }
        }

        if (catalog.Constant("SilverCardRarityEarly") > catalog.Constant("GoldCardRarityEarly") ||
            catalog.Constant("SilverCardRarity") > catalog.Constant("GoldCardRarity"))
        {
            throw new InvalidDataException("Card rarity thresholds are not ordered.");
        }
    }
}

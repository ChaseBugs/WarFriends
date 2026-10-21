using System.Text.Json;

namespace War.Backend.Legacy.Catalog;

/// <summary>Validates consumed economy fields without imposing shop rules on unrelated recovered tables.</summary>
internal static class LegacyCatalogValidation
{
    internal static string? IdentityField(string type) => type switch
    {
        "Google2u.Constants" or "Google2u.CardConstants" => "DBKEY",
        "Google2u.WeaponUpgrades" or "Google2u.ArmyUpgrades" or "Google2u.PlayerVisuals" or
            "Google2u.CardDefinitions" or "Google2u.CardPacks" => "NAME",
        _ => null
    };

    internal static void Validate(string type, LegacyCatalogRow row)
    {
        ValidateCells(row);
        switch (type)
        {
            case "Google2u.WeaponUpgrades":
                NonnegativeIntegers(row, "PRICE", "PRICEGOLD", "CANBEBOUGHT", "DELIVERTIME");
                _ = Require(row, "PURCHASABLE").GetValue<string>();
                break;
            case "Google2u.ArmyUpgrades":
                NonnegativeIntegers(row, "PRICE", "PRICEGOLD", "CANBEBOUGHT", "DELIVERTIME");
                foreach (string field in new[] { "STARTINGTIER", "STARTINGELITE", "UNLOCKTIER2", "UNLOCKTIER3",
                    "UNLOCKTIER4", "UNLOCKTIER5", "UNLOCKTIER6" })
                {
                    _ = Require(row, field).GetValue<int>();
                }
                break;
            case "Google2u.PlayerVisuals":
                NonnegativeIntegers(row, "PRICEGOLD", "PRICEWARBUCKS", "UNLOCKLEVEL", "CATEGORYID");
                _ = Require(row, "ONLYFORVIP").GetValue<bool>();
                _ = Require(row, "PURCHASABLE").GetValue<string>();
                break;
            case "Google2u.CardPacks":
                NonnegativeIntegers(row, "GOLD", "WARBUCKS");
                break;
            case "Google2u.Constants":
            case "Google2u.CardConstants":
                _ = Require(row, "FLOATVALUE").GetValue<double>();
                LegacyCatalogConstants.Validate(row);
                break;
            case "Google2u.CardDefinitions":
                _ = Require(row, "IMPLEMENTED").GetValue<bool>();
                if (Require(row, "RARITY").GetValue<int>() is not (-1 or 1 or 2 or 3))
                {
                    throw new InvalidDataException("Unknown recovered card rarity.");
                }
                break;
        }

        if (row.ContainsKey("NEXTUPGRADEPRICE") || row.ContainsKey("NEXTUPGRADEPRICEGOLD") ||
            row.ContainsKey("DELIVERYTIME"))
        {
            NonnegativeIntegers(row, "NEXTUPGRADEPRICE", "NEXTUPGRADEPRICEGOLD", "DELIVERYTIME");
        }

        ValidateOptionalFields(row);
        if (type == "Google2u.PlayerVisuals" && Require(row, "CATEGORYID").GetValue<int>() > 3)
        {
            throw new InvalidDataException("Visual category exceeds the four recovered slots.");
        }
    }

    private static void ValidateCells(LegacyCatalogRow row)
    {
        foreach (KeyValuePair<string, LegacyCatalogValue> field in row.Fields)
        {
            if (field.Key.Length is < 1 or > 256 || field.Key.Any(char.IsControl))
            {
                throw new InvalidDataException("Invalid catalog field identity.");
            }

            JsonValueKind kind = field.Value.GetValueKind();
            if (kind == JsonValueKind.Number)
            {
                _ = field.Value.GetValue<double>();
            }
            else if (kind is not (JsonValueKind.String or JsonValueKind.True or JsonValueKind.False))
            {
                throw new InvalidDataException("Catalog cells must be finite scalar source values.");
            }
        }
    }

    private static void ValidateOptionalFields(LegacyCatalogRow row)
    {
        foreach (string field in new[] { "TIER", "STARTINGTIER", "STARTINGELITE", "UNLOCKTIER2", "UNLOCKTIER3",
            "UNLOCKTIER4", "UNLOCKTIER5", "UNLOCKTIER6" })
        {
            if (row[field] is LegacyCatalogValue value)
            {
                _ = value.GetValue<int>();
            }
        }

        if (row["IMPLEMENTED"] is LegacyCatalogValue implemented)
        {
            _ = implemented.GetValue<bool>();
        }
    }

    private static void NonnegativeIntegers(LegacyCatalogRow row, params string[] fields)
    {
        foreach (string field in fields)
        {
            if (Require(row, field).GetValue<int>() < 0)
            {
                throw new InvalidDataException("Negative catalog price, duration or index: " + field);
            }
        }
    }

    private static LegacyCatalogValue Require(LegacyCatalogRow row, string field) =>
        row[field] ?? throw new InvalidDataException("Required catalog field is absent: " + field);
}

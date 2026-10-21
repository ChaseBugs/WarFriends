using System.Collections.Frozen;
using System.Text.Json;

namespace War.Persistence.Legacy.Analytics;

/// <summary>
/// Checks recovered field types and counter widths; feature lifecycle authority still needs its own rules.
/// </summary>
internal static class LegacyAnalyticsContract
{
    private static readonly FrozenSet<string> Integers = new[]
    {
        "warbucksSpent", "goldSpent", "installTimestamp", "numberOfSessions", "moneyPackDeadline",
        "starterPackDeadline", "totalBattles", "goldBonuses", "rateAppShownCounter", "rateAppClickYesCounter",
        "renameCount", "squadCreationsCount", "matchesToNextLootboxes", "lastSeenSquadChatTimeStampDB",
        "instantBattlesTime", "instantBattles", "paidInstantBattles", "cardTutState"
    }.ToFrozenSet(StringComparer.Ordinal);
    private static readonly FrozenSet<string> Flags = new[]
    {
        "boughtInApp", "chatShown", "elitesShown", "customizationShown", "warpathShown", "cardpoolShown",
        "craftingShown", "leagueLeaderboardsShown", "anticheatStatus"
    }.ToFrozenSet(StringComparer.Ordinal);
    private static readonly FrozenSet<string> Text = new[] { "rateAppFirstVersion", "rateAppClientVersion" }
        .ToFrozenSet(StringComparer.Ordinal);
    private static readonly FrozenSet<string> Names = Integers.Concat(Flags).Concat(Text).Concat(new[]
    {
        "realMoneySpent", "elitePackDeadlines", "collectedRewards", "transactions"
    }).ToFrozenSet(StringComparer.Ordinal);
    private static readonly FrozenSet<string> FoldedNames = Names.ToFrozenSet(StringComparer.OrdinalIgnoreCase);
    private static readonly FrozenSet<string> TransactionNames = new[] { "id", "p", "gold", "wb", "money" }
        .ToFrozenSet(StringComparer.Ordinal);
    private static readonly FrozenSet<string> FoldedTransactionNames = TransactionNames
        .ToFrozenSet(StringComparer.OrdinalIgnoreCase);

    internal static void Validate(JsonElement root)
    {
        foreach (JsonProperty field in root.EnumerateObject())
        {
            RejectAlias(field.Name, Names, FoldedNames);
            if (Integers.Contains(field.Name))
            {
                _ = ReadCounter(field.Value);
            }
            else if (Flags.Contains(field.Name))
            {
                if (field.Value.ValueKind is not (JsonValueKind.True or JsonValueKind.False))
                {
                    throw new JsonException("Analytics flag must be Boolean.");
                }
            }
            else if (Text.Contains(field.Name))
            {
                ValidateText(field.Value);
            }
            else
            {
                ValidateContainerField(field);
            }
        }

        if (root.TryGetProperty("matchesToNextLootboxes", out JsonElement remaining) &&
            ReadCounter(remaining) is < 1 or > 4)
        {
            throw new JsonException("Present paid-VIP lootbox countdown is outside its reviewed domain.");
        }

        int paid = OptionalCounter(root, "paidInstantBattles");
        int battles = OptionalCounter(root, "instantBattles");
        if ((long)paid * 5 > battles)
        {
            throw new JsonException("Paid Instant Battle groups exceed the recorded lifetime count.");
        }
    }

    private static void ValidateContainerField(JsonProperty field)
    {
        switch (field.Name)
        {
            case "realMoneySpent":
                ValidateMoney(field.Value);
                break;
            case "elitePackDeadlines":
            case "collectedRewards":
                if (field.Value.ValueKind != JsonValueKind.Object)
                {
                    throw new JsonException("Analytics counter map must be an object.");
                }

                foreach (JsonProperty entry in field.Value.EnumerateObject())
                {
                    _ = ReadCounter(entry.Value);
                }

                break;
            case "transactions":
                ValidateTransactions(field.Value);
                break;
        }
    }

    private static void ValidateTransactions(JsonElement value)
    {
        // The source has no list initializer and explicitly supports null transaction history.
        if (value.ValueKind == JsonValueKind.Null)
        {
            return;
        }

        if (value.ValueKind != JsonValueKind.Array)
        {
            throw new JsonException("Analytics transactions must be a list or source-null.");
        }

        foreach (JsonElement row in value.EnumerateArray())
        {
            ValidateTransaction(row);
        }
    }

    private static void ValidateTransaction(JsonElement row)
    {
        if (row.ValueKind != JsonValueKind.Object || TransactionNames.Any(name => !row.TryGetProperty(name, out _)))
        {
            throw new JsonException("Analytics transaction is incomplete.");
        }

        foreach (JsonProperty field in row.EnumerateObject())
        {
            RejectAlias(field.Name, TransactionNames, FoldedTransactionNames);
            switch (field.Name)
            {
                case "id":
                case "gold":
                case "wb":
                    _ = ReadCounter(field.Value);
                    break;
                case "money":
                    ValidateMoney(field.Value);
                    break;
                case "p":
                    ValidateText(field.Value);
                    break;
            }
        }
    }

    private static int ReadCounter(JsonElement value)
    {
        if (value.ValueKind != JsonValueKind.Number || !value.TryGetInt32(out int counter) ||
            counter < 0 || value.GetRawText().StartsWith('-'))
        {
            throw new JsonException("Analytics counter must be a nonnegative Client Int32.");
        }

        return counter;
    }

    private static int OptionalCounter(JsonElement root, string name) =>
        root.TryGetProperty(name, out JsonElement value) ? ReadCounter(value) : 0;

    private static void ValidateMoney(JsonElement value)
    {
        if (value.ValueKind != JsonValueKind.Number || !value.TryGetSingle(out float money) ||
            !float.IsFinite(money) || money < 0 || value.GetRawText().StartsWith('-') ||
            money == 0 && !IsZeroLiteral(value.GetRawText()))
        {
            throw new JsonException("Analytics money must fit the source nonnegative finite float.");
        }
    }

    private static bool IsZeroLiteral(string text)
    {
        foreach (char character in text)
        {
            if (character is 'e' or 'E')
            {
                break;
            }

            if (character is >= '1' and <= '9')
            {
                return false;
            }
        }

        return true;
    }

    private static void ValidateText(JsonElement value)
    {
        if (value.ValueKind is not (JsonValueKind.String or JsonValueKind.Null))
        {
            throw new JsonException("Analytics source text must be a string or source-null.");
        }
    }

    private static void RejectAlias(string name, FrozenSet<string> exact, FrozenSet<string> folded)
    {
        if (!exact.Contains(name) && folded.Contains(name))
        {
            throw new JsonException("Analytics contains a conflicting known-field case alias.");
        }
    }
}

using System.Text.Json;
using System.Text.Json.Nodes;
using War.Persistence.Legacy.State;

namespace War.Persistence.Legacy.Analytics;

/// <summary>Reads exact known analytics fields while preserving bounded future metadata and numeric text.</summary>
public static class LegacyAnalyticsState
{
    public const string Key = "PlayerAnalyticsData";

    /// <summary>Only a missing subsystem selects the recovered constructor's empty-state path.</summary>
    public static JsonObject Read(IReadOnlyDictionary<string, string>? states)
    {
        if (states == null)
        {
            throw new InvalidDataException("Legacy analytics container is null.");
        }

        return states.TryGetValue(Key, out string? json) ? Parse(json) : new JsonObject();
    }

    /// <summary>
    /// Validates present JSON before interpretation, without filling omitted fields or truncating history.
    /// </summary>
    public static JsonObject Parse(string? json)
    {
        ValidateJson(json);
        return JsonNode.Parse(json!)!.AsObject();
    }

    /// <summary>Checks a present snapshot without constructing a mutable JSON tree.</summary>
    public static void ValidateJson(string? json)
    {
        try
        {
            using JsonDocument document = LegacyStateJson.ParseObject(json);
            LegacyAnalyticsContract.Validate(document.RootElement);
        }
        catch (JsonException exception)
        {
            throw new InvalidDataException("Invalid present legacy analytics state.", exception);
        }
    }

    /// <summary>
    /// Checks the complete successor and retains unmodeled properties rather than serializing a partial DTO.
    /// </summary>
    public static string Write(JsonObject state)
    {
        string json = state.ToJsonString();
        ValidateJson(json);
        return json;
    }

    /// <summary>Validates a present snapshot without initializing a missing subsystem.</summary>
    public static void ValidateContainer(IReadOnlyDictionary<string, string>? states)
    {
        if (states == null)
        {
            throw new InvalidDataException("Legacy analytics container is null.");
        }

        if (states.TryGetValue(Key, out string? json))
        {
            ValidateJson(json);
        }
    }

    /// <summary>Rejects unsupported enum values before they can select a durable JSON property.</summary>
    public static string FlagName(LegacyAnalyticsFlag flag) => flag switch
    {
        LegacyAnalyticsFlag.Chat => "chatShown",
        LegacyAnalyticsFlag.Customization => "customizationShown",
        LegacyAnalyticsFlag.Warpath => "warpathShown",
        LegacyAnalyticsFlag.CardPool => "cardpoolShown",
        LegacyAnalyticsFlag.Crafting => "craftingShown",
        LegacyAnalyticsFlag.LeagueLeaderboards => "leagueLeaderboardsShown",
        LegacyAnalyticsFlag.Elites => "elitesShown",
        _ => throw new InvalidDataException("Unsupported legacy analytics flag.")
    };
}

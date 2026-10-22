using System.Text.Json;
using System.Text.Json.Serialization;

namespace War.Persistence.Legacy.Progression;

/// <summary>Ordered local bot outcomes, never replacement wallet or inventory balances.</summary>
public sealed record OfflineBotJournal([property: JsonRequired] string Stream,
    [property: JsonRequired] OfflineBotOutcome[] Battles)
{
    public static OfflineBotJournal Parse(string json)
    {
        if (json.Length > 32_768)
        {
            throw new InvalidDataException("Offline journal exceeds its bound.");
        }
        var options = new JsonSerializerOptions { UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow };
        OfflineBotJournal value = JsonSerializer.Deserialize<OfflineBotJournal>(json, options)
            ?? throw new InvalidDataException("Missing offline journal.");
        value.Validate();
        return value;
    }

    public void Validate()
    {
        if (!Guid.TryParseExact(Stream, "N", out var id) || id.ToString("N") != Stream ||
            Battles == null || Battles.Length is < 1 or > 100)
        {
            throw new InvalidDataException("Invalid offline journal identity or size.");
        }
        long previous = 0;
        foreach (OfflineBotOutcome battle in Battles)
        {
            if (battle == null || battle.Sequence is < 1 or > int.MaxValue ||
                (previous != 0 && battle.Sequence != previous + 1) ||
                battle.EndReason is not (1 or 2 or 3 or 5) || battle.Experience is < 0 or > 100_000 ||
                battle.ExtraGold is < 0 or > 1000 || battle.ExtraWarBucks is < 0 or > 100_000)
            {
                throw new InvalidDataException("Invalid offline battle sequence or outcome.");
            }
            previous = battle.Sequence;
        }
    }
}

public sealed record OfflineBotOutcome([property: JsonRequired] long Sequence,
    [property: JsonRequired] int EndReason, [property: JsonRequired] int Experience,
    int ExtraGold = 0, int ExtraWarBucks = 0);

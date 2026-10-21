using War.Backend.Legacy.Catalog;
using System.Collections.Frozen;

namespace War.Backend.Legacy.Cards;

/// <summary>Captures ordinary-card identities, reputation and the source cooldown once at startup.</summary>
public sealed class LegacyCardPoolPolicy
{
    private const int SecondsPerMinute = 60;
    private const int OrdinaryCardCount = 67;
    private readonly FrozenDictionary<string, int> _reputationByCard;

    private LegacyCardPoolPolicy(int cooldownSeconds, Dictionary<string, int> reputationByCard)
    {
        CooldownSeconds = cooldownSeconds;
        _reputationByCard = reputationByCard.ToFrozenDictionary(StringComparer.Ordinal);
    }

    public int CooldownSeconds { get; }

    public bool IsAvailable => _reputationByCard.Count == OrdinaryCardCount;

    public bool Contains(string cardId) => _reputationByCard.ContainsKey(cardId);

    public int Reputation(string cardId) => _reputationByCard[cardId];

    /// <summary>Missing content closes the feature; malformed configured content fails startup.</summary>
    public static LegacyCardPoolPolicy FromCatalog(LegacyCatalog catalog)
    {
        if (!catalog.IsLoaded)
        {
            return new LegacyCardPoolPolicy(0, new Dictionary<string, int>());
        }

        int? minutes = catalog.ConstantInt("CardWithdrawTimer");
        if (minutes is not > 0 || minutes > int.MaxValue / SecondsPerMinute)
        {
            throw new InvalidDataException("Invalid card-pool cooldown minutes.");
        }

        int[] reputation = ReadReputation(catalog);
        var identities = new Dictionary<string, int>(StringComparer.Ordinal);
        var seen = new HashSet<string>(StringComparer.Ordinal);
        foreach (LegacyCatalogRow row in catalog.Sheet("Google2u.CardDefinitions"))
        {
            string id = row["NAME"]?.GetValue<string>() ?? "";
            int rarity = row["RARITY"]?.GetValue<int>() ?? 0;
            if (id.Length is < 1 or > 64 || !seen.Add(id) || rarity is not (-1 or 1 or 2 or 3))
            {
                throw new InvalidDataException("Invalid ordinary-card identity.");
            }

            if (rarity > 0)
            {
                identities.Add(id, reputation[rarity - 1]);
            }
        }

        if (identities.Count != OrdinaryCardCount)
        {
            throw new InvalidDataException("Incomplete ordinary-card identity catalog.");
        }

        // CardpoolDialog uses 60 * CardWithdrawTimer, so the sheet value is minutes.
        return new LegacyCardPoolPolicy(checked(minutes.Value * SecondsPerMinute), identities);
    }

    private static int[] ReadReputation(LegacyCatalog catalog)
    {
        string[] names = ["RepPointsBronzeCard", "RepPointsSilverCard", "RepPointsGoldCard"];
        var result = new int[names.Length];
        for (int i = 0; i < names.Length; i++)
        {
            LegacyCatalogRow? row = catalog.Row("Google2u.CardConstants", "DBKEY", names[i]);
            int? value = row?["FLOATVALUE"]?.GetValue<int>();
            if (value is not >= 0)
            {
                throw new InvalidDataException("Invalid card donation reputation.");
            }

            result[i] = value.Value;
        }

        return result;
    }
}

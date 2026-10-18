using System.Text;
using System.Text.Json;
using War.Backend.Legacy;
using War.BattleServer;
using War.Persistence;
using War.Shared;

namespace War.Backend;

/// <summary>Builds battle inventory from durable account data without granting or consuming cards.</summary>
public sealed class BattleAllocationSource
{
    private const int MaximumStateBytes = 65536;
    private const int MaximumJsonDepth = 16;
    private static readonly HashSet<string> OrdinaryCardIds = WarCardSourceIdentityCatalog.All
        .Select(row => row.SourceCardId).ToHashSet(StringComparer.Ordinal);
    private static readonly HashSet<string> RootFields = new(StringComparer.Ordinal)
    {
        "cardData", "buddyCardData", "nextWithdraw", "nextBuddyDeposit", "extraSlot"
    };
    private readonly LegacyPlayerStore _players;

    /// <summary>Uses the durable legacy account store as inventory authority.</summary>
    public BattleAllocationSource(LegacyPlayerStore players)
    {
        _players = players ?? throw new ArgumentNullException(nameof(players));
    }

    /// <summary>Reads one durable account and returns its validated battle allocation.</summary>
    public async Task<BattleAllocationProjection> GetAsync(string playerId, CancellationToken cancellationToken)
    {
        LegacyPlayerDocument player = await _players.ById(playerId, cancellationToken)
            ?? throw new InvalidDataException("Battle inventory account is missing.");
        return Project(player);
    }

    /// <summary>Projects positive source card quantities and source-ordered equipped unit lanes.</summary>
    public static BattleAllocationProjection Project(LegacyPlayerDocument player)
    {
        BattlePlayerPresentation view = BattlePlayerPresentationSource.Project(player);
        IReadOnlyDictionary<string, int> cards = ReadCards(player);
        string[] identities = cards.Keys.Order(StringComparer.Ordinal).ToArray();
        return BattleAllocationProjection.Validate(new BattleAllocationProjection(player.Id, identities, [],
            view.Units.Select(unit => unit.UpgradeIndex).ToArray(),
            view.Units.Select(unit => unit.SpecialIndex).ToArray(),
            view.Units.Select(unit => unit.EliteIndex).ToArray())
        {
            CardCounts = identities.Select(identity => cards[identity]).ToArray()
        });
    }

    private static IReadOnlyDictionary<string, int> ReadCards(LegacyPlayerDocument player)
    {
        if (!player.Serialized.TryGetValue("CardManagerData", out string? json))
        {
            // CardManager's source default creates zero ordinary ownership when the subsystem is absent.
            return new Dictionary<string, int>();
        }

        if (string.IsNullOrWhiteSpace(json) || Encoding.UTF8.GetByteCount(json) > MaximumStateBytes)
        {
            throw new InvalidDataException("Invalid durable card-state size.");
        }

        try
        {
            using JsonDocument document = JsonDocument.Parse(json,
                new JsonDocumentOptions { MaxDepth = MaximumJsonDepth });
            JsonElement root = document.RootElement;
            RequireObject(root);
            ValidateRoot(root);
            return root.TryGetProperty("cardData", out JsonElement cards)
                ? ReadOrdinaryCards(cards) : new Dictionary<string, int>();
        }
        catch (JsonException exception)
        {
            throw new InvalidDataException("Malformed durable card state.", exception);
        }
    }

    private static void ValidateRoot(JsonElement root)
    {
        foreach (JsonProperty field in root.EnumerateObject())
        {
            if (!RootFields.Contains(field.Name))
            {
                throw new InvalidDataException("Unknown durable card-state field.");
            }

            if (field.Name == "buddyCardData")
            {
                RequireObject(field.Value);
                if (field.Value.EnumerateObject().Any())
                {
                    // CardBuddy.Init can turn amount zero into one; no Buddy row is silently treated as unowned.
                    throw new InvalidDataException("Buddy combat projection is not implemented.");
                }
            }
            else if (field.Name == "extraSlot" && field.Value.ValueKind is not
                (JsonValueKind.True or JsonValueKind.False))
            {
                throw new InvalidDataException("Invalid durable extra-slot flag.");
            }
            else if (field.Name is "nextWithdraw" or "nextBuddyDeposit")
            {
                ReadNonnegativeInteger(field.Value);
            }
        }
    }

    private static Dictionary<string, int> ReadOrdinaryCards(JsonElement cards)
    {
        RequireObject(cards);
        var result = new Dictionary<string, int>(StringComparer.Ordinal);
        foreach (JsonProperty card in cards.EnumerateObject())
        {
            RequireObject(card.Value);
            if (!OrdinaryCardIds.Contains(card.Name) || card.Value.EnumerateObject().Count() != 1 ||
                !card.Value.TryGetProperty("amount", out JsonElement amount))
            {
                throw new InvalidDataException("Unknown or malformed durable ordinary card.");
            }

            int count = ReadNonnegativeInteger(amount);
            if (count > 0)
            {
                result.Add(card.Name, count);
            }
        }

        return result;
    }

    private static int ReadNonnegativeInteger(JsonElement value)
    {
        if (value.ValueKind != JsonValueKind.Number || !value.TryGetInt32(out int number) || number < 0)
        {
            throw new InvalidDataException("Card authority requires a nonnegative Int32.");
        }

        return number;
    }

    private static void RequireObject(JsonElement value)
    {
        if (value.ValueKind != JsonValueKind.Object || value.EnumerateObject().Select(field => field.Name)
            .Distinct(StringComparer.Ordinal).Count() != value.EnumerateObject().Count())
        {
            throw new InvalidDataException("Card authority requires an object with unique fields.");
        }
    }
}

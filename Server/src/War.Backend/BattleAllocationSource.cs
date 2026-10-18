using War.Backend.Legacy;
using War.BattleServer;
using War.Persistence;
using War.Shared;

namespace War.Backend;

/// <summary>Builds battle inventory from durable account data without granting or consuming cards.</summary>
public sealed class BattleAllocationSource
{
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

        return OrdinaryCardInventory.Read(json);
    }
}

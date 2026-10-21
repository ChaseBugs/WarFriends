namespace War.BattleServer;

/// <summary>
/// MainScene CardIncreaseBonusChance.forBonus references, joined to the
/// KillStreakManager.bonusesPrefabs order through the reviewed bonus catalog.
/// </summary>
public static class QueuedBonusCardSourceCatalog
{
    private static readonly IReadOnlyDictionary<string, (string Name, string Guid)> cards =
        new Dictionary<string, (string, string)>(StringComparer.Ordinal)
        {
            ["HEALTHCRATE"] = ("KillStreakBonusAddHealth", "210cd2d62a418ae4c92af5fa9f2bbd21"),
            ["TURRETCRATE"] = ("KillStreakBonusTurret", "d89f6f627054a494cbd9862fb8752513"),
            ["KEVLARCRATE"] = ("KillStreakBonusKevlar", "ac8b905f5a7ce0c4a94b769453f4b52b"),
            ["AMMOCRATE"] = ("KillStreakBonusAddAmmo", "4253d98e2148db24cbdab745a1472a7d")
        };

    public static int IndexFor(string sourceCardId, PvpBonusCatalog catalog)
    {
        ArgumentNullException.ThrowIfNull(catalog);
        if (!cards.TryGetValue(sourceCardId ?? "", out var source))
            throw new InvalidDataException("Unknown queued-bonus War Card.");

        var matching = catalog.Rows.Where(row => row.Name == source.Name &&
            row.PrefabGuid == source.Guid).ToArray();
        if (matching.Length != 1 || matching[0].Index is < 0 or > 8)
            throw new InvalidDataException("Queued War Card lost its source prefab binding.");
        return matching[0].Index;
    }

    public static void Validate(PvpBonusCatalog catalog)
    {
        foreach (string sourceCardId in cards.Keys)
            IndexFor(sourceCardId, catalog);
    }
}

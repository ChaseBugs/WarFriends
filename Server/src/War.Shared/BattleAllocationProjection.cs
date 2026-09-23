using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace War.Shared
{

/// <summary>Backend-to-BattleServer trusted allocation payload. Client assertions never create this object.</summary>
public sealed class BattleAllocationProjection
{
    public string PlayerId { get; set; }
    public IReadOnlyList<string> CardIds { get; set; }
    public IReadOnlyList<string> BuddyCardIds { get; set; }
    public IReadOnlyList<int> NormalUpgradeIndexes { get; set; }
    public IReadOnlyList<int> SpecialUpgradeIndexes { get; set; }
    public IReadOnlyList<int> EliteUpgradeIndexes { get; set; }
    public BattleAllocationProjection(string playerId, IReadOnlyList<string> cardIds, IReadOnlyList<string> buddyCardIds,
        IReadOnlyList<int> normalUpgradeIndexes, IReadOnlyList<int> specialUpgradeIndexes, IReadOnlyList<int> eliteUpgradeIndexes)
    { PlayerId=playerId; CardIds=cardIds; BuddyCardIds=buddyCardIds; NormalUpgradeIndexes=normalUpgradeIndexes; SpecialUpgradeIndexes=specialUpgradeIndexes; EliteUpgradeIndexes=eliteUpgradeIndexes; }
    public static BattleAllocationProjection Validate(BattleAllocationProjection value)
    {
        if (value is null || string.IsNullOrWhiteSpace(value.PlayerId) || value.PlayerId.Length > 128)
            throw new InvalidDataException("Invalid battle allocation player.");
        ValidateIds(value.CardIds, 32, "card");
        ValidateIds(value.BuddyCardIds, 32, "buddy card");
        ValidateIndexes(value.NormalUpgradeIndexes, 0, "normal");
        ValidateIndexes(value.SpecialUpgradeIndexes, -1, "special");
        ValidateIndexes(value.EliteUpgradeIndexes, -1, "elite");
        if (value.SpecialUpgradeIndexes.Count != 0 && value.SpecialUpgradeIndexes.Count != value.NormalUpgradeIndexes.Count ||
            value.EliteUpgradeIndexes.Count != 0 && value.EliteUpgradeIndexes.Count != value.NormalUpgradeIndexes.Count)
            throw new InvalidDataException("Upgrade lane lengths do not agree.");
        return new BattleAllocationProjection(value.PlayerId,
            Array.AsReadOnly(value.CardIds.ToArray()), Array.AsReadOnly(value.BuddyCardIds.ToArray()),
            Array.AsReadOnly(value.NormalUpgradeIndexes.ToArray()), Array.AsReadOnly(value.SpecialUpgradeIndexes.ToArray()),
            Array.AsReadOnly(value.EliteUpgradeIndexes.ToArray()));
    }
    private static void ValidateIds(IReadOnlyList<string> ids, int max, string kind)
    {
        if (ids is null || ids.Count > max || ids.Any(x => string.IsNullOrWhiteSpace(x) || x.Length > 128 || x.Any(char.IsControl)) ||
            ids.Distinct(StringComparer.Ordinal).Count() != ids.Count) throw new InvalidDataException($"Invalid {kind} allocation.");
    }
    private static void ValidateIndexes(IReadOnlyList<int> values, int minimum, string kind)
    {
        if (values is null || values.Count > 64 || values.Any(x => x < minimum || x > 255)) throw new InvalidDataException($"Invalid {kind} upgrade allocation.");
    }
}
}

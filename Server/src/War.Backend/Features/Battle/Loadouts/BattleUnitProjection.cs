using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text.Json;
using War.Backend.Legacy;
using War.Shared;

namespace War.Backend;

/// <summary>Converts relative unit upgrades into source-bound battle indexes without granting ownership.</summary>
public static class BattleUnitProjection
{
    private const int UnitCount = 24;
    private const int MaximumRankIndex = 42;
    private const int MaximumTier = 6;
    private const int InactiveLaneIndex = -1;
    private const string ResourceName = "War.Backend.RecoveredBattleUnitRules";
    private const string ReviewedSha256 = "9d125ace3216536ae03f743d94e058a9e13df1552c57cc0a357a042db83fc2e8";
    private static readonly IReadOnlyDictionary<string, Rule> Rules = LoadRules();

    /// <summary>Checks that every source unit has a reviewed ownership and upgrade rule.</summary>
    public static void Validate()
    {
        if (Rules.Count != UnitCount)
        {
            throw new InvalidDataException("The battle unit projection rules are incomplete.");
        }
    }

    /// <summary>Reproduces UpgradeSlots.bought using saved state and authoritative gameplay context.</summary>
    public static bool IsOwned(string sourceId, SavedArmySlots saved, UnitOwnershipContext context)
    {
        Rule rule = RequireRule(sourceId, saved, context);
        return HasOwnership(rule, saved, context);
    }

    /// <summary>Projects a usable unit; corrupt stages fail instead of being clamped into valid authority.</summary>
    public static BattleUnitPresentation Project(string sourceId, SavedArmySlots saved, UnitOwnershipContext context)
    {
        Rule rule = RequireRule(sourceId, saved, context);
        bool isOwned = HasOwnership(rule, saved, context);
        // UpgradeSlots.canUseInBattle permits borrowed units independently of the equipped flag.
        if (!(saved.Equipped && isOwned) && !saved.Borrowed)
        {
            throw new InvalidDataException("The selected battle unit is not available.");
        }

        int tier = !isOwned || saved.Tier == 0 ? rule.StartingTier : saved.Tier;
        ValidateSavedStages(rule, saved, tier);
        int specialIndex = tier > rule.StartingTier
            ? rule.SpecialStartIndex + saved.SpecialSlot : InactiveLaneIndex;
        int eliteIndex = rule.EliteStartIndex > 0 && saved.EliteSlot > 0
            ? rule.EliteStartIndex + saved.EliteSlot : InactiveLaneIndex;
        return BattleUnitPresentation.Validate(new BattleUnitPresentation(
            sourceId, saved.BoughtIndex, specialIndex, eliteIndex, tier));
    }

    private static bool HasOwnership(Rule rule, SavedArmySlots saved, UnitOwnershipContext context)
    {
        if (rule.IsTutorialUnit)
        {
            return !context.IsTutorial || saved.Bought;
        }

        return rule.HasFreeAccess || saved.Borrowed ||
            (saved.Bought && context.RankIndex >= rule.MinimumPurchaseRankIndex);
    }

    private static Rule RequireRule(string sourceId, SavedArmySlots saved, UnitOwnershipContext context)
    {
        if (saved == null || context == null || context.RankIndex < 0 || context.RankIndex > MaximumRankIndex ||
            string.IsNullOrEmpty(sourceId) || !Rules.TryGetValue(sourceId, out Rule? rule))
        {
            throw new InvalidDataException("Invalid battle unit ownership input.");
        }

        return rule;
    }

    private static void ValidateSavedStages(Rule rule, SavedArmySlots saved, int tier)
    {
        if (saved.Tier < 0 || saved.Tier > MaximumTier || tier < rule.StartingTier || tier > MaximumTier ||
            saved.BoughtIndex < 0 ||
            saved.BoughtIndex >= rule.NormalCount || saved.SpecialSlot < 0 ||
            saved.SpecialSlot >= rule.SpecialCount || saved.EliteSlot < 0 ||
            (saved.EliteSlot > 0 && (rule.EliteStartIndex <= 0 || saved.EliteSlot >= rule.EliteCount)))
        {
            throw new InvalidDataException("The saved unit upgrade is outside its recovered lane.");
        }

        if (tier == rule.StartingTier && saved.SpecialSlot != 0)
        {
            throw new InvalidDataException("An unpromoted unit has saved special progression.");
        }
    }

    private static IReadOnlyDictionary<string, Rule> LoadRules()
    {
        using Stream input = typeof(BattleUnitProjection).Assembly.GetManifestResourceStream(ResourceName)
            ?? throw new InvalidDataException("The reviewed battle unit rules are missing.");
        using var buffer = new MemoryStream();
        input.CopyTo(buffer);
        byte[] bytes = buffer.ToArray();
        if (Convert.ToHexStringLower(SHA256.HashData(bytes)) != ReviewedSha256)
        {
            throw new InvalidDataException("Battle unit rules differ from the reviewed source.");
        }

        using JsonDocument document = JsonDocument.Parse(bytes);
        var rules = new Dictionary<string, Rule>(StringComparer.Ordinal);
        foreach (JsonElement unit in document.RootElement.GetProperty("units").EnumerateArray())
        {
            string sourceId = unit.GetProperty("sourceId").GetString() ?? "";
            JsonElement counts = unit.GetProperty("laneCounts");
            var rule = new Rule
            {
                MinimumPurchaseRankIndex = unit.GetProperty("minimumPurchaseRankIndex").GetInt32(),
                StartingTier = unit.GetProperty("startingTier").GetInt32(),
                IsTutorialUnit = unit.GetProperty("isTutorialUnit").GetBoolean(),
                HasFreeAccess = unit.GetProperty("hasFreeAccess").GetBoolean(),
                SpecialStartIndex = unit.GetProperty("specialStartIndex").GetInt32(),
                EliteStartIndex = unit.GetProperty("eliteStartIndex").GetInt32(),
                NormalCount = counts[0].GetInt32(),
                SpecialCount = counts[1].GetInt32(),
                EliteCount = counts[2].GetInt32()
            };
            if (!rules.TryAdd(sourceId, rule))
            {
                throw new InvalidDataException("The battle unit rules contain a duplicate identity.");
            }
        }

        if (rules.Count != UnitCount)
        {
            throw new InvalidDataException("The battle unit rules are incomplete.");
        }
        return new ReadOnlyDictionary<string, Rule>(rules);
    }

    private sealed class Rule
    {
        public int MinimumPurchaseRankIndex { get; init; }

        public int StartingTier { get; init; }

        public bool IsTutorialUnit { get; init; }

        public bool HasFreeAccess { get; init; }

        public int SpecialStartIndex { get; init; }

        public int EliteStartIndex { get; init; }

        public int NormalCount { get; init; }

        public int SpecialCount { get; init; }

        public int EliteCount { get; init; }
    }
}

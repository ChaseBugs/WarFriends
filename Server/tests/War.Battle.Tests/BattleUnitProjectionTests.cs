using System.Text.Json;
using War.Backend;
using War.Backend.Legacy;
using War.Persistence;

/// <summary>Checks starter units, source ownership branches and active versus inactive upgrade lanes.</summary>
internal static class BattleUnitProjectionTests
{
    private const int MaximumRankIndex = 42;
    private const int MaximumTier = 6;
    private const int InactiveLane = -1;
    private const int OwnershipCombinationCount = 8;

    internal static int Run(string contentDirectory)
    {
        BattleUnitProjection.Validate();
        using JsonDocument observation = JsonDocument.Parse(File.ReadAllBytes(
            Path.Combine(contentDirectory, "../docs/client-starter-loadout-observation.json")));
        using JsonDocument catalog = JsonDocument.Parse(File.ReadAllBytes(
            Path.Combine(contentDirectory, "recovered-battle-unit-rules.json")));
        var rules = catalog.RootElement.GetProperty("units").EnumerateArray().ToDictionary(
            unit => unit.GetProperty("sourceId").GetString() ?? "");
        int checks = 0;
        foreach (JsonElement unit in observation.RootElement.GetProperty("units").EnumerateArray())
        {
            checks += CheckOwnership(unit);
            checks += CheckLanes(rules[unit.GetProperty("sourceId").GetString() ?? ""]);
        }

        var player = new LegacyPlayerDocument
        {
            Id = Guid.NewGuid().ToString("N"), Name = "InitialUnits", Country = "US", Level = 1,
            Serialized = LegacyInitialLoadout.CreateSerializedState()
        };
        string before = player.Serialized["LevelManagerData"];
        var view = BattlePlayerPresentationSource.Project(player);
        Require(view.Weapons.Count == 4 && view.Units.Count == 4 && view.Units.All(unit =>
            unit.UpgradeIndex == 0 && unit.SpecialIndex == InactiveLane && unit.EliteIndex == InactiveLane &&
            unit.Tier == 1), "A fresh account did not project its four actual starter units without upgrade grants.");
        Require(player.Serialized["LevelManagerData"] == before, "Projection changed durable starter flags.");
        Reject(() => BattleUnitProjection.Project("unknown", new(), new(1, false)));
        Reject(() => BattleUnitProjection.Project("Google2u.DBUpgradeSlotsAssaulter", new(), new(-1, false)));
        CheckBorrowedSelection();
        return checks + 7;
    }

    private static void CheckBorrowedSelection()
    {
        const string Sniper = "Google2u.DBUpgradeSlotsSniper";
        var saved = new SavedArmySlots { Borrowed = true, Equipped = false, Tier = 0 };
        Require(BattleUnitProjection.Project(Sniper, saved, new(0, false)).Tier == 2,
            "An unequipped borrowed unit did not retain source availability and zero-tier fallback.");

        const string Assaulter = "Google2u.DBUpgradeSlotsAssaulter";
        saved = new SavedArmySlots { Equipped = true };
        Reject(() => BattleUnitProjection.Project(Assaulter, saved, new(0, true)));
        saved.Borrowed = true;
        Require(BattleUnitProjection.Project(Assaulter, saved, new(0, true)).Tier == 1,
            "Tutorial borrowing did not follow canUseInBattle independently of the bought branch.");
    }

    private static int CheckOwnership(JsonElement unit)
    {
        string sourceId = unit.GetProperty("sourceId").GetString() ?? "";
        bool isFree = unit.GetProperty("hasImplicitFreeOwnership").GetBoolean();
        bool isTutorialUnit = unit.GetProperty("isTutorialUnit").GetBoolean();
        int minimumRank = unit.GetProperty("minimumPurchaseRankIndex").GetInt32();
        Require(BattleUnitProjection.IsOwned(sourceId, new(), new(1, false)) ==
            unit.GetProperty("isBought").GetBoolean(), "Unit ownership differs from actual Client defaults.");
        int checks = 1;
        for (int rankIndex = 0; rankIndex <= MaximumRankIndex; rankIndex++)
        {
            for (int flags = 0; flags < OwnershipCombinationCount; flags++)
            {
                bool isBought = (flags & 1) != 0;
                bool isBorrowed = (flags & 2) != 0;
                bool isTutorial = (flags & 4) != 0;
                var saved = new SavedArmySlots { Bought = isBought, Borrowed = isBorrowed };
                bool expected = isFree || isBorrowed || (isBought && rankIndex >= minimumRank);
                if (isTutorialUnit)
                {
                    expected = !isTutorial || isBought;
                }
                Require(BattleUnitProjection.IsOwned(sourceId, saved, new(rankIndex, isTutorial)) == expected,
                    "Unit ownership differs from the recovered mode/rank/flag branches.");
                checks++;
            }
        }
        return checks;
    }

    private static int CheckLanes(JsonElement rule)
    {
        string sourceId = rule.GetProperty("sourceId").GetString() ?? "";
        int startingTier = rule.GetProperty("startingTier").GetInt32();
        JsonElement counts = rule.GetProperty("laneCounts");
        var saved = new SavedArmySlots { Bought = true, Equipped = true, Tier = startingTier };
        var context = new UnitOwnershipContext(MaximumRankIndex, false);
        saved.BoughtIndex = counts[0].GetInt32() - 1;
        Require(BattleUnitProjection.Project(sourceId, saved, context).UpgradeIndex == saved.BoughtIndex,
            "The last valid normal upgrade was not preserved.");
        saved.BoughtIndex++;
        Reject(() => BattleUnitProjection.Project(sourceId, saved, context));
        saved.BoughtIndex = 0;
        saved.SpecialSlot = -1;
        Reject(() => BattleUnitProjection.Project(sourceId, saved, context));
        saved.SpecialSlot = 0;
        int checks = 3;
        if (startingTier < MaximumTier)
        {
            saved.Tier++;
            for (int stage = 0; stage < counts[1].GetInt32(); stage++)
            {
                saved.SpecialSlot = stage;
                Require(BattleUnitProjection.Project(sourceId, saved, context).SpecialIndex ==
                    rule.GetProperty("specialStartIndex").GetInt32() + stage,
                    "A promoted unit's special stage did not use its source offset.");
                checks++;
            }
        }
        saved.SpecialSlot = counts[1].GetInt32();
        Reject(() => BattleUnitProjection.Project(sourceId, saved, context));
        saved.SpecialSlot = 0;
        saved.Tier = startingTier;
        saved.EliteSlot = 1;
        int eliteStart = rule.GetProperty("eliteStartIndex").GetInt32();
        if (eliteStart <= 0)
        {
            Reject(() => BattleUnitProjection.Project(sourceId, saved, context));
        }
        else
        {
            Require(BattleUnitProjection.Project(sourceId, saved, context).EliteIndex == eliteStart + 1,
                "Elite stage one did not use its source offset.");
        }
        saved.EliteSlot = Math.Max(1, counts[2].GetInt32());
        Reject(() => BattleUnitProjection.Project(sourceId, saved, context));
        return checks + 3;
    }

    private static void Reject(Action action)
    {
        try
        {
            action();
        }
        catch (InvalidDataException)
        {
            return;
        }
        throw new InvalidOperationException("Invalid unit ownership or progression was accepted.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}

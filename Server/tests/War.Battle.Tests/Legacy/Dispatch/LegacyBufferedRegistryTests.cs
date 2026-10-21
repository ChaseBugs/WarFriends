using System.Reflection;
using System.Text.Json.Nodes;
using Microsoft.Extensions.Logging.Abstractions;
using War.Backend.Legacy;
using War.Backend.Legacy.Buffering;
using War.Backend.Legacy.Buffering.Cards;
using War.Backend.Legacy.Buffering.Economy;
using War.Backend.Legacy.Buffering.Inventory;
using War.Backend.Legacy.Buffering.Squads;
using War.Persistence;
using War.Persistence.Legacy.Buffers;

namespace War.Battle.Tests.Legacy.Dispatch;

internal static class LegacyBufferedRegistryTests
{
    private const long Now = 1_700_000_000;

    internal static int Run()
    {
        LegacyBufferedActionRegistry registry = CreateRegistry();
        CheckOwnership(registry);
        CheckGraphRefusals(registry);
        CheckRequestIsolation();
        CheckFailedPublicationGuard();
        CheckClosedAndMalformedActions();
        return 5;
    }

    private static LegacyBufferedActionRegistry CreateRegistry()
    {
        return LegacyBufferedActionRegistry.Create(LegacyCatalog.Empty, LegacyBufferProcessor.SupportedActions);
    }

    private static void CheckOwnership(LegacyBufferedActionRegistry registry)
    {
        Require(registry.Actions.Count == 25 && registry.Actions.Keys.ToHashSet()
                .SetEquals(LegacyBufferProcessor.SupportedActions), "A supported buffered action lost its handler.");
        Require(registry.Actions.Values.Count(entry => entry.Feature == LegacyBufferedFeature.Inventory) == 21 &&
                registry.Actions.Values.Count(entry => entry.Feature == LegacyBufferedFeature.Economy) == 2 &&
                registry.Actions[DatabaseAction.BuyCardPack].Feature == LegacyBufferedFeature.Cards &&
                registry.Actions[DatabaseAction.SaveLastSeenSquadChatTimeStamp].Feature == LegacyBufferedFeature.Squads,
            "The reviewed buffered feature ownership changed.");

        MethodInfo[] plannerMethods = typeof(LegacyBufferPlanner).GetMethods(
            BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        Require(plannerMethods.Select(method => method.Name).ToHashSet().SetEquals(["Plan", "Execute"]),
            "The planner regained feature calculations instead of orchestrating explicit owners.");
        Type[] owners = [typeof(LegacyBufferedWeapons), typeof(LegacyBufferedWeaponUpgrades),
            typeof(LegacyBufferedUnits), typeof(LegacyBufferedUnitUpgrades), typeof(LegacyBufferedEquipment),
            typeof(LegacyBufferedCosmetics), typeof(LegacyBufferedElite), typeof(LegacyBufferedInventoryMarkers),
            typeof(LegacyBufferedPartsConversion), typeof(LegacyBufferedCardPacks), typeof(LegacyBufferedSquadChat)];
        Require(owners.All(owner => owner.IsAbstract && owner.IsSealed && owner.GetFields(
                BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic |
                BindingFlags.Static | BindingFlags.Instance).Length == 0),
            "A stateless buffered feature owner retained process-wide mutable state.");
    }

    private static void CheckGraphRefusals(LegacyBufferedActionRegistry registry)
    {
        LegacyBufferedActionRegistration[] entries = registry.Actions.Values.ToArray();
        foreach (LegacyBufferedActionRegistration missing in entries)
        {
            Refuses(() => new LegacyBufferedActionRegistry(entries.Where(entry => entry != missing),
                LegacyBufferProcessor.SupportedActions));
        }
        Refuses(() => new LegacyBufferedActionRegistry([.. entries, entries[0]],
            LegacyBufferProcessor.SupportedActions));
        Refuses(() => new LegacyBufferedActionRegistry(
            [.. entries, entries[0] with { Action = (DatabaseAction)999999 }], LegacyBufferProcessor.SupportedActions));
        Refuses(() => new LegacyBufferedActionRegistry(
            [.. entries.Skip(1), entries[0] with { Feature = (LegacyBufferedFeature)999999 }],
            LegacyBufferProcessor.SupportedActions));
        Refuses(() => new LegacyBufferedActionRegistry(
            [.. entries.Skip(1), entries[0] with { Handler = null! }], LegacyBufferProcessor.SupportedActions));
        Refuses(() => LegacyBufferedActionRegistry.Create(LegacyCatalog.Empty,
            new HashSet<DatabaseAction>(LegacyBufferProcessor.SupportedActions.Skip(1))));
    }

    private static void CheckRequestIsolation()
    {
        LegacyPlayerDocument player = Player();
        LegacyBufferPlanner planner = Planner();
        var request = new BufferedRequest(0, DatabaseAction.WeaponWasShown, "fixture-weapon");
        LegacyBufferedMutation first = planner.Plan(player, request, Now, 7);
        LegacyBufferedMutation retry = planner.Plan(player, request, Now, 7);

        Require(first.Result == (int)DatabaseResult.Success &&
                first.Serialized["LevelManagerData"] == retry.Serialized["LevelManagerData"] &&
                first.ResponseJson == retry.ResponseJson, "The same request snapshot produced different plans.");
        var levels = JsonNode.Parse(first.Serialized["LevelManagerData"])!;
        Require(levels["savedWeapons"]!["fixture-weapon"]!["showed"]!.GetValue<bool>(),
            "The Inventory owner did not include its notification change in the publication plan.");
        Require(player.Serialized.Count == 0 && player.Gold == 100 && player.WarBucks == 500,
            "Planning changed the durable source document before transaction publication.");

        LegacyBufferedMutation closed = planner.Plan(player,
            new BufferedRequest(1, DatabaseAction.ClaimAssignment, null), Now, 7);
        Require(closed.Serialized.Count == 0,
            "A later request inherited the previous request's dirty subsystem state.");
    }

    private static void CheckFailedPublicationGuard()
    {
        LegacyPlayerDocument player = Player();
        var state = new LegacyBufferedState(player, Now, new Random(7));
        Require(state.TrySpendGold(25) && !state.TrySpendWarBucks(501), "The wallet fixture did not reach its guard.");
        var response = new JsonObject { ["ActionId"] = (int)DatabaseAction.BuyWeapon };
        try
        {
            state.BuildMutation(DatabaseAction.BuyWeapon, DatabaseResult.NotEnoughWarbucks, response);
        }
        catch (InvalidDataException)
        {
            Require(player.Gold == 100 && player.WarBucks == 500 && player.Serialized.Count == 0,
                "A rejected publication changed the source account.");
            return;
        }
        throw new InvalidOperationException("A failed action published a pending wallet debit.");
    }

    private static void CheckClosedAndMalformedActions()
    {
        LegacyBufferPlanner planner = Planner();
        LegacyBufferedMutation closed = planner.Plan(Player(),
            new BufferedRequest(0, DatabaseAction.GameEnded, null), Now, 7);
        Require(closed.Result == (int)DatabaseResult.ServerMaintenance && closed.Serialized.Count == 0,
            "An unsupported buffered action became an empty success or mutation.");
        LegacyBufferedMutation malformed = planner.Plan(Player(),
            new BufferedRequest(1, DatabaseAction.BuyWeapon, "{"), Now, 7);
        Require(malformed.Result == (int)DatabaseResult.JsonFailure && malformed.Serialized.Count == 0 &&
                malformed.Gold == 100 && malformed.WarBucks == 500,
            "Malformed feature input bypassed the per-action error boundary or changed the wallet.");
    }

    private static LegacyBufferPlanner Planner()
    {
        return new(LegacyCatalog.Empty, LegacyBufferProcessor.SupportedActions, NullLogger.Instance);
    }

    private static LegacyPlayerDocument Player()
    {
        return new() { Id = new string('a', 32), Gold = 100, WarBucks = 500 };
    }

    private static void Refuses(Action action)
    {
        try
        {
            action();
        }
        catch (InvalidOperationException)
        {
            return;
        }
        throw new InvalidOperationException("An invalid buffered action graph was accepted.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}

using System.Text.Json;
using War.BattleServer;
using War.Protocol;
using War.Shared;

/// <summary>Separates full owned card catalogs from the bounded prebattle selection list.</summary>
internal static class CardCatalogCapacityTests
{
    private const int SelectedCardLimit = 32;
    private const int RepresentativeHandSize = 3;

    internal static int Run(MatchManifest definition)
    {
        string[] sourceIds = WarCardSourceIdentityCatalog.All.Select(row => row.SourceCardId).ToArray();
        Require(sourceIds.Length > SelectedCardLimit, "The fixture must exercise more than a selected hand.");
        string owner = definition.Players[0].PlayerId;
        string opponent = definition.Players[1].PlayerId;
        BattleAllocationProjection owned = CreateAllocation(owner, sourceIds);
        BattleAllocationProjection roundTrip = BattleAllocationProjection.Validate(
            JsonSerializer.Deserialize<BattleAllocationProjection>(JsonSerializer.Serialize(owned))!);
        Require(roundTrip.CardIds.SequenceEqual(sourceIds) && roundTrip.CardCounts.All(count => count == 1),
            "Full source inventory was truncated during allocation transport.");

        var host = new MatchEngine(definition);
        host.ConfigureBattleAllocations([owned, CreateAllocation(opponent, [])]);
        Require(host.Admit(owner), "Full-inventory fixture admission failed.");
        var selectionState = new BattleCardSelectionState();
        var catalog = sourceIds.ToHashSet(StringComparer.Ordinal);
        Reject(() => selectionState.Submit(owner, "oversized", sourceIds.Take(SelectedCardLimit + 1), catalog));
        Require(selectionState.Submit(owner, "accepted", sourceIds.Take(SelectedCardLimit), catalog).Count ==
            SelectedCardLimit, "The selection policy rejected its existing boundary.");
        var selection = new SelectCardsCommand();
        selection.CardIds.Add(sourceIds.Take(RepresentativeHandSize));
        Require(host.Command(owner, new MatchCommand { CommandId = 1, SelectCards = selection }).Code ==
            "cards-selected", "A valid hand could not be selected from the full owned catalog.");

        var splitHost = new MatchEngine(definition);
        int middle = sourceIds.Length / 2;
        splitHost.ConfigureBattleAllocations([CreateAllocation(owner, sourceIds.Take(middle).ToArray()),
            CreateAllocation(opponent, sourceIds.Skip(middle).ToArray())]);
        CheckTransportBounds(owner);
        return 7;
    }

    internal static BattleAllocationProjection CreateAllocation(string owner, string[] identities)
    {
        return new BattleAllocationProjection(owner, identities, [], [], [], [])
        {
            CardCounts = identities.Select(_ => 1).ToArray()
        };
    }

    private static void CheckTransportBounds(string owner)
    {
        string[] maximum = Enumerable.Range(0, BattleAllocationProjection.MaximumCardInventoryIdentities)
            .Select(index => "fixture-card-" + index).ToArray();
        BattleAllocationProjection.Validate(CreateAllocation(owner, maximum));
        Reject(() => BattleAllocationProjection.Validate(CreateAllocation(owner, [.. maximum, "one-too-many"])));
        string[] union = [.. maximum, .. maximum.Select(identity => identity + "-peer")];
        var catalog = union.ToHashSet(StringComparer.Ordinal);
        BattleLoadoutPolicy.ValidateCardCatalog(union, catalog);
        Reject(() => BattleLoadoutPolicy.ValidateCardCatalog([.. union, "one-too-many"],
            new HashSet<string>([.. union, "one-too-many"], StringComparer.Ordinal)));
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

        throw new InvalidOperationException("Oversized card authority was accepted.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}

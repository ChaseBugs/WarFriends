using War.Backend.Legacy;
using War.Client;
using War.Persistence;
using War.Shared;

namespace War.Battle.Tests;

/// <summary>Exercises normal HTTP refresh against a deliberate server-authored inventory fixture change.</summary>
internal static class LiveInactiveRefreshChecks
{
    private const string CardId = "SLOWDOWN";
    private const int OwnedCopies = 2;

    internal static async Task RunAsync(BackendClient backend, Settings settings, Stores stores,
        CancellationToken cancellationToken)
    {
        var cards = new CardManagerData();
        cards.CardData.Add(CardId, new SavedCardData { Amount = OwnedCopies });
        await stores.Players.SetSerialized(settings.PlayerId, "CardManagerData",
            PlayerState.Write(cards), cancellationToken);
        bool isActiveRefreshRejected = false;
        try
        {
            await backend.JoinMatchQueueAsync(settings.Token, cancellationToken);
        }
        catch (HttpRequestException failure) when (failure.Message.Contains("Backend status 409", StringComparison.Ordinal))
        {
            isActiveRefreshRejected = true;
        }
        BattleAllocationProjection retained = await stores.Allocations.Get(settings.PlayerId, cancellationToken)
            ?? throw new InvalidDataException("The active queue allocation disappeared.");
        Require(isActiveRefreshRejected && retained.CardIds.Count == 0,
            "Active queue ownership allowed HTTP allocation refresh.");
        Require((await backend.CancelMatchQueueAsync(settings.Token, cancellationToken)).Code == "cancelled",
            "The refresh fixture did not cancel its waiting ticket.");
        Require((await backend.JoinMatchQueueAsync(settings.Token, cancellationToken)).Code == "waiting",
            "The refreshed player did not reenter the normal queue.");
        BattleAllocationProjection refreshed = await stores.Allocations.Get(settings.PlayerId, cancellationToken)
            ?? throw new InvalidDataException("The refreshed HTTP queue allocation disappeared.");
        Require(refreshed.CardIds.Single() == CardId && refreshed.CardCounts.Single() == OwnedCopies,
            "Normal queue admission did not project current durable card ownership.");
        Console.WriteLine("PASS: normal HTTP queue rejects active refresh " +
            "and projects current ownership after cancellation");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidDataException(message);
        }
    }

    internal sealed record Settings(string PlayerId, string Token);
    internal sealed record Stores(LegacyPlayerStore Players, BattleAllocationStore Allocations);
}

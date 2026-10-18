using War.Backend;
using War.Persistence;

/// <summary>Checks complete roster ordering and rejects partial or damaged manifest authority.</summary>
internal static class BattleManifestAuthorityTests
{
    internal static async Task RunMongoAsync(string uri, string databaseName)
    {
        var store = new BattleAllocationStore(uri, databaseName);
        string[] identities = [new string('f', 32), new string('d', 32)];
        IReadOnlyList<BattleAllocationAccountSnapshot> rows = await store.GetAccountSnapshotsAsync(
            identities, CancellationToken.None);
        Require(rows.Select(row => row.Account.Id).SequenceEqual(identities) &&
            rows.Select(row => row.Allocation.PlayerId).SequenceEqual(identities),
            "Paired manifest authority changed source roster ordering.");
        Require(rows.All(row => row.Allocation.CardIds.Count == 0),
            "Paired manifest authority restored removed or unowned cards.");
        foreach (BattleAllocationAccountSnapshot row in rows)
        {
            BattleAllocationSource.ValidateMatchesAccount(row.Account, row.Allocation);
        }
        rows[0].Allocation.CardIds = ["SLOWDOWN"];
        rows[0].Allocation.CardCounts = [1];
        bool mismatchRejected = false;
        try
        {
            BattleAllocationSource.ValidateMatchesAccount(rows[0].Account, rows[0].Allocation);
        }
        catch (InvalidDataException)
        {
            mismatchRejected = true;
        }
        Require(mismatchRejected, "A stale allocation granted a card absent from its account snapshot.");
        await RejectAsync(store, [identities[0], new string('c', 32)]);
        await RejectAsync(store, [identities[0], new string('e', 32)]);
        Console.WriteLine("PASS: coherent manifest authority preserves roster and rejects missing or damaged participants");
    }

    private static async Task RejectAsync(BattleAllocationStore store, string[] identities)
    {
        try
        {
            await store.GetAccountSnapshotsAsync(identities, CancellationToken.None);
        }
        catch (InvalidDataException)
        {
            return;
        }
        throw new InvalidDataException("Incomplete or damaged paired authority was accepted.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidDataException(message);
        }
    }
}

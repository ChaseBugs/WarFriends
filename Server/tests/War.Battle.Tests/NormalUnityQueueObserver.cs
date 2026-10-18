using System.Text.Json;
using MongoDB.Driver;
using War.Persistence;
using War.Shared;

namespace War.Battle.Tests;

/// <summary>Records an actual normal Unity controller's first durable queue admission.</summary>
internal static class NormalUnityQueueObserver
{
    private const int MaximumObservationSeconds = 180;

    /// <summary>Watches only the isolated boot database and publishes no account credentials.</summary>
    internal static async Task WatchAsync(string uri, string databaseName, string reportPath)
    {
        const string databasePrefix = "war_client_boot_";
        if (!databaseName.StartsWith(databasePrefix, StringComparison.Ordinal) ||
            !Guid.TryParseExact(databaseName[databasePrefix.Length..], "N", out _))
        {
            throw new InvalidDataException("Normal Unity queue observation requires an isolated boot database.");
        }

        IMongoDatabase database = new MongoClient(uri).GetDatabase(databaseName);
        IMongoCollection<BattleQueueTicketDocument> tickets =
            database.GetCollection<BattleQueueTicketDocument>("battle_queue_tickets");
        using var deadline = new CancellationTokenSource(TimeSpan.FromSeconds(MaximumObservationSeconds));
        using var cursor = await tickets.WatchAsync(cancellationToken: deadline.Token);
        await File.WriteAllTextAsync(reportPath + ".ready", "ready\n", deadline.Token);
        while (await cursor.MoveNextAsync(deadline.Token))
        {
            foreach (ChangeStreamDocument<BattleQueueTicketDocument> change in cursor.Current)
            {
                if (change.OperationType != ChangeStreamOperationType.Insert)
                {
                    continue;
                }

                await RecordAdmissionAsync(database, change.FullDocument, reportPath);
                return;
            }
        }
        throw new InvalidDataException("No normal Unity queue admission was observed.");
    }

    private static async Task RecordAdmissionAsync(
        IMongoDatabase database, BattleQueueTicketDocument ticket, string reportPath)
    {
        LegacyPlayerDocument account = await database.GetCollection<LegacyPlayerDocument>("legacyPlayers")
            .Find(player => player.Id == ticket.PlayerId).SingleAsync();
        BattleAllocationProjection? allocation = await new BattleAllocationStore(database)
            .Get(ticket.PlayerId, CancellationToken.None);
        if (account.Level != 4 || allocation == null || string.IsNullOrEmpty(ticket.AttemptId))
        {
            throw new InvalidDataException("The normal Unity ticket did not bind its returning account and allocation.");
        }

        await File.WriteAllTextAsync(reportPath, JsonSerializer.Serialize(new
        {
            schemaVersion = 1,
            scope = "normal Unity controller to durable Backend queue; no paired battle",
            hasReturningAccount = true,
            hasAllocation = true,
            hasScopedQueueAttempt = true
        }) + "\n");
        Console.WriteLine("PASS: normal Unity random matchmaking created a durable scoped queue ticket and allocation");
    }
}

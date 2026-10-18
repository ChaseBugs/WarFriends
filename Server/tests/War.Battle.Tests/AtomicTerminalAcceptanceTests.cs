using System.Text.Json;
using Google.Protobuf;
using MongoDB.Bson;
using MongoDB.Driver;
using War.BattleServer;
using War.Persistence;
using War.Protocol;
using War.Shared;

/// <summary>Checks MongoDB transaction identity for result insertion and allocation removal.</summary>
internal static class AtomicTerminalAcceptanceTests
{
    internal static async Task RunAsync(string uri)
    {
        string databaseName = "war_atomic_terminal_" + Guid.NewGuid().ToString("N");
        var mongo = new MongoClient(uri);
        var database = mongo.GetDatabase(databaseName);
        var queue = new BattleMatchQueueStore(uri, databaseName);
        var results = new BattleResultStore(uri, databaseName);
        using var deadline = new CancellationTokenSource(TimeSpan.FromMinutes(2));
        try
        {
            await queue.Initialize(deadline.Token);
            await results.Initialize(deadline.Token);
            var manifest = await CreatePairAsync(queue, deadline.Token);
            var snapshots = new BattleManifestSnapshotStore(uri, databaseName);
            await snapshots.GetOrCreate(manifest.MatchId, manifest.Players.Select(player => player.PlayerId).ToArray(),
                () => Task.FromResult(JsonSerializer.SerializeToUtf8Bytes(manifest)), deadline.Token);
            byte[] payload = FinishBattle(manifest);
            string digest = TerminalResultDigest.Compute(payload);
            using var changes = await database.WatchAsync(
                new EmptyPipelineDefinition<ChangeStreamDocument<BsonDocument>>(),
                new ChangeStreamOptions { MaxAwaitTime = TimeSpan.FromSeconds(1) }, deadline.Token);
            string accepted = await results.AcceptAndReleasePairAsync(
                manifest.MatchId, digest, payload, deadline.Token);
            Require(accepted == "accepted", "First terminal acceptance must publish exactly one result.");
            await VerifyTransactionAsync(changes, deadline.Token);
            var replay = await Task.WhenAll(
                results.AcceptAndReleasePairAsync(manifest.MatchId, digest, payload, deadline.Token),
                results.AcceptAndReleasePairAsync(manifest.MatchId, digest, payload, deadline.Token));
            Require(replay.All(code => code == "already-accepted") &&
                await queue.ForMatch(manifest.MatchId, deadline.Token) == null,
                "Concurrent exact replay must preserve the result without recreating the allocation.");
            await TerminalGrantRaceTests.RunAsync(uri, databaseName, deadline.Token);
            await AtomicCardConsumptionTests.RunAsync(uri, databaseName, deadline.Token);
            Console.WriteLine("PASS: terminal insertion and pair removal share one Mongo transaction; " +
                "concurrent replay is stable");
        }
        finally
        {
            await mongo.DropDatabaseAsync(databaseName);
        }
    }

    internal static async Task<MatchManifest> CreatePairAsync(
        BattleMatchQueueStore queue, CancellationToken cancellationToken)
    {
        string first = Guid.NewGuid().ToString("N");
        string second = Guid.NewGuid().ToString("N");
        var now = DateTimeOffset.UtcNow;
        await queue.Join(first, "atomic-terminal.fixture", now, cancellationToken);
        var pair = await queue.Join(second, "atomic-terminal.fixture", now, cancellationToken);
        string revision = new('a', 64);
        // Synthetic weapon values exercise persistence, not recovered combat balance.
        var weapon = new WeaponManifest("atomic-fixture-rifle", 2, 3, 0.1, 0.2);
        return new MatchManifest(pair.MatchId!, "fixture-host", "fixture-map", revision, revision,
            MatchManifest.PrototypeMode, 10, 60, 10,
            pair.Players!.Select(player => new ParticipantManifest(player, weapon)).ToArray());
    }

    internal static byte[] FinishBattle(MatchManifest manifest)
    {
        var battle = new MatchEngine(manifest);
        foreach (var player in manifest.Players)
        {
            Require(battle.Admit(player.PlayerId), "Fixture admission failed.");
            battle.Command(player.PlayerId, new MatchCommand
            {
                CommandId = 1, Ready = new ReadyCommand { ManifestHash = battle.ManifestHash },
            });
        }

        const int CountdownSeconds = 2;
        battle.Advance(CountdownSeconds * MatchManifest.TickRate);
        battle.Command(manifest.Players[0].PlayerId,
            new MatchCommand { CommandId = 2, Forfeit = new ForfeitCommand() });
        Require(battle.Snapshot().Phase == BattlePhase.Ended, "Fixture must produce an actual completed battle.");
        return battle.TerminalEvidenceSnapshot().ToByteArray();
    }

    private static async Task VerifyTransactionAsync(
        IChangeStreamCursor<ChangeStreamDocument<BsonDocument>> changes, CancellationToken cancellationToken)
    {
        var writes = new List<BsonDocument>();
        while (writes.Count < 2 && await changes.MoveNextAsync(cancellationToken))
        {
            foreach (var change in changes.Current)
            {
                if (change.CollectionNamespace.CollectionName is "battle_results" or "battle_pairs")
                {
                    writes.Add(change.BackingDocument);
                }
            }
        }

        Require(writes.Count == 2 && writes[0]["operationType"] == "insert" &&
            writes[1]["operationType"] == "delete" && writes.All(write => write.Contains("txnNumber")) &&
            writes[0]["txnNumber"] == writes[1]["txnNumber"] && writes[0]["lsid"] == writes[1]["lsid"],
            "Result insertion and pair deletion must be emitted by the same MongoDB transaction.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }
}

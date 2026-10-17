using MongoDB.Bson;
using MongoDB.Driver;
using War.Persistence;
using War.Shared;

/// <summary>Checks real durable participant consent, expiry, cancellation and concurrent writers.</summary>
internal static class RematchConsentStoreTests
{
    internal static async Task RunAsync(string uri)
    {
        string databaseName = "war_rematch_consent_" + Guid.NewGuid().ToString("N");
        var mongo = new MongoClient(uri);
        using var deadline = new CancellationTokenSource(TimeSpan.FromMinutes(1));
        try
        {
            var queue = new BattleMatchQueueStore(uri, databaseName);
            var results = new BattleResultStore(uri, databaseName);
            await queue.Initialize(deadline.Token);
            await results.Initialize(deadline.Token);
            var manifest = await AtomicTerminalAcceptanceTests.CreatePairAsync(queue, deadline.Token);
            byte[] payload = AtomicTerminalAcceptanceTests.FinishBattle(manifest);
            string digest = TerminalResultDigest.Compute(payload);
            await results.Accept(manifest.MatchId, digest, payload, deadline.Token);
            var first = new BattleRematchConsentStore(uri, databaseName);
            var second = new BattleRematchConsentStore(uri, databaseName);
            var fixture = new Fixture(first, second, mongo.GetDatabase(databaseName));
            string[] players = manifest.Players.Select(player => player.PlayerId).ToArray();
            var now = DateTimeOffset.UtcNow;
            Require(await first.ReadAsync(manifest.MatchId, players[0], now, deadline.Token) == null,
                "A status read must not create a consent window.");
            await RejectAsync(() => first.AcceptAsync(manifest.MatchId, "outsider", now, deadline.Token));
            await RejectAsync(() => first.CancelAsync(manifest.MatchId, "outsider", now, deadline.Token));
            await RejectAsync(() => first.AcceptAsync("missing-match", players[0], now, deadline.Token));
            await VerifyAgreementAsync(fixture, manifest.MatchId, players, deadline.Token);
            await VerifyExpiryAndCorruptionAsync(fixture, manifest.MatchId, players, deadline.Token);
            Require((await results.Get(manifest.MatchId, deadline.Token))?.Digest == digest,
                "Consent must never rewrite the completed result.");
            Console.WriteLine("PASS: durable rematch consent, concurrent agreement, cancellation, expiry and corruption");
        }
        finally
        {
            await mongo.DropDatabaseAsync(databaseName);
        }
    }

    private static async Task VerifyAgreementAsync(
        Fixture fixture, string matchId, string[] players, CancellationToken cancellationToken)
    {
        BattleRematchConsentStore first = fixture.First;
        BattleRematchConsentStore second = fixture.Second;
        var now = DateTimeOffset.UtcNow;
        BattleRematchConsentDocument[] initial = await Task.WhenAll(
            first.AcceptAsync(matchId, players[0], now, cancellationToken),
            second.AcceptAsync(matchId, players[0], now, cancellationToken));
        BattleRematchConsentDocument waiting = initial[0];
        Require(initial.All(row => row.Revision == 1), "Concurrent first consent must insert one record.");
        Require(waiting.Status == "waiting" && waiting.AcceptedPlayers.Length == 1,
            "One participant cannot authorize a two-player rematch.");
        var observed = await second.ReadAsync(matchId, players[1], now, cancellationToken);
        Require(observed?.Revision == waiting.Revision && observed.AcceptedPlayers.Length == 1,
            "Reading as the opponent must not silently add its consent.");
        BattleRematchConsentDocument replay = await second.AcceptAsync(matchId, players[0], now, cancellationToken);
        Require(replay.Revision == waiting.Revision && replay.ExpiresUtc == waiting.ExpiresUtc,
            "A replay must not extend consent or consume another revision.");
        BattleRematchConsentDocument[] agreement = await Task.WhenAll(
            first.AcceptAsync(matchId, players[1], now, cancellationToken),
            second.AcceptAsync(matchId, players[1], now, cancellationToken));
        Require(agreement.All(row => row.Status == "ready" && row.Revision == 2),
            "Independent stores must preserve exactly one second-player consent.");
        var cancelled = await first.CancelAsync(matchId, players[0], now, cancellationToken);
        var denied = await second.AcceptAsync(matchId, players[1], now, cancellationToken);
        Require(cancelled.Status == "cancelled" && denied.Status == "cancelled" &&
            denied.Revision == cancelled.Revision, "Cancellation must not reopen through delayed acceptance.");
    }

    private static async Task VerifyExpiryAndCorruptionAsync(
        Fixture fixture, string matchId, string[] players, CancellationToken cancellationToken)
    {
        BattleRematchConsentStore store = fixture.First;
        IMongoDatabase database = fixture.Database;
        var rows = database.GetCollection<BattleRematchConsentDocument>("battle_rematch_consents");
        await rows.DeleteOneAsync(row => row.Id == matchId, cancellationToken);
        var now = DateTimeOffset.UtcNow;
        var waiting = await store.AcceptAsync(matchId, players[0], now, cancellationToken);
        var expired = await store.ReadAsync(matchId, players[1],
            now.AddSeconds(BattleRematchConsentStore.ConsentDurationSeconds), cancellationToken);
        Require(expired?.Status == "expired" && expired.AcceptedPlayers.Length == 1 &&
            expired.ExpiresUtc == waiting.ExpiresUtc, "The half-open deadline must reject a late second consent.");
        await rows.UpdateOneAsync(row => row.Id == matchId,
            Builders<BattleRematchConsentDocument>.Update.Set(row => row.ResultDigest, new string('b', 64)),
            cancellationToken: cancellationToken);
        await RejectAsync(() => store.AcceptAsync(matchId, players[0],
            now.AddSeconds(BattleRematchConsentStore.ConsentDurationSeconds), cancellationToken));
        var raw = database.GetCollection<BsonDocument>("battle_rematch_consents");
        Require(await raw.CountDocumentsAsync(new BsonDocument("_id", matchId), cancellationToken: cancellationToken) == 1,
            "Damaged consent must not be discarded into another claimable request.");
    }

    private static async Task RejectAsync(Func<Task<BattleRematchConsentDocument>> action)
    {
        try
        {
            await action();
        }
        catch (InvalidDataException)
        {
            return;
        }
        throw new InvalidDataException("Invalid rematch authority was accepted.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidDataException(message);
        }
    }

    private sealed record Fixture(
        BattleRematchConsentStore First, BattleRematchConsentStore Second, IMongoDatabase Database);
}

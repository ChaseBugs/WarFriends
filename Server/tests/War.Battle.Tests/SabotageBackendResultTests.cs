using Google.Protobuf;
using MongoDB.Driver;
using War.Backend;
using War.BattleServer;
using War.Persistence;
using War.Shared;
using System.Net;
using System.Net.Http.Json;

internal static class SabotageBackendResultTests
{
    internal static async Task<int> Run(string contentDirectory, string mongoUri,
        bool useHttp = false, bool automaticForward = false, bool simulateOutage = false)
    {
        string database = "war_sabotage_live_" + Guid.NewGuid().ToString("N");
        var mongo = new MongoClient(mongoUri);
        BackendResultHttpTestHost? httpHost = null;
        ResultOutageProxy? outage = null;
        byte[]? retainedPayload = null;
        try
        {
            var results = new BattleResultStore(mongoUri, database);
            await results.Initialize(CancellationToken.None);
            var acceptance = new BattleTerminalAcceptance(results,
                new BattleMatchQueueStore(mongoUri, database),
                new BattleManifestSnapshotStore(mongoUri, database));
            if (useHttp)
                httpHost = await BackendResultHttpTestHost.Start(
                    contentDirectory, mongoUri, database);
            if (simulateOutage)
                outage = await ResultOutageProxy.Start(httpHost!.Endpoint);
            using var http = new HttpClient();
            BackendResultForwarder? forwarder = httpHost == null ? null :
                new BackendResultForwarder(http, httpHost.ControlKey, "local-1");

            async Task<string> Accept(string matchId, string digest, byte[] payload,
                CancellationToken cancellationToken)
            {
                if (forwarder != null)
                    return await forwarder.AcceptAsync(httpHost!.Endpoint,
                        matchId, digest, payload, cancellationToken);
                return await acceptance.Accept(matchId, digest, payload, cancellationToken);
            }

            return await LiveSabotageUdpTests.RunCardDrone(contentDirectory,
                async (evidence, cancellationToken) =>
                {
                    int checks = 0;
                    void Check(bool condition, string description)
                    {
                        if (!condition) throw new Exception(description);
                        checks++;
                    }

                    string matchId = evidence.Snapshot.MatchId;
                    byte[] payload = evidence.Snapshot.ToByteArray();
                    if (retainedPayload != null)
                        Check(payload.SequenceEqual(retainedPayload),
                            "Backend recovery stores the exact result retained during HTTP outage");
                    if (httpHost != null)
                    {
                        using var unsigned = await http.PostAsJsonAsync(httpHost.Endpoint,
                            new { serverId = "local-1", matchId, digest = evidence.Digest,
                                snapshot = Convert.ToBase64String(payload) }, cancellationToken);
                        Check(unsigned.StatusCode == HttpStatusCode.Unauthorized,
                            "unsigned HTTP result cannot enter Backend authority");
                        var wrongKey = new BackendResultForwarder(http, new byte[32], "local-1");
                        try
                        {
                            await wrongKey.AcceptAsync(httpHost.Endpoint, matchId,
                                evidence.Digest, payload, cancellationToken);
                            throw new Exception("Backend accepted an invalid result signature.");
                        }
                        catch (HttpRequestException error) when (error.Message.EndsWith("401"))
                        {
                            checks++;
                        }
                    }
                    Check(await Accept(matchId, evidence.Digest,
                        payload, cancellationToken) == (automaticForward ? "already-accepted" : "accepted"),
                        "Backend acceptance persists the real UDP card Drone result");
                    Check(await Accept(matchId, evidence.Digest,
                        payload, cancellationToken) == "already-accepted",
                        "repeated result delivery cannot create another result");

                    var reopened = new BattleResultStore(mongoUri, database);
                    var stored = await reopened.Get(matchId, cancellationToken);
                    Check(stored != null && stored.Snapshot.SequenceEqual(payload) &&
                        stored.Digest == evidence.Digest && !stored.Scored && !stored.Settled,
                        "a fresh Mongo repository retains exact unscored Worker evidence");
                    var kills = await reopened.GetDirectArmyKillEvidence(matchId, cancellationToken);
                    var expected = evidence.Snapshot.DirectArmyKills.Single();
                    Check(kills is { Count: 1 } &&
                        kills[0].VictimSourceCardId == "HEAVYDRONE" &&
                        kills[0].VictimSpawnRequestId == expected.VictimSpawnRequestId &&
                        kills[0].VictimSpawnTick == expected.VictimSpawnTick &&
                        kills[0].EntityKey == expected.EntityKey,
                        "Mongo result projection preserves exact card spawn provenance");
                    var stats = await reopened.GetSabotageKillStats(matchId, cancellationToken);
                    Check(stats!.Single(row => row.PlayerId == expected.AttackerPlayerId) is
                        { Kills: 1, OneHitKills: 1, VehiclesDestroyed: 1, TanksDestroyed: 0 },
                        "stored card Drone result projects one source-shaped kill");

                    var forged = evidence.Snapshot.Clone();
                    forged.DirectArmyKills[0].VictimSpawnRequestId = "invalid";
                    byte[] forgedPayload = forged.ToByteArray();
                    try
                    {
                        await Accept(matchId, TerminalResultDigest.Compute(forgedPayload),
                            forgedPayload, cancellationToken);
                        throw new Exception("Backend accepted forged card Drone provenance.");
                    }
                    catch (InvalidDataException)
                    {
                        checks++;
                    }
                    catch (HttpRequestException error) when (useHttp && error.Message.EndsWith("400"))
                    {
                        checks++;
                    }
                    stored = await reopened.Get(matchId, cancellationToken);
                    Check(stored!.Snapshot.SequenceEqual(payload),
                        "rejected result leaves the original Mongo authority unchanged");
                    return checks;
                }, automaticForward ? outage?.Endpoint ?? httpHost!.Endpoint : null,
                automaticForward ? httpHost!.ControlKey : null,
                automaticForward ? async (matchId, cancellationToken) =>
                {
                    var stored = await results.Get(matchId, cancellationToken);
                    return stored == null ? null : new TerminalOutbox.Evidence(
                        War.Protocol.MatchSnapshot.Parser.ParseFrom(stored.Snapshot), stored.Digest);
                } : null,
                outage == null ? null : async (outbox, cancellationToken) =>
                {
                    await outage.WaitForFailedDelivery(cancellationToken);
                    var pending = outbox.PendingPage().Single();
                    retainedPayload = pending.Snapshot.ToByteArray();
                    if (await results.Get(pending.Snapshot.MatchId, cancellationToken) != null ||
                        !outbox.HasIdentity(pending.Snapshot.MatchId))
                        throw new Exception("Failed HTTP delivery changed durable result authority.");
                    outage.Restore();
                    return 1;
                });
        }
        finally
        {
            if (outage != null) await outage.DisposeAsync();
            httpHost?.Dispose();
            await mongo.DropDatabaseAsync(database);
        }
    }
}

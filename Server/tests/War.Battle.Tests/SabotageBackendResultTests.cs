using Google.Protobuf;
using MongoDB.Driver;
using War.Backend;
using War.BattleServer;
using War.Persistence;
using War.Shared;

internal static class SabotageBackendResultTests
{
    internal static async Task<int> Run(string contentDirectory, string mongoUri)
    {
        string database = "war_sabotage_live_" + Guid.NewGuid().ToString("N");
        var mongo = new MongoClient(mongoUri);
        try
        {
            var results = new BattleResultStore(mongoUri, database);
            await results.Initialize(CancellationToken.None);
            var acceptance = new BattleTerminalAcceptance(results,
                new BattleMatchQueueStore(mongoUri, database),
                new BattleManifestSnapshotStore(mongoUri, database));

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
                    Check(await acceptance.Accept(matchId, evidence.Digest,
                        payload, cancellationToken) == "accepted",
                        "Backend acceptance persists the real UDP card Drone result");
                    Check(await acceptance.Accept(matchId, evidence.Digest,
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
                        await acceptance.Accept(matchId, TerminalResultDigest.Compute(forgedPayload),
                            forgedPayload, cancellationToken);
                        throw new Exception("Backend accepted forged card Drone provenance.");
                    }
                    catch (InvalidDataException)
                    {
                        checks++;
                    }
                    stored = await reopened.Get(matchId, cancellationToken);
                    Check(stored!.Snapshot.SequenceEqual(payload),
                        "rejected result leaves the original Mongo authority unchanged");
                    return checks;
                });
        }
        finally
        {
            await mongo.DropDatabaseAsync(database);
        }
    }
}

using System.Text.Json;
using Google.Protobuf;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using War.Backend.Features.Battle.Settlement;
using War.Backend.Legacy;
using War.Battle.Tests.Support;
using War.BattleServer;
using War.Persistence;
using War.Persistence.Battles.Settlement;
using War.Protocol;
using War.Shared;

namespace War.Battle.Tests.Legacy.Progression;

internal static class BattleSettlementStoreTests
{
    internal static async Task RunAsync(string uri, string contentDirectory)
    {
        var client = new MongoClient(uri);
        string name = "war_settlement_" + Guid.NewGuid().ToString("N");
        IMongoDatabase database = client.GetDatabase(name);
        using var deadline = new CancellationTokenSource(TimeSpan.FromMinutes(2));
        try
        {
            var queue = new BattleMatchQueueStore(uri, name);
            var results = new BattleResultStore(uri, name);
            await queue.Initialize(deadline.Token);
            await results.Initialize(deadline.Token);
            MatchManifest pair = await AtomicTerminalAcceptanceTests.CreatePairAsync(queue, deadline.Token);
            MatchManifest manifest = CreateManifest(pair, contentDirectory);
            var accounts = manifest.Players.Select(player => new LegacyPlayerDocument
            {
                Id = player.PlayerId, Name = "Settlement", Level = 0, ArmyPower = 93,
                Gold = 10, WarBucks = 20, Skill = 50, MedalsBalance = 50
            }).ToArray();
            foreach (LegacyPlayerDocument account in accounts)
            {
                await LegacyTestAccounts.InsertAsync(database, account, deadline.Token);
            }
            var snapshots = new BattleManifestSnapshotStore(uri, name);
            await snapshots.GetOrCreate(manifest.MatchId, accounts.Select(account => account.Id).ToArray(),
                () => Task.FromResult(JsonSerializer.SerializeToUtf8Bytes(manifest)), deadline.Token);
            byte[] payload = Finish(manifest, contentDirectory);
            string accepted = await results.AcceptAndReleasePairAsync(manifest.MatchId,
                TerminalResultDigest.Compute(payload), payload, deadline.Token);
            Require(accepted == "accepted", "Host outcome must be accepted before settlement.");
            DateTime now = DateTime.UtcNow;
            Task<string?> Settle(BattleResultStore store, LegacyPlayerDocument account) => store.SettleAsync(
                new(manifest.MatchId, account.Id, account.SessionHash, now),
                context => BattleSettlementCalculator.Calculate(context, now), deadline.Token);
            await CheckOverflowRollbackAsync(database, accounts, () => Settle(results, accounts[0]), deadline.Token);
            await ExpectRejectedAsync(() => results.SettleAsync(
                new(manifest.MatchId, accounts[0].Id, new string('A', 64), now),
                context => BattleSettlementCalculator.Calculate(context, now), deadline.Token));
            string?[] replies = await Task.WhenAll(Settle(results, accounts[0]), Settle(results, accounts[1]),
                Settle(results, accounts[0]), Settle(results, accounts[1]));
            Require(replies[0] == replies[2] && replies[1] == replies[3],
                "Concurrent requests must replay the exact participant response.");
            Require(await Settle(new BattleResultStore(uri, name), accounts[0]) == replies[0],
                "A recreated store must replay the persisted response.");
            List<LegacyPlayerDocument> saved = await database.GetCollection<LegacyPlayerDocument>("legacyPlayers")
                .Find(Builders<LegacyPlayerDocument>.Filter.Empty).ToListAsync(deadline.Token);
            Require(saved.Single(player => player.Id == accounts[0].Id).WarBucks == 420 &&
                saved.Single(player => player.Id == accounts[1].Id).WarBucks == 1020,
                "Loss and win plus first streak must be credited exactly once to both participants.");
            Require(saved.All(player => player.Revision == accounts[0].Revision + 1),
                "Replay must not publish another account successor.");
            Require(await database.GetCollection<BattleSettlementReceipt>("battle_settlements")
                .CountDocumentsAsync(FilterDefinition<BattleSettlementReceipt>.Empty,
                    cancellationToken: deadline.Token) == 1, "Exactly one match receipt must exist.");
            Console.WriteLine("PASS: atomic two-player rewards, concurrent/recreated-store replay, " +
                "overflow rollback, and session rejection");
        }
        finally
        {
            await client.DropDatabaseAsync(name);
        }
    }

    private static async Task CheckOverflowRollbackAsync(
        IMongoDatabase database, LegacyPlayerDocument[] accounts, Func<Task<string?>> settle,
        CancellationToken cancellationToken)
    {
        var playerRows = database.GetCollection<LegacyPlayerDocument>("legacyPlayers");
        await playerRows.UpdateOneAsync(player => player.Id == accounts[1].Id,
            Builders<LegacyPlayerDocument>.Update.Set(player => player.WarBucks, long.MaxValue),
            cancellationToken: cancellationToken);
        await ExpectRejectedAsync(settle);
        LegacyPlayerDocument untouched = await playerRows.Find(player => player.Id == accounts[0].Id)
            .SingleAsync(cancellationToken);
        Require(untouched.WarBucks == 20 && untouched.Revision == accounts[0].Revision,
            "An overflowing opponent wallet must roll back the first participant as well.");
        Require(await database.GetCollection<BattleSettlementReceipt>("battle_settlements")
            .CountDocumentsAsync(FilterDefinition<BattleSettlementReceipt>.Empty,
                cancellationToken: cancellationToken) == 0, "Rejected settlement must not consume the receipt.");
        await playerRows.UpdateOneAsync(player => player.Id == accounts[1].Id,
            Builders<LegacyPlayerDocument>.Update.Set(player => player.WarBucks, 20),
            cancellationToken: cancellationToken);
    }

    private static MatchManifest CreateManifest(MatchManifest pair, string directory)
    {
        MatchManifest template = MatchManifest.Read(Path.Combine(directory, "local-rifle-match-template.json"));
        LegacyCatalog catalog = LegacyCatalog.Load(Path.Combine(directory, "recovered-battle-content.json"));
        BattleRewardPolicy policy = BattleRewardPolicy.Create(catalog, new ConfigurationBuilder().Build());
        return MatchManifest.Validate(template with
        {
            MatchId = pair.MatchId, SceneMasterPlayerId = pair.Players[0].PlayerId,
            PvpBonusMode = MatchManifest.OrdinaryPvpBonusMode, PvpGoldBonusesAtAdmission = 0,
            SettlementPolicyJson = policy.ToJson(), SettlementPolicyRevision = policy.Revision(),
            Players = template.Players.Select((player, index) => player with
            {
                PlayerId = pair.Players[index].PlayerId, PlayerLevel = 0
            }).ToArray()
        });
    }

    private static byte[] Finish(MatchManifest manifest, string directory)
    {
        BattleCombatContent content = BattleCombatContent.Load(Path.Combine(directory, "combat-content-manifest.json"));
        var map = content.Maps.Single(row => Path.GetFileNameWithoutExtension(row.Source) == manifest.MapId);
        var engine = new MatchEngine(manifest, map, content);
        foreach (ParticipantManifest player in manifest.Players)
        {
            Require(engine.Admit(player.PlayerId), "Participant must be admitted.");
            engine.Command(player.PlayerId, new MatchCommand
            {
                CommandId = 1, Ready = new ReadyCommand { ManifestHash = engine.ManifestHash }
            });
        }
        engine.Advance(2 * MatchManifest.TickRate);
        engine.Command(manifest.Players[0].PlayerId,
            new MatchCommand { CommandId = 2, Forfeit = new ForfeitCommand() });
        MatchSnapshot terminal = engine.TerminalEvidenceSnapshot();
        Require(terminal.Phase == BattlePhase.Ended && terminal.RewardEligible,
            "Only the completed host outcome should carry reward eligibility.");
        return terminal.ToByteArray();
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }

    private static async Task ExpectRejectedAsync(Func<Task<string?>> action)
    {
        try
        {
            await action();
        }
        catch (Exception error) when (error is InvalidDataException or OverflowException)
        {
            return;
        }
        throw new Exception("Invalid settlement was accepted.");
    }
}

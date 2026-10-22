using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using War.Backend.Features.Battle.Settlement;
using War.Backend.Legacy.Progression;
using War.Battle.Tests.Legacy.Accounts;
using War.Persistence;
using War.Persistence.Legacy.Progression;

namespace War.Battle.Tests.Legacy;

internal static class OfflineBotSyncTests
{
    internal static async Task RunAsync(string uri)
    {
        string database = "offline_bot_test_" + Guid.NewGuid().ToString("N");
        var mongo = new MongoClient(uri);
        try
        {
            var players = new LegacyPlayerStore(uri, database);
            var created = await players.CreateAccountAsync(LegacyAccountTestFixture.Creation(), default);
            var policy = BattleRewardPolicy.Create(LegacyAccountTestFixture.Catalog(), new ConfigurationBuilder().Build());
            var service = new OfflineBotSyncService(players, policy);
            string stream = Guid.NewGuid().ToString("N");
            var journal = new OfflineBotJournal(stream, [new(1, 2, 100, 3, 17), new(2, 1, 50)]);
            await Task.WhenAll(Enumerable.Range(0, 4).Select(_ => service.MergeAsync(created.Player, journal, default)));
            var saved = (await players.ById(created.Player.Id, default))!;
            Require(saved.WarBucks == 15000 + policy.WinWarBucks + policy.LoseWarBucks + 17,
                "Concurrent upload granted bot rewards more than once.");
            Require(saved.Gold == created.Player.Gold + 3,
                "Crate Gold was not imported exactly once.");
            Require(saved.Experience == 150 && saved.OfflineBotStreams[stream] == 2,
                "Offline XP and receipt were not committed together.");
            Require(saved.Skill == created.Player.Skill && saved.MedalsBalance == created.Player.MedalsBalance,
                "An offline outcome changed ranked competition.");
            long revision = saved.Revision;
            await service.MergeAsync(created.Player, journal, default);
            Require((await players.ById(saved.Id, default))!.Revision == revision,
                "An acknowledged journal replay changed the account.");
            await Reject(() => service.MergeAsync(created.Player,
                new OfflineBotJournal(stream, [new(4, 2, 10)]), default));
            await Reject(() => service.MergeAsync(created.Player,
                new OfflineBotJournal(stream, [new(3, 2, -1)]), default));
            await Reject(() => service.MergeAsync(created.Player,
                new OfflineBotJournal(stream, [new(3, 10, 10)]), default));
            await Reject(() => service.MergeAsync(created.Player,
                new OfflineBotJournal(stream, [new(3, 2, 10, 1001)]), default));
            await Reject(() => service.MergeAsync(created.Player,
                new OfflineBotJournal(stream, [new(3, 2, 10, 0, -1)]), default));
            Require((await players.ById(saved.Id, default))!.Revision == revision,
                "Rejected uploads modified progression or receipts.");
            var next = await service.MergeAsync(created.Player,
                new OfflineBotJournal(stream, [new(2, 1, 50), new(3, 2, 25)]), default);
            Require(next.Experience == 175 && next.OfflineBotStreams[stream] == 3,
                "An overlapping retry did not apply only its unseen suffix.");
            Console.WriteLine("PASS: offline bot upload, concurrent replay, gap rejection and competition isolation");
        }
        finally { await mongo.DropDatabaseAsync(database); }
    }

    private static void Require(bool condition, string message)
    {
        if (!condition) throw new InvalidOperationException(message);
    }
    private static async Task Reject(Func<Task<LegacyPlayerDocument>> operation)
    {
        try { await operation(); }
        catch (InvalidDataException) { return; }
        throw new InvalidOperationException("Invalid offline journal was accepted.");
    }
}

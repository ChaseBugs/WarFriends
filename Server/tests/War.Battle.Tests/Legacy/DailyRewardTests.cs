using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using MongoDB.Driver;
using War.Backend.Hosting.Configuration;
using War.Backend.Legacy;
using War.Backend.Legacy.Progression;
using War.Battle.Tests.Legacy.Accounts;
using War.Persistence;
using War.Persistence.Legacy.Progression;

namespace War.Battle.Tests.Legacy;

internal static class DailyRewardTests
{
    internal static async Task RunAsync(string uri)
    {
        VerifyCalendarAndPolicy();
        VerifyParsing();
        var mongo = new MongoClient(uri);
        string database = "daily_reward_test_" + Guid.NewGuid().ToString("N");
        try
        {
            await VerifyPublicationAsync(uri, database);
            Console.WriteLine("PASS: daily rewards: calendar, parsing, policy, concurrency, replay and overflow");
        }
        finally
        {
            await mongo.DropDatabaseAsync(database);
        }
    }

    private static async Task VerifyPublicationAsync(string uri, string database)
    {
        var players = new LegacyPlayerStore(uri, database);
        var created = await players.CreateAccountAsync(LegacyAccountTestFixture.Creation(), default);
        DateTimeOffset now = DateTimeOffset.UtcNow;
        var policy = new DailyRewardPolicy(5, 25);
        var check = new DailyRewardOperation(now);
        DailyRewardCommit opened = await players.ApplyDailyRewardAsync(created.Player, check, policy, default);
        Require(opened.Player.DailyRewards!.CanClaim == 1, "Initial visit must earn one day, not the date number.");
        var claim = new DailyRewardOperation(now, opened.Player.DailyRewards.Identity, 1);
        DailyRewardCommit[] results = await Task.WhenAll(Enumerable.Range(0, 4).Select(_ =>
            players.ApplyDailyRewardAsync(created.Player, claim, policy, default)));
        Require(results.Sum(result => result.AddedGold) == 5, "Concurrent requests granted more than once.");
        LegacyPlayerDocument saved = (await players.ById(created.Player.Id, default))!;
        Require(saved.Gold == created.Player.Gold + 5 && saved.DailyRewards!.Claimed == 1,
            "Wallet and claim cursor were not published together.");
        var restarted = new LegacyPlayerStore(uri, database);
        DailyRewardCommit replay = await restarted.ApplyDailyRewardAsync(created.Player, claim, policy, default);
        Require(replay.WasAlreadyClaimed && replay.AddedGold == 0, "Replay would add a second Client delta.");
        DailyRewardCommit sameDay = await players.ApplyDailyRewardAsync(created.Player, check,
            new DailyRewardPolicy(50, 250), default);
        Require(sameDay.Player.DailyRewards!.CanClaim == 1 && sameDay.Player.DailyRewards.OrdinaryGold == 5,
            "Repeated checks or policy changes rewrote the active calendar.");
        await RejectAsync(() => players.ApplyDailyRewardAsync(created.Player, claim with { Day = 2 }, policy, default));
        await RejectAsync(() => players.ApplyDailyRewardAsync(created.Player,
            claim with { CalendarId = "1970-01" }, policy, default));
        await VerifyCalendarMigrationAsync(uri, database, created.Player);
        created.Player.SessionHash = new string('a', 64);
        await RejectAsync(() => players.ApplyDailyRewardAsync(created.Player, check, policy, default));
        await VerifyOverflowAsync(players, now, policy);
    }

    private static async Task VerifyOverflowAsync(LegacyPlayerStore players, DateTimeOffset now, DailyRewardPolicy policy)
    {
        var creation = LegacyAccountTestFixture.Creation();
        creation.Player.Gold = long.MaxValue;
        var created = await players.CreateAccountAsync(creation, default);
        now = DateTimeOffset.UtcNow;
        DailyRewardCommit opened = await players.ApplyDailyRewardAsync(
            created.Player, new DailyRewardOperation(now), policy, default);
        var claim = new DailyRewardOperation(now, opened.Player.DailyRewards!.Identity, 1);
        await RejectAsync(() => players.ApplyDailyRewardAsync(created.Player, claim, policy, default));
        LegacyPlayerDocument saved = (await players.ById(created.Player.Id, default))!;
        Require(saved.Gold == long.MaxValue && saved.DailyRewards!.Claimed == 0,
            "An overflowing reward consumed the claim.");
    }

    private static async Task VerifyCalendarMigrationAsync(
        string uri, string database, LegacyPlayerDocument player)
    {
        var players = new LegacyPlayerStore(uri, database);
        IMongoCollection<LegacyPlayerDocument> collection = new MongoClient(uri)
            .GetDatabase(database).GetCollection<LegacyPlayerDocument>("legacyPlayers");
        DateTimeOffset now = DateTimeOffset.UtcNow;
        DateTimeOffset previous = now.AddMonths(-1);
        var expired = new DailyRewardCalendar
        {
            Year = previous.Year, Month = previous.Month, LastCheckDay = 99,
            CanClaim = 99, Claimed = 100, OrdinaryGold = 5, WeeklyGold = 25
        };
        await collection.UpdateOneAsync(row => row.Id == player.Id,
            Builders<LegacyPlayerDocument>.Update.Set(row => row.DailyRewards, expired));
        DailyRewardCommit rolled = await players.ApplyDailyRewardAsync(player,
            new DailyRewardOperation(now), new DailyRewardPolicy(5, 25), default);
        Require(rolled.Player.DailyRewards!.Identity != expired.Identity &&
            rolled.Player.DailyRewards.Claimed == 0 && rolled.Player.DailyRewards.CanClaim == 1,
            "Expired claim authority was retained or prevented the new monthly calendar.");
        DailyRewardCalendar future = new DailyRewardPolicy(5, 25).Open(now.AddMonths(1));
        await collection.UpdateOneAsync(row => row.Id == player.Id,
            Builders<LegacyPlayerDocument>.Update.Set(row => row.DailyRewards, future));
        await RejectAsync(() => players.ApplyDailyRewardAsync(player,
            new DailyRewardOperation(now), new DailyRewardPolicy(5, 25), default));
        await collection.UpdateOneAsync(row => row.Id == player.Id,
            Builders<LegacyPlayerDocument>.Update.Set(row => row.DailyRewards, rolled.Player.DailyRewards));
    }

    private static void VerifyCalendarAndPolicy()
    {
        var policy = new DailyRewardPolicy(5, 25);
        var leapDay = new DateTimeOffset(2028, 2, 29, 23, 59, 59, TimeSpan.Zero);
        DailyRewardCalendar calendar = policy.Open(leapDay);
        calendar.Validate(leapDay);
        Require(calendar.GoldForDay(7) == 25 && calendar.GoldForDay(29) == 5, "Wrong weekly/leap-day reward.");
        Reject(() => calendar.GoldForDay(30));
        Reject(() => calendar.Validate(leapDay.AddMonths(-1)));
        calendar.Claimed = 2;
        Reject(() => calendar.Validate(leapDay));
        Require(calendar.IsExpired(leapDay.AddSeconds(1)), "Expired month retained reward authority.");
        Reject(() => new DailyRewardPolicy(10, 5));
        foreach (string invalid in new[] { "-1", "NaN", "1.5", "1e3", " 5", "05", "" })
        {
            var settings = new Dictionary<string, string?> { ["Legacy:DailyRewards:OrdinaryGold"] = invalid };
            Reject(() => BackendDailyRewardPolicy.Read(new ConfigurationBuilder().AddInMemoryCollection(settings).Build()));
        }
    }

    private static void VerifyParsing()
    {
        foreach (string invalid in new[] { "0", "32", "01", "1.0", "+1", " 1", "1e0", "true", "null", "" })
        {
            Require(LegacyDailyRewardEndpoint.ParseDay(Request(invalid)) == null, "Malformed day was accepted.");
        }
        Require(LegacyDailyRewardEndpoint.ParseDay(Request("1")) == 1, "Source spelling was rejected.");
        Require(LegacyDailyRewardEndpoint.ParseDay(Request("1", true)) == null, "Ambiguous aliases were accepted.");
    }

    private static LegacyRequest Request(string day, bool addAlias = false)
    {
        var context = new DefaultHttpContext();
        context.Request.ContentType = "application/x-www-form-urlencoded";
        var fields = new Dictionary<string, StringValues> { ["requestId"] = "1002", ["claimRweard"] = day };
        if (addAlias)
        {
            fields["claimReward"] = day;
        }
        context.Request.Form = new FormCollection(fields);
        Require(LegacyRequest.TryParse(context.Request, out LegacyRequest? request), "Test request failed to parse.");
        return request!;
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
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
        throw new InvalidOperationException("Invalid daily reward authority was accepted.");
    }

    private static async Task RejectAsync(Func<Task<DailyRewardCommit>> action)
    {
        try
        {
            await action();
        }
        catch (InvalidDataException)
        {
            return;
        }
        throw new InvalidOperationException("Invalid daily reward mutation was accepted.");
    }
}

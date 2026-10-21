using MongoDB.Bson;
using MongoDB.Driver;
using War.Persistence;
using War.Protocol;

namespace War.Battle.Tests.Identity;

/// <summary>Rejects corrupted modern account identity before token rotation or profile publication.</summary>
internal static class CanonicalAccountStoreTests
{
    internal static async Task RunAsync(string uri)
    {
        string databaseName = "war_identity_" + Guid.NewGuid().ToString("N");
        var client = new MongoClient(uri);
        IMongoDatabase database = client.GetDatabase(databaseName);
        var store = new AccountStore(uri, databaseName);
        using var deadline = new CancellationTokenSource(TimeSpan.FromSeconds(60));
        try
        {
            await store.Initialize(deadline.Token);
            string canonical = "abcdef" + Guid.NewGuid().ToString("N")[6..];
            string[] aliases = [" " + canonical + " ", canonical.ToUpperInvariant(), canonical + "\t",
                Guid.ParseExact(canonical, "N").ToString("D")];
            int index = 0;
            foreach (string alias in aliases)
            {
                string token = LegacyPlayerStore.NewToken();
                var account = new AccountDocument
                {
                    Id = alias, Username = "identity" + index++, Locale = "en", Salt = new byte[16],
                    PasswordHash = new byte[32], SessionHash = AccountStore.HashToken(token),
                    CreatedUtc = DateTime.UtcNow, SessionExpiresUtc = DateTime.UtcNow.AddHours(1)
                };
                var documents = database.GetCollection<AccountDocument>("accounts");
                await documents.InsertOneAsync(account, cancellationToken: deadline.Token);
                byte[] before = account.ToBson();
                await RequireInvalidAsync(() => store.Authenticate(token, deadline.Token));
                await RequireInvalidAsync(() => store.Login(new LoginRequest
                {
                    Username = account.Username, Password = "identity-fixture-password"
                }, deadline.Token));
                AccountDocument after = await documents.Find(row => row.Id == alias).SingleAsync(deadline.Token);
                if (!before.AsSpan().SequenceEqual(after.ToBson()))
                {
                    throw new InvalidOperationException("Corrupt identity rotated a modern account session.");
                }
            }
            Console.WriteLine("PASS: 4 modern account identity/authentication/pre-rotation no-write groups");
        }
        finally
        {
            await client.DropDatabaseAsync(databaseName, CancellationToken.None);
        }
    }

    private static async Task RequireInvalidAsync(Func<Task> action)
    {
        try
        {
            await action();
        }
        catch (InvalidDataException)
        {
            return;
        }
        throw new InvalidOperationException("A corrupt durable identity was accepted or compared as credentials.");
    }
}

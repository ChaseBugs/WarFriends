using War.Backend.Legacy;
using War.Backend.Legacy.Accounts;
using War.Persistence;
using War.Persistence.Legacy.Accounts;

namespace War.Battle.Tests.Legacy.Accounts;

internal static class LegacyAccountTestFixture
{
    internal static LegacyAccountRegistration Registration() => new() { Locale = "en", UtcOffsetHours = 0 };

    internal static LegacyAccountCreation Creation() => new()
    {
        Registration = Registration(),
        SessionLifetimeHours = 24,
        NowUnixSeconds = checked((int)DateTimeOffset.UtcNow.ToUnixTimeSeconds()),
        Player = new LegacyPlayerDocument
        {
            Name = "Recruit",
            Gold = 75,
            WarBucks = 15000,
            DogTagMax = 4500,
            SquadRank = -1,
            Serialized = LegacyInitialLoadout.CreateSerializedState()
        }
    };

    internal static LegacyStarterPolicy Policy() =>
        LegacyStarterPolicy.FromOptions(LegacyStarterState.FromCatalog(Catalog()));

    internal static LegacyCatalog Catalog()
    {
        DirectoryInfo? directory = new(AppContext.BaseDirectory);
        while (directory != null)
        {
            string path = Path.Combine(directory.FullName, "content/recovered-battle-content.json");
            if (File.Exists(path))
            {
                return LegacyCatalog.Load(path);
            }

            directory = directory.Parent;
        }

        throw new FileNotFoundException("Missing source account catalog.");
    }

    internal static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }

    internal static void ExpectInvalid(Action action)
    {
        bool hasRejected = false;
        try
        {
            action();
        }
        catch (InvalidDataException)
        {
            hasRejected = true;
        }

        Require(hasRejected, "Invalid account/session authority was accepted.");
    }
}

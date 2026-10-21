using War.LegacyContract.Tests.Recovered;
using War.Persistence;
using War.Persistence.Legacy.Profile;

namespace War.LegacyContract.Tests;

/// <summary>Checks immutable profile inputs and executes the unchanged source price/callback contracts.</summary>
internal static class ProfileContractTests
{
    internal static int Run()
    {
        CheckInputBoundaries();
        CheckSourcePrices();
        CheckSourceCallbacks();
        CheckStoredProfile();
        return 4;
    }

    private static void CheckInputBoundaries()
    {
        foreach (int status in new[] { 0, 1, 2 })
        {
            LegacyProfileChange.ForStatus(status);
        }

        Reject(() => LegacyProfileChange.ForStatus(-1));
        Reject(() => LegacyProfileChange.ForStatus(3));
        foreach (string? value in new string?[] { null, "", " ", "token\n", "\ud800" })
        {
            Reject(() => LegacyProfileChange.ForDeviceRegistration(value, "en"));
        }

        LegacyProfileChange.ForDeviceRegistration(" padded opaque token ", "ko-KR");
        foreach (string? value in new string?[] { null, "", "EN", " en", "en ", "???" })
        {
            Reject(() => LegacyProfileChange.ForLanguage(value));
            Reject(() => LegacyProfileChange.ForDeviceRegistration("token", value));
        }

        foreach (string? value in new string?[] { null, "", "G", "GBR", "1B", " GB", "GB\n" })
        {
            Reject(() => LegacyProfileChange.ForCountry(value));
        }

        LegacyProfileChange.ForCountry("gb");
        foreach (string value in new[] { "", " ", new string('a', 16), "name\n", "\ud800" })
        {
            Reject(() => new LegacyRenameRequest(value, false).Validate());
        }

        new LegacyRenameRequest(" Exact name ", true).Validate();
    }

    private static void CheckSourcePrices()
    {
        for (int count = 0; count <= 27; count++)
        {
            Require(LegacyRenamePolicy.TryCalculatePrice(count, 25, out int price) &&
                price == RecoveredProfileOracle.Price(count, 25), "Valid rename price differs from original Client.");
        }

        foreach (int count in new[] { -1, 28, 29, 30, 31, int.MaxValue })
        {
            Require(!LegacyRenamePolicy.TryCalculatePrice(count, 25, out _),
                "An overflowing or invalid source rename authorized payment.");
        }

        Reject(() => new LegacyRenamePolicy(-1));
    }

    private static void CheckSourceCallbacks()
    {
        Dictionary<string, object> response = new()
        {
            ["PayForRename"] = 1,
            ["RenameCount"] = 2,
            ["Name"] = " Exact name "
        };
        var result = RecoveredProfileOracle.Rename(response, 1);
        Require(result == (2, 25, " Exact name "), "Original rename callback lost exact name/count/paid price.");
        foreach (string key in response.Keys)
        {
            var incomplete = new Dictionary<string, object>(response);
            incomplete.Remove(key);
            ExpectMissing(() => RecoveredProfileOracle.Rename(incomplete, 1));
        }

        Require(RecoveredProfileOracle.Status(new() { ["Time"] = 123 }) == 123,
            "Original heartbeat callback did not consume mandatory Time.");
        ExpectMissing(() => RecoveredProfileOracle.Status(new()));
        RecoveredProfileOracle.ReadEmptyCallbacks();
        Dictionary<string, object> failure = new() { ["RenameCount"] = 2, ["PlayerGold"] = 75L };
        Require(RecoveredProfileOracle.RenameFailure(failure) == 75,
            "Original rename error handler did not restore authoritative PlayerGold.");
        foreach (string key in failure.Keys)
        {
            var incomplete = new Dictionary<string, object>(failure);
            incomplete.Remove(key);
            ExpectMissing(() => RecoveredProfileOracle.RenameFailure(incomplete));
        }
    }

    private static void CheckStoredProfile()
    {
        var player = new LegacyPlayerDocument { Name = "Recruit" };
        LegacyProfileValues.ValidateStored(player);
        Action<LegacyPlayerDocument>[] corrupt =
        [
            value => value.Name = null!, value => value.Name = "bad\n", value => value.Locale = "???",
            value => value.Country = "GBR", value => value.DeviceToken = "bad\n",
            value => value.Status = 3, value => value.LastAction = -1
        ];
        foreach (Action<LegacyPlayerDocument> damage in corrupt)
        {
            player = new LegacyPlayerDocument { Name = "Recruit" };
            damage(player);
            Reject(() => LegacyProfileValues.ValidateStored(player));
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

        throw new InvalidOperationException("Malformed profile identity was accepted.");
    }

    private static void ExpectMissing(Action action)
    {
        try
        {
            action();
        }
        catch (KeyNotFoundException)
        {
            return;
        }

        throw new InvalidOperationException("A mandatory recovered callback field was no longer read.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}

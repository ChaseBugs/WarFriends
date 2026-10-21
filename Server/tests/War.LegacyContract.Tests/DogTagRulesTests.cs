using War.Backend.Legacy.Accounts;
using War.Backend.Legacy.DogTags;
using War.Backend.Legacy.Time;
using War.Backend.Legacy;
using War.LegacyContract.Tests.Recovered;
using War.Persistence.Legacy.DogTags;
using War.Persistence;

namespace War.LegacyContract.Tests;

internal static class DogTagRulesTests
{
    private const int Now = 1_700_000_000;

    internal static int Run()
    {
        LegacyCatalog catalog = RecoveredCatalogFixture.Catalog;
        LegacyStarterPolicy starter = LegacyStarterPolicy.FromOptions(LegacyStarterState.FromCatalog(catalog));
        LegacyDogTagPolicy policy = LegacyDogTagPolicy.FromCatalog(catalog, starter)!;
        int checks = CompareRecoveredRules(policy);
        CheckInvalidAuthority(policy);
        CheckPolicy(catalog, starter);
        return checks + 2;
    }

    private static int CompareRecoveredRules(LegacyDogTagPolicy policy)
    {
        int checks = 0;
        foreach (int seconds in new[] { -1800, -900, -1, 0, 899, 900, 4499, 4500 })
        {
            foreach (int elapsed in new[] { 0, 1, 899, 900, 4500, 10000 })
            {
                foreach (int expiry in new[] { Now - 1, Now, Now + 1 })
                {
                    LegacyPlayerDocument player = Player();
                    player.DogTagSeconds = seconds;
                    player.DogTagLastUpdate = Now - elapsed;
                    player.Vip = expiry;
                    var expected = RecoveredDogTagOracle.Read(seconds, Now - elapsed, 4500, 900, 2, expiry, Now);
                    LegacyDogTagMutation refill = LegacyDogTagRules.Refill(player, policy, Now);
                    LegacyDogTagMutation penalty = LegacyDogTagRules.Pay(player, policy, Now);
                    Require(penalty.Seconds == expected.BaseAfterPenalty && penalty.Gold == player.Gold,
                        "Penalty debt/base-cap behavior differs from the unchanged Client method.");
                    Require(expected.Full ? refill.Outcome == LegacyDogTagOutcome.Unchanged :
                        refill.Outcome == LegacyDogTagOutcome.Applied && player.Gold - refill.Gold == expected.Price,
                        "Refill fullness/VIP price differs from unchanged Client getters.");
                    checks++;
                }
            }
        }

        return checks;
    }

    private static void CheckInvalidAuthority(LegacyDogTagPolicy policy)
    {
        foreach (Action<LegacyPlayerDocument> damage in new Action<LegacyPlayerDocument>[]
        {
            player => player.DogTagLastUpdate = -1,
            player => player.DogTagLastUpdate = Now + 1,
            player => player.DogTagMax = 0,
            player => player.DogTagMax = 4501,
            player => player.DogTagSeconds = 4501,
            player => player.Vip = -1,
            player => player.Gold = -1
        })
        {
            LegacyPlayerDocument player = Player();
            damage(player);
            Reject(() => LegacyDogTagRules.Refill(player, policy, Now));
            Reject(() => LegacyDogTagRules.Pay(player, policy, Now));
            Reject(() => LegacyDogTagRules.Project(player, Now, policy));
        }

        LegacyPlayerDocument debt = Player();
        debt.DogTagSeconds = int.MinValue;
        Reject(() => LegacyDogTagRules.Pay(debt, policy, Now));
        LegacyPlayerDocument old = Player();
        old.DogTagSeconds = 4500;
        old.DogTagLastUpdate = 0;
        Require(LegacyDogTagRules.Project(old, int.MaxValue).Seconds == 4500,
            "Int32 intermediate overflow erased a legitimately full pool.");
        Reject(() => LegacyClientTime.Read(-1));
        Reject(() => LegacyClientTime.Read((long)int.MaxValue + 1));
        Reject(() => LegacyClientTime.NextMidnight(int.MaxValue));
        Require(LegacyClientTime.NextMidnight(86_400) == 172_800, "UTC midnight derivation changed.");
        old.Gold = 0;
        old.DogTagSeconds = 0;
        old.DogTagLastUpdate = Now;
        Require(LegacyDogTagRules.Refill(old, policy, Now).Outcome == LegacyDogTagOutcome.NotEnoughGold,
            "An empty wallet authorized refill.");
    }

    private static void CheckPolicy(LegacyCatalog catalog, LegacyStarterPolicy starter)
    {
        Require(LegacyDogTagPolicy.FromCatalog(LegacyCatalog.Empty, starter) == null,
            "Missing source policy invented a mutation period.");
        Reject(() => LegacyDogTagPolicy.FromCatalog(catalog, starter with { DogTagMax = 10 }));
    }

    private static LegacyPlayerDocument Player() => new()
    {
        Gold = 100,
        DogTagMax = 4500,
        DogTagLastUpdate = Now
    };

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

        throw new InvalidOperationException("Invalid dog-tag authority was accepted.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}

using War.Backend.Legacy.Economy;

internal static class LegacyEconomyPricingTests
{
    internal static int Run()
    {
        int checks = 0;
        var renameCases = new[]
        {
            (Count: 0, Expected: 0),
            (Count: 1, Expected: 25),
            (Count: 27, Expected: 1_677_721_600)
        };
        foreach (var testCase in renameCases)
        {
            bool priced = LegacyEconomyPricing.TryCalculateRenamePrice(testCase.Count, 25, out int price);
            Require(priced && price == testCase.Expected, "Source-backed rename price differs.");
            checks++;
        }

        foreach (int count in new[] { -1, 28, 29, 30, 31, int.MaxValue })
        {
            bool priced = LegacyEconomyPricing.TryCalculateRenamePrice(count, 25, out int price);
            Require(!priced && price == 0, "Overflowing rename became an authorized price.");
            checks++;
        }

        Require(!LegacyEconomyPricing.TryCalculateRenamePrice(1, -25, out _), "Negative price policy accepted.");
        checks++;

        // Golden values from the active Client's MiscTools formula, including a double-only mismatch.
        var completionCases = new[]
        {
            (Seconds: 0L, Expected: 0),
            (Seconds: 1L, Expected: 1),
            (Seconds: 60L, Expected: 1),
            (Seconds: 324_478L, Expected: 761)
        };
        foreach (var testCase in completionCases)
        {
            int price = LegacyEconomyPricing.CalculateTimeCompletionGold(testCase.Seconds, 0.6325, -0.175);
            Require(price == testCase.Expected, "Instant completion differs from Client binary32 rounding.");
            checks++;
        }

        foreach (long seconds in new[] { -1L, (long)int.MaxValue + 1 })
        {
            Reject(() => LegacyEconomyPricing.CalculateTimeCompletionGold(seconds, 0.6325, -0.175));
            checks++;
        }

        foreach (double coefficient in new[] { -1, 0, double.NaN, double.PositiveInfinity, double.MaxValue })
        {
            Reject(() => LegacyEconomyPricing.CalculateTimeCompletionGold(60, coefficient, -0.175));
            checks++;
        }

        Reject(() => LegacyEconomyPricing.CalculateTimeCompletionGold(60, 0.6325, double.NaN));
        Reject(() => LegacyEconomyPricing.CalculateTimeCompletionGold(int.MaxValue, int.MaxValue, 10));
        return checks + 2;
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

        throw new InvalidOperationException("Invalid calculation input did not fail closed.");
    }
}

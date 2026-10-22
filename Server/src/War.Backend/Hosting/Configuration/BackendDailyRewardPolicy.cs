using System.Globalization;
using War.Persistence.Legacy.Progression;

namespace War.Backend.Hosting.Configuration;

public static class BackendDailyRewardPolicy
{
    public static DailyRewardPolicy Read(IConfiguration configuration)
    {
        // Explicit deployment fallback. No recovered production monthly table is available.
        return new DailyRewardPolicy(
            ReadAmount(configuration, "Legacy:DailyRewards:OrdinaryGold", 5),
            ReadAmount(configuration, "Legacy:DailyRewards:WeeklyGold", 25));
    }

    private static long ReadAmount(IConfiguration configuration, string key, long fallback)
    {
        string? value = configuration[key];
        if (value == null)
        {
            return fallback;
        }
        if (!long.TryParse(value, NumberStyles.None, CultureInfo.InvariantCulture, out long amount) ||
            amount < 0 || value != amount.ToString(CultureInfo.InvariantCulture))
        {
            throw new InvalidDataException($"{key} must be a canonical nonnegative Int64.");
        }
        return amount;
    }
}

namespace War.Persistence.Legacy.Progression;

/// <summary>Explicit offline deployment policy; the production calendar was not recovered.</summary>
public sealed class DailyRewardPolicy
{
    public const long MaximumGold = 9_007_199_254_740_991;

    public DailyRewardPolicy(long ordinaryGold, long weeklyGold)
    {
        if (ordinaryGold < 0 || weeklyGold < ordinaryGold || weeklyGold > MaximumGold)
        {
            throw new InvalidDataException("Daily Gold must be nonnegative and weekly Gold no lower than ordinary.");
        }
        OrdinaryGold = ordinaryGold;
        WeeklyGold = weeklyGold;
    }

    public long OrdinaryGold { get; }
    public long WeeklyGold { get; }

    public DailyRewardCalendar Open(DateTimeOffset now)
    {
        return new DailyRewardCalendar
        {
            Year = now.Year,
            Month = now.Month,
            LastCheckDay = now.Day,
            CanClaim = 1,
            OrdinaryGold = OrdinaryGold,
            WeeklyGold = WeeklyGold
        };
    }
}

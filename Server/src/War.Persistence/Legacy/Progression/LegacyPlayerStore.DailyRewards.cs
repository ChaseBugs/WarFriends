using MongoDB.Driver;
using War.Persistence.Legacy.Accounts;
using War.Persistence.Legacy.Progression;
using War.Persistence.Legacy.State;

namespace War.Persistence;

public sealed partial class LegacyPlayerStore
{
    public async Task<DailyRewardCommit> ApplyDailyRewardAsync(
        LegacyPlayerDocument authenticated,
        DailyRewardOperation operation,
        DailyRewardPolicy policy,
        CancellationToken cancellationToken)
    {
        operation.Validate();
        const int MaximumAttempts = 8;
        for (int attempt = 0; attempt < MaximumAttempts; attempt++)
        {
            LegacyPlayerDocument current = await ById(authenticated.Id, cancellationToken, operation.Time)
                ?? throw new InvalidDataException("Daily reward account disappeared.");
            ValidateDailyRewardSession(current, authenticated, operation.Time);
            DailyRewardCommit commit = ApplyDailyReward(current, operation, policy);
            LegacyPlayerEconomyAuthority.Validate(current, operation.Time);
            long revision = current.Revision;
            current.Revision = checked(revision + 1);
            ReplaceOneResult result = await players.ReplaceOneAsync(
                player => player.Id == current.Id && player.Revision == revision &&
                    player.SessionHash == authenticated.SessionHash,
                current, cancellationToken: cancellationToken);
            if (result.ModifiedCount == 1)
            {
                return commit;
            }
        }
        throw new InvalidDataException("Daily reward publication conflicted repeatedly.");
    }

    private static DailyRewardCommit ApplyDailyReward(
        LegacyPlayerDocument current, DailyRewardOperation operation, DailyRewardPolicy policy)
    {
        DailyRewardCalendar? calendar = current.DailyRewards;
        if (calendar == null || calendar.IsExpired(operation.Time))
        {
            calendar = policy.Open(operation.Time);
        }
        calendar.Validate(operation.Time);
        if (calendar.LastCheckDay != operation.Time.Day)
        {
            // One attendance credit per visited UTC day; missed days are not backfilled.
            calendar.LastCheckDay = operation.Time.Day;
            calendar.CanClaim++;
        }
        current.DailyRewards = calendar;
        if (!operation.Day.HasValue)
        {
            return new DailyRewardCommit(current, 0, false);
        }
        int day = operation.Day.Value;
        if (day <= calendar.Claimed)
        {
            return new DailyRewardCommit(current, 0, true);
        }
        if (day != calendar.Claimed + 1 || day > calendar.CanClaim)
        {
            throw new InvalidDataException("Daily reward has not been earned in order.");
        }
        long gold = calendar.GoldForDay(day);
        current.Gold = RewardBalance.Add(current.Gold, gold);
        calendar.Claimed = day;
        calendar.Validate(operation.Time);
        return new DailyRewardCommit(current, gold, false);
    }

    private static void ValidateDailyRewardSession(
        LegacyPlayerDocument current, LegacyPlayerDocument authenticated, DateTimeOffset now)
    {
        LegacySessionAuthority.ValidateStored(current, now.UtcDateTime);
        if (current.SessionHash != authenticated.SessionHash || current.SessionExpiresUtc <= now.UtcDateTime)
        {
            throw new InvalidDataException("Daily reward session expired.");
        }
    }
}

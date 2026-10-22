using System.Globalization;
using System.Text.Json.Nodes;
using War.Persistence;
using War.Persistence.Legacy.Progression;

namespace War.Backend.Legacy.Progression;

/// <summary>Recovered actions 1001/1002, including the original claimRweard spelling.</summary>
public sealed class LegacyDailyRewardEndpoint
{
    private readonly LegacyPlayerStore _players;
    private readonly DailyRewardPolicy _policy;
    private readonly TimeProvider _clock;

    public LegacyDailyRewardEndpoint(LegacyPlayerStore players, DailyRewardPolicy policy, TimeProvider? clock = null)
    {
        _players = players;
        _policy = policy;
        _clock = clock ?? TimeProvider.System;
    }

    public async Task<IResult> ExecuteAsync(
        LegacyRequest request, LegacyPlayerDocument authenticated, CancellationToken cancellationToken)
    {
        DateTimeOffset now = _clock.GetUtcNow();
        bool isClaim = request.Action == DatabaseAction.ClaimDailyReward;
        int? day = isClaim ? ParseDay(request) : null;
        if (isClaim && !day.HasValue)
        {
            return LegacyResponse.Failure(DatabaseResult.TryClaimWrongRewad);
        }
        try
        {
            var operation = new DailyRewardOperation(now, request.SingleField("CalendarId"), day);
            DailyRewardCommit commit = await _players.ApplyDailyRewardAsync(
                authenticated, operation, _policy, cancellationToken);
            JsonObject calendar = Project(commit.Player.DailyRewards!, now);
            if (isClaim)
            {
                // The recovered parser adds a delta. Replays must not repeat that delta.
                calendar["ok"] = (int)DatabaseResult.Success;
                calendar["addedType"] = 1; // DailyReward.Gold in the active 1.4.0 Client.
                calendar["added"] = commit.AddedGold;
            }
            return LegacyResponse.Json(DatabaseResult.Success, new JsonObject
            {
                ["dailyRewardData"] = calendar,
                ["Time"] = now.ToUnixTimeSeconds(),
                ["DailyRewardWallet"] = new JsonObject
                {
                    ["Gold"] = commit.Player.Gold,
                    ["WarBucks"] = commit.Player.WarBucks
                }
            });
        }
        catch (InvalidDataException)
        {
            return LegacyResponse.Failure(DatabaseResult.ServerMaintenance);
        }
        catch (OverflowException)
        {
            return LegacyResponse.Failure(DatabaseResult.ServerMaintenance);
        }
    }

    public static int? ParseDay(LegacyRequest request)
    {
        if (request.HasField("claimRweard") == request.HasField("claimReward"))
        {
            return null;
        }
        string? value = request.SingleField(request.HasField("claimRweard") ? "claimRweard" : "claimReward");
        if (!int.TryParse(value, NumberStyles.None, CultureInfo.InvariantCulture, out int day) ||
            day is < 1 or > 31 || value != day.ToString(CultureInfo.InvariantCulture))
        {
            return null;
        }
        return day;
    }

    private static JsonObject Project(DailyRewardCalendar calendar, DateTimeOffset now)
    {
        calendar.Validate(now);
        var config = new JsonObject();
        int days = DateTime.DaysInMonth(calendar.Year, calendar.Month);
        for (int day = 1; day <= days; day++)
        {
            config["Day" + day.ToString(CultureInfo.InvariantCulture)] = new JsonObject
            {
                ["Type"] = 1, ["Double"] = 0, ["Count"] = calendar.GoldForDay(day), ["Param"] = ""
            };
        }
        return new JsonObject
        {
            ["year"] = calendar.Year,
            ["month"] = calendar.Month,
            ["canClaim"] = calendar.CanClaim,
            ["claimReward"] = calendar.Claimed,
            ["nextDay"] = new DateTimeOffset(now.UtcDateTime.Date.AddDays(1)).ToUnixTimeSeconds() - now.ToUnixTimeSeconds(),
            ["config"] = config
        };
    }
}

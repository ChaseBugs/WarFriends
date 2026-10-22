namespace War.Backend.Legacy.Progression;

/// <summary>Answers the automatic lobby probe while the offline reward calendar is unavailable.</summary>
public static class LegacyDailyRewardAvailabilityEndpoint
{
    public static IResult Read()
    {
        // The recovered CheckDailyReward callback explicitly permits no dailyRewardData.
        // Omitting it offers no calendar or claim, unlike a fabricated empty reward table.
        // 503 means global maintenance to this Client and would terminate a valid session.
        return LegacyResponse.Json(DatabaseResult.Success, new System.Text.Json.Nodes.JsonObject());
    }
}

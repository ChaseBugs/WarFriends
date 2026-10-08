namespace War.BattleServer;

internal sealed record CoopMissionSuccessScore(int Score, int Stars);

/// <summary>
/// Mission.computedGainedSuccesScore and GetStars from the recovered Client.
/// The caller must supply a host-confirmed successful mission and player HP.
/// This calculation never grants currency or progression by itself.
/// </summary>
internal static class CoopMissionScorePolicy
{
    internal static CoopMissionSuccessScore Calculate(
        MissionRule mission, float healthRatio, float remainingTimeRatio)
    {
        ArgumentNullException.ThrowIfNull(mission);
        if (!float.IsFinite(healthRatio) || healthRatio is < 0 or > 1 ||
            !float.IsFinite(remainingTimeRatio) ||
            remainingTimeRatio is < 0 or > 1 ||
            mission.HealthTargetFraction <= 0 ||
            mission.TimeTargetFraction <= 0 ||
            mission.ScoreOneStar > mission.ScoreTwoStars ||
            mission.ScoreTwoStars > mission.ScoreThreeStars)
            throw new InvalidDataException("Invalid co-op mission score inputs.");

        int score = mission.MissionType switch
        {
            "KillXEnemies" or "SurviveXSeconds" =>
                ScoreWithHealthOnly(mission, healthRatio),
            "Score" or "KillOpponent" =>
                ScoreWithHealthAndTime(mission, healthRatio,
                    remainingTimeRatio),
            _ => throw new InvalidDataException("Unknown co-op score rule.")
        };
        int stars = 0;
        if (score >= mission.ScoreOneStar) stars = 1;
        if (score >= mission.ScoreTwoStars) stars = 2;
        if (score >= mission.ScoreThreeStars) stars = 3;
        return new CoopMissionSuccessScore(score, stars);
    }

    private static int ScoreWithHealthOnly(
        MissionRule mission, float healthRatio)
    {
        float healthPoints = healthRatio / mission.HealthTargetFraction *
            (mission.ScoreThreeStars - mission.ScoreOneStar);
        return checked(mission.ScoreOneStar + RoundLikeClient(healthPoints));
    }

    private static int ScoreWithHealthAndTime(
        MissionRule mission, float healthRatio, float remainingTimeRatio)
    {
        float healthProgress = healthRatio / mission.HealthTargetFraction;
        float timeProgress = remainingTimeRatio / mission.TimeTargetFraction;
        // The Client only clamps both bonuses when either target is missed.
        if (healthRatio < mission.HealthTargetFraction ||
            remainingTimeRatio < mission.TimeTargetFraction)
        {
            healthProgress = Math.Clamp(healthProgress, 0f, 1f);
            timeProgress = Math.Clamp(timeProgress, 0f, 1f);
        }
        int healthBonus = RoundLikeClient(healthProgress *
            (mission.ScoreTwoStars - mission.ScoreOneStar));
        int timeBonus = RoundLikeClient(timeProgress *
            (mission.ScoreThreeStars - mission.ScoreTwoStars));
        return checked(mission.ScoreOneStar + healthBonus + timeBonus);
    }

    // MiscTools.RoundToInt uses Mathf.FloorToInt(value + 0.5f).
    private static int RoundLikeClient(float value)
    {
        if (!float.IsFinite(value) || value < 0 || value > int.MaxValue - 1)
            throw new InvalidDataException("Co-op score bonus overflow.");
        return checked((int)MathF.Floor(value + 0.5f));
    }
}

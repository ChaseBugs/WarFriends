namespace War.BattleServer;

public readonly record struct MissionScoreResult(int Score, int Stars);

/// <summary>
/// Source Mission.computedGainedSuccesScore and GetStars, using only host-confirmed
/// health and elapsed match time. This calculates a result; it does not grant a reward.
/// </summary>
public static class MissionScoreCalculator
{
    public static MissionScoreResult Calculate(
        MissionRule rule, float playerHealthFraction, float elapsedTimeFraction)
    {
        ArgumentNullException.ThrowIfNull(rule);
        ValidateFraction(playerHealthFraction, nameof(playerHealthFraction));
        ValidateFraction(elapsedTimeFraction, nameof(elapsedTimeFraction));

        int score = rule.MissionType is "KillXEnemies" or "SurviveXSeconds"
            ? ScoreFromHealth(rule, playerHealthFraction)
            : ScoreFromHealthAndTime(rule, playerHealthFraction, elapsedTimeFraction);
        int stars = StarsForScore(rule, score);
        return new MissionScoreResult(score, stars);
    }

    private static int ScoreFromHealth(MissionRule rule, float health)
    {
        float bonus = health / rule.HealthTargetFraction *
            (rule.ScoreThreeStars - rule.ScoreOneStar);
        return checked(rule.ScoreOneStar + RoundLikeClient(bonus));
    }

    private static int ScoreFromHealthAndTime(MissionRule rule, float health, float time)
    {
        float healthRatio = health / rule.HealthTargetFraction;
        float timeRatio = time / rule.TimeTargetFraction;
        if (healthRatio < 1 || timeRatio < 1)
        {
            healthRatio = Math.Clamp(healthRatio, 0, 1);
            timeRatio = Math.Clamp(timeRatio, 0, 1);
        }

        int healthBonus = RoundLikeClient(healthRatio *
            (rule.ScoreTwoStars - rule.ScoreOneStar));
        int timeBonus = RoundLikeClient(timeRatio *
            (rule.ScoreThreeStars - rule.ScoreTwoStars));
        return checked(rule.ScoreOneStar + healthBonus + timeBonus);
    }

    private static int StarsForScore(MissionRule rule, int score)
    {
        if (score >= rule.ScoreThreeStars) return 3;
        if (score >= rule.ScoreTwoStars) return 2;
        if (score >= rule.ScoreOneStar) return 1;
        return 0;
    }

    private static int RoundLikeClient(float value)
    {
        // MiscTools.RoundToInt calls Mathf.FloorToInt(value + 0.5f).
        if (!float.IsFinite(value) || value < 0 || value > int.MaxValue - 1)
            throw new InvalidDataException("Mission score bonus is outside the client integer range.");
        return checked((int)MathF.Floor(value + 0.5f));
    }

    private static void ValidateFraction(float value, string name)
    {
        if (!float.IsFinite(value) || value < 0 || value > 1)
            throw new ArgumentOutOfRangeException(name);
    }
}

namespace War.Persistence.Legacy.Progression;

public sealed record DailyRewardOperation(DateTimeOffset Time, string? CalendarId = null, int? Day = null)
{
    public void Validate()
    {
        if (Time.Offset != TimeSpan.Zero || Time.ToUnixTimeSeconds() is < 0 or > int.MaxValue ||
            Day is < 1 or > 31 ||
            (Day.HasValue && CalendarId != Time.ToString("yyyy-MM", System.Globalization.CultureInfo.InvariantCulture)))
        {
            throw new InvalidDataException("Invalid or expired daily reward operation.");
        }
    }
}

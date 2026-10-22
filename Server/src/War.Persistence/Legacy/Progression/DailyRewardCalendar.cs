using MongoDB.Bson.Serialization.Attributes;
using War.Persistence.Legacy.State;

namespace War.Persistence.Legacy.Progression;

/// <summary>One UTC attendance calendar. Reward prices are frozen when the month is opened.</summary>
public sealed class DailyRewardCalendar
{
    [BsonRequired, BsonSerializer(typeof(LegacyInt32Serializer))] public int Year { get; set; }
    [BsonRequired, BsonSerializer(typeof(LegacyInt32Serializer))] public int Month { get; set; }
    [BsonRequired, BsonSerializer(typeof(LegacyInt32Serializer))] public int LastCheckDay { get; set; }
    [BsonRequired, BsonSerializer(typeof(LegacyInt32Serializer))] public int CanClaim { get; set; }
    [BsonRequired, BsonSerializer(typeof(LegacyInt32Serializer))] public int Claimed { get; set; }
    [BsonRequired, BsonSerializer(typeof(LegacyInt64Serializer))] public long OrdinaryGold { get; set; }
    [BsonRequired, BsonSerializer(typeof(LegacyInt64Serializer))] public long WeeklyGold { get; set; }

    public string Identity => $"{Year:D4}-{Month:D2}";

    public bool IsExpired(DateTimeOffset now)
    {
        ValidateCoordinates();
        if (Year > now.Year || Year == now.Year && Month > now.Month)
        {
            throw new InvalidDataException("Daily reward calendar belongs to a future month.");
        }
        return Year < now.Year || Month < now.Month;
    }

    public void Validate(DateTimeOffset now)
    {
        // An expired calendar carries no claim authority into the next month.
        if (IsExpired(now))
        {
            return;
        }
        int days = DateTime.DaysInMonth(Year, Month);
        if (LastCheckDay < 1 || LastCheckDay > now.Day || CanClaim < 1 || CanClaim > LastCheckDay ||
            Claimed < 0 || Claimed > CanClaim || CanClaim > days ||
            OrdinaryGold < 0 || WeeklyGold < OrdinaryGold || WeeklyGold > DailyRewardPolicy.MaximumGold)
        {
            throw new InvalidDataException("Invalid daily reward calendar authority.");
        }
    }

    public long GoldForDay(int day)
    {
        if (day < 1 || day > DateTime.DaysInMonth(Year, Month))
        {
            throw new InvalidDataException("Daily reward index is outside this calendar.");
        }
        const int DaysPerWeek = 7;
        return day % DaysPerWeek == 0 ? WeeklyGold : OrdinaryGold;
    }

    private void ValidateCoordinates()
    {
        if (Year is < 1970 or > 9999 || Month is < 1 or > 12)
        {
            throw new InvalidDataException("Invalid daily reward calendar coordinates.");
        }
    }
}

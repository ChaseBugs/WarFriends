namespace War.Backend.Legacy.Time;

/// <summary>Validates exact nonnegative Unix seconds before using recovered signed-Int32 wire clocks.</summary>
public static class LegacyClientTime
{
    private const int SecondsPerDay = 86_400;

    /// <summary>Rejects unsupported Unix time before narrowing it to the recovered Client field.</summary>
    public static int Read(long seconds)
    {
        if (seconds is < 0 or > int.MaxValue)
        {
            throw new InvalidDataException("Application time exceeds the recovered Client timestamp domain.");
        }

        return (int)seconds;
    }

    /// <summary>Derives UTC midnight from the supplied clock, rejecting client-width deadline overflow.</summary>
    public static int NextMidnight(int now)
    {
        Read(now);
        return Read(((long)now / SecondsPerDay + 1) * SecondsPerDay);
    }
}

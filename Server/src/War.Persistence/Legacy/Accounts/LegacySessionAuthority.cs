using System.Text.RegularExpressions;

namespace War.Persistence.Legacy.Accounts;

/// <summary>Validates session material and date arithmetic without repairing historical damaged rows.</summary>
public static class LegacySessionAuthority
{
    /// <summary>Calculates one exact positive-hour expiry or rejects unsupported date arithmetic.</summary>
    public static DateTime Expiry(DateTime nowUtc, int lifetimeHours)
    {
        if (nowUtc.Kind != DateTimeKind.Utc || nowUtc < DateTime.UnixEpoch || lifetimeHours <= 0)
        {
            throw new InvalidDataException("Invalid legacy session lifetime or application time.");
        }

        try
        {
            long ticks = checked((long)lifetimeHours * TimeSpan.TicksPerHour);
            return nowUtc.AddTicks(ticks);
        }
        catch (Exception exception) when (exception is OverflowException or ArgumentOutOfRangeException)
        {
            throw new InvalidDataException("Legacy session expiry exceeds the supported date range.", exception);
        }
    }

    /// <summary>Rejects malformed or future-born sessions while allowing a valid expired session to renew.</summary>
    public static void ValidateStored(LegacyPlayerDocument player, DateTime nowUtc)
    {
        if (player.SessionHash == null || !Regex.IsMatch(player.SessionHash, "\\A[A-F0-9]{64}\\z") ||
            player.CreatedUtc < DateTime.UnixEpoch || player.CreatedUtc > nowUtc ||
            player.SessionExpiresUtc <= player.CreatedUtc || player.Revision < 1 || player.Revision == long.MaxValue)
        {
            throw new InvalidDataException("Invalid persisted legacy session authority.");
        }
    }
}

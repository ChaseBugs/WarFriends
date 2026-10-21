namespace War.Persistence.Legacy.Accounts;

/// <summary>Preserves validated registration metadata; UTC offset is diagnostic and never calendar authority.</summary>
public sealed record LegacyAccountRegistration
{
    public const int MaximumDeviceTokenLength = 4096;
    public const int MaximumPlatformIdLength = 256;
    public const double MaximumUtcOffsetHours = 24;

    public required string Locale { get; init; }

    public required double UtcOffsetHours { get; init; }

    public string? DeviceToken { get; init; }

    public string? GameCenterId { get; init; }

    /// <summary>Revalidates raw strings without trimming or converting an opaque identity.</summary>
    public void Validate()
    {
        if (Locale == null || !AccountStore.ValidLocale(Locale) || !double.IsFinite(UtcOffsetHours) ||
            Math.Abs(UtcOffsetHours) > MaximumUtcOffsetHours ||
            DeviceToken != null && !IsValidDeviceToken(DeviceToken) ||
            GameCenterId != null && !IsOpaqueValue(GameCenterId, MaximumPlatformIdLength))
        {
            throw new InvalidDataException("Invalid legacy account registration metadata.");
        }
    }

    /// <summary>Validates a provided opaque token without trimming or normalizing it.</summary>
    public static bool IsValidDeviceToken(string? value) =>
        value != null && IsOpaqueValue(value, MaximumDeviceTokenLength);

    private static bool IsOpaqueValue(string value, int maximumLength)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length > maximumLength)
        {
            return false;
        }

        for (int i = 0; i < value.Length; i++)
        {
            if (char.IsControl(value[i]) || char.IsLowSurrogate(value[i]))
            {
                return false;
            }

            if (char.IsHighSurrogate(value[i]))
            {
                if (i + 1 >= value.Length || !char.IsLowSurrogate(value[i + 1]))
                {
                    return false;
                }

                i++;
            }
        }

        return true;
    }
}

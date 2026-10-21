using War.Persistence.Legacy.Accounts;

namespace War.Persistence.Legacy.Profile;

/// <summary>Immutable, validated replacement for one source-supported profile field or tuple.</summary>
public sealed class LegacyProfileChange
{
    private LegacyProfileChange(LegacyProfileChangeKind kind)
    {
        Kind = kind;
    }

    public LegacyProfileChangeKind Kind { get; }

    internal int Status { get; private init; }

    internal string? DeviceToken { get; private init; }

    internal string? Locale { get; private init; }

    internal string? Country { get; private init; }

    /// <summary>Creates one exact Offline/Online/InGame status replacement.</summary>
    public static LegacyProfileChange ForStatus(int status)
    {
        if (status is < 0 or > 2)
        {
            throw new InvalidDataException("Invalid legacy player status.");
        }

        return new(LegacyProfileChangeKind.Status) { Status = status };
    }

    /// <summary>Preserves a validated device-token/locale tuple byte-for-byte.</summary>
    public static LegacyProfileChange ForDeviceRegistration(string? deviceToken, string? locale)
    {
        if (!LegacyAccountRegistration.IsValidDeviceToken(deviceToken) ||
            locale == null || !AccountStore.ValidLocale(locale))
        {
            throw new InvalidDataException("Invalid legacy device registration tuple.");
        }

        return new(LegacyProfileChangeKind.DeviceRegistration) { DeviceToken = deviceToken, Locale = locale };
    }

    /// <summary>Preserves a validated recovered locale identity.</summary>
    public static LegacyProfileChange ForLanguage(string? locale)
    {
        if (locale == null || !AccountStore.ValidLocale(locale))
        {
            throw new InvalidDataException("Invalid legacy profile locale.");
        }

        return new(LegacyProfileChangeKind.Language) { Locale = locale };
    }

    /// <summary>Canonicalizes the existing two-letter country contract once, after validation.</summary>
    public static LegacyProfileChange ForCountry(string? country)
    {
        if (!LegacyProfileValues.IsCountry(country))
        {
            throw new InvalidDataException("Invalid legacy profile country.");
        }

        return new(LegacyProfileChangeKind.Country) { Country = country!.ToUpperInvariant() };
    }
}

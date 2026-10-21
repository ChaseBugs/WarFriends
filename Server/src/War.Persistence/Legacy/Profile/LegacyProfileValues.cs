using War.Persistence.Legacy.Accounts;
using War.Persistence.Legacy.Preferences;

namespace War.Persistence.Legacy.Profile;

/// <summary>Checks exact profile identities without trimming opaque tokens or player names.</summary>
public static class LegacyProfileValues
{
    public const int MaximumNameLength = 15;

    /// <summary>Matches the existing Client display-name boundary and rejects malformed UTF-16.</summary>
    public static bool IsName(string? value) =>
        value != null && value.Length <= MaximumNameLength && LegacyAccountRegistration.IsValidDeviceToken(value);

    /// <summary>Accepts exactly two ASCII letters before canonical country publication.</summary>
    public static bool IsCountry(string? value) => value is { Length: 2 } &&
        value.All(character => character is >= 'A' and <= 'Z' or >= 'a' and <= 'z');

    /// <summary>Validates the stored profile before replacing any of its known fields.</summary>
    public static void ValidateStored(LegacyPlayerDocument player)
    {
        if (!IsName(player.Name) || player.Locale == null || !AccountStore.ValidLocale(player.Locale) ||
            player.Country == null || player.Country.Length != 0 && !IsCountry(player.Country) ||
            player.DeviceToken == null || player.DeviceToken.Length != 0 &&
                !LegacyAccountRegistration.IsValidDeviceToken(player.DeviceToken) ||
            player.Status is < 0 or > 2 || player.LastAction < 0)
        {
            throw new InvalidDataException("Invalid stored legacy profile authority.");
        }

        LegacySettingsSnapshot.ValidateContainer(player.Serialized);
    }
}

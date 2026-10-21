using System.Globalization;
using War.Persistence.Legacy.Accounts;

namespace War.Backend.Legacy.Accounts;

/// <summary>Parses recovered registration fields without treating client starting balances as authority.</summary>
public static class LegacyAccountParser
{
    private const int MaximumOffsetTextLength = 128;

    public static LegacyAccountRegistration Parse(LegacyRequest request)
    {
        string locale = Required(request, "Locale");
        string text = Required(request, "UtcOffset");
        if (text.Length > MaximumOffsetTextLength || char.IsWhiteSpace(text[0]) ||
            char.IsWhiteSpace(text[^1]) || !double.TryParse(text, NumberStyles.Float,
                CultureInfo.InvariantCulture, out double offset))
        {
            throw new InvalidDataException("Invalid invariant UTC-offset diagnostic.");
        }

        var registration = new LegacyAccountRegistration
        {
            Locale = locale,
            UtcOffsetHours = offset,
            DeviceToken = Optional(request, "DeviceToken"),
            GameCenterId = Optional(request, "GameCenterId")
        };
        registration.Validate();
        if (request.Action == DatabaseAction.CreateGcAccount && registration.GameCenterId == null)
        {
            throw new InvalidDataException("Missing Game Center identity.");
        }

        return registration;
    }

    private static string Required(LegacyRequest request, string field) =>
        request.SingleField(field) ?? throw new InvalidDataException("Missing registration field: " + field);

    private static string? Optional(LegacyRequest request, string field) =>
        request.HasField(field) ? Required(request, field) : null;
}

using System.Globalization;

namespace War.Infrastructure;

/// <summary>Missing settings use explicit defaults; supplied malformed values never do.</summary>
public static class DeploymentValueParser
{
    public static int ReadInt32(string? value, string setting, int defaultValue)
    {
        if (value == null)
        {
            return defaultValue;
        }
        if (!int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out int parsed))
        {
            throw new InvalidDataException(setting + " must be an Int32 integer.");
        }
        return parsed;
    }

    public static bool ReadBoolean(string? value, string setting, bool defaultValue)
    {
        if (value == null)
        {
            return defaultValue;
        }
        if (!bool.TryParse(value, out bool parsed))
        {
            throw new InvalidDataException(setting + " must be true or false.");
        }
        return parsed;
    }
}

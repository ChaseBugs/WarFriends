using System.Globalization;

namespace War.Backend.Legacy.Catalog;

/// <summary>Reads exact integral JSON numbers without truncation, underflow or floating-point rounding.</summary>
internal static class LegacyCatalogInteger
{
    private const int MaximumNumberTextLength = 128;
    private const int MaximumMagnitudeDigits = 19;
    private const ulong NegativeInt64Magnitude = 9_223_372_036_854_775_808;

    internal static long Read(string text)
    {
        if (text.Length is < 1 or > MaximumNumberTextLength)
        {
            throw new InvalidDataException("Catalog integer text exceeds its bound.");
        }

        bool isNegative = text[0] == '-';
        string unsigned = isNegative ? text[1..] : text;
        string[] parts = unsigned.Split(['e', 'E']);
        int exponent = 0;
        if (parts.Length > 2 || parts.Length == 2 && !int.TryParse(parts[1], NumberStyles.AllowLeadingSign,
                CultureInfo.InvariantCulture, out exponent))
        {
            throw new InvalidDataException("Invalid catalog integer exponent.");
        }

        int point = parts[0].IndexOf('.');
        long scale = (long)exponent - (point < 0 ? 0 : parts[0].Length - point - 1);
        string digits = parts[0].Replace(".", "").TrimStart('0');
        ulong magnitude = ReadMagnitude(digits, scale);
        if (isNegative && magnitude <= NegativeInt64Magnitude)
        {
            return magnitude == NegativeInt64Magnitude ? long.MinValue : -(long)magnitude;
        }

        if (!isNegative && magnitude <= long.MaxValue)
        {
            return (long)magnitude;
        }

        throw new InvalidDataException("Catalog integer exceeds Int64.");
    }

    private static ulong ReadMagnitude(string digits, long scale)
    {
        if (digits.Length == 0)
        {
            return 0;
        }

        if (scale < 0)
        {
            long fractionalDigits = -scale;
            if (fractionalDigits >= digits.Length ||
                digits.AsSpan(digits.Length - (int)fractionalDigits).ContainsAnyExcept('0'))
            {
                throw new InvalidDataException("Fractional catalog integer.");
            }

            digits = digits[..(digits.Length - (int)fractionalDigits)];
            scale = 0;
        }

        if (digits.Length + scale > MaximumMagnitudeDigits ||
            !ulong.TryParse(digits + new string('0', (int)scale), NumberStyles.None,
                CultureInfo.InvariantCulture, out ulong result))
        {
            throw new InvalidDataException("Catalog integer magnitude exceeds its bound.");
        }

        return result;
    }
}

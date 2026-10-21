using War.Persistence.Legacy.Profile;

namespace War.Backend.Legacy.Economy;

/// <summary>Checked prices preserving the active 1.4.0 Client's numeric contract.</summary>
public static class LegacyEconomyPricing
{
    /// <summary>Returns false when a rename cannot be priced in the recovered signed Int32 field.</summary>
    public static bool TryCalculateRenamePrice(int renameCount, int basePrice, out int price) =>
        LegacyRenamePolicy.TryCalculatePrice(renameCount, basePrice, out price);

    /// <summary>Calculates MiscTools.ConvertTimeIntoGold with its original binary32 intermediates.</summary>
    public static int CalculateTimeCompletionGold(long seconds, double coefficient, double exponent)
    {
        float sourceCoefficient = (float)coefficient;
        float sourceExponent = (float)exponent;
        if (seconds is < 0 or > int.MaxValue || !double.IsFinite(coefficient) ||
            !double.IsFinite(exponent) || !float.IsFinite(sourceCoefficient) ||
            !float.IsFinite(sourceExponent) || sourceCoefficient <= 0)
        {
            throw new InvalidDataException("Invalid instant-completion price inputs.");
        }

        if (seconds == 0)
        {
            return 0;
        }

        // The Client stores minutes and constants as float before promoting them for Pow.
        // Double-only arithmetic changes the ceiling at legitimate delivery-time boundaries.
        float minutes = (float)seconds / 60f;
        double roundedPrice = Math.Ceiling(
            (double)sourceCoefficient * Math.Pow(minutes, sourceExponent) * (double)minutes);
        if (!double.IsFinite(roundedPrice) || roundedPrice < 0 || roundedPrice > int.MaxValue)
        {
            throw new InvalidDataException("Instant-completion price exceeds the Client's Int32 field.");
        }

        return Convert.ToInt32(roundedPrice);
    }
}

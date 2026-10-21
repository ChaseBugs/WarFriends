namespace War.Persistence.Legacy.Profile;

/// <summary>Immutable server-owned catalog price; missing catalog permits only the first free rename.</summary>
public sealed class LegacyRenamePolicy
{
    public LegacyRenamePolicy(int? secondRenameGoldCost)
    {
        if (secondRenameGoldCost < 0)
        {
            throw new InvalidDataException("Invalid legacy rename price policy.");
        }

        SecondRenameGoldCost = secondRenameGoldCost;
    }

    public int? SecondRenameGoldCost { get; }

    /// <summary>Checks the recovered doubling formula before a Client-width price can authorize payment.</summary>
    public static bool TryCalculatePrice(int renameCount, int basePrice, out int price)
    {
        price = 0;
        if (renameCount is < 0 or > 31 || basePrice < 0)
        {
            return false;
        }

        if (renameCount == 0)
        {
            return true;
        }

        long calculated = (1L << (renameCount - 1)) * basePrice;
        if (calculated > int.MaxValue)
        {
            return false;
        }

        price = (int)calculated;
        return true;
    }
}

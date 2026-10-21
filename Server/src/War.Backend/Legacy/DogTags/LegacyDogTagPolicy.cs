using War.Backend.Legacy.Accounts;

namespace War.Backend.Legacy.DogTags;

/// <summary>One immutable source-derived capacity, period and VIP bonus resolved before traffic.</summary>
public sealed record LegacyDogTagPolicy
{
    private const int BaseRefillGold = 35;
    private const int GoldDiscountPerTag = 2;

    private LegacyDogTagPolicy(int refillSeconds, int maximumSeconds, int vipBonusSeconds)
    {
        RefillSeconds = refillSeconds;
        MaximumSeconds = maximumSeconds;
        VipBonusSeconds = vipBonusSeconds;
    }

    public int RefillSeconds { get; }
    public int MaximumSeconds { get; }
    public int VipBonusSeconds { get; }

    /// <summary>Checks source/starter agreement, or returns no mutation policy for catalog-free mode.</summary>
    public static LegacyDogTagPolicy? FromCatalog(LegacyCatalog catalog, LegacyStarterPolicy starter)
    {
        if (!catalog.IsLoaded)
        {
            return null;
        }

        int period = catalog.ConstantInt("DogTagRefillTime") ?? 0;
        int capacity = catalog.ConstantInt("DogTagCap") ?? 0;
        int vipCount = catalog.ConstantInt("VipDogtags") ?? -1;
        long maximum = (long)period * capacity;
        long bonus = (long)period * vipCount;
        if (period <= 0 || capacity <= 0 || vipCount < 0 || maximum != starter.DogTagMax ||
            maximum + bonus > int.MaxValue ||
            BaseRefillGold - GoldDiscountPerTag * ((long)capacity + vipCount - 1) < 0)
        {
            throw new InvalidDataException("Invalid source/starter dog-tag capacity or refill policy.");
        }

        return new LegacyDogTagPolicy(period, (int)maximum, (int)bonus);
    }

    /// <summary>Reproduces the source price from the complete available tag count.</summary>
    public long RefillPrice(int currentDogTags) => BaseRefillGold - (long)GoldDiscountPerTag * currentDogTags;
}

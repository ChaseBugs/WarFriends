namespace War.Persistence.Legacy.State;

/// <summary>Shared currency-grant guard; validate before publishing any reward receipt.</summary>
public static class RewardBalance
{
    public static long Add(long balance, long reward)
    {
        if (balance < 0 || reward < 0 || reward > long.MaxValue - balance)
        {
            throw new InvalidDataException("Currency reward exceeds the supported wallet domain.");
        }
        return balance + reward;
    }
}

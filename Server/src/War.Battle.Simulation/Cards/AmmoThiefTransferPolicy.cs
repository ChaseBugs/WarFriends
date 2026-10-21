namespace War.BattleServer;

internal readonly record struct AmmoThiefTransfer(int ReserveTaken, int ClipTaken, bool ClipAccessed)
{
    internal int TotalTaken => ReserveTaken + ClipTaken;
}

internal static class AmmoThiefTransferPolicy
{
    internal static AmmoThiefTransfer Calculate(int startingAmmo, int victimReserve,
        int victimClip, int receivingReserve)
    {
        if (startingAmmo < 0 || victimReserve < 0 || victimClip < 0 || receivingReserve < 0)
            throw new InvalidDataException("Ammo Thief requires nonnegative trusted weapon state.");

        // The recovered CardAmmoThief truncates the positive float product.
        int requested = (int)((float)startingAmmo * 0.25f);
        int reserveTaken = Math.Min(requested, victimReserve);
        int clipTaken = Math.Min(requested - reserveTaken, victimClip);
        int totalTaken = reserveTaken + clipTaken;
        if (totalTaken > int.MaxValue - receivingReserve)
            throw new InvalidDataException("Ammo Thief would overflow the owner's reserve.");

        return new AmmoThiefTransfer(reserveTaken, clipTaken,
            ClipAccessed: reserveTaken < requested);
    }
}

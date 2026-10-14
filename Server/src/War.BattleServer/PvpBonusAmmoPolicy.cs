namespace War.BattleServer;

/// <summary>
/// KillStreakBonusAddAmmo adds one clip size to each used weapon's reserve.
/// The recovered Weapon.ammoLeft setter does not cap the resulting reserve.
/// </summary>
internal static class PvpBonusAmmoPolicy
{
    // Weapon.hasLowAmmo uses the original starting reserve, not clip plus
    // reserve. Only reloadable weapons can qualify for the source weight boost.
    internal static bool HasLowAmmo(bool reloadableWeapon, int startingReserve,
        int currentReserve, int currentClip, float sourceThreshold)
    {
        if (startingReserve < 0 || currentReserve < 0 || currentClip < 0 ||
            (long)currentReserve + currentClip > int.MaxValue ||
            !float.IsFinite(sourceThreshold) || sourceThreshold is <= 0f or >= 1f)
            throw new InvalidDataException("Invalid source weapon ammunition state.");
        if (!reloadableWeapon || startingReserve == 0) return false;
        float fraction = (float)(currentReserve + currentClip) / startingReserve;
        return fraction < sourceThreshold;
    }

    internal static int RefilledReserve(int currentReserve, int clipSize)
    {
        if (currentReserve < 0 || clipSize <= 0 || currentReserve > int.MaxValue - clipSize)
            throw new InvalidDataException("Invalid bonus crate ammo reserve.");
        return currentReserve + clipSize;
    }
}

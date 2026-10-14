namespace War.BattleServer;

/// <summary>
/// KillStreakBonusAddAmmo adds one clip size to each used weapon's reserve.
/// The recovered Weapon.ammoLeft setter does not cap the resulting reserve.
/// </summary>
internal static class PvpBonusAmmoPolicy
{
    internal static int RefilledReserve(int currentReserve, int clipSize)
    {
        if (currentReserve < 0 || clipSize <= 0 || currentReserve > int.MaxValue - clipSize)
            throw new InvalidDataException("Invalid bonus crate ammo reserve.");
        return currentReserve + clipSize;
    }
}

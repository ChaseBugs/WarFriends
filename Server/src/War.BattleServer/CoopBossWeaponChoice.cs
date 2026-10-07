namespace War.BattleServer;

internal enum CoopBossWeaponSlotKind
{
    Primary = 0,
    Secondary = 1,
    Explosive = 2,
    Pistol = 3
}

internal sealed record CoopBossWeaponReadiness(
    bool OutOfAmmo, bool Reloading, bool WillShoot, int AmmoLeft);

/// <summary>
/// PlayerBot.PickProperWeapon's ordinary player-target branch. The caller
/// supplies host-owned ammunition and reload state. Explosive sequences,
/// bonus boxes, and AI targets use other Client branches and stay closed.
/// </summary>
internal static class CoopBossWeaponChoice
{
    public static CoopBossWeaponSlotKind ForOrdinaryPlayerTarget(
        CoopBossAttackTiming timing, bool inDanger,
        CoopBossWeaponReadiness primary,
        CoopBossWeaponReadiness secondary,
        CoopBossWeaponReadiness explosive,
        float explosiveDraw, float rifleDraw)
    {
        ArgumentNullException.ThrowIfNull(timing);
        Validate(primary);
        Validate(secondary);
        Validate(explosive);
        ValidateDraw(explosiveDraw);
        ValidateDraw(rifleDraw);

        // PickProperWeapon checks this chance before its ordinary rifle path.
        if (explosiveDraw < timing.ExplosiveSwitchProbability &&
            !inDanger && explosive.WillShoot && explosive.AmmoLeft > 0)
            return CoopBossWeaponSlotKind.Explosive;

        bool primaryReady = !primary.OutOfAmmo && !primary.Reloading;
        bool secondaryReady = !secondary.OutOfAmmo && !secondary.Reloading;
        if (primaryReady && secondaryReady)
            return rifleDraw < 0.5f
                ? CoopBossWeaponSlotKind.Primary
                : CoopBossWeaponSlotKind.Secondary;
        if (primaryReady)
            return CoopBossWeaponSlotKind.Primary;
        if (secondaryReady)
            return CoopBossWeaponSlotKind.Secondary;

        // GetRiffle returns the pistol even if it is also out of ammunition;
        // its later ShootForBot path decides whether a round can fire.
        return CoopBossWeaponSlotKind.Pistol;
    }

    private static void Validate(CoopBossWeaponReadiness readiness)
    {
        ArgumentNullException.ThrowIfNull(readiness);
        if (readiness.AmmoLeft < 0)
            throw new InvalidDataException("Boss ammunition cannot be negative.");
    }

    private static void ValidateDraw(float draw)
    {
        if (!float.IsFinite(draw) || draw < 0 || draw >= 1)
            throw new InvalidDataException("Boss weapon draw is outside [0, 1).");
    }
}

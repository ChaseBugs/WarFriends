namespace War.BattleServer;

/// <summary>
/// Source SkillShotControllerPlayer.PlayerOnDamage flags for damage whose
/// owner is a different PlayerController. The caller must prove that owner
/// and the victim's exact Walking state from host combat authority.
/// </summary>
internal static class PvpPlayerHitSkillShotPolicy
{
    internal const int EnemyPlayerHit = 65_536;
    internal const int OnTheMove = 131_072;
    internal const int ArmyPlayerHit = 524_288;

    internal static int FlagsForConfirmedDamage(CombatDamageType damageType,
        bool victimWalking)
    {
        if (!Enum.IsDefined(damageType))
            throw new InvalidDataException("Unknown player damage type.");

        // The source returns before scoring poison and immortal damage.
        if (damageType is CombatDamageType.Poison or CombatDamageType.Immortal)
            return 0;

        // Flame has a real-time six-hit throttle in the Client. The current
        // host has no verified equivalent, so it cannot award these flags.
        if (damageType == CombatDamageType.Flame)
            return 0;

        return EnemyPlayerHit | (victimWalking ? OnTheMove : 0);
    }

    /// <summary>
    /// The separate AIObject branch credits its owning player only when the
    /// army entity and victim have different source fractions. It does not
    /// add OnTheMove even when the victim is walking.
    /// </summary>
    internal static int FlagsForConfirmedArmyDamage(CombatDamageType damageType,
        bool opposingFractions)
    {
        if (!Enum.IsDefined(damageType))
            throw new InvalidDataException("Unknown army damage type.");
        if (!opposingFractions || damageType is CombatDamageType.Poison or
            CombatDamageType.Immortal or CombatDamageType.Flame)
            return 0;
        return ArmyPlayerHit;
    }
}

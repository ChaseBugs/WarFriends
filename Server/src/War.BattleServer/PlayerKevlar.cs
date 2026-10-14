namespace War.BattleServer;

internal sealed record KevlarDamageResult(PlayerDamageResult Player, float RemainingKevlar);

/// <summary>Reproduces Kevlar.MainObjectOnDamage after the ordinary player hit.</summary>
internal static class PlayerKevlar
{
    internal const float CardStrength = 0.2f;
    internal const float BonusCrateStrength = 0.1f;

    internal static float CardMaximum(float playerMaximumHealth)
    {
        return MaximumForStrength(playerMaximumHealth, CardStrength);
    }

    internal static float BonusCrateMaximum(float playerMaximumHealth)
    {
        return MaximumForStrength(playerMaximumHealth, BonusCrateStrength);
    }

    private static float MaximumForStrength(float playerMaximumHealth, float strength)
    {
        if (!float.IsFinite(playerMaximumHealth) || playerMaximumHealth <= 0)
            throw new InvalidDataException("Invalid player health for Kevlar.");
        float maximum = playerMaximumHealth * strength;
        if (!float.IsFinite(maximum) || maximum <= 0 || maximum > 100_000_000)
            throw new InvalidDataException("Invalid Kevlar maximum.");
        return maximum;
    }

    internal static KevlarDamageResult Absorb(PlayerDamageResult player,
        float currentKevlar, float maximumKevlar, float maximumPlayerHealth,
        bool playerImmortal)
    {
        if (!float.IsFinite(currentKevlar) || !float.IsFinite(maximumKevlar) ||
            !float.IsFinite(maximumPlayerHealth) || currentKevlar < 0 ||
            currentKevlar > maximumKevlar || maximumKevlar < 0 ||
            maximumPlayerHealth <= 0)
            throw new InvalidDataException("Invalid player Kevlar authority.");
        if (!player.Applied || currentKevlar == 0 || player.OriginalDamage <= 0)
            return new(player, currentKevlar);

        // The recovered callback receives originalDamage even if the main
        // player dodged or was immortal. Kevlar still takes that full hit.
        float armorDamage = player.OriginalDamage;
        float remaining = Math.Max(0, currentKevlar - armorDamage);
        float refund = playerImmortal ? 0 : Math.Min(currentKevlar, armorDamage);
        float restoredHealth = Math.Min(maximumPlayerHealth, player.Health + refund);
        float actualRefund = restoredHealth - player.Health;
        if (!float.IsFinite(remaining) || !float.IsFinite(restoredHealth) ||
            !float.IsFinite(actualRefund))
            throw new InvalidDataException("Player Kevlar arithmetic overflow.");
        return new(player with
        {
            Health = restoredHealth,
            Damage = player.Damage - actualRefund,
            Dead = restoredHealth <= 0
        }, remaining);
    }
}

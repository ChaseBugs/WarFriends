namespace War.BattleServer;

// Numeric identities match DestroyableObject.DamageType in the recovered 1.4.0 client.
public enum CombatDamageType { Shot, Explosion, Shiver, Basic, Poison, Flame, Heal, Immortal, Suicide }

public sealed record PlayerCombatManifest(float MaxHealth, float ShotCoefficient = 1,
    float NoDamageChance = 0, bool Immortal = false, bool TutorialProtection = false);

// Server simulation input only. Never deserialize this from a player packet.
internal sealed record ResolvedPlayerDamage(float Amount, CombatDamageType Type,
    float PartWeight = 1, bool HasWeapon = true, bool FriendKill = false,
    float FriendlyCoefficient = 1, float PlayerCoefficient = 1,
    float PlayerOvertimeCoefficient = 1, float ExplosiveCoefficient = 1,
    float ExplosiveOvertimeCoefficient = 1, bool Overtime = false,
    bool IgnoreImmortality = false);

internal sealed record PlayerDamageResult(bool Applied, float Health, float Damage,
    float OriginalDamage, CombatDamageType Type, bool OneHit, bool Dead);

internal static class PlayerDamage
{
    internal static void Validate(PlayerCombatManifest definition)
    {
        if (!float.IsFinite(definition.MaxHealth) || definition.MaxHealth is <= 0 or > 100000000 ||
            !Coefficient(definition.ShotCoefficient) || !float.IsFinite(definition.NoDamageChance) ||
            definition.NoDamageChance is < 0 or > 1)
            throw new InvalidDataException("Invalid player combat authority.");
    }

    private static bool Coefficient(float value) => float.IsFinite(value) && value is >= 0 and <= 1000;

    // Preserve binary32 operation order, including PlayerController.OnDamage's
    // refund BEFORE DestroyableObject checks death. Critical/spread/falloff belong
    // to the upstream server projectile; Amount already includes those effects.
    internal static PlayerDamageResult Resolve(PlayerCombatManifest definition, float health,
        ResolvedPlayerDamage hit, bool sameFraction, bool self, float randomRoll)
    {
        Validate(definition);
        if (!float.IsFinite(health) || health <= 0 || health > definition.MaxHealth ||
            !Enum.IsDefined(hit.Type) || !float.IsFinite(hit.Amount) || Math.Abs(hit.Amount) > 100000000 ||
            (hit.Amount < 0 && (hit.HasWeapon || hit.Type is not (CombatDamageType.Heal or CombatDamageType.Shiver))) ||
            !Coefficient(hit.PartWeight) || !Coefficient(hit.FriendlyCoefficient) ||
            !Coefficient(hit.PlayerCoefficient) || !Coefficient(hit.PlayerOvertimeCoefficient) ||
            !Coefficient(hit.ExplosiveCoefficient) || !Coefficient(hit.ExplosiveOvertimeCoefficient) ||
            !float.IsFinite(randomRoll) || randomRoll is < 0 or > 1)
            throw new InvalidDataException("Invalid resolved damage authority.");
        if (hit.HasWeapon && !hit.FriendKill && sameFraction)
            return new(false, health, 0, 0, hit.Type, false, false);

        float damage = hit.Amount;
        if (hit.Type is CombatDamageType.Shot or CombatDamageType.Flame) damage *= definition.ShotCoefficient;
        damage *= hit.PartWeight;
        if (hit.HasWeapon && hit.Type is CombatDamageType.Shot or CombatDamageType.Explosion or CombatDamageType.Shiver)
            damage *= hit.Overtime ? hit.PlayerOvertimeCoefficient : hit.PlayerCoefficient;
        if (!hit.HasWeapon && hit.Type is CombatDamageType.Explosion or CombatDamageType.Shiver)
            damage *= hit.Overtime ? hit.ExplosiveOvertimeCoefficient : hit.ExplosiveCoefficient;
        if (sameFraction) damage *= hit.FriendlyCoefficient;
        float original = damage;
        var type = hit.Type;
        if (definition.Immortal && !hit.IgnoreImmortality) { damage = 0; type = CombatDamageType.Immortal; }
        bool oneHit = health >= definition.MaxHealth && damage >= health;
        float after = Math.Min(health - damage, definition.MaxHealth);
        float beforeCallback = after;
        if (((randomRoll < definition.NoDamageChance || self) && !definition.Immortal) ||
            (definition.TutorialProtection && Math.Clamp(after / definition.MaxHealth, 0, 1) < 0.2f))
            after = Math.Min(after + damage, definition.MaxHealth);
        damage -= after - beforeCallback;
        if (!float.IsFinite(original) || !float.IsFinite(after) || !float.IsFinite(damage))
            throw new InvalidDataException("Damage arithmetic overflow.");
        return new(true, after, damage, original, type, oneHit, after <= 0);
    }
}

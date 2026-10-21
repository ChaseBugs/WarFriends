namespace War.BattleServer;

/// <summary>Current vitality and ordered weapon damage observed at the source AfterSpawned callback.</summary>
public sealed record SicknessCombatState(float MaximumHealth, float Health, IReadOnlyList<float> WeaponDamage)
{
    /// <summary>RefillTo clears the source immortality flag.</summary>
    public bool IsImmortal { get; init; }

    /// <summary>RefillTo clears the source death flag.</summary>
    public bool IsDead { get; init; }
}

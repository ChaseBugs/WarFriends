namespace War.BattleServer;

/// <summary>Server-owned air-unit vitality. Damage is applied only after the
/// collision resolver has validated the entity and trusted amount.</summary>
public sealed class AirEntityHealthState
{
    public float Maximum { get; }
    public float Current { get; private set; }
    public bool IsDead => Current <= 0;

    public AirEntityHealthState(float maximum)
    {
        if (!float.IsFinite(maximum) || maximum <= 0 || maximum > 10_000_000)
            throw new InvalidDataException("Invalid air-unit health.");
        Maximum = maximum; Current = maximum;
    }

    public float ApplyDamage(float damage)
    {
        if (!float.IsFinite(damage) || damage <= 0 || damage > 10_000_000)
            throw new InvalidDataException("Invalid air-unit damage.");
        if (IsDead) return 0;
        var applied = MathF.Min(Current, damage);
        Current -= applied;
        return applied;
    }
}

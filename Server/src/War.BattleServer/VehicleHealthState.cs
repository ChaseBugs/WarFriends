namespace War.BattleServer;

public sealed class VehicleHealthState
{
    public float Maximum { get; }
    public float Current { get; private set; }
    public bool Destroyed => Current <= 0;
    public VehicleHealthState(float maximum)
    {
        if (!float.IsFinite(maximum) || maximum <= 0 || maximum > 10_000_000) throw new InvalidDataException("Invalid vehicle health.");
        Maximum = maximum; Current = maximum;
    }
    public float ApplyDamage(float amount)
    {
        if (!float.IsFinite(amount) || amount <= 0 || amount > 10_000_000) throw new InvalidDataException("Invalid vehicle damage.");
        var before = Current; Current = Math.Max(0, Current - amount); return before - Current;
    }
    public float ApplyHeal(float amount)
    {
        if (!float.IsFinite(amount) || amount <= 0 || amount > 10_000_000)
            throw new ArgumentOutOfRangeException(nameof(amount));
        float before=Current;Current=Math.Min(Maximum,Current+amount);return Current-before;
    }
}

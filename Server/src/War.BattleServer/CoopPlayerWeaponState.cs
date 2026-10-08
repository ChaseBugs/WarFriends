namespace War.BattleServer;

public sealed record CoopWeaponReadiness(
    int Slot, int Clip, int Reserve, ulong ReloadEndTick,
    ulong NextFireTick, ulong ShotsFired);

internal enum CoopShotAvailability
{
    Ready,
    WrongSlot,
    WrongTick,
    Reloading,
    Cooldown,
    NoAmmo
}

/// <summary>
/// Host-owned ammunition and timing for source-validated co-op weapon slots.
/// ConfirmHostShot is an internal combat seam: call it only after a real host
/// projectile has been created for the signed weapon.
/// </summary>
public sealed class CoopPlayerWeaponState
{
    private sealed class SlotState(CoopPlayerWeapon weapon)
    {
        public CoopPlayerWeapon Weapon { get; } = weapon;
        public int Clip = weapon.Weapon.ClipSize;
        public int Reserve = weapon.Weapon.ReserveAmmo;
        public ulong ReloadEndTick;
        public ulong NextFireTick;
        public ulong ShotsFired;
    }

    private readonly Dictionary<int, SlotState> slots;
    public int ActiveSlot { get; private set; }
    public ulong CurrentTick { get; private set; }
    public bool HasFiredAnyShot => slots.Values.Any(slot =>
        slot.ShotsFired != 0);

    public CoopPlayerWeaponState(
        IReadOnlyList<CoopPlayerWeapon> weapons, ulong startingTick)
    {
        ArgumentNullException.ThrowIfNull(weapons);
        if (weapons.Count is < 1 or > 8 ||
            weapons.Select(weapon => weapon.Slot).Distinct().Count() != weapons.Count)
            throw new InvalidDataException("Invalid co-op weapon slots.");
        slots = weapons.ToDictionary(weapon => weapon.Slot,
            weapon => new SlotState(weapon));
        ActiveSlot = weapons[0].Slot;
        CurrentTick = startingTick;
    }

    public CoopWeaponReadiness Readiness(int slot)
    {
        SlotState weapon = GetSlot(slot);
        return new CoopWeaponReadiness(slot, weapon.Clip, weapon.Reserve,
            weapon.ReloadEndTick, weapon.NextFireTick, weapon.ShotsFired);
    }

    public bool TrySelectSlot(int slot, ulong tick)
    {
        if (tick != CurrentTick || !slots.ContainsKey(slot))
            return false;
        ActiveSlot = slot;
        return true;
    }

    public bool ConfirmHostShot(int slot, ulong tick)
    {
        if (CheckShot(slot, tick) != CoopShotAvailability.Ready)
            return false;
        SlotState weapon = GetSlot(slot);
        weapon.Clip--;
        weapon.ShotsFired = checked(weapon.ShotsFired + 1);
        weapon.NextFireTick = checked(tick + TickDuration(
            weapon.Weapon.Weapon.CadenceSeconds));
        if (weapon.Clip == 0 && weapon.Reserve > 0)
            StartReload(weapon, tick);
        return true;
    }

    /// <summary>
    /// Checks a proposed host shot without spending ammunition. The projectile
    /// simulator must still establish a muzzle, unobstructed path, and damage
    /// before ConfirmHostShot commits this weapon state.
    /// </summary>
    internal CoopShotAvailability CheckShot(int slot, ulong tick)
    {
        if (slot != ActiveSlot || !slots.ContainsKey(slot))
            return CoopShotAvailability.WrongSlot;
        if (tick != CurrentTick)
            return CoopShotAvailability.WrongTick;

        SlotState weapon = GetSlot(slot);
        if (weapon.ReloadEndTick != 0)
            return CoopShotAvailability.Reloading;
        if (tick < weapon.NextFireTick)
            return CoopShotAvailability.Cooldown;
        if (weapon.Clip == 0)
            return CoopShotAvailability.NoAmmo;
        return CoopShotAvailability.Ready;
    }

    public bool TryStartReload(int slot, ulong tick)
    {
        if (slot != ActiveSlot || tick != CurrentTick)
            return false;
        SlotState weapon = GetSlot(slot);
        if (weapon.ReloadEndTick != 0 || weapon.Reserve == 0 ||
            weapon.Clip == weapon.Weapon.Weapon.ClipSize)
            return false;
        StartReload(weapon, tick);
        return true;
    }

    public bool Advance(ulong tick)
    {
        if (tick < CurrentTick)
            throw new InvalidOperationException("Co-op weapon time moved backward.");
        CurrentTick = tick;
        bool changed = false;
        foreach (SlotState weapon in slots.Values)
        {
            if (weapon.ReloadEndTick == 0 || tick < weapon.ReloadEndTick)
                continue;
            int missing = weapon.Weapon.Weapon.ClipSize - weapon.Clip;
            int transferred = Math.Min(missing, weapon.Reserve);
            weapon.Clip += transferred;
            if (weapon.Reserve != int.MaxValue)
                weapon.Reserve -= transferred;
            weapon.ReloadEndTick = 0;
            changed = true;
        }
        return changed;
    }

    private static ulong TickDuration(double seconds)
    {
        return checked((ulong)Math.Ceiling(seconds * MatchManifest.TickRate));
    }

    private static void StartReload(SlotState weapon, ulong tick)
    {
        weapon.ReloadEndTick = checked(tick + TickDuration(
            weapon.Weapon.Weapon.ReloadSeconds));
    }

    private SlotState GetSlot(int slot)
    {
        return slots.TryGetValue(slot, out SlotState? weapon)
            ? weapon
            : throw new ArgumentOutOfRangeException(nameof(slot));
    }
}

using War.BattleServer;

/// <summary>Rejects invalid host shot clocks without spending source-bound ammunition.</summary>
internal static class CoopWeaponAtomicityTests
{
    internal static void Run(CoopPlayerWeapon source)
    {
        var cadenceOverflow = new CoopPlayerWeaponState([source], ulong.MaxValue);
        RequireUnchangedAfterOverflow(cadenceOverflow, source.Slot, ulong.MaxValue);

        ulong cadenceTicks = checked((ulong)Math.Ceiling(
            source.Weapon.CadenceSeconds * MatchManifest.TickRate));
        ulong reloadTicks = checked((ulong)Math.Ceiling(
            source.Weapon.ReloadSeconds * MatchManifest.TickRate));
        if (reloadTicks <= cadenceTicks || source.Weapon.ReserveAmmo <= 0)
        {
            throw new Exception("The source fixture must exercise automatic reload overflow separately.");
        }

        var reloadOverflow = new CoopPlayerWeaponState([source], 0);
        ulong tick = 0;
        while (reloadOverflow.Readiness(source.Slot).Clip > 1)
        {
            if (!reloadOverflow.ConfirmHostShot(source.Slot, tick))
            {
                throw new Exception("The source fixture could not consume its ordinary shots.");
            }
            tick = checked(tick + cadenceTicks);
            reloadOverflow.Advance(tick);
        }

        ulong lastShotTick = ulong.MaxValue - cadenceTicks;
        reloadOverflow.Advance(lastShotTick);
        RequireUnchangedAfterOverflow(reloadOverflow, source.Slot, lastShotTick);
        Console.WriteLine("PASS: co-op cadence and automatic reload overflow preserve all ammunition state");
    }

    private static void RequireUnchangedAfterOverflow(CoopPlayerWeaponState weapons, int slot, ulong tick)
    {
        CoopWeaponReadiness before = weapons.Readiness(slot);
        try
        {
            weapons.ConfirmHostShot(slot, tick);
            throw new Exception("An overflowing host shot clock was accepted.");
        }
        catch (OverflowException)
        {
            // Invalid authority is rejected before any part of the shot is published.
        }

        if (weapons.Readiness(slot) != before)
        {
            throw new Exception("A rejected host shot changed clip, reserve, reload, cadence or shot count.");
        }
    }
}

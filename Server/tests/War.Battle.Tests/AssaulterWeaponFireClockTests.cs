using War.BattleServer;

/// <summary>Checks source float boundary and persistent weapon time, independently of tick rounding.</summary>
internal static class AssaulterWeaponFireClockTests
{
    internal static int Run()
    {
        const float sourceCadence = 0.35f;
        var clock = new AssaulterWeaponFireClock(sourceCadence);
        Require(!clock.CanFire(0) && !clock.CanFire(sourceCadence), "Initial cadence equality allowed fire.");
        float firstTime = MathF.BitIncrement(sourceCadence);
        Require(clock.CanFire(firstTime), "First float after cadence was not eligible.");
        clock.ObserveFired(firstTime);
        Reject(() => clock.ObserveFired(firstTime));
        float nextBoundary = firstTime + sourceCadence;
        Require(!clock.CanFire(nextBoundary), "Persistent lastShotTime lost its strict boundary.");
        float nextTime = MathF.BitIncrement(nextBoundary);
        Require(clock.CanFire(nextTime), "Second volley could not use the persistent weapon clock.");
        Reject(() => clock.CanFire(float.NaN));
        Reject(() => clock.CanFire(float.PositiveInfinity));
        Reject(() => clock.CanFire(-1));
        Reject(() => clock.CanFire(firstTime));
        clock.ObserveFired(nextTime);
        Reject(() => new AssaulterWeaponFireClock(0));
        Reject(() => new AssaulterWeaponFireClock(float.NaN));
        return 11;
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }

    private static void Reject(Action action)
    {
        try
        {
            action();
        }
        catch (Exception exception) when (exception is InvalidOperationException or InvalidDataException)
        {
            return;
        }
        throw new Exception("Malformed or premature weapon time was accepted.");
    }
}

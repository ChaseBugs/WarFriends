namespace War.BattleServer;

public enum WeaponFireMode { Click, Hold, Burst, Swipe, Zoom }

public static class WeaponFireModePolicy
{
    public static WeaponFireMode Validate(WeaponFireMode mode, bool sourceSupportsMode)
    {
        if (!Enum.IsDefined(mode) || !sourceSupportsMode)
            throw new InvalidDataException("Unsupported weapon fire mode.");
        return mode;
    }
}

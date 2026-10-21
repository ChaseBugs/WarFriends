namespace War.BattleServer;

/// <summary>Shared server-only key rules for startup and signing utilities.</summary>
public static class TransportSecurityPolicy
{
    private const int KeyBytes = 32;

    public static void ValidateSigningKey(byte[] key)
    {
        ValidateKey(key, "Battle signing key");
    }

    internal static void ValidateKey(byte[] key, string setting)
    {
        if (key == null || key.Length != KeyBytes)
        {
            throw new InvalidDataException(setting + " must be a nonzero 256-bit key.");
        }

        foreach (byte value in key)
        {
            if (value != 0)
            {
                return;
            }
        }
        throw new InvalidDataException(setting + " must be a nonzero 256-bit key.");
    }
}

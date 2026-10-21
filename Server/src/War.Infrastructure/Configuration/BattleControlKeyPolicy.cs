using System.Security.Cryptography;

namespace War.BattleServer;

/// <summary>Keeps allocator control authority separate from player admission signing.</summary>
public static class BattleControlKeyPolicy
{
    public static byte[] ValidateAndCopy(byte[] controlKey, byte[] signingKey)
    {
        TransportSecurityPolicy.ValidateSigningKey(signingKey);
        TransportSecurityPolicy.ValidateKey(controlKey, "Battle control key");
        if (CryptographicOperations.FixedTimeEquals(controlKey, signingKey))
        {
            throw new InvalidDataException("Battle control key must differ from the signing key.");
        }
        return controlKey.ToArray();
    }
}

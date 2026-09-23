using System.Security.Cryptography;

namespace War.BattleServer;

public static class BattleControlKeyPolicy
{
    public static byte[] ValidateAndCopy(byte[] controlKey,byte[] signingKey)
    {
        if(controlKey is not {Length:32})throw new InvalidDataException("Battle control key must be 256-bit.");
        if(signingKey is not {Length:32})throw new InvalidDataException("Battle signing key must be 256-bit.");
        if(CryptographicOperations.FixedTimeEquals(controlKey,signingKey))
            throw new InvalidDataException("Battle control key must differ from the signing key.");
        return controlKey.ToArray();
    }
}

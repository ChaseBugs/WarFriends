namespace War.BattleServer;

public static class TransportSecurityPolicy
{
    public static void ValidateSigningKey(byte[] key)
    {
        if(key==null||key.Length!=32||key.All(x=>x==0))throw new InvalidDataException("Battle signing key must be a nonzero 256-bit key.");
    }
}

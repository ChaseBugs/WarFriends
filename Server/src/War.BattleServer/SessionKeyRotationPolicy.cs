namespace War.BattleServer;

public static class SessionKeyRotationPolicy
{
    public static void Validate(ulong currentGeneration, ulong nextGeneration, byte[] key)
    {
        if (nextGeneration <= currentGeneration || key is null || key.Length != 32 || key.All(x => x == 0))
            throw new InvalidDataException("Invalid session key rotation.");
    }
}

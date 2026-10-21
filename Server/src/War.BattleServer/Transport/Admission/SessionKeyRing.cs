namespace War.BattleServer;

/// <summary>Owns the active transport signing key and prevents callers from mutating it.</summary>
public sealed class SessionKeyRing
{
    private byte[] key;
    public ulong Generation { get; private set; }
    public SessionKeyRing(ulong generation, byte[] initialKey)
    {
        if (generation == 0) throw new InvalidDataException("Invalid initial key generation.");
        if (initialKey is null) throw new ArgumentNullException(nameof(initialKey));
        SessionKeyRotationPolicy.Validate(0, generation, initialKey);
        key = (byte[])initialKey.Clone(); Generation = generation;
    }
    public byte[] CurrentKey => (byte[])key.Clone();
    public void Rotate(ulong nextGeneration, byte[] nextKey)
    {
        if (nextKey is null) throw new ArgumentNullException(nameof(nextKey));
        SessionKeyRotationPolicy.Validate(Generation, nextGeneration, nextKey);
        key = (byte[])nextKey.Clone(); Generation = nextGeneration;
    }
}

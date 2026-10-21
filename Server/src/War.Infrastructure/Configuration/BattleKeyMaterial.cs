using War.BattleServer;

namespace War.Infrastructure;

/// <summary>One validated startup snapshot; exposed control bytes cannot change its authority.</summary>
public sealed class BattleKeyMaterial
{
    private readonly byte[]? _controlKey;

    private BattleKeyMaterial(string signingKey, byte[]? controlKey)
    {
        SigningKey = signingKey;
        _controlKey = controlKey;
    }

    public string SigningKey { get; }

    public byte[]? ControlKey => _controlKey?.ToArray();

    public static BattleKeyMaterial FromEncodedKeys(string? signingText, string? controlText,
        bool requireControlKey = false)
    {
        byte[] signingKey = Decode(signingText, "Battle:SigningKey");
        TransportSecurityPolicy.ValidateSigningKey(signingKey);
        if (controlText == null && requireControlKey)
        {
            throw new InvalidDataException("Set Battle:ControlKey separately from Battle:SigningKey.");
        }

        byte[]? controlKey = controlText == null
            ? null
            : BattleControlKeyPolicy.ValidateAndCopy(Decode(controlText, "Battle:ControlKey"), signingKey);
        return new BattleKeyMaterial(Convert.ToBase64String(signingKey), controlKey);
    }

    private static byte[] Decode(string? encoded, string setting)
    {
        if (encoded == null)
        {
            throw new InvalidDataException("Set " + setting + ".");
        }
        try
        {
            return Convert.FromBase64String(encoded);
        }
        catch (FormatException)
        {
            // A configuration error must never include secret bytes in logs or its message.
            throw new InvalidDataException(setting + " must be base64-encoded key bytes.");
        }
    }
}

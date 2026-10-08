using Microsoft.Extensions.Configuration;

namespace War.BattleServer;

/// <summary>Validated transport keys captured once during Worker startup.</summary>
public sealed class BattleKeyConfig
{
    private readonly byte[]? controlKey;

    private BattleKeyConfig(string signingKey, byte[]? controlKey)
    {
        SigningKey = signingKey;
        this.controlKey = controlKey;
    }

    public string SigningKey { get; }

    public byte[]? ControlKey => controlKey?.ToArray();

    public static BattleKeyConfig FromConfiguration(
        IConfiguration configuration, bool requireControlKey = false)
    {
        ArgumentNullException.ThrowIfNull(configuration);
        string signingText = configuration["Battle:SigningKey"] ??
            throw new InvalidDataException("Set Battle__SigningKey.");
        byte[] signingBytes = Decode(signingText, "Battle__SigningKey");
        TransportSecurityPolicy.ValidateSigningKey(signingBytes);

        string? controlText = configuration["Battle:ControlKey"];
        if (controlText == null && requireControlKey)
            throw new InvalidDataException(
                "Set Battle__ControlKey separately from Battle__SigningKey.");
        byte[]? controlBytes = controlText == null
            ? null
            : BattleControlKeyPolicy.ValidateAndCopy(
                Decode(controlText, "Battle__ControlKey"), signingBytes);

        return new BattleKeyConfig(
            Convert.ToBase64String(signingBytes), controlBytes);
    }

    private static byte[] Decode(string encoded, string setting)
    {
        try { return Convert.FromBase64String(encoded); }
        catch (FormatException error)
        {
            throw new InvalidDataException(
                $"{setting} must be base64-encoded key bytes.", error);
        }
    }
}

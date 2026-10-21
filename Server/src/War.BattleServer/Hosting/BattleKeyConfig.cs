using Microsoft.Extensions.Configuration;
using War.Infrastructure;

namespace War.BattleServer;

/// <summary>Adapts Worker configuration to the shared immutable server key policy.</summary>
public sealed class BattleKeyConfig
{
    private readonly BattleKeyMaterial _keys;

    private BattleKeyConfig(BattleKeyMaterial keys)
    {
        _keys = keys;
    }

    public string SigningKey => _keys.SigningKey;

    public byte[]? ControlKey => _keys.ControlKey;

    public static BattleKeyConfig FromConfiguration(IConfiguration configuration, bool requireControlKey = false)
    {
        ArgumentNullException.ThrowIfNull(configuration);
        BattleKeyMaterial keys = BattleKeyMaterial.FromEncodedKeys(configuration["Battle:SigningKey"],
            configuration["Battle:ControlKey"], requireControlKey);
        return new BattleKeyConfig(keys);
    }
}

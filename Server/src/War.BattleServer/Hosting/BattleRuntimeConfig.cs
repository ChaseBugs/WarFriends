using System.Globalization;
using Microsoft.Extensions.Configuration;
using War.Infrastructure;
using War.Protocol.Transport;

namespace War.BattleServer;

public sealed record BattleRuntimeConfig(
    int Port, int MaxMatches, int TickRate, int MtuBytes);

public static class BattleRuntimeConfigValidator
{
    public static BattleRuntimeConfig FromConfiguration(
        IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration);

        var candidate = new BattleRuntimeConfig(
            ReadInteger(configuration, "Battle:Port", BattleEndpointPolicy.DefaultUdpPort),
            ReadInteger(configuration, "Battle:MaxMatches", 32),
            ReadInteger(configuration, "Battle:TickRate", 30),
            ReadInteger(configuration, "Battle:MtuBytes", PacketCodec.MaximumDatagramBytes));
        return ValidateAndFreeze(candidate);
    }

    public static BattleRuntimeConfig ValidateAndFreeze(
        BattleRuntimeConfig config)
    {
        Validate(config);
        return new BattleRuntimeConfig(
            config.Port, config.MaxMatches, config.TickRate, config.MtuBytes);
    }

    public static void Validate(BattleRuntimeConfig config)
    {
        if (config == null ||
            config.MaxMatches is < 1 or > 1024 ||
            config.TickRate != 30)
        {
            throw new InvalidDataException(
                "Invalid BattleServer runtime configuration.");
        }

        BattleEndpointPolicy.ValidateUdpPort(config.Port);

        // The codec, SDK receive buffers and reply paging all use this fixed protocol budget.
        // A smaller ingress-only setting would still emit replies above the operator's limit.
        if (config.MtuBytes != PacketCodec.MaximumDatagramBytes)
        {
            throw new InvalidDataException(
                $"Battle:MtuBytes must equal the protocol UDP budget ({PacketCodec.MaximumDatagramBytes}).");
        }
    }

    private static int ReadInteger(IConfiguration configuration,
        string key, int defaultValue)
    {
        string? value = configuration[key];
        if (value == null)
            return defaultValue;
        if (!int.TryParse(value, NumberStyles.Integer,
                CultureInfo.InvariantCulture, out int parsed))
            throw new InvalidDataException(
                $"BattleServer setting {key} must be an integer.");
        return parsed;
    }
}

using System.Globalization;
using Microsoft.Extensions.Configuration;

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
            ReadInteger(configuration, "Battle:Port", 30000),
            ReadInteger(configuration, "Battle:MaxMatches", 32),
            ReadInteger(configuration, "Battle:TickRate", 30),
            ReadInteger(configuration, "Battle:MtuBytes", 1200));
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
            config.Port is < 1024 or > 65535 ||
            config.MaxMatches is < 1 or > 1024 ||
            config.TickRate != 30 ||
            config.MtuBytes is < 576 or > 1400)
            throw new InvalidDataException(
                "Invalid BattleServer runtime configuration.");
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

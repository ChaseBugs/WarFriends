using Microsoft.Extensions.Configuration;
using War.Infrastructure;

namespace War.BattleServer;

/// <summary>Captures every Worker startup input before listeners, content or durable journals open.</summary>
public sealed class BattleHostStartupOptions
{
    private BattleHostStartupOptions(IConfiguration configuration)
    {
        Runtime = BattleRuntimeConfigValidator.FromConfiguration(configuration);
        ControlPort = BattleEndpointPolicy.ReadControlPort(configuration["Battle:ControlPort"], Runtime.Port);
        Keys = BattleKeyConfig.FromConfiguration(configuration, requireControlKey: true);
        Worker = BattleWorkerSettings.FromConfiguration(configuration, hasControlKey: true);
    }

    public BattleRuntimeConfig Runtime { get; }

    public int ControlPort { get; }

    public BattleKeyConfig Keys { get; }

    public BattleWorkerSettings Worker { get; }

    public static BattleHostStartupOptions FromConfiguration(IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration);
        try
        {
            return new BattleHostStartupOptions(configuration);
        }
        catch (Exception error) when (error is not InvalidDataException &&
            error is ArgumentException or FormatException or InvalidOperationException or IOException)
        {
            throw new InvalidDataException("Invalid Worker deployment configuration.");
        }
    }
}

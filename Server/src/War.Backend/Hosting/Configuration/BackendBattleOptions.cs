using System.Text.RegularExpressions;
using War.Infrastructure;

namespace War.Backend.Hosting.Configuration;

/// <summary>Frozen Backend coordinates, keys and deliberate matchmaking admission configuration.</summary>
public sealed class BackendBattleOptions
{
    private BackendBattleOptions(IConfiguration configuration)
    {
        ServerId = configuration["Battle:ServerId"] ?? "local-1";
        PublicHost = configuration["Battle:PublicHost"] ?? "127.0.0.1";
        Port = DeploymentValueParser.ReadInt32(configuration["Battle:Port"], "Battle:Port",
            BattleEndpointPolicy.DefaultUdpPort);
        BattleEndpointPolicy.ValidateServerId(ServerId);
        BattleEndpointPolicy.ValidatePublicHost(PublicHost);
        BattleEndpointPolicy.ValidateUdpPort(Port);
        ControlPort = BattleEndpointPolicy.ReadControlPort(configuration["Battle:ControlPort"], Port);
        string endpoint = configuration["Battle:ControlEndpoint"] ??
            $"http://127.0.0.1:{ControlPort}/internal/matches";
        ControlEndpoint = BattleEndpointPolicy.ReadHttpEndpoint(endpoint, "Battle:ControlEndpoint");
        Keys = BattleKeyMaterial.FromEncodedKeys(configuration["Battle:SigningKey"],
            configuration["Battle:ControlKey"], requireControlKey: true);
        CompatibilityKey = configuration["Battle:MatchmakingCompatibilityKey"];
        if (CompatibilityKey != null && !Regex.IsMatch(CompatibilityKey, @"\A[a-zA-Z0-9_.:-]{1,128}\z"))
        {
            throw new InvalidDataException("Invalid Battle:MatchmakingCompatibilityKey.");
        }
        BattleContentPaths paths = BattleContentPaths.FromConfiguration(configuration);
        if (CompatibilityKey != null && paths.Template == null)
        {
            throw new InvalidDataException("Set Battle:MatchManifestTemplatePath when matchmaking is enabled.");
        }
        Content = BattleContentStartupOptions.FromPaths(paths, ServerId);
    }

    public string ServerId { get; }

    public string PublicHost { get; }

    public int Port { get; }

    public int ControlPort { get; }

    public Uri ControlEndpoint { get; }

    public BattleKeyMaterial Keys { get; }

    public string? CompatibilityKey { get; }

    public BattleContentStartupOptions Content { get; }

    public static BackendBattleOptions FromConfiguration(IConfiguration configuration)
    {
        return new BackendBattleOptions(configuration);
    }
}

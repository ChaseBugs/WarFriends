using System.Net;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;

namespace War.BattleServer;

/// <summary>Worker deployment values resolved before loading content or durable state.</summary>
public sealed class BattleWorkerSettings
{
    private readonly string bindAddress;

    private BattleWorkerSettings(string serverId, IPAddress bindAddress,
        string publicHost, string? matchManifestPath,
        string? matchManifestDirectory, string? combatContentManifestPath,
        string? shotgunContentManifestPath, string? smgContentManifestPath,
        string? pistolContentManifestPath, string? lmgContentManifestPath,
        string? minigunContentManifestPath, string? sniperContentManifestPath,
        string? bazookaContentManifestPath, string? grenadeContentManifestPath,
        string? contentPath, string resultOutboxPath,
        Uri? backendResultEndpoint, Uri? backendAllocationEndpoint)
    {
        ServerId = serverId;
        this.bindAddress = bindAddress.ToString();
        PublicHost = publicHost;
        MatchManifestPath = matchManifestPath;
        MatchManifestDirectory = matchManifestDirectory;
        CombatContentManifestPath = combatContentManifestPath;
        ShotgunContentManifestPath = shotgunContentManifestPath;
        SmgContentManifestPath = smgContentManifestPath;
        PistolContentManifestPath = pistolContentManifestPath;
        LmgContentManifestPath = lmgContentManifestPath;
        MinigunContentManifestPath = minigunContentManifestPath;
        SniperContentManifestPath = sniperContentManifestPath;
        BazookaContentManifestPath = bazookaContentManifestPath;
        GrenadeContentManifestPath = grenadeContentManifestPath;
        ContentPath = contentPath;
        ResultOutboxPath = resultOutboxPath;
        BackendResultEndpoint = backendResultEndpoint;
        BackendAllocationEndpoint = backendAllocationEndpoint;
    }

    public string ServerId { get; }
    public IPAddress BindAddress => IPAddress.Parse(bindAddress);
    public string PublicHost { get; }
    public string? MatchManifestPath { get; }
    public string? MatchManifestDirectory { get; }
    public string? CombatContentManifestPath { get; }
    public string? ShotgunContentManifestPath { get; }
    public string? SmgContentManifestPath { get; }
    public string? PistolContentManifestPath { get; }
    public string? LmgContentManifestPath { get; }
    public string? MinigunContentManifestPath { get; }
    public string? SniperContentManifestPath { get; }
    public string? BazookaContentManifestPath { get; }
    public string? GrenadeContentManifestPath { get; }
    public string? ContentPath { get; }
    public string ResultOutboxPath { get; }
    public Uri? BackendResultEndpoint { get; }
    public Uri? BackendAllocationEndpoint { get; }

    public static BattleWorkerSettings FromConfiguration(
        IConfiguration configuration, bool hasControlKey)
    {
        ArgumentNullException.ThrowIfNull(configuration);

        string serverId = configuration["Battle:ServerId"] ?? "local-1";
        if (!Regex.IsMatch(serverId, @"\A[a-zA-Z0-9-]{1,64}\z"))
            throw new InvalidDataException("Invalid Battle__ServerId.");

        string bindText = configuration["Battle:BindAddress"] ?? "127.0.0.1";
        if (!IPAddress.TryParse(bindText, out IPAddress? bindAddress))
            throw new InvalidDataException("Invalid Battle__BindAddress.");

        string publicHost = configuration["Battle:PublicHost"] ?? "127.0.0.1";
        if (Uri.CheckHostName(publicHost) == UriHostNameType.Unknown)
            throw new InvalidDataException("Invalid Battle__PublicHost.");

        string? manifestPath = OptionalPath(configuration, "Battle:MatchManifestPath");
        string? manifestDirectory = OptionalPath(configuration,
            "Battle:MatchManifestDirectory");
        if (manifestPath != null && manifestDirectory != null)
            throw new InvalidDataException(
                "Choose a single manifest or a manifest directory.");

        string? combatPath = OptionalPath(configuration,
            "Battle:CombatContentManifestPath");
        string? shotgunPath = OptionalPath(configuration,
            "Battle:ShotgunContentManifestPath");
        string? smgPath = OptionalPath(configuration,
            "Battle:SmgContentManifestPath");
        string? pistolPath = OptionalPath(configuration,
            "Battle:PistolContentManifestPath");
        string? lmgPath = OptionalPath(configuration,
            "Battle:LmgContentManifestPath");
        string? minigunPath = OptionalPath(configuration,
            "Battle:MinigunContentManifestPath");
        string? sniperPath = OptionalPath(configuration,
            "Battle:SniperContentManifestPath");
        string? bazookaPath = OptionalPath(configuration,
            "Battle:BazookaContentManifestPath");
        string? grenadePath = OptionalPath(configuration,
            "Battle:GrenadeContentManifestPath");
        if (combatPath == null && new[]
            {
                shotgunPath, smgPath, pistolPath, lmgPath,
                minigunPath, sniperPath, bazookaPath, grenadePath
            }.Any(path => path != null))
            throw new InvalidDataException(
                "Weapon content requires the pinned combat package.");

        string? configuredOutbox = configuration["Battle:ResultOutboxPath"];
        if (configuredOutbox != null &&
            string.IsNullOrWhiteSpace(configuredOutbox))
            throw new InvalidDataException("Invalid Battle__ResultOutboxPath.");
        string outboxPath = configuredOutbox ??
            Path.Combine(AppContext.BaseDirectory, "battle-outbox");
        outboxPath = Path.GetFullPath(outboxPath);

        return new BattleWorkerSettings(
            serverId, bindAddress, publicHost, manifestPath, manifestDirectory,
            combatPath, shotgunPath, smgPath, pistolPath, lmgPath,
            minigunPath, sniperPath, bazookaPath, grenadePath,
            OptionalPath(configuration, "Battle:ContentPath"), outboxPath,
            ReadEndpoint(configuration, "Battle:BackendResultEndpoint", hasControlKey),
            ReadEndpoint(configuration, "Battle:BackendAllocationEndpoint", hasControlKey));
    }

    private static string? OptionalPath(IConfiguration configuration, string key)
    {
        string? value = configuration[key];
        return string.IsNullOrEmpty(value) ? null : value;
    }

    private static Uri? ReadEndpoint(IConfiguration configuration,
        string key, bool hasControlKey)
    {
        string? value = configuration[key];
        if (value == null || value.Length == 0)
            return null;
        if (string.IsNullOrWhiteSpace(value) || value != value.Trim() ||
            !hasControlKey ||
            !Uri.TryCreate(value, UriKind.Absolute,
                out Uri? endpoint) || endpoint.Scheme is not ("http" or "https"))
            throw new InvalidDataException(
                $"{key} requires an HTTP endpoint and a control key.");
        return endpoint;
    }
}

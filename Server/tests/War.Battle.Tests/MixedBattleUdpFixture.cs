using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text.Json;
using Google.Protobuf;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using War.BattleServer;
using War.Client;
using War.Protocol;
using War.Shared;

/// <summary>Owns an isolated mixed Worker and grants for source-starter UDP integration tests.</summary>
internal sealed class MixedBattleUdpFixture : IAsyncDisposable
{
    private const int SigningKeyBytes = 32;
    private const int GrantLifetimeSeconds = 120;
    private static readonly string[] ContentPackages =
    ["Combat", "Shotgun", "Smg", "Pistol", "Lmg", "Minigun", "Sniper", "Bazooka", "Grenade"];
    private readonly NetworkWorker _worker;
    private readonly MatchTokens _tokens;
    private readonly int _port;

    internal BattleCombatContent Content { get; }

    internal MatchManifest Manifest { get; }

    internal string RunDirectory { get; }

    internal MixedBattleUdpFixture(string directory)
    {
        Content = BattleArmyManifestProjectionTests.LoadContent(directory);
        MatchManifest starter = MixedGrenadeActorTests.CreateStarterManifest(Content, directory);
        Manifest = MatchManifest.Validate(starter with
        {
            MatchId = "mixed-udp-" + Guid.NewGuid().ToString("N"),
            Allocations = starter.Players.Select(player => new BattleAllocationProjection(player.PlayerId, [], [],
                player.ArmyNormalUpgradeIndexes!, player.ArmySpecialUpgradeIndexes!, player.ArmyEliteUpgradeIndexes!))
                .ToArray()
        });
        RunDirectory = Path.Combine(Path.GetDirectoryName(Path.GetFullPath(directory))!, ".local",
            "mixed-grenade-udp-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(RunDirectory);
        string manifestPath = Path.Combine(RunDirectory, "manifest.json");
        File.WriteAllBytes(manifestPath, JsonSerializer.SerializeToUtf8Bytes(Manifest));
        _port = ReservePort();
        string signingKey = Convert.ToBase64String(RandomNumberGenerator.GetBytes(SigningKeyBytes));
        _tokens = new MatchTokens(signingKey);
        _worker = new NetworkWorker(CreateConfiguration(directory, manifestPath, signingKey),
            NullLogger<NetworkWorker>.Instance);
    }

    internal Task StartAsync(CancellationToken cancellationToken)
    {
        return _worker.StartAsync(cancellationToken);
    }

    internal MatchConnection CreateConnection(string playerId, ulong sessionId)
    {
        if (!Manifest.Players.Any(player => player.PlayerId == playerId))
        {
            throw new InvalidDataException("The test grant participant is absent from the trusted manifest.");
        }
        long now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        var admission = new MatchAdmission
        {
            MatchId = Manifest.MatchId, ServerId = Manifest.ServerId, PlayerId = playerId, SessionId = sessionId,
            ManifestHash = Manifest.Digest(), IssuedUnixSeconds = now, ExpiresUnixSeconds = now + GrantLifetimeSeconds
        };
        return new MatchConnection(new MatchConnectionGrant
        {
            Host = "127.0.0.1", Port = (uint)_port, MatchId = admission.MatchId, PlayerId = playerId,
            SessionId = sessionId, ManifestHash = admission.ManifestHash,
            ExpiresUnixSeconds = admission.ExpiresUnixSeconds,
            Ticket = _tokens.Sign(admission), SessionKey = ByteString.CopyFrom(_tokens.SessionKey(admission))
        });
    }

    /// <summary>Stops and disposes only this fixture's Worker; retained artifacts stay under Server/.local.</summary>
    public async ValueTask DisposeAsync()
    {
        try
        {
            await _worker.StopAsync(CancellationToken.None);
        }
        finally
        {
            _worker.Dispose();
        }
    }

    private IConfiguration CreateConfiguration(string directory, string manifestPath, string signingKey)
    {
        var values = new Dictionary<string, string?>
        {
            ["Battle:SigningKey"] = signingKey,
            ["Battle:ServerId"] = Manifest.ServerId,
            ["Battle:BindAddress"] = "127.0.0.1",
            ["Battle:Port"] = _port.ToString(CultureInfo.InvariantCulture),
            ["Battle:MatchManifestPath"] = manifestPath,
            ["Battle:ResultOutboxPath"] = Path.Combine(RunDirectory, "outbox")
        };
        foreach (string package in ContentPackages)
        {
            values["Battle:" + package + "ContentManifestPath"] = Path.Combine(directory,
                package.ToLowerInvariant() + "-content-manifest.json");
        }
        return new ConfigurationBuilder().AddInMemoryCollection(values).Build();
    }

    private static int ReservePort()
    {
        using var probe = new UdpClient(new IPEndPoint(IPAddress.Loopback, 0));
        return ((IPEndPoint)probe.Client.LocalEndPoint!).Port;
    }
}

using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text.Json;
using Google.Protobuf;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using War.BattleServer;
using War.Protocol;

/// <summary>Runs the production UDP Worker together with the disposable recovered Unity Editor.</summary>
internal static class LiveBazookaUnityTests
{
    private const string M202 = "Google2u.Bazooka_M202";
    private const string Rpg = "Google2u.Bazooka_RPG7";
    private const int M202InventoryIndex = 42;
    private const int RpgInventoryIndex = 3;
    private const int GrantSeconds = (int)MatchTokens.GrantLifetimeSeconds;
    private const int EditorTimeoutSeconds = 110;
    private const int FixtureBattleSeconds = 90;
    private const int FixtureHealth = 100_000;
    private const int RpgSlot = 2;
    private const ulong LocalSessionId = 4001;
    private const ulong PeerSessionId = 4002;
    private const string SuccessMarker = "UNITY_LIVE_BAZOOKA_PASSED";
    private const string PlaySuccessMarker = "UNITY_LIVE_BAZOOKA_PLAY_PASSED";

    internal static Task RunAsync(string directory, string unityExecutable, string projectPath)
    {
        return RunModeAsync(directory, unityExecutable, projectPath, AuditMode.EditorComponents);
    }

    internal static Task RunPlayModeAsync(string directory, string unityExecutable, string projectPath)
    {
        return RunModeAsync(directory, unityExecutable, projectPath, AuditMode.PlayMode);
    }

    private static async Task RunModeAsync(
        string directory, string unityExecutable, string projectPath, AuditMode mode)
    {
        ValidateProject(unityExecutable, projectPath, mode);

        string runDirectory = Path.GetFullPath(Path.Combine(directory, "../.local/bazooka-live-" +
            Guid.NewGuid().ToString("N")));
        Directory.CreateDirectory(runDirectory);
        BattleCombatContent content = BattleCombatContent.Load(
            Path.Combine(directory, "combat-content-manifest.json"),
            bazookaManifestPath: Path.Combine(directory, "bazooka-content-manifest.json"));
        MatchManifest manifest = CreateManifest(directory, content);
        string manifestFile = Path.Combine(runDirectory, "manifest.json");
        string grantsFile = Path.Combine(runDirectory, "grants.jsonl");
        string unityLog = Path.Combine(runDirectory, "unity.log");
        await File.WriteAllTextAsync(manifestFile, JsonSerializer.Serialize(manifest));
        using var probe = new UdpClient(new IPEndPoint(IPAddress.Loopback, 0));
        int port = ((IPEndPoint)probe.Client.LocalEndPoint!).Port;
        probe.Close();
        string key = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
        var tokens = new MatchTokens(key);
        IConfiguration config = CreateConfiguration(directory, runDirectory, key, port);
        using var worker = new NetworkWorker(config, NullLogger<NetworkWorker>.Instance);
        Process? editor = null;
        try
        {
            await worker.StartAsync(CancellationToken.None);
            await File.WriteAllLinesAsync(grantsFile, manifest.Players.Select(player =>
                JsonFormatter.Default.Format(CreateGrant(manifest, port, tokens, player.PlayerId))));
            string method = mode == AuditMode.PlayMode ? "UnityLiveBazookaPlayAudit.Run" : "UnityLiveBazookaAudit.Run";
            editor = StartEditor(unityExecutable, projectPath, grantsFile, new EditorInvocation(unityLog, method));
            using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(EditorTimeoutSeconds));
            await editor.WaitForExitAsync(timeout.Token);
            string marker = mode == AuditMode.PlayMode ? PlaySuccessMarker : SuccessMarker;
            if (editor.ExitCode != 0 || !File.ReadAllText(unityLog).Contains(marker, StringComparison.Ordinal))
            {
                throw new Exception("Live Unity bazooka presentation failed; inspect " + unityLog);
            }

            Console.WriteLine("PASS: live Worker/SDK/Unity bazooka " + mode + "; " + unityLog);
        }
        finally
        {
            if (editor != null)
            {
                if (!editor.HasExited)
                {
                    editor.Kill(true);
                }

                editor.Dispose();
            }

            await worker.StopAsync(CancellationToken.None);
            File.Delete(grantsFile);
        }
    }

    private static void ValidateProject(string unityExecutable, string projectPath, AuditMode mode)
    {
        if (!File.Exists(unityExecutable))
        {
            throw new FileNotFoundException("The native Unity executable was not found.");
        }

        string[] sharedTools =
        [
            "UnityLiveBazookaAudit",
            "UnityLiveBazookaObservation",
            "UnityLiveBazookaRigs",
            "UnityLiveBazookaEffectObservation",
            "UnityBazookaEffectFixture"
        ];
        foreach (string tool in sharedTools)
        {
            RequireEditorTool(projectPath, tool);
        }

        if (mode == AuditMode.PlayMode)
        {
            foreach (string tool in new[] { "UnityLiveBazookaPlayAudit", "UnityLiveBazookaPlayScene" })
            {
                RequireEditorTool(projectPath, tool);
            }
        }
    }

    private static void RequireEditorTool(string projectPath, string name)
    {
        if (!File.Exists(Path.Combine(projectPath, "Assets/Editor", name + ".cs")))
        {
            throw new FileNotFoundException("Prepare the disposable Unity source tool: " + name);
        }
    }

    private static MatchManifest CreateManifest(string directory, BattleCombatContent content)
    {
        MatchManifest template = MatchManifest.Read(Path.Combine(directory, "local-rifle-match-template.json"));
        WeaponManifest m202 = content.Bazookas!.CreateManifest(M202, 0);
        WeaponManifest rpg = content.Bazookas.CreateManifest(Rpg, 0);
        return template with
        {
            MatchId = "bazooka-unity-" + Guid.NewGuid().ToString("N"),
            Mode = MatchManifest.BazookaCombatMode,
            CatalogRevision = content.BazookaRevision!,
            SceneMasterPlayerId = template.Players[0].PlayerId,
            AdmissionSeconds = GrantSeconds,
            DurationSeconds = FixtureBattleSeconds,
            Players = template.Players.Select(player => player with
            {
                Weapon = m202, WeaponUpgrade = 0, PlayerLevel = 0,
                // This unscored visual fixture must survive until all flight/impact observations finish.
                Combat = new PlayerCombatManifest(FixtureHealth),
                WeaponSlots = [new(0, M202InventoryIndex, m202, 0), new(RpgSlot, RpgInventoryIndex, rpg, 0)]
            }).ToArray()
        };
    }

    private static MatchConnectionGrant CreateGrant(
        MatchManifest manifest, int port, MatchTokens tokens, string playerId)
    {
        bool isLocal = playerId == manifest.Players[0].PlayerId;
        long now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        var admission = new MatchAdmission
        {
            MatchId = manifest.MatchId, ServerId = manifest.ServerId, ManifestHash = manifest.Digest(),
            PlayerId = playerId, SessionId = isLocal ? LocalSessionId : PeerSessionId,
            IssuedUnixSeconds = now, ExpiresUnixSeconds = now + GrantSeconds
        };
        var grant = new MatchConnectionGrant
        {
            MatchId = admission.MatchId, ManifestHash = admission.ManifestHash,
            Host = "127.0.0.1", Port = (uint)port, PlayerId = playerId, SessionId = admission.SessionId,
            ExpiresUnixSeconds = admission.ExpiresUnixSeconds,
            Ticket = tokens.Sign(admission), SessionKey = ByteString.CopyFrom(tokens.SessionKey(admission))
        };
        foreach (ParticipantManifest player in manifest.Players)
        {
            var view = new BattlePlayerView
            {
                PlayerId = player.PlayerId, DisplayName = "BazookaAudit", Level = 1,
                ArmyPower = 1, Country = "US", Fraction = player.Fraction, DefendPosition = 0
            };
            view.VisualIds.Add(["v0", "v1", "v2", "v3"]);
            view.Weapons.Add(new BattleWeaponView { Slot = 0, WeaponIndex = M202InventoryIndex, SourceId = M202 });
            view.Weapons.Add(new BattleWeaponView { Slot = RpgSlot, WeaponIndex = RpgInventoryIndex, SourceId = Rpg });
            grant.PlayerViews.Add(view);
        }

        return grant;
    }

    private static IConfiguration CreateConfiguration(string directory, string runDirectory, string key, int port)
    {
        return new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string, string?>
        {
            ["Battle:SigningKey"] = key, ["Battle:ServerId"] = "local-1", ["Battle:Port"] = port.ToString(),
            ["Battle:MatchManifestPath"] = Path.Combine(runDirectory, "manifest.json"),
            ["Battle:CombatContentManifestPath"] = Path.Combine(directory, "combat-content-manifest.json"),
            ["Battle:BazookaContentManifestPath"] = Path.Combine(directory, "bazooka-content-manifest.json"),
            ["Battle:ResultOutboxPath"] = Path.Combine(runDirectory, "outbox")
        }).Build();
    }

    private static Process StartEditor(
        string executable, string projectPath, string grantsFile, EditorInvocation invocation)
    {
        var start = new ProcessStartInfo(executable)
        {
            UseShellExecute = false, CreateNoWindow = true, WindowStyle = ProcessWindowStyle.Hidden
        };
        foreach (string argument in new[] { "-batchmode", "-nographics", "-noUpm", "-projectPath", projectPath,
            "-executeMethod", invocation.MethodName, "-logFile", invocation.LogFile })
        {
            start.ArgumentList.Add(argument);
        }

        start.Environment["WAR_BAZOOKA_LIVE_GRANTS_FILE"] = grantsFile;
        return Process.Start(start) ?? throw new Exception("Unity did not start.");
    }

    private enum AuditMode
    {
        EditorComponents,
        PlayMode
    }

    private sealed record EditorInvocation(string LogFile, string MethodName);
}

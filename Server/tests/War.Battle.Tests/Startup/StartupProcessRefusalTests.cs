using System.Diagnostics;
using System.Reflection;

namespace War.Battle.Tests.Startup;

/// <summary>Real entry points must refuse bad policy before database selection or durable Worker creation.</summary>
internal static class StartupProcessRefusalTests
{
    private const int ExitDeadlineSeconds = 15;
    private sealed record Refusal(string Project, string Setting, string Value, string Expected);
    private static readonly string SigningKey = Convert.ToBase64String(Enumerable.Repeat((byte)1, 32).ToArray());
    private static readonly string ControlKey = Convert.ToBase64String(Enumerable.Repeat((byte)2, 32).ToArray());

    internal static async Task<int> RunAsync()
    {
        string zeroKey = Convert.ToBase64String(new byte[32]);
        Refusal[] cases =
        [
            new("War.Backend", "Battle__SigningKey", zeroKey, "Battle signing key"),
            new("War.Backend", "Battle__ControlKey", SigningKey, "must differ"),
            new("War.Backend", "Battle__Port", "1023", "Battle:Port"),
            new("War.Backend", "Battle__ControlPort", "30000", "Battle:ControlPort"),
            new("War.Backend", "RateLimiting__Api__PermitLimit", "0", "RateLimiting:Api"),
            new("War.Backend", "RateLimiting__Auth__WindowSeconds", "86401", "RateLimiting:Auth"),
            new("War.Backend", "Legacy__AllowCatalogFreeStartup", "false", "Legacy:ContentPath"),
            new("War.Backend", "Legacy__ContentPath", "missing-startup-catalog.json", "Legacy:ContentPath"),
            new("War.Backend", "Battle__MatchmakingCompatibilityKey", "reviewed", "MatchManifestTemplatePath"),
            new("War.Backend", "Mongo__Uri", "invalid://user:probe-password@localhost", "Mongo:Uri"),
            new("War.Backend", "Mongo__Database", "bad-name", "Mongo:Database"),
            new("War.Backend", "Mongo__Database", new string('a', 65), "Mongo:Database"),
            new("War.BattleServer", "Battle__SigningKey", zeroKey, "Battle signing key"),
            new("War.BattleServer", "Battle__ControlKey", SigningKey, "must differ"),
            new("War.BattleServer", "Battle__Port", "1023", "Battle:Port"),
            new("War.BattleServer", "Battle__ControlPort", "30000", "Battle:ControlPort"),
            new("War.BattleServer", "Battle__BackendResultEndpoint", "http://localhost/result?x=1",
                "Battle:BackendResultEndpoint")
        ];
        string directory = Directory.CreateTempSubdirectory("warfriends-startup-process-").FullName;
        for (int index = 0; index < cases.Length; index++)
        {
            await CheckRefusalAsync(cases[index], directory, index);
        }
        Require(!Directory.Exists(Path.Combine(directory, "outbox")),
            "Invalid Worker configuration created its durable outbox.");
        Console.WriteLine("Startup refusal reports: " + directory);
        return cases.Length;
    }

    private static async Task CheckRefusalAsync(Refusal refusal, string directory, int index)
    {
        ProcessStartInfo start = CreateStartInfo(refusal.Project, directory);
        start.Environment[refusal.Setting] = refusal.Value;
        using var process = new Process { StartInfo = start };
        Require(process.Start(), "The owned startup-refusal process did not start.");
        Task<string> stdout = process.StandardOutput.ReadToEndAsync();
        Task<string> stderr = process.StandardError.ReadToEndAsync();
        using var deadline = new CancellationTokenSource(TimeSpan.FromSeconds(ExitDeadlineSeconds));
        try
        {
            await process.WaitForExitAsync(deadline.Token);
        }
        catch (OperationCanceledException)
        {
            process.Kill(entireProcessTree: true);
            await process.WaitForExitAsync(CancellationToken.None);
            throw new InvalidOperationException("Startup policy reached a blocking database/listener path.");
        }

        string output = await stdout + await stderr;
        await File.WriteAllTextAsync(Path.Combine(directory, index.ToString("D2") + ".log"), output);
        Require(process.ExitCode == 1 && output.Contains("startup configuration rejected:", StringComparison.Ordinal) &&
            output.Contains(refusal.Expected, StringComparison.Ordinal),
            "A real entry point did not reject the configured invalid setting: " + refusal.Setting);
        Require(!output.Contains("probe-password", StringComparison.Ordinal) &&
            !output.Contains("MongoDB.Driver", StringComparison.Ordinal),
            "A rejected setting reached driver authority or exposed URI credentials.");
    }

    private static ProcessStartInfo CreateStartInfo(string project, string directory)
    {
        string configuration = typeof(StartupProcessRefusalTests).Assembly
            .GetCustomAttribute<AssemblyConfigurationAttribute>()!.Configuration;
        string server = BackendStartupPolicyTests.FindServerDirectory();
        string projectDirectory = Path.Combine(server, "src", project);
        string dll = Path.Combine(projectDirectory, "bin", configuration, "net10.0", project + ".dll");
        var start = new ProcessStartInfo("dotnet")
        {
            UseShellExecute = false,
            CreateNoWindow = true,
            WindowStyle = ProcessWindowStyle.Hidden,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            WorkingDirectory = projectDirectory
        };
        start.ArgumentList.Add(dll);
        string[] prefixes = ["Battle__", "Legacy__", "Mongo__", "RateLimiting__"];
        foreach (string key in start.Environment.Keys.Where(key =>
            prefixes.Any(prefix => key.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))).ToArray())
        {
            start.Environment.Remove(key);
        }
        ConfigureBaseline(start, directory);
        return start;
    }

    private static void ConfigureBaseline(ProcessStartInfo start, string directory)
    {
        start.Environment["ASPNETCORE_ENVIRONMENT"] = "Production";
        start.Environment["ASPNETCORE_URLS"] = "http://127.0.0.1:0";
        start.Environment["Battle__SigningKey"] = SigningKey;
        start.Environment["Battle__ControlKey"] = ControlKey;
        start.Environment["Battle__ResultOutboxPath"] = Path.Combine(directory, "outbox");
        start.Environment["Legacy__AllowCatalogFreeStartup"] = "true";
        // Any accidental database initialization must exceed our deadline; no mongod fixture is started.
        start.Environment["Mongo__Uri"] = "mongodb://127.0.0.1:1/?serverSelectionTimeoutMS=600000";
        start.Environment["DOTNET_DbgEnableMiniDump"] = "0";
        start.Environment["COMPlus_DbgEnableMiniDump"] = "0";
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}

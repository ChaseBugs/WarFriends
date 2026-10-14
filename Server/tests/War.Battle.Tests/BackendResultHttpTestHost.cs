using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;

/// <summary>Starts the real Backend executable for an isolated result test.</summary>
internal sealed class BackendResultHttpTestHost : IDisposable
{
    private readonly Process process;
    private readonly Task<string> errorOutput;
    private readonly Task<string> standardOutput;
    internal byte[] ControlKey { get; }
    internal Uri Endpoint { get; }

    private BackendResultHttpTestHost(Process process, byte[] controlKey, Uri endpoint)
    {
        this.process = process;
        ControlKey = controlKey;
        Endpoint = endpoint;
        errorOutput = process.StandardError.ReadToEndAsync();
        standardOutput = process.StandardOutput.ReadToEndAsync();
    }

    internal static async Task<BackendResultHttpTestHost> Start(
        string contentDirectory, string mongoUri, string database)
    {
        string serverRoot = Directory.GetParent(contentDirectory)!.FullName;
        string dll = Path.Combine(serverRoot, "src/War.Backend/bin/Release/net10.0/War.Backend.dll");
        var probe = new TcpListener(IPAddress.Loopback, 0);
        probe.Start();
        int port = ((IPEndPoint)probe.LocalEndpoint).Port;
        probe.Stop();
        string baseUrl = $"http://127.0.0.1:{port}/";
        byte[] controlKey = RandomNumberGenerator.GetBytes(32);
        var start = new ProcessStartInfo("dotnet")
        {
            UseShellExecute = false, CreateNoWindow = true,
            WindowStyle = ProcessWindowStyle.Hidden,
            WorkingDirectory = Path.GetDirectoryName(dll)!,
            RedirectStandardOutput = true, RedirectStandardError = true
        };
        start.ArgumentList.Add(dll);
        var environment = new Dictionary<string, string>
        {
            ["ASPNETCORE_ENVIRONMENT"] = "Development",
            ["ASPNETCORE_URLS"] = baseUrl,
            ["Mongo__Uri"] = mongoUri, ["Mongo__Database"] = database,
            ["Battle__SigningKey"] = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32)),
            ["Battle__ControlKey"] = Convert.ToBase64String(controlKey),
            ["Battle__ServerId"] = "local-1", ["Battle__PublicHost"] = "127.0.0.1",
            ["Battle__MatchmakingCompatibilityKey"] = "unscored-rifle.fixture",
            ["Battle__MatchManifestTemplatePath"] = Path.Combine(contentDirectory, "local-rifle-match-template.json"),
            ["Battle__CombatContentManifestPath"] = Path.Combine(contentDirectory, "combat-content-manifest.json")
        };
        foreach (var item in environment) start.Environment[item.Key] = item.Value;
        var process = Process.Start(start) ?? throw new Exception("Backend did not start.");
        var host = new BackendResultHttpTestHost(process, controlKey,
            new Uri(baseUrl + "internal/battle/results/accept"));
        try
        {
            using var http = new HttpClient { Timeout = TimeSpan.FromSeconds(1) };
            var startup = Stopwatch.StartNew();
            while (startup.Elapsed < TimeSpan.FromMinutes(3))
            {
                if (process.HasExited)
                    throw new Exception("Backend stopped during startup: " + await host.errorOutput);
                try
                {
                    using var response = await http.GetAsync(baseUrl + "health/ready");
                    if (response.IsSuccessStatusCode) return host;
                }
                catch (HttpRequestException) { }
                catch (TaskCanceledException) { }
                await Task.Delay(100);
            }
            throw new Exception("Backend result test host did not become ready.");
        }
        catch (Exception error)
        {
            host.Dispose();
            string output = await host.standardOutput;
            string errors = await host.errorOutput;
            throw new Exception("Backend result test startup failed. " + output + errors, error);
        }
    }

    public void Dispose()
    {
        if (!process.HasExited)
        {
            process.Kill(entireProcessTree: true);
            process.WaitForExit(5000);
        }
        process.Dispose();
    }
}

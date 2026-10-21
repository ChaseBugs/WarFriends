using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using Microsoft.Extensions.Configuration;

/// <summary>Starts a fresh native Worker against the previous host's durable spool.</summary>
internal sealed class WorkerResultRecoveryProcess : IDisposable
{
    private readonly Process process;
    private readonly Task<string> output;
    private readonly Task<string> errors;

    private WorkerResultRecoveryProcess(Process process)
    {
        this.process = process;
        output = process.StandardOutput.ReadToEndAsync();
        errors = process.StandardError.ReadToEndAsync();
    }

    internal static async Task<WorkerResultRecoveryProcess> Start(
        string contentDirectory, IConfiguration configuration, CancellationToken cancellationToken)
    {
        string root = Directory.GetParent(contentDirectory)!.FullName;
        string dll = Path.Combine(root, "src/War.BattleServer/bin/Release/net10.0/War.BattleServer.dll");
        var probe = new TcpListener(IPAddress.Loopback, 0);
        probe.Start();
        int controlPort = ((IPEndPoint)probe.LocalEndpoint).Port;
        probe.Stop();
        var start = new ProcessStartInfo("dotnet")
        {
            UseShellExecute = false, CreateNoWindow = true,
            WindowStyle = ProcessWindowStyle.Hidden,
            WorkingDirectory = Path.GetDirectoryName(dll)!,
            RedirectStandardOutput = true, RedirectStandardError = true
        };
        start.ArgumentList.Add(dll);
        foreach (var value in configuration.AsEnumerable())
            if (value.Value != null) start.Environment[value.Key.Replace(":", "__")] = value.Value;
        start.Environment["Battle__ControlPort"] = controlPort.ToString();
        start.Environment["Battle__BindAddress"] = "127.0.0.1";
        // A terminal match must not be registered again on startup. The new
        // host only drains the existing spool and validates its journal.
        start.Environment.Remove("Battle__MatchManifestPath");
        start.Environment.Remove("Battle__MatchManifestDirectory");
        var process = Process.Start(start) ?? throw new Exception("Recovery Worker did not start.");
        var host = new WorkerResultRecoveryProcess(process);
        try
        {
            using var http = new HttpClient { Timeout = TimeSpan.FromSeconds(1) };
            var startup = Stopwatch.StartNew();
            while (startup.Elapsed < TimeSpan.FromSeconds(25))
            {
                cancellationToken.ThrowIfCancellationRequested();
                if (process.HasExited) throw new Exception("Recovery Worker exited during startup.");
                try
                {
                    using var response = await http.GetAsync(
                        $"http://127.0.0.1:{controlPort}/health/ready", cancellationToken);
                    if (response.IsSuccessStatusCode) return host;
                }
                catch (HttpRequestException) { }
                catch (TaskCanceledException) when (!cancellationToken.IsCancellationRequested) { }
                await Task.Delay(100, cancellationToken);
            }
            throw new Exception("Recovery Worker did not become ready.");
        }
        catch (Exception error)
        {
            host.Dispose();
            throw new Exception("Recovery Worker startup failed: " + await host.output + await host.errors, error);
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

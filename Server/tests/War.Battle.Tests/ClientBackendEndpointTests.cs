using System.Diagnostics;

/// <summary>Exercises the exact Unity endpoint source in isolated process configuration snapshots.</summary>
internal static class ClientBackendEndpointTests
{
    private const string OverrideUrl = "http://127.0.0.1:18771/game/";
    private const string ConfiguredUrl = "https://self-hosted.example/client/";
    private const int ProcessTimeoutSeconds = 20;

    internal static async Task RunAsync()
    {
        await RunChildAsync("defaults", null);
        await RunChildAsync("override", OverrideUrl);
        await RunChildAsync("reject", "http://self-hosted.example/");
        Console.WriteLine(
            "PASS: shared Unity endpoint, local default, process override, invalid policy and frozen routing");
    }

    internal static void RunChild(string mode)
    {
        if (mode == "reject")
        {
            RequireRejected(() => SelfHostedBackendEndpoint.Resolve());
            return;
        }

        string expected = mode == "override" ? OverrideUrl : SelfHostedBackendEndpoint.DefaultBackendUrl;
        Require(SelfHostedBackendEndpoint.Resolve().AbsoluteUri == expected, "The process endpoint differs.");
        Require(SelfHostedBackendEndpoint.GetLegacyActionUrl() == expected + "index_09_25_2015.php",
            "The recovered action filename or Backend prefix changed.");
        Environment.SetEnvironmentVariable(
            SelfHostedBackendEndpoint.EnvironmentVariableName, "http://changed.example/");
        Require(SelfHostedBackendEndpoint.Resolve().AbsoluteUri == expected, "Routing changed after first use.");
        if (mode == "override")
        {
            Require(SelfHostedBackendEndpoint.Resolve(ConfiguredUrl).AbsoluteUri == expected,
                "The SDK's configured URL bypassed the common process override.");
            return;
        }

        Require(SelfHostedBackendEndpoint.Resolve(ConfiguredUrl).AbsoluteUri == ConfiguredUrl,
            "An absent override discarded explicit SDK configuration.");
        foreach (string malformed in new[]
        {
            "", "relative/", "ftp://127.0.0.1/", "http://self-hosted.example/",
            "https://user:password@self-hosted.example/", "https://self-hosted.example/path",
            "https://self-hosted.example/?query=value", "https://self-hosted.example/#fragment",
            " https://self-hosted.example/", "https://self-hosted.example/ "
        })
        {
            RequireRejected(() => SelfHostedBackendEndpoint.Resolve(malformed));
        }
    }

    private static async Task RunChildAsync(string mode, string? endpoint)
    {
        var start = new ProcessStartInfo("dotnet")
        {
            UseShellExecute = false,
            CreateNoWindow = true,
            WindowStyle = ProcessWindowStyle.Hidden
        };
        start.ArgumentList.Add(typeof(ClientBackendEndpointTests).Assembly.Location);
        start.ArgumentList.Add("--client-endpoint-process");
        start.ArgumentList.Add(mode);
        if (endpoint == null)
        {
            start.Environment.Remove(SelfHostedBackendEndpoint.EnvironmentVariableName);
        }
        else
        {
            start.Environment[SelfHostedBackendEndpoint.EnvironmentVariableName] = endpoint;
        }

        using var lifetime = new CancellationTokenSource(TimeSpan.FromSeconds(ProcessTimeoutSeconds));
        using Process process = Process.Start(start)
            ?? throw new InvalidOperationException("Endpoint probe did not start.");
        try
        {
            await process.WaitForExitAsync(lifetime.Token);
            Require(process.ExitCode == 0, "An isolated endpoint configuration probe failed: " + mode);
        }
        finally
        {
            if (!process.HasExited)
            {
                process.Kill(true);
                await process.WaitForExitAsync(CancellationToken.None);
            }
        }
    }

    private static void RequireRejected(Action resolve)
    {
        try
        {
            resolve();
        }
        catch (ArgumentException)
        {
            return;
        }

        throw new InvalidOperationException("Malformed endpoint policy selected a valid transport.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}

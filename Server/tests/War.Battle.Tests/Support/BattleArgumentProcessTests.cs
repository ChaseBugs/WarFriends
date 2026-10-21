using System.Diagnostics;

namespace War.Battle.Tests.Support;

internal static class BattleArgumentProcessTests
{
    private const int ExitDeadlineSeconds = 10;
    private const string OpaqueArgument = "probe-sensitive-value";

    internal static async Task<int> RunAsync()
    {
        CheckSharedEntryShapes();
        await CheckFocusedEntryAsync();
        Refusal[] refusals =
        [
            new("unknown", ["--missing-test-case"]),
            new("unknown-with-values", ["--missing-test-case", OpaqueArgument, OpaqueArgument]),
            new("focused-extra-value", ["--pvp-army-bullets-only", OpaqueArgument]),
            new("allocation-extra-value", ["--allocation-inventory-only", OpaqueArgument]),
            new("unity-no-paths", ["--unity"]),
            new("unity-one-path", ["--unity", OpaqueArgument]),
            new("unity-extra-path", ["--unity", OpaqueArgument, OpaqueArgument, OpaqueArgument]),
            new("unity-empty-executable", ["--unity", "", OpaqueArgument]),
            new("unity-blank-project", ["--unity", OpaqueArgument, " "]),
            new("unity-rifle-no-paths", ["--unity-rifle"]),
            new("unity-rifle-one-path", ["--unity-rifle", OpaqueArgument]),
            new("unity-rifle-extra-path", ["--unity-rifle", OpaqueArgument, OpaqueArgument, OpaqueArgument]),
            new("unity-rifle-blank-executable", ["--unity-rifle", " ", OpaqueArgument]),
            new("unity-rifle-empty-project", ["--unity-rifle", OpaqueArgument, ""]),
            new("worker-missing-url", ["--worker-control-http-only"]),
            new("store-missing-uri", ["--legacy-account-store-only"]),
            new("empty-selector", [""]),
            new("selector-case", ["--PVP-ARMY-BULLETS-ONLY"])
        ];
        foreach (Refusal refusal in refusals)
        {
            Require(!BattleSharedSuiteArguments.CanRunSharedSuite(refusal.Arguments),
                "Malformed shared entry accepted: " + refusal.Name);
            await CheckRefusalAsync(refusal);
        }
        return refusals.Length;
    }

    private static void CheckSharedEntryShapes()
    {
        string[][] allowed =
        [
            [],
            ["--allocation-inventory-only"],
            ["--unity", "Program Files/Unity.exe", "source project"],
            ["--unity-rifle", "Program Files/Unity.exe", "source project"]
        ];
        foreach (string[] arguments in allowed)
        {
            Require(BattleSharedSuiteArguments.CanRunSharedSuite(arguments),
                "An existing shared-suite entry shape was closed.");
        }
        Console.WriteLine("PASS: four existing shared-suite entry shapes remain accepted");
    }

    private static async Task CheckRefusalAsync(Refusal refusal)
    {
        ProcessResult result = await RunChildAsync(refusal.Arguments);
        Require(result.ExitCode == BattleSharedSuiteArguments.InvalidArgumentsExitCode &&
            result.Stdout == "" && result.Stderr == BattleSharedSuiteArguments.InvalidArgumentsMessage +
                Environment.NewLine,
            "Arguments were not refused with the exact safe diagnostic: " + refusal.Name);
        Require(!Directory.Exists(result.ScratchPath), "Rejected arguments created disposable data: " + refusal.Name);
    }

    private static async Task CheckFocusedEntryAsync()
    {
        ProcessResult result = await RunChildAsync(["--legacy-buffer-parser-only"]);
        Require(result.ExitCode == 0 && result.Stdout.Contains("PASS:", StringComparison.Ordinal) &&
            result.Stderr == "" && !Directory.Exists(result.ScratchPath),
            "A valid pure selector failed under the same isolated child environment.");
        Console.WriteLine("PASS: a real focused selector succeeds under the same child environment");
    }

    private static async Task<ProcessResult> RunChildAsync(string[] arguments)
    {
        string scratchPath = Path.Combine(Path.GetTempPath(),
            "warfriends-test-arguments-" + Guid.NewGuid().ToString("N"));
        using var process = new Process { StartInfo = CreateStartInfo(arguments, scratchPath) };
        Require(process.Start(), "The owned test-argument process did not start.");
        Task<string> stdout = process.StandardOutput.ReadToEndAsync();
        Task<string> stderr = process.StandardError.ReadToEndAsync();
        using var deadline = new CancellationTokenSource(TimeSpan.FromSeconds(ExitDeadlineSeconds));
        try
        {
            await process.WaitForExitAsync(deadline.Token);
        }
        catch (OperationCanceledException)
        {
            throw new InvalidOperationException("A test-argument child reached a long-running test path.");
        }
        finally
        {
            if (!process.HasExited)
            {
                process.Kill(entireProcessTree: true);
                await process.WaitForExitAsync(CancellationToken.None);
            }
        }

        return new(process.ExitCode, await stdout, await stderr, scratchPath);
    }

    private static ProcessStartInfo CreateStartInfo(string[] arguments, string scratchPath)
    {
        var start = new ProcessStartInfo("dotnet")
        {
            UseShellExecute = false,
            CreateNoWindow = true,
            WindowStyle = ProcessWindowStyle.Hidden,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            WorkingDirectory = AppContext.BaseDirectory
        };
        start.ArgumentList.Add(typeof(BattleArgumentProcessTests).Assembly.Location);
        foreach (string argument in arguments)
        {
            start.ArgumentList.Add(argument);
        }
        foreach (string name in new[] { "TEMP", "TMP", "TMPDIR" })
        {
            start.Environment[name] = scratchPath;
        }
        start.Environment["DOTNET_DbgEnableMiniDump"] = "0";
        start.Environment["COMPlus_DbgEnableMiniDump"] = "0";
        return start;
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }

    private sealed record Refusal(string Name, string[] Arguments);

    private sealed record ProcessResult(int ExitCode, string Stdout, string Stderr, string ScratchPath);
}

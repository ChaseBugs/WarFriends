using System.IO.Compression;
using System.Security.Cryptography;
using System.Text.Json;

using War.Shared;

/// <summary>Replays original warning frames, preserving first activation, reuse and strict float boundaries.</summary>
internal static class MortarIndicatorClockTests
{
    private const float Tolerance = 0.00001f;
    private const string ReferenceDigest = "9c58d7f96c0b7d7e3cb101f5eb0954313a14b37e326e13ac5265ee011bdfcc08";

    internal static int Run(string directory)
    {
        string path = Path.Combine(directory, "mortar-indicator-frames-unity-reference.json.gz");
        byte[] bytes = File.ReadAllBytes(path);
        int checks = Require(Convert.ToHexStringLower(SHA256.HashData(bytes)) == ReferenceDigest,
            "The frame reference changed without a reviewed native observation.");
        using var compressed = new MemoryStream(bytes);
        using var gzip = new GZipStream(compressed, CompressionMode.Decompress);
        using JsonDocument document = JsonDocument.Parse(gzip);
        JsonElement root = document.RootElement;
        checks += Require(root.GetProperty("captureRate").GetInt32() == 30 &&
            root.GetProperty("timeScale").GetSingle() == 1f &&
            root.GetProperty("scenarios").GetArrayLength() == 5,
            "The frame reference must retain all five source scenarios at the observed capture rate.");
        checks += CheckSourceHashes(directory, root);
        foreach (JsonElement scenario in root.GetProperty("scenarios").EnumerateArray())
        {
            checks += ReplayScenario(scenario);
        }
        return checks + RejectInvalidInputs();
    }

    private static int CheckSourceHashes(string directory, JsonElement root)
    {
        string repository = Directory.GetParent(directory)!.Parent!.FullName;
        int checks = 0;
        foreach (JsonElement row in root.GetProperty("sources").EnumerateArray())
        {
            string source = row.GetProperty("source").GetString()!;
            string relative = source.StartsWith("Assets/UnityMortarIndicator", StringComparison.Ordinal) ||
                source.StartsWith("Assets/Editor/UnityMortarIndicator", StringComparison.Ordinal)
                ? Path.Combine("Server/tools", Path.GetFileName(source))
                : Path.Combine("Clients/ExportedProject", source);
            string digest = Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(
                Path.Combine(repository, relative))));
            checks += Require(digest == row.GetProperty("sha256").GetString(),
                "The frame observation no longer matches its active source or probe.");
        }
        return checks;
    }

    private static int ReplayScenario(JsonElement scenario)
    {
        var clock = new MortarIndicatorClock();
        var shrinkFinished = new List<int>();
        var blinkFinished = new List<int>();
        int first = scenario.GetProperty("firstShotTick").GetInt32();
        int repeated = scenario.GetProperty("repeatedShotTick").GetInt32();
        int checks = Require(scenario.GetProperty("frames").GetArrayLength() == 241,
            "The native frame observation is incomplete.");
        foreach (JsonElement frame in scenario.GetProperty("frames").EnumerateArray())
        {
            int tick = frame.GetProperty("tick").GetInt32();
            if (tick == first || tick == repeated)
            {
                clock.BeginShot(scenario.GetProperty("stopSeconds").GetSingle());
            }
            bool wasShrinking = clock.IsShrinking;
            bool wasVisible = clock.IsVisible;
            clock.Advance(frame.GetProperty("deltaTime").GetSingle());
            if (wasShrinking && !clock.IsShrinking)
            {
                shrinkFinished.Add(tick);
            }
            if (wasVisible && !clock.IsVisible)
            {
                blinkFinished.Add(tick);
            }
            checks += CheckFrame(clock, frame, tick >= first, scenario.GetProperty("name").GetString()!);
        }
        checks += Require(shrinkFinished.SequenceEqual(scenario.GetProperty("shrinkFinished")
            .EnumerateArray().Select(row => row.GetInt32())) &&
            blinkFinished.SequenceEqual(scenario.GetProperty("blinkFinished")
                .EnumerateArray().Select(row => row.GetInt32())),
            "Warning completion callbacks differ from the source first/repeated-shot frame boundaries.");
        return checks;
    }

    private static int CheckFrame(MortarIndicatorClock clock, JsonElement frame, bool hasShot, string scenario)
    {
        int tick = frame.GetProperty("tick").GetInt32();
        string context = scenario + " at tick " + tick;
        int checks = Require(clock.IsVisible == frame.GetProperty("active").GetBoolean(),
            "Warning visibility differs from native " + context);
        if (!hasShot)
        {
            return checks;
        }
        checks += Require(clock.IsShrinking == frame.GetProperty("shrinkEnabled").GetBoolean() &&
            clock.IsBlinking == frame.GetProperty("blinkEnabled").GetBoolean(),
            "Warning phase ownership differs from native " + context);
        (string Name, float Actual)[] values =
        {
            ("scale", clock.Scale), ("alpha", clock.Alpha), ("rotationFactor", clock.RotationFactor),
            ("shrinkFactor", clock.ShrinkFactor), ("blinkFactor", clock.BlinkFactor)
        };
        foreach (var value in values)
        {
            checks += Require(MathF.Abs(value.Actual - frame.GetProperty(value.Name).GetSingle()) < Tolerance,
                "Warning " + value.Name + " differs from native " + context);
        }
        return checks;
    }

    private static int RejectInvalidInputs()
    {
        int checks = 0;
        foreach (float invalid in new[] { float.NaN, float.PositiveInfinity, float.NegativeInfinity, -1f, 1801f })
        {
            var clock = new MortarIndicatorClock();
            clock.BeginShot(2f);
            foreach (Action action in new Action[] { () => clock.BeginShot(invalid), () => clock.Advance(invalid) })
            {
                bool rejected = false;
                try
                {
                    action();
                }
                catch (ArgumentOutOfRangeException)
                {
                    rejected = true;
                }
                checks += Require(rejected && clock.IsVisible && clock.ShrinkFactor == 0f,
                    "A malformed warning clock input changed an active source phase.");
            }
        }
        return checks;
    }

    private static int Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
        return 1;
    }
}

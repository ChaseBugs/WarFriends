using System.IO.Compression;
using System.Security.Cryptography;
using System.Text.Json;

using War.Shared;

/// <summary>Replays original warning reuse and allied suppression independently for each observer.</summary>
internal static class MortarIndicatorReuseTests
{
    private const string ReferenceDigest = "c39711ff2007ee3ab629d7985fbf22c3f267ab8739ffa51e5007f1214b456cf7";
    private const float Tolerance = 0.00001f;

    internal static int Run(string directory)
    {
        byte[] bytes = File.ReadAllBytes(Path.Combine(directory, "mortar-indicator-reuse-unity-reference.json.gz"));
        int checks = Require(Convert.ToHexStringLower(SHA256.HashData(bytes)) == ReferenceDigest,
            "The native reuse observation changed without a reviewed source run.");
        using var compressed = new MemoryStream(bytes);
        using var gzip = new GZipStream(compressed, CompressionMode.Decompress);
        using JsonDocument document = JsonDocument.Parse(gzip);
        JsonElement root = document.RootElement;
        checks += Require(root.GetProperty("captureRate").GetInt32() == 30 &&
            root.GetProperty("timeScale").GetSingle() == 1f && root.GetProperty("scenarios").GetArrayLength() == 2,
            "Warning reuse requires both observed local fractions at the source capture rate.");
        checks += CheckSources(directory, root);
        foreach (JsonElement scenario in root.GetProperty("scenarios").EnumerateArray())
        {
            checks += Replay(scenario);
        }
        return checks + CheckOwnerGuards();
    }

    private static int CheckOwnerGuards()
    {
        var observer = new MortarIndicatorObserver(1);
        bool unboundRejected = false;
        try
        {
            observer.BeginShot(2f);
        }
        catch (InvalidOperationException)
        {
            unboundRejected = true;
        }
        int checks = Require(unboundRejected && !observer.IsVisible,
            "An unbound source weapon manufactured an opposing warning.");
        observer.AssignOwner(2);
        observer.BeginShot(2f);
        observer.Advance(1f / 30f);
        float factor = observer.ShrinkFactor;
        foreach (int invalid in new[] { -1, 0, 3, int.MaxValue })
        {
            bool rejected = false;
            try
            {
                observer.AssignOwner(invalid);
            }
            catch (ArgumentOutOfRangeException)
            {
                rejected = true;
            }
            checks += Require(rejected && observer.IsVisible && observer.ShrinkFactor == factor,
                "A malformed owner cleared an existing observer's source history.");
        }
        return checks;
    }

    private static int CheckSources(string directory, JsonElement root)
    {
        string repository = Directory.GetParent(directory)!.Parent!.FullName;
        int checks = 0;
        foreach (JsonElement row in root.GetProperty("sources").EnumerateArray())
        {
            string source = row.GetProperty("source").GetString()!;
            string relative = source.StartsWith("Assets/UnityMortarIndicatorReuse", StringComparison.Ordinal) ||
                source.StartsWith("Assets/Editor/UnityMortarIndicatorReuse", StringComparison.Ordinal)
                ? Path.Combine("Server/tools", Path.GetFileName(source))
                : Path.Combine("Clients/ExportedProject", source);
            string digest = Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(
                Path.Combine(repository, relative))));
            checks += Require(digest == row.GetProperty("sha256").GetString(),
                "A reuse source/probe differs from the active recovered Client or committed tool.");
        }
        return checks;
    }

    private static int Replay(JsonElement scenario)
    {
        int localFraction = scenario.GetProperty("localFraction").GetInt32();
        var observer = new MortarIndicatorObserver(localFraction);
        int[] reassignTicks = scenario.GetProperty("reassignTicks").EnumerateArray()
            .Select(value => value.GetInt32()).ToArray();
        int[] fireTicks = scenario.GetProperty("fireTicks").EnumerateArray()
            .Select(value => value.GetInt32()).ToArray();
        var shrinkFinished = new List<int>();
        var blinkFinished = new List<int>();
        bool hasOpposingShot = false;
        int checks = Require(scenario.GetProperty("frames").GetArrayLength() == 361,
            "The two-viewer reuse history is incomplete.");
        foreach (JsonElement frame in scenario.GetProperty("frames").EnumerateArray())
        {
            int tick = frame.GetProperty("tick").GetInt32();
            if (reassignTicks.Contains(tick))
            {
                observer.AssignOwner(frame.GetProperty("ownerFraction").GetInt32());
            }
            if (fireTicks.Contains(tick))
            {
                observer.BeginShot(scenario.GetProperty("stopSeconds").GetSingle());
                hasOpposingShot |= frame.GetProperty("ownerFraction").GetInt32() != localFraction;
            }
            bool wasShrinking = observer.IsShrinking;
            bool wasVisible = observer.IsVisible;
            observer.Advance(frame.GetProperty("deltaTime").GetSingle());
            if (wasShrinking && !observer.IsShrinking)
            {
                shrinkFinished.Add(tick);
            }
            if (wasVisible && !observer.IsVisible)
            {
                blinkFinished.Add(tick);
            }
            checks += CheckFrame(observer, frame, hasOpposingShot, localFraction);
        }
        checks += Require(shrinkFinished.SequenceEqual(scenario.GetProperty("shrinkFinished")
            .EnumerateArray().Select(value => value.GetInt32())) &&
            blinkFinished.SequenceEqual(scenario.GetProperty("blinkFinished")
                .EnumerateArray().Select(value => value.GetInt32())),
            "Reuse or allied suppression changed the observer's native callback history.");
        return checks;
    }

    private static int CheckFrame(MortarIndicatorObserver observer, JsonElement frame, bool hasShot, int localFraction)
    {
        string context = "viewer " + localFraction + " tick " + frame.GetProperty("tick").GetInt32();
        int checks = Require(frame.GetProperty("sameIndicatorObject").GetBoolean() &&
            observer.IsVisible == frame.GetProperty("active").GetBoolean(),
            "Reusing the original warning changed visibility or replaced its identity: " + context);
        if (!hasShot)
        {
            return checks;
        }
        checks += Require(observer.IsShrinking == frame.GetProperty("shrinkEnabled").GetBoolean() &&
            observer.IsBlinking == frame.GetProperty("blinkEnabled").GetBoolean(),
            "Reuse cleared a cached tween's enabled state: " + context);
        (string Name, float Actual)[] values =
        {
            ("scale", observer.Scale), ("alpha", observer.Alpha), ("rotationFactor", observer.RotationFactor),
            ("shrinkFactor", observer.ShrinkFactor), ("blinkFactor", observer.BlinkFactor)
        };
        foreach (var value in values)
        {
            checks += Require(MathF.Abs(value.Actual - frame.GetProperty(value.Name).GetSingle()) < Tolerance,
                "Reuse changed native " + value.Name + ": " + context);
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

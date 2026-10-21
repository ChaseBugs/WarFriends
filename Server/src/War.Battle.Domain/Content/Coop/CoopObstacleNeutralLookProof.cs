using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

/// <summary>Binds the isolated obstacle poses to a second source run with default procedural look enabled.</summary>
internal static class CoopObstacleNeutralLookProof
{
    internal const int ObservationVersion = 4;
    private const string FileName = "coop-obstacle-volley-neutral-look-reference.json";
    private const string ReviewedSha256 = "32f9d91dca9c0e712010327328c901c5add003cb7964a2c62c6b4c885e148738";
    private const int MaximumObservationBytes = 200000;
    private static readonly string[] SourceFields =
    [
        "client", "unity", "prefabSha256", "controllerSha256", "exporterSha256", "clips", "planSha256",
        "captureRate", "samplePhase", "roundInvocations", "observedReturnToCrawl"
    ];
    private static readonly string[] FrameFields =
    [
        "tick", "seconds", "scaledTime", "deadlineBeforeShot", "deadlineAfterShot", "roundInvoked",
        "muzzle", "states", "parts"
    ];

    internal static void Validate(string baselinePath, JsonElement baseline)
    {
        string path = Path.Combine(Path.GetDirectoryName(baselinePath)!, FileName);
        if (new FileInfo(path).Length > MaximumObservationBytes)
        {
            throw new InvalidDataException("The neutral-look observation is too large.");
        }

        byte[] bytes = File.ReadAllBytes(path);
        if (Convert.ToHexStringLower(SHA256.HashData(bytes)) != ReviewedSha256)
        {
            throw new InvalidDataException("The source neutral-look observation differs from the reviewed run.");
        }

        using JsonDocument document = JsonDocument.Parse(bytes);
        JsonElement neutral = document.RootElement;
        if (neutral.GetProperty("version").GetInt32() != ObservationVersion ||
            !neutral.GetProperty("proceduralLookEnabled").GetBoolean() ||
            baseline.GetProperty("proceduralLookEnabled").GetBoolean())
        {
            throw new InvalidDataException("The obstacle comparison must include both source look modes.");
        }

        CompareFields(baseline, neutral, SourceFields);
        CompareFrames(baseline.GetProperty("samples"), neutral.GetProperty("samples"));
    }

    private static void CompareFrames(JsonElement baseline, JsonElement neutral)
    {
        if (baseline.GetArrayLength() != neutral.GetArrayLength())
        {
            throw new InvalidDataException("The neutral-look observation has an incomplete frame window.");
        }

        for (int index = 0; index < baseline.GetArrayLength(); index++)
        {
            CompareFields(baseline[index], neutral[index], FrameFields);
        }
    }

    private static void CompareFields(JsonElement baseline, JsonElement neutral, IReadOnlyList<string> fields)
    {
        foreach (string field in fields)
        {
            // These paired captures use the same source plan and sampling phase; require exact recorded values.
            if (baseline.GetProperty(field).GetRawText() != neutral.GetProperty(field).GetRawText())
            {
                throw new InvalidDataException("Default neutral look changed the recorded source field: " + field);
            }
        }
    }
}

using System.IO.Compression;
using System.Text.Json;
using War.BattleServer;

/// <summary>Checks origin retention and sample identities against the independently generated source catalog.</summary>
internal static class CoopObstaclePreparationStartTests
{
    private const ulong CaptureTick = 1000;
    private const int FirstUnsupportedObservation = 13;

    internal static void Run(string directory, EnemyPoseCatalog poses)
    {
        float length = poses.Clip("stand_up_crawl").Length;
        using var compressed = new GZipStream(File.OpenRead(Path.Combine(directory,
            "coop-obstacle-fixed-step-pose-catalog.json.gz")), CompressionMode.Decompress);
        using JsonDocument catalog = JsonDocument.Parse(compressed);
        int checks = 0;
        foreach (JsonElement sample in catalog.RootElement.GetProperty("samples").EnumerateArray())
        {
            int phase = sample.GetProperty("priorReturnTicks").GetInt32();
            int step = sample.GetProperty("observationTick").GetInt32();
            ulong previousReturn = CaptureTick - (ulong)phase;
            CoopObstaclePreparationStart origin = CoopObstaclePreparationStart.FromReturn(CaptureTick,
                previousReturn, length);
            Require(origin.PreviousReturnTick == previousReturn && origin.PriorReturnTicks == phase &&
                origin.SelectSampleId(CaptureTick + (ulong)step) == sample.GetProperty("id").GetInt32(),
                "Captured source history must select the independent catalog identity.");
            Require(origin.SelectSampleId(CaptureTick + FirstUnsupportedObservation) == null,
                "Unobserved time must not extrapolate a pose sample.");
            checks++;
        }
        VerifyBoundaries(length);
        Console.WriteLine($"PASS: {checks} source-backed obstacle origin/sample identities and rejection boundaries");
    }

    private static void VerifyBoundaries(float length)
    {
        CoopObstaclePreparationStart completed = CoopObstaclePreparationStart.FromReturn(CaptureTick, 0, length);
        Require(completed.PreviousReturnTick == 0 && completed.PriorReturnTicks == 16 &&
            !completed.HasUnverifiedTransition, "Completed crawl must preserve its real epoch and canonical phase.");
        CoopObstaclePreparationStart unknown = CoopObstaclePreparationStart.Unresolved(CaptureTick, true);
        Require(unknown.HasUnverifiedTransition && unknown.SelectSampleId(CaptureTick) == null,
            "Unknown previous animation must not select fresh preparation.");
        Require(!CoopObstaclePreparationStart.Unresolved(CaptureTick, false).HasUnverifiedTransition,
            "An initial attempt must remain separate from an unresolved previous attempt.");
        Reject(() => CoopObstaclePreparationStart.FromReturn(0, 1, length));
        Reject(() => CoopObstaclePreparationStart.FromReturn(CaptureTick, CaptureTick - 2, length, CaptureTick - 1));
        Reject(() => CoopObstaclePreparationStart.Unresolved(0, true, 1));
        Reject(() => completed.SelectSampleId(CaptureTick - 1));
        Reject(() => CoopObstaclePreparationStart.Unresolved(CaptureTick, false, 0));
        Reject(() => CoopObstaclePreparationStart.Unresolved(CaptureTick, true, previousRoundTick: CaptureTick + 1));
        CoopObstaclePreparationStart previousFire = CoopObstaclePreparationStart.Unresolved(CaptureTick, true,
            previousRoundTick: CaptureTick - 1);
        Require(previousFire.PreviousRoundTick == CaptureTick - 1 && previousFire.HasUnverifiedTransition,
            "An unresolved previous fire must retain its confirmed round without selecting a fresh pose.");
        foreach (float invalid in new[] { float.NaN, float.PositiveInfinity, -1f, 0f, 0.6f })
        {
            Reject(() => CoopObstaclePreparationStart.FromReturn(CaptureTick, 0, invalid));
        }
    }

    private static void Reject(Action action)
    {
        try
        {
            action();
        }
        catch (InvalidDataException)
        {
            return;
        }
        throw new Exception("Malformed obstacle origin was accepted.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }
}

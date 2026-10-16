using System.Numerics;
using System.Text.Json;
using War.BattleServer;

/// <summary>Compares selected source poses with every actual controller frame and collider dimension.</summary>
internal static class CoopObstaclePoseCatalogTests
{
    private const float PositionTolerance = 0.00002f;
    private const float DimensionTolerance = 0.000002f;
    private const float RotationTolerance = 0.000001f;

    internal static void Run(string directory, BattleCombatContent content)
    {
        using JsonDocument observation = JsonDocument.Parse(File.ReadAllBytes(
            Path.Combine(directory, "coop-obstacle-volley-unity-reference.json")));
        using JsonDocument plan = JsonDocument.Parse(File.ReadAllBytes(
            Path.Combine(directory, "coop-obstacle-volley-source-plan.json")));
        JsonElement samples = observation.RootElement.GetProperty("samples");
        ulong[] rounds = plan.RootElement.GetProperty("roundTicks").EnumerateArray()
            .Select(value => value.GetUInt64()).ToArray();
        ulong crawlReturn = samples.EnumerateArray().First(frame =>
            frame.GetProperty("tick").GetUInt64() > rounds[^1] &&
            frame.GetProperty("states").EnumerateArray().Any(state =>
                state.GetProperty("name").GetString() == "stand_up_crawl"))
            .GetProperty("tick").GetUInt64();
        var position = new Vector3(2, 3, 4);
        Quaternion rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0.7f);
        int compared = 0;
        foreach (JsonElement frame in samples.EnumerateArray())
        {
            ulong tick = frame.GetProperty("tick").GetUInt64();
            var clock = new CoopObstaclePoseClock(tick, rounds.Where(round => round <= tick).ToArray(), crawlReturn);
            IReadOnlyList<PlayerHitbox> placed = content.CoopObstaclePoses.Place(clock, position, rotation, "probe/");
            CompareParts(placed, frame.GetProperty("parts"), position, rotation);
            CompareFiringMuzzle(content, clock, frame);
            compared += placed.Count;
        }
        VerifyInvalidClocks(content.CoopObstaclePoses);
        Console.WriteLine($"PASS: {compared} controller collider poses, dimensions and source reset clocks");
    }

    private static void CompareParts(IReadOnlyList<PlayerHitbox> placed, JsonElement expected,
        Vector3 position, Quaternion rotation)
    {
        Require(placed.Count == expected.GetArrayLength(), "Every controller frame needs its complete collider set.");
        for (int index = 0; index < placed.Count; index++)
        {
            PlayerHitbox actual = placed[index];
            JsonElement part = expected[index];
            Vector3 center = position + Vector3.Transform(Vector(part.GetProperty("center")), rotation);
            float[] values = part.GetProperty("rotation").EnumerateArray().Select(value => value.GetSingle()).ToArray();
            Quaternion facing = Quaternion.Normalize(rotation *
                new Quaternion(values[0], values[1], values[2], values[3]));
            Require(actual.SourcePath == "probe/" + part.GetProperty("path").GetString() &&
                Vector3.Distance(actual.Center, center) <= PositionTolerance &&
                1f - Math.Abs(Quaternion.Dot(actual.Rotation, facing)) <= RotationTolerance,
                "Selected source collider placement differs from the actual controller frame.");
            Require(Vector3.Distance(actual.Size, Vector(part.GetProperty("size"))) <= DimensionTolerance &&
                Math.Abs(actual.Radius - part.GetProperty("radius").GetSingle()) <= DimensionTolerance &&
                actual.Enabled == part.GetProperty("enabled").GetBoolean() &&
                actual.Active == part.GetProperty("active").GetBoolean(),
                "Selected collider dimensions or activity differ from the actual controller frame.");
        }
    }

    private static void CompareFiringMuzzle(BattleCombatContent content, CoopObstaclePoseClock clock,
        JsonElement frame)
    {
        CoopQueuedMuzzleSample? muzzle = content.CoopObstaclePoses.FiringMuzzle(clock, content.CoopEnemyMuzzles);
        bool firing = frame.GetProperty("states").EnumerateArray().Any(state =>
            state.GetProperty("name").GetString() == "rifle_shot_loop - Queued Clone" ||
            state.GetProperty("name").GetString() == "rifle_shot_loop");
        Require((muzzle != null) == firing, "Only a firing source frame can expose its muzzle sample.");
        if (muzzle != null)
        {
            Require(Vector3.Distance(muzzle.LocalPosition, Vector(frame.GetProperty("muzzle"))) <= PositionTolerance,
                "Per-round loop resets must preserve the actual controller's muzzle position.");
        }
    }

    private static void VerifyInvalidClocks(CoopObstaclePoseCatalog catalog)
    {
        var invalid = new[]
        {
            new CoopObstaclePoseClock(10, new ulong[] { 11 }),
            new CoopObstaclePoseClock(22, new ulong[] { 11, 11 }),
            new CoopObstaclePoseClock(22, new ulong[] { 22, 11 }),
            new CoopObstaclePoseClock(22, new ulong[] { 11, 22 }, 22),
            new CoopObstaclePoseClock(40, Enumerable.Range(7, 15).Select(value => (ulong)value).ToArray())
        };
        foreach (CoopObstaclePoseClock clock in invalid)
        {
            try
            {
                catalog.Place(clock, Vector3.Zero, Quaternion.Identity);
                throw new Exception("An invalid obstacle pose clock was accepted.");
            }
            catch (InvalidDataException)
            {
                // Invalid input must fail before any diagnostic collider placement is returned.
            }
        }
    }

    private static Vector3 Vector(JsonElement value)
    {
        float[] coordinates = value.EnumerateArray().Select(item => item.GetSingle()).ToArray();
        return new Vector3(coordinates[0], coordinates[1], coordinates[2]);
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }
}

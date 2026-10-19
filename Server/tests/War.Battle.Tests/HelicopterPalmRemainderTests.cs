using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using War.BattleServer;

/// <summary>
/// Checks positive sub-unit normalization and zero-weight retention against two distinct prior poses.
/// </summary>
internal static class HelicopterPalmRemainderTests
{
    private const string ReferenceDigest = "0ca1a8d7292f00c88498b09fe52e31ffe2b769ba5e7186ad200226fdc852e806";
    private const float PositionTolerance = 0.00003f;

    internal static int Run(string directory, EnemyPoseCatalog poses)
    {
        string text = File.ReadAllText(Path.Combine(directory,
            "recovered-palm-remainder-unity-reference.json")).Replace("\r\n", "\n");
        Require(Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(text))) == ReferenceDigest,
            "Palm remainder reference changed without review.");
        using JsonDocument document = JsonDocument.Parse(text);
        JsonElement[] rows = document.RootElement.GetProperty("references").EnumerateArray().ToArray();
        Require(rows.Length == 72 && rows.Count(IsZero) == 12 &&
            rows.Select(row => row.GetProperty("seed").GetString()).Distinct().Count() == 2,
            "Palm remainder capture lost zero-weight or prior-pose coverage.");
        HelicopterPalmBlendCatalog catalog = HelicopterPalmBlendCatalog.Load(
            Path.Combine(directory, "recovered-helicopter-palm-blend.json"), poses);
        float maximumError = 0;
        foreach (JsonElement row in rows)
        {
            maximumError = MathF.Max(maximumError, Verify(catalog, row));
        }
        RigLocalTransform[] binding = Pose(document.RootElement.GetProperty("bindingPose"));
        Require(rows.Where(IsZero).Any(row => !Pose(row.GetProperty("after")).SequenceEqual(binding)),
            "Zero-weight reference no longer distinguishes retained pose from imported binding pose.");
        VerifyRejectedInput(catalog, Pose(rows[0].GetProperty("before")));
        Console.WriteLine($"PASS: 72 sub-unit/zero palm poses; maximum error {maximumError}.");
        return 72 * 2 + 5;
    }

    private static float Verify(HelicopterPalmBlendCatalog catalog, JsonElement row)
    {
        var selection = new HelicopterPalmWeightedSelection(row.GetProperty("idleFrame").GetInt32(),
            row.GetProperty("slideFrame").GetInt32(), row.GetProperty("idleWeight").GetSingle(),
            row.GetProperty("slideWeight").GetSingle());
        RigLocalTransform[] before = Pose(row.GetProperty("before"));
        if (IsZero(row))
        {
            Require(before.SequenceEqual(Pose(row.GetProperty("after"))),
                "Source zero weight did not retain the exact prior local pose.");
        }
        Vector3 local = catalog.SampleWithRetainedPose(selection, before);
        HelicopterDescentFrame world = HelicopterPalmFramePlacement.Create(local, new Vector3(3, 7, 11),
            Quaternion.CreateFromAxisAngle(Vector3.UnitY, MathF.PI / 2), Vector3.UnitX);
        float error = MathF.Max(Vector3.Distance(local, Vector(row.GetProperty("palm"))),
            Vector3.Distance(world.LeftPalmPosition, Vector(row.GetProperty("worldPalm"))));
        Require(error <= PositionTolerance, $"Sub-unit/zero palm differs from Unity by {error} at {selection}.");
        Require(before.SequenceEqual(Pose(row.GetProperty("before"))), "Palm sampling mutated retained input.");
        return error;
    }

    private static void VerifyRejectedInput(HelicopterPalmBlendCatalog catalog, RigLocalTransform[] before)
    {
        var zero = new HelicopterPalmWeightedSelection(0, 0, 0, 0);
        RigLocalTransform[] damaged = before.ToArray();
        damaged[0] = damaged[0] with { Rotation = default };
        Action[] invalid =
        {
            () => catalog.SampleWeighted(zero),
            () => catalog.SampleWithRetainedPose(zero, Array.Empty<RigLocalTransform>()),
            () => catalog.SampleWithRetainedPose(zero, damaged),
            () => catalog.SampleWithRetainedPose(zero with { IdleFrame = catalog.IdleFrameCount }, before),
            () => catalog.SampleWithRetainedPose(zero with { SlideWeight = float.NaN }, before),
        };
        foreach (Action action in invalid)
        {
            try
            {
                action();
            }
            catch (InvalidDataException)
            {
                continue;
            }
            throw new Exception("Palm sampler accepted missing/malformed retained pose or source layer identity.");
        }
    }

    private static bool IsZero(JsonElement row)
    {
        return row.GetProperty("idleWeight").GetSingle() + row.GetProperty("slideWeight").GetSingle() == 0;
    }

    private static RigLocalTransform[] Pose(JsonElement rows)
    {
        return rows.EnumerateArray().Select(row => new RigLocalTransform(Vector(row.GetProperty("position")),
            Rotation(row.GetProperty("rotation")), Vector(row.GetProperty("scale")))).ToArray();
    }

    private static Vector3 Vector(JsonElement value)
    {
        return new Vector3(value[0].GetSingle(), value[1].GetSingle(), value[2].GetSingle());
    }

    private static Quaternion Rotation(JsonElement value)
    {
        return new Quaternion(value[0].GetSingle(), value[1].GetSingle(), value[2].GetSingle(), value[3].GetSingle());
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }
}

using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using War.BattleServer;

/// <summary>Checks independent AnimationState weights against actual Unity bone-chain results.</summary>
internal static class HelicopterPalmRawWeightTests
{
    private const string ReferenceDigest = "df4c69550b7fe2d7f9b821e3eb7a6abc8f8eaefef02371e4cf2d55831b343705";
    private const float PositionTolerance = 0.00003f;

    internal static int Run(string directory, EnemyPoseCatalog poses)
    {
        string text = File.ReadAllText(Path.Combine(directory,
            "recovered-helicopter-palm-raw-weights.json")).Replace("\r\n", "\n");
        Require(Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(text))) == ReferenceDigest,
            "Independent palm weight reference changed without review.");
        using JsonDocument document = JsonDocument.Parse(text);
        JsonElement root = document.RootElement;
        JsonElement[] references = root.GetProperty("references").EnumerateArray().ToArray();
        Require(root.GetProperty("rawWeightProbe").GetBoolean() && references.Length == 36 &&
            references.Count(row => row.GetProperty("idleWeight").GetSingle() +
                row.GetProperty("slideWeight").GetSingle() > 1f) == 24,
            "Palm weight fixture lost its over-unit weight coverage.");
        HelicopterPalmBlendCatalog catalog = HelicopterPalmBlendCatalog.Load(
            Path.Combine(directory, "recovered-helicopter-palm-blend.json"), poses);
        Vector3 position = Vector(root.GetProperty("worldRootPosition"));
        Quaternion rotation = Rotation(root.GetProperty("worldRootRotation"));
        float maximumError = 0;
        foreach (JsonElement row in references)
        {
            maximumError = MathF.Max(maximumError, Verify(catalog, row, position, rotation));
        }
        VerifyRejectedWeights(catalog);
        Console.WriteLine($"PASS: 36 independent Unity palm weights/world poses; maximum error {maximumError}.");
        return 36 * 2 + 5 + VerifyTransitions(directory, catalog);
    }

    private static int VerifyTransitions(string directory, HelicopterPalmBlendCatalog catalog)
    {
        (string Filename, string Digest)[] captures =
        {
            ("recovered-idle-to-slide-unity-reference.json",
                "057da06e2d77ad8d10e7dfa03020ae05f63cf6aa1f0e2a385b67471e63a707b0"),
            ("recovered-idle-to-slide-visibility-unity-reference.json",
                "e1b0f1532531da3a61d272c2675158681f684c1f5b52bd913681154529ecebdb"),
        };
        int checks = 0;
        foreach ((string filename, string digest) in captures)
        {
            string text = File.ReadAllText(Path.Combine(directory, filename)).Replace("\r\n", "\n");
            Require(Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(text))) == digest,
                "Source transition palm capture changed without review.");
            using JsonDocument document = JsonDocument.Parse(text);
            checks += VerifyTransitionFrames(catalog, document.RootElement.GetProperty("frames"));
        }
        Require(checks == 188, "Transition palm replay lost evaluated or resumed frame coverage.");
        return checks;
    }

    private static int VerifyTransitionFrames(HelicopterPalmBlendCatalog catalog, JsonElement frames)
    {
        int checks = 0;
        float maximumError = 0;
        foreach (JsonElement frame in frames.EnumerateArray())
        {
            foreach (JsonElement row in frame.GetProperty("scenarios").EnumerateArray())
            {
                JsonElement[] states = row.GetProperty("states").EnumerateArray().ToArray();
                JsonElement idle = states.Single(state => state.GetProperty("name").GetString() == "idle");
                JsonElement slide = states.Single(state => state.GetProperty("name").GetString() ==
                    "helicopter_jump_pose");
                if (!row.GetProperty("componentEnabled").GetBoolean() ||
                    !slide.GetProperty("enabled").GetBoolean() || slide.GetProperty("time").GetSingle() <= 0)
                {
                    continue;
                }
                int idleFrame = (int)MathF.Round(idle.GetProperty("time").GetSingle() * MatchManifest.TickRate) %
                    (catalog.IdleFrameCount - 1);
                float idleWeight = idle.GetProperty("enabled").GetBoolean() ?
                    idle.GetProperty("weight").GetSingle() : 0;
                var selection = new HelicopterPalmWeightedSelection(idleFrame, catalog.SlideFrameCount - 1,
                    idleWeight, slide.GetProperty("weight").GetSingle());
                float error = Vector3.Distance(catalog.SampleWeighted(selection), Vector(row.GetProperty("palm")));
                Require(error <= PositionTolerance,
                    $"Source transition palm differs by {error} at frame {frame.GetProperty("frame")}, {selection}.");
                maximumError = MathF.Max(maximumError, error);
                checks++;
            }
        }
        Console.WriteLine($"PASS: {checks} evaluated source transition palms; maximum error {maximumError}.");
        return checks;
    }

    private static float Verify(HelicopterPalmBlendCatalog catalog, JsonElement row,
        Vector3 position, Quaternion rotation)
    {
        var selection = new HelicopterPalmWeightedSelection(row.GetProperty("idleFrame").GetInt32(),
            row.GetProperty("slideFrame").GetInt32(), row.GetProperty("idleWeight").GetSingle(),
            row.GetProperty("slideWeight").GetSingle());
        Vector3 local = catalog.SampleWeighted(selection);
        HelicopterDescentFrame world = catalog.CreateWeightedFrame(selection, position, rotation, Vector3.UnitX);
        float error = MathF.Max(Vector3.Distance(local, Vector(row.GetProperty("palm"))),
            Vector3.Distance(world.LeftPalmPosition, Vector(row.GetProperty("worldPalm"))));
        Require(error <= PositionTolerance, $"Independent palm blend differs from Unity by {error} at {selection}.");
        return error;
    }

    private static void VerifyRejectedWeights(HelicopterPalmBlendCatalog catalog)
    {
        Vector2[] invalid = { new(float.NaN, 1), new(-1, 1), new(2, 1), new(0.2f, 0.2f), Vector2.Zero };
        foreach (Vector2 weights in invalid)
        {
            try
            {
                catalog.SampleWeighted(new HelicopterPalmWeightedSelection(0, 0, weights.X, weights.Y));
            }
            catch (InvalidDataException)
            {
                continue;
            }
            throw new Exception("Palm blend accepted malformed weights or an unproven base-pose remainder.");
        }
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

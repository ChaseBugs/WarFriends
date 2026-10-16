using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using War.BattleServer;

/// <summary>Preserves the native agent counterexample to a fixed moving-volley firing rotation.</summary>
internal static class CoopObstacleTurnObservationTests
{
    private const string ReferenceSha256 = "390c3536b3fff05d434276525fc5f2b20c39defab8b020a1ceddf93fec9ca274";
    private const string PlanSha256 = "d1f134406bf00517c79877dc621a7234cb40b406616c73fc5339587381f05ec5";
    private const int ExpectedFrames = 60;
    private const float QuaternionTolerance = 0.00001f;
    private const float FrameTimeTolerance = 0.00001f;
    private const float MinimumMovement = 0.2f;
    private const float MinimumFinalAngleDegrees = 45f;
    private const float SourceMovementSpeed = 0.9f;
    private const int CompletedTurnTick = 6;

    internal static void Run(string directory, BattleCombatContent content)
    {
        byte[] referenceBytes = File.ReadAllBytes(Path.Combine(directory, "coop-obstacle-turn-unity-reference.json"));
        byte[] planBytes = File.ReadAllBytes(Path.Combine(directory, "coop-obstacle-turn-source-plan.json"));
        Require(Convert.ToHexStringLower(SHA256.HashData(referenceBytes)) == ReferenceSha256 &&
            Convert.ToHexStringLower(SHA256.HashData(planBytes)) == PlanSha256,
            "The reviewed native turn observation and actual host input must remain bound.");
        using JsonDocument reference = JsonDocument.Parse(referenceBytes);
        using JsonDocument plan = JsonDocument.Parse(planBytes);
        JsonElement root = reference.RootElement;
        Require(root.GetProperty("planSha256").GetString() == PlanSha256 &&
            root.GetProperty("captureRate").GetInt32() == MatchManifest.TickRate &&
            plan.RootElement.GetProperty("enemySha256").GetString() == content.EnemyPoses.SourceSha256 &&
            plan.RootElement.GetProperty("speed").GetSingle() == SourceMovementSpeed,
            "The turn probe must bind the source rig, movement speed and fixed frame clock.");
        VerifyFrames(root.GetProperty("samples"), plan.RootElement);
        Console.WriteLine("PASS: native co-op moving-root rotation diverges after the source firing tween");
    }

    private static void VerifyFrames(JsonElement samples, JsonElement plan)
    {
        Require(samples.GetArrayLength() == ExpectedFrames, "The complete turn observation is required.");
        Quaternion target = Rotation(plan.GetProperty("targetRotation"));
        int expectedTick = 0;
        foreach (JsonElement frame in samples.EnumerateArray())
        {
            int tick = frame.GetProperty("tick").GetInt32();
            Require(tick == expectedTick++ &&
                Math.Abs(frame.GetProperty("seconds").GetSingle() - tick / (float)MatchManifest.TickRate) <
                    FrameTimeTolerance && PlayerHitbox.Finite(Vector(frame.GetProperty("position"))) &&
                PlayerHitbox.Finite(Vector(frame.GetProperty("velocity"))) &&
                Math.Abs(Rotation(frame.GetProperty("rotation")).LengthSquared() - 1f) < QuaternionTolerance,
                "Every native turn frame must retain a finite ordered source-clock pose.");
        }

        Quaternion settled = Rotation(samples[CompletedTurnTick].GetProperty("rotation"));
        Require(1f - Math.Abs(Quaternion.Dot(settled, target)) < QuaternionTolerance,
            "The source firing tween must first reach its requested target.");
        JsonElement last = samples[ExpectedFrames - 1];
        float dot = Math.Clamp(Math.Abs(Quaternion.Dot(Rotation(last.GetProperty("rotation")), target)), 0f, 1f);
        float angleDegrees = 2f * MathF.Acos(dot) * 180f / MathF.PI;
        Require(!last.GetProperty("tweenEnabled").GetBoolean() && angleDegrees > MinimumFinalAngleDegrees &&
            Vector3.Distance(Vector(samples[0].GetProperty("position")), Vector(last.GetProperty("position"))) >
                MinimumMovement,
            "Native navigation must disprove a fixed final root even after the firing tween ends.");
    }

    private static Vector3 Vector(JsonElement values)
    {
        return new Vector3(values[0].GetSingle(), values[1].GetSingle(), values[2].GetSingle());
    }

    private static Quaternion Rotation(JsonElement values)
    {
        return new Quaternion(
            values[0].GetSingle(), values[1].GetSingle(), values[2].GetSingle(), values[3].GetSingle());
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }
}

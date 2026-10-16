using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using War.BattleServer;

/// <summary>Checks host ray geometry against native queries made before gameplay shot callbacks.</summary>
internal static class CoopGameplayQueryObservationTests
{
    private const float DistanceTolerance = 0.00002f;
    private const int ExpectedFrames = 81;
    private const int ExpectedParts = 3;

    internal static void Run(string directory)
    {
        using JsonDocument queryDocument = Read(directory, "coop-gameplay-query-unity-reference.json");
        using JsonDocument postDocument = Read(directory, "coop-gameplay-query-post-reference.json");
        JsonElement observation = queryDocument.RootElement;
        JsonElement samples = observation.GetProperty("samples");
        JsonElement postSamples = postDocument.RootElement.GetProperty("samples");
        Require(observation.GetProperty("version").GetInt32() == 2 &&
            postDocument.RootElement.GetProperty("version").GetInt32() == 5,
            "The paired observations must use gameplay round emission.");
        Require(samples.GetArrayLength() == ExpectedFrames && postSamples.GetArrayLength() == ExpectedFrames + 1,
            "The observer must capture every frame after editor initialization.");
        int compared = 0;
        foreach (JsonElement sample in samples.EnumerateArray())
        {
            int tick = sample.GetProperty("tick").GetInt32();
            JsonElement previous = postSamples[tick - 1];
            Require(previous.GetProperty("unityFrame").GetInt32() + 1 ==
                sample.GetProperty("unityFrame").GetInt32(), "Query and previous post frames must be contiguous.");
            compared += CompareParts(sample, previous, observation);
            Require(Vector3.Distance(Vector(sample.GetProperty("muzzle")),
                Vector(previous.GetProperty("muzzle"))) <= DistanceTolerance,
                "Gameplay firing origins must use the preceding animation sample.");
        }

        Require(compared == ExpectedFrames * ExpectedParts, "Every body and head query must be compared.");
        Console.WriteLine($"PASS: {compared} native gameplay queries match host rays and previous sampled poses");
    }

    private static int CompareParts(JsonElement sample, JsonElement previous, JsonElement observation)
    {
        int compared = 0;
        foreach (JsonElement part in previous.GetProperty("parts").EnumerateArray())
        {
            string path = part.GetProperty("path").GetString() ?? throw new InvalidDataException("Missing part path.");
            JsonElement query = sample.GetProperty("queries").EnumerateArray().Single(candidate =>
                "enemy" + candidate.GetProperty("path").GetString() == path &&
                candidate.GetProperty("kind").GetString() == part.GetProperty("kind").GetString());
            Require(Vector3.Distance(Vector(query.GetProperty("rootLocalCenter")),
                Vector(part.GetProperty("center"))) <= DistanceTolerance,
                "Update must see the previous post-frame collider center.");
            VerifyNativeRay(query, observation);
            compared++;
        }

        return compared;
    }

    private static void VerifyNativeRay(JsonElement query, JsonElement observation)
    {
        bool isBox = query.GetProperty("kind").GetString() == "box";
        Vector3 scale = Vector3.Abs(Vector(query.GetProperty("scale")));
        float radius = query.GetProperty("radius").GetSingle() * Math.Max(scale.X, Math.Max(scale.Y, scale.Z));
        float[] rotation = query.GetProperty("rotation").EnumerateArray().Select(value => value.GetSingle()).ToArray();
        string path = query.GetProperty("path").GetString() ?? throw new InvalidDataException("Missing query path.");
        var shape = new PlayerHitbox(path,
            isBox ? PlayerHitboxKind.Box : PlayerHitboxKind.Sphere, 1,
            Vector(query.GetProperty("center")), isBox ? Vector(query.GetProperty("size")) * scale : Vector3.Zero,
            new Quaternion(rotation[0], rotation[1], rotation[2], rotation[3]), radius, Vector3.Zero, 0);
        float? distance = shape.Raycast(Vector(query.GetProperty("origin")),
            Vector(observation.GetProperty("rayDirection")), observation.GetProperty("rayDistance").GetSingle());
        Require(distance.HasValue == query.GetProperty("hasHit").GetBoolean(), "Host and native hit state must agree.");
        if (distance.HasValue)
        {
            Require(Math.Abs(distance.Value - query.GetProperty("distance").GetSingle()) <= DistanceTolerance,
                "Host and native hit distance must agree at the recorded gameplay pose.");
        }
    }

    private static JsonDocument Read(string directory, string fileName)
    {
        string expectedHash = fileName == "coop-gameplay-query-unity-reference.json"
            ? "156f9bbba88ebd3b2da95f5ef3f239927f2526c2c8c033af64c103af309ea999"
            : "bb884d964c361cf12108c7a82c4cfdfcd075efe77f92dfcaf388849d2a0c8c79";
        byte[] bytes = File.ReadAllBytes(Path.Combine(directory, fileName));
        Require(Convert.ToHexStringLower(SHA256.HashData(bytes)) == expectedHash,
            "The gameplay observation must match the reviewed Unity capture.");
        return JsonDocument.Parse(bytes);
    }

    private static Vector3 Vector(JsonElement value)
    {
        return new Vector3(value[0].GetSingle(), value[1].GetSingle(), value[2].GetSingle());
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidDataException(message);
        }
    }
}

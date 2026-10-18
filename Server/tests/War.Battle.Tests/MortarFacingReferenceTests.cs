using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

using War.BattleServer;

/// <summary>Compares source NGUI easing and quaternion wrap behavior with native Unity samples.</summary>
internal static class MortarFacingReferenceTests
{
    private const string Revision = "1fcae99a4e8ec9f51775f61cc7ce279d83bce0396d7c8b93731de8fc552e33b6";
    private const int CaseCount = 25;
    private const int SampleCount = 7;
    private const float MaximumVectorError = 0.00001f;

    internal static int Run(string directory)
    {
        byte[] bytes = File.ReadAllBytes(Path.Combine(directory, "mortar-facing-unity-reference.json"));
        int checks = Require(Convert.ToHexStringLower(SHA256.HashData(bytes)) == Revision,
            "Mortar rotation native reference bytes changed.");
        using JsonDocument document = JsonDocument.Parse(bytes);
        JsonElement root = document.RootElement;
        checks += Require(root.GetProperty("unityVersion").GetString() == "2018.3.0f2" &&
            root.GetProperty("cases").GetArrayLength() == CaseCount,
            "Mortar rotation lost its native version or complete yaw-case set.");
        foreach (JsonElement row in root.GetProperty("cases").EnumerateArray())
        {
            var tween = new MortarFacingTween(0, 0, Position(row.GetProperty("from")), Position(row.GetProperty("to")));
            JsonElement samples = row.GetProperty("samples");
            checks += Require(samples.GetArrayLength() == SampleCount,
                "Mortar rotation native case has an incomplete sample set.");
            for (int step = 0; step < SampleCount; step++)
            {
                JsonElement sample = samples[step];
                Vector3 expected = Position(sample.GetProperty("facing"));
                Vector3 actual = tween.FacingAt((ulong)step);
                checks += Require(sample.GetProperty("step").GetInt32() == step &&
                    Vector3.Distance(actual, expected) < MaximumVectorError,
                    $"Mortar facing {row.GetProperty("fromYaw")} -> {row.GetProperty("toYaw")}, step {step}: " +
                    $"host={actual}, native={expected}.");
            }
        }

        return checks + CheckInvalidAuthority();
    }

    private static int CheckInvalidAuthority()
    {
        int checks = 0;
        foreach (Vector3 invalid in new[] { Vector3.Zero, Vector3.UnitY,
            new Vector3(float.NaN, 0f, 1f), new Vector3(float.MaxValue, 0f, float.MaxValue) })
        {
            try
            {
                _ = new MortarFacingTween(0, 0, invalid, Vector3.UnitZ);
                throw new InvalidOperationException("Mortar accepted invalid facing authority.");
            }
            catch (InvalidDataException)
            {
                checks++;
            }
        }

        var tween = new MortarFacingTween(20, 0, Vector3.UnitZ, Vector3.UnitX);
        try
        {
            tween.FacingAt(19);
            throw new InvalidOperationException("Mortar sampled before its rotation started.");
        }
        catch (InvalidDataException)
        {
            checks++;
        }

        return checks;
    }

    private static Vector3 Position(JsonElement coordinates)
    {
        float[] values = coordinates.EnumerateArray().Select(value => value.GetSingle()).ToArray();
        return new Vector3(values[0], values[1], values[2]);
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

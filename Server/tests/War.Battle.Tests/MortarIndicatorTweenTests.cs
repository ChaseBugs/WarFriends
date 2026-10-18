using System.Security.Cryptography;
using System.Text.Json;

using War.Shared;

/// <summary>Compares the portable warning sampler with actual recovered Unity tween observations.</summary>
internal static class MortarIndicatorTweenTests
{
    private const float Tolerance = 0.00001f;
    private const string ReferenceDigest = "b10ea3c6d4d2b8d04a75943c041dea64bc05ec34b23e12498b674bcb570957ba";

    internal static int Run(string directory)
    {
        byte[] bytes = File.ReadAllBytes(Path.Combine(directory, "recovered-mortar-indicator-reference.json"));
        int checks = Require(Convert.ToHexStringLower(SHA256.HashData(bytes)) == ReferenceDigest,
            "The native indicator reference changed without a reviewed observation.");
        using JsonDocument reference = JsonDocument.Parse(bytes);
        JsonElement root = reference.RootElement;
        checks += Require(root.GetProperty("unityVersion").GetString() == "2018.3.0f2" &&
            root.GetProperty("checks").GetInt32() == 11 &&
            root.GetProperty("scaleMethod").GetString() == "EaseInOut" &&
            root.GetProperty("colorMethod").GetString() == "EaseInOut",
            "The warning reference must retain its observed Unity and source method identity.");
        string repository = Directory.GetParent(directory)!.Parent!.FullName;
        foreach (JsonElement source in root.GetProperty("sources").EnumerateArray())
        {
            string path = Path.Combine(repository, "Clients/ExportedProject",
                source.GetProperty("source").GetString()!);
            string digest = Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(path)));
            checks += Require(digest == source.GetProperty("sha256").GetString(),
                "The private indicator observation no longer matches the active recovered source.");
        }
        foreach (JsonElement sample in root.GetProperty("samples").EnumerateArray())
        {
            float factor = sample.GetProperty("factor").GetSingle();
            float scale = MortarIndicatorTween.SampleScale(factor);
            checks += Require(sample.GetProperty("scale").EnumerateArray()
                .All(axis => MathF.Abs(axis.GetSingle() - scale) < Tolerance),
                "Portable warning shrink differs from native TweenScale.Sample.");
            float halfAngle = MortarIndicatorTween.SampleRotationDegrees(factor) * MathF.PI / 360f;
            float basis = MathF.Sqrt(0.5f);
            float[] rotation = { MathF.Cos(halfAngle) * basis, MathF.Sin(halfAngle) * basis,
                -MathF.Sin(halfAngle) * basis, MathF.Cos(halfAngle) * basis };
            JsonElement native = sample.GetProperty("rotation");
            float dot = rotation.Select((axis, index) => axis * native[index].GetSingle()).Sum();
            checks += Require(MathF.Abs(dot) > 1f - Tolerance,
                "Portable warning rotation differs from native TweenRotationSpecial.Sample.");
        }
        foreach (JsonElement sample in root.GetProperty("blinkSamples").EnumerateArray())
        {
            checks += Require(MathF.Abs(MortarIndicatorTween.SampleAlpha(sample.GetProperty("factor").GetSingle()) -
                sample.GetProperty("alpha").GetSingle()) < Tolerance,
                "Portable warning blink differs from native TweenColorTk2d.Sample.");
        }
        foreach (float invalid in new[] { float.NaN, float.NegativeInfinity, float.PositiveInfinity, -0.1f, 1.1f })
        {
            foreach (Func<float, float> sampler in new Func<float, float>[]
                { MortarIndicatorTween.SampleScale, MortarIndicatorTween.SampleAlpha, MortarIndicatorTween.SampleRotationDegrees })
            {
                bool rejected = false;
                try
                {
                    sampler(invalid);
                }
                catch (ArgumentOutOfRangeException)
                {
                    rejected = true;
                }
                checks += Require(rejected, "A malformed warning factor reached presentation arithmetic.");
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

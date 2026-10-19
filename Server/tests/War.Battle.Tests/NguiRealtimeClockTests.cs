using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using War.BattleServer;

/// <summary>Checks the actual recovered clock, carried rounding residuals and rejected-observation atomicity.</summary>
internal static class NguiRealtimeClockTests
{
    private const string ReferenceDigest = "4a3d9307e13fa6b0ae9d70b977f943cb8a0814f6dbc92b4b174a4321026547b0";

    internal static int Run(string directory)
    {
        string text = File.ReadAllText(Path.Combine(directory,
            "recovered-ngui-realtime-unity-reference.json")).Replace("\r\n", "\n");
        if (Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(text))) != ReferenceDigest)
        {
            throw new Exception("NGUI realtime reference changed without review.");
        }
        using JsonDocument document = JsonDocument.Parse(text);
        JsonElement rows = document.RootElement.GetProperty("rows");
        var clock = new NguiRealtimeClock(0);
        int longFrames = 0;
        foreach (JsonElement row in rows.EnumerateArray())
        {
            float previous = row.GetProperty("previous").GetSingle();
            float realtime = row.GetProperty("realtime").GetSingle();
            clock.ReenableAt(previous);
            Require(clock.Residual == row.GetProperty("beforeResidual").GetSingle(),
                "Re-enabling discarded a source rounding residual.");
            float delta = clock.Advance(realtime);
            Require(delta == row.GetProperty("delta").GetSingle() &&
                clock.Residual == row.GetProperty("residual").GetSingle(),
                "NGUI realtime delta or fractional residual differs from the original method.");
            if (realtime - previous > 1.2f && delta == 1f)
            {
                longFrames++;
            }
        }
        Require(rows.GetArrayLength() == 27 && longFrames == 3,
            "Clock reference lost its real long-frame cap coverage.");
        VerifyRejectedObservations();
        Console.WriteLine("PASS: 27 original NGUI realtime observations, long-frame cap and atomic input guards.");
        return 60;
    }

    private static void VerifyRejectedObservations()
    {
        var clock = new NguiRealtimeClock(0);
        var control = new NguiRealtimeClock(0);
        _ = clock.Advance(0.0004f);
        _ = control.Advance(0.0004f);
        foreach (float invalid in new[] { -1f, float.NaN, float.PositiveInfinity, float.MaxValue })
        {
            float residual = clock.Residual;
            try
            {
                clock.Advance(invalid);
                throw new Exception("Clock accepted an invalid or overflowing observation.");
            }
            catch (InvalidDataException)
            {
                Require(clock.Residual == residual, "Rejected observation consumed the rounding residual.");
            }
        }
        Require(clock.Advance(0.001f) == control.Advance(0.001f) && clock.Residual == control.Residual,
            "Rejected observation changed the next valid clock result.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }
}

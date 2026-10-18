using System.Security.Cryptography;
using System.Text.Json;

using War.BattleServer;

/// <summary>Checks source callback and next-Update projections against actual Unity coroutine observations.</summary>
internal static class MortarClockReferenceTests
{
    private const string Revision = "a207c39f3ff51a96ef22ee13cfaa8ace76cdfb7d78602a73d9571d8e8c232f43";

    internal static int Run(string directory)
    {
        byte[] bytes = File.ReadAllBytes(Path.Combine(directory, "mortar-clock-unity-reference.json"));
        Require(Convert.ToHexStringLower(SHA256.HashData(bytes)) == Revision,
            "Native Mortar coroutine reference changed without review.");
        using JsonDocument document = JsonDocument.Parse(bytes);
        JsonElement root = document.RootElement;
        Require(root.GetProperty("unityVersion").GetString() == "2018.3.0f2" &&
            root.GetProperty("captureRate").GetInt32() == MatchManifest.TickRate &&
            root.GetProperty("observations").GetArrayLength() == 3,
            "Native Mortar coroutine reference lost its supported capture identity.");
        int checks = 2;
        foreach (JsonElement row in root.GetProperty("observations").EnumerateArray())
        {
            ulong preparationTick = row.GetProperty("preparedTick").GetUInt64();
            var attempt = new MortarShotAttempt(preparationTick, null, false);
            checks += Require(attempt.CallbackTick == row.GetProperty("callbackTick").GetUInt64() &&
                attempt.PollTick == row.GetProperty("pollTick").GetUInt64(),
                "Mortar callback or first gameplay poll differs from the native recovered coroutine.");
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

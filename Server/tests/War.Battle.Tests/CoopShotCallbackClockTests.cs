using System.Security.Cryptography;
using System.Text.Json;
using War.BattleServer;

/// <summary>Checks the active host callback clock against a recovered Unity coroutine observation.</summary>
internal static class CoopShotCallbackClockTests
{
    internal static void Run(string directory, BattleCombatContent content)
    {
        const string ReviewedHash = "a550552508c9d74078708a9220155e7dc42e83effda1f28dcebd07d335b30f7d";
        byte[] bytes = File.ReadAllBytes(Path.Combine(directory, "coop-delayed-shot-unity-reference.json"));
        Require(Convert.ToHexStringLower(SHA256.HashData(bytes)) == ReviewedHash,
            "The delayed shot observation must match the reviewed native source run.");
        using JsonDocument document = JsonDocument.Parse(bytes);
        VerifyObservation(content, document.RootElement);
    }

    private static void VerifyObservation(BattleCombatContent content, JsonElement observation)
    {
        const int ExpectedCaptureRate = 30;
        const float SourcePaddingSeconds = 0.05f;
        float clipSeconds = content.EnemyPoses.Clip("stand_up_begin").Length;
        ulong callbackTick = observation.GetProperty("callbackTick").GetUInt64();
        ulong firstReadyTick = observation.GetProperty("firstReadyTick").GetUInt64();
        Require(observation.GetProperty("version").GetInt32() == 1 &&
            observation.GetProperty("captureRate").GetInt32() == ExpectedCaptureRate &&
            observation.GetProperty("timeScale").GetSingle() == 1f,
            "The callback observation must use the source fixed-rate scaled clock.");
        Require(observation.GetProperty("callbackDelay").GetSingle() == clipSeconds + SourcePaddingSeconds,
            "The native coroutine must use the recovered preparation length and callback padding.");
        Require(CoopShotCallbackClock.CallbackTick(0, clipSeconds) == callbackTick,
            "The active host callback calculation must match the native coroutine resume tick.");
        Require(CoopShotCallbackClock.FirstGameplayPollTick(callbackTick) == firstReadyTick,
            "The first gameplay poll must follow the callback's actual resume frame.");
        Require(observation.GetProperty("callbackFrame").GetInt64() -
            observation.GetProperty("preparationFrame").GetInt64() == (long)callbackTick,
            "Relative callback ticks must bind actual Unity frames.");
        VerifyInvalidInputs();
        Console.WriteLine($"PASS: source coroutine callback at {callbackTick}, first gameplay poll at {firstReadyTick}");
    }

    private static void VerifyInvalidInputs()
    {
        float[] invalidLengths = [float.NaN, float.PositiveInfinity, float.NegativeInfinity, 0f, -1f, 61f];
        foreach (float clipSeconds in invalidLengths)
        {
            RequireFailure(() => CoopShotCallbackClock.CallbackTick(0, clipSeconds), typeof(InvalidDataException));
        }

        RequireFailure(() => CoopShotCallbackClock.CallbackTick(ulong.MaxValue, 1f), typeof(OverflowException));
        RequireFailure(() => CoopShotCallbackClock.FirstGameplayPollTick(ulong.MaxValue), typeof(OverflowException));
    }

    private static void RequireFailure(Action action, Type exceptionType)
    {
        try
        {
            action();
        }
        catch (Exception exception) when (exception.GetType() == exceptionType)
        {
            return;
        }

        throw new InvalidDataException("The shot callback clock accepted invalid authority.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidDataException(message);
        }
    }
}

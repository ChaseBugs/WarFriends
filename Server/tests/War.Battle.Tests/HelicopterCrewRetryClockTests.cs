using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

using War.BattleServer;

/// <summary>Replays original InvokeAfter callback frames through pause and repeated scaled waits.</summary>
internal static class HelicopterCrewRetryClockTests
{
    internal static int Run(string directory)
    {
        string text = File.ReadAllText(Path.Combine(directory,
            "recovered-crew-retry-wait-unity-reference.json")).Replace("\r\n", "\n");
        Require(Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(text))) ==
            "60a557245e046eccbbc2666bd1a297814fcb3e3acd18fdc39554e942efe73396",
            "Source retry wait capture changed without review.");
        using JsonDocument document = JsonDocument.Parse(text);
        JsonElement capture = document.RootElement.GetProperty("capture");
        JsonElement start = capture.GetProperty("start");
        var clock = new HelicopterCrewRetryClock(start.GetProperty("frame").GetUInt64(),
            start.GetProperty("time").GetSingle());
        JsonElement frames = capture.GetProperty("frames");
        Require(frames.GetArrayLength() == 235 && capture.GetProperty("callbacks").GetArrayLength() == 2,
            "Retry capture lost automatic frames or its second wait.");
        int fired = 0;
        int paused = 0;
        foreach (JsonElement frame in frames.EnumerateArray())
        {
            if (clock.TryConsume(frame.GetProperty("frame").GetUInt64(), frame.GetProperty("time").GetSingle()))
            {
                fired++;
                if (fired < 2)
                {
                    clock.ScheduleNext();
                }
            }
            Require(fired == frame.GetProperty("callbacks").GetInt32(),
                $"Crew retry callback differs from source frame {frame.GetProperty("frame")}.");
            paused += frame.GetProperty("delta").GetSingle() == 0 ? 1 : 0;
        }
        Require(fired == 2 && paused == 10 && !clock.IsPending, "Retry lost pause, repeat or one-shot semantics.");
        VerifyGuards();
        Console.WriteLine("PASS: 235 original scaled retry frames, ten paused frames and two coroutine callbacks.");
        return 243;
    }

    private static void VerifyGuards()
    {
        var clock = new HelicopterCrewRetryClock(1, 1);
        Action[] invalid =
        {
            () => clock.TryConsume(2, float.NaN),
            () => clock.TryConsume(2, -1),
            () => clock.TryConsume(0, 1),
            () => clock.TryConsume(1, 2),
            () => clock.ScheduleNext(),
            () => new HelicopterCrewRetryClock(0, float.MaxValue),
        };
        foreach (Action action in invalid)
        {
            try
            {
                action();
                throw new Exception("Crew retry accepted damaged time, frame order or duplicate scheduling.");
            }
            catch (Exception exception) when (exception is InvalidDataException or InvalidOperationException)
            {
                Require(clock.IsPending, "Rejected retry input consumed its pending callback.");
            }
        }
        Require(clock.TryConsume(2, 6) && !clock.TryConsume(2, 6), "Retry callback was not consumed exactly once.");
        Require(!clock.TryConsume(3, 7), "Consumed retry fired without another source wait.");
        clock.ScheduleNext();
        Require(clock.TryConsume(4, 11), "Polling a consumed wait shifted the next source callback origin.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }
}

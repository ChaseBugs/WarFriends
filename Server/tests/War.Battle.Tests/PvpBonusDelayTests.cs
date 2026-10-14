using System.Security.Cryptography;
using System.Text.Json;
using War.BattleServer;

internal static class PvpBonusDelayTests
{
    internal static int Run(string directory)
    {
        int checks = 0;
        void Check(bool condition, string description)
        {
            if (!condition) throw new Exception(description);
            checks++;
        }
        string Id(int ordinal) => ordinal.ToString("x32");
        byte[] bytes = File.ReadAllBytes(Path.Combine(directory, "unity-pvp-delay-reference.json"));
        Check(Convert.ToHexStringLower(SHA256.HashData(bytes)) ==
              "dd8673f81c10f21fc7dede975a853bc093bd2fc7668a12bfcab12e30ad8f0225",
            "delay oracle uses the reviewed original-coroutine Play Mode trace");
        using var reference = JsonDocument.Parse(bytes);
        Check(reference.RootElement.GetProperty("unityVersion").GetString() == "2018.3.0f2" &&
              reference.RootElement.GetProperty("managerSha256").GetString() ==
                  "62c6e7318e482478f35f3c4c7f2f00a83a1a9b19d52fff1c622e164363c88895" &&
              reference.RootElement.GetProperty("coreSha256").GetString() ==
                  "3a42957a1560169dc96af028905d93f0a70aa7d84050d6d5b640b06507f60dce",
            "oracle pins engine, GenerateNewBonus and original coroutine helper");
        Check(reference.RootElement.GetProperty("cases").GetArrayLength() == 8,
            "oracle covers speed, pause, end, ordering and manager destruction");
        foreach (var sourceCase in reference.RootElement.GetProperty("cases").EnumerateArray())
        {
            string name = sourceCase.GetProperty("name").GetString()!;
            using var queue = new PvpBonusDelayQueue();
            queue.ScheduleConfirmedBonus(Id(1), Id(100), "owner-1", 1, 1);
            if (name == "same_frame_two_requests")
                queue.ScheduleConfirmedBonus(Id(2), Id(100), "owner-2", 1, 1);
            int callbackOffset = sourceCase.GetProperty("callbackFrame").GetInt32() -
                sourceCase.GetProperty("issueFrame").GetInt32();
            bool destroyed = false;
            foreach (var frame in sourceCase.GetProperty("frames").EnumerateArray())
            {
                int offset = frame.GetProperty("offset").GetInt32();
                if (destroyed) continue;
                float delta = BitConverter.Int32BitsToSingle(frame.GetProperty("deltaBits").GetInt32());
                var ready = queue.AdvanceFrame((ulong)offset + 1, delta);
                if (name == "manager_destroyed")
                {
                    Check(ready.Count == 0, "original manager destruction prevents pending callback");
                    if (offset == 5) { queue.Dispose(); destroyed = true; }
                    continue;
                }
                if (offset == callbackOffset)
                {
                    string[] expected = sourceCase.GetProperty("callbackOwnerOrder").EnumerateArray()
                        .Select(owner => "owner-" + owner.GetInt32()).ToArray();
                    Check(ready.Select(request => request.OwnerPlayerId).SequenceEqual(expected),
                        "source callback frame and order: " + name);
                }
                else
                    Check(ready.Count == 0, "no callback before the source scaled deadline: " + name);
            }
            Check(queue.PendingCount == 0, "source delay leaves no pending request: " + name);
            if (name == "game_ended_manager_alive")
                Check(sourceCase.GetProperty("poolFrees").GetInt32() == 1 &&
                      sourceCase.GetProperty("callbackOwnerOrder").GetArrayLength() == 1,
                    "original game-end pool cleanup does not cancel the manager's coroutine");
            if (name == "manager_destroyed")
                Check(sourceCase.GetProperty("callbackOwnerOrder").GetArrayLength() == 0,
                    "destroyed original manager never invokes its pending SpawnBonus prefix");
        }

        using var state = new PvpBonusDelayQueue(maximumPending:1, maximumReceipts:2);
        var first = state.ScheduleConfirmedBonus(Id(1), Id(100), "owner-1", 1, 1);
        Check(state.ScheduleConfirmedBonus(Id(1), Id(100), "owner-1", 1, 1) == first && state.PendingCount == 1,
            "issue replay cannot create a second pending coroutine");
        Check(state.AdvanceFrame(1, 1.5f).Count == 0,
            "issue-frame delta is not counted as elapsed wait time");
        try { state.ScheduleConfirmedBonus(Id(2), Id(100), "owner-1", 2, 1); throw new Exception("Pending capacity exceeded."); }
        catch (InvalidOperationException) { checks++; }
        var readyFirst = state.AdvanceFrame(2, 1.5f);
        Check(readyFirst.Count == 1 && readyFirst[0] == first && state.PendingCount == 0,
            "first later frame reaching the source duration matures the request");
        var second = state.ScheduleConfirmedBonus(Id(2), Id(100), "owner-1", 2, 2);
        Check(state.AdvanceFrame(2, 1.5f) == readyFirst && state.PendingCount == 1,
            "exact frame replay does not age a newly scheduled request");
        Check(state.ScheduleConfirmedBonus(Id(1), Id(100), "owner-1", 1, 1) == first && state.PendingCount == 1,
            "old matured issue replay cannot restore a consumed wait");
        foreach (Action invalid in new Action[] {
            () => state.ScheduleConfirmedBonus(Id(1), Id(101), "owner-1", 1, 1),
            () => state.ScheduleConfirmedBonus(Id(1), Id(100), "owner-2", 1, 1),
            () => state.ScheduleConfirmedBonus(Id(1), Id(100), "owner-1", 2, 1),
            () => state.ScheduleConfirmedBonus(Id(1), Id(100), "owner-1", 1, 2),
            () => state.ScheduleConfirmedBonus(Id(3), Id(100), "owner-1", 2, 2),
            () => state.ScheduleConfirmedBonus(Id(3), Id(100), "owner-1", 4, 2),
            () => state.ScheduleConfirmedBonus(Id(3), Id(100), "owner-1", 3, 1),
            () => state.ScheduleConfirmedBonus("invalid", Id(100), "owner-1", 3, 2),
            () => state.ScheduleConfirmedBonus(Id(3), Id(100), " owner-1", 1, 2),
            () => state.AdvanceFrame(2, 0f),
            () => state.AdvanceFrame(4, 0f) })
        {
            try { invalid(); throw new Exception("Changed or unordered delay authority accepted."); }
            catch (InvalidDataException) { checks++; }
        }
        foreach (float invalid in new[] {-1f,float.NaN,float.PositiveInfinity})
        {
            try { state.AdvanceFrame(3, invalid); throw new Exception("Invalid scaled delta accepted."); }
            catch (ArgumentOutOfRangeException) { checks++; }
        }
        try { state.ScheduleConfirmedBonus(Id(3), Id(100), "owner-1", 3, 2); throw new Exception("Receipt capacity exceeded."); }
        catch (InvalidOperationException) { checks++; }
        Check(state.ReceiptCount == 2 && state.PendingCount == 1 &&
              state.AdvanceFrame(3, 1.5f).Single() == second,
            "rejected requests and deltas do not consume ordinal, wait or receipt authority");
        try { ((IList<PvpBonusDelayedRequest>)readyFirst).Clear(); throw new Exception("Ready requests were mutable."); }
        catch (NotSupportedException) { checks++; }
        state.Dispose();
        try { state.AdvanceFrame(4, 1f); throw new Exception("Disposed manager advanced."); }
        catch (ObjectDisposedException) { checks++; }
        return checks;
    }
}

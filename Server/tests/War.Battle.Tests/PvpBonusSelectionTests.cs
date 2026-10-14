using System.Security.Cryptography;
using System.Text.Json;
using War.BattleServer;

internal static class PvpBonusSelectionTests
{
    internal static int Run(string directory)
    {
        int checks = 0;
        void Check(bool condition, string description)
        {
            if (!condition) throw new Exception(description);
            checks++;
        }
        var catalog = BattleCombatContent.Load(Path.Combine(directory, "combat-content-manifest.json")).PvpBonuses;
        byte[] bytes = File.ReadAllBytes(Path.Combine(directory, "unity-pvp-selection-reference.json"));
        Check(Convert.ToHexStringLower(SHA256.HashData(bytes)) ==
              "bf55bfe8bca14bacde87676f3eaf42cb4b8596a6ff724a612f952d4f263723c0",
            "selection oracle uses the reviewed original-prefix Mono fixture");
        using var reference = JsonDocument.Parse(bytes);
        Check(reference.RootElement.GetProperty("unityVersion").GetString() == "2018.3.0f2" &&
              reference.RootElement.GetProperty("managerSha256").GetString() ==
                  "62c6e7318e482478f35f3c4c7f2f00a83a1a9b19d52fff1c622e164363c88895",
            "oracle pins source selection and engine identity");
        Check(reference.RootElement.GetProperty("samples").GetArrayLength() == 66,
            "oracle contains all reviewed boundaries and queue branches");
        foreach (var sample in reference.RootElement.GetProperty("samples").EnumerateArray())
        {
            float[] weights = sample.GetProperty("weightBits").EnumerateArray()
                .Select(value => BitConverter.Int32BitsToSingle(value.GetInt32())).ToArray();
            int queued = sample.GetProperty("queuedIndex").GetInt32();
            if (queued >= 0)
            {
                Check(sample.GetProperty("prefabIndex").GetInt32() == queued &&
                      sample.GetProperty("sourceIndex").GetInt32() == queued &&
                      sample.GetProperty("drawCalls").GetInt32() == 0,
                    "original queued branch bypasses probability and draw");
                continue;
            }
            var choice = PvpBonusSelectionState.SourceWeightedChoice(weights,
                sample.GetProperty("lastIndex").GetInt32(),
                BitConverter.Int32BitsToSingle(sample.GetProperty("drawBits").GetInt32()));
            Check(BitConverter.SingleToInt32Bits(choice.Total) == sample.GetProperty("totalBits").GetInt32() &&
                  choice.PrefabIndex == sample.GetProperty("prefabIndex").GetInt32() &&
                  choice.SourceIndex == sample.GetProperty("sourceIndex").GetInt32() &&
                  sample.GetProperty("drawCalls").GetInt32() == 1,
                "original exclusion, strict cumulative comparison and fallthrough: " + sample.GetProperty("name").GetString());
        }
        string Receipt(int ordinal) => ordinal.ToString("x32");
        var context = new PvpBonusWeightContext(false, false, 8, 7, 0, false);
        var state = new PvpBonusSelectionState(catalog);
        int draws = 0;
        float Draw(float total) { draws++; return 0f; }
        var first = state.SelectConfirmedBonus(Receipt(1), PvpBonusSide.Allies, context, Draw);
        Check(first.Prefab.Index == 1 && first.SourceIndex == 1 && first.HasValidSourceIndex && draws == 1,
            "initial source index zero excludes Gold from the first weighted draw");
        var second = state.SelectConfirmedBonus(Receipt(2), PvpBonusSide.Enemy, context, Draw);
        Check(second.Prefab.Index == 0 && state.LastSourceIndex == 0 && draws == 2,
            "both source sides share last-selection history");
        Check(state.SelectConfirmedBonus(Receipt(1), PvpBonusSide.Allies, context, Draw) == first &&
              state.LastSourceIndex == 0 && draws == 2,
            "old selection replay neither redraws nor restores old history");

        state.EnqueueConfirmedBonus(Receipt(3), PvpBonusSide.Allies, 7);
        state.EnqueueConfirmedBonus(Receipt(3), PvpBonusSide.Allies, 7);
        state.EnqueueConfirmedBonus(Receipt(4), PvpBonusSide.Allies, 0);
        state.EnqueueConfirmedBonus(Receipt(5), PvpBonusSide.Enemy, 6);
        Check(state.QueuedCount(PvpBonusSide.Allies) == 2 && state.QueuedCount(PvpBonusSide.Enemy) == 1,
            "queued receipts are retry-safe and side-isolated");
        var forced = state.SelectConfirmedBonus(Receipt(6), PvpBonusSide.Allies,
            context with {IsFriendlyDeathMatch=true}, _ => throw new Exception("Queued branch drew randomly."));
        Check(forced is {SourceIndex:7,UsedQueuedOverride:true} && state.LastSourceIndex == 7 &&
              state.QueuedCount(PvpBonusSide.Allies) == 1 && state.QueuedCount(PvpBonusSide.Enemy) == 1,
            "source queued override bypasses zero card weight and consumes only its side head");
        Check(state.SelectConfirmedBonus(Receipt(7), PvpBonusSide.Allies, context, Draw).SourceIndex == 0 &&
              state.SelectConfirmedBonus(Receipt(8), PvpBonusSide.Enemy, context, Draw).SourceIndex == 6 && draws == 2,
            "source queue order stays FIFO without consuming random draws");
        state.EnqueueConfirmedBonus(Receipt(9), PvpBonusSide.Allies, 2);
        state.ClearQueuesForGameStart();
        state.EnqueueConfirmedBonus(Receipt(9), PvpBonusSide.Allies, 2);
        Check(state.LastSourceIndex == 6 && state.QueuedCount(PvpBonusSide.Allies) == 0,
            "GameStarted clears pending queues but preserves last index and prior receipt authority");

        var endpoint = state.SelectConfirmedBonus(Receipt(10), PvpBonusSide.Allies, context, total => total);
        Check(endpoint.Prefab.Index == 8 && endpoint.SourceIndex == 9 && !endpoint.HasValidSourceIndex && state.LastSourceIndex == 9,
            "source upper endpoint is recorded without inventing a valid network index");
        Check(state.SelectConfirmedBonus(Receipt(11), PvpBonusSide.Enemy, context, Draw).SourceIndex == 0,
            "the source endpoint's last index nine excludes no later prefab");

        foreach (Action invalid in new Action[] {
            () => state.EnqueueConfirmedBonus(Receipt(3), PvpBonusSide.Enemy, 7),
            () => state.EnqueueConfirmedBonus(Receipt(3), PvpBonusSide.Allies, 6),
            () => state.EnqueueConfirmedBonus(Receipt(1), PvpBonusSide.Allies, 0),
            () => state.SelectConfirmedBonus(Receipt(3), PvpBonusSide.Allies, context, Draw),
            () => state.SelectConfirmedBonus(Receipt(1), PvpBonusSide.Enemy, context, Draw),
            () => state.SelectConfirmedBonus(Receipt(1), PvpBonusSide.Allies, context with {GoldBonusesCollected=1}, Draw),
            () => state.EnqueueConfirmedBonus("invalid", PvpBonusSide.Allies, 0) })
        {
            try { invalid(); throw new Exception("Changed receipt accepted."); }
            catch (InvalidDataException) { checks++; }
        }
        Check(state.LastSourceIndex == 0 && state.ReceiptCount == 11,
            "changed receipt kind/side/context never mutates accepted selection state");
        foreach (int invalid in new[] {-2,9})
        {
            try { state.EnqueueConfirmedBonus(Receipt(12), PvpBonusSide.Allies, invalid); throw new Exception("Invalid queue index accepted."); }
            catch (ArgumentOutOfRangeException) { checks++; }
        }
        var pending = new PvpBonusSelectionState(catalog);
        pending.EnqueueConfirmedBonus(Receipt(1), PvpBonusSide.Allies, -1);
        foreach (float invalid in new[] {-1f,float.NaN,float.PositiveInfinity,999f})
        {
            try { pending.SelectConfirmedBonus(Receipt(2), PvpBonusSide.Allies, context, _ => invalid); throw new Exception("Invalid draw accepted."); }
            catch (ArgumentOutOfRangeException) { checks++; }
        }
        Check(pending.ReceiptCount == 1 && pending.QueuedCount(PvpBonusSide.Allies) == 1 && pending.LastSourceIndex == 0,
            "failed weighted draws do not consume the source negative queue sentinel");
        Check(pending.SelectConfirmedBonus(Receipt(2), PvpBonusSide.Allies, context, _ => 0).SourceIndex == 1 &&
              pending.QueuedCount(PvpBonusSide.Allies) == 0,
            "source IndexOf -1 sentinel consumes once and falls back to weighted selection");
        var limited = new PvpBonusSelectionState(catalog, maximumReceipts:1);
        limited.EnqueueConfirmedBonus(Receipt(1), PvpBonusSide.Allies, 2);
        try { limited.SelectConfirmedBonus(Receipt(2), PvpBonusSide.Allies, context, Draw); throw new Exception("Receipt capacity exceeded."); }
        catch (InvalidOperationException) { checks++; }
        Check(limited.QueuedCount(PvpBonusSide.Allies) == 1 && limited.LastSourceIndex == 0,
            "receipt exhaustion cannot consume a pending forced bonus");
        var bounded = new PvpBonusSelectionState(catalog);
        for (int ordinal = 1; ordinal <= 64; ordinal++)
            bounded.EnqueueConfirmedBonus(Receipt(ordinal), PvpBonusSide.Allies, 0);
        try { bounded.EnqueueConfirmedBonus(Receipt(65), PvpBonusSide.Allies, 0); throw new Exception("Queue capacity exceeded."); }
        catch (InvalidOperationException) { checks++; }
        Check(bounded.QueuedCount(PvpBonusSide.Allies) == 64 && bounded.ReceiptCount == 64,
            "queue exhaustion leaves every prior pending bonus and receipt intact");
        Check(bounded.SelectConfirmedBonus(Receipt(65), PvpBonusSide.Allies, context,
                  _ => throw new Exception("Forced repeat drew randomly.")).SourceIndex == 0,
            "forced source entry bypasses even the current last-index exclusion");
        try { bounded.EnqueueConfirmedBonus(Receipt(66), (PvpBonusSide)0, 0); throw new Exception("Invalid side accepted."); }
        catch (ArgumentOutOfRangeException) { checks++; }
        return checks;
    }
}

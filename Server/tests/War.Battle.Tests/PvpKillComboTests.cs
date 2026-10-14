using War.BattleServer;
using System.Security.Cryptography;
using System.Text.Json;

internal static class PvpKillComboTests
{
    internal static int Run(string directory)
    {
        int checks = 0;
        void Check(bool condition, string description)
        {
            if (!condition) throw new Exception(description);
            checks++;
        }
        var catalog = BattleCombatContent.Load(Path.Combine(directory,
            "combat-content-manifest.json")).PvpScores;
        string Receipt(int ordinal) => ordinal.ToString("x32");
        var combo = new PvpKillComboState(catalog);
        var first = combo.RecordConfirmedKill(Receipt(1), 0);
        var second = combo.RecordConfirmedKill(Receipt(2), 0.2f);
        var third = combo.RecordConfirmedKill(Receipt(3), 0.4f);
        var fourth = combo.RecordConfirmedKill(Receipt(4), 0.6f);
        Check(first is { Streak: 1, ComboFlag: 0 } && second is { Streak: 2, ComboFlag: 32 } &&
              third is { Streak: 3, ComboFlag: 64 } && fourth is { Streak: 4, ComboFlag: 128 },
            "eligible callbacks share the source double/triple/multi kill history");
        Check(catalog.PointsForConfirmedFlags(0x1210 | second.ComboFlag) == 56 &&
              catalog.PointsForConfirmedFlags(0x1210 | third.ComboFlag) == 66 &&
              catalog.PointsForConfirmedFlags(0x1210 | fourth.ComboFlag) == 96,
            "source multiplayer combo points compose with confirmed Sabotage flags");
        Check(combo.RecordConfirmedKill(Receipt(1), 0) == first &&
              combo.Streak == 4 && combo.LastKillTime == 0.6f && combo.ReceiptCount == 4,
            "an old receipt replays without advancing or rewinding the current combo");
        var boundary = new PvpKillComboState(catalog);
        boundary.RecordConfirmedKill(Receipt(1), 1f);
        Check(boundary.RecordConfirmedKill(Receipt(2), 1f + 0.9f) is { Streak: 1, ComboFlag: 0 },
            "exact source float window resets rather than awarding a double kill");
        boundary.RecordConfirmedKill(Receipt(3), 2f);
        Check(boundary.RecordConfirmedKill(Receipt(4), 2.899f).ComboFlag == 64,
            "a callback strictly inside the source window continues its existing streak");
        var largeClock = new PvpKillComboState(catalog);
        largeClock.RecordConfirmedKill(Receipt(1), 16_777_216f);
        Check(largeClock.RecordConfirmedKill(Receipt(2), 16_777_216f).Streak == 2,
            "Unity Mono comparison precision is preserved for a large float clock");
        byte[] referenceBytes = File.ReadAllBytes(Path.Combine(directory, "unity-pvp-combo-reference.json"));
        Check(Convert.ToHexStringLower(SHA256.HashData(referenceBytes)) ==
              "de80cc4718579f1c17aaab01eabb195aa5d272b58c0367531db29d31a78dcb23",
            "combo comparison uses the reviewed original-method Mono fixture");
        using var reference = JsonDocument.Parse(referenceBytes);
        Check(reference.RootElement.GetProperty("unityVersion").GetString() == "2018.3.0f2" &&
              reference.RootElement.GetProperty("managerSha256").GetString() ==
                  "82a21f9cfa209e8f27b30f6b8f2d61f1f4d510ea1b2429784d012d13dac8d0d8",
            "reference records its exact Unity runtime and recovered source code");
        foreach (var sourceCase in reference.RootElement.GetProperty("cases").EnumerateArray())
        {
            var observed = new PvpKillComboState(catalog);
            int ordinal = 0;
            foreach (var step in sourceCase.GetProperty("steps").EnumerateArray())
            {
                float time = BitConverter.Int32BitsToSingle(step.GetProperty("timeBits").GetInt32());
                var result = observed.RecordConfirmedKill(Receipt(++ordinal), time);
                Check(result.Streak == step.GetProperty("streak").GetInt32() &&
                      result.ComboFlag == step.GetProperty("comboFlag").GetInt32(),
                    "original Mono combo trace: " + sourceCase.GetProperty("name").GetString());
            }
        }
        foreach (float invalid in new[] { -1f, float.NaN, float.PositiveInfinity })
        {
            try { combo.RecordConfirmedKill(Receipt(5), invalid); throw new Exception("Invalid combo clock accepted."); }
            catch (ArgumentOutOfRangeException) { checks++; }
        }
        try { combo.RecordConfirmedKill(Receipt(1), 0.1f); throw new Exception("Changed kill receipt accepted."); }
        catch (InvalidDataException) { checks++; }
        try { combo.RecordConfirmedKill(Receipt(5), 0.5f); throw new Exception("Reordered kill callback accepted."); }
        catch (InvalidDataException) { checks++; }
        Check(combo.Streak == 4 && combo.LastKillTime == 0.6f && combo.ReceiptCount == 4,
            "rejected source clock or receipt cannot mutate combo authority");
        var limited = new PvpKillComboState(catalog, maximumReceipts: 1);
        limited.RecordConfirmedKill(Receipt(1), 0);
        try { limited.RecordConfirmedKill(Receipt(2), 0.1f); throw new Exception("Receipt capacity exceeded."); }
        catch (InvalidOperationException) { checks++; }
        Check(limited.Streak == 1 && limited.ReceiptCount == 1,
            "receipt backpressure leaves the accepted source state unchanged");
        return checks;
    }
}

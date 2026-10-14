using System.Security.Cryptography;
using System.Text.Json;
using War.BattleServer;

internal static class PvpScoreStreakProgressTests
{
    internal static int Run(string directory)
    {
        int checks = 0;
        void Check(bool condition, string description)
        {
            if (!condition) throw new Exception(description);
            checks++;
        }
        var content = BattleCombatContent.Load(Path.Combine(directory, "combat-content-manifest.json"));
        var policy = content.PvpScoreStreak;
        byte[] bytes = File.ReadAllBytes(Path.Combine(directory, "unity-pvp-progress-reference.json"));
        Check(Convert.ToHexStringLower(SHA256.HashData(bytes)) ==
              "fd8dd5a46a418947507dd9a87a8a558248e69a1494d9f561669b08e486007d1f",
            "progress oracle uses the reviewed original-method Mono fixture");
        using var reference = JsonDocument.Parse(bytes);
        Check(reference.RootElement.GetProperty("unityVersion").GetString() == "2018.3.0f2" &&
              reference.RootElement.GetProperty("managerSha256").GetString() ==
                  "b8b3e9a7e07ed310044c536c1f041c2efef6c0390dfa82dcd2424d1d56b11cb6",
            "oracle pins the exact engine and source manager");
        foreach (var sample in reference.RootElement.GetProperty("samples").EnumerateArray())
        {
            float Float(string field) => BitConverter.Int32BitsToSingle(sample.GetProperty(field).GetInt32());
            string name = sample.GetProperty("name").GetString()!;
            float gain = PvpScoreStreakProgress.AddSourceGain(Float("initialBits"),
                sample.GetProperty("points").GetInt32(), Float("ratioBits"), Float("multiplierBits"));
            Check(BitConverter.SingleToInt32Bits(gain) == sample.GetProperty("gainBits").GetInt32() &&
                  sample.GetProperty("gainBits").GetInt32() == sample.GetProperty("opponentGainBits").GetInt32(),
                "source local/opponent progress gain: " + name);
            var frame = PvpScoreStreakProgress.UpdateSourceProgress(gain, Float("deltaBits"),
                sample.GetProperty("running").GetBoolean(), policy);
            Check(BitConverter.SingleToInt32Bits(frame.Progress) == sample.GetProperty("afterBits").GetInt32() &&
                  sample.GetProperty("afterBits").GetInt32() == sample.GetProperty("opponentAfterBits").GetInt32() &&
                  frame.BonusRequested == (sample.GetProperty("bonuses").GetInt32() == 1) &&
                  sample.GetProperty("bonuses").GetInt32() == sample.GetProperty("opponentBonuses").GetInt32(),
                "source decay/clamp/one-bonus Update: " + name);
        }
        string Receipt(int ordinal) => ordinal.ToString("x32");
        var state = new PvpScoreStreakProgress(content.PvpScores, policy, dropsCrates: true);
        float first = state.RecordConfirmedSkillShot(Receipt(1), 0x1210, 1f);
        Check(first == 34.5f, "source Sabotage score rows gain progress using the effective ratio");
        state.RecordConfirmedSkillShot(Receipt(2), 0x1210, 1f);
        state.RecordConfirmedSkillShot(Receipt(3), 0x1210, 1f);
        var award = state.AdvanceFrame(1, 0f, true);
        Check(award is { BonusRequested: true, BonusOrdinal: 1, Progress: 3.5f } && state.BonusesRequested == 1,
            "one host frame requests one bonus and retains the remaining progress");
        Check(state.RecordConfirmedSkillShot(Receipt(1), 0x1210, 1f) == first && state.Progress == 3.5f,
            "old skill-shot replay never restores its previous progress");
        Check(state.AdvanceFrame(1, 0f, true) == award && state.BonusesRequested == 1,
            "frame replay cannot request a second bonus");
        var paused = state.AdvanceFrame(2, 1f, false);
        Check(paused.Progress == 3.5f && !paused.BonusRequested,
            "stopped game frames apply neither decay nor bonus generation");
        Check(state.AdvanceFrame(3, 10f, true).Progress == 0,
            "running decay clamps depleted progress to zero");
        foreach (float invalid in new[] { -.1f, float.NaN, float.PositiveInfinity })
        {
            try { state.AdvanceFrame(4, invalid, true); throw new Exception("Invalid delta accepted."); }
            catch (ArgumentOutOfRangeException) { checks++; }
        }
        foreach (ulong invalid in new ulong[] { 0, 1, 5 })
        {
            try { state.AdvanceFrame(invalid, 0f, true); throw new Exception("Invalid frame order accepted."); }
            catch (InvalidDataException) { checks++; }
        }
        try { state.AdvanceFrame(3, 0f, true); throw new Exception("Changed frame accepted."); }
        catch (InvalidDataException) { checks++; }
        try { state.RecordConfirmedSkillShot(Receipt(1), 0x1210, 1.25f); throw new Exception("Changed multiplier accepted."); }
        catch (InvalidDataException) { checks++; }
        try { state.RecordConfirmedSkillShot(Receipt(1), 16, 1f); throw new Exception("Changed flags accepted."); }
        catch (InvalidDataException) { checks++; }
        foreach (float invalid in new[] { .8f, -1f, float.NaN, float.PositiveInfinity })
        {
            try { state.RecordConfirmedSkillShot(Receipt(4), 16, invalid); throw new Exception("Unsupported multiplier accepted."); }
            catch (ArgumentOutOfRangeException) { checks++; }
        }
        Check(state.Progress == 0 && state.BonusesRequested == 1 && state.ReceiptCount == 3,
            "rejected frames and receipts leave all accepted progress authority unchanged");
        var disabled = new PvpScoreStreakProgress(content.PvpScores, policy, dropsCrates: false);
        Check(disabled.RecordConfirmedSkillShot(Receipt(1), 0x1210, 1.25f) == 0,
            "no-crate allocation cannot earn progress through a booster");
        var effects = new PvpScoreStreakProgress(content.PvpScores, policy, dropsCrates: true, maximumReceipts: 2);
        Check(effects.RecordConfirmedSkillShot(Receipt(1), 0x1210, 0f) == 0 &&
              effects.RecordConfirmedSkillShot(Receipt(2), 0x1210, 1.25f) == 43.125f,
            "source blocker and booster values affect gain without changing source points");
        try { effects.RecordConfirmedSkillShot(Receipt(3), 16, 1f); throw new Exception("Receipt capacity exceeded."); }
        catch (InvalidOperationException) { checks++; }
        Check(effects.Progress == 43.125f && effects.ReceiptCount == 2,
            "receipt capacity exhaustion never partially awards progress");
        return checks;
    }
}

using War.BattleServer;

internal static class PvpSkillShotScoreStateTests
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
        var state = new PvpSkillShotScoreState(catalog);
        Check(state.Score == 0 && state.Counts.Count == 19 && state.Counts.Values.All(count => count == 0),
            "new player score contains every source counter initialized to zero");

        var first = state.RecordConfirmedSkillShot(Receipt(1), 0x1210);
        Check(first.Points == 46 && first.ScoreAfter == 46 && state.Score == 46,
            "confirmed Sabotage rows award source multiplayer points");
        foreach (var row in catalog.Rows)
            Check(state.Counts[row.Flag] == (((first.Flags & row.Flag) == row.Flag) ? 1 : 0),
                "every matching row is counted once: " + row.Name);

        var second = state.RecordConfirmedSkillShot(Receipt(2), 0x1210 | 32);
        Check(second.Points == 56 && state.Score == 102 && state.Counts[32] == 1,
            "a host-derived combo contributes its separate source score row");
        Check(state.RecordConfirmedSkillShot(Receipt(1), first.Flags) == first &&
              state.Score == 102 && state.ReceiptCount == 2 && state.Counts[16] == 2,
            "old skill-shot replay returns its original result without rewinding or recounting");

        foreach (int flags in new[] { -1, 1024, first.Flags | 1024 })
        {
            try { state.RecordConfirmedSkillShot(Receipt(3), flags); throw new Exception("Unknown flags accepted."); }
            catch (ArgumentOutOfRangeException) { checks++; }
        }
        try { state.RecordConfirmedSkillShot(Receipt(1), 16); throw new Exception("Changed receipt accepted."); }
        catch (InvalidDataException) { checks++; }
        try { state.RecordConfirmedSkillShot("invalid", 16); throw new Exception("Invalid receipt accepted."); }
        catch (InvalidDataException) { checks++; }
        Check(state.Score == 102 && state.ReceiptCount == 2 && state.Counts[16] == 2,
            "rejected identity and flags leave all score authority unchanged");

        var limited = new PvpSkillShotScoreState(catalog, maximumReceipts: 1);
        var empty = limited.RecordConfirmedSkillShot(Receipt(1), 0);
        Check(empty.Points == 0 && limited.Score == 0 && limited.Counts.Values.All(count => count == 0),
            "empty source flags have no score or counter effect");
        try { limited.RecordConfirmedSkillShot(Receipt(2), 16); throw new Exception("Capacity exceeded."); }
        catch (InvalidOperationException) { checks++; }
        Check(limited.RecordConfirmedSkillShot(Receipt(1), 0) == empty && limited.ReceiptCount == 1,
            "capacity exhaustion preserves existing replay receipts");
        try { ((IDictionary<int, int>)state.Counts)[16] = 99; throw new Exception("Counts were mutable."); }
        catch (NotSupportedException) { checks++; }
        Check(state.Counts[16] == 2, "published counts cannot be forged by consumers");
        return checks;
    }
}

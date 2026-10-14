using War.BattleServer;

internal static class PvpScoreMultiplierTests
{
    public static int Run()
    {
        int checks = 0;
        static void Expect(bool condition, string message)
        {
            if (!condition) throw new Exception(message);
        }

        var cards = new PvpScoreMultiplierState("red", "blue");
        Expect(cards.ForPlayer("red") == 1f && cards.ForPlayer("blue") == 1f,
            "Both score multipliers start at the source default.");
        checks++;

        cards.UseCard("red", PvpScoreMultiplierState.StreakBoost);
        Expect(cards.ForPlayer("red") == 1.25f && cards.ForPlayer("blue") == 1f,
            "Streak Boost changes only its owner's progress.");
        checks++;

        cards.UseCard("red", PvpScoreMultiplierState.CrateBlocker);
        Expect(cards.ForPlayer("blue") == 0f,
            "Crate Blocker stops the opponent's score progress.");
        checks++;

        cards.Advance(60f);
        Expect(cards.ForPlayer("red") == 1.25f && cards.ForPlayer("blue") == 0f,
            "The source Update expires a zero timer on its next frame.");
        checks++;

        cards.Advance(1f / 30f);
        Expect(cards.ForPlayer("red") == 1f && cards.ForPlayer("blue") == 1f,
            "Both expired cards restore the source default multiplier.");
        checks++;

        cards.UseCard("red", PvpScoreMultiplierState.StreakBoost);
        cards.UseCard("blue", PvpScoreMultiplierState.CrateBlocker);
        Expect(cards.ForPlayer("red") == 0f,
            "A later card assignment overwrites rather than multiplies.");
        checks++;

        cards.Advance(60f);
        cards.Advance(1f / 30f);
        Expect(cards.ForPlayer("red") == 1f,
            "Source expiry callbacks restore one even after an overwrite.");
        checks++;

        try
        {
            cards.UseCard("outsider", PvpScoreMultiplierState.StreakBoost);
            throw new Exception("An outsider used a War Card.");
        }
        catch (InvalidDataException) { checks++; }

        try
        {
            cards.Advance(float.NaN);
            throw new Exception("A malformed game delta advanced card time.");
        }
        catch (ArgumentOutOfRangeException) { checks++; }

        return checks;
    }
}

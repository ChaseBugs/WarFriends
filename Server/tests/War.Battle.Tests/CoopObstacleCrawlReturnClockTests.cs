using War.BattleServer;

/// <summary>Checks strict return deadlines, repeated rounds and source callback ordering.</summary>
internal static class CoopObstacleCrawlReturnClockTests
{
    private const float HideAfterSeconds = 0.5f;

    internal static void Run()
    {
        var clock = new CoopObstacleCrawlReturnClock();
        Require(!clock.Update(0f), "An idle timer cannot return to crawl.");
        clock.RecordShot(1f, HideAfterSeconds);
        Require(!clock.Update(1.5f), "Deadline equality must not play crawl.");
        Require(clock.Update(float.BitIncrement(1.5f)), "The first representable later time must play crawl.");
        Require(!clock.Update(2f), "A consumed return event cannot play again.");

        VerifyRepeatedRounds();
        VerifyCallbackOrder();
        VerifyRejectedInput();
        Console.WriteLine("PASS: obstacle float crawl deadlines, resets, callback order and invalid-time atomicity");
    }

    private static void VerifyRepeatedRounds()
    {
        var clock = new CoopObstacleCrawlReturnClock();
        clock.RecordShot(1f, HideAfterSeconds);
        clock.RecordShot(1.25f, HideAfterSeconds);
        Require(!clock.Update(1.5f), "Each emitted round must extend the return deadline.");
        Require(!clock.Update(1.75f), "The extended deadline still uses strict comparison.");
        Require(clock.Update(float.BitIncrement(1.75f)), "The extended return must eventually fire.");
    }

    private static void VerifyCallbackOrder()
    {
        float afterDeadline = float.BitIncrement(1.5f);
        var updateFirst = new CoopObstacleCrawlReturnClock();
        updateFirst.RecordShot(1f, HideAfterSeconds);
        Require(updateFirst.Update(afterDeadline), "An expired Update before a new shot returns to crawl.");
        updateFirst.RecordShot(afterDeadline, HideAfterSeconds);
        Require(!updateFirst.Update(afterDeadline), "The new shot arms a separate deadline.");

        var shotFirst = new CoopObstacleCrawlReturnClock();
        shotFirst.RecordShot(1f, HideAfterSeconds);
        shotFirst.RecordShot(afterDeadline, HideAfterSeconds);
        Require(!shotFirst.Update(afterDeadline), "A shot before Update postpones the expired return.");
    }

    private static void VerifyRejectedInput()
    {
        var clock = new CoopObstacleCrawlReturnClock();
        clock.RecordShot(1f, HideAfterSeconds);
        foreach (float invalidTime in new[] { float.NaN, float.PositiveInfinity, -1f, 0.5f })
        {
            Reject(() => clock.Update(invalidTime));
            Reject(() => clock.RecordShot(invalidTime, HideAfterSeconds));
        }

        foreach (float invalidDelay in new[] { float.NaN, float.PositiveInfinity, -1f, 0f, float.Epsilon })
        {
            Reject(() => clock.RecordShot(2f, invalidDelay));
        }

        Reject(() => clock.RecordShot(float.MaxValue, float.MaxValue));
        Require(clock.Deadline == 1.5f, "Rejected input must preserve the pending deadline.");
        Require(clock.Update(float.BitIncrement(1.5f)), "Rejected input must not advance observed time.");
    }

    private static void Reject(Action action)
    {
        try
        {
            action();
        }
        catch (InvalidDataException)
        {
            return;
        }

        throw new Exception("Invalid crawl timer input was accepted.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }
}
